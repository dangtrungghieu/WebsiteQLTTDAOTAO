namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUAKHAOSAT")]
    public partial class KETQUAKHAOSAT
    {
        [Key]
        public int MaKetQuaKhaoSat { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLamKhaoSat { get; set; }

        public int? MaHocVien_KetQuaKhaoSat { get; set; }

        public int? MaKhaoSat_KetQuaKhaoSat { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual KHAOSAT KHAOSAT { get; set; }
    }
}
