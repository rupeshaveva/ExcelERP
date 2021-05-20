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
    
    public partial class TBL_MP_CRM_SalesEnquiry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_CRM_SalesEnquiry()
        {
            this.TBL_MP_CRM_SalesEnquiry_Associates = new HashSet<TBL_MP_CRM_SalesEnquiry_Associates>();
            this.TBL_MP_CRM_SalesEnquiry_Attachments = new HashSet<TBL_MP_CRM_SalesEnquiry_Attachments>();
            this.TBL_MP_CRM_SalesQuotation = new HashSet<TBL_MP_CRM_SalesQuotation>();
        }
    
        public int PK_SalesEnquiryID { get; set; }
        public string SalesEnquiry_No { get; set; }
        public System.DateTime SalesEnquiry_Date { get; set; }
        public int FK_SalesLeadID { get; set; }
        public string Project_Name { get; set; }
        public int FK_Userlist_Enquiry_Status_ID { get; set; }
        public string Enquiry_Genrated_By { get; set; }
        public string Enquiry_Genrated_By_Name { get; set; }
        public Nullable<int> FK_EnqGenerated_Agent_ID { get; set; }
        public Nullable<int> FK_EnqGenerated_Employee_ID { get; set; }
        public int FK_AssignedTo { get; set; }
        public Nullable<int> FK_Userlist_ProjectType_ID { get; set; }
        public string General_Description { get; set; }
        public int FK_Userlist_EnquiryType_ID { get; set; }
        public Nullable<System.DateTime> Enquiry_Due_Date { get; set; }
        public int FK_Userlist_Submission_Mode_ID { get; set; }
        public int FK_Userlist_EnquirySource_ID { get; set; }
        public Nullable<int> FK_Userlist_ProjectStatus_ID { get; set; }
        public Nullable<decimal> Project_Value { get; set; }
        public Nullable<int> FK_Userlist_Contract_ID { get; set; }
        public Nullable<int> FK_Project_Country_ID { get; set; }
        public Nullable<int> FK_Project_State_ID { get; set; }
        public Nullable<int> FK_Project_City_ID { get; set; }
        public Nullable<int> Duration_of_Project { get; set; }
        public Nullable<System.DateTime> Tentative_Start_Date { get; set; }
        public Nullable<System.DateTime> Tentative_End_Date { get; set; }
        public Nullable<int> Pending_Months { get; set; }
        public Nullable<int> Is_Accomodation_Provided { get; set; }
        public int FK_Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public Nullable<int> FK_Customer_City_ID { get; set; }
        public Nullable<System.DateTime> Customer_Submission_Date { get; set; }
        public Nullable<System.DateTime> EstimationTeam_Submission_Date { get; set; }
        public Nullable<System.DateTime> DesignTeam_Submission_Date { get; set; }
        public Nullable<System.DateTime> Extension_Date { get; set; }
        public Nullable<System.DateTime> New_Submission_Date { get; set; }
        public Nullable<int> FK_Userlist_SubmitTo_ID { get; set; }
        public string Submission_Remarks_EXT_Approval_Name { get; set; }
        public string Submission_Remarks_MKT_Approval_Name { get; set; }
        public string BOQ_Remarks { get; set; }
        public Nullable<int> FK_Userlist_Project_SubType_ID { get; set; }
        public Nullable<int> FK_Userlist_SystemType_ID { get; set; }
        public string Sector { get; set; }
        public Nullable<int> FK_Userlist_HazardCategory_ID { get; set; }
        public Nullable<int> FK_Parent_Sales_Enquiry_ID { get; set; }
        public Nullable<bool> Is_Quotation_Done { get; set; }
        public Nullable<int> FK_PreparedBy { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public Nullable<int> FK_CheckedBy { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDatetime { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public int FK_CompanyID { get; set; }
        public Nullable<decimal> From_Project_Value { get; set; }
        public Nullable<decimal> To_Project_Value { get; set; }
        public string ReasonClose { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesEnquiry_Associates> TBL_MP_CRM_SalesEnquiry_Associates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesEnquiry_Attachments> TBL_MP_CRM_SalesEnquiry_Attachments { get; set; }
        public virtual TBL_MP_CRM_SM_SalesLead TBL_MP_CRM_SM_SalesLead { get; set; }
        public virtual TBL_MP_Master_City TBL_MP_Master_City { get; set; }
        public virtual TBL_MP_Master_Country TBL_MP_Master_Country { get; set; }
        public virtual Tbl_MP_Master_Party Tbl_MP_Master_Party { get; set; }
        public virtual TBL_MP_Master_State TBL_MP_Master_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesQuotation> TBL_MP_CRM_SalesQuotation { get; set; }
    }
}
