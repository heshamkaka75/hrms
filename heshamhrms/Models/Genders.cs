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
    
    public partial class Genders
    {
        public Genders()
        {
            this.Employees = new HashSet<Employees>();
        }
    
        public int Gender_id { get; set; }
	[Display(Name = "�����")]
        public string Gender_name { get; set; }
    
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
