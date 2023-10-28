using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        
        //Get: Dang Nhap Admin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult NavAdmin()
        {
            return View();
        }

        public ActionResult NavRight()
        {
            return View();
        }
    }
}