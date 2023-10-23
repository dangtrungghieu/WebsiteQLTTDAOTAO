namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATHI")]
    public partial class CATHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATHI()
        {
            PHONGTHI = new HashSet<PHONGTHI>();
        }

        [Key]
        public int MaCaThi { get; set; }

        [Required]
        [StringLength(20)]
        public string TenCaThi { get; set; }

        public TimeSpan GioThi { get; set; }

        public TimeSpan GioTapTrung { get; set; }

        public int? MaLoai_CaThi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGTHI> PHONGTHI { get; set; }

        public virtual LOAICATHI LOAICATHI { get; set; }
    }
}
