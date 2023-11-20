using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class ChiTietGiaoVien
    {
        public List<LOP> LopCuaGiaoVien { get; set; }
        public List<NHANVIEN> ThongTinGiaoVien { get; set; }
    }
}