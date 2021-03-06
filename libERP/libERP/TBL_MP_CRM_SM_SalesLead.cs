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
    
    public partial class TBL_MP_CRM_SM_SalesLead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_CRM_SM_SalesLead()
        {
            this.TBL_MP_CRM_SalesEnquiry = new HashSet<TBL_MP_CRM_SalesEnquiry>();
            this.TBL_MP_CRM_SM_SalesLead_Associates = new HashSet<TBL_MP_CRM_SM_SalesLead_Associates>();
            this.TBL_MP_CRM_SM_SalesLead_Attachment = new HashSet<TBL_MP_CRM_SM_SalesLead_Attachment>();
            this.TBL_MP_CRM_SM_SalesLead_SuspectingInfo = new HashSet<TBL_MP_CRM_SM_SalesLead_SuspectingInfo>();
        }
    
        public int PK_SalesLeadID { get; set; }
        public string LeadNo { get; set; }
        public System.DateTime LeadDate { get; set; }
        public int FK_Status { get; set; }
        public Nullable<int> CType { get; set; }
        public int FK_PartyID { get; set; }
        public string LeadName { get; set; }
        public string ContactPersone { get; set; }
        public string LeadAddress { get; set; }
        public string LeadEmailID { get; set; }
        public string LeadWebsite { get; set; }
        public string LeadPhoneNo { get; set; }
        public string LeadMobileNo { get; set; }
        public string LeadFAXNo { get; set; }
        public string LeadRequirement { get; set; }
        public Nullable<int> FK_LeadSource { get; set; }
        public Nullable<int> FK_AgentID { get; set; }
        public Nullable<decimal> EstimatedValue { get; set; }
        public Nullable<int> FK_EstimatedCurrency { get; set; }
        public Nullable<System.DateTime> NextFollowupDate { get; set; }
        public Nullable<int> FK_LeadGeneratedBy { get; set; }
        public Nullable<int> FK_LeadAssignTo { get; set; }
        public Nullable<int> FK_ProjectType { get; set; }
        public int FK_CompanyID { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
        public int FK_PreparedBy { get; set; }
        public Nullable<int> FK_CheckedBy { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public Nullable<int> FK_LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<bool> IS_EnquiryDone { get; set; }
        public Nullable<int> FK_CountryID { get; set; }
        public Nullable<int> FK_StateID { get; set; }
        public Nullable<int> FK_CityID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> FK_DesignationID { get; set; }
        public Nullable<int> FK_LeadStrength { get; set; }
        public Nullable<int> FK_IndustryType { get; set; }
        public string ContactPerson1 { get; set; }
        public string ContactPerson1MobileNumber { get; set; }
        public string ContactPerson1Email { get; set; }
        public string ContactPerson2 { get; set; }
        public string ContactPerson2MobileNumber { get; set; }
        public string ContactPerson2Email { get; set; }
        public string ContactPerson3 { get; set; }
        public string ContactPerson3MobileNumber { get; set; }
        public string ContactPerson3Email { get; set; }
        public Nullable<int> NumberOfYears { get; set; }
        public Nullable<decimal> TurnOver { get; set; }
        public Nullable<int> TurnOverCurrency { get; set; }
        public Nullable<int> NumberOfEmployees { get; set; }
        public Nullable<int> AuctionCompany { get; set; }
        public Nullable<int> Imports { get; set; }
        public Nullable<int> Exports { get; set; }
        public Nullable<int> JobWork { get; set; }
        public Nullable<int> NumberOfLocations { get; set; }
        public Nullable<int> Firm { get; set; }
        public string MentionName { get; set; }
        public string DecisionMaker { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ReasonClose { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesEnquiry> TBL_MP_CRM_SalesEnquiry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SM_SalesLead_Associates> TBL_MP_CRM_SM_SalesLead_Associates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SM_SalesLead_Attachment> TBL_MP_CRM_SM_SalesLead_Attachment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SM_SalesLead_SuspectingInfo> TBL_MP_CRM_SM_SalesLead_SuspectingInfo { get; set; }
        public virtual Tbl_MP_Master_Party Tbl_MP_Master_Party { get; set; }
    }
}
