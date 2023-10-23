namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANGKY")]
    public partial class DANGKY
    {
        [Key]
        public int MaDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDangKy { get; set; }

        public int LePhi { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? MaLopHoc_DangKy { get; set; }

        public int? MaHocVien_DangKy { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
