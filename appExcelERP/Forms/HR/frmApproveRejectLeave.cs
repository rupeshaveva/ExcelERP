using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP;
using libERP;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;

namespace appExcelERP.Forms.HR
{
    public partial class frmApproveRejectLeave : Form
    {
        public int ApplicationID { get; set; }

        public frmApproveRejectLeave(int appliationID)
        {
            InitializeComponent();
            ApplicationID = appliationID;
        }

        private void frmApproveRejectLeave_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceLeaveApplication service = new ServiceLeaveApplication();
                TBL_MP_HR_LeaveApplication model = service.GetLeaveApplicationInfoDbRecord(this.ApplicationID);
                if (model != null)
                {
                    txtLeaveApplicationNo.Text = model.ApplicationNo;
                    dtLeaveApplicationDate.Value = model.ApplicationDate;

                    txtLeaveDescription.Text = string.Format("{0} {1}", model.TBL_MP_Master_Employee.EmployeeName, model.TBL_MP_Master_Employee.EmployeeCode);
                    txtLeaveDescription.Text += string.Format("\n{0}   From: {1}{2} To: {3}{4}",
                        model.TBL_MP_Admin_UserList.Admin_UserList_Desc.ToUpper(),
                        model.FromDate.ToString("ddMMMyy"), model.FromTime.Value.ToString("hh:mmtt"),
                        model.ToDate.ToString("ddMMMyy"), model.ToTime.Value.ToString("hh:mmtt"));
                    txtLeaveDescription.Text += string.Format("\n{0}", model.Remarks);
                    if (model.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_APPROVED_ID) rbtnApproveLeave.Checked = true;
                    if (model.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_REJECTED_ID) rbtnRejectLeave.Checked = true;

                    txtApprovalRemarks.Text = model.RemarksApproval;
                }
            }
            catch (Exception ex) 
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectLeave::frmApproveRejectLeave_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ServiceLeaveApplication service = new ServiceLeaveApplication();
                TBL_MP_HR_LeaveApplication model = service.GetLeaveApplicationInfoDbRecord(this.ApplicationID);
                if (model != null)
                {
                    model.RemarksApproval = txtApprovalRemarks.Text.Trim();
                    model.FK_ApprovedBy = Program.CURR_USER.EmployeeID;
                    model.Approval_Date = AppCommon.GetServerDateTime();
                    if (rbtnApproveLeave.Checked) model.FK_UserList_ApprovalStatusID = service.LEAVE_STATUS_APPROVED_ID;
                    if (rbtnRejectLeave.Checked) model.FK_UserList_ApprovalStatusID = service.LEAVE_STATUS_REJECTED_ID;

                    if (model.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_REJECTED_ID)
                    {
                        service.RejectAttendanceForLeave(ApplicationID);
                    }
                    service.UpdateLeaveApplicationInfo(model);
                    if (model.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_APPROVED_ID)
                    {
                        service.ApproveAttendanceForLeave(ApplicationID);
                    }
                    
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmApproveRejectLeave::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
