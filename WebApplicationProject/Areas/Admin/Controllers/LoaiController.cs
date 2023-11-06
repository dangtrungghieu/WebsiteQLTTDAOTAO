using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class LoaiController : Controller
    {
        //Khai bao CSDL
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Loai
        [HttpGet]
        public ActionResult Index()
        {
            var loai = db.LOAI.ToList(); // Lấy danh sách tất cả các loại
            var loaiWithCount = new List<LoaiWithCount>(); // Tạo danh sách mới để lưu thông tin loại và số lượng

            foreach (var item in loai)
            {
                int soLuong = db.PHONGHOC.Count(n => n.MaLoaiPhong_PhongHoc == item.MaLoai);
                loaiWithCount.Add(new LoaiWithCount
                {
                    TenLoai = item.TenLoai,
                    SoLuong = soLuong
                });
            }
            return View(loaiWithCount);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TenNV = "Đặng Trung Hiếu";
            ViewBag.MaNV = "5";
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f, LOAI l)
        {
            string ten = f["sTen"];
            var loai = db.LOAI.Select(b => b);
            var kq = db.LOAI.SingleOrDefault(n => n.TenLoai == ten);
            if (kq != null)
            {
                ViewBag.Ten = ten;
                ViewBag.ThongBao = "Tên loại đã tồn tại";
            }
            else if(ModelState.IsValid)
            {
                l.TenLoai = f["sTen"];
                l.MaNhanVien_Loai = 5;
                l.NgayTao = Convert.ToDateTime(f["sNgayTao"]);
                db.LOAI.Add(l);
                db.SaveChanges();
                return RedirectToAction("Index", "PhongHoc");
            }
            return View();
        }
    }
}