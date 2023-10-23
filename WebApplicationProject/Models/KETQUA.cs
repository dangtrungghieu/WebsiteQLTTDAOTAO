namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUA")]
    public partial class KETQUA
    {
        [Key]
        public int MaKetQua { get; set; }

        public double DiemSo { get; set; }

        [Required]
        [StringLength(20)]
        public string XepLoai { get; set; }

        public int? MaHocVien_KetQua { get; set; }

        public int? MaKhoaHoc_KetQua { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }
    }
}
