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
using appExcelERP.Controls.CommonControls;
using libERP.SERVICES.CRM;
using libERP.MODELS.CRM;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class ControlSalesLeadGeneralDetails : UserControl
    {
        private DB_FORM_IDs SALES_LEAD_FORM_ID = DB_FORM_IDs.SALES_LEAD;
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                btnApproveLead.Visible = !_ReadOnly;
            }
        }
        public int SelectedLeadID { get; set; }
        private ServiceSalesLead _service = null; 

        public ControlSalesLeadGeneralDetails()
        {
            _service = new ServiceSalesLead();
            InitializeComponent();
        
        }
        public ControlSalesLeadGeneralDetails(ServiceSalesLead service)
        {
            InitializeComponent();
            _service = service;
        
        }
        private void ctrlSalesLeadGeneralDetails_Load(object sender, EventArgs e)
        {
        }
        public void PopulateLeadMasterInfo()
        {
            try
            {
                LeadMasterInfoModel _masterInfo = (new ServiceSalesLead()).GetLeadMasterInfo(this.SelectedLeadID);
                if (_masterInfo != null)
                {
                    headerGroupMain.ValuesPrimary.Heading = string.Format("{0} dt. {1}", _masterInfo.LeadNo, _masterInfo.LeadDate.Value.ToString("dd-MM-yyyy"));
                    
                    headerStatus.Text = string.Format("Status : {0}", _masterInfo.LeadStatus.ToUpper());
                    txtStatusDetails.Text = _masterInfo.LeadStatusDescription;
                    lblLeadApprovalInfo.Text = _masterInfo.ApprovedBy;
                    lblLeadApprovalInfo.StateCommon.Back.Color1 = (_masterInfo.IsApproved)? Color.Green : Color.Red;
                    if (!ReadOnly)
                    {
                        WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == this.SALES_LEAD_FORM_ID).FirstOrDefault();
                        if (model != null)
                        {
                            if(model.CanApprove)
                                if (_masterInfo.IsApproved==false)
                                    btnApproveLead.Visible = true;
                                else
                                    btnApproveLead.Visible = false;
                            else
                                btnApproveLead.Visible = false;

                        }
                    }
                    
                    lblLeadName.Text = string.Format("{0}", _masterInfo.LeadName);
                    lblWebSiteEmailId.Text = String.Format("{0}", _masterInfo.WebSite);
                    lblEmailId.Text = string.Format("{0}", _masterInfo.EmailId);
                    lblLedRequirement.Text = string.Format("{0}", _masterInfo.LeadRequirement);
                    lblLeadSource.Text = string.Format("{0}", _masterInfo.LeadSource);
                    
                    lblEstimatedValue.Text = string.Format("{1} {0:0.00}", _masterInfo.EstimatedValue, _masterInfo.EstimatedValueCurrency);

                    lblGeneratedBy.Text = string.Format("{0}", _masterInfo.GeneratedBy);

                    lblAssignedTo.Text = string.Format("{0}", _masterInfo.AssignedTo);
                    lblProjectSector.Text = string.Format("{0}", _masterInfo.ProjectSector);
                                        
                    gridContacts.DataSource = _service.GetContactsForLeadID(this.SelectedLeadID);
                    gridContacts.Columns["Selected"].Visible = gridContacts.Columns["ContactID"].Visible = false;

                    headerGroupMain.ValuesSecondary.Heading = _masterInfo.CreationInfo;
                    headerGroupMain.ValuesSecondary.Description = _masterInfo.ModificationInfo;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlSalesLeadGeneralDetails::PoulateLeadMasterInfo");
            }

        }
       private void btnApproveLead_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = (new ServiceSalesLead()).ApproveLead(this.SelectedLeadID, Program.CURR_USER.EmployeeID);
                PopulateLeadMasterInfo();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesLeadGeneralDetails::btnApproveLead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
