namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonXinNghi")]
    public partial class DonXinNghi
    {
        [Key]
        public int MaDonXinNghi { get; set; }

        [Required]
        [StringLength(200)]
        public string LyDo { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXinNghi { get; set; }

        [Required]
        [StringLength(50)]
        public string MinhChung { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? MaHocVien_DonXinNghi { get; set; }

        public int? MaLop_DonXinNghi { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
