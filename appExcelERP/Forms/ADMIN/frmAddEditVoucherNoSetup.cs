
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.COMMON;
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
    public partial class frmAddEditVoucherNoSetup : KryptonForm
    {

        public int pkID { get; set; }
        public int FORM_ID { get; set; }
        public string FORM_NAME { get; set; }
        public frmAddEditVoucherNoSetup()
        {
            InitializeComponent();
        }
        public frmAddEditVoucherNoSetup(int ID)
        {
            InitializeComponent();
            pkID = ID;
        }

        private void frmAddEditVoucherNoSetup_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateFinYearDropdown();
                if (this.FORM_NAME != string.Empty) headerGroupMain.ValuesPrimary.Heading = this.FORM_NAME;

                if (pkID != 0)
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::frmAddEditVoucherNoSetup_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ScatterData()
        {
            try
            {
                TBL_MP_Admin_VoucherNoSetup model = (new ServiceVoucherNoSetup()).GetVoucherSetupDBRecordByID(this.pkID);
                if(model!=null)
                {
                    cboYears.SelectedItem = ((List<SelectListItem>)cboYears.DataSource).Where(x => x.ID == model.Fk_YearID).FirstOrDefault();
                    txtNoPrefix.Text = model.NoPrefix.ToString();
                    txtSeparator.Text = txtSeparatorSuffix.Text = model.NoSeperator;
                    txtNoPadding.Text = model.NoPad.ToString();
                    txtNoPostFix.Text = model.NoPostfix;
                    txtVoucherNoPreview.Text = model.VoucherNoPreview;
                    chkIs_continuedNextYear.Checked = model.Is_NoContinuedNextYear;
                    if (model.NoStartingFrom != null) txtNoStartingFrom.Text = model.NoStartingFrom.ToString();
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateFinYearDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllFinancialYears());
                cboYears.DataSource = LST;
                cboYears.DisplayMember = "Description";
                cboYears.ValueMember = "ID";
            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::PopulateFinYearDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region VALIDATIONS
        private void txtNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtNoPrefix.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtNoPrefix, "Should not be left blank");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::txtNoPrefix_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtSeparator_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSeparator.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSeparator, "Should not be left blank");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::txtSeparator_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtNoStyle_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtNoPadding.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtNoPadding, "Should not be left blank");
                    e.Cancel = true;
                    return;
                }
                if (!txtNoPadding.Text.All(Char.IsDigit))
                {
                    errorProvider1.SetError(txtNoPadding, "Enter Digits only [0-9]");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::txtNoStyle_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtNoPostFix_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtNoPostFix.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtNoPostFix, "Should not be left blank");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::txtNoPostFix_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtNoStartingFrom_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chkIs_continuedNextYear.Checked == false)
                {

                    if (txtNoStartingFrom.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtNoStartingFrom, "Should not be left blank");
                        e.Cancel = true;
                        return;
                    }
                    if (!txtNoStartingFrom.Text.All(Char.IsDigit))
                    {
                        errorProvider1.SetError(txtNoStartingFrom, "Enter Digits only [0-9]");
                        e.Cancel = true;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::txtNoStartingFrom_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboYears_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboYears.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboYears, "Leads Source is Mandatory");
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::cboYears_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion  

        private void GenerateVoucherNoPreview(object sender, EventArgs e)
        {
            try
            {
                if (((KryptonTextBox)sender).Name == "txtSeparator") txtSeparatorSuffix.Text = txtSeparator.Text;

                string strPreview = string.Empty;
                strPreview += txtNoPrefix.Text.Trim(); 
                strPreview += txtSeparator.Text.Trim();
                int paddings = int.Parse(txtNoPadding.Text.Trim()); 
                string strNo = string.Empty;
                for (int i = 1; i <= paddings; i++)
                    strNo += "0";
                strPreview += strNo;
                strPreview += txtSeparatorSuffix.Text.Trim();
                strPreview += txtNoPostFix.Text.Trim();

                txtVoucherNoPreview.Text = strPreview;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::GenerateVoucherNoPreview", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_Admin_VoucherNoSetup model = null;
            ServiceVoucherNoSetup _service = new ServiceVoucherNoSetup();
            try
            {
                errorProvider1.Clear();
                if(!this.ValidateChildren()) return;
                if (pkID == 0)
                    model = new TBL_MP_Admin_VoucherNoSetup();
                else
                    model = _service.GetVoucherSetupDBRecordByID(this.pkID);

                //gather data from controls inot model
                model.fk_FormID = this.FORM_ID;
                model.Fk_YearID = ((SelectListItem)cboYears.SelectedItem).ID;
                model.NoPrefix = txtNoPrefix.Text;
                model.NoSeperator = txtSeparator.Text;
                model.NoPad = int.Parse(txtNoPadding.Text);
                model.NoPostfix = txtNoPostFix.Text;
                model.VoucherNoPreview = txtVoucherNoPreview.Text;
                model.Is_NoContinuedNextYear = chkIs_continuedNextYear.Checked;

                if (chkIs_continuedNextYear.Checked)
                    model.NoStartingFrom = null;
                else
                    model.NoStartingFrom = int.Parse(txtNoStartingFrom.Text);

                if (pkID == 0)
                {
                    model.FK_PreparedBy = Program.CURR_USER.EmployeeID;
                    model.CreatedDatetime= AppCommon.GetServerDateTime();
                    model.Fk_BranchID = Program.CURR_USER.BranchID;
                    _service.AddNewVoucherNoSetup(model);
                }
                else
                {
                    model.LastModifiedBy = Program.CURR_USER.EmployeeID;
                    model.LastModifiedDate = AppCommon.GetServerDateTime();
                    _service.UpdateVoucherNoSetup(model);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditVoucherNoSetup::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void chkIs_continuedNextYear_CheckedChanged(object sender, EventArgs e)
        {
            txtNoStartingFrom.Enabled = !chkIs_continuedNextYear.Checked;
        }

       

       
    }
}
