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
    
    public partial class vLoanRequestApplication
    {
        public int PK_LoanRequestID { get; set; }
        public string LoanRequestNo { get; set; }
        public Nullable<int> FK_EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> RequestedLoanAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> ApprovalStatus { get; set; }
        public string StatusDescription { get; set; }
        public Nullable<int> RequestTo { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public string ApproverName { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public Nullable<decimal> ApprovedAmount { get; set; }
        public string RemarksApproved { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> Fk_YearID { get; set; }
        public Nullable<int> FK_CompanyID { get; set; }
        public Nullable<int> Fk_BranchID { get; set; }
        public Nullable<System.DateTime> LoanRequestDate { get; set; }
    }
}
