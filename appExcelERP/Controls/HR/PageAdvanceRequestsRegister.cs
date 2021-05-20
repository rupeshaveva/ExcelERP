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
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using appExcelERP.Forms.HR;
using libERP.MODELS.HR;

namespace appExcelERP.Controls.HR
{
    public partial class PageAdvanceRequestsRegister : UserControl
    {
        public int AdvanceRequestID { get; set; }
        private BindingList<AdvanceRequestModel> _AdvanceRequestList = null;
        private BindingList<AdvanceRequestModel> _filtered_AdvanceRequestList = null;
        public PageAdvanceRequestsRegister()
        {
            InitializeComponent();
        }

        private void PageAdvanceRequestsRegister_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateAdvanceRequestGrid();
                btnApproveReject.Visible = false;
                WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.ADVANCE_REQUEST).FirstOrDefault();
                if (model.CanApprove) btnApproveReject.Visible = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::PageAdvanceRequestsRegister_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void PopulateAdvanceRequestGrid()
        {
            try
            {
                _AdvanceRequestList = AppCommon.ConvertToBindingList<AdvanceRequestModel>((new ServiceAdvanceRequest()).GetAllAdvanceRequestsToEmployee(Program.CURR_USER.EmployeeID));
                gridAdvanceRegister.DataSource = _AdvanceRequestList;
                gridAdvanceRegister.ColumnHeadersHeight = 50;
                gridAdvanceRegister.Columns["PK_AdvancRequestID"].Visible = false;
                gridAdvanceRegister.Columns["AdvanceRequestNo"].Visible = true;
                gridAdvanceRegister.Columns["AdvanceRequestNo"].HeaderText = "Request No.";
                gridAdvanceRegister.Columns["AdvanceRequestNo"].Width= 105;
                gridAdvanceRegister.Columns["RequestDate"].Visible = true;
                gridAdvanceRegister.Columns["RequestDate"].Width =80;
                gridAdvanceRegister.Columns["RequestDate"].HeaderText = "Date\nRequest";
                gridAdvanceRegister.Columns["RequestDate"].DefaultCellStyle.Format = "dd/MM/yy";
                gridAdvanceRegister.Columns["FK_EmployeeID"].Visible = false;
                gridAdvanceRegister.Columns["EmployeeName"].Visible = true;
                gridAdvanceRegister.Columns["EmployeeName"].HeaderText = "Name of Employee";
                gridAdvanceRegister.Columns["RequestedAmount"].Visible = true;
                gridAdvanceRegister.Columns["RequestedAmount"].HeaderText = "Amount\nRequested";
                gridAdvanceRegister.Columns["RequestedAmount"].Width = 80;
                gridAdvanceRegister.Columns["RequestedAmount"].DefaultCellStyle.Format = "0.00";

                gridAdvanceRegister.Columns["Remarks"].Visible = true;
                gridAdvanceRegister.Columns["Remarks"].HeaderText = "Remarks\nRequest";
                gridAdvanceRegister.Columns["Remarks"].Width = (int)(this.Width * .2);
                gridAdvanceRegister.Columns["ApprovalStatus"].Visible = false;
                gridAdvanceRegister.Columns["StatusDescription"].Visible = true;
                gridAdvanceRegister.Columns["StatusDescription"].HeaderText = "Status";
                gridAdvanceRegister.Columns["StatusDescription"].Width = 80;
                gridAdvanceRegister.Columns["FK_RequestTo"].Visible = false; // this is for our convenience 
                gridAdvanceRegister.Columns["FK_ApprovedBy"].Visible = false;
                gridAdvanceRegister.Columns["ApproverName"].Visible = true;
                gridAdvanceRegister.Columns["ApproverName"].HeaderText = "Name of Approver";
                gridAdvanceRegister.Columns["ApprovalDate"].Visible = true;
                gridAdvanceRegister.Columns["ApprovalDate"].HeaderText = "Date\nApproved";
                gridAdvanceRegister.Columns["ApprovalDate"].DefaultCellStyle.Format = "dd/MM/yy";
                gridAdvanceRegister.Columns["ApprovalDate"].Width = 80;
                gridAdvanceRegister.Columns["ApprovedAmount"].Visible = true;
                gridAdvanceRegister.Columns["ApprovedAmount"].DefaultCellStyle.Format = "0.00";
                gridAdvanceRegister.Columns["ApprovedAmount"].HeaderText = "Amount\nApproved";
                gridAdvanceRegister.Columns["ApprovedAmount"].Width = 80;
                gridAdvanceRegister.Columns["RemarksApproved"].Visible = true;
                gridAdvanceRegister.Columns["RemarksApproved"].HeaderText = "Remarks\nApproval";
                gridAdvanceRegister.Columns["RemarksApproved"].Width = (int)(this.Width * .1);
                gridAdvanceRegister.Columns["SearchString"].Visible = false;
                 gridAdvanceRegister.Columns["IsDeleted"].Visible = false;
                gridAdvanceRegister.Columns["Fk_YearID"].Visible = false;
                gridAdvanceRegister.Columns["FK_CompanyID"].Visible = false;
                gridAdvanceRegister.Columns["Fk_BranchID"].Visible = false;
                hederGroupAdvanceRequest.ValuesSecondary.Heading = string.Format("{0}Records Found", gridAdvanceRegister.Rows.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::PopulateAdvanceRequestGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridAdvanceRegister_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServiceAdvanceRequest service = new ServiceAdvanceRequest();
                this.AdvanceRequestID = (int)(gridAdvanceRegister.Rows[e.RowIndex].Cells["PK_AdvancRequestID"].Value);
                TBL_MP_HR_AdvanceRequestApplication model = service.GetAdvanceRequestInfoDbRecord(this.AdvanceRequestID);

                //if (AppCommon.GetServerDateTime() < model.RequestDate)
                //    btnApproveReject.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                //else
                //    btnApproveReject.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::gridAdvanceRegister_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnApproveReject_Click(object sender, EventArgs e)
        {
            try
            {
                frmApproveRejectAdvanceRequest frm = new frmApproveRejectAdvanceRequest(this.AdvanceRequestID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAdvanceRequestGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::btnApproveReject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchAdvanceRequestRegister_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filtered_AdvanceRequestList = new BindingList<AdvanceRequestModel>(_AdvanceRequestList.Where(p => p.SearchString.Contains(txtSearchAdvanceRequest.Text.ToUpper())).ToList());
                gridAdvanceRegister.DataSource = _filtered_AdvanceRequestList;
                hederGroupAdvanceRequest.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridAdvanceRegister.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::btnSearchAdvanceRequestRegister_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateAdvanceRequestGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportAdvanceRequest_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string fName = string.Format("AdvancedRequestRegister.xls");
                string fileNameWithPath = string.Format("{0}{1}", AppCommon.GetDefaultStorageFolderPath(), fName);
                (new ServiceExcelApp()).ExportAdvancedRequstRegister(_AdvanceRequestList, fileNameWithPath);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAdvanceRequestsRegister::btnExportAdvanceRequest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
