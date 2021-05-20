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
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;

namespace appExcelERP.Controls.HR
{
    public partial class PageHR_LeavesConfiguration : UserControl
    {
        public int SelectedBranchID { get; set; }
        public int SelectedYearID { get; set; }
        public int SelectedLeaveID { get; set; }
    //    public int SelectedEmployeeID { get; set; }


        public PageHR_LeavesConfiguration()
        {
            InitializeComponent();
        }
        private void PageHR_LeavesConfiguration_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateBranchesDropdown();
                PopulateFinancialYearDropdown();

                PopulateLeaveGrid();


            }
           catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::PageHR_ManageLeaves_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }

        public void PopulateLeaveGrid()
        {
            try
            {
                gridLeaves.DataSource = null;
                Application.DoEvents();
                gridLeaves.DataSource = (new ServiceLeaveConfiguration()).GetAllLeavesConfigurationForBranchAndYear(this.SelectedBranchID, this.SelectedYearID);

                foreach (DataGridViewColumn col in gridLeaves.Columns)
                {
                    col.Visible = false;
                }
                gridLeaves.Columns["MaxDaysAllow"].Visible =
                gridLeaves.Columns["LeaveTypeName"].Visible =
                gridLeaves.Columns["CarryForwardLeave"].Visible =
                gridLeaves.Columns["CarryForwardLimitDays"].Visible =
                gridLeaves.Columns["ApplicableInProbation"].Visible =
                gridLeaves.Columns["LeaveEnchashable"].Visible =
                gridLeaves.Columns["EncashableSalaryHeadNames"].Visible =
                gridLeaves.Columns["IsActive"].Visible = true;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::PopulateLeaveGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::gridLeaves_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region POPULATE DROPDOWN
        private void PopulateBranchesDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllBraches());
                cboBranch.DataSource = LST;
                cboBranch.DisplayMember = "Description";
                cboBranch.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::PopulateBranchesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateFinancialYearDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllFinancialYears());
                cboFinYear.DataSource = LST;
                cboFinYear.DisplayMember = "Description";
                cboFinYear.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::PopulateFinancialYearDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateSalaryIncomeHEads()
        {

        }
        #endregion

        private void btnAddNewYearlyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLeaveConfiguration FRM = new frmAddEditLeaveConfiguration();
                FRM.SeledctedBranchID = this.SelectedBranchID;
                FRM.SeledctedYearID = this.SelectedYearID;
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    PopulateLeaveGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::btnAddNewYearlyLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditYearlyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLeaveConfiguration FRM = new frmAddEditLeaveConfiguration(this.SelectedLeaveID);
                FRM.SeledctedBranchID = this.SelectedBranchID;
                FRM.SeledctedYearID = this.SelectedYearID;
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    PopulateLeaveGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::btnEditYearlyLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteYearlyLeave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Are you sure to Delete selected Leave Permanently";
                DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    (new ServiceLeaveConfiguration()).DeleteLeaveConfiguration(this.SelectedLeaveID);
                    PopulateLeaveGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::btnDeleteYearlyLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void cboBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedBranchID = 0;
                SelectListItem selItem = (SelectListItem)cboBranch.SelectedItem;
                if (selItem != null)
                    this.SelectedBranchID = selItem.ID;
                PopulateLeaveGrid();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::cboBranch_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboFinYear_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedYearID = 0;
                SelectListItem selItem = (SelectListItem)cboFinYear.SelectedItem;
                if (selItem != null)
                    this.SelectedYearID = selItem.ID;
                PopulateLeaveGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHR_LeavesConfiguration::cboFinYear_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

          }
}
