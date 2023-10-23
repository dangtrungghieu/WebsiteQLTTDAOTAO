namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YEUCAUNHANVIEN")]
    public partial class YEUCAUNHANVIEN
    {
        [Key]
        public int MaYeuCauNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        public string TenYeuCauNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? MaNhanVien_YeuCauNhanVien { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
