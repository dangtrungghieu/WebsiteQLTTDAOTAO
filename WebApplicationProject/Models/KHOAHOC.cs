namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOAHOC")]
    public partial class KHOAHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOAHOC()
        {
            DANHGIAKHOAHOC = new HashSet<DANHGIAKHOAHOC>();
            KETQUA = new HashSet<KETQUA>();
            LOP = new HashSet<LOP>();
            PHIEUTHU = new HashSet<PHIEUTHU>();
            PHONGTHI = new HashSet<PHONGTHI>();
        }

        [Key]
        public int MaKhoaHoc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKhoaHoc { get; set; }

        [Required]
        [StringLength(100)]
        public string MoTa { get; set; }

        public int? LePhi { get; set; }

        [StringLength(50)]
        public string AnhKhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIAKHOAHOC> DANHGIAKHOAHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHU> PHIEUTHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGTHI> PHONGTHI { get; set; }
    }
}
