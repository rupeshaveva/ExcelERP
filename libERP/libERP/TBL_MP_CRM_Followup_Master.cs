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
    
    public partial class TBL_MP_CRM_Followup_Master
    {
        public int PK_FollowupID { get; set; }
        public Nullable<int> FK_Action { get; set; }
        public Nullable<int> FK_Status { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string ReffType { get; set; }
        public Nullable<int> FK_ReffTypePK_ID { get; set; }
        public string RefNo { get; set; }
        public string FollowupStartDate { get; set; }
        public string FollowupStartTime { get; set; }
        public string FollowupEndDate { get; set; }
        public string FollowupEndTime { get; set; }
        public string CustomerName { get; set; }
        public string ContactPersone { get; set; }
        public string ContactNo { get; set; }
        public string Location { get; set; }
        public string ActionPlanResult { get; set; }
        public Nullable<bool> ISNextFollowupRequired { get; set; }
        public Nullable<int> FK_Reminder { get; set; }
        public string NEXT_FollowupStartDate { get; set; }
        public string NEXT_FollowupStartTime { get; set; }
        public string NEXT_FollowupEndDate { get; set; }
        public string NEXT_FollowupEndTime { get; set; }
        public string NEXT_ActionPlanResult { get; set; }
        public Nullable<int> FK_BranchID { get; set; }
        public Nullable<int> FK_EmployeeID { get; set; }
        public Nullable<int> FK_LastModifiedBy { get; set; }
        public Nullable<System.DateTime> FK_LastModifiedDate { get; set; }
        public string Url { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> FK_PrevFollowupID { get; set; }
        public Nullable<int> FK_ThreadID { get; set; }
        public Nullable<bool> IsNextFollowupDone { get; set; }
        public Nullable<bool> IsClosed { get; set; }
        public Nullable<int> FK_ModuleId { get; set; }
        public Nullable<int> FK_ThreadSequence { get; set; }
        public string ThreadNo { get; set; }
        public Nullable<int> FK_CustomerID { get; set; }
        public Nullable<int> FK_ApprovedBYID { get; set; }
        public Nullable<int> FK_CustomerTypeID { get; set; }
        public string Type_of_Organization { get; set; }
        public string Purpose_Of_Visit { get; set; }
        public Nullable<int> Purpose_Of_VisitMet { get; set; }
        public Nullable<int> FK_ClientDesiganation_ID { get; set; }
    }
}
