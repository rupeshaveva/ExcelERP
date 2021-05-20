using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
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

namespace appExcelERP.Forms.MASTER
{
    public partial class frmAddEditBankBranch : Form
    {
        public int BankBranchID { get; set; }
        public int BankID { get; set; }
        public frmAddEditBankBranch()
        {
            InitializeComponent();
        }
        public frmAddEditBankBranch(int id)
        {
            InitializeComponent();
            BankBranchID = id;
        }

        private void frmAddEditBankBranch_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateBankBranchCountry();
                if (BankBranchID == 0)
                {
                    txtBranchName.Text = txtBankBranchAddress.Text = txtBranchIFSCCode.Text = string.Empty;
                    chkIsActive.Checked = true;
                    int indiaID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.DefaultCountryID).FirstOrDefault().DEFAULT_VALUE;
                    cboBranchCountries.SelectedItem = ((List<SelectListItem>)cboBranchCountries.DataSource).Where(x => x.ID == indiaID).FirstOrDefault();
                    PopulateBankBranchState();
                    if (this.BankID != 0)
                    {
                        TBL_MP_Master_Bank model = (new ServiceBankMaster()).GetBankDbRecord(this.BankID);
                        if (model != null)
                        {
                            this.Text = string.Format("{0} - ADD BRANCH", model.BankName);
                        }
                    }
                }
                else
                {
                    TBL_MP_Master_BankBranch model = (new ServiceBankMaster()).GetBankBranchDbRecord(this.BankBranchID);
                    if (model != null)
                    {
                        txtBranchName.Text = model.BranchName;
                        txtBankBranchAddress.Text = model.BranchAddress;
                        txtBranchIFSCCode.Text = model.IFSCCode;
                        cboBranchCountries.SelectedItem = ((List<SelectListItem>)cboBranchCountries.DataSource).Where(x => x.ID == model.FK_CountryID).FirstOrDefault();
                        PopulateBankBranchState();
                        cboBranchStates.SelectedItem = ((List<SelectListItem>)cboBranchStates.DataSource).Where(x => x.ID == model.FK_StateID).FirstOrDefault();
                        PopulateBankBranchCity();
                        cboBranchCity.SelectedItem = ((List<SelectListItem>)cboBranchCity.DataSource).Where(x => x.ID == model.FK_CityID).FirstOrDefault();
                        chkIsActive.Checked = model.IsActive;
                    }

                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::frmAddEditBankBranch_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_BankBranch model = null;
            ServiceBankMaster _service = new ServiceBankMaster();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.BankBranchID == 0)
                {
                    model = new TBL_MP_Master_BankBranch();
                }   
                else
                    model = _service.GetBankBranchDbRecord(this.BankBranchID);

                model.FK_BankID = this.BankID;
                model.BranchName = txtBranchName.Text;
                model.BranchAddress = txtBankBranchAddress.Text;
                model.FK_CountryID = ((SelectListItem)cboBranchCountries.SelectedItem).ID;
                model.FK_StateID = ((SelectListItem)cboBranchStates.SelectedItem).ID;
                model.FK_CityID = ((SelectListItem)cboBranchCity.SelectedItem).ID;
                model.IsActive = chkIsActive.Checked;
                model.IFSCCode = txtBranchIFSCCode.Text;

                if (this.BankBranchID == 0)
                   this.BankBranchID= _service.AddNewBankBranch(model);
                else
                    _service.UpdateBankBranch(model);

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region POPULATE DROPDOWN
        public void PopulateBankBranchCountry()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllCountries());
                cboBranchCountries.DataSource = LST;
                cboBranchCountries.DisplayMember = "Description";
                cboBranchCountries.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::PopulateBankBranchCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateBankBranchState()
        {
            try
            {

                int countryID = ((SelectListItem)cboBranchCountries.SelectedItem).ID;
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllStatesForCountry(countryID));
                cboBranchStates.DataSource = LST;
                cboBranchStates.DisplayMember = "Description";
                cboBranchStates.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::PopulateBankBranchState", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateBankBranchCity()
        {
            try
            {
                int stateID = ((SelectListItem)cboBranchStates.SelectedItem).ID;
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllCitiesForState(stateID));
                cboBranchCity.DataSource = LST;
                cboBranchCity.DisplayMember = "Description";
                cboBranchCity.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::PopulateBankBranchCity", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboBranchCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PopulateBankBranchState();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::cboBranchCountries_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboBranchStates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PopulateBankBranchCity();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::cboBranchStates_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
         #endregion
       
        #region validations
         private void txtBranchName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtBranchName.Text == string.Empty)
                {
                    errorProvider1.SetError(txtBranchName, "Branch Name mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::txtBranchName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtBankBranchAddress_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtBankBranchAddress.Text == string.Empty)
                {
                    errorProvider1.SetError(txtBankBranchAddress, "Branch Address mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::txtBankBranchAddress_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboBranchCountries_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBranchCountries.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBranchCountries, "branch country mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::cboBranchCountries_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        }
        private void cboBranchStates_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBranchStates.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBranchStates, "branch state mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::cboBranchStates_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboBranchCity_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBranchCity.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBranchCity, "branch country mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBankBranch::cboBranchCity_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
