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
    
    public partial class LeaveManagement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LeaveManagement()
        {
            this.Users = new HashSet<User>();
        }
    
        public int leaveManagementId { get; set; }
        public System.DateTime annual_leave { get; set; }
        public System.DateTime sick_leave { get; set; }
        public System.DateTime maternity_leave { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public System.DateTime total_day { get; set; }
        public string comment { get; set; }
        public string accept { get; set; }
        public string decline { get; set; }
        public System.DateTime datecreated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
