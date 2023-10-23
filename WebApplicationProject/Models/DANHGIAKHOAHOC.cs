namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIAKHOAHOC")]
    public partial class DANHGIAKHOAHOC
    {
        [Key]
        public int MaDanhGiaKhoaHoc { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDanhGia { get; set; }

        public int? MaHocVien_DanhGiaKhoaHoc { get; set; }

        public int? MaKhoaHoc_DanhGiaKhoaHoc { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }
    }
}
