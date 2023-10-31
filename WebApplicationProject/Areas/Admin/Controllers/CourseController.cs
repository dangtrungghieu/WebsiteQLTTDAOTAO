using PagedList;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Course
        [HttpGet]
        public ActionResult Index(int ?page, string strSearch)
        {
            ViewBag.Search = strSearch;
            var kq = db.KHOAHOC.Select(b => b);
            int iSize = 12;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                kq = kq.Where(b => b.TenKhoaHoc.Contains(strSearch));
            }
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
            return View();
        }

        // GET: Admin/Course/Delete
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var khoahoc = db.KHOAHOC.Find(id);
            return View(khoahoc);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOAHOC khoahoc = db.KHOAHOC.Find(id);
            if (khoahoc == null)
            {
                return HttpNotFound();
            }
            return View(khoahoc);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection f, HttpPostedFileBase sAnhBia)
        {
            var maKhoaHoc = int.Parse(f["sMaKhoaHoc"]);
            var ngayCapNhat = DateTime.Parse(f["sNgayCapNhat"]);
            var ngayHienTai = DateTime.Now;
            var khoahoc = db.KHOAHOC.SingleOrDefault(n => n.MaKhoaHoc == maKhoaHoc);
           if (ModelState.IsValid)
            {
                if (sAnhBia != null)
                {
                    var sFileName = Path.GetFileName(sAnhBia.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), sFileName);
                    if (!System.IO.File.Exists(path))
                    {
                        sAnhBia.SaveAs(path);
                    }
                    khoahoc.AnhKhoaHoc = sFileName;
                }
                khoahoc.TenKhoaHoc = f["sTenKhoaHoc"];
                khoahoc.MoTa = f["sMoTa"];
                khoahoc.NgayTao = Convert.ToDateTime(f["sNgayCapNhat"]);
                khoahoc.LePhi = int.Parse(f["sLePhi"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoahoc);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var khoahoc = db.KHOAHOC.SingleOrDefault(n => n.MaKhoaHoc == id);
            if (khoahoc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khoahoc);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, FormCollection f)
        {
            var khoahoc = db.KHOAHOC.SingleOrDefault(n => n.MaKhoaHoc == id);
            if (khoahoc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //var ctdh = db.CHITIETDATHANG.Where(ct => ct.MaSach == id);
            //if (ctdh.Count() > 0)
            //{
            //    ViewBag.ThongBao = "Sách hiện đang có trong bảng Chi Tiết Đặt Hàng <br>" + "Bạn vẫn muốn xóa quyển sách này chứ?";
            //    return View(sach);
            //}
            //var vietsach = db.VIETSACH.Where(vs => vs.MaSach == id).ToList();
            //if (vietsach != null)
            //{
            //    db.VIETSACH.RemoveRange(vietsach);
            //    db.SaveChanges();
            //}
            db.KHOAHOC.Remove(khoahoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}