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
using libERP.SERVICES;
using ComponentFactory.Krypton.Toolkit;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using appExcelERP.Forms.Masters;
using appExcelERP.Forms.MASTER;

namespace appExcelERP.Forms
{
    public partial class frmSalesEnquiry : KryptonForm
    {
        private ServiceUOW _UNIT = null;

        int STATUS_OPEN_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusOpen].DEFAULT_VALUE;
        int STATUS_LOST_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusLost].DEFAULT_VALUE;
        int STATUS_CONVERTED_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusConverted].DEFAULT_VALUE;
        int STATUS_CLOSED_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusClose].DEFAULT_VALUE;

        public int SalesEnquiryID { get; set; }
        public int selectedSalesLeadID { get; set; }
        public int SelectedCountryID { get; set; }
        public int SelectedStateID { get; set; }
        public int SelectedCityID { get; set; }
        public string _EnqGeneratedBy { get; set; }

        public int GeneratorEmployeeID { get; set; }
        public int GeneratorAgentID { get; set; }


        public TBL_MP_CRM_SalesEnquiry EnquiryModel = null;

        public frmSalesEnquiry()
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
        }
        public frmSalesEnquiry(int id)
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            this.SalesEnquiryID = id;
        }

        #region POPULATE ALL DROPDOWNS
        private void PopulateSalesEnquiryTypeDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllSalesEnquiryType());
                cboSalesEnquiryType.DataSource = LST;
                cboSalesEnquiryType.DisplayMember = "Description";
                cboSalesEnquiryType.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateSalesEnquiryTypeDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateSalesEnquirySubmissionModeDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllSalesEnquirySubmissionMode());
                cboSumissionMode.DataSource = LST; 
                cboSumissionMode.DisplayMember = "Description";
                cboSumissionMode.ValueMember = "ID";

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateSalesEnquirySubmissionModeDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateSalesEnquirySourceDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllSalesEnquirySources());
                cboEnquirySource.DataSource = LST;
                cboEnquirySource.DisplayMember = "Description";
                cboEnquirySource.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateSalesEnquirySourceDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void PopulateSalesEnquiryStatusDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllSalesEnquiryStatuses());
                cboEnquiryStatus.DataSource = LST;
                cboEnquiryStatus.DisplayMember = "Description";
                cboEnquiryStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateSalesEnquiryStatusDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateProjectCountriesDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllCountries());
                cboProjectCounty.DataSource =LST;
                cboProjectCounty.DisplayMember = "Description";
                cboProjectCounty.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateProjectCountriesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private void PopulateProjectStatesDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllStatesForCountry(this.SelectedCountryID));
                cboProjectState.DataSource = LST;
                cboProjectState.DisplayMember = "Description";
                cboProjectState.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateProjectStatesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateProjectCitiesDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllCitiesForState(this.SelectedStateID));
                cboProjectCity.DataSource = LST;
                cboProjectCity.DisplayMember = "Description";
                cboProjectCity.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateProjectCitiesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateProjectSectorDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllProjectSectors());
                cboProjectSector.DataSource =LST ;
                cboProjectSector.DisplayMember = "Description";
                cboProjectSector.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateProjectSectorDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateProjectSubTypeDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllProjectTypes());
                cboProjectSubType.DataSource = LST;
                cboProjectSubType.DisplayMember = "Description";
                cboProjectSubType.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateProjectSubTypeDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateProjectStatusDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllProjectStatuses());
                cboProjectStatus.DataSource = LST;
                cboProjectStatus.DisplayMember = "Description";
                cboProjectStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateProjectStatusDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateAssignedToDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
                cboAssignedTo.DataSource =LST ;
                cboAssignedTo.DisplayMember = "Description";
                cboAssignedTo.ValueMember = "Id";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::PopulateAssignedToDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void PopulateSaleLead()
        {
            TBL_MP_CRM_SM_SalesLead model = _UNIT.SalesLeadService.GetLeadMasterDBInfo(this.selectedSalesLeadID);
            txtLead.Text = string.Format("{0} dt. {1}", model.LeadNo, model.LeadDate.ToString("dd-MMMM-yy"));
            tabPageLeadRequirements.Text = string.Format("Party: {0}", model.LeadName);
            txtDescription.Text = string.Format("{0}", model.LeadRequirement);
            txtProjectName.Text = model.LeadName;
            cboProjectSector.SelectedItem = ((List<SelectListItem>)cboProjectSector.DataSource).Where(x => x.ID == model.FK_ProjectType).FirstOrDefault();
            txtProjectValue.Text = string.Format("{0:0.00}",model.EstimatedValue);

            if (model.FK_LeadSource == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadSourceAgency].DEFAULT_VALUE)
            {
                rboAgent.Checked = true; _EnqGeneratedBy = "A"; GeneratorAgentID = (int)model.FK_AgentID;
                txtGeneratdBy.Text = _UNIT.PartiesService.GetPartyNameByPartyID(GeneratorAgentID);
            }
        }
       
        #endregion


        private void frmSalesEnquiry_Load(object sender, EventArgs e)
        {
            try
            {
                tabPageLeadCloseReason.Visible = false;
                PopulateSalesEnquiryTypeDropDowns();
                PopulateSalesEnquirySubmissionModeDropDowns();
                PopulateSalesEnquirySourceDropDowns();
                PopulateSalesEnquiryStatusDropDowns();
                PopulateProjectCountriesDropDowns();
                PopulateProjectSectorDropDowns();
                PopulateProjectSubTypeDropDowns();
                PopulateProjectStatusDropDowns();
                PopulateAssignedToDropdown();
                if (this.SalesEnquiryID == 0)
                {
                    SetDefaultNew();
                }
                else
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::frmSalesEnquiry_Load", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        
        public void SetDefaultNew()
        {
            try
            {
                txtProjectName.Text = String.Empty;
                txtEnquiryNo.Text = _UNIT.SalesEnquiryService.GenerateNewSalesEnquiryNumber(Program.CURR_USER.FinYearID,Program.CURR_USER.BranchID,Program.CURR_USER.CompanyID);
                dtEnquiryDate.Value = AppCommon.GetServerDateTime();
                rboRefrence.Checked = true;
                
                int enquiryOpen = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusOpen].DEFAULT_VALUE;
                cboEnquiryStatus.SelectedItem = ((List<SelectListItem>)cboEnquiryStatus.DataSource).Where(x => x.ID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusOpen].DEFAULT_VALUE).FirstOrDefault();


                cboProjectCounty.SelectedItem = ((List<SelectListItem>)cboProjectCounty.DataSource).Where(x => x.ID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.DefaultCountryID].DEFAULT_VALUE).FirstOrDefault();
                this.SelectedCountryID = ((SelectListItem)cboProjectCounty.SelectedItem).ID;
                PopulateProjectStatesDropDowns();
                int enquirySourceLead = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquirySourceLEAD].DEFAULT_VALUE;
                cboEnquirySource.SelectedItem = ((List<SelectListItem>)cboEnquirySource.DataSource).Where(x => x.ID == Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquirySourceLEAD].DEFAULT_VALUE).FirstOrDefault();
                cboEnquirySource.Enabled = false;
                cboEnquiryStatus.Enabled = false;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::SetDefaultNew", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void ScatterData()
        {
            if (this.SalesEnquiryID == 0) return;
            try
            {
                EnquiryModel = _UNIT.AppDBContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == this.SalesEnquiryID).FirstOrDefault();
                if (EnquiryModel != null)
                {
                    txtEnquiryNo.Text = EnquiryModel.SalesEnquiry_No;
                    dtEnquiryDate.Value = EnquiryModel.SalesEnquiry_Date;
                    dtEnquiryDueDate.Value = EnquiryModel.Enquiry_Due_Date.Value;
                    cboSalesEnquiryType.SelectedItem = ((List<SelectListItem>)cboSalesEnquiryType.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_EnquiryType_ID).FirstOrDefault();
                    cboSumissionMode.SelectedItem = ((List<SelectListItem>)cboSumissionMode.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_Submission_Mode_ID).FirstOrDefault();
                    cboEnquirySource.SelectedItem = ((List<SelectListItem>)cboEnquirySource.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_EnquirySource_ID).FirstOrDefault();
                    cboEnquiryStatus.SelectedItem = ((List<SelectListItem>)cboEnquiryStatus.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_Enquiry_Status_ID).FirstOrDefault();
                    cboAssignedTo.SelectedItem = ((List<SelectListItem>)cboAssignedTo.DataSource).Where(x => x.ID == EnquiryModel.FK_AssignedTo).FirstOrDefault();
                    if (EnquiryModel.FK_Userlist_Enquiry_Status_ID == STATUS_CLOSED_ID || EnquiryModel.FK_Userlist_Enquiry_Status_ID == STATUS_LOST_ID)
                    {
                        EnquiryModel.ReasonClose = txtReasonLost.Text;
                        tabPageLeadCloseReason.Visible = true;
                    }

                    TBL_MP_CRM_SM_SalesLead lead = _UNIT.SalesLeadService.GetLeadMasterDBInfo((int)EnquiryModel.FK_SalesLeadID);
                    if (lead != null)
                    {
                        selectedSalesLeadID = lead.PK_SalesLeadID;
                        PopulateSaleLead();
                    }

                    txtDescription.Text = EnquiryModel.General_Description;
                    txtProjectName.Text = EnquiryModel.Project_Name;
                    SelectedCountryID = (int)EnquiryModel.FK_Project_Country_ID;
                    cboProjectCounty.SelectedItem = ((List<SelectListItem>)cboProjectCounty.DataSource).Where(x => x.ID == SelectedCountryID ).FirstOrDefault();
                    PopulateProjectStatesDropDowns();
                    SelectedStateID = (int)EnquiryModel.FK_Project_State_ID;
                    cboProjectState.SelectedItem = ((List<SelectListItem>)cboProjectState.DataSource).Where(x => x.ID == SelectedStateID).FirstOrDefault();
                    PopulateProjectCitiesDropDowns();
                    SelectedCityID = (int)EnquiryModel.FK_Project_City_ID;
                    cboProjectCity.SelectedItem = ((List<SelectListItem>)cboProjectCity.DataSource).Where(x => x.ID == SelectedCityID).FirstOrDefault();
                    txtProjectValue.Text = string.Format("{0:0.00}", EnquiryModel.Project_Value);
                    cboProjectSector.SelectedItem = ((List<SelectListItem>)cboProjectSector.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_ProjectType_ID).FirstOrDefault();
                    cboProjectSubType.SelectedItem = ((List<SelectListItem>)cboProjectSubType.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_Project_SubType_ID).FirstOrDefault();
                    cboProjectStatus.SelectedItem = ((List<SelectListItem>)cboProjectStatus.DataSource).Where(x => x.ID == EnquiryModel.FK_Userlist_ProjectStatus_ID).FirstOrDefault();


                    
                    switch(EnquiryModel.Enquiry_Genrated_By)
                    {
                        case "R": rboRefrence.Checked = true; break;
                        case "A":rboAgent.Checked = true; GeneratorAgentID = (int)EnquiryModel.FK_EnqGenerated_Agent_ID; break;
                        case "E": rboEmployee.Checked = true; GeneratorEmployeeID = (int)EnquiryModel.FK_EnqGenerated_Employee_ID; break;
                    }
                    _EnqGeneratedBy = EnquiryModel.Enquiry_Genrated_By;
                    txtGeneratdBy.Text = EnquiryModel.Enquiry_Genrated_By_Name;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GatherData()
        {
            try
            {
                if (this.SalesEnquiryID == 0)
                {
                    EnquiryModel = new TBL_MP_CRM_SalesEnquiry();
                    EnquiryModel.SalesEnquiry_No = _UNIT.SalesEnquiryService.GenerateNewSalesEnquiryNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                }
                else
                    EnquiryModel = _UNIT.AppDBContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == this.SalesEnquiryID).FirstOrDefault();

                EnquiryModel.SalesEnquiry_Date = dtEnquiryDate.Value;
                EnquiryModel.Enquiry_Due_Date = dtEnquiryDueDate.Value;
                EnquiryModel.FK_SalesLeadID = this.selectedSalesLeadID;
                
                EnquiryModel.Enquiry_Genrated_By = _EnqGeneratedBy;
                EnquiryModel.Enquiry_Genrated_By_Name = txtGeneratdBy.Text;
                if (rboEmployee.Checked) EnquiryModel.FK_EnqGenerated_Employee_ID = GeneratorEmployeeID;
                if (rboAgent.Checked) EnquiryModel.FK_EnqGenerated_Agent_ID = GeneratorAgentID;
                EnquiryModel.Project_Name = txtProjectName.Text;
                EnquiryModel.General_Description = txtDescription.Text;
                EnquiryModel.FK_Userlist_Enquiry_Status_ID = (int)cboEnquiryStatus.SelectedValue;
                if (EnquiryModel.FK_Userlist_Enquiry_Status_ID == STATUS_CLOSED_ID || EnquiryModel.FK_Userlist_Enquiry_Status_ID == STATUS_LOST_ID)
                {
                    EnquiryModel.ReasonClose = txtReasonLost.Text;
                }
                EnquiryModel.FK_AssignedTo= (int)cboAssignedTo.SelectedValue;
                EnquiryModel.FK_Userlist_ProjectType_ID = (int)cboProjectSector.SelectedValue;
                EnquiryModel.FK_Userlist_Project_SubType_ID = (int)cboProjectSubType.SelectedValue;
                EnquiryModel.FK_Userlist_EnquiryType_ID = (int)cboSalesEnquiryType.SelectedValue;
                EnquiryModel.FK_Userlist_Submission_Mode_ID = (int)cboSumissionMode.SelectedValue;
                EnquiryModel.FK_Userlist_EnquirySource_ID = (int)cboEnquirySource.SelectedValue;
                EnquiryModel.FK_Userlist_ProjectStatus_ID = (int)cboProjectStatus.SelectedValue;
                EnquiryModel.Project_Value = decimal.Parse(txtProjectValue.Text.Trim());
                

                EnquiryModel.FK_Project_Country_ID = (int)cboProjectCounty.SelectedValue;
                EnquiryModel.FK_Project_State_ID = (int)cboProjectState.SelectedValue;
                EnquiryModel.FK_Project_City_ID = (int)cboProjectCity.SelectedValue;

                TBL_MP_CRM_SM_SalesLead lead = _UNIT.SalesLeadService.GetLeadMasterDBInfo(this.selectedSalesLeadID);
                if (lead != null)
                {
                    EnquiryModel.FK_Customer_ID = lead.FK_PartyID;
                    EnquiryModel.Customer_Name = _UNIT.PartiesService.GetPartyNameByPartyID((int)lead.FK_PartyID);
                    //EnquiryModel.Customer_Address] [varchar] (2000) NULL,
                }
                if (this.SalesEnquiryID == 0)
                {
                    EnquiryModel.FK_PreparedBy = Program.CURR_USER.EmployeeID;
                    EnquiryModel.FK_CompanyID = Program.CURR_USER.CompanyID;
                    EnquiryModel.FK_BranchID = Program.CURR_USER.BranchID;
                    EnquiryModel.FK_YearID = Program.CURR_USER.FinYearID;
                    EnquiryModel.IsActive = true;
                    EnquiryModel.CreatedDatetime = AppCommon.GetServerDateTime();
                }
                else
                {
                    EnquiryModel.LastModifiedDate = AppCommon.GetServerDateTime();
                    EnquiryModel.LastModifiedBy = Program.CURR_USER.EmployeeID;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}",ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void cboProjectCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (cboProjectCounty.SelectedItem == null) return;
                this.SelectedCountryID = ((SelectListItem)cboProjectCounty.SelectedItem).ID;
                PopulateProjectStatesDropDowns();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectCounty_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void cboProjectState_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboProjectState.SelectedItem == null) return;
            this.SelectedStateID = ((SelectListItem)cboProjectState.SelectedItem).ID;
            PopulateProjectCitiesDropDowns();
        }
        private void rboRefrence_CheckedChanged(object sender, EventArgs e)
        {
            btnSearchGeneratedBy.Visible = !rboRefrence.Checked;
            if (rboRefrence.Checked) _EnqGeneratedBy = "R";
            GeneratorAgentID = GeneratorEmployeeID = 0;
            txtGeneratdBy.ReadOnly = false;
            txtGeneratdBy.Text = string.Empty;
        }
        private void rboAgent_CheckedChanged(object sender, EventArgs e)
        {
            btnSearchGeneratedBy.Visible = rboAgent.Checked;
            if (rboAgent.Checked) _EnqGeneratedBy = "A";
            GeneratorAgentID = GeneratorEmployeeID = 0;
            txtGeneratdBy.ReadOnly = true;
            txtGeneratdBy.Text = string.Empty;

        }
        private void rboEployee_CheckedChanged(object sender, EventArgs e)
        {
            btnSearchGeneratedBy.Visible = rboEmployee.Checked;
            if (rboEmployee.Checked) _EnqGeneratedBy = "E";
            GeneratorAgentID = GeneratorEmployeeID = 0;
            txtGeneratdBy.ReadOnly = true;
            txtGeneratdBy.Text = string.Empty;
        }
        

        private void btnSearchGeneratedBy_Click(object sender, EventArgs e)
        {
            frmGridMultiSelect frm = null;

            switch (_EnqGeneratedBy)
            {
                case "A":
                    frm = new frmGridMultiSelect(APP_ENTITIES.AGENTS, APP_ENTITIES.none, 0);
                    frm.SingleSelect = true;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        BindingList<MultiSelectListItem> selectedIDs = frm.SelectedItems;
                        if (selectedIDs != null)
                        {
                            this.GeneratorEmployeeID = 0;
                            this.GeneratorAgentID = selectedIDs[0].ID;
                            txtGeneratdBy.Text = _UNIT.PartiesService.GetPartyNameByPartyID(GeneratorAgentID);
                        }
                    }
                    break;
                case "E":
                    frm = new frmGridMultiSelect(APP_ENTITIES.EMPLOYEES, APP_ENTITIES.none, 0);
                    frm.SingleSelect = true;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        BindingList<MultiSelectListItem> selectedIDs = frm.SelectedItems;
                        if (selectedIDs != null)
                        {
                            this.GeneratorEmployeeID = selectedIDs[0].ID;
                            this.GeneratorAgentID = 0;
                            txtGeneratdBy.Text = ServiceEmployee.GetEmployeeNameByID(GeneratorEmployeeID);
                        }
                    }
                    break;
            }
        }
        private void btnSearchLead_Click(object sender, EventArgs e)
        {
            frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_LEAD_APPROVED_OPEN, APP_ENTITIES.none, 0);
            frm.SingleSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindingList<MultiSelectListItem> selectedIDs = frm.SelectedItems;
                if (selectedIDs != null)
                {
                    if(selectedIDs.Count>0)
                    { 
                        selectedSalesLeadID = selectedIDs[0].ID;
                        PopulateSaleLead();
                    }
                }
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    this.Cursor = Cursors.WaitCursor;
                    GatherData();
                    if (this.SalesEnquiryID == 0)
                    {
                        EnquiryModel.FK_YearID = Program.CURR_USER.FinYearID;
                        EnquiryModel.FK_BranchID = Program.CURR_USER.BranchID;
                        EnquiryModel.FK_CompanyID = Program.CURR_USER.CompanyID;

                        this.SalesEnquiryID = _UNIT.SalesEnquiryService.AddNewSalesEnquiry(EnquiryModel);

                        // CHANGE STATUS OF LEAD TO CONVERTED TO ENQUIRY AND SET REMARKS
                        TBL_MP_CRM_SM_SalesLead existingLead = _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == EnquiryModel.FK_SalesLeadID).FirstOrDefault();
                        existingLead.FK_Status = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.LeadStatusConverted].DEFAULT_VALUE;
                        existingLead.ReasonClose = string.Format("Sales Enquiry: {0} dt. {1}", EnquiryModel.SalesEnquiry_No, EnquiryModel.SalesEnquiry_Date.ToString("dd MMM yy hh:mmtt"));
                        _UNIT.AppDBContext.SaveChanges();

                        _UNIT.SalesEnquiryService.GenerateDefaultsFromSalesLeadIntoSalesEnquiry(selectedSalesLeadID, this.SalesEnquiryID);
                        await _UNIT.SalesEnquiryService.SendSalesEnquiryCreationEmail(this.SalesEnquiryID);

                    }
                    else
                    {
                        _UNIT.AppDBContext.SaveChanges();
                    }
                    this.Cursor = Cursors.Default;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSalesEnquiry::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region VALIDATIONS
        private void cboAssignedTo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboAssignedTo.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboAssignedTo, " Assigned name is Invalid");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboAssignedTo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtEnquiryDueDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtEnquiryDueDate.Value <= dtEnquiryDate.Value)
            {
                errorProvider1.SetError(dtEnquiryDueDate, "Due date Cannot be Less than or same as Date of Enquiry");
                e.Cancel = true;
            }
        }
        private void cboSalesEnquiryType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboSalesEnquiryType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboSalesEnquiryType, "Invalid Enquiry Type");
                    e.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboSalesEnquiryType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboSumissionMode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboSumissionMode.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboSumissionMode, "Invalid Mode of Submission of Enquiry");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboSumissionMode_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboEnquirySource_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboEnquirySource.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEnquirySource, "Invalid Enquiry Source");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboEnquirySource_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboEnquiryStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboEnquiryStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEnquiryStatus, "Invalid Enquiry Status");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboEnquiryStatus_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLead_Validating(object sender, CancelEventArgs e)
        {
            if (txtLead.Text.Trim() == string.Empty || this.selectedSalesLeadID == 0)
            {
                errorProvider1.SetError(txtLead, "Invalid Selection");
                e.Cancel = true;
            }
        }
        private void cboProjectCounty_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboProjectCounty.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectCounty, "Invalid Country");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectCounty_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProjectState_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboProjectState.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectState, "Invalid State");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectState_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProjectCity_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(cboProjectCity.SelectedItem==null)
                {
                    errorProvider1.SetError(cboProjectCity, "Invalid City");
                    e.Cancel = true;
                    return;
                }
                if (((SelectListItem)cboProjectCity.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectCity, "Invalid City");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectCity_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProjectType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboProjectSector.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectSector, "Invalid Project Type");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProjectSubType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboProjectSubType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectSubType, " Project Sub Type is Invalid");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectSubType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProjectStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboProjectStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectStatus, "Invalid Project Type");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::cboProjectStatus_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtProjectValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtProjectValue.Text.Trim() != string.Empty)
                {
                    double val = 0;
                    double.TryParse(txtProjectValue.Text, out val);
                }
            }
            catch (Exception)
            {
                errorProvider1.SetError(txtProjectValue, "Not a valid Estimated Value of Project");
                e.Cancel = true;
            }
        }
        private void rboAgent_Validating(object sender, CancelEventArgs e)
        {
            if (rboAgent.Checked)
            {
                if (GeneratorAgentID == 0)
                {
                    errorProvider1.SetError(txtGeneratdBy,"Select a Valid Agent");
                    e.Cancel = true;
                }
            }
        }
        private void rboEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (rboEmployee.Checked)
            {
                if (GeneratorEmployeeID == 0)
                {
                    errorProvider1.SetError(txtGeneratdBy, "Select a Valid Employee");
                    e.Cancel = true;
                }
            }
        }
        private void rboRefrence_Validating(object sender, CancelEventArgs e)
        {
            if (rboRefrence.Checked)
            {
                if (txtGeneratdBy.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtGeneratdBy, "Enter Valid Reference Name");
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCity frm = new frmAddEditCity();
                frm.CountryID = this.SelectedCountryID;
                frm.StateID = this.SelectedStateID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SelectedCityID = frm.CityID;
                    PopulateProjectCitiesDropDowns();
                    cboProjectCity.SelectedItem = ((List<SelectListItem>)cboProjectCity.DataSource).Where(x => x.ID == SelectedCityID).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::btnAddCity_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void cboEnquiryStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int statusOfEnquiry = (int)cboEnquiryStatus.SelectedValue;

                if (statusOfEnquiry == this.STATUS_CLOSED_ID || statusOfEnquiry == this.STATUS_LOST_ID)
                {
                    tabPageLeadCloseReason.Visible = true;
                    tabPageLeadCloseReason.Text = "Reason for " + ((statusOfEnquiry == STATUS_CLOSED_ID) ? " Closing Enquiry" : " Loosing Enquiry");
                }
                else
                    tabPageLeadCloseReason.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "frmSalesEnquiry::cboEnquiryStatus_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtReasonLost_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int statusOfLead = (int)cboEnquiryStatus.SelectedValue;
                if (statusOfLead == STATUS_CLOSED_ID || statusOfLead == STATUS_LOST_ID)
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
                MessageBox.Show(ex.Message, "frmSalesEnquiry::txtReasonLost_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCountry frm = new frmAddEditCountry();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateProjectCountriesDropDowns();
                    SelectedCountryID = frm.CountryID;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::btnAddCountry_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddStateProvince_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditState frm = new frmAddEditState();
                frm.SelectedCountryID = this.SelectedCountryID;
                //   frm.CountryID = this.SelectedCountryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SelectedStateID = frm.StateID;
                    PopulateProjectStatesDropDowns();
                    cboProjectState.SelectedItem = ((List<SelectListItem>)cboProjectState.DataSource).Where(x => x.ID == SelectedStateID).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::btnAddStateProvince_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }

}

