using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
using PagedList;

namespace WebApplicationProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Khai bao Entities 
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Course(int ?page)
        {
            int iSize = 12;
            int iPageNum = (page ?? 1);
            var khoahoc = from kh in db.KHOAHOC select kh;
            return View(khoahoc.OrderBy(s => s.MaKhoaHoc).ToPagedList(iPageNum, iSize));
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Teacher()
        {
            var giaovien = (from gv in db.NHANVIEN
                            where gv.MaLoai_NhanVien == 2
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

        public ActionResult NavHeader()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }

    }
}