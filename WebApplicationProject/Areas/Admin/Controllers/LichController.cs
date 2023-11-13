using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject.Model;
namespace WebApplicationProject.Areas.Admin.Controllers
{
    public class LichController : Controller
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        // GET: Admin/Lich
        [HttpGet]
        public ActionResult Index()
        {
            //Hiển thị Calendar
            CalendarViewModel model = new CalendarViewModel();
            // Tính toán StartDate và DisplayDates
            DateTime today = DateTime.Now;
            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(6);

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

            return db.LOP
                .Where(c => c.NgayKhaiGiang <= date && c.NgayKetThuc >= date && (c.CAHOC.NgayHocTrongTuan.Contains(((int)date.DayOfWeek + 1).ToString())))
                .Select(c => new ClassInfo
                {
                    ClassName = c.TenLop,
                    ClassTenCaHoc = c.CAHOC.TenCaHoc,
                    ClassGiaoVien = c.NHANVIEN.TenNhanVien
                })
                .ToList();
        }

        [HttpGet]

        public ActionResult TinhTrangDangKyKhoaHoc()
        {
            var dk = db.LOP.ToList();
            var tt = new List<TinhTrangDangKy>();
            foreach(var item in dk)
            {
                int tongdk = db.DANGKY.Count(n => n.MaLopHoc_DangKy == item.MaLop);
                tt.Add(new TinhTrangDangKy
                {
                    maLop = item.MaLop,
                    tenLop = item.TenLop,
                    tenGiaoVien = item.NHANVIEN.TenNhanVien,
                    tenKhoaHoc = item.KHOAHOC.TenKhoaHoc,
                    tongSoDangKyHienTai = tongdk,
                    siSo = item.PHONGHOC.SucChua

                });
            }
            return View(tt);
        }
    }
}