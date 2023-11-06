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
            var kq = from gv in db.NHANVIEN.Where(n => n.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên") select gv;
            int iSize = 12;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                kq = kq.Where(b => b.TenNhanVien.Contains(strSearch));
            }
            return View(kq.OrderBy(s => s.MaNhanVien).ToPagedList(iPageNum, iSize));
        }
    }
}