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
    
    public partial class CHAMCONG
    {
        public int MaChamCong { get; set; }
        public System.DateTime NgayChamCong { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<int> MaNhanVien_ChamCong { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
