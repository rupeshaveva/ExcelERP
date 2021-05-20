using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;
using libERP.MODELS.HR;

namespace appExcelERP.Controls.USER_INFO
{
    public partial class PageMyAdvanceRequests : UserControl
    {
        public int SelectedAdvanceRequestID { get; set; }
        public BindingList<AdvanceRequestModel> _AdvanceRequestList { get; set; }
        public BindingList<AdvanceRequestModel> _filteredAdvanceRequestList { get; set; }

        public PageMyAdvanceRequests()
        {
            InitializeComponent();
        }
        private void PageMyAdvanceRequests_Load(object sender, EventArgs e)
        {
            PopulateAdvanceRequestGrid();
        }

        #region EMPLOYEE ADVANCE REQUESTS
        public void PopulateAdvanceRequestGrid()
        {
            try
            {
                _AdvanceRequestList = AppCommon.ConvertToBindingList<AdvanceRequestModel>((new ServiceAdvanceRequest()).GetAllAdvanceRequestsOfEmployeeForStatus(Program.CURR_USER.EmployeeID));
                gridAdvanceRequests.DataSource = _AdvanceRequestList;
                foreach (DataGridViewColumn col in gridAdvanceRequests.Columns)
                {
                    col.Visible = false;
                }
                gridAdvanceRequests.Columns["RequestDate"].Visible =
                    gridAdvanceRequests.Columns["EmployeeName"].Visible =
                    gridAdvanceRequests.Columns["RequestedAmount"].Visible =
                    gridAdvanceRequests.Columns["Remarks"].Visible =
                    gridAdvanceRequests.Columns["StatusDescription"].Visible =
                    gridAdvanceRequests.Columns["ApproverName"].Visible =
                    gridAdvanceRequests.Columns["ApprovalDate"].Visible =
                    gridAdvanceRequests.Columns["ApprovedAmount"].Visible =
                    gridAdvanceRequests.Columns["RemarksApproved"].Visible =
                    gridAdvanceRequests.Columns["ApproverName"].Visible = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::PopulateAdvanceRequestGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridAdvanceRequests_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedAdvanceRequestID = (int)(gridAdvanceRequests.Rows[e.RowIndex].Cells["PK_AdvancRequestID"].Value);
                int approvalStatusID = (int)(gridAdvanceRequests.Rows[e.RowIndex].Cells["ApprovalStatus"].Value);
                ServiceAdvanceRequest service = new ServiceAdvanceRequest();
                if (approvalStatusID != service.REQUEST_STATUS_PENDING_ID)
                    btnEditAdvanceRequest.Enabled = btnDeleteAdvanceRequests.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                else
                    btnEditAdvanceRequest.Enabled = btnDeleteAdvanceRequests.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::gridAdvanceRequests_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSearchMyAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                _filteredAdvanceRequestList = new BindingList<AdvanceRequestModel>(_AdvanceRequestList.Where(p => p.SearchString.Contains(txtAdvanceSearch.Text.ToUpper())).ToList());
                gridAdvanceRequests.DataSource = _filteredAdvanceRequestList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnSearchMyAdvance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewAdvanceRequest_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAdvanceRequest frm = new frmAddEditAdvanceRequest();
                frm.EmployeeID = Program.CURR_USER.EmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAdvanceRequestGrid();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnAddNewAdvanceRequest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditAdvanceRequest_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAdvanceRequest frm = new frmAddEditAdvanceRequest(this.SelectedAdvanceRequestID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAdvanceRequestGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnEditAdvanceRequest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteAdvanceRequests_Click(object sender, EventArgs e)
        {
            try
            {
                // TBL_MP_HR_LeaveApplication model = new TBL_MP_HR_LeaveApplication();
                ServiceAdvanceRequest service = new ServiceAdvanceRequest();

                TBL_MP_HR_AdvanceRequestApplication dbModel = service.GetAdvanceRequestInfoDbRecord(SelectedAdvanceRequestID);


                {
                    string msg = "Are you sure to Delete selected advanced request Permanently";
                    DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        if (dbModel.ApprovalStatus == service.REQUEST_STATUS_PENDING_ID)
                        {
                            (new ServiceAdvanceRequest()).DeleteAdvancedRequest(this.SelectedAdvanceRequestID);
                            PopulateAdvanceRequestGrid();
                        }
                        else
                        {
                            msg = "Unable to delete  selected advanced request..";
                            MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMyAdvanceRequests::btnDeleteAdvanceRequests_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

       
    }
}
