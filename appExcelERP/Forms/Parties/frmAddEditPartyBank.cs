using appExcelERP.Forms.MASTER;
using ComponentFactory.Krypton.Toolkit;
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

namespace appExcelERP.Forms.Parties
{
    public partial class frmAddEditPartyBank : KryptonForm
    {
        public string SelectedPartyType { get; set; }
        public int SelectedPartyBankID { get; set; }
        public int SelectedPartyID { get; set; }

        public frmAddEditPartyBank()
        {
            InitializeComponent();
        }
        public frmAddEditPartyBank(int partybankID)
        {
            InitializeComponent();
            this.SelectedPartyBankID = partybankID;
        }

        private void frmAddEditPartyBank_Load(object sender, EventArgs e)
        {
            try
            {
                PopulatePartiesDropdown();
                PopulateBanksDropdown();
                PopulateBankAccountTypeDropdown();
                if (this.SelectedPartyBankID == 0)
                {
                    if (this.SelectedPartyID != 0)
                    {
                        cboParties.SelectedItem = ((List<SelectListItem>)cboParties.DataSource).Where(x => x.ID == this.SelectedPartyID).FirstOrDefault();
                    }
                    txtAccountNo.Text = string.Empty;
                    chkIsActive.Checked = true;
                }
                else
                {
                    ScatterData();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::frmAddEditPartyBank_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ScatterData()
        {
            try
            {
                Tbl_MP_Master_Party_BankDetail model = (new ServiceParties()).GetPartyBankDBRecordByPartyBankID(this.SelectedPartyBankID);
                if(model!=null)
                {
                    // you ahve to search for item from the combo and set it as selected...contine
                    cboParties.SelectedItem = ((List<SelectListItem>)cboParties.DataSource).Where(x => x.ID == model.FK_PartyID).FirstOrDefault();
                    cboBankName.SelectedItem = ((List<SelectListItem>)cboBankName.DataSource).Where(x => x.ID == model.FK_BankID).FirstOrDefault();
                    cboBankBranchName.SelectedItem = ((List<SelectListItem>)cboBankBranchName.DataSource).Where(x => x.ID == model.FK_BankBranchID).FirstOrDefault();
                    cboAccountType.SelectedItem = ((List<SelectListItem>)cboAccountType.DataSource).Where(x => x.ID == model.FK_AccountType).FirstOrDefault();
                    txtAccountNo.Text = model.AccountNo;
                    chkIsActive.Checked = model.IsActive;

                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region POPULATE DROPDOWNS
        private void PopulatePartiesDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceParties()).GetAllParties(SelectedPartyType));
                cboParties.DataSource = lst;
                cboParties.DisplayMember = "Description";
                cboParties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::PopulatePartiesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBankAccountTypeDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllBankAccountTypes());
                cboAccountType.DataSource = lst;
                cboAccountType.DisplayMember = "Description";
                cboAccountType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::PopulateBankAccountTypeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBanksDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceBankMaster()).GetAllActiveBanks());
                cboBankName.DataSource = lst;
                cboBankName.DisplayMember = "Description";
                cboBankName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::PopulateBanksDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBankBranchesDropdown()
        {
            try
            {
                int bankID = ((SelectListItem)cboBankName.SelectedItem).ID;
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceBankMaster()).GetAllActiveBankBranchesForSelection(bankID));
                cboBankBranchName.DataSource = lst;
                cboBankBranchName.DisplayMember = "Description";
                cboBankBranchName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::PopulateBankBranchesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void cboBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateBankBranchesDropdown();
            }
            catch (Exception ex)
            {


                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::cboBankName_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewBank_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditBank frm = new frmAddEditBank();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBanksDropdown();
                    cboBankName.SelectedItem = ((List<SelectListItem>)cboBankName.DataSource).Where(x => x.ID == frm.SelectedBankID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::btnAddNewBank_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewBankBranch_Click(object sender, EventArgs e)
        {
            try
            {
                int bankId = ((SelectListItem)cboBankName.SelectedItem).ID;
                frmAddEditBankBranch frm = new frmAddEditBankBranch();
                frm.BankID = bankId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBankBranchesDropdown();
                    cboBankBranchName.SelectedItem = ((List<SelectListItem>)cboBankBranchName.DataSource).Where(x => x.ID == frm.BankBranchID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::btnAddNewBranch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        #region VALIDATION
        private void cboBankName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBankName.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBankName, " Bank Name mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::cboBankName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboBankBranchName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBankBranchName.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBankBranchName, " Bank  Branch Name mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::cboBankBranchName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboAccountType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboAccountType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboAccountType, " Account Type mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::cboAccountType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtAccountNo.Text == string.Empty)
                {
                    errorProvider1.SetError(txtAccountNo, "Bank name mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBank::txtAccountNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            Tbl_MP_Master_Party_BankDetail model = null;
            try
            {
                if (!this.ValidateChildren()) return;

                if (this.SelectedPartyBankID == 0)
                    model = new Tbl_MP_Master_Party_BankDetail();
                else
                    model = (new ServiceParties()).GetPartyBankDBRecordByPartyBankID(this.SelectedPartyBankID);

                //populate model from control
                model.FK_PartyID = ((SelectListItem)cboParties.SelectedItem).ID;
                model.FK_BankID = ((SelectListItem)cboBankName.SelectedItem).ID;
                model.FK_BankBranchID = ((SelectListItem)cboBankBranchName.SelectedItem).ID;
                model.FK_AccountType = ((SelectListItem)cboAccountType.SelectedItem).ID;
                model.AccountNo = txtAccountNo.Text.Trim();
                model.IsActive = chkIsActive.Checked;


                if (this.SelectedPartyBankID == 0)
                    this.SelectedPartyBankID= (new ServiceParties()).AddNewPartyBankDetail(model);
                else
                    (new ServiceParties()).UpdatePartyBankDetail(model);

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPartyBank::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
