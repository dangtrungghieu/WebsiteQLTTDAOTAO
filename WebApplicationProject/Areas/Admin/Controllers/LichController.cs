using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class LichController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Lich
        [HttpGet]
        public ActionResult Index()
        {
            //Hiển thị Calendar
            CalendarViewModel model = new CalendarViewModel();
            // Tính toán StartDate và DisplayDates
            DateTime today = DateTime.Now;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(6);

            model.StartDate = startDate;
            model.DisplayDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                .Select(offset => startDate.AddDays(offset))
                .ToList();

            // Thêm thông tin về giờ học
            model.ClassesByDate = new Dictionary<DateTime, List<ClassInfo>>();
            foreach (var date in model.DisplayDates)
            {
                List<ClassInfo> classesForDate = GetClassesForDate(date);
                model.ClassesByDate[date] = classesForDate;
            }

            return View(model);
        }

        private List<ClassInfo> GetClassesForDate(DateTime date)
        {

            return db.LOP
                .Where(c => c.NgayKhaiGiang <= date && c.NgayKetThuc >= date && c.CAHOC.TenCaHoc.Contains("Sáng") && (c.CAHOC.NgayHocTrongTuan.Contains(((int)date.DayOfWeek + 1).ToString())))
                .Select(c => new ClassInfo
                {
                    ClassName = c.TenLop,
                    ClassKhoaHoc = c.KHOAHOC.TenKhoaHoc,
                    ClassGiaoVien = c.NHANVIEN.TenNhanVien,
                    ClassSiSoToiDa = c.PHONGHOC.SucChua,
                    ClassSoLuongDangKy = db.DANGKY.Count(m => m.MaLopHoc_DangKy == c.MaLop && m.TinhTrang == "Đã đăng ký")
                })
                .ToList();
        }
        [HttpGet]
        public ActionResult Index2()
        {
            //Hiển thị Calendar
            CalendarViewModel model = new CalendarViewModel();
            // Tính toán StartDate và DisplayDates
            DateTime today = DateTime.Now;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(6);

            model.StartDate = startDate;
            model.DisplayDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                .Select(offset => startDate.AddDays(offset))
                .ToList();

            // Thêm thông tin về giờ học
            model.ClassesByDate = new Dictionary<DateTime, List<ClassInfo>>();
            foreach (var date in model.DisplayDates)
            {
                List<ClassInfo> classesForDate = GetClassesForDate2(date);
                model.ClassesByDate[date] = classesForDate;
            }

            return View(model);
        }

        private List<ClassInfo> GetClassesForDate2(DateTime date)
        {

            return db.LOP
                .Where(c => c.NgayKhaiGiang <= date && c.NgayKetThuc >= date && c.CAHOC.TenCaHoc.Contains("Chiều") && (c.CAHOC.NgayHocTrongTuan.Contains(((int)date.DayOfWeek + 1).ToString())))
                .Select(c => new ClassInfo
                {
                    ClassName = c.TenLop,
                    ClassKhoaHoc = c.KHOAHOC.TenKhoaHoc,
                    ClassGiaoVien = c.NHANVIEN.TenNhanVien,
                    ClassSiSoToiDa = c.PHONGHOC.SucChua,
                    ClassSoLuongDangKy = db.DANGKY.Count(m => m.MaLopHoc_DangKy == c.MaLop && m.TinhTrang == "Đã đăng ký")
                })
                .ToList();
        }
        [HttpGet]
        public ActionResult Index3()
        {
            //Hiển thị Calendar
            CalendarViewModel model = new CalendarViewModel();
            // Tính toán StartDate và DisplayDates
            DateTime today = DateTime.Now;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(6);

            model.StartDate = startDate;
            model.DisplayDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                .Select(offset => startDate.AddDays(offset))
                .ToList();

            // Thêm thông tin về giờ học
            model.ClassesByDate = new Dictionary<DateTime, List<ClassInfo>>();
            foreach (var date in model.DisplayDates)
            {
                List<ClassInfo> classesForDate = GetClassesForDate3(date);
                model.ClassesByDate[date] = classesForDate;
            }

            return View(model);
        }

        private List<ClassInfo> GetClassesForDate3(DateTime date)
        {

            return db.LOP
                .Where(c => c.NgayKhaiGiang <= date && c.NgayKetThuc >= date && c.CAHOC.TenCaHoc.Contains("Tối") && (c.CAHOC.NgayHocTrongTuan.Contains(((int)date.DayOfWeek + 1).ToString())))
                .Select(c => new ClassInfo
                {
                    ClassName = c.TenLop,
                    ClassKhoaHoc = c.KHOAHOC.TenKhoaHoc,
                    ClassGiaoVien = c.NHANVIEN.TenNhanVien,
                    ClassSiSoToiDa = c.PHONGHOC.SucChua,
                    ClassSoLuongDangKy = db.DANGKY.Count(m => m.MaLopHoc_DangKy == c.MaLop && m.TinhTrang == "Đã đăng ký")
                })
                .ToList();
        }

        [HttpGet]
        public ActionResult TinhTrangDangKyKhoaHoc()
        {
            var dk = db.LOP.ToList();
            var tt = new List<TinhTrangDangKy>();
            foreach(var item in dk)
            {
                int tongdk = db.DANGKY.Count(n => n.MaLopHoc_DangKy == item.MaLop);
                tt.Add(new TinhTrangDangKy
                {
                    maLop = item.MaLop,
                    tenLop = item.TenLop,
                    tenGiaoVien = item.NHANVIEN.TenNhanVien,
                    tenKhoaHoc = item.KHOAHOC.TenKhoaHoc,
                    tongSoDangKyHienTai = tongdk,
                    siSo = item.PHONGHOC.SucChua

                });
            }
            return View(tt);
        }
    }
}