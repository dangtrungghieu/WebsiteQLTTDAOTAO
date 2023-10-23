namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHAMCONG")]
    public partial class CHAMCONG
    {
        [Key]
        public int MaChamCong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayChamCong { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? MaNhanVien_ChamCong { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
