namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGTHI")]
    public partial class PHONGTHI
    {
        [Key]
        public int MaPhongThi { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayThi { get; set; }

        public int? MaNhanVien_PhongThi { get; set; }

        public int? MaPhongHoc_PhongThi { get; set; }

        public int? MaCaThi_PhongThi { get; set; }

        public int? MaKhoaHoc_PhongThi { get; set; }

        public virtual CATHI CATHI { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONGHOC PHONGHOC { get; set; }
    }
}
