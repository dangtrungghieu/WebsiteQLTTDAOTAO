namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAHOC")]
    public partial class CAHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAHOC()
        {
            LOP = new HashSet<LOP>();
        }

        [Key]
        public int MaCaHoc { get; set; }

        [Required]
        [StringLength(20)]
        public string TenCaHoc { get; set; }

        public TimeSpan ThoiGianBatDau { get; set; }

        public TimeSpan ThoiGianKetThuc { get; set; }

        [Required]
        [StringLength(50)]
        public string NgayHocTrongTuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOP { get; set; }
    }
}
