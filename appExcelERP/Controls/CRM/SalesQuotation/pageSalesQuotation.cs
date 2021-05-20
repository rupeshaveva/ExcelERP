using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP.MODELS;
using appExcelERP.Forms;
using appExcelERP.Controls.CommonControls;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using libERP.MODELS.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.COMMON;
using libERP.MODELS.CRM;
using appExcelERP.Forms.CRM.SalesEnquiry;

namespace appExcelERP.Controls.CRM
{
    public partial class pageSalesQuotation : UserControl
    {
        public int FormOperationID { get; set; }
        public DB_FORM_IDs SelectedTAB { get; set; }
        public KryptonPage ParentTABControl { get; set; }

        public int SelectedQuotationID { get; set; }
        public string SelectedQuotationNumber { get; set; }
        private int SelectedQuotationStatus = 0;
        
        BindingList<SelectListItem> _QuotationsList = null;
        BindingList<SelectListItem> _filteredQuotationsList = null;
        
        #region TAB PAGE CUSTOM CONTROLS
        ControlSalesQuotaionGeneralDetails _ctrlGeneralDetails = null;
        private void InitializeQuotationGeneralInfoControl()
        {
            _ctrlGeneralDetails = new ControlSalesQuotaionGeneralDetails();
            tabPageGeneralInfo.Controls.Add(_ctrlGeneralDetails);
            _ctrlGeneralDetails.Dock = DockStyle.Fill;
        }

        ControlSalesQuotationClientDetails _ctrlClientDetails = null;
        private void InitializeClientDetailsControl()
        {
            _ctrlClientDetails = new ControlSalesQuotationClientDetails();
            tabPageClientDetail.Controls.Add(_ctrlClientDetails);
            _ctrlClientDetails.Dock = DockStyle.Fill;
        }

        ctrlAttachments _ctrlAttachment = null;
        private void InitializeAttachmentInfoControl()
        {
            _ctrlAttachment = new ctrlAttachments(APP_ENTITIES.SALES_QUOTATION);
            _ctrlAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
            tabPageAttachment.Controls.Add(_ctrlAttachment);
            _ctrlAttachment.Dock = DockStyle.Fill;
        }


        ctrlScheduleCallLog _ctrlScheduler = null;
        private void InitializeSchedulerInfoControl()
        {
            tabPageScheduledCalls.Controls.Clear();
            _ctrlScheduler = new ctrlScheduleCallLog(APP_ENTITIES.SALES_QUOTATION);
            tabPageScheduledCalls.Controls.Add(_ctrlScheduler);
            _ctrlScheduler.Dock = DockStyle.Fill;
        }

        ctrlAssociates _ctrlAssociates = null;
        private void InitializeAssociatesInfoControl()
        {
            tabPageAssociates.Controls.Clear();
            _ctrlAssociates = new ctrlAssociates(APP_ENTITIES.SALES_QUOTATION);
            tabPageAssociates.Controls.Add(_ctrlAssociates);
            _ctrlAssociates.Dock = DockStyle.Fill;
        }

        ControlSalesQuotationTermsAndCondition _ctrlTermsAndConditions = null;
        private void InitializeTermsAndConditionsInfoControl()
        {
            tabPageTermAndConditions.Controls.Clear();
            _ctrlTermsAndConditions = new ControlSalesQuotationTermsAndCondition();
            tabPageTermAndConditions.Controls.Add(_ctrlTermsAndConditions);
            _ctrlTermsAndConditions.Dock = DockStyle.Fill;
        }

        #endregion

