using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.HR;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeLeaveConfig : UserControl
    {
        public int SelectedEmployeeID { get; set; }
        public int SelectedFinYearID { get; set; }

        public int SelectedLeaveID { get; set; }
        private BindingList<SelectListItem> _FinYearList = null;
        private BindingList<SelectListItem> _filteredFinYearList = null;


        public ControlEmployeeLeaveConfig()
        {
            InitializeComponent();
        }
        private void ControlEmployeeLeaveConfig_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateFinYEars();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::ControlEmployeeLeaveConfig_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetReadOnly()
        {
            try
            {
                btnAddNewYearlyLeave.Enabled = btnEditYearlyLeave.Enabled  = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PopulateFinYEars()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SelectedFinYearID = 0;
                _FinYearList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllFinancialYears());
                gridFY.DataSource = _FinYearList;

                gridFY.Columns["ID"].Visible =
                gridFY.Columns["Code"].Visible =
                gridFY.Columns["DescriptionToUpper"].Visible =
                gridFY.Columns["IsActive"].Visible = false;

                headerGroupFY.ValuesSecondary.Heading = string.Format("{0} records found", gridFY.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::PopulateFinYEars", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void gridFY_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedFinYearID = (int)gridFY.Rows[e.RowIndex].Cells["ID"].Value;
                PopulateEmployeeLeaveConfigurations();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::gridFY_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchFA_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredFinYearList = new BindingList<SelectListItem>(_FinYearList.Where(p => p.Description.Contains(txtSearchFA.Text.ToUpper())).ToList());
                gridFY.DataSource = _filteredFinYearList;
                headerGroupFY.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridFY.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ControlEmployeeLeaveConfig::btnSearchFA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void PopulateEmployeeLeaveConfigurations()
        {
            try
            {
                gridLeaves.DataSource = (new ServiceEmployee()).GetAllLeavesConfigurationOfEmployeeForYear(SelectedEmployeeID, SelectedFinYearID);
                foreach (DataGridViewColumn col in gridLeaves.Columns)
                {
                    col.Visible = false;
                }
                gridLeaves.Columns["MaxDaysAllow"].Visible =
                gridLeaves.Columns["LeaveTypeName"].Visible =
                gridLeaves.Columns["CarryForwardLeave"].Visible =
                gridLeaves.Columns["CarryForwardLimitDays"].Visible =
                gridLeaves.Columns["LeavesEarned"].Visible =
                gridLeaves.Columns["ApplicableInProbation"].Visible =
                gridLeaves.Columns["LeaveEnchashable"].Visible =
                gridLeaves.Columns["EncashableSalaryHeadNames"].Visible =
                gridLeaves.Columns["IsActive"].Visible = true;

                gridLeaves.Columns["CarryForwardLimitDays"].HeaderText = "Limit Days";
                gridLeaves.Columns["LeaveTypeName"].HeaderText = "Leave Type";
                gridLeaves.Columns["CarryForwardLeave"].HeaderText = "Carry Forward";
                gridLeaves.Columns["LeavesEarned"].HeaderText = "Earned";
                gridLeaves.Columns["ApplicableInProbation"].HeaderText = "Probation";
                gridLeaves.Columns["LeaveEnchashable"].HeaderText = "Enchashable";
                gridLeaves.Columns["EncashableSalaryHeadNames"].HeaderText = "Salary Head(s)";

                tbl_Acct_Financial_Year fyYear = (new ServiceMASTERS()).GetFinancialYearDbRecordByID(this.SelectedFinYearID);
                if (fyYear != null) headerGroupYearlyLeaves.Values.Heading = string.Format("Leave Configuration - {0}", fyYear.FinYearName);


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::PopulateEmployeeLeaveConfigurations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewYearlyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditEmployeeLeaveConfig frm = new frmAddEditEmployeeLeaveConfig();
                frm.EmployeeID = this.SelectedEmployeeID;
                frm.FinYearID = this.SelectedFinYearID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateEmployeeLeaveConfigurations();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::btnAddNewYearlyLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditYearlyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditEmployeeLeaveConfig frm = new frmAddEditEmployeeLeaveConfig(this.SelectedLeaveID);
                frm.EmployeeID = this.SelectedEmployeeID;
                frm.FinYearID = this.SelectedFinYearID;
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    PopulateEmployeeLeaveConfigurations();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::btnEditYearlyLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridLeaves_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedLeaveID = (int)gridLeaves.Rows[e.RowIndex].Cells["LeaveID"].Value;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::gridLeaves_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridLeaves_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnEditYearlyLeave_Click(this.btnAddNewYearlyLeave, null);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeLeaveConfig::gridLeaves_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
