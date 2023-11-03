using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class PhongHocController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/PhongHoc
        public ActionResult Index(int? page, string strSearch)
        {
            var kq = db.PHONGHOC.Select(n => n);
            int iSize = 10;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                ViewBag.Search = strSearch;
                kq = kq.Where(b => b.TenPhongHoc.Contains(strSearch));
            }
            return View(kq.OrderBy(s => s.MaPhongHoc).ToPagedList(iPageNum, iSize));
        }

        //GET: Admin/PhongHoc/Create
        [HttpGet]
        public ActionResult Create()
        {
            var loaiPhong = from lp in db.LOAI select lp;
            return View(loaiPhong.ToList().OrderBy(n => n.MaLoai));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PHONGHOC phongHoc, FormCollection f)
        {
            string sTen = f["sTen"];
            var loaiPhong = from lp in db.LOAI select lp;
            var tenPhong = db.PHONGHOC.SingleOrDefault(n => n.TenPhongHoc == sTen);
            if(tenPhong != null)
            {
                ViewBag.Ten = sTen;
                ViewBag.SucChua = f["sSucChua"];
                ViewBag.ThongBao = "Tên phòng học đã tồn tại!";
            }
            else if (ModelState.IsValid)
            {
                phongHoc.TenPhongHoc = f["sTen"];
                phongHoc.SucChua = int.Parse(f["sSucChua"]);
                phongHoc.TinhTrang = f["sTinhTrang"];
                phongHoc.NgayTao = Convert.ToDateTime(f["sNgayTao"]);
                phongHoc.MaNhanVien_PhongHoc = int.Parse(f["sMaNV"]);
                phongHoc.MaLoaiPhong_PhongHoc = int.Parse(f["sLoaiPhong"]);
                db.PHONGHOC.Add(phongHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiPhong.ToList().OrderBy(n => n.MaLoai));
        }

    }
}