        public pageSalesQuotation()
        {
            InitializeComponent();
        }
        private void pageSalesQuotation_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            try
            {
                PopulateSalesQuotationStatus();

                SelectedQuotationStatus = ((SelectListItem)cboQuotationStatus.SelectedItem).ID;
                PopulateSalesQuotations();
                splitContainerMain.SplitterDistance = (int)(this.Width * .25);

                SetSalesQuotationTabTags();
                SetSalesQuotationTabAsPerPermission();
                if (_ctrlGeneralDetails != null) this.SelectedTAB = (DB_FORM_IDs)tabPageGeneralInfo.Tag;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::pageSalesQuotation_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        
        #region ACCESS RIGHT MANAGEMENT CODE
        private void SetSalesQuotationTabTags()
        {
            try
            {
                tabPageGeneralInfo.Tag = DB_FORM_IDs.SALES_QUOTATION_GENERAL_INFO; //SALES LEAD FOMR ID
                tabPageClientDetail.Tag = DB_FORM_IDs.SALES_QUOTATION_CLIENT_INFO; // SALES ENQUIRY FORM ID
                tabPageAttachment.Tag = DB_FORM_IDs.SALES_QUOTATION_ATTACHMENTS;
                tabPageAssociates.Tag = DB_FORM_IDs.SALES_QUOTATION_ASSOCIATES;
                tabPageScheduledCalls.Tag = DB_FORM_IDs.SALES_QUOTATION_SCHEDULE_CALL;
                tabPageTermAndConditions.Tag = DB_FORM_IDs.SALES_QUOTATION_TNC;

                btnSalesBOQ.Tag = DB_FORM_IDs.SALES_QUOTATION_BOQ;

                tabPageGeneralInfo.Visible = 
                tabPageClientDetail.Visible = 
                tabPageBOQ.Visible = 
                tabPageAttachment.Visible = 
                tabPageAssociates.Visible = 
                tabPageScheduledCalls.Visible =
                tabPageTermAndConditions.Visible = false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::SetSalesQuotationTabTags", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSalesQuotationTabAsPerPermission()
        {
            WhosWhoModel model = null;
            try
            {
                foreach (KryptonPage tabSelected in tabQuotation.Pages)
                {
                    if (tabSelected.Tag != null)
                    {
                        model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)tabSelected.Tag).FirstOrDefault();
                        if (model != null)
                        {
                            tabSelected.Visible = model.CanView;
                            if (tabSelected.Visible)
                            {
                                switch ((DB_FORM_IDs)model.FormID)
                                {
                                    case DB_FORM_IDs.SALES_QUOTATION_GENERAL_INFO: InitializeQuotationGeneralInfoControl(); break;
                                    case DB_FORM_IDs.SALES_QUOTATION_CLIENT_INFO: InitializeClientDetailsControl(); break;
                                    case DB_FORM_IDs.SALES_QUOTATION_ATTACHMENTS: InitializeAttachmentInfoControl(); break;
                                    case DB_FORM_IDs.SALES_QUOTATION_ASSOCIATES: InitializeAssociatesInfoControl(); break;
                                    case DB_FORM_IDs.SALES_QUOTATION_SCHEDULE_CALL: InitializeSchedulerInfoControl(); break;
                                    case DB_FORM_IDs.SALES_QUOTATION_TNC: InitializeTermsAndConditionsInfoControl(); break;
                                }
                            }

                        }
                    }
                }
                model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.SALES_QUOTATION_BOQ).FirstOrDefault();
                if (model != null)
                {
                    btnSalesBOQ.Visible = model.CanView;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::SetSalesQuotationTabAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
            bool readOnly = (new ServiceSalesQuotation()).IsQuotationReadOnly(this.SelectedQuotationID);
            if (readOnly)
                btnEditQuotation.Enabled = btnDeleteQuotation.Enabled = btnGenerateRevision.Enabled = ButtonEnabled.False;
            else
                btnEditQuotation.Enabled = btnDeleteQuotation.Enabled = btnGenerateRevision.Enabled = ButtonEnabled.True;
            
            switch (this.SelectedTAB)
            {
                case DB_FORM_IDs.SALES_QUOTATION_GENERAL_INFO:
                    if (_ctrlGeneralDetails == null) return;
                    _ctrlGeneralDetails.SelectedQuotationID = this.SelectedQuotationID;
                    _ctrlGeneralDetails.ReadOnly = readOnly;
                    _ctrlGeneralDetails.PoulateSalesQuotationMasterInfo();

                    break;
                case DB_FORM_IDs.SALES_QUOTATION_CLIENT_INFO:
                    if (_ctrlClientDetails == null) return;
                    _ctrlClientDetails.SelectedQuotationID = this.SelectedQuotationID;
                    _ctrlClientDetails.ReadOnly = readOnly;
                    _ctrlClientDetails.PopulateClientAndConsultantInfo(); break;
                //case DB_FORM_IDs.SALES_QUOTATION_BOQ:
                //    if (_ControlQuotationBOQ == null) return;
                //    _ControlQuotationBOQ.SalesQuotationID = this.SelectedQuotationID;
                //    _ControlQuotationBOQ.ReadOnly = readOnly;
                //    _ControlQuotationBOQ.PopulateSalesQuotationBOQ();
                //    if (_ctrlGeneralDetails != null)
                //        _ctrlGeneralDetails.UpdateBOQSummary(_ControlQuotationBOQ.MODEL.SUMMARY);
                //    break;
                case DB_FORM_IDs.SALES_QUOTATION_ATTACHMENTS:
                    if (_ctrlAttachment == null) return;
                    _ctrlAttachment.SelectedEntityID = this.SelectedQuotationID;
                    _ctrlAttachment.ReadOnly = readOnly;
                    _ctrlAttachment.PopulateDocuments();
                    break;
                case DB_FORM_IDs.SALES_QUOTATION_SCHEDULE_CALL:
                    if (_ctrlScheduler == null) return;
                    _ctrlScheduler.SOURCE_ENTITY_ID = this.SelectedQuotationID;
                    _ctrlScheduler.ReadOnly = readOnly;
                    _ctrlScheduler.PopulateAllSchedules();
                    break;
                case DB_FORM_IDs.SALES_QUOTATION_ASSOCIATES:
                    if (_ctrlAssociates == null) return;
                    _ctrlAssociates.SelectedID = this.SelectedQuotationID;
                    _ctrlAssociates.ReadOnly = readOnly;
                    _ctrlAssociates.PopulateAssociatedEmployees();
                    break;
                case DB_FORM_IDs.SALES_QUOTATION_TNC:
                    if (_ctrlTermsAndConditions == null) return;
                    _ctrlTermsAndConditions.SelectedQuotationID = this.SelectedQuotationID;
                    _ctrlTermsAndConditions.ReadOnly = readOnly;
                    _ctrlTermsAndConditions.PopulateControl();
                    break;

            }

        }
        #endregion

        private void PopulateSalesQuotationStatus()
        {
            try
            {
                List<SelectListItem> lst = (new ServiceSalesQuotation()).GetAllActiveQuotationStatusesList();
                lst.Add(new SelectListItem() { ID = 0, Description = "(ALL)" });
                lst = lst.OrderBy(x => x.Description).ToList();
                cboQuotationStatus.DataSource = lst;
                cboQuotationStatus.DisplayMember = "Description";
                cboQuotationStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::PopulateSalesQuotationStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void PopulateSalesQuotations()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _QuotationsList = (new ServiceSalesQuotation()).GetSalseQuotationsSelectListForStatus(this.SelectedQuotationStatus);
                gridSalesQuotations.DataSource = _QuotationsList;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesQuotation::PopulateSalesQuotations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void gridSalesQuotations_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;    
            try
            {
                gridSalesQuotations.Columns["ID"].Visible = gridSalesQuotations.Columns["IsActive"].Visible = gridSalesQuotations.Columns["Code"].Visible = gridSalesQuotations.Columns["DescriptionToUpper"].Visible = false;
                headerGroupQuotList.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridSalesQuotations.Rows.Count);
                if (gridSalesQuotations.Rows.Count == 0)
                {
                    splitContainerMain.Panel2.Enabled = false;
                    btnEditQuotation.Enabled = btnDeleteQuotation.Enabled = ButtonEnabled.False;
                }
                else
                {
                    splitContainerMain.Panel2.Enabled = true;
                    btnEditQuotation.Enabled = btnDeleteQuotation.Enabled = ButtonEnabled.True;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesQuotation::gridSalesQuotations_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void gridSalesQuotations_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.SelectedQuotationID = (int)gridSalesQuotations.Rows[e.RowIndex].Cells["ID"].Value;
                    this.SelectedQuotationNumber = gridSalesQuotations.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                    this.ParentTABControl.Text = this.SelectedQuotationNumber;
                    btnGenerateRevision.Visible = (new ServiceSalesQuotation()).IsQuotationStatusOPEN(this.SelectedQuotationID);
                    this.RefreshTabPage();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::gridSalesQuotations_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchQuotations_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _filteredQuotationsList = new BindingList<SelectListItem>(_QuotationsList.Where(p => p.DescriptionToUpper.Contains(txtSearchQuotations.Text.ToUpper())).ToList());
                gridSalesQuotations.DataSource = _filteredQuotationsList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesQuotation::txtSearchQuotations_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
               
        private void cboQuotationStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboQuotationStatus.SelectedItem != null)
                {
                    SelectedQuotationStatus = ((SelectListItem)cboQuotationStatus.SelectedItem).ID;
                    PopulateSalesQuotations();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::cboQuotationStatus_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnShowHideList_ButtonSpecPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            splitContainerMain.Panel1Collapsed = (btnShowHideList.Checked == ButtonCheckState.Unchecked) ? true : false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateSalesQuotations();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalesQuotation frm = new frmSalesQuotation();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalesQuotations();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::btnAddNewQuotation_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedQuotationID == 0)
                {
                    MessageBox.Show("Select a valid SalesQuotation for Editing", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmSalesQuotation frm = new frmSalesQuotation(this.SelectedQuotationID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalesQuotations();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::btnEditQuotation_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Sales Quotation {0}", this.SelectedQuotationNumber);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalesQuotation()).DeleteSalesQuotation(this.SelectedQuotationID, Program.CURR_USER.EmployeeID))
                        PopulateSalesQuotations();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::btnDeleteQuotation_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabQuotation_TabClicked(object sender, KryptonPageEventArgs e)
        {
            this.SelectedTAB = (DB_FORM_IDs)((KryptonNavigator)sender).Pages[e.Index].Tag;
            this.RefreshTabPage();
        }
        private void btnSalesBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                frmBOQ frm = new frmBOQ();
                frm.FormClosed += Frm_FormClosed;
                frm.SelectedEntity = APP_ENTITIES.SALES_QUOTATION;
                frm.SelectedEntityID = this.SelectedQuotationID;
                frm.Show();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::btnSalesBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefreshTabPage();
        }
        #region generate revision for sales quotation
        private void btnGenerateRevision_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new ServiceSalesQuotation()).GenerateRevision(this.SelectedQuotationID,Program.CURR_USER);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotation::btnGenerateRevision_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        #endregion


    }
}
