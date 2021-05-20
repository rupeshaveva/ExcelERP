using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{
    public class ServicePayRoll: DefaultService
    {
        public string payroll_col_PAYSLIP_ID = "PAYSLIP_ID";
        public string payroll_col_EMP_ID = "EMP_ID";
        public string payroll_col_EMP_CODE = "EMP_CODE";
        public string payroll_col_EMP_NAME = "EMP_NAME";
        public string payroll_col_TOT_DAYS = "TOT_DAYS";
        public string payroll_col_PRESENT_DAYS = "PRESENT_DAYS";
        public string payroll_col_ABSENT_DAYS = "ABSENT_DAYS";
        public string payroll_col_PAID_DAYS = "PAID_DAYS";
        public string payroll_col_PAID_HOLIDAYS = "PAID_HOLIDAYS";
        public string payroll_col_WEEKLY_OFF = "WEEKLY_OFF";
        public string payroll_col_LEAVES = "LEAVES";
        public string payroll_col_TOT_EARNINGS = "TOT_EARNINGS";
        public string payroll_col_TOT_DEDUCTIONS = "TOT_DEDUCTIONS";
        public string payroll_col_GROSS_SALARY = "GROSS_SALARY";
        public string payroll_col_NET_SALARY = "NET_SALARY";
        public string payroll_col_IS_APPROVED = "IS_APPROVED";

       
        public ServicePayRoll(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServicePayRoll()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<string> GetDistinctPayslipMonths()
        {
            List<string> lst = new List<string>();
            try
            {
                string strQuery = "select distinct payslipmonth from TBL_MP_HR_PayslipMaster";
                lst= _dbContext.Database.SqlQuery<string>(strQuery).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::GetDistinctPayslipMonths", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<PayslipMonthlyListModel> GetDistinctPayslipMonthsList()
        {
            List<PayslipMonthlyListModel> lst = new List<PayslipMonthlyListModel>();
            try
            {
                string strQuery = "select distinct PayslipMonth, FromDate,ToDate from TBL_MP_HR_PayslipMaster order by fromdate desc";
                lst =_dbContext.Database.SqlQuery<PayslipMonthlyListModel>(strQuery).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::GetDistinctPayslipMonthsList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<MonthlyPayslipViewModel> GetAllEmployeesMonthlyPayslipList(string strMonth)
        {
            List<MonthlyPayslipViewModel> lst = new List<MonthlyPayslipViewModel>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select A.PayslipID as PayslipID, A.FK_EmployeeID as EmployeeID, b.EmployeeDescription as EmployeeName, ");
                sb.Append("a.TotalAllounces,a.TotalDeductions,a.GrossSalary,a.IsApproved ");
                sb.Append("from TBL_MP_HR_PayslipMaster A LEFT JOIN vEMPLOYEE_DESCRIPTION B on A.FK_EmployeeID = B.PK_EmployeeId ");
                sb.Append("where a.PayslipMonth = '{0}' ORDER BY 2");
                string strQuery = string.Format(sb.ToString(), strMonth);
                lst = _dbContext.Database.SqlQuery<MonthlyPayslipViewModel>(string.Format(strQuery)).ToList();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::GetAllEmployeesMonthlyPayslipList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public void ApprovePayslip(int SelectedPayslipID, int employeeID, bool isApproved)
        {
            try
            {
                TBL_MP_HR_PayslipMaster dbRecord = _dbContext.TBL_MP_HR_PayslipMaster.Where(x => x.PayslipID == SelectedPayslipID).FirstOrDefault();
                if (dbRecord != null)
                {
                    dbRecord.FK_ApprovedBy = employeeID;
                    dbRecord.ApprovedDatetime = AppCommon.GetServerDateTime();
                    dbRecord.IsApproved = isApproved;
                    if (!dbRecord.IsApproved)
                    {
                        dbRecord.FK_ApprovedBy = null;
                        dbRecord.ApprovedDatetime = null;
                    }
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::ApprovePayslip", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public TBL_MP_HR_PayslipMaster GetPaySlipRecordbyID(int payslipID)
        {
            TBL_MP_HR_PayslipMaster lst = new TBL_MP_HR_PayslipMaster();
            try
            {

                lst = _dbContext.TBL_MP_HR_PayslipMaster.Where(x => x.PayslipID == payslipID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::GetPaySlipRecordbyID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst; 
        }
        public DataTable GeneratePayrollDatatableForMonth(DateTime dateSalaryMonth)
        {
            // MONTH FORMAT -> JAN-2019
            DataTable dtMain = new DataTable();
            string strPayMonth = string.Format("{0}", dateSalaryMonth.ToString("MMM-yyyy")).ToUpper();
            try
            {
                #region PREPARE DATATABLE COLUMNS
                // ADD COLUMNS TO THE DATATABLE 
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_PAYSLIP_ID, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_EMP_ID, DataType = typeof(int), DefaultValue = 0   });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_EMP_CODE, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_EMP_NAME, DataType = typeof(string), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_TOT_DAYS, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_PRESENT_DAYS, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_ABSENT_DAYS, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_PAID_HOLIDAYS, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_WEEKLY_OFF, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_LEAVES, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_PAID_DAYS, DataType = typeof(int), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_TOT_EARNINGS, DataType = typeof(decimal), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_TOT_DEDUCTIONS, DataType = typeof(decimal), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_GROSS_SALARY, DataType = typeof(decimal), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_NET_SALARY, DataType = typeof(decimal), DefaultValue = 0 });
                dtMain.Columns.Add(new DataColumn() { ColumnName = payroll_col_IS_APPROVED, DataType = typeof(bool), DefaultValue = 0 });

                int stIndex = dtMain.Columns[payroll_col_TOT_EARNINGS].Ordinal;
                // ADDEND COLUMNS OF EARNING TYPE
                int ALLOUNCE_CATAGAORY_ID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadEARNINGType).FirstOrDefault().DEFAULT_VALUE;
                List<SelectListItem> lstAllounces = (new ServiceSalaryHead()).GetSelectListItemSalaryHeadsofType(ALLOUNCE_CATAGAORY_ID);
                foreach (SelectListItem item in lstAllounces)
                {
                    dtMain.Columns.Add(new DataColumn() { ColumnName = string.Format("{0}",item.Description), DataType = typeof(decimal), DefaultValue = false });
                    dtMain.Columns[item.Description].SetOrdinal(stIndex++);
                }
                dtMain.Columns[payroll_col_TOT_EARNINGS].SetOrdinal(stIndex++);
                // ADDEND COLUMNS OF DEDUCTION TYPE
                stIndex = dtMain.Columns[payroll_col_TOT_DEDUCTIONS].Ordinal;
                int DEDUCTION_CATAGAORY_ID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadDEDUCTIONType).FirstOrDefault().DEFAULT_VALUE;
                List<SelectListItem> lstDeductions = (new ServiceSalaryHead()).GetSelectListItemSalaryHeadsofType(DEDUCTION_CATAGAORY_ID);
                foreach (SelectListItem item in lstDeductions)
                {
                    dtMain.Columns.Add(new DataColumn() { ColumnName = item.Description, DataType = typeof(decimal), DefaultValue = false });
                    dtMain.Columns[item.Description].SetOrdinal(stIndex++);
                }
                dtMain.Columns[payroll_col_TOT_DEDUCTIONS].SetOrdinal(stIndex++);
                dtMain.Columns[payroll_col_GROSS_SALARY].SetOrdinal(stIndex++);
                dtMain.Columns[payroll_col_NET_SALARY].SetOrdinal(stIndex++);
                #endregion

                List<TBL_MP_HR_PayslipMaster> lstPayroll = _dbContext.TBL_MP_HR_PayslipMaster.Where(x => x.PayslipMonth == strPayMonth).ToList();
                foreach (TBL_MP_HR_PayslipMaster item in lstPayroll)
                {
                    DataRow dtrow = dtMain.NewRow();
                    dtrow[payroll_col_PAYSLIP_ID] = item.PayslipID;
                    dtrow[payroll_col_EMP_ID] = item.FK_EmployeeID;
                    dtrow[payroll_col_EMP_NAME] = _dbContext.vEMPLOYEE_DESCRIPTION.Where(x => x.PK_EmployeeId == item.FK_EmployeeID).FirstOrDefault().EmployeeDescription;
                    dtrow[payroll_col_IS_APPROVED] = item.IsApproved;
                    #region POPULATE DATABALE BY GETTING ATTENDANCE INFO 
                    EmployeeAttendanceSummaryModel attendance = (new ServiceAttendance()).GetAttendanceSummaryOfEmployeeForMonth(item.FK_EmployeeID, dateSalaryMonth);
                    if (attendance != null)
                    {
                        dtrow[payroll_col_TOT_DAYS] = attendance.TotalDays.Days;
                        dtrow[payroll_col_PRESENT_DAYS] = attendance.Present.Days;
                        dtrow[payroll_col_ABSENT_DAYS] = attendance.Absent.Days;
                        dtrow[payroll_col_PAID_DAYS] = attendance.PaidDays.Days;
                        dtrow[payroll_col_PAID_HOLIDAYS] = attendance.NonWorkingDays.Days;
                        //dtrow[payroll_col_WEEKLY_OFF] = attendance.Present;
                        dtrow[payroll_col_LEAVES] = attendance.TotalLeaves;

                    }
                    #endregion
                    #region POPULATE DATATABLE WITH ALLOUNCES & DEDUCTIONS
                    EmployeePayslipModel SALARY = (new ServiceEmployee()).GetEmployeePayslipModel(item.FK_EmployeeID, dateSalaryMonth);
                    if (SALARY != null)
                    {
                        foreach (EmployeePayslipItemModel payslipItem in SALARY.MonthlyAllounces)
                        {
                            dtrow[payslipItem.SalaryHeadName] = payslipItem.SalaryHeadAmount;
                        }
                        foreach (EmployeePayslipItemModel payslipItem in SALARY.MonthlyDeducations)
                        {
                            dtrow[payslipItem.SalaryHeadName] = payslipItem.SalaryHeadAmount;
                        }

                        dtrow[payroll_col_TOT_EARNINGS] = SALARY.StandardAllouncesAmount + SALARY.AdditionalAllouncesAmount;
                        dtrow[payroll_col_TOT_DEDUCTIONS] = SALARY.StandardDeducationAmount + SALARY.AdditionalDeducationAmount;
                        dtrow[payroll_col_GROSS_SALARY] = SALARY.GrossSalaryAmount;
                        dtrow[payroll_col_NET_SALARY] = SALARY.NetSalaryAmount;
                    }

                        

                    #endregion
                    dtMain.Rows.Add(dtrow);

                }
                                                                                 
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::GeneratePayrollDatatableForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtMain;
        }
        public void RecalculateEmployeeSalaryHeads(EmployeePayslipModel model)
        {
            try
            {
                int basicSalaryHeadID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                int daSalaryHeadID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.daSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;

                foreach (EmployeePayslipItemModel item in model.MonthlyAllounces)
                {

                    if (item.SalaryHeadID == basicSalaryHeadID)
                        item.SalaryHeadAmount = model.BasicSalaryApplied;

                    switch (item.ChargesType)
                    {
                        case ITEM_CHARGE_TYPE.LUMPSUM:
                            item.SalaryHeadAmount = item.SalaryHeadAmount;
                            break;
                        case ITEM_CHARGE_TYPE.PERCENTAGE:
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                item.SalaryHeadAmount = (model.BasicSalaryApplied * item.SalaryHeadValue) / 100;
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                item.SalaryHeadAmount = (model.GrossSalaryAmount * item.SalaryHeadValue) / 100;
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            {
                                decimal daAmount = model.MonthlyAllounces.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;
                                item.SalaryHeadAmount = ((model.BasicSalaryApplied + daAmount) * item.SalaryHeadValue) / 100;
                            }
                            break;
                    }
                }
                foreach (EmployeePayslipItemModel item in model.MonthlyDeducations)
                {

                    if (item.SalaryHeadID == basicSalaryHeadID)
                        item.SalaryHeadAmount = model.BasicSalaryApplied;

                    switch (item.ChargesType)
                    {
                        case ITEM_CHARGE_TYPE.LUMPSUM:
                            item.SalaryHeadAmount = item.SalaryHeadValue;
                            break;
                        case ITEM_CHARGE_TYPE.PERCENTAGE:
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                item.SalaryHeadAmount = (model.BasicSalaryApplied * item.SalaryHeadValue) / 100;
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                item.SalaryHeadAmount = (model.GrossSalaryAmount * item.SalaryHeadValue) / 100;
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            {
                                decimal daAmount = model.MonthlyAllounces.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;
                                item.SalaryHeadAmount = ((model.BasicSalaryApplied + daAmount) * item.SalaryHeadValue) / 100;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServicePayRoll::RecalculateEmployeeSalaryHeads", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
