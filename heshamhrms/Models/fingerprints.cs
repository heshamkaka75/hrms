//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace heshamhrms.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fingerprints
    {
        public fingerprints()
        {
            this.Employees = new HashSet<Employees>();
            this.national_services = new HashSet<national_services>();
        }
    
        public int fingerprint_id { get; set; }
        public Nullable<int> Employee_id { get; set; }
        public string national_ser_id { get; set; }
    
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<national_services> national_services { get; set; }
    }
}