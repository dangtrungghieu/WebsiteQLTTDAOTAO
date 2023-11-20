using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class KhoaHoc_LopHoc
    {
        public KHOAHOC KhoaHoc { get; set; }
        public List<LOP> DanhSachLopHoc { get; set; }
    }
}