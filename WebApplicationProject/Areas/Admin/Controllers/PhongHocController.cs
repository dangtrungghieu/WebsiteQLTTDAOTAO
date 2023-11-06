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
        [HttpGet]
        public ActionResult Index(int? page, string strSearch)
        {
            CapNhatTinhTrangPhongHoc();
            var kq = db.PHONGHOC.Select(n => n);
            int iSize = 15;
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
        private void CapNhatTinhTrangPhongHoc()
        {
            var phongHocCanCapNhat = db.PHONGHOC.ToList(); // Lấy danh sách tất cả các phòng học

            foreach (var phongHoc in phongHocCanCapNhat)
            {
                // Lấy số lớp học trong phòng học cho các ca 1, 2 và 4
                var soCaHoc = db.LOP.Count(lh => lh.MaPhongHoc_Lop == phongHoc.MaPhongHoc && (lh.MaCaHoc_Lop == 1 || lh.MaCaHoc_Lop == 2 || lh.MaCaHoc_Lop == 4));

                if (soCaHoc < 3)
                {
                    // Kiểm tra tình trạng ban đầu trước khi cập nhật
                    if (phongHoc.TinhTrang != "Đang Sửa")
                    {
                        phongHoc.TinhTrang = "Còn Trống";
                    }
                }
                else
                {
                    // Kiểm tra tình trạng ban đầu trước khi cập nhật
                    if (phongHoc.TinhTrang != "Đang Sửa")
                    {
                        phongHoc.TinhTrang = "Đủ";
                    }
                }
            }
            db.SaveChanges();
        }

    }
}