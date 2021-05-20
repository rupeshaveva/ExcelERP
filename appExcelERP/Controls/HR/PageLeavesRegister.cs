using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.HR;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.MODELS.HR;
using libERP;
using appExcelERP.Forms.HR;

namespace appExcelERP.Controls.HR
{
    public partial class PageLeavesRegister : UserControl
    {

        public int LeaveApplicationID { get; set; }
        private BindingList<LeaveApplicationModel> _LeavesRegisterList = null;
        private BindingList<LeaveApplicationModel> _filteredLeavesRegisterList = null;
        private ServiceLeaveApplication _ServiceLeaves = null;
        public PageLeavesRegister()
        {
            InitializeComponent();
        }
        private void PageLeavesRegister_Load(object sender, EventArgs e)
        {
            try
            {
                // STAR SERVICE WITH EVEN HANDLER
                _ServiceLeaves = new ServiceLeaveApplication();
                _ServiceLeaves.EmployeeRecordCompleted += _ServiceLeaves_EmployeeRecordCompleted;

                btnApproveReject.Visible = false;
                WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.LEAVE_APPLICATIONS).FirstOrDefault();
                if (model.CanApprove)
                    btnApproveReject.Visible = true;

                PopulateLavesGrid();
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::PageLeavesRegister_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ServiceLeaves_EmployeeRecordCompleted(object sender, libERP.MODELS.COMMON.EventArguementModel e)
        {
            try
            {
                hederGroupLeaveRegister.ValuesSecondary.Heading = e.Message;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::_ServiceLeaves_EmployeeRecordCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void PopulateLavesGrid()
        {
            try
            {

                _LeavesRegisterList = AppCommon.ConvertToBindingList<LeaveApplicationModel>(_ServiceLeaves.GetAllLeaveRequestsToAuthority(Program.CURR_USER.EmployeeID, Program.CURR_USER.FinYearID));
                gridLeaveRegister.DataSource = _LeavesRegisterList;

                gridLeaveRegister.Columns["ApplicationID"].Visible =
                gridLeaveRegister.Columns["SearchString"].Visible =
                gridLeaveRegister.Columns["ApplicationNo"].Visible =
                gridLeaveRegister.Columns["ApplicationDate"].Visible =
                gridLeaveRegister.Columns["PreparedByID"].Visible =
                 gridLeaveRegister.Columns["ApprovedByID"].Visible =
                false;
                gridLeaveRegister.Columns["ApplicationNoWithDate"].Width = (int)(gridLeaveRegister.Width * .1);
                gridLeaveRegister.Columns["EmployeeName"].Width = (int)(gridLeaveRegister.Width * .15);
                gridLeaveRegister.Columns["LeaveDescription"].Width = (int)(gridLeaveRegister.Width * .18);
                gridLeaveRegister.Columns["FromDateTime"].HeaderText = "From";
                gridLeaveRegister.Columns["FromDateTime"].Width = (int)(gridLeaveRegister.Width * .07);
                gridLeaveRegister.Columns["FromDateTime"].DefaultCellStyle.Format = "dd MMM hh:mm tt";
                gridLeaveRegister.Columns["ToDateTime"].HeaderText = "Till";
                gridLeaveRegister.Columns["ToDateTime"].DefaultCellStyle.Format = "dd MMM hh:mm tt";
                gridLeaveRegister.Columns["ToDateTime"].Width = (int)(gridLeaveRegister.Width * .07);
                gridLeaveRegister.Columns["Remarks"].Width = (int)(gridLeaveRegister.Width * .15);
                gridLeaveRegister.Columns["ApplicationStatus"].Width = (int)(gridLeaveRegister.Width * .07); 


                gridLeaveRegister.Columns["PreparedByName"].HeaderText = "Prepared By";
                gridLeaveRegister.Columns["PreparedByName"].Width = (int)(gridLeaveRegister.Width * .11);
                gridLeaveRegister.Columns["ApprovedByName"].HeaderText = "Approved By";
                gridLeaveRegister.Columns["ApprovedByName"].Width = (int)(gridLeaveRegister.Width * .08);
                gridLeaveRegister.Columns["Approval_Date"].Visible = true;
                gridLeaveRegister.Columns["Approval_Date"].Width = (int)(gridLeaveRegister.Width * .07);

                gridLeaveRegister.Columns["CreateDateTime"].Visible = false;
                //gridLeaveRegister.Columns["ApplicationID"].Visible = gridLeaveRegister.Columns["SearchString"].Visible = false;
                //gridLeaveRegister.Columns["ApplicationNo"].Width = (int)(gridLeaveRegister.Width * .1);
                //gridLeaveRegister.Columns["ApplicationNoWithDate"].Width = (int)(gridLeaveRegister.Width * .1);
                //gridLeaveRegister.Columns["ApplicationNoWithDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                //gridLeaveRegister.Columns["EmployeeName"].Width = (int)(gridLeaveRegister.Width * .1);
                //gridLeaveRegister.Columns["Status"].Width = (int)(gridLeaveRegister.Width * .1);
                //gridLeaveRegister.Columns["LeaveDescription"].Width = (int)(gridLeaveRegister.Width * .1);
                //gridLeaveRegister.Columns["FromDateTime"].Width = 50;
                //gridLeaveRegister.Columns["FromDateTime"].DefaultCellStyle.Format = "dd MMM yyyy";
                //gridLeaveRegister.Columns["ToDateTime"].DefaultCellStyle.Format = "dd MMM yyyy";
                //gridLeaveRegister.Columns["ToDateTime"].Width = 50;
                //gridLeaveRegister.Columns["Description"].Width = (int)(gridLeaveRegister.Width * .1);
                //gridLeaveRegister.Columns["StatusDescription"].Width = (int)(gridLeaveRegister.Width * .1);

                hederGroupLeaveRegister.ValuesSecondary.Heading = string.Format("{0}Records Found", gridLeaveRegister.Rows.Count);

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::PopulateLavesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridLeaveRegister_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.LeaveApplicationID= (int)(gridLeaveRegister.Rows[e.RowIndex].Cells["ApplicationID"].Value);
                TBL_MP_HR_LeaveApplication model = _ServiceLeaves.GetLeaveApplicationInfoDbRecord(this.LeaveApplicationID);
                if (model.FK_RequestTo == Program.CURR_USER.EmployeeID)
                    btnApproveReject.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                else
                    btnApproveReject.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::gridLeaveRegister_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnApproveReject_Click(object sender, EventArgs e)
        {
            try
            {
                frmApproveRejectLeave frm = new frmApproveRejectLeave(this.LeaveApplicationID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //PopulateLavesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::btnApproveReject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateLavesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchLeaveRegister_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                _filteredLeavesRegisterList = new BindingList<LeaveApplicationModel>(_LeavesRegisterList.Where(p => p.SearchString.Contains(txtSearchLeaveRegister.Text.ToUpper())).ToList());
                gridLeaveRegister.DataSource = _filteredLeavesRegisterList;
                hederGroupLeaveRegister.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridLeaveRegister.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLeavesRegister::txtSearchLeaveRegister_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
    }
}
