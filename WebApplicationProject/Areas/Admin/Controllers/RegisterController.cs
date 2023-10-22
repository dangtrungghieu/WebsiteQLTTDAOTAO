using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}