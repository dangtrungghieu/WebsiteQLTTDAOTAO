using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/NhanVien
        public ActionResult Index(int? page, string strSearch)
        {
            ViewBag.Search = strSearch;
            var kq = db.NHANVIEN.Select(b => b);
            int iSize = 12;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                kq = kq.Where(b => b.TenNhanVien.Contains(strSearch));
            }
            return View(kq.OrderBy(s => s.LOAINHANVIEN.MaLoaiNhanVien).ToPagedList(iPageNum, iSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
    }
}