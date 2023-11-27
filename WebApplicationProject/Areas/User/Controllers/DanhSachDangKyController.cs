using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.User.Controllers
{
    public class DanhSachDangKyController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: User/DanhSachDangKy
        public List<DanhSachDangky> LayDanhSach()
        {
            List<DanhSachDangky> lstDanhSachDangKy = Session["DanhSachDangKy"] as List<DanhSachDangky>;
            if (lstDanhSachDangKy == null )
            {
                lstDanhSachDangKy = new List<DanhSachDangky>();
                Session["DanhSachDangKy"] = lstDanhSachDangKy;
            }
            return lstDanhSachDangKy;
        }

        public ActionResult ThemDanhSachDangKy(int mkh, string url)
        {
            List<DanhSachDangky> lstDanhSachDangKy = LayDanhSach();
            DanhSachDangky kh = lstDanhSachDangKy.Find(n => n.iMakhoaHoc == mkh);
            if (kh == null)
            {
                kh = new DanhSachDangky(mkh);
                lstDanhSachDangKy .Add(kh);
            }
            else
            {
                //kh.iSoLuong++;
            }
            return Redirect(url);
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<DanhSachDangky> lstDanhSachDangKy = Session["DanhSachDangKy"] as List<DanhSachDangky>;
            if (lstDanhSachDangKy != null)
            {
                iTongSoLuong = lstDanhSachDangKy.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }

        private Nullable<double> TongLePhi()
        {
            Nullable <double> dTongLePhi = 0;
            List<DanhSachDangky> lstDanhSachDangKy = Session["DanhSachDangKy"] as List<DanhSachDangky>;
            if (lstDanhSachDangKy != null)
            {
                dTongLePhi = lstDanhSachDangKy.Sum(n => n.dThanhTien);
            }
            return dTongLePhi;
        }

        public ActionResult DanhSachDangKy()
        {
            List<DanhSachDangky> lstDanhSachDangKy = LayDanhSach();
            if (lstDanhSachDangKy.Count == 0)
            {
                return RedirectToAction("Course", "Home", new { area = "" });
            }
            //ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongLePhi();
            return View(lstDanhSachDangKy);
        }

        public ActionResult DanhSachDangKyPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongLePhi();
            return PartialView();
        }

        public ActionResult XoaKh(int iMaKhoaHoc)
        {
            List<DanhSachDangky> lstDanhSachDangKy = LayDanhSach();
            DanhSachDangky kh = lstDanhSachDangKy.SingleOrDefault(n => n.iMakhoaHoc == iMaKhoaHoc);
            if (kh != null)
            {
                lstDanhSachDangKy.RemoveAll(n => n.iMakhoaHoc == iMaKhoaHoc);
                if (lstDanhSachDangKy.Count == 0)
                {
                    return RedirectToAction("Course", "Home", new { area = "" });
                }
            }
            return RedirectToAction("DanhSachDangKy");
        }
        public ActionResult CapNhatDSDK(int iMaKhoaHoc, FormCollection f)
        {
            List<DanhSachDangky> lstDanhSachDangKy = LayDanhSach();
            DanhSachDangky kh = lstDanhSachDangKy.SingleOrDefault(n => n.iMakhoaHoc == iMaKhoaHoc);
            return RedirectToAction("DanhSachDangKy");
        }
        public ActionResult XoaDSDK()
        {
            List<DanhSachDangky> lstDanhSachDangKy = LayDanhSach();
            lstDanhSachDangKy.Clear();
            return RedirectToAction("Course", "Home", new { area = "" });
        }

    }
}