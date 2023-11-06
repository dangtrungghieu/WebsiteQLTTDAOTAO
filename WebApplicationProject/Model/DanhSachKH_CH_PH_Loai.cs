using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class DanhSachKH_CH_PH_Loai
    {
        public List<KHOAHOC> KhoahocList { get; set; }
        public List<LOAI> LoaiList { get; set; }
        public List<CAHOC> CahocList { get; set; }
        public List<NHANVIEN> GiangvienList { get; set; }
        public List<PHONGHOC> PhongHocList { get; set; }
        //public int MaKhoaHoc { get; set; }
        //public string TenKhoaHoc { get; set; }
        //public int MaCaHoc { get; set; }
        //public string TenCaHoc { get; set; }
        //public int MaGiaoVien { get; set; }
        //public string TenGiaoVien { get; set; }
        //public int MaLoai { get; set; }
        //public string TenLoai { get; set; }
        //public int MaPhongHoc { get; set; }
        //public string TenPhongHoc { get; set; }
    }
}