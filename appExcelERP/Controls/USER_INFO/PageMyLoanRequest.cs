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
    public partial class PageMyLoanRequest : UserControl
    {
        public int SelectedLoanRequestID { get; set; }
        public BindingList<LoanRequestModel> _LoanRequestList { get; set; }
        public BindingList<LoanRequestModel> _filteredLoanRequestList { get; set; }


        public PageMyLoanRequest()
        {
            InitializeComponent();
        }
        private void PageMyLoanRequest_Load(object sender, EventArgs e)
        {
            PopulateLoanRequestGrid();
        }
        #region EMPLOYEE LOAN REQUESTS
        public void PopulateLoanRequestGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _LoanRequestList = AppCommon.ConvertToBindingList<LoanRequestModel>((new ServiceLoanRequest()).GetAllLoanRequestsOfEmployeeForStatus(Program.CURR_USER.EmployeeID));
                gridLoanRequest.DataSource = _LoanRequestList;
                foreach (DataGridViewColumn col in gridLoanRequest.Columns)
                {
                    col.Visible = false;
                }
                // follow this patter noonward for grid... 
                gridLoanRequest.ColumnHeadersHeight = 50;
                gridLoanRequest.Columns["PK_LoanRequestID"].Visible = false;
                gridLoanRequest.Columns["LoanRequestNo"].Visible = true;
                gridLoanRequest.Columns["LoanRequestNo"].HeaderText = "Request No.";
                gridLoanRequest.Columns["LoanRequestNo"].Width = 50;
                gridLoanRequest.Columns["LoanRequestDate"].Visible = true;
                gridLoanRequest.Columns["LoanRequestDate"].Width = 150;
                gridLoanRequest.Columns["LoanRequestDate"].HeaderText = "Date\nRequest";
                gridLoanRequest.Columns["LoanRequestDate"].DefaultCellStyle.Format = "dd/MM/yy";
                gridLoanRequest.Columns["FK_EmployeeID"].Visible = false;
                gridLoanRequest.Columns["EmployeeName"].Visible = true;
                gridLoanRequest.Columns["EmployeeName"].HeaderText = "Name of Employee";
                gridLoanRequest.Columns["RequestedLoanAmount"].Visible = true;
                gridLoanRequest.Columns["RequestedLoanAmount"].HeaderText = "Amount\nRequested";
                gridLoanRequest.Columns["RequestedLoanAmount"].Width = 80;
                gridLoanRequest.Columns["RequestedLoanAmount"].DefaultCellStyle.Format = "0.00";

                gridLoanRequest.Columns["Remarks"].Visible = true;
                gridLoanRequest.Columns["Remarks"].HeaderText = "Remarks\nRequest";
                gridLoanRequest.Columns["Remarks"].Width = (int)(this.Width * .2);
                gridLoanRequest.Columns["ApprovalStatus"].Visible = false;
                gridLoanRequest.Columns["StatusDescription"].Visible = true;
                gridLoanRequest.Columns["StatusDescription"].HeaderText = "Status";
                gridLoanRequest.Columns["StatusDescription"].Width = 80;
                gridLoanRequest.Columns["RequestTo"].Visible = false; // this is for our convenience 
                gridLoanRequest.Columns["FK_ApprovedBy"].Visible = false;
                gridLoanRequest.Columns["ApproverName"].Visible = true;
                gridLoanRequest.Columns["ApproverName"].HeaderText = "Name of Approver";
                gridLoanRequest.Columns["ApprovalDate"].Visible = true;
                gridLoanRequest.Columns["ApprovalDate"].HeaderText = "Date\nApproved";
                gridLoanRequest.Columns["ApprovalDate"].DefaultCellStyle.Format = "dd/MM/yy";
                gridLoanRequest.Columns["ApprovalDate"].Width = 80;
                gridLoanRequest.Columns["ApprovedAmount"].Visible = true;
                gridLoanRequest.Columns["ApprovedAmount"].DefaultCellStyle.Format = "0.00";
                gridLoanRequest.Columns["ApprovedAmount"].HeaderText = "Amount\nApproved";
                gridLoanRequest.Columns["ApprovedAmount"].Width = 80;
                gridLoanRequest.Columns["RemarksApproved"].Visible = true;
                gridLoanRequest.Columns["RemarksApproved"].HeaderText = "Remarks\nApproval";
                gridLoanRequest.Columns["RemarksApproved"].Width = (int)(this.Width * .1);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::PopulateLoanRequestGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridLoanRequest_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                this.SelectedLoanRequestID = (int)(gridLoanRequest.Rows[e.RowIndex].Cells["PK_LoanRequestID"].Value);
                int approvalStatusID = (int)(gridLoanRequest.Rows[e.RowIndex].Cells["ApprovalStatus"].Value);
                ServiceLoanRequest service = new ServiceLoanRequest();
                if (approvalStatusID != service.REQUEST_STATUS_PENDING_ID)
                    btnEditLoanRequest.Enabled = btnDeleteLoanRequest.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                else
                    btnEditLoanRequest.Enabled = btnDeleteLoanRequest.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::gridLoanRequest_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAddNewLoanRequest_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLoanRequest frm = new frmAddEditLoanRequest();
                frm.EmployeeID = Program.CURR_USER.EmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLoanRequestGrid();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnAddNewLoanRequest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditLoanRequest_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLoanRequest frm = new frmAddEditLoanRequest(this.SelectedLoanRequestID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLoanRequestGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnEditLoanRequest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteLoanRequest_Click(object sender, EventArgs e)
        {
            try
            {

                ServiceLoanRequest service = new ServiceLoanRequest();

                TBL_MP_HR_LoanRequestApplication dbModel = service.GetLoanRequestInfoDbRecord(SelectedLoanRequestID);


                {
                    string msg = "Are you sure to Delete selected Loan request Permanently";
                    DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        if (dbModel.ApprovalStatus == service.REQUEST_STATUS_PENDING_ID)
                        {
                            (new ServiceLoanRequest()).DeleteLoanRequest(this.SelectedLoanRequestID);
                            PopulateLoanRequestGrid();
                        }
                        else
                        {
                            msg = "Unable to delete  selected Loan request..";
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
        private void btnSearchMyLoan_Click(object sender, EventArgs e)
        {

            try
            {
                _filteredLoanRequestList = new BindingList<LoanRequestModel>(_LoanRequestList.Where(p => p.SearchString.Contains(txtSearchLoanRequest.Text.ToUpper())).ToList());
                gridLoanRequest.DataSource = _filteredLoanRequestList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::btnSearchMyLoan_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateLoanRequestGrid();
        }
         #endregion

       
    }
}
