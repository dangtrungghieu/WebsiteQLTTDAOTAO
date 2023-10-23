namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LUONG")]
    public partial class LUONG
    {
        [Key]
        public int MaLuong { get; set; }

        public int SoNgayCong { get; set; }

        public int TienBaoHiem { get; set; }

        public int TienThuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public int MaNhanVien_Luong { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
