using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace libERP.MODELS.HR
{
    public class EmployeePayslipModel 
    {
        public int PayslipID { get; set; }
        public int EmployeeID { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string EmployeeName { get; set; }
        public string SalaryMonth { get; set; }

        public decimal TotalDays { get; set; }
        public decimal PaidDays { get; set; }
        public decimal BasicSalaryDefault { get; set; }
        public decimal BasicSalaryPerDay { get; set; }
        public decimal BasicSalaryApplied { get; set; }
               
        public List<EmployeePayslipItemModel> MonthlyAllounces { get; set; }
        public List<EmployeePayslipItemModel> MonthlyDeducations { get; set; }

        public decimal StandardAllouncesAmount
        {
            get
            {
                return (from xx in this.MonthlyAllounces where xx.IsStandard == true && xx.SalaryHeadAmount > 0 select xx.SalaryHeadAmount).Sum();
            }
        }
        public decimal AdditionalAllouncesAmount
        {
            get
            {
                return (from xx in this.MonthlyAllounces where xx.IsStandard == false && xx.SalaryHeadAmount > 0  select xx.SalaryHeadAmount).Sum();
            }
        }
        public decimal StandardDeducationAmount
        {
            get
            {
                return (from xx in this.MonthlyDeducations where xx.IsStandard == true && xx.SalaryHeadAmount > 0  select xx.SalaryHeadAmount).Sum();
            }
        }
        public decimal AdditionalDeducationAmount
        {
            get
            {
                return (from xx in this.MonthlyDeducations where xx.IsStandard == false && xx.SalaryHeadAmount > 0 select xx.SalaryHeadAmount).Sum();
            }
        }

        public decimal GrossSalaryAmount
        {
            get
            {
                //decimal totLumsumDeduction= this.MonthlyDeducations.Where(x => x.ChargesType== ITEM_CHARGE_TYPE.LUMPSUM).Sum(x => x.SalaryHeadAmount);
                //decimal totOnBasicDeduction = this.MonthlyDeducations.Where(x => x.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC).Sum(x => x.SalaryHeadAmount);
                //decimal totOnBasicAndDADeduction = this.MonthlyDeducations.Where(x => x.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA).Sum(x => x.SalaryHeadAmount);

                //decimal deductionGross = this.MonthlyDeducations.Where(x => x.HeadForCalculation != SalaryHeadCalculatedOn.PERCENT_OF_GROSS).Sum(x => x.SalaryHeadAmount);

                return (this.StandardAllouncesAmount + this.AdditionalAllouncesAmount) ;
            }
        }
        public decimal NetSalaryAmount
        {
            get
            {
                return (this.StandardAllouncesAmount + this.AdditionalAllouncesAmount) - (this.StandardDeducationAmount+ this.AdditionalDeducationAmount);
            }
        }

        #region ctc properties
        public decimal PFEMPLOYER { get; set; }
        public decimal ESICEMPLOYER { get; set; }
        public decimal BONUS { get; set; }
        public decimal GRATUITY { get; set; }
        public decimal MEDICALINSURANCE { get; set; }
        public decimal ACCIDENTINSURANCE { get; set; }
        #endregion

        public EmployeePayslipModel()
        {
            try
            {
                this.MonthlyAllounces = new List<EmployeePayslipItemModel>();
                this.MonthlyDeducations = new List<EmployeePayslipItemModel>();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "EmployeePayslipModel::EmployeePayslipModel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void UpdateTotals()
        {
            
        }

       


    }


    //public class EmployeeMonthlyAttndanceModel
    //{
    //    public int AttendanceDays { get; set; }
    //    public int PresentDays { get; set; }
    //    public int NonWorkingDays { get; set; }
    //    public int SandwichDays { get; set; }

    //    public int PaidDays { get; set; }
    //    public int AbsentDays { get; set; }
    //    public int DeducationDays { get; set; }

    //    public TimeModal OverTime { get; set; }
    //    public TimeModal UnderTime { get; set; }
    //}
    //public class EmployeeMonthlyLeaveModel
    //{
    //    public int PL { get; set; }
    //    public int CL { get; set; }
    //    public int SL { get; set; }
    //    public int CompOff { get; set; }
    //}
    public class EmployeePayslipItemModel
    {
        public bool IsApplied { get; set; }
        public int SalaryHeadID { get; set; }
        public string SalaryHeadName { get; set; }
        public SalaryHeadCalculatedOn HeadForCalculation { get; set; }
        public bool IsStandard { get; set; }
        public ITEM_CHARGE_TYPE ChargesType { get; set; }
        public decimal SalaryHeadValue { get; set; }
        public string SalaryHeadCaption {
            get
            {
                string str=string.Format("{0} {1:0.00} {2}",(ChargesType == ITEM_CHARGE_TYPE.LUMPSUM) ? "Rs. " : "", 
                    SalaryHeadValue, 
                    (ChargesType == ITEM_CHARGE_TYPE.PERCENTAGE) ? "%" : "");

                if (this.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC) str += " (B)";
                if (this.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS) str += " (G)";
                if (this.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA) str += " (BA+DA)";
                return str;
            }
        }
        public decimal SalaryHeadAmount { get; set; }

    }
    public class MonthlyPayslipViewModel
    {
        public int PayslipID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string SalaryMonth { get; set; }
        public decimal TotalAllounces { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal GrossSalary { get; set; }
        public bool IsApproved { get; set; }
        public string SearchString
        {
            get
            {
                return string.Format("{0} {1}", this.EmployeeName.ToString(),this.SalaryMonth);
            }
        }
    }

    public class PayslipMonthlyListModel 
    {
        public string PayslipMonth { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string SearchString
        {
            get
            {
                return string.Format("{0}", PayslipMonth.ToString());
            }
        }
    }
}
