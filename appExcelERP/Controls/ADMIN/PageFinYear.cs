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
using libERP.SERVICES.MASTER;
using appExcelERP.Forms.ADMIN;
using libERP.SERVICES.HR;
using libERP;

namespace appExcelERP.Controls.ADMIN
{
    public partial class PageFinYear : UserControl
    {
        public int SelectedFinYearID { get; set; }
        private BindingList<SelectListItem> _FinYearList = null;
        private BindingList<SelectListItem> _filteredFinYearList = null;
        public PageFinYear()
        {
            InitializeComponent();
        }
        
        private void PageFinYear_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateFinYears();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::PageFinYear_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PopulateFinYears()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SelectedFinYearID = 0;
                _FinYearList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllFinancialYears());
                gridFinYears.DataSource = _FinYearList;

                gridFinYears.Columns["ID"].Visible =
                gridFinYears.Columns["Code"].Visible =
                gridFinYears.Columns["DescriptionToUpper"].Visible =
                gridFinYears.Columns["IsActive"].Visible = false;

                headerGroupFinYears.ValuesSecondary.Heading = string.Format("{0} records found", gridFinYears.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::PopulateFinYears", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void gridFinYears_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedFinYearID = (int)gridFinYears.Rows[e.RowIndex].Cells["ID"].Value;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::gridFinYears_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchFinYears_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredFinYearList = new BindingList<SelectListItem>(_FinYearList.Where(p => p.Description.Contains(txtSearchFinYears.Text.ToUpper())).ToList());
                gridFinYears.DataSource = _filteredFinYearList;
                headerGroupFinYears.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridFinYears.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::txtSearchFinYears_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnAddNewFinYear_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditFinYear frm = new frmAddEditFinYear();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateFinYears();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::btnAddNewFinYear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEditFinYear_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditFinYear frm = new frmAddEditFinYear(this.SelectedFinYearID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateFinYears();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if(ex.InnerException!=null) errMessage+=string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::btnEditFinYear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteFinYear_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Financial Year {0}", this.SelectedFinYearID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceMASTERS()).DeleteFinancialYear(this.SelectedFinYearID, Program.CURR_USER.EmployeeID))
                        PopulateFinYears();
                    //gridFinYears.Refresh();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::btnDeleteFinYear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGenerateLeaveConfigurationForEmployees_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                txtProgress.Text = string.Empty;
                tbl_Acct_Financial_Year currYear = (new ServiceMASTERS()).GetFinancialYearDbRecordByID(this.SelectedFinYearID);
                ServiceLeaveConfiguration configuration = new ServiceLeaveConfiguration();
                configuration.OnEmployeeLeaveConfigurationCompleted += Configuration_OnEmployeeLeaveConfigurationCompleted;
                configuration.GenerateEmployeeLeaveConfigurationsForFinYear(currYear.FK_CompanyID, currYear.FK_BranchID, currYear.PK_ID);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::btnGenerateLeaveConfigurationForEmployees_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void Configuration_OnEmployeeLeaveConfigurationCompleted(object sender, libERP.MODELS.COMMON.EventArguementModel e)
        {
            try
            {
                //txtProgress.Text += "\n" + e.Message;
                txtProgress.AppendText(e.Message);
                txtProgress.ScrollToCaret();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageFinYear::Configuration_OnEmployeeLeaveConfigurationCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

      
    }
}
