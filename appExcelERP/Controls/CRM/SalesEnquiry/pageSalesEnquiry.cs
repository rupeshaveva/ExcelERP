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
using libERP.SERVICES.MASTER;
using appExcelERP.Forms.CRM.SalesEnquiry;

namespace appExcelERP.Controls.CRM
{
    public partial class pageSalesEnquiry : UserControl
    {
        public int FormOperationID { get; set; }
        
        public ServiceSalesEnquiry _service = null;
        BindingList<SelectListItem> _EnquiryList = null;
        BindingList<SelectListItem> _filteredList = null;
        
        private int _EnquiryStatus = 0;
        public DB_FORM_IDs SelectedTAB { get; set; }
        public KryptonPage ParentTABControl { get; set; }

        public int SelectedEnquiryID { get; set; }
        public string SelectedEnquiryNumber { get; set; }

        #region CUSTOM CONTROLS FOR EACH TAB
        ControlSalesEnquiryGeneralDetails _ctrlGeneralDetails = null;
        private void InitializeEnquiryMasterInfoControl()
        {
            _ctrlGeneralDetails = new ControlSalesEnquiryGeneralDetails();
            tabPageGeneralInfo.Controls.Add(_ctrlGeneralDetails);
            _ctrlGeneralDetails.Dock = DockStyle.Fill;
        }

        ControlSalesEnquiryClientIDetails _ctrlClientDetails = null;
        private void InitializeClientDetailsControl()
        {
            _ctrlClientDetails = new ControlSalesEnquiryClientIDetails();
            tabPageClientDetail.Controls.Add(_ctrlClientDetails);
            _ctrlClientDetails.Dock = DockStyle.Fill;
        }

        ctrlAssociates _ctrlAssociates = null;
        private void InitializeAssociatesInfoControl()
        {
            tabPageAssociates.Controls.Clear();
            _ctrlAssociates = new ctrlAssociates(APP_ENTITIES.SALES_ENQUIRY);
            tabPageAssociates.Controls.Add(_ctrlAssociates);
            _ctrlAssociates.Dock = DockStyle.Fill;
        }

        ctrlScheduleCallLog _ctrlScheduler = null;
        private void InitializeSchedulerInfoControl()
        {
            tabPageScheduledCalls.Controls.Clear();
            _ctrlScheduler = new ctrlScheduleCallLog(APP_ENTITIES.SALES_ENQUIRY);
            tabPageScheduledCalls.Controls.Add(_ctrlScheduler);
            _ctrlScheduler.Dock = DockStyle.Fill;
        }


        ctrlAttachments _ctrlAttachment = null;
        private void InitializeAttachmentInfoControl()
        {
            _ctrlAttachment = new ctrlAttachments(APP_ENTITIES.SALES_ENQUIRY);
            _ctrlAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
            tabPageAttachment.Controls.Add(_ctrlAttachment);
            _ctrlAttachment.Dock = DockStyle.Fill;
        }

        // converted info a seperate form 
        //ControlSalesEnquiryDesignBOQ _ctrlDesignBOQ = null;
        //private void InitializeBOQInfoControl()
        //{

        //    _ctrlDesignBOQ = new ControlSalesEnquiryDesignBOQ();
        //    tabPageBOQ.Controls.Add(_ctrlDesignBOQ);
        //    _ctrlDesignBOQ.Dock = DockStyle.Fill;
        //    _ctrlDesignBOQ.ENTITY = APP_ENTITIES.SALES_ENQUIRY;
            
        //}
        #endregion

        //ctrlTermsAndCondition _ctrlTermsAndConditions = null;
        //private void InitializeTermsAndConditionsInfoControl()
        //{
        //    tabPageTermAndConditions.Controls.Clear();
        //    _ctrlTermsAndConditions = new ctrlTermsAndCondition(APP_ENTITIES.SALES_ENQUIRY);
        //    tabPageTermAndConditions.Controls.Add(_ctrlTermsAndConditions);
        //    _ctrlTermsAndConditions.Dock = DockStyle.Fill;
        //}

        public pageSalesEnquiry()
        {
            InitializeComponent();
            _service = new ServiceSalesEnquiry();
        }
        private void pageSalesEnquiry_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SetSalesEnquiryTabTags();
                SetSalesEnquiryTabAsPerPermission();
                if(_ctrlGeneralDetails!=null ) this.SelectedTAB = (DB_FORM_IDs)tabPageGeneralInfo.Tag;

                PopulateSalesEnquiryStatus();
                
