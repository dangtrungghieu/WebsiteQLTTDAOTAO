namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            CHAMCONG = new HashSet<CHAMCONG>();
            KHAOSAT = new HashSet<KHAOSAT>();
            LOP = new HashSet<LOP>();
            LUONG = new HashSet<LUONG>();
            NHAPHANG = new HashSet<NHAPHANG>();
            PHONGTHI = new HashSet<PHONGTHI>();
            THONGBAO = new HashSet<THONGBAO>();
            YEUCAUNHANVIEN = new HashSet<YEUCAUNHANVIEN>();
        }

        [Key]
        public int MaNhanVien { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [Required]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [StringLength(50)]
        public string HocVi { get; set; }

        [StringLength(50)]
        public string ChuyenNganh { get; set; }

        [StringLength(50)]
        public string DonViCapBang { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int? MaTaiKhoan_NhanVien { get; set; }

        public int? MaLoai_NhanVien { get; set; }

        [StringLength(50)]
        public string AnhDaiDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAMCONG> CHAMCONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHAOSAT> KHAOSAT { get; set; }

        public virtual LOAINHANVIEN LOAINHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUONG> LUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAPHANG> NHAPHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGTHI> PHONGTHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGBAO> THONGBAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEUCAUNHANVIEN> YEUCAUNHANVIEN { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
