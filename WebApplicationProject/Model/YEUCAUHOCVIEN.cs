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
    
    public partial class YEUCAUHOCVIEN
    {
        public int MaYeuCau { get; set; }
        public string TenYeuCau { get; set; }
        public string NoiDungYeuCau { get; set; }
        public System.DateTime NgayYeuCau { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<int> MaHocVien_YeuCau { get; set; }
    
        public virtual HOCVIEN HOCVIEN { get; set; }
    }
}