                _EnquiryStatus = ((SelectListItem)cboEnquiryStatus.SelectedItem).ID;
                PopulateSalesEnquiry();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::pageSalesEnquiry_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
            
            
        }
        private void pageSalesEnquiry_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Width * .2);
        }

        private void SetSalesEnquiryTabTags()
        {
            try
            {
                tabPageGeneralInfo.Tag = DB_FORM_IDs.SALES_ENQUIRY_GENERAL_INFO; //SALES LEAD FOMR ID
                tabPageClientDetail.Tag = DB_FORM_IDs.SALES_ENQUIRY_CLIENT_INFO; // SALES ENQUIRY FORM ID
                tabPageAttachment.Tag = DB_FORM_IDs.SALES_ENQUIRY_ATTACHMENTS;
                tabPageAssociates.Tag = DB_FORM_IDs.SALES_ENQUIRY_ASSOCIATES;
                tabPageScheduledCalls.Tag = DB_FORM_IDs.SALES_ENQUIRY_SCHEDULE_CALL;
                tabPageGeneralInfo.Visible = tabPageClientDetail.Visible =  tabPageAttachment.Visible = tabPageAssociates.Visible = tabPageScheduledCalls.Visible= false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageCRMLanding::SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSalesEnquiryTabAsPerPermission()
        {
            try
            {
                WhosWhoModel model = null;
                foreach (KryptonPage tabSelected in tabSalesEnquiry.Pages)
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
                                    case DB_FORM_IDs.SALES_ENQUIRY_GENERAL_INFO: InitializeEnquiryMasterInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ENQUIRY_CLIENT_INFO:  InitializeClientDetailsControl(); break;
                                    case DB_FORM_IDs.SALES_ENQUIRY_ATTACHMENTS:  InitializeAttachmentInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ENQUIRY_ASSOCIATES:   InitializeAssociatesInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ENQUIRY_SCHEDULE_CALL: InitializeSchedulerInfoControl(); break;
                                }
                            }
                            
                        }
                    }
                }

                // SET SHOW BOQ BUTTON VISIBILITY AS PER PERMISSION
                model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.SALES_ENQUIRY_DESIGN_BOQ).FirstOrDefault();
                btnShowBOQ.Visible = model.CanView;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageCRMLanding::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
            bool readOnly = !(new ServiceSalesEnquiry()).IsEnquiryStatusOPEN(this.SelectedEnquiryID);
            if (readOnly)
                btnEditEnquiry.Enabled = btnDeleteEnquiry.Enabled = btnGenerateRevision.Enabled = btnShowBOQ.Enabled= ButtonEnabled.False;
            else
                btnEditEnquiry.Enabled = btnDeleteEnquiry.Enabled = btnGenerateRevision.Enabled = btnShowBOQ.Enabled = ButtonEnabled.True;
            switch (this.SelectedTAB)
            {
                case DB_FORM_IDs.SALES_ENQUIRY_GENERAL_INFO:
                    if (_ctrlGeneralDetails == null) return;
                    _ctrlGeneralDetails.SelectedEnquiryID = this.SelectedEnquiryID;
                    _ctrlGeneralDetails.ReadOnly = readOnly;
                    _ctrlGeneralDetails.PoulateEnquiryMasterInfo();
                    break;
                case DB_FORM_IDs.SALES_ENQUIRY_CLIENT_INFO:
                    if (_ctrlClientDetails == null) return;
                    _ctrlClientDetails.SelectedEnquiryID = this.SelectedEnquiryID;
                    _ctrlClientDetails.ReadOnly = readOnly;
                    _ctrlClientDetails.PopulateClientAndConsultantInfo(); break;
               
                case DB_FORM_IDs.SALES_ENQUIRY_ATTACHMENTS:
                    if (_ctrlAttachment == null) return;
                    _ctrlAttachment.SelectedEntityID = this.SelectedEnquiryID;
                    _ctrlAttachment.ReadOnly = readOnly;
                    _ctrlAttachment.PopulateDocuments();
                    break;
                case DB_FORM_IDs.SALES_ENQUIRY_SCHEDULE_CALL:
                    if (_ctrlScheduler == null) return;
                    _ctrlScheduler.SOURCE_ENTITY_ID = this.SelectedEnquiryID;
                    _ctrlScheduler.ReadOnly = readOnly;
                    _ctrlScheduler.PopulateAllSchedules();
                    break;
                case DB_FORM_IDs.SALES_ENQUIRY_ASSOCIATES:
                    if (_ctrlAssociates == null) return;
                    _ctrlAssociates.SelectedID = this.SelectedEnquiryID;
                    _ctrlAssociates.ReadOnly = readOnly;
                    _ctrlAssociates.PopulateAssociatedEmployees();
                    break;
            }

            
        }

        private void PopulateSalesEnquiryStatus()
        {
            List<SelectListItem> lst= (new ServiceMASTERS()).GetAllSalesEnquiryStatuses();
            lst.Add(new SelectListItem() { ID = 0, Description = "(ALL)" });
            lst = lst.OrderBy(x => x.Description).ToList();
            cboEnquiryStatus.DataSource = lst;
            cboEnquiryStatus.DisplayMember = "Description";
            cboEnquiryStatus.ValueMember = "ID";
        }
        private void btnProjects_Click(object sender, EventArgs e)
        {
            frmSalesLead frm = new frmSalesLead();
            frm.ShowDialog();
        }

        public void PopulateSalesEnquiry()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _EnquiryList = (new ServiceSalesEnquiry()).GetSalesEnquirySelectionList(_EnquiryStatus);
                gridSalesEnquires.DataSource = _EnquiryList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesEnquiry::PopulateSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void gridSalesEnquires_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridSalesEnquires.Columns["ID"].Visible = gridSalesEnquires.Columns["IsActive"].Visible = gridSalesEnquires.Columns["Code"].Visible = gridSalesEnquires.Columns["DescriptionToUpper"].Visible = false;
                headerGroupSalesEnquiryList.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridSalesEnquires.Rows.Count);
                if (gridSalesEnquires.Rows.Count == 0)
                {
                    splitContainerMain.Panel2.Enabled = false;
                    btnEditEnquiry.Enabled = btnDeleteEnquiry.Enabled = ButtonEnabled.False;
                }
                else
                {
                    splitContainerMain.Panel2.Enabled = true;
                    btnEditEnquiry.Enabled = btnDeleteEnquiry.Enabled = ButtonEnabled.True;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesEnquiry::gridSalesEnquires_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchEnquiry_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _filteredList = new BindingList<SelectListItem>(_EnquiryList.Where(p => p.DescriptionToUpper.Contains(txtSearchEnquiry.Text.ToUpper())).ToList());
                gridSalesEnquires.DataSource = _filteredList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageSalesEnquiry::txtSearchEnquiry_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;

            
        }
        private void gridSalesEnquires_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.SelectedEnquiryID = (int)gridSalesEnquires.Rows[e.RowIndex].Cells["ID"].Value;
                    this.SelectedEnquiryNumber = gridSalesEnquires.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                    this.ParentTABControl.Text = this.SelectedEnquiryNumber;

                    btnGenerateRevision.Visible= (new ServiceSalesEnquiry()).IsEnquiryStatusOPEN(this.SelectedEnquiryID);
                    this.RefreshTabPage();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::gridSalesEnquires_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddEnquiry_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.Cursor = Cursors.Default;
                frmSalesEnquiry frm = new frmSalesEnquiry();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalesEnquiry();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnAddEnquiry_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
           
        }
        private void btnEditLead_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                frmSalesEnquiry frm = new frmSalesEnquiry(this.SelectedEnquiryID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalesEnquiry();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnEditLead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

            
        }
        private void btnDeleteEnquiry_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Sales Enquiry {0}", this.SelectedEnquiryID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalesEnquiry()).DeleteSalesEnquiry(this.SelectedEnquiryID, Program.CURR_USER.EmployeeID))
                        PopulateSalesEnquiry();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnDeleteEnquiry_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGenerateRevision_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new ServiceSalesEnquiry()).GenerateRevision(this.SelectedEnquiryID);
                PopulateSalesEnquiry();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnGenerateRevision_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateSalesEnquiry();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #region EVENT HANDLERS
        public event PageSelectionChangedEventHandler SelectionChanged;
        protected virtual void OnSelectionChanged(EventArguementModel e)
        {
            SelectionChanged(this, e);
        }
        #endregion

        private void cboEnquiryStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboEnquiryStatus.SelectedItem != null)
                {
                    _EnquiryStatus = ((SelectListItem)cboEnquiryStatus.SelectedItem).ID;

                    PopulateSalesEnquiry();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::cboEnquiryStatus_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnShowHideList_ButtonSpecPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                //MessageBox.Show(string.Format("{0} : {1}", e.PropertyName, btnShowHideList.Checked));
                splitContainerMain.Panel1Collapsed = (btnShowHideList.Checked == ButtonCheckState.Unchecked) ? true : false;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnShowHideList_ButtonSpecPropertyChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void tabSalesEnquiry_TabClicked(object sender, KryptonPageEventArgs e)
        {
            try
            {
                this.SelectedTAB = (DB_FORM_IDs)((KryptonNavigator)sender).Pages[e.Index].Tag;
                this.RefreshTabPage();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::tabSalesEnquiry_TabClicked", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnShowBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                frmBOQ frm = new frmBOQ();
                frm.SelectedEntity = APP_ENTITIES.SALES_ENQUIRY;
                frm.SelectedEntityID = this.SelectedEnquiryID;
                frm.Show();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesEnquiry::btnShowBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
