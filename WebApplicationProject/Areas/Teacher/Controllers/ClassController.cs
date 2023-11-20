using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.Teacher.Controllers   
{
    public class ClassController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Teacher/Class
        public ActionResult tcClass()
        {
            var nhanvien = from nv in db.LOP.Where(n => n.MaGiangVien_Lop == 1) select nv;
            return View(nhanvien);
        }
        public ActionResult DetailsClass(int? id)
        {
            var Lop = db.LOP.Find(id);
            return View(Lop);
        }
        public ActionResult DetailsStudent(int? id)
        {
            var hocvien = db.HOCVIEN.Find(id);
            return View(hocvien);
        }
        public ActionResult tcNotification()
        {
            var thongBaoList = db.THONGBAO.ToList();

            var thongBaoViewModelList = thongBaoList.Select(tb => new ThongBaoViewModel
            {
                MaThongBao = tb.MaThongBao,
                NoiDung = tb.NoiDung,
                NguoiNhan = tb.NguoiNhan,
                NgayGui = tb.NgayGui,
                MaNhanVien_ThongBao = tb.MaNhanVien_ThongBao ?? 1,
                MaLoaiThongBao_ThongBao = tb.MaLoaiThongBao_ThongBao ?? 1
            }).ToList();

            return View(thongBaoViewModelList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ThongBaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newThongBao = new THONGBAO
                {
                    NoiDung = model.NoiDung,
                    NguoiNhan = model.NguoiNhan,
                    NgayGui = DateTime.Now,
                    MaNhanVien_ThongBao = model.MaNhanVien_ThongBao,
                    MaLoaiThongBao_ThongBao = model.MaLoaiThongBao_ThongBao
                };

                db.THONGBAO.Add(newThongBao);
                db.SaveChanges();

                return RedirectToAction("tcNotification");
            }

            return View(model);
        }
    }
}