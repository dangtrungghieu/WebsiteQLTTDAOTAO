namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHU")]
    public partial class PHIEUTHU
    {
        [Key]
        public int MaPhieuThu { get; set; }

        public int SoTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayThu { get; set; }

        public int? MaHocVien_PhieuThu { get; set; }

        public int? MaKhoaHoc_PhieuThu { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }
    }
}
