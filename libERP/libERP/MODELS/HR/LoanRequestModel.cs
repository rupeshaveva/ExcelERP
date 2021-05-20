using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
    public partial class LoanRequestModel
    {
        public int PK_LoanRequestID { get; set; }
        public string LoanRequestNo { get; set; }
        public int FK_EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> RequestedLoanAmount { get; set; }
        public string Remarks { get; set; }
        public int ApprovalStatus { get; set; }
        public string StatusDescription { get; set; }
        public int RequestTo { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public string ApproverName { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public Nullable<decimal> ApprovedAmount { get; set; }
        public string RemarksApproved { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public int Fk_YearID { get; set; }
        public int FK_CompanyID { get; set; }
        public int Fk_BranchID { get; set; }
        public Nullable<System.DateTime> LoanRequestDate { get; set; }



        public string SearchString
        {
            get
            {
                return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                           LoanRequestNo.ToString(), EmployeeName, RequestedLoanAmount, LoanRequestDate.ToString(), ApprovalDate.ToString(),
                                  ApprovalStatus, Remarks, StatusDescription, ApproverName, RemarksApproved);
            }
        }
    }
}
