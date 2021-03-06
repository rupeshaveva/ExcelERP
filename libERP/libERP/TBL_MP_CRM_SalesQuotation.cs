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
    
    public partial class TBL_MP_CRM_SalesQuotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_CRM_SalesQuotation()
        {
            this.TBL_MP_CRM_SalesOrder = new HashSet<TBL_MP_CRM_SalesOrder>();
            this.TBL_MP_CRM_SalesQuotation_Associates = new HashSet<TBL_MP_CRM_SalesQuotation_Associates>();
            this.TBL_MP_CRM_SalesQuotation_Attachments = new HashSet<TBL_MP_CRM_SalesQuotation_Attachments>();
            this.TBL_MP_CRM_SalesQuotation_ItemCharges = new HashSet<TBL_MP_CRM_SalesQuotation_ItemCharges>();
            this.TBL_MP_CRM_SalesQuotation_Review = new HashSet<TBL_MP_CRM_SalesQuotation_Review>();
        }
    
        public int PK_Quotation_ID { get; set; }
        public string Quotation_No { get; set; }
        public System.DateTime Quotation_Date { get; set; }
        public int FK_Userlist_Quotation_Status_ID { get; set; }
        public int Quotation_ValidDays { get; set; }
        public int FK_RepresentativeID { get; set; }
        public int FK_Userlist_Priority_ID { get; set; }
        public int FK_Userlist_ProjectSector_ID { get; set; }
        public int FK_Sales_Enquiry_ID { get; set; }
        public int FK_Customer_ID { get; set; }
        public int FK_Project_City_ID { get; set; }
        public string ReasonClose { get; set; }
        public string Remarks { get; set; }
        public int FK_PreparedBy { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public Nullable<int> FK_CheckedBy { get; set; }
        public Nullable<int> VoucherStyle { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
        public int FK_CompanyID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public Nullable<int> FK_CurrencyID { get; set; }
        public Nullable<decimal> ConversionRate { get; set; }
        public string SpecialNotes { get; set; }
        public string Project_Name { get; set; }
        public int FK_BOQRepresentativeID { get; set; }
        public Nullable<decimal> MaterialSupplyTotalAmount { get; set; }
        public Nullable<int> MaterialSupplyDiscountType { get; set; }
        public Nullable<decimal> MaterialSupplyDiscountValue { get; set; }
        public Nullable<decimal> MaterialSupplyDiscountamount { get; set; }
        public Nullable<decimal> MaterialSupplySGSTPercent { get; set; }
        public Nullable<decimal> MaterialSupplyCGSTPercent { get; set; }
        public Nullable<decimal> MaterialSupplyIGSTPercent { get; set; }
        public Nullable<decimal> MaterialSupplySGSTAmount { get; set; }
        public Nullable<decimal> MaterialSupplyCGSTAmount { get; set; }
        public Nullable<decimal> MaterialSupplyIGSTAmount { get; set; }
        public Nullable<decimal> MaterialSupplyFinalAmount { get; set; }
        public Nullable<decimal> InstallationTotalAmount { get; set; }
        public Nullable<int> InstallationDiscountType { get; set; }
        public Nullable<decimal> InstallationDiscountValue { get; set; }
        public Nullable<decimal> InstallationDiscountAmount { get; set; }
        public Nullable<decimal> InstallationSGSTPercent { get; set; }
        public Nullable<decimal> InstallationCGSTPercent { get; set; }
        public Nullable<decimal> InstallationIGSTPercent { get; set; }
        public Nullable<decimal> InstallationSGSTAmount { get; set; }
        public Nullable<decimal> InstallationCGSTAmount { get; set; }
        public Nullable<decimal> InstallationIGSTAmount { get; set; }
        public Nullable<decimal> InstallationFinalAmount { get; set; }
        public Nullable<decimal> QuotationFinalAmount { get; set; }
    
        public virtual TBL_MP_CRM_SalesEnquiry TBL_MP_CRM_SalesEnquiry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesOrder> TBL_MP_CRM_SalesOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesQuotation_Associates> TBL_MP_CRM_SalesQuotation_Associates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesQuotation_Attachments> TBL_MP_CRM_SalesQuotation_Attachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesQuotation_ItemCharges> TBL_MP_CRM_SalesQuotation_ItemCharges { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesQuotation_Review> TBL_MP_CRM_SalesQuotation_Review { get; set; }
        public virtual Tbl_MP_Master_Party Tbl_MP_Master_Party { get; set; }
    }
}
