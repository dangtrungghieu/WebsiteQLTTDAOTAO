using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
using PagedList;
using PagedList.Mvc;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class LopController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Lop
        [HttpGet]
        public ActionResult Index(int? page, string strSearch)
        {
            var kq = db.LOP.Select(n => n);
            int iSize = 15;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                ViewBag.Search = strSearch;
                kq = kq.Where(b => b.TenLop.Contains(strSearch));
            }
            return View(kq.OrderBy(s => s.MaLop).ToPagedList(iPageNum, iSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            CapNhatTinhTrangPhongHoc();
            DanhSachKH_CH_PH_Loai ds = new DanhSachKH_CH_PH_Loai
            {
                KhoahocList = db.KHOAHOC.ToList(),
                CahocList = db.CAHOC.ToList(),
                LoaiList = db.LOAI.ToList(),
                GiangvienList = db.NHANVIEN.Where(n => n.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên").ToList(),
                PhongHocList = db.PHONGHOC.Where(n => n.TinhTrang == "Còn Trống").ToList()
            };
            return View(ds);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection f, LOP lop)
        {
            CapNhatTinhTrangPhongHoc();
            DanhSachKH_CH_PH_Loai ds = new DanhSachKH_CH_PH_Loai
            {
                KhoahocList = db.KHOAHOC.ToList(),
                CahocList = db.CAHOC.ToList(),
                LoaiList = db.LOAI.ToList(),
                GiangvienList = db.NHANVIEN.Where(n => n.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên").ToList(),
                PhongHocList = db.PHONGHOC.Where(n => n.TinhTrang == "Còn Trống").ToList()
            };
            string ten = f["sTen"];
            var maLoaiLop = int.Parse(f["sLoaiLop"]);
            var maPhongHoc = int.Parse(f["sPhongHoc"]);
            var kiemtra_ten = db.LOP.SingleOrDefault(n => n.TenLop == ten);
            var ngaykhaigiang = Convert.ToDateTime(f["sNgayKhaiGiang"]);
            var ngayketthuc = Convert.ToDateTime(f["sNgayKetThuc"]);
            var kt_loai = db.PHONGHOC.SingleOrDefault(n => n.MaPhongHoc == maPhongHoc && n.MaLoaiPhong_PhongHoc == maLoaiLop);
            if(kiemtra_ten != null)
            {
                ViewBag.Ten = ten;
                ViewBag.ThongBao = "Tên lớp đã tồn tại!";
                ViewBag.NgayKhaiGiang = Convert.ToDateTime(f["sNgayKhaiGiang"]);
                ViewBag.NgayKetThuc = Convert.ToDateTime(f["sNgayKetThuc"]);
            }
            else if (kt_loai == null)
            {
                ViewBag.Ten = ten;
                ViewBag.NgayKhaiGiang = Convert.ToDateTime(f["sNgayKhaiGiang"]);
                ViewBag.NgayKetThuc = Convert.ToDateTime(f["sNgayKetThuc"]);
                ViewBag.ThongBaoPhong = "Phòng học không phù hợp!";
            }
            else if (ngaykhaigiang < DateTime.Now || ngaykhaigiang > ngayketthuc)
            {
                ViewBag.Ten = ten;
                ViewBag.NgayKhaiGiang = Convert.ToDateTime(f["sNgayKhaiGiang"]);
                ViewBag.NgayKetThuc = Convert.ToDateTime(f["sNgayKetThuc"]);
                ViewBag.ThongBaoNgay = "Ngày khai giảng không hợp lệ!";
            }
            else if (ModelState.IsValid)
            {
                lop.TenLop = ten;
                lop.NgayKhaiGiang = Convert.ToDateTime(f["sNgayKhaiGiang"]);
                lop.NgayKetThuc = Convert.ToDateTime(f["sNgayKetThuc"]);
                lop.MaCaHoc_Lop = int.Parse(f["sCaHoc"]);
                lop.MaGiangVien_Lop = int.Parse(f["sGiaoVien"]);
                lop.MaKhoaHoc_Lop = int.Parse(f["sKhoaHoc"]);
                lop.MaLoaiLop_Lop = int.Parse(f["sLoaiLop"]);
                lop.MaPhongHoc_Lop = int.Parse(f["sPhongHoc"]);
                db.LOP.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ds);
        }

        //Hàm kiểm tra, cập nhật tình trạng phòng học trước khi lấy dữ liệu
        private void CapNhatTinhTrangPhongHoc()
        {
            var phongHocCanCapNhat = db.PHONGHOC.ToList(); // Lấy danh sách tất cả các phòng học

            foreach (var phongHoc in phongHocCanCapNhat)
            {
                // Lấy số lớp học trong phòng học cho các ca 1, 2 và 4
                var soCaHoc = db.LOP.Count(lh => lh.MaPhongHoc_Lop == phongHoc.MaPhongHoc && (lh.MaCaHoc_Lop == 1 || lh.MaCaHoc_Lop == 2 || lh.MaCaHoc_Lop == 4));

                if (soCaHoc < 3)
                {
                    // Kiểm tra tình trạng ban đầu trước khi cập nhật
                    if (phongHoc.TinhTrang != "Đang Sửa")
                    {
                        phongHoc.TinhTrang = "Còn Trống";
                    }
                }
                else
                {
                    // Kiểm tra tình trạng ban đầu trước khi cập nhật
                    if (phongHoc.TinhTrang != "Đang Sửa")
                    {
                        phongHoc.TinhTrang = "Đủ";
                    }
                }
            }
            db.SaveChanges();
        }
    }
}