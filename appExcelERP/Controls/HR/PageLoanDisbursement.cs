using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.HR;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using libERP;

namespace appExcelERP.Controls.HR
{
    public partial class PageLoanDisbursement : UserControl
    {
        public int SelectedLoanDisbursementID { get; set; }
        private BindingList<LoanDisbursementModel> _DisbursementList = null;
        private BindingList<LoanDisbursementModel> _filteredDisbursementList = null;

        public PageLoanDisbursement()
        {
            InitializeComponent();
        }
        private void PageLoanDisbursement_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateLoanDisbursmentGrid();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::PageLoanDisbursement_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #region Loan Disbursement
        public void PopulateLoanDisbursmentGrid()
        {
            try
            {
                _DisbursementList = AppCommon.ConvertToBindingList<LoanDisbursementModel>((new ServiceLoanDisbursement()).GetAllLoanDisbursementList());
                gridLoanDisbursement.DataSource = _DisbursementList;
                gridLoanDisbursement.ColumnHeadersHeight = 50;
                gridLoanDisbursement.Columns["DisbursementID"].Visible = false;
                gridLoanDisbursement.Columns["DisbursementDate"].Visible = true;
                gridLoanDisbursement.Columns["DisbursementDate"].HeaderText = "Date\nDisbursement";
                gridLoanDisbursement.Columns["DisbursementDate"].Width = 80;
                gridLoanDisbursement.Columns["DisbursementDate"].DefaultCellStyle.Format = "dd/MM/yy";

                gridLoanDisbursement.Columns["EmployeeInfo"].Visible = true;
                //gridLoanDisbursement.Columns["EmployeeInfo"].Width = 150;
                gridLoanDisbursement.Columns["EmployeeInfo"].HeaderText = "Employee Info.";
            
                
                gridLoanDisbursement.Columns["LoanInfo"].Visible = true;
                //gridLoanDisbursement.Columns["LoanInfo"].Width = 150;
                gridLoanDisbursement.Columns["LoanInfo"].HeaderText = "Loan Info.";


                gridLoanDisbursement.Columns["DisbursementInfo"].Visible = true;
                gridLoanDisbursement.Columns["DisbursementInfo"].HeaderText = "Disbursement Info.";
                //gridLoanDisbursement.Columns["DisbursementInfo"].Width = 80;

                gridLoanDisbursement.Columns["StatusInfo"].Visible = true;
                gridLoanDisbursement.Columns["StatusInfo"].HeaderText = "Status";
                gridLoanDisbursement.Columns["StatusInfo"].Width = 80;

                gridLoanDisbursement.Columns["AmountGiven"].Visible = true;
                gridLoanDisbursement.Columns["AmountGiven"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridLoanDisbursement.Columns["AmountGiven"].HeaderText = "Amount\nLoan";
                gridLoanDisbursement.Columns["AmountGiven"].Width = 80;

                gridLoanDisbursement.Columns["AmountReceived"].Visible = true;
                gridLoanDisbursement.Columns["AmountReceived"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridLoanDisbursement.Columns["AmountReceived"].HeaderText = "Amount\nReceived";
                gridLoanDisbursement.Columns["AmountReceived"].Width = 80;

                gridLoanDisbursement.Columns["AmountDue"].Visible = true;
                gridLoanDisbursement.Columns["AmountDue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridLoanDisbursement.Columns["AmountDue"].HeaderText = "Amount\nDue";
                gridLoanDisbursement.Columns["AmountDue"].Width = 80;

                gridLoanDisbursement.Columns["SearchText"].Visible = false;
              


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::PopulateLoanDisbursmentGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridLoanDisbursement_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedLoanDisbursementID = (int)gridLoanDisbursement.Rows[e.RowIndex].Cells["DisbursementID"].Value;
                ServiceLoanDisbursement service = new ServiceLoanDisbursement();
                TBL_MP_HR_LoanDisbursement model = service.GetLoanDisbursementInfoDbRecord(this.SelectedLoanDisbursementID);
                if (model.ApprovalStatus == service.LOAN_DISBURSEMENT_STATUS_PENDING_ID)
                {
                    btnApproveDisbursement.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
                else
                    btnApproveDisbursement.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::gridLoanDisbursement_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewLoan_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLoanDisbursement frm = new frmAddEditLoanDisbursement();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLoanDisbursmentGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::btnAddNewLoan_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditLoan_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLoanDisbursement frm = new frmAddEditLoanDisbursement(this.SelectedLoanDisbursementID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLoanDisbursmentGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::btnEditLoan_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteLoan_Click(object sender, EventArgs e)
        {
            try
            {

                ServiceLoanDisbursement service = new ServiceLoanDisbursement();

                TBL_MP_HR_LoanDisbursement dbModel = service.GetLoanDisbursementInfoDbRecord(SelectedLoanDisbursementID);


                {
                    string msg = "Are you sure to Delete selected Loan disbursement Permanently";
                    DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        if (dbModel.ApprovalStatus == service.LOAN_DISBURSEMENT_STATUS_PENDING_ID)
                        {
                            (new ServiceLoanDisbursement()).DeleteLoanDisbursement(this.SelectedLoanDisbursementID);
                            PopulateLoanDisbursmentGrid();
                        }
                        else
                        {
                            msg = "Unable to delete  selected Loan disbursement request..";
                            MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::btnDeleteLoan_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                    PopulateLoanDisbursmentGrid();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchLoanDisbursement_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredDisbursementList = new BindingList<LoanDisbursementModel>(_DisbursementList.Where(p => p.SearchText.Contains(txtSearchLoanDisbursementGrid.Text.ToUpper())).ToList());
                gridLoanDisbursement.DataSource = _filteredDisbursementList;
                hederGroupLoanDisbursement.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridLoanDisbursement.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::btnSearchLoanDisbursement_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnApproveDisbursement_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strMessage = "Are You sure to Approve Selected Loan";
                if (MessageBox.Show(strMessage, "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ServiceLoanDisbursement service = new ServiceLoanDisbursement();
                    TBL_MP_HR_LoanDisbursement model = service.GetLoanDisbursementInfoDbRecord(this.SelectedLoanDisbursementID);
                    model.ApprovalStatus = service.LOAN_DISBURSEMENT_APPROVED_ID;
                    model.FK_ApprovedBy = Program.CURR_USER.EmployeeID;
                    service.UpdateLoanDisbursement(model);
                    PopulateLoanDisbursmentGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageLoanDisbursement::btnApproveDisbursement_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

       
    }
}
