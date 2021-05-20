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
    public partial class frmAddEditAdvanceRequest : Form
    {
        public int AdvanceRequestID { get; set; }
        public int EmployeeID { get; set; }

        public frmAddEditAdvanceRequest()
        {
            InitializeComponent();
        }
        public frmAddEditAdvanceRequest(int appicationID)
        {
            InitializeComponent();
            this.AdvanceRequestID = appicationID;
        }
        private void frmAddEditAdvanceRequest_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployeeDropdown();
                PopulateRequestToDropdown();
                if (this.AdvanceRequestID == 0)
                {
                    if (this.EmployeeID != 0)
                    {
                        cboEmployees.SelectedItem = ((List<SelectListItem>)cboEmployees.DataSource).Where(x => x.ID == EmployeeID).FirstOrDefault();
                    }
                    txtAdvanceRequestNo.Text = (new ServiceAdvanceRequest()).GenerateNewAdvanceRequestNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                    dtRequestDate.Value = dtExpectedDate.Value = AppCommon.GetServerDateTime();
                    txtRequestedAmount.Text = "0.00";
                }
                else
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::frmAddEditAdvanceRequest_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::PopulateEmployeeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::PopulateRequestToDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ScatterData()
        {
            ServiceAdvanceRequest _service = new ServiceAdvanceRequest();
            try
            {
                TBL_MP_HR_AdvanceRequestApplication model = _service.GetAdvanceRequestInfoDbRecord(this.AdvanceRequestID);
                if (model != null)
                {
                    txtAdvanceRequestNo.Text = model.AdvanceRequestNo;
                    dtRequestDate.Value = model.RequestDate;
                    cboEmployees.SelectedItem = ((List<SelectListItem>)cboEmployees.DataSource).Where(x => x.ID == model.FK_EmployeeID).FirstOrDefault();
                    cboRequestTo.SelectedItem = ((List<SelectListItem>)cboRequestTo.DataSource).Where(x => x.ID == model.FK_RequestTo).FirstOrDefault();
                    txtRemarks.Text = model.Remarks;
                    txtRequestedAmount.Text = model.RequestedAmount.ToString();
                    if(model.ExpectedDate!=null)
                        dtExpectedDate.Value = (DateTime)model.ExpectedDate;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            TBL_MP_HR_AdvanceRequestApplication model = null;

            ServiceAdvanceRequest service = new ServiceAdvanceRequest();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.AdvanceRequestID == 0)
                    model = new TBL_MP_HR_AdvanceRequestApplication();
                else
                    model = service.GetAdvanceRequestInfoDbRecord(this.AdvanceRequestID);

                #region GATHER DATA INTO MODEL FROM VIEW

                model.AdvanceRequestNo = txtAdvanceRequestNo.Text.Trim();
                model.RequestDate= dtRequestDate.Value;
                model.ExpectedDate = dtExpectedDate.Value;
                model.FK_EmployeeID = ((SelectListItem)cboEmployees.SelectedItem).ID;
                model.FK_RequestTo = ((SelectListItem)cboRequestTo.SelectedItem).ID;
                model.RequestedAmount=decimal.Parse(txtRequestedAmount.Text.Trim());
                model.Remarks = txtRemarks.Text.Trim();

                #endregion
                if (this.AdvanceRequestID == 0)
                {
                    model.Fk_YearID = Program.CURR_USER.FinYearID;
                    model.Fk_BranchID = Program.CURR_USER.BranchID;
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;

                    this.AdvanceRequestID = service.AddNewAdvanceRequest(model);
                }
                else
                    service.UpdateAdvanceRequest(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region VALIDATIONS
        private void txtAdvanceRequestNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtAdvanceRequestNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtAdvanceRequestNo, "Request Number Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::txtAdvanceRequestNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::cboEmployees_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtRequestedAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtRequestedAmount.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRequestedAmount, "Requested Amount Mandatory");
                    e.Cancel = true;
                    return;
                }
                decimal amt = 0;
                decimal.TryParse(txtRequestedAmount.Text.Trim(), out amt);
                if (amt == 0)
                {
                    errorProvider1.SetError(txtRequestedAmount, "Invalid Amount");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::txtRequestedAmount_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::txtRemarks_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditAdvanceRequest::cboRequestTo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
    }
}
