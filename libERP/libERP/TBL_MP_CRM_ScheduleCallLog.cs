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
    
    public partial class TBL_MP_CRM_ScheduleCallLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_CRM_ScheduleCallLog()
        {
            this.TBL_MP_CRM_ScheduleCallLogAssignee = new HashSet<TBL_MP_CRM_ScheduleCallLogAssignee>();
            this.TBL_MP_CRM_ScheduleCallLogFollowUp = new HashSet<TBL_MP_CRM_ScheduleCallLogFollowUp>();
        }
    
        public int ScheduleID { get; set; }
        public Nullable<int> EntityType { get; set; }
        public Nullable<int> EntityID { get; set; }
        public Nullable<int> ActionID { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Subject { get; set; }
        public Nullable<System.DateTime> StartAt { get; set; }
        public Nullable<System.DateTime> EndsAt { get; set; }
        public Nullable<System.DateTime> Reminder { get; set; }
        public string CustomerName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        public Nullable<int> ScheduleStatus { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDatetime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> Completed { get; set; }
        public Nullable<System.DateTime> ModifiedDatetime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        public string DeleteRemarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_ScheduleCallLogAssignee> TBL_MP_CRM_ScheduleCallLogAssignee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_ScheduleCallLogFollowUp> TBL_MP_CRM_ScheduleCallLogFollowUp { get; set; }
    }
}
