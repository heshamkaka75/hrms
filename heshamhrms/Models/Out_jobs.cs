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
    
    public partial class Out_jobs
    {
        public int Out_job_id { get; set; }
        public Nullable<int> Out_job_employee_id { get; set; }
        public Nullable<int> Out_job_location_id { get; set; }
        [Display(Name = "����� ���������")]
        [DataType(DataType.Date)]

        public Nullable<System.DateTime> Out_job_date { get; set; }
        [Display(Name = "����� �� ���������")]
        

        public string Out_job_reason { get; set; }
        [Display(Name = "��� ���������")]
        

        public Nullable<int> Out_job_duration { get; set; }
        public Nullable<int> Edit_by { get; set; }
        [Display(Name = "����� �������")]
        [DataType(DataType.Date)]

        public Nullable<System.DateTime> Date_time { get; set; }
    
        public virtual Departments Departments { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Users Users { get; set; }
    }
}
