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
using libERP.MODELS;using appExcelERP.Controls.CommonControls;
using libERP;
using libERP.SERVICES.CRM;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class ControlSalesEnquiryGeneralDetails : UserControl
    {
        private DB_FORM_IDs SALES_ENQUIRY_FORM_ID = DB_FORM_IDs.SALES_ENQUIRY;
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                btnApproveEnquiry.Visible = !_ReadOnly;
            }
        }

        public int SelectedEnquiryID { get; set; }

        ServiceSalesEnquiry _service = new ServiceSalesEnquiry();

        public ControlSalesEnquiryGeneralDetails()
        {
            InitializeComponent();
        }
        public ControlSalesEnquiryGeneralDetails(ServiceSalesEnquiry service)
        {
            InitializeComponent();
            _service = service;
        }
        private void ctrlSalesEnquiryGeneralDetail_Load(object sender, EventArgs e)
        {

        }
        private void DoBlanks()
        {
            try
            {
                txtLeadInfo.Text = txtDescription.Text =
                txtEnquiryInfo.Text = txtEnquiryDueDate.Text = txtEnquiryGeneratedBy.Text = txtGeneratedByName.Text =
                 txtEnquirySource.Text = txtSubmissionMode.Text = txtEnquiryStatus.Text = txtDescription.Text = txtProjectSector.Text = string.Empty;

                txtProjectName.Text = txtProjectValue.Text = txtProjectStatus.Text = txtProjectCountry.Text = txtProjectState.Text = txtProjectCity.Text = "";

                headerBottom.Values.Heading = headerBottom.Values.Description = string.Empty;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryGeneralDetails::DoBlanks", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        public void PoulateEnquiryMasterInfo()
        {
            try
            {
                DoBlanks();
                TBL_MP_CRM_SalesEnquiry _masterInfo = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(SelectedEnquiryID);
                ServiceMASTERS _masterService = new ServiceMASTERS();
                if (_masterInfo != null)
                {
                    txtLeadInfo.Text = "--";
                    if (_masterInfo.TBL_MP_CRM_SM_SalesLead != null)
                    {
                        txtLeadInfo.Text = string.Format("{0} dt. {1}", _masterInfo.TBL_MP_CRM_SM_SalesLead.LeadNo, _masterInfo.TBL_MP_CRM_SM_SalesLead.LeadDate.ToString("dd MMM yyyy"));
                    }

                    txtEnquiryInfo.Text = string.Format("{0}  dt. {1}", _masterInfo.SalesEnquiry_No, _masterInfo.SalesEnquiry_Date.ToString("dd MMM yyyy hh:mmtt"));

                    if (_masterInfo.Enquiry_Due_Date!=null)
                        txtEnquiryDueDate.Text= string.Format("{0}", _masterInfo.Enquiry_Due_Date.Value.ToString("dd MMM yyyy"));

                    txtEnquiryGeneratedBy.Text = (_masterInfo.Enquiry_Genrated_By == "R") ? "REFERENCE" : ((_masterInfo.Enquiry_Genrated_By == "A") ? "AGENT" : "EMPLOYEE");
                    txtGeneratedByName.Text = _masterInfo.Enquiry_Genrated_By_Name;
                    if (_masterInfo.FK_Userlist_EnquirySource_ID != 0)
                        txtEnquirySource.Text = _masterService.GetAllSalesEnquirySources().Where(x => x.ID == _masterInfo.FK_Userlist_EnquirySource_ID).FirstOrDefault().Description.ToUpper();
                    else
                        txtEnquirySource.Text = "--";

                    if (_masterInfo.FK_Userlist_Submission_Mode_ID != 0)
                        txtSubmissionMode.Text = _masterService.GetAllSalesEnquirySubmissionMode().Where(x => x.ID == _masterInfo.FK_Userlist_Submission_Mode_ID).FirstOrDefault().Description.ToUpper();
                    else
                        txtSubmissionMode.Text = "--";

                    if (_masterInfo.FK_Userlist_Enquiry_Status_ID != 0)
                        txtEnquiryStatus.Text = _masterService.GetAllSalesEnquiryStatuses().Where(x => x.ID == _masterInfo.FK_Userlist_Enquiry_Status_ID).FirstOrDefault().Description.ToUpper();
                    else
                        txtEnquiryStatus.Text = "--";
                    headerStatus.Text = string.Format("Status : {0}", txtEnquiryStatus.Text.ToUpper());
                    if (_masterInfo.FK_Userlist_Enquiry_Status_ID != Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.EnquiryStatusOpen].DEFAULT_VALUE)
                    {
                        txtStatusDetails.Text = _masterInfo.ReasonClose;
                    }
                    else
                    {
                        txtStatusDetails.Text = string.Empty;
                    }

                    txtDescription.Text = _masterInfo.General_Description;
                    if (_masterInfo.FK_AssignedTo != 0)
                        txtAssignedTo.Text = ServiceEmployee.GetEmployeeNameByID(_masterInfo.FK_AssignedTo);
                    else
                        txtAssignedTo.Text = "--";

                    if (_masterInfo.FK_Userlist_ProjectType_ID != 0)
                        txtProjectSector.Text = _masterService.GetAllProjectSectors().Where(x => x.ID == _masterInfo.FK_Userlist_ProjectType_ID).FirstOrDefault().Description.ToUpper();
                    else
                        txtProjectSector.Text = "--";

                    txtProjectName.Text = _masterInfo.Project_Name;
                    txtProjectValue.Text = string.Format("{0:0.00}", _masterInfo.Project_Value);

                    if (_masterInfo.FK_Userlist_ProjectStatus_ID != 0)
                        txtProjectStatus.Text = _masterService.GetAllProjectStatuses().Where(x => x.ID == _masterInfo.FK_Userlist_ProjectStatus_ID).FirstOrDefault().Description.ToUpper();
                    else
                        txtProjectStatus.Text = "--";

                    if (_masterInfo.FK_Userlist_Project_SubType_ID != 0)
                        txtProjectSubType.Text = _masterService.GetAllProjectTypes().Where(x => x.ID == _masterInfo.FK_Userlist_Project_SubType_ID).FirstOrDefault().Description.ToUpper();
                    else
                        txtProjectSubType.Text = "--";


                    if (_masterInfo.FK_Project_Country_ID != null)
                    { 
                        if (_masterInfo.FK_Project_Country_ID != 0)
                            txtProjectCountry.Text = _masterService.GetAllCountries().Where(x => x.ID == _masterInfo.FK_Project_Country_ID).FirstOrDefault().Description.ToUpper();
                        else
                            txtProjectCountry.Text = "--";
                    }
                    if (_masterInfo.FK_Project_State_ID != null)
                    {
                        if (_masterInfo.FK_Project_State_ID != 0)
                            txtProjectState.Text = _masterService.GetAllStatesForCountry((int)_masterInfo.FK_Project_Country_ID).Where(x => x.ID == _masterInfo.FK_Project_State_ID).FirstOrDefault().Description.ToUpper();
                        else
                            txtProjectState.Text = "--";
                    }
                    if (_masterInfo.FK_Project_City_ID != null)
                    {
                        if (_masterInfo.FK_Project_City_ID != 0)
                            txtProjectCity.Text = _masterService.GetAllCitiesForState((int)_masterInfo.FK_Project_State_ID).Where(x => x.ID == _masterInfo.FK_Project_City_ID).FirstOrDefault().Description.ToUpper();
                        else
                            txtProjectCity.Text = "--";
                    }

                    if (_masterInfo.FK_PreparedBy != null)
                    {
                        string strPreparedByName = ServiceEmployee.GetEmployeeNameByID((int)_masterInfo.FK_PreparedBy);
                        headerBottom.Values.Heading = string.Format("Created : {0} {1}", strPreparedByName, _masterInfo.CreatedDatetime.Value.ToString("dd MMM yyyy hh:mmtt"));
                    }
                    if(_masterInfo.LastModifiedBy!=null)
                    { 
                        string strModifiedByName = ServiceEmployee.GetEmployeeNameByID((int)_masterInfo.LastModifiedBy);
                        headerBottom.Values.Description = string.Format("Modified : {0} {1}", strModifiedByName, _masterInfo.LastModifiedDate.Value.ToString("dd MMM yyyy hh:mmtt"));
                    }

                    if (_masterInfo.FK_ApprovedBy == null)
                    {
                        lblEnquiryApprovalInfo.Text = "UN-APPROVED";
                        lblEnquiryApprovalInfo.StateCommon.Back.Color1 = Color.Red;
                    }
                    else
                    {
                        lblEnquiryApprovalInfo.Text = string.Format("APPROVED : {0}", ServiceEmployee.GetEmployeeNameByID((int)_masterInfo.FK_ApprovedBy));
                        lblEnquiryApprovalInfo.StateCommon.Back.Color1 = Color.Green;
                    }

                    if (!ReadOnly)
                    {
                        WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == this.SALES_ENQUIRY_FORM_ID).FirstOrDefault();
                        if (model != null)
                        {
                            if (model.CanApprove)
                                if (_masterInfo.FK_ApprovedBy == null)
                                    btnApproveEnquiry.Visible = true;
                                else
                                    btnApproveEnquiry.Visible = false;
                            else
                                btnApproveEnquiry.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlSalesEnquiryGeneralDetails::PoulateEnquiryMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnApproveEnquiry_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                bool res = (new ServiceSalesEnquiry()).ApproveEnquiry(this.SelectedEnquiryID, Program.CURR_USER.EmployeeID);
                PoulateEnquiryMasterInfo();
                btnApproveEnquiry.Visible = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryGeneralDetails::btnApproveEnquiry_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
