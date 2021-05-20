using libERP;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.HR
{
    public partial class frmAddEditLoanDisbursement : Form
    {
        public int SelectedLoanDisbursementID { get; set; }
        public int EmployeeID { get; set; }
        public frmAddEditLoanDisbursement()
        {
            InitializeComponent();
        }

        public frmAddEditLoanDisbursement(int ID)
        {
            InitializeComponent();
            SelectedLoanDisbursementID = ID;
        }

        private void frmAddEditLoanDisbursement_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateLoanDropdown();
                PopulatePreparedByDropdown();
                PopulateRequestToDropdown();
                if (this.SelectedLoanDisbursementID == 0)
                {
                    dtLoanDisbursementDate.Value = dtDeductionFromDate.Value = AppCommon.GetServerDateTime();

                }
                else
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::frmAddEditLoanDisbursement_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateLoanDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceLoanRequest()).GetAllApprovedLoanRequests());
                cboLoanRequests.DataSource = LST;
                cboLoanRequests.DisplayMember = "Description";
                cboLoanRequests.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::PopulateLoanDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulatePreparedByDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllEmployees());
                cboPreparedBy.DataSource = LST;
                cboPreparedBy.DisplayMember = "Description";
                cboPreparedBy.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::PopulatePreparedByDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateRequestToDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllEmployees());
                cboRequestTo.DataSource = LST;
                cboRequestTo.DisplayMember = "Description";
                cboRequestTo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::PopulateRequestToDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ScatterData()
        {
            ServiceLoanDisbursement _service = new ServiceLoanDisbursement();
            try
            {
                TBL_MP_HR_LoanDisbursement model = _service.GetLoanDisbursementInfoDbRecord(this.SelectedLoanDisbursementID);
                if (model != null)
                {
                    dtLoanDisbursementDate.Value = model.DisbursementDate;
                    cboLoanRequests.SelectedItem = ((List<SelectListItem>)cboLoanRequests.DataSource).Where(x => x.ID == model.FK_LoanRequestID).FirstOrDefault();
                    txtLoanAmount.Text = string.Format("{0:0.00}", model.LoanAmount);
                    txtInterestRate.Text = string.Format("{0:0.00}", model.InterestRate);
                    txttotalEMI.Text = model.NoOfInstallment.ToString();
                    TxtEMIAmount.Text = string.Format("{0:0.00}", model.InstallmentAmount);
                    dtDeductionFromDate.Value = model.InstallmentStartDate;
                    cboPreparedBy.SelectedItem = ((List<SelectListItem>)cboPreparedBy.DataSource).Where(x => x.ID == model.FK_PreparedBy).FirstOrDefault();
                    cboRequestTo.SelectedItem = ((List<SelectListItem>)cboRequestTo.DataSource).Where(x => x.ID == model.FK_ApprovedBy).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CalculateSimpleInterest()
        {
            try
            {
                decimal P = 0; decimal R = 0; decimal T = 0;
                decimal.TryParse(txtLoanAmount.Text.Trim(), out P);
                decimal.TryParse(txtInterestRate.Text.Trim(), out R);
                R = (R / 100) / 12;
                decimal.TryParse(txttotalEMI.Text.Trim(), out T);
                decimal SI = (P * R * T);
                decimal EMI = (P + SI) / T;
                txtTotalAmount.Text = string.Format("{0:0.00}", P + SI);
                TxtEMIAmount.Text = string.Format("{0:0.00}", EMI);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::CalculateSimpleInterest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboLoanRequests_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLoanRequests.SelectedItem != null)
                {
                    SelectListItem selLoan = (SelectListItem)cboLoanRequests.SelectedItem;
                    if (selLoan.ID > 0)
                    {
                        TBL_MP_HR_LoanRequestApplication loan = (new ServiceLoanRequest()).GetLoanRequestInfoDbRecord(selLoan.ID);
                        if (loan != null)
                        {
                            this.EmployeeID = loan.FK_EmployeeID;
                            txtEmployeeInfo.Text = (new ServiceEmployee()).GetEmployeeCompleteDescription(this.EmployeeID);
                            txtLoanAmount.Text = string.Format("{0:0.00}", loan.RequestedLoanAmount);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::cboLoanRequests_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateSimpleInterest();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::txtLoanAmount_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtInterestRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateSimpleInterest();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::txtInterestRate_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txttotalEMI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateSimpleInterest();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::txttotalEMI_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            TBL_MP_HR_LoanDisbursement model = null;

            ServiceLoanDisbursement service = new ServiceLoanDisbursement();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.SelectedLoanDisbursementID == 0)
                    model = new TBL_MP_HR_LoanDisbursement();
                else
                    model = service.GetLoanDisbursementInfoDbRecord(this.SelectedLoanDisbursementID);

                #region GATHER DATA INTO MODEL FROM VIEW

                model.DisbursementDate = dtLoanDisbursementDate.Value;
                model.FK_LoanRequestID = ((SelectListItem)cboLoanRequests.SelectedItem).ID;
                model.FK_EmployeeID = this.EmployeeID;
                model.LoanAmount = decimal.Parse(txtLoanAmount.Text.Trim());
                model.InterestRate = decimal.Parse(txtInterestRate.Text.Trim());
                model.NoOfInstallment = int.Parse(txttotalEMI.Text.Trim());
                model.InstallmentAmount = decimal.Parse(TxtEMIAmount.Text.Trim());
                model.InstallmentStartDate = dtDeductionFromDate.Value;
                model.FK_PreparedBy = ((SelectListItem)cboPreparedBy.SelectedItem).ID;
                model.FK_ApprovedBy = ((SelectListItem)cboRequestTo.SelectedItem).ID;
                model.Remarks = txtRemarks.Text.Trim();

                #endregion
                if (this.SelectedLoanDisbursementID == 0)
                {
                    model.FK_YearID = Program.CURR_USER.FinYearID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;

                    this.SelectedLoanDisbursementID = service.AddNewLoanDisbursement(model);
                }
                else
                    service.UpdateLoanDisbursement(model);

                this.DialogResult = DialogResult.OK;
            }

            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
        #region validations
        private void txtInterestRate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtInterestRate.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtInterestRate, "Enter Interest Rate");
                    e.Cancel = true;
                }
                int rate = 0;
                int.TryParse(txtInterestRate.Text.Trim(), out rate);
                txtInterestRate.Text = string.Format("{0:0.00}",rate);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::txtInterestRate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txttotalEMI_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txttotalEMI.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txttotalEMI, "Enter Total E.M.I");
                    e.Cancel = true;
                }
                int totEMIs = 0;
                int.TryParse(txttotalEMI.Text.Trim(), out totEMIs);
                if (totEMIs == 0)
                {
                    errorProvider1.SetError(txttotalEMI, "Enter Valid No. of EMIs");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::txttotalEMI_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboRequestTo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboRequestTo.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboRequestTo, "mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::cboRequestTo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboPreparedBy_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboPreparedBy.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboPreparedBy, "mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanDisbursement::cboPreparedBy_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        
    }
 }
