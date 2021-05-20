using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
    public class LeaveConfigurationModel
    {
        public int LeaveID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
        public decimal MaxDaysAllow { get; set; }
        public bool CarryForwardLeave { get; set; }
        public decimal CarryForwardLimitDays { get; set; }
        public decimal LeavesEarned { get; set; }
        public bool ApplicableInProbation { get; set; }
        public bool LeaveEnchashable { get; set; }
        public string EncashableSalaryHeadIDs { get; set; }
        public string EncashableSalaryHeadNames { get; set; }
        public bool IsActive { get; set; }

        public int EmployeeID { get; set; }
        public int FinYearID { get; set; }

    }

    public class LeaveApplicationModel
    {
        public int ApplicationID { get; set; }
        public string ApplicationNo { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public string ApplicationNoWithDate { get { return string.Format("{0}\ndt. {1}", this.ApplicationNo, this.ApplicationDate.ToString("dd MMM yyyy"));} }
        public string EmployeeName { get; set; } 
        public string LeaveDescription { get; set; } 
        public System.DateTime FromDateTime { get; set; }
        public System.DateTime ToDateTime { get; set; }
        public int PreparedByID { get; set; } 
        public string PreparedByName { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        public string Remarks { get; set; }
       // public bool IsDeleted { get; set; }
        public String ApplicationStatus { get; set; }
        public int ApprovedByID { get; set; }
        public string ApprovedByName { get; set; }
        public System.DateTime Approval_Date { get; set; }

        public string SearchString { get { return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} ", this.ApplicationNo.ToUpper(),
            this.ApplicationDate.ToString("dd MMM yyyy").ToUpper(), this.EmployeeName.ToUpper(), this.LeaveDescription.ToUpper(),
            this.FromDateTime.ToString("dd MMM yyyy").ToUpper(), this.ToDateTime.ToString("dd MMM yyyy").ToUpper(),
            this.PreparedByName.ToUpper(), this.Remarks.ToUpper(),this.ApplicationStatus.ToUpper()); } }
    }


    public class LeaveBalanceModel
    {
        public decimal Allowed { get; set; }
        public decimal Earned { get; set; }
        public decimal Taken { get; set; }
        //public string TakenAsText { get { return string.Format("{0}"); } }
        public decimal Balance { get; set; }
        
    }
}
