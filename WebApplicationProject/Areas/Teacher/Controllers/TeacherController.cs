using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.Teacher.Controllers
{
    public class TeacherController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Teacher/Teacher
        [HttpGet]
        public ActionResult tcProfile()
        {
            var nhanvien = db.NHANVIEN.FirstOrDefault(nv => nv.MaNhanVien == 1);
            return View(nhanvien);
        }
        [HttpPost]
        public ActionResult usProfile(FormCollection f)
        {
            var nhanvien = db.NHANVIEN.FirstOrDefault(nv => nv.MaNhanVien == 1);

            if (ModelState.IsValid)
            {
                nhanvien.TenNhanVien = f["sTenNhanVien"];
                nhanvien.DiaChi = f["sDiaChi"];
                nhanvien.Email = f["sEmail"];
                //hocvien.SoDienThoai = int.Parse(f["sSoDienThoai"]);

                db.SaveChanges();

                return RedirectToAction("Profile");
            }

            return View(nhanvien);
        }
        public ActionResult NavTeacher()
        {
            var nhanvien = db.NHANVIEN.FirstOrDefault(nv => nv.MaNhanVien == 1);
            return PartialView(nhanvien);

        }
        public ActionResult NavTeacher()
        {
            var nhanvien = db.NHANVIEN.FirstOrDefault(nv => nv.MaNhanVien == 1);
            return PartialView(nhanvien);

        }
    }
}