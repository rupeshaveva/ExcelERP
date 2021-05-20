using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Controls.HR.EmployeeSalary;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.MODELS.HR;

namespace appExcelERP.Controls.USER_INFO
{
    public partial class PageMyPayslips : UserControl
    {
       
        private DataTable _dtPayslip = null;
        private ControlEmployeeSalaryView _payslipViewer = null;

        private BindingList<PayslipMonthlyListModel> _PayslipMonthsList = null;
        private BindingList<PayslipMonthlyListModel> _filteredPayslipMonthsList = null;

        private string selectedPayslipMonth = string.Empty;
        public PageMyPayslips()
        {
            InitializeComponent();
        }
        private void PageMyPayslips_Load(object sender, EventArgs e)
        {
            try
            {
                _payslipViewer = new ControlEmployeeSalaryView();
                _payslipViewer.EmployeeID = Program.CURR_USER.EmployeeID;
                kryptonSplitContainer1.Panel2.Controls.Add(_payslipViewer);
                _payslipViewer.Dock = DockStyle.Fill;
                PopulateMonthlyPayslipsGrid();
                _payslipViewer.SetReadOnly();

                headerGroupMain.ValuesPrimary.Heading = Program.CURR_USER.UserFullName;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMyPayslips::PageMyPayslips_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #region EMPLOYEE PAYSLIP
        public void PopulateMonthlyPayslipsGrid()
        {
            try
            {
                _PayslipMonthsList = AppCommon.ConvertToBindingList<PayslipMonthlyListModel>((new ServicePayRoll()).GetDistinctPayslipMonthsList());
                gridPayslips.DataSource = _PayslipMonthsList;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMyPayslips::PopulateMonthlyPayslipsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridPayslips_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedPayslipMonth = gridPayslips.Rows[e.RowIndex].Cells["PayslipMonth"].Value.ToString();
                _payslipViewer.SalaryMonth= (DateTime)gridPayslips.Rows[e.RowIndex].Cells["FromDate"].Value;
                _payslipViewer.GeneratePaySlip();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMyPayslips::gridPayslips_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridPayslips_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridPayslips.Columns["FromDate"].Visible = gridPayslips.Columns["ToDate"].Visible =gridPayslips.Columns["SearchString"].Visible= false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMyPayslips::gridPayslips_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSearchMyPayslip_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredPayslipMonthsList = new BindingList<PayslipMonthlyListModel>(_PayslipMonthsList.Where(p => p.SearchString.Contains(txtSearchPayslips.Text.ToUpper())).ToList());
                gridPayslips.DataSource = _filteredPayslipMonthsList;
                headerGroupPayslipMonths.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridPayslips.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageMyPayslips::txtSearchPayslips_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion


    }
}
