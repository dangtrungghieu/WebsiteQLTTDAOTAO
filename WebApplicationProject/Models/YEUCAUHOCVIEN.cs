namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YEUCAUHOCVIEN")]
    public partial class YEUCAUHOCVIEN
    {
        [Key]
        public int MaYeuCau { get; set; }

        [Required]
        [StringLength(50)]
        public string TenYeuCau { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDungYeuCau { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayYeuCau { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? MaHocVien_YeuCau { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }
    }
}
