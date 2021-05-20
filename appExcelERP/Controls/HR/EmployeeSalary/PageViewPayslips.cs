using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.HR;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.MODELS;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.HR.EmployeeSalary
{
    public partial class PageViewPayslips : UserControl
    {
        private DataTable _dtPayroll = null;
        private BindingList<MonthlyPayslipViewModel> _monthlyPayslips = null;
        private BindingList<MonthlyPayslipViewModel> _filteredMonthlyPayslips = null;
        public int SelectedPayslipID { get; set; }
        public bool SelectedPayslipApproved { get; set; }

        public PageViewPayslips()
        {
            InitializeComponent();
        }
        #region PAYSLIP VIEWER
        private void PayViewPayslips_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageViewPayslips::PayViewPayslips_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridPayslips_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServicePayRoll _SERVICE = new ServicePayRoll();
                SelectedPayslipApproved = (bool)gridPayslips.Rows[e.RowIndex].Cells[_SERVICE.payroll_col_IS_APPROVED].Value;
                btnApprovePayslip.Text = (SelectedPayslipApproved == true) ? "Dis-Approve" : "Approve Now";
                SelectedPayslipID = (int)gridPayslips.Rows[e.RowIndex].Cells[_SERVICE.payroll_col_PAYSLIP_ID].Value;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageViewPayslips::gridPayslips_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPrepareMonthlySheet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string payslipMonth = string.Format("{0}", dtPayslipMonth.Value.ToString("MMM-yyyy").ToUpper());
                _dtPayroll = (new ServicePayRoll()).GeneratePayrollDatatableForMonth(dtPayslipMonth.Value);
                gridPayslips.DataSource = _dtPayroll;
                //_monthlyPayslips = AppCommon.ConvertToBindingList<MonthlyPayslipViewModel>((new ServicePayRoll()).GetAllEmployeesMonthlyPayslipList(payslipMonth));
                //gridPayslips.DataSource = _monthlyPayslips;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageViewPayslips::btnPrepareMonthlySheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }
        private void gridPayslips_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //return;
                ServicePayRoll _service = new ServicePayRoll();
                foreach (DataGridViewColumn col in gridPayslips.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    
                }
                gridPayslips.Columns[_service.payroll_col_EMP_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                headerGroupPayslipSheet.ValuesSecondary.Heading = string.Format("{0} records found.", gridPayslips.Rows.Count);
                //gridPayslips.ColumnHeadersVisible = true;
                gridPayslips.Columns[_service.payroll_col_EMP_ID].Visible = gridPayslips.Columns[_service.payroll_col_EMP_CODE].Visible = gridPayslips.Columns[_service.payroll_col_WEEKLY_OFF].Visible = false;
                gridPayslips.Columns[_service.payroll_col_EMP_NAME].Width = (int)(gridPayslips.Width * .15);
                gridPayslips.Columns[_service.payroll_col_EMP_NAME].HeaderText = "Name of\nEmployee";
                gridPayslips.Columns[_service.payroll_col_TOT_DAYS].HeaderText = "Days";
                gridPayslips.Columns[_service.payroll_col_PRESENT_DAYS].HeaderText = "P";
                gridPayslips.Columns[_service.payroll_col_ABSENT_DAYS].HeaderText = "A";
                gridPayslips.Columns[_service.payroll_col_LEAVES].HeaderText = "L";
                gridPayslips.Columns[_service.payroll_col_PAID_HOLIDAYS].HeaderText = "H";
                gridPayslips.Columns[_service.payroll_col_PAID_DAYS].HeaderText = "Paid";

                gridPayslips.Columns[_service.payroll_col_TOT_DAYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridPayslips.Columns[_service.payroll_col_PRESENT_DAYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridPayslips.Columns[_service.payroll_col_ABSENT_DAYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridPayslips.Columns[_service.payroll_col_LEAVES].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridPayslips.Columns[_service.payroll_col_PAID_HOLIDAYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridPayslips.Columns[_service.payroll_col_PAID_DAYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                int ALLOUNCE_CATAGAORY_ID = Program.LIST_DEFAULTS.Where(x=>x.ID== (int) APP_DEFAULT_VALUES.SalaryHeadEARNINGType).FirstOrDefault().DEFAULT_VALUE ;
                List<SelectListItem> lstAllounces = (new ServiceSalaryHead()).GetSelectListItemSalaryHeadsofType(ALLOUNCE_CATAGAORY_ID);
                foreach (SelectListItem item in lstAllounces)
                {
                    gridPayslips.Columns[item.Description].DefaultCellStyle.Format = "0.00";
                    gridPayslips.Columns[item.Description].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    gridPayslips.Columns[item.Description].HeaderText = item.Description.Replace(' ', '\n');
                }
                int DEDUCTION_CATAGAORY_ID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalaryHeadDEDUCTIONType).FirstOrDefault().DEFAULT_VALUE;
                List<SelectListItem> lstDeductions = (new ServiceSalaryHead()).GetSelectListItemSalaryHeadsofType(DEDUCTION_CATAGAORY_ID);
                foreach (SelectListItem item in lstDeductions)
                {
                    gridPayslips.Columns[item.Description].DefaultCellStyle.Format = "0.00";
                    gridPayslips.Columns[item.Description].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    gridPayslips.Columns[item.Description].HeaderText = item.Description.Replace(' ', '\n');
                }

                gridPayslips.Columns[_service.payroll_col_TOT_EARNINGS].HeaderText = "Total\nEarnings";
                gridPayslips.Columns[_service.payroll_col_TOT_EARNINGS].DefaultCellStyle.Format = "0.00";
                gridPayslips.Columns[_service.payroll_col_TOT_EARNINGS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                gridPayslips.Columns[_service.payroll_col_TOT_DEDUCTIONS].HeaderText = "Total\nDeductions";
                gridPayslips.Columns[_service.payroll_col_TOT_DEDUCTIONS].DefaultCellStyle.Format = "0.00";
                gridPayslips.Columns[_service.payroll_col_TOT_DEDUCTIONS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                gridPayslips.Columns[_service.payroll_col_GROSS_SALARY].HeaderText = "Gross\nSalary";
                gridPayslips.Columns[_service.payroll_col_GROSS_SALARY].DefaultCellStyle.Format = "0.00";
                gridPayslips.Columns[_service.payroll_col_GROSS_SALARY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                gridPayslips.Columns[_service.payroll_col_NET_SALARY].HeaderText = "Net\nSalary";
                gridPayslips.Columns[_service.payroll_col_NET_SALARY].DefaultCellStyle.Format = "0.00";
                gridPayslips.Columns[_service.payroll_col_NET_SALARY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                headerGroupPayslipSheet.ValuesSecondary.Heading = string.Format("{0} records found.", gridPayslips.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageViewPayslips::gridPayslips_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnApprovePayslip_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ServicePayRoll _service = new ServicePayRoll();

                (new ServicePayRoll()).ApprovePayslip(SelectedPayslipID, Program.CURR_USER.EmployeeID, !SelectedPayslipApproved);
                string strEXPR = string.Format("[{0}]=0", _service.payroll_col_PAYSLIP_ID,SelectedPayslipID);
                DataRow[] rows = _dtPayroll.Select(strEXPR);
                if (rows.Count() > 0)
                {
                    rows[0][_service.payroll_col_IS_APPROVED] = !SelectedPayslipApproved;
                    _dtPayroll.AcceptChanges();
                }
                gridPayslips.DataSource = _dtPayroll;
                gridPayslips.Refresh();
                
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageViewPayslips::btnApprovePayslip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnExportMonthlyPayrollTooExcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strFileName = string.Format("{0}{1}.xls", AppCommon.GetDefaultStorageFolderPath(), dtPayslipMonth.Value.ToString("yyyy-MMM"));
                (new ServiceExcelApp()).ExportMonthlyPayrollDataToExcel(_dtPayroll, strFileName, dtPayslipMonth.Value);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::btnExportMonthlyPayrollTooExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchPayslipViewer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredMonthlyPayslips = new BindingList<MonthlyPayslipViewModel>(_monthlyPayslips.Where(p => p.SearchString.Contains(txtSearchEmployee.Text.ToUpper())).ToList());
                gridPayslips.DataSource = _filteredMonthlyPayslips;
                headerGroupPayslipSheet.ValuesSecondary.Heading = string.Format("{0} records found.", gridPayslips.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::btnSearchPayslipViewer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
