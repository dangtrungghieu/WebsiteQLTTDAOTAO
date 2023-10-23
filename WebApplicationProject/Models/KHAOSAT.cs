namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHAOSAT")]
    public partial class KHAOSAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHAOSAT()
        {
            KETQUAKHAOSAT = new HashSet<KETQUAKHAOSAT>();
        }

        [Key]
        public int MaKhaoSat { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKhaoSat { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTaoKhaoSat { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThucKhaoSat { get; set; }

        public int? MaNhanVien_KhaoSat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUAKHAOSAT> KETQUAKHAOSAT { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
