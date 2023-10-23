namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITHONGBAO")]
    public partial class LOAITHONGBAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITHONGBAO()
        {
            THONGBAO = new HashSet<THONGBAO>();
        }

        [Key]
        public int MaLoaiThongBao { get; set; }

        [StringLength(20)]
        public string TenLoaiThongBao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGBAO> THONGBAO { get; set; }
    }
}
