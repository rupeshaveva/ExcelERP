//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace libERP
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MP_CRM_ScheduleCallLogAssignee
    {
        public int ScheduleCallAssigneeID { get; set; }
        public Nullable<int> ScheduleID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual TBL_MP_CRM_ScheduleCallLog TBL_MP_CRM_ScheduleCallLog { get; set; }
        public virtual TBL_MP_Master_Employee TBL_MP_Master_Employee { get; set; }
    }
}
