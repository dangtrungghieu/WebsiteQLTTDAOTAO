namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGBAO")]
    public partial class THONGBAO
    {
        [Key]
        public int MaThongBao { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(20)]
        public string NguoiNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGui { get; set; }

        public int? MaNhanVien_ThongBao { get; set; }

        public int? MaLoaiThongBao_ThongBao { get; set; }

        public virtual LOAITHONGBAO LOAITHONGBAO { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
