//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppEmployee.Extensions.Test.Quanlythuhocphi.Quanlythuhocphi.Quanlythuhocphi.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class MIENGIAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MIENGIAM()
        {
            this.SINHVIENs = new HashSet<SINHVIEN>();
        }
    
        public int MaMienGiam { get; set; }
        public string TenMienGiam { get; set; }
        public Nullable<int> PhanTram { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SINHVIEN> SINHVIENs { get; set; }
    }
}
