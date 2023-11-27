using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class DanhSachDangky
    {
        FINALPROJECTEntities db = new FINALPROJECTEntities();
        public int iMakhoaHoc { get; set; }
        public string sTenKhoaHoc { get; set; }
        public string sAnhKhoaHoc { get; set; }
        public string sMota { get; set; }
        public int iSoLuong { get; set; }
        public Nullable<int> iLePhi { get; set; }
        public Nullable<double> dThanhTien
        {
            get { return /*iSoLuong **/ iLePhi; }
        }

        public DanhSachDangky(int mkh)
        {
            iMakhoaHoc = mkh;
            KHOAHOC s = db.KHOAHOC.Single(n => n.MaKhoaHoc == iMakhoaHoc);
            sTenKhoaHoc = s.TenKhoaHoc;
            sAnhKhoaHoc= s.AnhKhoaHoc;
            sMota = s.MoTa;
            iLePhi = s.LePhi;
            iSoLuong = 1;
        }
    }
}