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
    
    public partial class Certificates
    {
        public int Certificate_id { get; set; }

        public Nullable<int> Certificate_employee_id { get; set; }
        [Display(Name = "��� �������")]

        public string Certificate_name { get; set; }
        [Display(Name = "���� ������")]

        public Nullable<int> edit_by { get; set; }
        [Display(Name = "����� �������")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_time { get; set; }
        [Display(Name = "��� �������")]
        public string Certificate_type { get; set; }
        [Display(Name = "��� �������")]
        public string Certificate_source { get; set; }
        [Display(Name = "�����")]
        public Nullable<int> Certificate_duration { get; set; }
        [Display(Name = "��")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Certificate_from { get; set; }
        [Display(Name = "���")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Certificate_to { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Employees Employees { get; set; }
    }
}