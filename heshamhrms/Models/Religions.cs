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
    
    public partial class Religions
    {
        public Religions()
        {
            this.Employees = new HashSet<Employees>();
            this.national_services = new HashSet<national_services>();
            this.trainings = new HashSet<trainings>();
        }
    
        public int Religion_id { get; set; }
         [Display(Name = "��� �������")]
        public string Religion_name { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<national_services> national_services { get; set; }
        public virtual ICollection<trainings> trainings { get; set; }
    }
}
