namespace WebApplicationProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            DANGKY = new HashSet<DANGKY>();
            DonXinNghi = new HashSet<DonXinNghi>();
        }

        [Key]
        public int MaLop { get; set; }

        [Required]
        [StringLength(30)]
        public string TenLop { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKhaiGiang { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        public int? MaKhoaHoc_Lop { get; set; }

        public int? MaPhongHoc_Lop { get; set; }

        public int? MaCaHoc_Lop { get; set; }

        public int? MaGiangVien_Lop { get; set; }

        public int? MaLoaiLop_Lop { get; set; }

        public virtual CAHOC CAHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKY> DANGKY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonXinNghi> DonXinNghi { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }

        public virtual LOAI LOAI { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONGHOC PHONGHOC { get; set; }
    }
}
