using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Models;
namespace WebApplicationProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Khai bao Entities 
        FinalProject db = new FinalProject();
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Course()
        {
            var khoahoc = from kh in db.KHOAHOC select kh;
            return View(khoahoc.OrderBy(s => s.MaKhoaHoc));
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Teacher()
        {
            var giaovien = (from gv in db.NHANVIEN
                            where gv.MaLoai_NhanVien == 6
                            select gv).ToList();
            return View(giaovien);
        }

        public ActionResult Price()
        {
            return View();
        }

        public ActionResult Review()
        {
            return View();
        }
    }
}