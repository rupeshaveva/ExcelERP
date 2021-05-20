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
    public partial class frmApproveRejectAdvanceRequest : Form
    {
        public int AdvanceRequestID { get; set; }
        public frmApproveRejectAdvanceRequest()
        {
            InitializeComponent();
        }
        public frmApproveRejectAdvanceRequest(int ID)
        {
            InitializeComponent();
            AdvanceRequestID = ID;
        }

        private void frmApproveRejectAdvanceRequest_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceAdvanceRequest service = new ServiceAdvanceRequest();
                vAdvanceRequestApplication model = service.GetAdvanceRequestViewDbRecord(this.AdvanceRequestID);
                if (model != null)
                {
                    txtAdvanceRequestNo.Text = string.Format("{0} dt. {1}", model.AdvanceRequestNo, model.RequestDate.ToString("dd MMM yy"));
                    dtApprovalDate.Value = model.RequestDate;
                    txtAdvanceRequestDescription.Text = model.EmployeeName;
                    txtAdvanceRequestDescription.Text += string.Format("\nAmount: {0:0.00}\nRemarks: {1}", model.RequestedAmount, model.Remarks);

                    if (model.ApprovalStatus == service.REQUEST_STATUS_APPROVED_ID) rbtnApproveAdvanceRequest.Checked = true;
                    if (model.ApprovalStatus == service.REQUEST_STATUS_REJECTED_ID) rbtnRejectAdvanceRequest.Checked = true;

                    txtApprovedAmount.Text = model.ApprovedAmount.ToString();
                    txtApprovalRemarks.Text = model.RemarksApproved;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectAdvanceRequest::frmApproveRejectAdvanceRequest_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                errorProvider1.Clear();
                if (!this.ValidateChildren()) return;
                ServiceAdvanceRequest service = new ServiceAdvanceRequest();
                TBL_MP_HR_AdvanceRequestApplication model = service.GetAdvanceRequestInfoDbRecord(this.AdvanceRequestID);
                if (model != null)
                {
                    model.RemarksApproved = txtApprovalRemarks.Text.Trim();
                    model.FK_ApprovedBy = Program.CURR_USER.EmployeeID;
                    if (rbtnApproveAdvanceRequest.Checked) model.ApprovalStatus = service.REQUEST_STATUS_APPROVED_ID;
                    if (rbtnRejectAdvanceRequest.Checked) model.ApprovalStatus = service.REQUEST_STATUS_REJECTED_ID;
                    model.ApprovalDate = dtApprovalDate.Value;
                    model.ApprovedAmount = decimal.Parse(txtApprovedAmount.Text.Trim());
                    // put validation on this 
                    service.UpdateAdvanceRequest(model);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectAdvanceRequest::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmApproveRejectAdvanceRequest::txtApprovedAmount_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
