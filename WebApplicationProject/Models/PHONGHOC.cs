namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGHOC")]
    public partial class PHONGHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONGHOC()
        {
            LOP = new HashSet<LOP>();
            PHONGTHI = new HashSet<PHONGTHI>();
        }

        [Key]
        public int MaPhongHoc { get; set; }

        [Required]
        [StringLength(20)]
        public string TenPhongHoc { get; set; }

        public int SucChua { get; set; }

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }

        public int? MaLoaiPhong_PhongHoc { get; set; }

        public virtual LOAI LOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGTHI> PHONGTHI { get; set; }
    }
}
