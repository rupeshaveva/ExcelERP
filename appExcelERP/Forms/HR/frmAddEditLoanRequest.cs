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
    public partial class frmAddEditLoanRequest : Form
    {
        public int LoanRequestID { get; set; }
        public int EmployeeID { get; set; }
        public frmAddEditLoanRequest()
        {
            InitializeComponent();
        }
        public frmAddEditLoanRequest(int id)
        {
            InitializeComponent();
            LoanRequestID = id;
        }

        private void frmAddEditLoanRequest_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployeeDropdown();
                PopulateRequestToDropdown();
                if (this.LoanRequestID == 0)
                {
                    if (this.EmployeeID != 0)
                    {
                        cboEmployees.SelectedItem = ((List<SelectListItem>)cboEmployees.DataSource).Where(x => x.ID == EmployeeID).FirstOrDefault();
                    }
                    txtLoanRequestNo.Text = (new ServiceLoanRequest()).GenerateNewLoanRequestNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                    dtLoanRequestDate.Value = dtDisbursementDate.Value = AppCommon.GetServerDateTime();
                    txtRequestedLoanAmount.Text = "0.00";
                }
                else
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::frmAddEditLoanRequest_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateEmployeeDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllEmployees());
                cboEmployees.DataSource = LST;
                cboEmployees.DisplayMember = "Description";
                cboEmployees.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::PopulateEmployeeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::PopulateRequestToDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ScatterData()
        {
            ServiceLoanRequest _service = new ServiceLoanRequest();
            try
            {
                TBL_MP_HR_LoanRequestApplication model = _service.GetLoanRequestInfoDbRecord(this.LoanRequestID);
                if (model != null)
                {
                    txtLoanRequestNo.Text = model.LoanRequestNo;
                    dtLoanRequestDate.Value = model.LoanRequestDate;
                    cboEmployees.SelectedItem = ((List<SelectListItem>)cboEmployees.DataSource).Where(x => x.ID == model.FK_EmployeeID).FirstOrDefault();
                    cboRequestTo.SelectedItem = ((List<SelectListItem>)cboRequestTo.DataSource).Where(x => x.ID == model.RequestTo).FirstOrDefault();
                    txtRemarks.Text = model.Remarks;
                    txtRequestedLoanAmount.Text = model.RequestedLoanAmount.ToString();
                    if (model.ProposedDisbursementDate != null)
                        dtDisbursementDate.Value = (DateTime)model.ProposedDisbursementDate;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            TBL_MP_HR_LoanRequestApplication model = null;

            ServiceLoanRequest service = new ServiceLoanRequest();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.LoanRequestID == 0)
                    model = new TBL_MP_HR_LoanRequestApplication();
                else
                    model = service.GetLoanRequestInfoDbRecord(this.LoanRequestID);

                #region GATHER DATA INTO MODEL FROM VIEW

                model.LoanRequestNo = txtLoanRequestNo.Text.Trim();
                model.LoanRequestDate = dtLoanRequestDate.Value;
                model.ProposedDisbursementDate = dtDisbursementDate.Value;
                model.FK_EmployeeID = ((SelectListItem)cboEmployees.SelectedItem).ID;
                model.RequestTo = ((SelectListItem)cboRequestTo.SelectedItem).ID;
                model.RequestedLoanAmount = decimal.Parse(txtRequestedLoanAmount.Text.Trim());
                model.Remarks = txtRemarks.Text.Trim();

                #endregion
                if (this.LoanRequestID == 0)
                {
                    model.FK_YearID = Program.CURR_USER.FinYearID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;

                    this.LoanRequestID = service.AddNewLoanRequest(model);
                }
                else
                    service.UpdateLoanRequest(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        #region VALIDATIONS
        private void txtLoanRequestNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtLoanRequestNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtLoanRequestNo, "Request Number Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::txtLoanRequestNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEmployees_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (((SelectListItem)cboEmployees.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEmployees, "Select Employee");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::cboEmployees_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtRequestedLoanAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtRequestedLoanAmount.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRequestedLoanAmount, "Requested Loan Amount Mandatory");
                    e.Cancel = true;
                    return;
                }
                decimal amt = 0;
                decimal.TryParse(txtRequestedLoanAmount.Text.Trim(), out amt);
                if (amt == 0)
                {
                    errorProvider1.SetError(txtRequestedLoanAmount, "Invalid Amount");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::txtRequestedLoanAmount_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtRemarks.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRemarks, "Remarks Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::txtRemarks_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRequestTo_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (((SelectListItem)cboRequestTo.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboRequestTo, "Select Request to");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLoanRequest::cboRequestTo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion
    }
}
