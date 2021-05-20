using libERP;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.ADMIN
{
    public partial class frmAddEditFinYear : Form
    {
        public int FIN_YEAR_ID { get; set; }

        public frmAddEditFinYear()
        {
            InitializeComponent();
        }
        public frmAddEditFinYear(int ID)
        {
            InitializeComponent();
            this.FIN_YEAR_ID = ID;
        }

        private void frmAddEditFinYear_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateCompaniesDropdwn();
                PopulateBranchDropdown();
                if (FIN_YEAR_ID != 0)
                    ScatterData();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::frmAddEditFinYear_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateCompaniesDropdwn()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllCompanies());
                cboCompany.DataSource = lst;
                cboCompany.DisplayMember = "Description";
                cboCompany.ValueMember = "Id";


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::PopulateCompaniesDropdwn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBranchDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllBraches());
                cboBranch.DataSource = lst;
                cboBranch.DisplayMember = "Description";
                cboBranch.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::PopulateBranchDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ScatterData()
        {
            try
            {
                tbl_Acct_Financial_Year model = (new ServiceMASTERS()).GetFinancialYearDbRecordByID(this.FIN_YEAR_ID);
                if (model != null)
                {
                    cboCompany.SelectedItem = ((List<SelectListItem>)cboCompany.DataSource).Where(x => x.ID == (int)model.FK_CompanyID).FirstOrDefault();
                    cboBranch.SelectedItem = ((List<SelectListItem>)cboBranch.DataSource).Where(x => x.ID == (int)model.FK_BranchID).FirstOrDefault();
                    dtFromDate.Value = model.FromDate;
                    dtToDate.Value = model.ToDate;
                    txtFinYearName.Text = model.FinYearName;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ServiceMASTERS service = new ServiceMASTERS();
            try
            {
                if (!this.ValidateChildren()) return;
                tbl_Acct_Financial_Year model = null;
                if (FIN_YEAR_ID == 0)
                    model = new tbl_Acct_Financial_Year();
                else
                    model = service.GetFinancialYearDbRecordByID(FIN_YEAR_ID);

                model.FK_CompanyID = ((SelectListItem)cboCompany.SelectedItem).ID;
                model.FK_BranchID = ((SelectListItem)cboBranch.SelectedItem).ID;
                model.FromDate = dtFromDate.Value;
                model.ToDate = dtToDate.Value;
                model.FinYearName = txtFinYearName.Text;

                if (FIN_YEAR_ID == 0)
                    FIN_YEAR_ID = service.AddNewFinancialYear(model);
                else
                    service.UpdateFinancialYear(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
        #region VALIDATION
        private void dtToDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (dtToDate.Value <= dtFromDate.Value)
                {
                    errorProvider1.SetError(dtToDate, "Invalid Date Range");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboCompany_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboCompany.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCompany, "Invalid Company");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear ::cboCompany_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboBranch_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBranch.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBranch, "Invalid Branch");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear ::cboBranch_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtFinYearName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtFinYearName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtFinYearName, "Fin Year Name is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFinYear::txtFinYearName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }

}
