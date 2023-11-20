using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class ThongBaoViewModel
    {
        public int MaThongBao { get; set; }
        public string NoiDung { get; set; }
        public string NguoiNhan { get; set; }
        public DateTime NgayGui { get; set; }
        public int MaNhanVien_ThongBao { get; set; }
        public int MaLoaiThongBao_ThongBao { get; set; }
    }
}