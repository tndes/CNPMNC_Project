//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPMNC_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAIKHOAN
    {
        public int MATK { get; set; }
        public string USERNAME { get; set; }
        public string MATKHAU { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<int> MAPQ { get; set; }
    
        public virtual PHANQUYEN PHANQUYEN { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
