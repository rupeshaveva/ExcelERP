using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms;
using libERP.SERVICES;
using libERP.MODELS;
using appExcelERP.Controls.CommonControls;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;

 
using libERP;
using System.Threading;
using libERP.SERVICES.CRM;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class pageSalesLead : UserControl
    {
        public int FormOperationID { get; set; }
        public DB_FORM_IDs SelectedTAB { get; set; }
        public KryptonPage ParentTABControl { get; set; }

        public int SelectedLeadID { get; set; }
        public string SelectedLeadNumber { get; set; }

        private ServiceUOW _UNIT = null;
        BindingList<SelectListItem> _leadsList = null;
        BindingList<SelectListItem> _filteredList = null;
        
        #region BACKGROUNDWORKER
        //BackgroundWorker bwLeadsLoad = null;
        //private void InitializeBackgroundWorker()
        //{
        //    try
        //    {
        //        bwLeadsLoad = new BackgroundWorker();
        //        bwLeadsLoad.WorkerSupportsCancellation = true;
        //        bwLeadsLoad.WorkerReportsProgress = true;
        //        bwLeadsLoad.DoWork += new DoWorkEventHandler(bwLeadsLoad_DoWork);
        //        bwLeadsLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLeadsLoad_RunWorkerCompleted);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "pageSalesLead::InitializeBackgroundWorker", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        //private void bwLeadsLoad_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        BackgroundWorker worker = sender as BackgroundWorker;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "pageSalesLead::bwLeadsLoad_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        e.Cancel = true;
        //    }

        //}
        //private void bwLeadsLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {

        //        Application.DoEvents();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "pageSalesLead::bwLeadsLoad_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}
        #endregion

        public ServiceSalesLead _service = null;
        

        int _SelectedStatus = 0;

        ControlSalesLeadGeneralDetails _ctrlGeneralDetails = null;
        private void InitializeLeadMasterInfoControl()
        {
            try
            {
                _ctrlGeneralDetails = new ControlSalesLeadGeneralDetails();
                tabPageGeneralInfo.Controls.Add(_ctrlGeneralDetails);
                _ctrlGeneralDetails.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageSalesLead::InitializeLeadMasterInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        ctrlAttachments _ctrlSalesLeadAttachment = null;
        private void InitializeAttachmentInfoControl()
        {
            _ctrlSalesLeadAttachment = new ctrlAttachments(APP_ENTITIES.SALES_LEAD);
            _ctrlSalesLeadAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
            tabPageAttachement.Controls.Add(_ctrlSalesLeadAttachment);
            _ctrlSalesLeadAttachment.Dock = DockStyle.Fill;
        }

        ctrlAssociates _ctrlAssociates = null;
        private void InitializeAssociatesInfoControl()
        {
            tabPageAssociate.Controls.Clear();
            _ctrlAssociates = new ctrlAssociates(APP_ENTITIES.SALES_LEAD);
            tabPageAssociate.Controls.Add(_ctrlAssociates);
            _ctrlAssociates.Dock = DockStyle.Fill;
        }

        ctrlSuspectInfo _ctrlSuspectInfo = null;
        private void InitializeSuspectInfoControl()
        {
            tabPageSuspect.Controls.Clear();
            _ctrlSuspectInfo = new ctrlSuspectInfo(APP_ENTITIES.SALES_LEAD);
            tabPageSuspect.Controls.Add(_ctrlSuspectInfo);
            _ctrlSuspectInfo.Dock = DockStyle.Fill;
        }

        ctrlScheduleCallLog _ctrlScheduler = null;
        private void InitializeSchedulerInfoControl()
        {
            tabPageScheduledCalls.Controls.Clear();
            _ctrlScheduler = new ctrlScheduleCallLog(APP_ENTITIES.SALES_LEAD);

            tabPageScheduledCalls.Controls.Add(_ctrlScheduler);
            _ctrlScheduler.Dock = DockStyle.Fill;
        }

        public pageSalesLead()
        {
            try
            {
                _UNIT = new ServiceUOW();
                InitializeComponent();
                Cursor = Cursors.WaitCursor;
                _service = new ServiceSalesLead();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::pageSalesLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void pageSalesLead_Load(object sender, EventArgs e)
        {
            try
            {
                SetSalesLeadTabTags();
                SetSalesLeadTabAsPerPermission();
                if (_ctrlGeneralDetails != null) this.SelectedTAB = (DB_FORM_IDs)tabPageGeneralInfo.Tag;

                InitLeadStatusDropdown();
                _SelectedStatus = ((SelectListItem)cboLeadStatuses.Items[0]).ID;
                splitContainerMain.SplitterDistance = (int)(this.Width * .25);
                PopulateLeads();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}",ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::pageSalesLead_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSalesLeadTabTags()
        {
            try
            {
                tabPageGeneralInfo.Tag = DB_FORM_IDs.SALES_LEAD_GENERAL_INFO; //SALES LEAD FOMR ID
                tabPageSuspect.Tag = DB_FORM_IDs.SALES_LEAD_SUSPECT_INFO; // SALES ENQUIRY FORM ID
                tabPageAttachement.Tag = DB_FORM_IDs.SALES_LEAD_ATTACHMENTS;
                tabPageScheduledCalls.Tag = DB_FORM_IDs.SALES_LEAD_SCHEDULE_CALLS;
                tabPageAssociate.Tag = DB_FORM_IDs.SALES_LEAD_ASSOCIATES;

                tabPageGeneralInfo.Visible = tabPageGeneralInfo.Visible = tabPageSuspect.Visible = tabPageAttachement.Visible = tabPageScheduledCalls.Visible = tabPageAssociate.Visible = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::SetSalesLeadTabTags", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSalesLeadTabAsPerPermission()
        {
            try
            {
                foreach (KryptonPage tabSelected in tabSalesLead.Pages)
                {
                    if (tabSelected.Tag != null)
                    {
                        WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)tabSelected.Tag).FirstOrDefault();
                        if (model != null)
                        {
                            tabSelected.Visible = model.CanView;
                            if (tabSelected.Visible)
                            {
                                switch ((DB_FORM_IDs)model.FormID)
                                {
                                    case DB_FORM_IDs.SALES_LEAD_GENERAL_INFO: InitializeLeadMasterInfoControl(); break;
                                    case DB_FORM_IDs.SALES_LEAD_SUSPECT_INFO: InitializeSuspectInfoControl(); break;
                                    case DB_FORM_IDs.SALES_LEAD_ATTACHMENTS: InitializeAttachmentInfoControl(); break;
                                    case DB_FORM_IDs.SALES_LEAD_SCHEDULE_CALLS: InitializeSchedulerInfoControl(); break;
                                    case DB_FORM_IDs.SALES_LEAD_ASSOCIATES: InitializeAssociatesInfoControl(); break;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::SetSalesLeadTabAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int statusID = _UNIT.SalesLeadService.GetLeadStatus(this.SelectedLeadID);
                bool readOnly = false;
                if (statusID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusClose].DEFAULT_VALUE) readOnly = true;
                if (statusID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusLost].DEFAULT_VALUE) readOnly = true;
                if (statusID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusConverted].DEFAULT_VALUE) readOnly = true;

                if (readOnly)
                    btnEditLead.Enabled = btnDeleteLead.Enabled = btnGenerateRevision.Enabled = ButtonEnabled.False;
                else
                    btnEditLead.Enabled = btnDeleteLead.Enabled = btnGenerateRevision.Enabled = ButtonEnabled.True;
                switch (this.SelectedTAB)
                {
                    case DB_FORM_IDs.SALES_LEAD_GENERAL_INFO:
                        if (_ctrlGeneralDetails == null) return;
                        _ctrlGeneralDetails.SelectedLeadID = this.SelectedLeadID;
                        _ctrlGeneralDetails.ReadOnly = readOnly;
                        _ctrlGeneralDetails.PopulateLeadMasterInfo();
                        this.SelectedLeadNumber = _ctrlGeneralDetails.lblLeadApprovalInfo.Text;
                        break;
                    case DB_FORM_IDs.SALES_LEAD_SUSPECT_INFO:
                        if (_ctrlSuspectInfo == null) return;
                        _ctrlSuspectInfo.SelectedID = this.SelectedLeadID;
                        _ctrlSuspectInfo.ReadOnly = readOnly;
                        _ctrlSuspectInfo.PopulateSuspectInfoControls();
                        break;
                    case DB_FORM_IDs.SALES_LEAD_ATTACHMENTS:
                        if (_ctrlSalesLeadAttachment == null) return;
                        _ctrlSalesLeadAttachment.SelectedEntityID = this.SelectedLeadID;
                        _ctrlSalesLeadAttachment.ReadOnly = readOnly;
                        _ctrlSalesLeadAttachment.PopulateDocuments();
                        break;
                    case DB_FORM_IDs.SALES_LEAD_SCHEDULE_CALLS:
                        if (_ctrlScheduler == null) return;
                        _ctrlScheduler.SOURCE_ENTITY_ID = this.SelectedLeadID;
                        _ctrlScheduler.ReadOnly = readOnly;
                        _ctrlScheduler.PopulateAllSchedules();
                        break;
                    case DB_FORM_IDs.SALES_LEAD_ASSOCIATES:
                        if (_ctrlAssociates == null) return;
                        _ctrlAssociates.SelectedID = this.SelectedLeadID;
                        _ctrlAssociates.ReadOnly = readOnly;
                        _ctrlAssociates.PopulateAssociatedEmployees();
                        break;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::RefreshTabPage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
         private void InitLeadStatusDropdown()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem() { ID = 0, Description = "All Sales Lead" });
                items.AddRange(_UNIT.MasterService.GetAllLeadStatuses());
                cboLeadStatuses.DataSource = items;
                cboLeadStatuses.ValueMember = "ID";
                cboLeadStatuses.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::InitLeadStatusDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #region SLAES LEAD
        public void PopulateLeads()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                _leadsList = (new ServiceSalesLead()).GetLeadsSelectionList(_SelectedStatus);
                gridLeads.DataSource = _leadsList;
                gridLeads.Columns["ID"].Visible = gridLeads.Columns["IsActive"].Visible = gridLeads.Columns["Code"].Visible = gridLeads.Columns["DescriptionToUpper"].Visible = false;
                kryptonHeaderGroup1.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridLeads.Rows.Count);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageSalesLead::PopulateLeads", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;

        }
        private void gridLeads_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedLeadID = (int)gridLeads.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedLeadNumber = gridLeads.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                this.ParentTABControl.Text= this.SelectedLeadNumber;
                RefreshTabPage();

                //EventArguementModel args = new EventArguementModel();
                //args.Message = this.SelectedLeadNumber;
                //args.ID = this.SelectedLeadID;
                //OnSelectionChanged(args);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesLead::gridLeads_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }
        private void btnAddLead_Click(object sender, EventArgs e)
        {
            frmSalesLead frm = new frmSalesLead();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateLeads();
            }
        }
        private void btnEditSalesLead_Click(object sender, EventArgs e)
        {
            frmSalesLead frm = new frmSalesLead(this.SelectedLeadID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateLeads();
            }

        }
        private void btnDeleteLead_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Sales Lead {0}", this.SelectedLeadID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalesLead()).DeleteSalesLead(this.SelectedLeadID, Program.CURR_USER.EmployeeID))
                        PopulateLeads();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::btnDeleteLead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateLeads();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchLead_Leave(object sender, EventArgs e)
        {
            try
            {
                _filteredList = new BindingList<SelectListItem>(_leadsList.Where(p => p.DescriptionToUpper.Contains(txtSearchLead.Text.ToUpper())).ToList());
                gridLeads.DataSource = _filteredList;
                kryptonHeaderGroup1.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridLeads.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::txtSearchLead_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cboLeadStatuses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _SelectedStatus = ((SelectListItem)cboLeadStatuses.SelectedItem).ID;
                PopulateLeads();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::cboLeadStatuses_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        #endregion

        #region GENERATE REVISION FOR LEAD
        private async void btnGenerateRevision_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                await (new ServiceSalesLead()).GenerateRevision(this.SelectedLeadID, Program.CURR_USER.EmployeeID);
                PopulateLeads();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquity::btnGenerateRevision_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region EVENT HANDLERS
        public event PageSelectionChangedEventHandler SelectionChanged;
        protected virtual void OnSelectionChanged(EventArguementModel e)
        {
            SelectionChanged(this, e);
        }
        #endregion

        private void tabSalesLead_TabClicked(object sender, KryptonPageEventArgs e)
        {
            this.SelectedTAB = (DB_FORM_IDs)((KryptonNavigator)sender).Pages[e.Index].Tag;
            this.RefreshTabPage();
        }
        private void btnShowHideLeads_ButtonSpecPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            splitContainerMain.Panel1Collapsed = (btnShowHideLeads.Checked == ButtonCheckState.Unchecked) ? true : false;
        }

       

       
    }
}
