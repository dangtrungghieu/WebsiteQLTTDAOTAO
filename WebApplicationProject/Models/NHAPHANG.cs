namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAPHANG")]
    public partial class NHAPHANG
    {
        [Key]
        public int MaNhapHang { get; set; }

        [Required]
        [StringLength(30)]
        public string LoaiVatTu { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNhap { get; set; }

        public int? MaNhanVien_NhapHang { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
