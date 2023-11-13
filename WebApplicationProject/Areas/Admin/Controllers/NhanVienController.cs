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
            var kq = from nv in db.NHANVIEN where nv.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên" select nv;
            int iSize = 12;
            int iPageNum = (page ?? 1);
            if (!String.IsNullOrEmpty(strSearch))
            {
                kq = kq.Where(b => b.TenNhanVien.Contains(strSearch));
            }
            return View(kq.OrderBy(s => s.LOAINHANVIEN.MaLoaiNhanVien).ToPagedList(iPageNum, iSize));
        }
        [HttpGet]
        public ActionResult Create()
        {

            // Tạo một đối tượng mới của mô hình DanhSachKH_CH_PH_Loai
            DanhSachKH_CH_PH_Loai model = new DanhSachKH_CH_PH_Loai();

            // Lấy dữ liệu cho các danh sách (nếu cần)
            model.KhoahocList = db.KHOAHOC.ToList(); // Ví dụ, thay "KHOAHOC" bằng tên thực thể của bạn
            model.LoaiList = db.LOAI.ToList(); // Thay "LOAI" bằng tên thực thể của bạn
            model.CahocList = db.CAHOC.ToList(); // Thay "CAHOC" bằng tên thực thể của bạn
            model.GiangvienList = db.NHANVIEN.Where(nv => nv.LOAINHANVIEN.TenLoaiNhanVien == "Giáo viên").ToList();
            model.PhongHocList = db.PHONGHOC.ToList(); // Thay "PHONGHOC" bằng tên thực thể của bạn

            // Truyền model vào view để hiển thị form với dữ liệu khởi tạo
            return View(model);
        }
    }
}