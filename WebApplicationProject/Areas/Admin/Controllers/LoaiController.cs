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
        public ActionResult Index()
        {
            var loai = db.LOAI.Select(n => n);
            return View(loai.OrderBy(n => n.MaLoai));
        }
    }
}