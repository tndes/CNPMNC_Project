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
    
    public partial class THUONGKILUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUONGKILUAT()
        {
            this.LUONGs = new HashSet<LUONG>();
        }
    
        public int MATKL { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<int> MAHT { get; set; }
        public string LIDO { get; set; }
        public Nullable<decimal> SOTIEN { get; set; }
    
        public virtual HINHTHUC HINHTHUC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUONG> LUONGs { get; set; }
    }
}
