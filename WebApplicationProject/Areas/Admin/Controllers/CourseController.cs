using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
using PagedList.Mvc;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Course
        [HttpGet]
        public ActionResult Index(int ?page)
        {
            int iSize = 12;
            int iPageNum = (page ?? 1);
            var khoahoc = from kh in db.KHOAHOC select kh;
            return View(khoahoc.OrderBy(n => n.MaKhoaHoc).ToPagedList(iPageNum, iSize));
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}