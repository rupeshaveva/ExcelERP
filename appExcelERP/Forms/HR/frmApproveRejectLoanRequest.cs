using libERP;
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
    //continue
    public partial class frmApproveRejectLoanRequest : Form
    {
        public int LoanRequestID { get; set; }
        public frmApproveRejectLoanRequest()
        {
            InitializeComponent();
        }
        public frmApproveRejectLoanRequest(int ID)
        {
            InitializeComponent();
            LoanRequestID = ID;
        }

        private void frmApproveRejectLoanRequest_Load(object sender, EventArgs e)
        {
            // try getting edmx again for view 
            try
            {
                ServiceLoanRequest service = new ServiceLoanRequest();
                vLoanRequestApplication model = service.GetLoanRequestViewDbRecord(this.LoanRequestID);
                if (model != null)
                {
                    txtLoanRequestNo.Text = string.Format("{0} dt. {1}", model.LoanRequestNo, model.LoanRequestDate.Value.ToString("dd MMM yy"));
                    dtApprovalDate.Value = (DateTime)model.LoanRequestDate;
                    txtLoanRequestDescription.Text = model.EmployeeName;
                    txtLoanRequestDescription.Text += string.Format("\nAmount: {0:0.00}\nRemarks: {1}", model.RequestedLoanAmount, model.Remarks);

                    if (model.ApprovalStatus == service.REQUEST_STATUS_APPROVED_ID) rbtnApproveLoanRequest.Checked = true;
                    if (model.ApprovalStatus == service.REQUEST_STATUS_REJECTED_ID) rbtnRejectLoanRequest.Checked = true;

                    txtApprovedAmount.Text = model.ApprovedAmount.ToString();
                    txtApprovalRemarks.Text = model.RemarksApproved;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectLoanRequest::frmApproveRejectLoanRequest_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                errorProvider1.Clear();
                if (!this.ValidateChildren()) return;
                ServiceLoanRequest service = new ServiceLoanRequest();
                TBL_MP_HR_LoanRequestApplication model = service.GetLoanRequestInfoDbRecord(this.LoanRequestID);
                if (model != null)
                {
                    model.RemarksApproved = txtApprovalRemarks.Text.Trim();
                    model.FK_ApprovedBy = Program.CURR_USER.EmployeeID;
                    if (rbtnApproveLoanRequest.Checked) model.ApprovalStatus = service.REQUEST_STATUS_APPROVED_ID;
                    if (rbtnRejectLoanRequest.Checked) model.ApprovalStatus = service.REQUEST_STATUS_REJECTED_ID;
                    model.ApprovalDate = dtApprovalDate.Value;
                    model.ApprovedAmount = decimal.Parse(txtApprovedAmount.Text.Trim());
                    // put validation on this 
                    service.UpdateLoanRequest(model);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectLoanRequest::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtApprovedAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtApprovedAmount.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtApprovedAmount, "Approved Amount Mandatory");
                    e.Cancel = true;
                    return;
                }
                decimal amt = 0;
                decimal.TryParse(txtApprovedAmount.Text.Trim(), out amt);
                if (amt == 0)
                {
                    errorProvider1.SetError(txtApprovedAmount, "Invalid Amount");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectLoanRequest::txtApprovedAmount_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
