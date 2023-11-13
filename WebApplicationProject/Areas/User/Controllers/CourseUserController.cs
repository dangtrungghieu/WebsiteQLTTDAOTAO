using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.User.Controllers
{
    public class CourseUserController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: User/CourseUser
        public ActionResult MyCourse()
        {
            var hocvien = from hv in db.DANGKY.Where(n => n.MaHocVien_DangKy == 4) select hv;
            return View(hocvien);
        }

        public ActionResult MyWishList()
        {
            var khoahoc = from hv in db.DANGKY.Where(n => n.MaHocVien_DangKy == 4) select hv;
            return View(khoahoc);
        }

        public ActionResult DetailsCourse(int? id)
        {
            var khoahoc = db.KHOAHOC.Find(id);
            return View(khoahoc);
        }
    }
}