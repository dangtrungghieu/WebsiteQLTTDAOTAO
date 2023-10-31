using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        
        //Get: Dang Nhap Admin
        public ActionResult Admin()
        {
            int soLuongHocSinh, soLuongGiaoVien, soLuongKhoaHoc, soLuongLopHoc;
            soLuongHocSinh = db.HOCVIEN.Count(n => n.MaHocVien.ToString() != null);
            soLuongGiaoVien = db.NHANVIEN.Count(n => n.MaNhanVien.ToString() != null && n.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên");
            soLuongKhoaHoc = db.KHOAHOC.Count(n => n.MaKhoaHoc.ToString() != null);
            soLuongLopHoc = db.LOP.Count(n => n.MaLop.ToString() != null);
            ViewBag.SoLuongHocSinh = soLuongHocSinh;
            ViewBag.SoLuongGiaoVien = soLuongGiaoVien;
            ViewBag.SoLuongKhoaHoc = soLuongKhoaHoc;
            ViewBag.SoLuongLopHoc = soLuongLopHoc;
            return View();
        }

        //Partial Nav Admin
        [ChildActionOnly]
        public ActionResult NavAdmin()
        {
            return PartialView("NavAdmin");
        }

        //Partial NavRight
        [ChildActionOnly]
        public ActionResult NavRight()
        {
            return PartialView("NavRight");
        }

        public ActionResult SearchCourse()
        {
            return View();
        }

        public ActionResult FooterAdmin()
        {
            return View();
        }
    }
}