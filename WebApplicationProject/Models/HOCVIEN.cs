namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCVIEN")]
    public partial class HOCVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCVIEN()
        {
            DANGKY = new HashSet<DANGKY>();
            DANHGIAKHOAHOC = new HashSet<DANHGIAKHOAHOC>();
            DonXinNghi = new HashSet<DonXinNghi>();
            KETQUA = new HashSet<KETQUA>();
            KETQUAKHAOSAT = new HashSet<KETQUAKHAOSAT>();
            PHIEUTHU = new HashSet<PHIEUTHU>();
            YEUCAUHOCVIEN = new HashSet<YEUCAUHOCVIEN>();
        }

        [Key]
        public int MaHocVien { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHocVien { get; set; }

        [Required]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int? MaTaiKhoan_HocVien { get; set; }

        public int? MaLop_HocVien { get; set; }

        [StringLength(50)]
        public string AnhDaiDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKY> DANGKY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIAKHOAHOC> DANHGIAKHOAHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonXinNghi> DonXinNghi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUAKHAOSAT> KETQUAKHAOSAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHU> PHIEUTHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEUCAUHOCVIEN> YEUCAUHOCVIEN { get; set; }
    }
}
