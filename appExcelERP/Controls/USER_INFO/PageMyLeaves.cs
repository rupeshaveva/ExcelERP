using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.HR;
using appExcelERP.Forms.HR;
using libERP.SERVICES.HR;
using libERP;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.USER_INFO
{
    public partial class PageMyLeaves : UserControl
    {
        public int SelectedLeaveAppliID { get; set; }

        public BindingList<LeaveApplicationModel> _LeavesList { get; set; }
        public BindingList<LeaveApplicationModel> _filteredLeavesList { get; set; }
        public PageMyLeaves()
        {
            InitializeComponent();
        }
        public void PopulateLeavesGrid()
        {
            try
            {
               // _LeavesList = AppCommon.ConvertToBindingList<LeaveApplicationModel>((new ServiceLeaveApplication()).GetAllLeaveApplicationsForEmp(Program.CURR_USER.EmployeeID));

                _LeavesList = AppCommon.ConvertToBindingList<LeaveApplicationModel>((new ServiceLeaveApplication()).GetAllLeaveApplicationsOfEmployee(Program.CURR_USER.EmployeeID));
                gridLeaveApplications.DataSource = _LeavesList;
                gridLeaveApplications.Columns["ApplicationID"].Visible =
                gridLeaveApplications.Columns["SearchString"].Visible =
                gridLeaveApplications.Columns["ApplicationNo"].Visible =
                gridLeaveApplications.Columns["ApplicationDate"].Visible =
                gridLeaveApplications.Columns["PreparedByID"].Visible =
                  gridLeaveApplications.Columns["ApprovedByID"].Visible =
                false;
                int gridWidth = gridLeaveApplications.Width;
                gridLeaveApplications.Columns["ApplicationNoWithDate"].HeaderText = "#Application";
                gridLeaveApplications.Columns["ApplicationNoWithDate"].Width = (int)(gridWidth * .1);
                gridLeaveApplications.Columns["EmployeeName"].Width = (int)(gridWidth * .15);
                gridLeaveApplications.Columns["LeaveDescription"].Width = (int)(gridWidth * .07);
                gridLeaveApplications.Columns["FromDateTime"].HeaderText = "From";
                gridLeaveApplications.Columns["FromDateTime"].Width = (int)(gridWidth * .07);
                gridLeaveApplications.Columns["FromDateTime"].DefaultCellStyle.Format = "dd MMM hh:mm tt";
                gridLeaveApplications.Columns["ToDateTime"].HeaderText = "Till";
                gridLeaveApplications.Columns["ToDateTime"].DefaultCellStyle.Format = "dd MMM hh:mm tt";
                gridLeaveApplications.Columns["ToDateTime"].Width = (int)(gridWidth * .07);
                gridLeaveApplications.Columns["Remarks"].Width = (int)(gridWidth * .15);

                gridLeaveApplications.Columns["ApplicationStatus"].Width = (int)(gridWidth * .05);
                gridLeaveApplications.Columns["ApplicationStatus"].HeaderText = "Status";

                gridLeaveApplications.Columns["PreparedByName"].HeaderText = "Prepared By";
                gridLeaveApplications.Columns["PreparedByName"].Width = (int)(gridWidth * .15);

                gridLeaveApplications.Columns["ApprovedByName"].HeaderText = "Approved By";
                gridLeaveApplications.Columns["ApprovedByName"].Width = (int)(gridWidth * .15);

              

                hederGroupLeaveApplications.ValuesSecondary.Heading = string.Format("{0}Records Found", gridLeaveApplications.Rows.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::PopulateLeavesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Employee MY LEAVE
        private void gridLeaveApplications_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServiceLeaveApplication service = new ServiceLeaveApplication();
                this.SelectedLeaveAppliID = (int)(gridLeaveApplications.Rows[e.RowIndex].Cells["ApplicationID"].Value);
                TBL_MP_HR_LeaveApplication dbModel = service.GetLeaveApplicationInfoDbRecord(SelectedLeaveAppliID);

                if (dbModel.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_PENDING_ID)
                    btnEditLeave.Enabled = btnDeleteLeave.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                if (dbModel.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_APPROVED_ID)
                    btnEditLeave.Enabled = btnDeleteLeave.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (dbModel.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_REJECTED_ID)
                { 
                    btnEditLeave.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnDeleteLeave.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::gridLeaveApplications_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSearchMyLeave_Click(object sender, EventArgs e)
        {

            try
            {
                _filteredLeavesList = new BindingList<LeaveApplicationModel>(_LeavesList.Where(p => p.SearchString.Contains(txtSearchLeaveApplications.Text.ToUpper())).ToList());
                gridLeaveApplications.DataSource = _filteredLeavesList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnSearchMyLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLeaveApplication frm = new frmAddEditLeaveApplication();
                frm.EmployeeID = Program.CURR_USER.EmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLeavesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnAddNewLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditLeave_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLeaveApplication frm = new frmAddEditLeaveApplication(this.SelectedLeaveAppliID);
               if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLeavesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnEditLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefreshLeaves_Click(object sender, EventArgs e)
        {
            PopulateLeavesGrid();
        }
        private void btnDeleteLeave_Click(object sender, EventArgs e)
        {

            try
            {
               // TBL_MP_HR_LeaveApplication model = new TBL_MP_HR_LeaveApplication();
                ServiceLeaveApplication service = new ServiceLeaveApplication();

                TBL_MP_HR_LeaveApplication dbModel = service.GetLeaveApplicationInfoDbRecord(SelectedLeaveAppliID);

               
                {
                    string msg = "Are you sure to Delete selected leave Permanently";
                    DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        if (dbModel.FK_UserList_ApprovalStatusID == service.LEAVE_STATUS_PENDING_ID)
                        {
                            (new ServiceLeaveApplication()).DeleteEmployeeLeave(this.SelectedLeaveAppliID);
                            PopulateLeavesGrid();
                        }
                        else
                        {
                             msg = "Unable to delete  selected leave..";
                            MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                } 
               
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnDeleteLeave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void hederGroupLeaveApplications_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

       
    }
}
