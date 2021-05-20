using libERP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmSalesQuotation : KryptonForm
    {
        public int SalesQuotationID { get; set; }
        public int SelectedSalesEnquiryID { get; set; }
        public int STATUS_OPEN_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.QuotationStatusOpen].DEFAULT_VALUE;
        public int STATUS_LOST_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.QuotationStatusLost].DEFAULT_VALUE;
        public int STATUS_CONVERTED_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.QuotationStatusConverted].DEFAULT_VALUE;
        public int STATUS_CLOSED_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.QuotationStatusClose].DEFAULT_VALUE;
        public int STATUS_INPROCESS_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.QuotationStatusInProcess].DEFAULT_VALUE;
        public int STATUS_HOLD_ID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.QuotationStatusHold].DEFAULT_VALUE;
        
        public frmSalesQuotation()
        {

            InitializeComponent();
        
        }
        public frmSalesQuotation(int id)
        {
            InitializeComponent();
            this.SalesQuotationID = id;
        }
        private void frmQuotation_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateSalesQuotationsStatusDropDown();
                PopulateQuotationPriorityDropDown();
                PopulateSalesRepresentativeDropdown();
                PopulateBOQRepresentativeDropdown();
                PopulateProjectSectorDropDowns();
                PopulateCustomersDropdown();

                tabPageQuotationCloseReason.Visible = false;
                if (this.SalesQuotationID == 0)
                    SetDefaultNew();
                else
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::frmQuotation_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_CRM_SalesQuotation objQuote = null;
            ServiceSalesQuotation _serviceQuote = null;
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    _serviceQuote = new ServiceSalesQuotation(); ;
                    if (this.SalesQuotationID == 0)
                    {
                        objQuote = new TBL_MP_CRM_SalesQuotation();
                        objQuote.PK_Quotation_ID = 0;
                        objQuote.FK_YearID = Program.CURR_USER.FinYearID;
                        objQuote.FK_BranchID = Program.CURR_USER.BranchID;
                        objQuote.FK_CompanyID = Program.CURR_USER.CompanyID;
                        objQuote.Quotation_No = txtQuotationNumber.Text.ToUpper().Trim();
                        //objQuote.Quotation_No = _serviceQuote.GenerateNewSalesQuotationNumber(objQuote.FK_YearID,objQuote.FK_BranchID,objQuote.FK_CompanyID);
                    }
                    else
                        objQuote = _serviceQuote.GetSalesQuotationMasterDBInfo(this.SalesQuotationID);

                    // GATHER DATA
                    objQuote.Quotation_Date = dtQuotationDate.Value;
                    objQuote.FK_Userlist_Quotation_Status_ID = ((SelectListItem)cboQuotationStatus.SelectedItem).ID;
                    objQuote.Quotation_ValidDays = int.Parse(txtQuotationValidDays.Text);
                    objQuote.FK_Userlist_Priority_ID = ((SelectListItem)cboQuotationPriority.SelectedItem).ID;
                    objQuote.FK_RepresentativeID = ((SelectListItem)cboSalesRepresentative.SelectedItem).ID;
                    objQuote.FK_BOQRepresentativeID = ((SelectListItem)cboBOQRepresentative.SelectedItem).ID;
                    objQuote.FK_Sales_Enquiry_ID = this.SelectedSalesEnquiryID;
                    objQuote.FK_Customer_ID = ((SelectListItem)cboClient.SelectedItem).ID;
                    objQuote.Project_Name = txtProjectName.Text.Trim();
                    objQuote.FK_Project_City_ID = ((SelectListItem)cboProjectLocation.SelectedItem).ID;
                    objQuote.FK_Userlist_ProjectSector_ID = ((SelectListItem)cboProjectSector.SelectedItem).ID;
                    
                    objQuote.Remarks = txtRemarks.Text;
                    objQuote.ReasonClose = txtReasonClosedLost.Text;

                    if (this.SalesQuotationID == 0)
                    {
                        this.SalesQuotationID = _serviceQuote.AddNewQuotation(objQuote);
                        _serviceQuote.GenerateDefaultsFromSalesEnquiryIntoSalesQuotation(this.SelectedSalesEnquiryID, SalesQuotationID);
                    }
                    else
                    {
                        objQuote.LastModifiedBy = Program.CURR_USER.EmployeeID;
                        objQuote.LastModifiedDate = AppCommon.GetServerDateTime();
                        _serviceQuote.UpdateSalesQuotation(objQuote);
                    }
                        
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region POPULATE ALL DROPDOWNS
        private void PopulateSalesQuotationsStatusDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceSalesQuotation()).GetAllActiveQuotationStatusesList());
                cboQuotationStatus.DataSource = LST;
                cboQuotationStatus.DisplayMember = "Description";
                cboQuotationStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateSalesQuotationsStatusDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateQuotationPriorityDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceSalesQuotation()).GetAllActiveQuotationPriorityList());
                cboQuotationPriority.DataSource = LST;
                cboQuotationPriority.DisplayMember = "Description";
                cboQuotationPriority.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateQuotationPriorityDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateProjectSectorDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllProjectSectors());
                cboProjectSector.DataSource = LST;
                cboProjectSector.DisplayMember = "Description";
                cboProjectSector.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateProjectSectorDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateSalesRepresentativeDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
                cboSalesRepresentative.DataSource = LST;
                cboSalesRepresentative.DisplayMember = "Description";
                cboSalesRepresentative.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateSalesRepresentativeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void PopulateBOQRepresentativeDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
                cboBOQRepresentative.DataSource = LST;
                cboBOQRepresentative.DisplayMember = "Description";
                cboBOQRepresentative.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateBOQRepresentativeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateCitiesDropdown(int stateID)
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllCitiesForState(stateID));
                cboProjectLocation.DataSource = LST;
                cboProjectLocation.DisplayMember = "Description";
                cboProjectLocation.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateCitiesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateCustomersDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceParties()).GetAllActiveParties("C"));
                cboClient.DataSource =LST ;
                cboClient.DisplayMember = "Description";
                cboClient.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateCustomersDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        #endregion


        #region SCATTER/GATHER
        public void SetDefaultNew()
        {
            try
            {
                this.Text = "SALES QUOTATION (ADD NEW)";
                //txtQuotationNumber.Text = (new ServiceSalesQuotation()).GenerateNewSalesQuotationNumber(Program.CURR_USER.FinYearID,Program.CURR_USER.BranchID,Program.CURR_USER.CompanyID );
                txtQuotationNumber.Text = string.Empty;
                txtEnquiryNumber.Text= txtProjectName.Text = String.Empty;
                dtQuotationDate.Value = AppCommon.GetServerDateTime();
                cboQuotationStatus.SelectedItem = ((List<SelectListItem>)cboQuotationStatus.DataSource).Where(x => x.ID == STATUS_OPEN_ID).FirstOrDefault();
                cboQuotationStatus.Enabled = false;
                tabPageQuotationCloseReason.Visible = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::SetDefaultNew", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ScatterData()
        {
            if (this.SalesQuotationID == 0) return;
            try
            {
                string strMessage = string.Empty;
                TBL_MP_CRM_SalesQuotation model = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(this.SalesQuotationID);
                if (model != null)
                {
                    this.Text = "SALES QUOTATION (EDIT)";
                    txtQuotationNumber.Text = model.Quotation_No;
                    txtQuotationNumber.ReadOnly = true;
                    dtQuotationDate.Value = model.Quotation_Date;
                    txtQuotationValidDays.Text = model.Quotation_ValidDays.ToString();
                    txtQuotationExpiryDate.Text = string.Format("{0}", model.Quotation_Date.AddDays(model.Quotation_ValidDays).ToString("dd MMM yyyy"));

                    cboQuotationStatus.SelectedItem = ((List<SelectListItem>)cboQuotationStatus.DataSource).Where(x => x.ID == model.FK_Userlist_Quotation_Status_ID).FirstOrDefault();
                    cboQuotationPriority.SelectedItem = ((List<SelectListItem>)cboQuotationPriority.DataSource).Where(x => x.ID == model.FK_Userlist_Priority_ID).FirstOrDefault();
                    cboSalesRepresentative.SelectedItem = ((List<SelectListItem>)cboSalesRepresentative.DataSource).Where(x => x.ID == model.FK_RepresentativeID).FirstOrDefault();
                    cboQuotationStatus.SelectNextControl(dtQuotationDate,true,false, false, true);
                    if (cboSalesRepresentative.SelectedItem == null)
                    {
                        string empName = ServiceEmployee.GetEmployeeNameByID(model.FK_RepresentativeID);
                        strMessage += string.Format("\nUnable to locate Employee {0} in active Employees list.",empName );
                        List<SelectListItem> lstemployees= (new ServiceEmployee()).GetAllActiveEmployees();
                        SelectListItem newRep= new SelectListItem() { ID = model.FK_RepresentativeID, Description = empName };
                        lstemployees.Add(newRep);
                        cboSalesRepresentative.DataSource = lstemployees;
                        cboSalesRepresentative.SelectedItem = newRep;
                    }
                    //BOQ REPRESENTATIVE
                    if (model.FK_BOQRepresentativeID > 0)
                    {
                        cboBOQRepresentative.SelectedItem = ((List<SelectListItem>)cboBOQRepresentative.DataSource).Where(x => x.ID == model.FK_BOQRepresentativeID).FirstOrDefault();
                    }

                    this.SelectedSalesEnquiryID = model.FK_Sales_Enquiry_ID;
                    PopulateSelectedSalesEnquiryInfo();
                    TBL_MP_CRM_SalesEnquiry objEnquiry = model.TBL_MP_CRM_SalesEnquiry;
                    if (objEnquiry != null)
                    {
                        txtEnquiryNumber.Text = string.Format("{0} dt. {1}", objEnquiry.SalesEnquiry_No, objEnquiry.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                        txtProjectName.Text = objEnquiry.Project_Name;
                        cboProjectSector.SelectedItem = ((List<SelectListItem>)cboProjectSector.DataSource).Where(x => x.ID == model.FK_Userlist_ProjectSector_ID).FirstOrDefault();
                        PopulateCitiesDropdown((int)objEnquiry.FK_Project_State_ID);
                        cboProjectLocation.SelectedItem = ((List<SelectListItem>)cboProjectLocation.DataSource).Where(x => x.ID == model.FK_Project_City_ID).FirstOrDefault();
                    }
                    Tbl_MP_Master_Party party = model.Tbl_MP_Master_Party;
                    if (party != null)
                    {
                        cboClient.SelectedItem = ((List<SelectListItem>)cboClient.DataSource).Where(x => x.ID == model.FK_Customer_ID).FirstOrDefault();
                        if (cboClient.SelectedItem == null)
                        {
                            strMessage += string.Format("\nUnable to locate Customer {0} in active Customers list.", party.PartyName);
                        }
                    }

                    txtRemarks.Text = model.Remarks;
                    if (model.FK_Userlist_Quotation_Status_ID == this.STATUS_CLOSED_ID || model.FK_Userlist_Quotation_Status_ID == this.STATUS_LOST_ID)
                    {
                        txtReasonClosedLost.Text = model.ReasonClose.ToString();
                        tabPageQuotationCloseReason.Visible = true;
                    }
                    else
                        tabPageQuotationCloseReason.Visible = false;

                    tabRemarks.SelectedPage = tabPageQuotationRemarks;
                    
                    if (strMessage != string.Empty) MessageBox.Show(strMessage);
                    dtQuotationDate.Focus();
                    Application.DoEvents();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GatherData()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesEnquiry::GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        #endregion

        private void btnSelectSalesEnquiries_Click(object sender, EventArgs e)
        {
            frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_ENQUIRY_APPROVED_OPEN);
            frm.SingleSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindingList<MultiSelectListItem> selectedIDs = frm.SelectedItems;
                if (selectedIDs != null)
                {
                    if (selectedIDs.Count > 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        SelectedSalesEnquiryID= selectedIDs[0].ID;
                        PopulateSelectedSalesEnquiryInfo();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }
        #region HELPER METHOD
        private void PopulateSelectedSalesEnquiryInfo()
        {
            try
            {
                TBL_MP_CRM_SalesEnquiry objEnquiry = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(SelectedSalesEnquiryID);
                if (objEnquiry != null)
                {
                    txtEnquiryNumber.Text = string.Format("{0} dt. {1}", objEnquiry.SalesEnquiry_No, objEnquiry.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                    txtProjectName.Text = objEnquiry.Project_Name;
                    cboProjectSector.SelectedItem = ((List<SelectListItem>)cboProjectSector.DataSource).Where(x => x.ID == objEnquiry.FK_Userlist_ProjectType_ID).FirstOrDefault();
                    PopulateCitiesDropdown((int)objEnquiry.FK_Project_State_ID);
                    cboProjectLocation.SelectedItem = ((List<SelectListItem>)cboProjectLocation.DataSource).Where(x => x.ID == objEnquiry.FK_Project_City_ID).FirstOrDefault();
                }
                Tbl_MP_Master_Party party = objEnquiry.Tbl_MP_Master_Party;
                if (party != null)
                {
                    cboClient.SelectedItem = ((List<SelectListItem>)cboClient.DataSource).Where(x => x.ID == objEnquiry.FK_Customer_ID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::PopulateSelectedSalesEnquiryInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion
        #region VALIDATIONS
        private void txtQuotationValidDays_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtQuotationValidDays.Text.Trim()==string.Empty)
                {
                    errorProvider1.SetError(txtQuotationValidDays, "Valid Days is mandatory");
                    e.Cancel = true;
                    return;
                }
                if (!txtQuotationValidDays.Text.All(Char.IsDigit))
                {
                    errorProvider1.SetError(txtQuotationValidDays, "Enter Digits only [0-9]");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::txtQuotationValidDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboSalesRepresentative_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboSalesRepresentative.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboSalesRepresentative, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboSalesRepresentative_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboBOQRepresentative_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBOQRepresentative.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBOQRepresentative, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboBOQRepresentative_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cboQuotationPriority_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboQuotationPriority.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboQuotationPriority, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboQuotationPriority_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboQuotationStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboQuotationStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboQuotationStatus, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboQuotationStatus_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnquiryNumber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtEnquiryNumber.Text.Trim()==string.Empty)
                {
                    errorProvider1.SetError(txtEnquiryNumber, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::txtEnquiryNumber_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProjectName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtProjectName.Text.Trim()== string.Empty)
                {
                    errorProvider1.SetError(txtProjectName, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::txtProjectName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProjectSector_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboProjectSector.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectSector, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboProjectSector_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProjectLocation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboProjectLocation.SelectedItem == null)
                {
                    errorProvider1.SetError(cboProjectLocation, "Invalid Selection");
                    e.Cancel = true;
                    return;
                }
                if (((SelectListItem)cboProjectLocation.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjectLocation, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboProjectLocation_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboClient_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboClient.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboClient, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::cboClient_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtReasonClosedLost_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selstatus = ((SelectListItem)cboQuotationStatus.SelectedItem).ID;
                if (selstatus == STATUS_CLOSED_ID || selstatus == STATUS_LOST_ID)
                {
                    if (txtReasonClosedLost.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtReasonClosedLost, "Invalid Selection");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSalesQuotation::txtReasonClosedLost_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtQuotationValidDays_Leave(object sender, EventArgs e)
        {

            if (txtQuotationValidDays.Text.All(Char.IsDigit))
            {
                txtQuotationExpiryDate.Text = string.Format("{0}", dtQuotationDate.Value.AddDays((int.Parse(txtQuotationValidDays.Text))).ToString("dd MMM yyyy"));
            }
                
        }

        private void cboQuotationStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int statusOfQuotation = (int)cboQuotationStatus.SelectedValue;

                if (statusOfQuotation == this.STATUS_CLOSED_ID || statusOfQuotation == this.STATUS_LOST_ID)
                {
                    tabPageQuotationCloseReason.Visible = true;
                    tabPageQuotationCloseReason.Text = "Reason for " + ((statusOfQuotation == STATUS_CLOSED_ID) ? " Closing Quotation" : " Loosing Quotation");
                }
                else
                    tabPageQuotationCloseReason.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "frmSalesQuotation::cboQuotationStatus_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
