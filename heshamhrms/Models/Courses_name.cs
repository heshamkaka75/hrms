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
    
    public partial class Courses_name
    {
        public Courses_name()
        {
            this.Courses = new HashSet<Courses>();
        }
    
        public int Course_name_id { get; set; }
	[Display(Name = "��� ������")]
        public string Course_name { get; set; }
    
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
