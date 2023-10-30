using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
using PagedList.Mvc;
using System.IO;

namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Course
        [HttpGet]
        public ActionResult Index(int ?page, string strSearch)
        {
            int iSize = 12;
            int iPageNum = (page ?? 1);
            if (String.IsNullOrEmpty(strSearch))
            {
                var khoahoc = from kh in db.KHOAHOC select kh;
                return View(khoahoc.OrderBy(n => n.MaKhoaHoc).ToPagedList(iPageNum, iSize));
            }
            var kq = from s in db.KHOAHOC where s.TenKhoaHoc.Contains(strSearch) || s.MaKhoaHoc.ToString().Contains(strSearch) select s;
            return View(kq.OrderBy(s => s.MaKhoaHoc).ToPagedList(iPageNum, iSize));
        }
        // GET: Admin/Course/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection f, KHOAHOC kh, HttpPostedFileBase sAnhBia)
        {
            var ngayTao = DateTime.Parse(f["sNgayTao"]);
            var ngayHienTai = DateTime.Now;
             if (ngayTao < ngayHienTai)
            {
                ViewBag.AnhBia = f["sAnhBia"];
                ViewBag.ThongBaoNgayTao = "Ngày tạo không phù hợp.";
                ViewBag.Ten = f["sTen"];
                ViewBag.MoTa = f["sMoTa"];
                ViewBag.LePhi = int.Parse(f["sLePhi"]);
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var sFileName = Path.GetFileName(sAnhBia.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/"), sFileName);
                    if (!System.IO.File.Exists(path))
                    {
                        sAnhBia.SaveAs(path);
                    }
                    kh.TenKhoaHoc = f["sTen"];
                    kh.MoTa = f["sMoTa"];
                    kh.AnhKhoaHoc = sFileName;
                    kh.LePhi = int.Parse(f["sLePhi"]);
                    kh.NgayTao = Convert.ToDateTime(f["sNgayTao"]);
                    kh.MaNhanVien_KhoaHoc = int.Parse(f["sMaNV"]);
                    db.KHOAHOC.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: Admin/Course/Delete
        [HttpGet]
        public ActionResult Details(int? maKhoaHoc)
        {
            var khoahoc = db.KHOAHOC.SingleOrDefault(n => n.MaKhoaHoc == maKhoaHoc);
            return View(khoahoc);
        }

    }
}