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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Jobs
    {
        public Jobs()
        {
            this.Employees = new HashSet<Employees>();
        }
    
        public int job_id { get; set; }
         [Display(Name = "اسم الوظيفة")]
        public string job_title { get; set; }
         [Display(Name = "وصف الوظيفة")]
        public string Job_details { get; set; }
    
        public virtual ICollection<Employees> Employees { get; set; }
    }
}