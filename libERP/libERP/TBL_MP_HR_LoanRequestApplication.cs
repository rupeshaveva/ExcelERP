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
    
    public partial class TBL_MP_HR_LoanRequestApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_HR_LoanRequestApplication()
        {
            this.TBL_MP_HR_LoanDisbursement = new HashSet<TBL_MP_HR_LoanDisbursement>();
        }
    
        public int pk_LoanRequestID { get; set; }
        public string LoanRequestNo { get; set; }
        public System.DateTime LoanRequestDate { get; set; }
        public int FK_EmployeeID { get; set; }
        public Nullable<decimal> RequestedLoanAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> ProposedDisbursementDate { get; set; }
        public Nullable<int> ApprovalStatus { get; set; }
        public Nullable<int> RequestTo { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public Nullable<decimal> ApprovedAmount { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
        public int FK_CompanyID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string RemarksApproved { get; set; }
    
        public virtual TBL_MP_Admin_UserList TBL_MP_Admin_UserList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_HR_LoanDisbursement> TBL_MP_HR_LoanDisbursement { get; set; }
        public virtual TBL_MP_Master_Employee TBL_MP_Master_Employee { get; set; }
    }
}
