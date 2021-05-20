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

namespace appExcelERP.Controls.HR
{
    public partial class PageLoanRequestRegister : UserControl
    {
        public int LoanRequestID { get; set; }
        private BindingList<LoanRequestModel> _LoanRequestList = null;
        private BindingList<LoanRequestModel> _filteredLoanRequestList = null;
        public PageLoanRequestRegister()
        {
            InitializeComponent();
        }
        private void PageLoanRequestRegister_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateLoanRequestGrid();
                btnApproveReject.Visible = false;
                WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.LOAN_REQUEST).FirstOrDefault();
                if (model.CanApprove) btnApproveReject.Visible = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanRequestRegister::PageLoanRequestRegister_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #region Loan Request Register
        public void PopulateLoanRequestGrid()
        {
            try
            {
                _LoanRequestList = AppCommon.ConvertToBindingList<LoanRequestModel>((new ServiceLoanRequest()).GetAllLoanRequestsToEmployee(Program.CURR_USER.EmployeeID));
                gridLoanRequestRegister.DataSource = _LoanRequestList;
                gridLoanRequestRegister.ColumnHeadersHeight = 50;
                gridLoanRequestRegister.Columns["PK_LoanRequestID"].Visible = false;
                gridLoanRequestRegister.Columns["LoanRequestNo"].Visible = true;
                gridLoanRequestRegister.Columns["LoanRequestNo"].HeaderText = "Request No.";
                gridLoanRequestRegister.Columns["LoanRequestNo"].Width = 50;
                gridLoanRequestRegister.Columns["LoanRequestDate"].Visible = true;
                gridLoanRequestRegister.Columns["LoanRequestDate"].Width = 150;
                gridLoanRequestRegister.Columns["LoanRequestDate"].HeaderText = "Date\nRequest";
                gridLoanRequestRegister.Columns["LoanRequestDate"].DefaultCellStyle.Format = "dd/MM/yy";
                gridLoanRequestRegister.Columns["FK_EmployeeID"].Visible = false;
                gridLoanRequestRegister.Columns["EmployeeName"].Visible = true;
                gridLoanRequestRegister.Columns["EmployeeName"].HeaderText = "Name of Employee";
                gridLoanRequestRegister.Columns["RequestedLoanAmount"].Visible = true;
                gridLoanRequestRegister.Columns["RequestedLoanAmount"].HeaderText = "Amount\nRequested";
                gridLoanRequestRegister.Columns["RequestedLoanAmount"].Width = 80;
                gridLoanRequestRegister.Columns["RequestedLoanAmount"].DefaultCellStyle.Format = "0.00";

                gridLoanRequestRegister.Columns["Remarks"].Visible = true;
                gridLoanRequestRegister.Columns["Remarks"].HeaderText = "Remarks\nRequest";
                gridLoanRequestRegister.Columns["Remarks"].Width = (int)(this.Width * .2);
                gridLoanRequestRegister.Columns["ApprovalStatus"].Visible = false;
                gridLoanRequestRegister.Columns["StatusDescription"].Visible = true;
                gridLoanRequestRegister.Columns["StatusDescription"].HeaderText = "Status";
                gridLoanRequestRegister.Columns["StatusDescription"].Width = 80;
                gridLoanRequestRegister.Columns["RequestTo"].Visible = false; // this is for our convenience 
                gridLoanRequestRegister.Columns["FK_ApprovedBy"].Visible = false;
                gridLoanRequestRegister.Columns["ApproverName"].Visible = true;
                gridLoanRequestRegister.Columns["ApproverName"].HeaderText = "Name of Approver";
                gridLoanRequestRegister.Columns["ApprovalDate"].Visible = true;
                gridLoanRequestRegister.Columns["ApprovalDate"].HeaderText = "Date\nApproved";
                gridLoanRequestRegister.Columns["ApprovalDate"].DefaultCellStyle.Format = "dd/MM/yy";
                gridLoanRequestRegister.Columns["ApprovalDate"].Width = 80;
                gridLoanRequestRegister.Columns["ApprovedAmount"].Visible = true;
                gridLoanRequestRegister.Columns["ApprovedAmount"].DefaultCellStyle.Format = "0.00";
                gridLoanRequestRegister.Columns["ApprovedAmount"].HeaderText = "Amount\nApproved";
                gridLoanRequestRegister.Columns["ApprovedAmount"].Width = 80;
                gridLoanRequestRegister.Columns["RemarksApproved"].Visible = true;
                gridLoanRequestRegister.Columns["RemarksApproved"].HeaderText = "Remarks\nApproval";
                gridLoanRequestRegister.Columns["RemarksApproved"].Width = (int)(this.Width * .1);
                gridLoanRequestRegister.Columns["SearchString"].Visible = false;
                gridLoanRequestRegister.Columns["IsDeleted"].Visible = false;
                gridLoanRequestRegister.Columns["Fk_YearID"].Visible = false;
                gridLoanRequestRegister.Columns["FK_CompanyID"].Visible = false;
                gridLoanRequestRegister.Columns["Fk_BranchID"].Visible = false;
                hederGroupLoanRequest.ValuesSecondary.Heading = string.Format("{0}Records Found", gridLoanRequestRegister.Rows.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanRequestRegister::PopulateLoanRequestGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridLoanRegister_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServiceLoanRequest service = new ServiceLoanRequest();
                this.LoanRequestID = (int)(gridLoanRequestRegister.Rows[e.RowIndex].Cells["PK_LoanRequestID"].Value);
                TBL_MP_HR_LoanRequestApplication model = service.GetLoanRequestInfoDbRecord(this.LoanRequestID);

                //if (AppCommon.GetServerDateTime() < model.RequestDate)
                //    btnApproveReject.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                //else
                //    btnApproveReject.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanRequestRegister::gridLoanRegister_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private void btnSearchLoanRequestRegister_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredLoanRequestList = new BindingList<LoanRequestModel>(_LoanRequestList.Where(p => p.SearchString.Contains(txtSearchLoanRequest.Text.ToUpper())).ToList());
                gridLoanRequestRegister.DataSource = _filteredLoanRequestList;
                hederGroupLoanRequest.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridLoanRequestRegister.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanRequestRegister::btnSearchLoanRequestRegister_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnApproveReject_Click(object sender, EventArgs e)
        {
            try
            {
                frmApproveRejectLoanRequest frm = new frmApproveRejectLoanRequest(this.LoanRequestID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLoanRequestGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanRequestRegister::btnApproveReject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateLoanRequestGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanRequestRegister::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        
    }
}
