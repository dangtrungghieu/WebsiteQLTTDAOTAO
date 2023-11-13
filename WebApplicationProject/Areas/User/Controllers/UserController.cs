using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;

namespace WebApplicationProject.Areas.User.Controllers
{
    public class UserController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: User/User
        [HttpGet]
        public ActionResult usProfile()
        {
            var hocvien = db.HOCVIEN.FirstOrDefault(hv => hv.MaHocVien == 4);
            return View(hocvien);
        }

        // Action HTTP POST để xử lý cập nhật thông tin profile
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult usProfile(FormCollection f)
        {
            var hocvien = db.HOCVIEN.FirstOrDefault(hv => hv.MaHocVien == 4);

            if (ModelState.IsValid)
            {
                hocvien.TenHocVien = f["sTenHocVien"];
                hocvien.DiaChi = f["sDiaChi"];
                hocvien.Email = f["sEmail"];
                hocvien.SoDienThoai = int.Parse(f["sSoDienThoai"]);

                db.SaveChanges();

                return RedirectToAction("Profile");
            }

            return View(hocvien);
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View();
        }
        // GET: User/Register
        public ActionResult Register()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult NavUser()
        {
            var hocvien = db.HOCVIEN.FirstOrDefault(hv => hv.MaHocVien == 4);
            return PartialView(hocvien);
        }
        public ActionResult NavHeaderUser()
        {
            return View();
        }
        public ActionResult Schedule()
        {
            //Hiển thị Calendar
            CalendarViewModel model = new CalendarViewModel();
            // Tính toán StartDate và DisplayDates
            DateTime today = DateTime.Now;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(20);

            model.StartDate = startDate;
            model.DisplayDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                .Select(offset => startDate.AddDays(offset))
                .ToList();

            // Thêm thông tin về giờ học
            model.ClassesByDate = new Dictionary<DateTime, List<ClassInfo>>();
            foreach (var date in model.DisplayDates)
            {
                List<ClassInfo> classesForDate = GetClassesForDate(date);
                model.ClassesByDate[date] = classesForDate;
            }

            return View(model);
        }
        private List<ClassInfo> GetClassesForDate(DateTime date)
        {

            return db.DANGKY
                .Where(c => c.LOP.NgayKhaiGiang <= date && c.LOP.NgayKetThuc >= date && (c.LOP.CAHOC.NgayHocTrongTuan.Contains(((int)date.DayOfWeek + 1).ToString())) && c.MaHocVien_DangKy == 6)
                .Select(c => new ClassInfo
                {
                    ClassName = c.LOP.TenLop,
                    ClassTenCaHoc = c.LOP.CAHOC.TenCaHoc,
                    ClassGiaoVien = c.LOP.NHANVIEN.TenNhanVien
                })
                .ToList();
        }

    }
}