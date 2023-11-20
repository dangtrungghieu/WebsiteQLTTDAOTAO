using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/NhanVien
        public ActionResult Index(int? page, string strSearch)
        {
            ViewBag.Search = strSearch;
            var kq = from nv in db.NHANVIEN where nv.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên" select nv;
            int iSize = 12;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                kq = kq.Where(b => b.TenNhanVien.Contains(strSearch));
            }
            return View(kq.OrderBy(s => s.LOAINHANVIEN.MaLoaiNhanVien).ToPagedList(iPageNum, iSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            DanhSachKH_CH_PH_Loai model = new DanhSachKH_CH_PH_Loai();
            model.KhoahocList = db.KHOAHOC.ToList(); 
            model.LoaiList = db.LOAI.ToList(); 
            model.CahocList = db.CAHOC.ToList(); 
            model.GiangvienList = db.NHANVIEN.Where(nv => nv.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên").ToList();
            model.PhongHocList = db.PHONGHOC.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var nv = db.NHANVIEN.Find(id);
            DateTime ngaySinh = nv.NgaySinh;
            TimeSpan timeSpan = DateTime.Now - ngaySinh;
            int tuoi = (int)(timeSpan.Days / 365.25);
            ViewBag.Tuoi = tuoi;
            int countHS = db.DANGKY.Count(n => n.LOP.NHANVIEN.MaNhanVien == id);
            ViewBag.SoLuongHocSinhHienTai = countHS;
            int coutLop = db.LOP.Count(n => n.NHANVIEN.MaNhanVien == id && n.NgayKetThuc >= DateTime.Now);
            ViewBag.SoLuongLopHocHienTai =coutLop;
            int coutLopHT = db.LOP.Count(n => n.NHANVIEN.MaNhanVien == id && n.NgayKetThuc < DateTime.Now);
            ViewBag.SoLuongLopHocHoanThanh = coutLopHT;
            int khoaHocThamGia = db.KHOAHOC
                .Where(kh => db.LOP.Any(lh => lh.MaKhoaHoc_Lop == kh.MaKhoaHoc && lh.MaGiangVien_Lop == id))
                .Count();
            ViewBag.SoLuongKhoaHocThamGia = khoaHocThamGia;
            return View(nv);
        }
        [HttpGet]
        public ActionResult XemLichDay(int? id)
        {
            var teacher = db.NHANVIEN.FirstOrDefault(t => t.MaNhanVien == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            CalendarViewModel model = new CalendarViewModel();
            DateTime today = DateTime.Now;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(6);

            model.StartDate = startDate;
            model.DisplayDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                .Select(offset => startDate.AddDays(offset))
                .ToList();

            model.ClassesByDate = GetClassesForTeacher((int)id, model.DisplayDates);

            return View(model);
        }
        private Dictionary<DateTime, List<ClassInfo>> GetClassesForTeacher(int teacherId, List<DateTime> displayDates)
        {
            Dictionary<DateTime, List<ClassInfo>> classesByDate = new Dictionary<DateTime, List<ClassInfo>>();

            foreach (var date in displayDates)
            {
                List<ClassInfo> classesForDate = db.LOP
                    .Where(c => c.NgayKhaiGiang <= date && c.NgayKetThuc >= date && (c.CAHOC.NgayHocTrongTuan.Contains(((int)date.DayOfWeek + 1).ToString())) && c.NHANVIEN.MaNhanVien == teacherId)
                    .Select(c => new ClassInfo
                    {
                        ClassName = c.TenLop,
                        ClassKhoaHoc = c.KHOAHOC.TenKhoaHoc,
                        ClassGiaoVien = c.NHANVIEN.TenNhanVien,
                        ClassSiSoToiDa = c.PHONGHOC.SucChua,
                        ClassSoLuongDangKy = db.DANGKY.Count(m => m.MaLopHoc_DangKy == c.MaLop && m.TinhTrang == "Đã đăng ký")
                    })
                    .ToList();

                classesByDate[date] = classesForDate;
            }

            return classesByDate;
        }

    }
}