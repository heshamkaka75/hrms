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
    
    public partial class Vacation_Balances
    {
    public int Vacation_Balances_id { get; set; }
        public Nullable<int> Vb_vt_id { get; set; }
        public Nullable<int> vb_emp_id { get; set; }
         [Display(Name = "��� ������")]
        public Nullable<int> vb_total { get; set; }
         [Display(Name = "���� ������")]
        public Nullable<int> edit_by { get; set; }
         [Display(Name = "����� �������")]
         [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_time { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Vacations_type Vacations_type { get; set; }
    }
}
