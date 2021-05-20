using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.MODELS.HR;

namespace appExcelERP.Controls.HR.EmployeeSalary
{
    public partial class PageGeneratePayslips : UserControl
    {
        private int SelectedEmployeeID = 0;
        private BindingList<SelectListItem> _EmployeesList = null;
        private BindingList<SelectListItem> _filteredEmployeesList = null;

        private ControlEmployeeSalaryView _EmployeeSalaryViewControl = null;

        public PageGeneratePayslips()
        {
            InitializeComponent();
        }
        #region GENERATE PAYSLIP
        private void GeneratePaySlipForSelectedEmployee()
        {
            try
            {
                if (_EmployeeSalaryViewControl != null)
                {
                    _EmployeeSalaryViewControl.EmployeeID = this.SelectedEmployeeID;
                    _EmployeeSalaryViewControl.SalaryMonth = this.dtSalaryMonth.Value;
                    _EmployeeSalaryViewControl.GeneratePaySlip();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::GeneratePaySlipForSelectedEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridActiveEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedEmployeeID = (int)gridActiveEmployees.Rows[e.RowIndex].Cells["ID"].Value;
                GeneratePaySlipForSelectedEmployee();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::gridActiveEmployees_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PageGeneratePayslips_Load(object sender, EventArgs e)
        {
            try
            {
                _EmployeeSalaryViewControl = new ControlEmployeeSalaryView();
                splitContainerMain.Panel2.Controls.Clear();
                splitContainerMain.Panel2.Controls.Add(_EmployeeSalaryViewControl);
                splitContainerMain.SplitterDistance = (int)(this.Width * .30);
                _EmployeeSalaryViewControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::PageGeneratePayslips_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnGeneratePayslips_Click(object sender, EventArgs e)
        {
            ServiceEmployee service = new ServiceEmployee();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int idx = 1;
                headerGroupMain.ValuesSecondary.Heading = string.Format("Processing Payroll for {0}", dtSalaryMonth.Value.ToString("MMMM yyyy"));
                _EmployeesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceAttendance()).GetDistinctEmployeesListForMonthInAttendance(dtSalaryMonth.Value));
                headerGroupMain.ValuesSecondary.Heading = string.Format("Generating Payslip [{0}/{1}].Employees", idx, _EmployeesList.Count);
                foreach (SelectListItem emp in _EmployeesList)
                {
                    //if (emp.ID == 8) // for debugging 
                    //{
                    //    MessageBox.Show(emp.ID.ToString());
                    //}
                       

                    EmployeePayslipModel model = (new ServiceEmployee()).GetEmployeePayslipModel(emp.ID, dtSalaryMonth.Value);
                    (new ServiceEmployee()).SaveEmployeePayslip(model);
                    headerGroupMain.ValuesSecondary.Heading = string.Format("Processed [{0}/{1}].\n{2}", idx++, _EmployeesList.Count, emp.Description);
                    Application.DoEvents();
                }
                gridActiveEmployees.DataSource = _EmployeesList;
                FormatEmployeeGrid();
                headerGroupMain.ValuesSecondary.Heading = string.Format("Select Employee to View/Modify Salary");
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::btnGeneratePayslips_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void FormatEmployeeGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                gridActiveEmployees.Columns["ID"].Visible =
                gridActiveEmployees.Columns["Code"].Visible =
                gridActiveEmployees.Columns["DescriptionToUpper"].Visible =
                gridActiveEmployees.Columns["IsActive"].Visible = false;
                headerGroupEmployees.ValuesSecondary.Heading =string.Format("{0} records found.", gridActiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::FormatEmployeeGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchActiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredEmployeesList = new BindingList<SelectListItem>(_EmployeesList.Where(p => p.DescriptionToUpper.Contains(txtSearchActiveEmployees.Text.ToUpper())).ToList());
                gridActiveEmployees.DataSource = _filteredEmployeesList;
                headerGroupEmployees.ValuesSecondary.Heading = string.Format("{0} records found.", gridActiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageGeneratePayslips::btnSearchActiveUsers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion


    }
}
