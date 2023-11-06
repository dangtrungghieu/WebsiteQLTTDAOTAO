using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.User.Controllers
{
    public class UserController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: User/User
        public ActionResult ProFile()
        {
            var hocvien = db.HOCVIEN.FirstOrDefault(hv => hv.MaHocVien == 4);
            return View(hocvien);
        }
        // GET: User/Login
        public ActionResult Login()
        {
            return View();
        }
        // GET: User/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}