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
    
    public partial class TBL_MP_CRM_SalesOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_CRM_SalesOrder()
        {
            this.TBL_MP_CRM_SalesOrder_Associates = new HashSet<TBL_MP_CRM_SalesOrder_Associates>();
            this.TBL_MP_CRM_SalesOrder_Attachment = new HashSet<TBL_MP_CRM_SalesOrder_Attachment>();
            this.TBL_MP_CRM_SalesOrder_TermsAndConditions = new HashSet<TBL_MP_CRM_SalesOrder_TermsAndConditions>();
        }
    
        public int PK_SalesOrderID { get; set; }
        public string SalesOrderNo { get; set; }
        public System.DateTime SalesOrderDate { get; set; }
        public int FK_POSource { get; set; }
        public int FK_SalesOrderStatus { get; set; }
        public int FK_SalesOrderType { get; set; }
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
        public Nullable<decimal> OrderFinalAmount { get; set; }
        public string MaterialSupplyPONo { get; set; }
        public Nullable<System.DateTime> MaterialSupplyPODate { get; set; }
        public Nullable<int> MaterialSupplyPOValidDays { get; set; }
        public Nullable<System.DateTime> MaterialSupplyPOExpiryDate { get; set; }
        public string InstallationServicePONo { get; set; }
        public Nullable<System.DateTime> InstallationServicePODate { get; set; }
        public Nullable<int> InstallationServicePOValidDays { get; set; }
        public Nullable<System.DateTime> InstallationServicePOExpiryDate { get; set; }
        public Nullable<int> FK_QuotationID { get; set; }
        public int FK_ClientID { get; set; }
        public Nullable<int> FK_ProjectID { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
        public int FK_CompanyID { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> FK_BOQRepresentativeID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesOrder_Associates> TBL_MP_CRM_SalesOrder_Associates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesOrder_Attachment> TBL_MP_CRM_SalesOrder_Attachment { get; set; }
        public virtual TBL_MP_CRM_SalesQuotation TBL_MP_CRM_SalesQuotation { get; set; }
        public virtual Tbl_MP_Master_Party Tbl_MP_Master_Party { get; set; }
        public virtual TBL_MP_PMC_ProjectMaster TBL_MP_PMC_ProjectMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesOrder_TermsAndConditions> TBL_MP_CRM_SalesOrder_TermsAndConditions { get; set; }
    }
}
