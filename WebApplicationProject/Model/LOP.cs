//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            this.DANGKY = new HashSet<DANGKY>();
            this.DonXinNghi = new HashSet<DonXinNghi>();
            this.HOCVIEN = new HashSet<HOCVIEN>();
        }
    
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public System.DateTime NgayKhaiGiang { get; set; }
        public System.DateTime NgayKetThuc { get; set; }
        public Nullable<int> MaKhoaHoc_Lop { get; set; }
        public Nullable<int> MaPhongHoc_Lop { get; set; }
        public Nullable<int> MaCaHoc_Lop { get; set; }
        public Nullable<int> MaGiangVien_Lop { get; set; }
        public Nullable<int> MaLoaiLop_Lop { get; set; }
    
        public virtual CAHOC CAHOC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANGKY> DANGKY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonXinNghi> DonXinNghi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCVIEN> HOCVIEN { get; set; }
        public virtual KHOAHOC KHOAHOC { get; set; }
        public virtual LOAI LOAI { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual PHONGHOC PHONGHOC { get; set; }
    }
}