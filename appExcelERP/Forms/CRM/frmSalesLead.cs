using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using libERP;
using libERP.MODELS;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES;
 
using appExcelERP.Forms.UserList;
using libERP.MODELS.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmSalesLead : KryptonForm
    {
        private ServiceUOW _UNIT = null;
        TBL_MP_CRM_SM_SalesLead model = null;


        public int SelectedLeadID { get; set; }
        public int SelectedPartyID { get; set; }

        int closeStatusID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusClose].DEFAULT_VALUE;
        int lostStatusID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusLost].DEFAULT_VALUE;


        public frmSalesLead()
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
        }
        public frmSalesLead( int id)
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            this.SelectedLeadID = id;
        }

        #region POPULATE DROPDOWNS 
        private void PopulateLeadStatusDropDown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            LST.AddRange((new ServiceMASTERS()).GetAllLeadStatuses());
            cboSalesLeadStatus.DataSource = LST;
            cboSalesLeadStatus.DisplayMember = "Description";
            cboSalesLeadStatus.ValueMember = "Id";
        }
        private void PopulateCompaniesDropdown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID =0, Description ="(Select)" });
            LST.AddRange((new ServiceParties()).GetAllActiveParties("C"));
            cboCompanies.DataSource = LST;
            cboCompanies.ValueMember = "ID";
            cboCompanies.DisplayMember = "Description";
        }
        private void PopulateLeadSourceDropdown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            LST.AddRange((new ServiceMASTERS()).GetAllActiveLeadSources());
            cboLeadSources.DataSource = LST ;
            cboLeadSources.ValueMember = "ID";
            cboLeadSources.DisplayMember = "Description";
        }
        private void PopulateAssignedToDropdown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            LST.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
            cboAssignedTo.DataSource = LST;
            cboAssignedTo.DisplayMember = "Description";
            cboAssignedTo.ValueMember = "Id";
        }
        private void PopulateProjectSectorDropdown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            LST.AddRange((new ServiceMASTERS()).GetAllProjectSectors());
            cboProjectSector.DataSource = LST ;
            cboProjectSector.DisplayMember = "Description";
            cboProjectSector.ValueMember = "Id";
        }
        private void PopulateCurrencyDropdown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            LST.AddRange((new ServiceMASTERS()).GetAllCurrencies());
            cboCurrency.DataSource = LST;
            cboCurrency.DisplayMember = "Description";
            cboCurrency.ValueMember = "Id";
        }
        private void PopulateAgenciesDropdown()
        {
            List<SelectListItem> LST = new List<SelectListItem>();
            LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            LST.AddRange((new ServiceParties()).GetAllParties("A"));
            cboAgencies.DataSource = LST ;
            cboAgencies.DisplayMember = "Description";
            cboAgencies.ValueMember = "Id";
        }
        #endregion  
        private void frmSalesLead_Load(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPaletteMode = Program.CURRENT_THEME;

            PopulateLeadStatusDropDown();
            PopulateCompaniesDropdown();
            PopulateLeadSourceDropdown();
            PopulateAssignedToDropdown();
            PopulateProjectSectorDropdown();
            PopulateCurrencyDropdown();
            PopulateAgenciesDropdown();


            DoBlank();

            if (this.SelectedLeadID == 0)
            {
                txtLeadNumber.Text = _UNIT.SalesLeadService.GenerateNewSalesLeadNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                SetDefaultNew();
                cboSalesLeadStatus.Enabled = false;
            }
            else
                ScatterData();

        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string IDs = string.Empty;
            string strMessage = string.Empty;
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    
                    if(!GatherData()) return;
                    bool result = false;
                    Cursor = Cursors.WaitCursor;
                    if (this.SelectedLeadID == 0)
                    {
                        model.FK_YearID = Program.CURR_USER.FinYearID;
                        model.FK_BranchID = Program.CURR_USER.BranchID;
                        model.FK_CompanyID = Program.CURR_USER.CompanyID;
                        model.FK_LeadGeneratedBy = Program.CURR_USER.EmployeeID;
                       
                        

                        this.SelectedLeadID = _UNIT.SalesLeadService.AddNewSalesLead(model);
                        if (this.SelectedLeadID > 0)
                        {
                            strMessage = string.Format("Created Sales Lead {0} ID: {1}\n", model.LeadNo, this.SelectedLeadID);
                            result = true;
                            //GENERATE NOTIFICATION FOR THE USER TO WHOME THIS LEAD IS ASSIGNED
                            string bodyText = string.Format("You are associated with a sales Lead\n{0} {1}", model.LeadName, model.LeadNo);
                            _UNIT.NotificationService.GenerateNotificationFor(APP_ENTITIES.SALES_LEAD, SelectedLeadID, (int)model.FK_LeadAssignTo, "Lead assigned", bodyText);
                            _UNIT.NotificationService.GenerateNotificationFor(APP_ENTITIES.SALES_LEAD, SelectedLeadID, (int)model.FK_LeadGeneratedBy, "Lead assigned", bodyText);
                            model.IsActive = true;
                            strMessage += string.Format("Generated Notification for GeneratedBy & AssignedTo\n");
                        }
                    }
                    else
                    {
                        model.LastModifiedDate = AppCommon.GetServerDateTime();
                        model.FK_LastModifiedBy = Program.CURR_USER.EmployeeID;
                        result = _UNIT.SalesLeadService.UpdateSalesLeadMasterInfo(model);
                        strMessage = string.Format("Modified Sales Lead {0} \n", model.LeadNo, this.SelectedLeadID);
                    }
                    
                    if (result)
                    {
                        IDs = string.Empty;
                        // UPDATE CONTACTS FOR THE SALES LEAD 
                        foreach (DataGridViewRow row in gridContacts.Rows)
                        {
                            if ((bool)row.Cells["Selected"].Value)
                            {
                                IDs += row.Cells["ContactID"].Value.ToString() + Program.DefaultStringSeperator;
                            }
                        }
                        IDs = IDs.TrimEnd(Program.DefaultStringSeperator);
                        if (IDs.Trim() != String.Empty)
                        {
                            _UNIT.SalesLeadService.UpdateContactReferences(IDs, SelectedLeadID);
                            strMessage += string.Format("Contact References added to Lead\n", model.LeadNo);
                        }
                        
                        _UNIT.SalesLeadService.UpdateContactNamesInSalesLeadMaster(IDs, SelectedLeadID);


                        //GENERATOR & ASSIGNEE OF THIS LEAD TO BE ADDED INTO ASSOCIATION TABLE
                        IDs = string.Format("{0}{1}{2}", model.FK_LeadGeneratedBy, Program.DefaultStringSeperator, model.FK_LeadAssignTo);
                        _UNIT.SalesLeadService.AssociateEmployees(IDs, SelectedLeadID);
                        strMessage += string.Format("GeneratedBy & AssignedTo are added as Associates for Lead {0}\n", model.LeadNo);

                        

                        //SENDING EMAIL TO ASSIGNE EMPLOYEE
                        result = await _UNIT.SalesLeadService.SendLeadCreationEmail(this.SelectedLeadID);
                        strMessage += string.Format("Sent Updated Lead information to the assigned Employee\n", model.LeadNo);

                        result = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesLead::Save_Click");
            }
        }

        public void ScatterData()
        {
            try
            {
                model = _UNIT.SalesLeadService.GetLeadMasterDBInfo(this.SelectedLeadID);
                if (model != null)
                {
                    txtLeadNumber.Text = model.LeadNo;
                    dtLeadDate.Value = model.LeadDate;

                    txtLeadRequirements.Text = model.LeadRequirement;
                    txtGeneratedBy.Text = ServiceEmployee.GetEmployeeNameByID((int)model.FK_LeadGeneratedBy);
                    cboAssignedTo.SelectedItem = ((List<SelectListItem>)cboAssignedTo.DataSource).Where(x => x.ID == model.FK_LeadAssignTo).FirstOrDefault();

                    cboSalesLeadStatus.SelectedItem = ((List<SelectListItem>)cboSalesLeadStatus.DataSource).Where(x => x.ID == model.FK_Status).FirstOrDefault();
                    if (model.FK_Status == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusClose].DEFAULT_VALUE)
                    {
                        txtReasonLost.Text = model.ReasonClose;
                        tabPageLeadCloseReason.Visible = true;
                    }

                    cboCompanies.SelectedItem = ((List<SelectListItem>)cboCompanies.DataSource).Where(x => x.ID == model.FK_PartyID).FirstOrDefault();
                    //scatter lead contacts
                    this.SelectedPartyID = ((SelectListItem)cboCompanies.SelectedItem).ID;
                    PopulateContactsGrid();
                    List<SelectContactModel> lstContacts = _UNIT.SalesLeadService.GetContactsForLeadID(this.SelectedLeadID);
                    if (lstContacts != null)
                    {
                        foreach (SelectContactModel contact in (List<SelectContactModel>)gridContacts.DataSource)
                        {
                            SelectContactModel found = lstContacts.Where(x => x.ContactID == contact.ContactID).FirstOrDefault();
                            if (found != null)
                            {
                                contact.Selected = true;
                            }
                        }
                    }
                    
                    cboLeadSources.SelectedItem = ((List<SelectListItem>)cboLeadSources.DataSource).Where(x => x.ID == model.FK_LeadSource).FirstOrDefault();
                    if (model.FK_LeadSource == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadSourceAgency].DEFAULT_VALUE)
                    {
                        cboAgencies.SelectedItem = ((List<SelectListItem>)cboAgencies.DataSource).Where(x => x.ID == model.FK_AgentID).FirstOrDefault();
                        cboAgencies.Enabled = btnAddAgency.Enabled = true;
                    }
                    else
                        cboAgencies.Enabled = btnAddAgency.Enabled = false;

                    if (model.EstimatedValue != null)
                    {
                        txtEstimatedValue.Text = string.Format("{0:0.00}", model.EstimatedValue);
                        cboCurrency.SelectedItem = ((List<SelectListItem>)cboCurrency.DataSource).Where(x => x.ID == model.FK_EstimatedCurrency).FirstOrDefault();
                    }
                    else
                        txtEstimatedValue.Text = string.Empty;

                    cboProjectSector.SelectedItem = ((List<SelectListItem>)cboProjectSector.DataSource).Where(x => x.ID == model.FK_ProjectType).FirstOrDefault();

                    txtLeadRequirements.Text = model.LeadRequirement;
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool GatherData()
        {
            bool result = false;
            try
            {
                if (this.SelectedLeadID == 0)
                {
                    model = new TBL_MP_CRM_SM_SalesLead();
                }
                else
                    model = _UNIT.SalesLeadService.GetLeadMasterDBInfo(this.SelectedLeadID);

                if (model == null) { MessageBox.Show("Cannot create Lead Master Object"); return false; }

                model.LeadNo = txtLeadNumber.Text.ToString();
                model.LeadDate = dtLeadDate.Value;
                if (model.LeadDate == null)
                {
                    MessageBox.Show("Select a valid Date of Lead creation", "GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (cboCompanies.SelectedItem != null)
                {
                    model.FK_PartyID = (int)cboCompanies.SelectedValue;
                    Tbl_MP_Master_Party party = _UNIT.PartiesService.GetPartyByPartyID((int)cboCompanies.SelectedValue);
                    if (party != null)
                    {
                        model.LeadName = party.PartyName;
                        model.LeadEmailID = party.EmailID;
                        model.LeadWebsite = party.Website;
                    }
                }
                else
                {
                    MessageBox.Show("Select a valid Company and its Contacts to continue", "GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                model.LeadRequirement = txtLeadRequirements.Text;

                if (txtEstimatedValue.Text.Trim() != string.Empty)
                {
                    model.EstimatedValue = Convert.ToDecimal(txtEstimatedValue.Text);
                    model.FK_EstimatedCurrency = (int)cboCurrency.SelectedValue;
                }
                else
                {
                    model.EstimatedValue = null;
                }
                
                if (cboAssignedTo.SelectedItem != null)
                    model.FK_LeadAssignTo = (int)cboAssignedTo.SelectedValue;
                else
                    model.FK_LeadAssignTo = null;
                if (model.FK_LeadAssignTo == null)
                {
                    MessageBox.Show("Select a valid Assignee for this Lead", "GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (cboProjectSector.SelectedItem != null)
                    model.FK_ProjectType = (int)cboProjectSector.SelectedValue;
                else
                    model.FK_ProjectType = null;


                model.FK_Status = (int)cboSalesLeadStatus.SelectedValue;
                if (model.FK_Status == closeStatusID || model.FK_Status== lostStatusID)
                {
                    model.ReasonClose = txtReasonLost.Text;
                }

                model.FK_LeadSource = (int)cboLeadSources.SelectedValue;
                if (model.FK_LeadSource != null)
                {
                    if (model.FK_LeadSource == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadSourceAgency].DEFAULT_VALUE)
                    {
                        model.FK_AgentID = (int)cboAgencies.SelectedValue;
                        if (model.FK_AgentID == null)
                        {
                            MessageBox.Show("Select a valid Agency/Consultant of Lead", "GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select a valid Source of Lead", "GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::GatherData",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return result;
        }
        public void DoBlank()
        {
            try
            {

                txtLeadNumber.Text = string.Empty;
                txtLeadRequirements.Text = string.Empty;
                txtEstimatedValue.Text = string.Empty;
                cboSalesLeadStatus.SelectedIndex = 0;
                cboProjectSector.SelectedIndex = 0;
                cboLeadSources.SelectedIndex = 0;

                cboAssignedTo.SelectedIndex = 0;
                gridContacts.DataSource = null;
                tabPageLeadCloseReason.Visible = false;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "frmSalesLead::DoBlank", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void SetDefaultNew()
        {
            try
            {
                int leadStatusOpen = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.DefaultLeadStatusID].DEFAULT_VALUE;
                int currID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.DefaultCurrencyID].DEFAULT_VALUE;
                cboAgencies.Enabled = btnAddAgency.Enabled = false;
                cboSalesLeadStatus.SelectedItem = ((List<SelectListItem>)cboSalesLeadStatus.DataSource).Where(x => x.ID == leadStatusOpen).FirstOrDefault();
                cboCurrency.SelectedItem = ((List<SelectListItem>)cboCurrency.DataSource).Where(x => x.ID == currID).FirstOrDefault();
                txtGeneratedBy.Text = ServiceEmployee.GetEmployeeNameByID(Program.CURR_USER.EmployeeID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::SetDefaultNew", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    
         #region VALIDATIONS
        private void cboCompanies_Validating(object sender, CancelEventArgs e)
        {
            
                int selID = ((SelectListItem)cboCompanies.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboCompanies, "Company Name is Mandatory");
                    e.Cancel = true;
                }

            
        }
        private void cboSalesLeadStatus_Validating(object sender, CancelEventArgs e)
        {
           
                int selID = ((SelectListItem)cboSalesLeadStatus.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboSalesLeadStatus, " leads Status is Mandatory");
                    e.Cancel = true;
                }

           
        }
        private void cboLeadSources_Validating(object sender, CancelEventArgs e)
        {
           
                int selID = ((SelectListItem)cboLeadSources.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboLeadSources, "Leads Source is Mandatory");
                    e.Cancel = true;
                }

            
        }
        private void cboProjectSector_Validating(object sender, CancelEventArgs e)
        {
           
                int selID = ((SelectListItem)cboProjectSector.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboProjectSector, "Project Sector is Mandatory");
                    e.Cancel = true;
                }

        }
        private void cboAssignedTo_Validating(object sender, CancelEventArgs e)
        {
            int selID = ((SelectListItem)cboAssignedTo.SelectedItem).ID;
            if (selID == 0)
            {
                errorProvider1.SetError(cboAssignedTo, "Assigned To Name is Mandatory");
                e.Cancel = true;
            }
        }
        private void gridContacts_Validating(object sender, CancelEventArgs e)
        {
            bool isSelected = false;
            foreach (DataGridViewRow row in gridContacts.Rows)
            {
                if ((bool)row.Cells["Selected"].Value == true)
                {
                    isSelected = true;
                }
            }
            if (!isSelected)
            {
                errorProvider1.SetError(gridContacts, "Select atleast one Contact for this Lead");
                e.Cancel = true;
            }
        }
        private void txtEstimatedValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtEstimatedValue.Text.Trim() != string.Empty)
                {
                    double val = 0;
                    double.TryParse(txtEstimatedValue.Text, out val);
                }
            }
            catch (Exception )
            {
                errorProvider1.SetError(txtEstimatedValue, "Not a valid Value.");
                e.Cancel = true;
            }

        }
        #endregion

        private void PopulateContactsGrid()
        {
            try
            {
                gridContacts.DataSource = _UNIT.ContactService.GetContactsOfPartyForSelection(this.SelectedPartyID);
                gridContacts.Columns["ContactID"].Visible = false;
                gridContacts.Columns["Selected"].Width = (int)(gridContacts.Width * .1);
                gridContacts.Columns["Description1"].Width = (int)(gridContacts.Width * .5);
                gridContacts.Columns["Description2"].Width = (int)(gridContacts.Width * .4);
                gridContacts.Columns["Description1"].DefaultCellStyle.WrapMode = gridContacts.Columns["Description2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::PopulateContactsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedPartyID = ((SelectListItem)cboCompanies.SelectedItem).ID;
                PopulateContactsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::cboCompanies_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridContacts.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridContacts.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "frmSalesLead::gridContacts_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty("C");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCompaniesDropdown();
                    cboCompanies.SelectedItem = ((List<SelectListItem>)cboCompanies.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::btnAddNewCompany_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnAddNewContact_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmContact frm = new frmContact();
                frm.PartyID = this.SelectedPartyID;
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateContactsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesLead::btnAddNewContact_Click_1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnAddLeadSource_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.Text = "Add new Source of Lead";
                frm.MASTERCategoryID = (int)APP_ADMIN_CATEGORIES.LEAD_SOURCE;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateLeadSourceDropdown();
                    cboLeadSources.SelectedItem = ((List<SelectListItem>)cboLeadSources.DataSource).Where(x => x.ID == frm.MASTERCategoryID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnAddLeadSource_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAddProjectSector_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.Text = "Add new Project Sector";
                frm.MASTERCategoryID = (int)APP_ADMIN_CATEGORIES.PROJECT_SECTOR;
                // frm.Text = string.Format("Add New {0} Value", _SelectedMasterCategoryName);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateProjectSectorDropdown();
                    cboProjectSector.SelectedItem = ((List<SelectListItem>)cboProjectSector.DataSource).Where(x => x.ID == frm.MASTERCategoryID).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnAddProjectSector_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void cboLeadSources_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboAgencies.Enabled = btnAddAgency.Enabled = false;
                SelectListItem selItem = (SelectListItem)cboLeadSources.SelectedItem;
                if (selItem != null)
                {
                    if (selItem.ID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadSourceAgency].DEFAULT_VALUE)
                    {
                        cboAgencies.DataSource = _UNIT.PartiesService.GetAllParties("A");
                        cboAgencies.DisplayMember = "Description";
                        cboAgencies.ValueMember = "ID";

                        cboAgencies.Enabled = btnAddAgency.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cboLeadSources_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void txtReasonLost_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int statusOfLead = (int)cboSalesLeadStatus.SelectedValue;
                if (statusOfLead == closeStatusID || statusOfLead == lostStatusID)
                {
                    if (txtReasonLost.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(kryptonNavigator1, tabPageLeadCloseReason.Text + " is mandatory");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtReasonLost_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
       
        private void cboSalesLeadStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int statusOfLead = (int)cboSalesLeadStatus.SelectedValue;
               
                if (statusOfLead == closeStatusID || statusOfLead == lostStatusID)
                {
                    tabPageLeadCloseReason.Visible = true;
                    tabPageLeadCloseReason.Text = "Reason for " + ((statusOfLead == closeStatusID) ? " Closing Lead" : " Loosing Lead");
                }
                else
                    tabPageLeadCloseReason.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cboSalesLeadStatus_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddAgency_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty("A");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAgenciesDropdown();
                    cboAgencies.SelectedItem = ((List<SelectListItem>)cboAgencies.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnAddAgency_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
