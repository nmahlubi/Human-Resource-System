//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTeam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payroll
    {
        public int PayrollId { get; set; }
        public double salary { get; set; }
        public System.DateTime hours_worked { get; set; }
        public int tax_no { get; set; }
        public int uif { get; set; }
        public double pension_fund { get; set; }
        public System.DateTime overtime { get; set; }
        public System.DateTime public_holidays { get; set; }
        public double bonus { get; set; }
        public string allowance { get; set; }
        public string benefits { get; set; }
        public System.DateTime datecreated { get; set; }
    
        public virtual Salary Salary1 { get; set; }
    }
}