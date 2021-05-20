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
using libERP.MODELS.HR;
using libERP.SERVICES.HR;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeBankInfo : UserControl
    {
        public int SelectedEmployeeID { get; set; }
        public int SelectedBankID { get; set; }
        public ControlEmployeeBankInfo()
        {
            InitializeComponent();
        }
        
        private void ControlEmployeeBankInfo_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateBankDropdown();
                PopulateBankAccountTypeDropdown();
                PopulatePaymentModeDropdown();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::ControlEmployeeBankInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetReadOnly()
        {
            try
            {
                btnUpdateBankDetails.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region POPULATE DROPDOWNS
        private void PopulateBankDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceBankMaster()).GetAllBanks());
                cboBank.DataSource = lst;
                cboBank.DisplayMember = "Description";
                cboBank.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::PopulateBankDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBranchDropdown()
        {
            try
            {
                int bankID = ((SelectListItem)cboBank.SelectedItem).ID;
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceBankMaster()).GetAllActiveBankBranchesForSelection(bankID));
                cboBankBranch.DataSource = lst;
                cboBankBranch.DisplayMember = "Description";
                cboBankBranch.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::PopulateBranchDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::PopulateBankAccountTypeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulatePaymentModeDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllModeOfSalaryPayment());
                cboModeOfSalaryPayment.DataSource = lst;
                cboModeOfSalaryPayment.DisplayMember = "Description";
                cboModeOfSalaryPayment.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::PopulatePaymentModeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VALIDATION
        private void cboBank_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBank.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblBankName, " Bank Name mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::cboBank_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboAccountType_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (((SelectListItem)cboAccountType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblAccountType, " Bank Account Type mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::cboAccountType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (txtAccountNo.Text == string.Empty)
                {
                    errorProvider1.SetError(lblAccountNo, "Bank Account Number mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::txtAccountNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtPFNo_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtESICNo_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (txtESICNo.Text == string.Empty)
                {
                    errorProvider1.SetError(lblESICNo, " ESIC Number mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::txtESICNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtPANNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtPANNo.Text == string.Empty)
                {
                    errorProvider1.SetError(lblPANNo, " PAN Number mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::txtPANNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtUANNo_Validating(object sender, CancelEventArgs e)
        {

        }
        private void cboModeOfSalaryPayment_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboModeOfSalaryPayment.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblModeOfSalaryPayment, " Mode Of Salary Payment mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::cboModeOfSalaryPayment_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
         #endregion
        public void PopulateEmployeeBankInfo()
        {
            try
            {
                EmployeeBankInfoModel model= (new ServiceEmployee()).GetEmployeeBankInfo(this.SelectedEmployeeID);
                if (model != null)
                {
                    cboBank.SelectedItem = ((List<SelectListItem>)cboBank.DataSource).Where(x => x.ID == model.BankInfo.ID).FirstOrDefault();
                    PopulateBranchDropdown();// as branches dropdown need to be populated for the changed BankID
                    cboBankBranch.SelectedItem = ((List<SelectListItem>)cboBankBranch.DataSource).Where(x => x.ID == model.BankBranchInfo.ID).FirstOrDefault();
                    // Rest all dropdowns are populated while load..so need not to populate them again
                    cboAccountType.SelectedItem = ((List<SelectListItem>)cboAccountType.DataSource).Where(x => x.ID == model.BankAccountType.ID).FirstOrDefault();
                    cboModeOfSalaryPayment.SelectedItem = ((List<SelectListItem>)cboModeOfSalaryPayment.DataSource).Where(x => x.ID == model.PaymentModeType.ID).FirstOrDefault();
                    // rest all are simpel datatypes..you can do them...continue
                    txtAccountNo.Text = model.AccountNo;
                    txtAtmCardNo.Text = model.DebitCardNo;
                    txtCreditCardNo.Text = model.CreditCardNo;
                    txtPFNo.Text = model.PFNumber;
                    txtESICNo.Text = model.ESICNumber;
                    txtPANNo.Text = model.PANNumber;
                    txtUANNo.Text = model.UANNumber;
                    if (model.LastCheckUpDate == null)
                        dtLastMedicalCheckUpDate.Checked = true;
                    else
                        dtLastMedicalCheckUpDate.Value=(DateTime)model.LastCheckUpDate;
                    if (model.NextCheckUpDate == null)
                        dtNextMedicalCheckUpDate.Checked = true;
                    else
                        dtNextMedicalCheckUpDate.Value = (DateTime)model.NextCheckUpDate;

                    // you still have issues in managinig null values & setting dropdown values....
                    //focus on this....contime

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::PopulateEmployeeBankInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateBranchDropdown();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::cboBank_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnUpdateBankDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren()) return;

                EmployeeBankInfoModel model = (new ServiceEmployee()).GetEmployeeBankInfo(this.SelectedEmployeeID);
                if (model != null)
                {
                    model.BankInfo.ID = ((SelectListItem)cboBank.SelectedItem).ID;
                    model.BankBranchInfo.ID = ((SelectListItem)cboBankBranch.SelectedItem).ID;
                    model.BankAccountType.ID = ((SelectListItem)cboAccountType.SelectedItem).ID;
                    model.PaymentModeType.ID = ((SelectListItem)cboModeOfSalaryPayment.SelectedItem).ID;
                    model.AccountNo = txtAccountNo.Text.Trim();
                    model.DebitCardNo = txtAtmCardNo.Text.Trim();
                    model.CreditCardNo = txtCreditCardNo.Text.Trim();
                    model.PFNumber = txtPFNo.Text.Trim();
                    model.ESICNumber = txtESICNo.Text.Trim();
                    model.PANNumber = txtPANNo.Text.Trim();
                    model.UANNumber = txtUANNo.Text.Trim();

                    if (dtLastMedicalCheckUpDate.Checked)
                        model.LastCheckUpDate = null;
                    else
                        model.LastCheckUpDate = dtLastMedicalCheckUpDate.Value;

                    if (dtNextMedicalCheckUpDate.Checked)
                        model.NextCheckUpDate= null;
                    else
                        model.NextCheckUpDate = dtNextMedicalCheckUpDate.Value;



                    bool result=(new ServiceEmployee()).SetEmployeeBankInfo(model);
                    if (result)
                        MessageBox.Show("Employee Bank Details Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeBankInfo::btnUpdateBankDetails_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
