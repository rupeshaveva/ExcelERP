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
using libERP.SERVICES.CRM;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.PMC;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;

namespace appExcelERP.Controls.CRM.SalesOrder
{
    public partial class ControlSalesOrderGeneralInfo : UserControl
    {
        private DB_FORM_IDs SALES_ORDER_FORM_ID = DB_FORM_IDs.SALES_ORDER;
        public int SelectedSalesOrderID { get; set; }
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
               
            }
        }

        public ControlSalesOrderGeneralInfo()
        {
            InitializeComponent();
        }
        private void ControlSalesOrderGeneralInfo_Load(object sender, EventArgs e)
        {

        }
        public void PopulateSalesOrderGeneralInfo()
        {

            this.Cursor = Cursors.WaitCursor;
            ServiceSalesOrder _service = new ServiceSalesOrder();
            try
            {
                //btnApproveSO.Visible = true;
                DoBlanks();
                SelectListItem selItem = null;
                List<SelectListItem> lst = _service.GetAllSalesOrderStatuses();

                TBL_MP_CRM_SalesOrder model = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(SelectedSalesOrderID);
                if (model != null)
                {
                    headerGroupMain.ValuesPrimary.Heading = model.SalesOrderNo;
                  //  lblSOApprovalInfo.Text =model.FK_ApprovedBy.ToString();
                   // lblSOApprovalInfo.StateCommon.Back.Color1 = (model.IsApproved) ? Color.Green : Color.Red;


                    selItem = lst.Where(x => x.ID == model.FK_SalesOrderStatus).FirstOrDefault();
                    txtSOStatus.Text = selItem.Description;

                    lst = (new ServiceMASTERS()).GetAllPOSources();
                    selItem = lst.Where(x => x.ID == model.FK_POSource).FirstOrDefault();
                    txtPOSource.Text = selItem.Description;

                    if (model.MaterialSupplyPONo != null)
                    {
                        txtMaterialSupplyInfo.Text = string.Format("{0} dt. {1}\nfor {2} days till {3}",
                        model.MaterialSupplyPONo,
                        ((DateTime)model.MaterialSupplyPODate).ToString("dd MMM yyyy"),
                        model.MaterialSupplyPOValidDays,
                        ((DateTime)model.MaterialSupplyPOExpiryDate).ToString("dd/MM/yy"));
                    }


                    if (model.InstallationServicePONo != null)
                    {
                        txtInstallationServicesInfo.Text = string.Format("{0} dt. {1}\nfor {2} days till {3}",
                        model.InstallationServicePONo,
                        ((DateTime)model.InstallationServicePODate).ToString("dd MMM yyyy"),
                        model.InstallationServicePOValidDays,
                        ((DateTime)model.InstallationServicePOExpiryDate).ToString("dd/MM/yy"));
                    }
                    if (model.FK_ClientID != null)
                    {
                        txtClientName.Text = String.Format("{0} ({1}) ",
                            model.Tbl_MP_Master_Party.PartyName,
                            model.Tbl_MP_Master_Party.PartyCode);
                    }
                    if (model.FK_QuotationID != null)
                    {
                        txtQuotationInfo.Text = String.Format("{0} dt. {1} ",
                            model.TBL_MP_CRM_SalesQuotation.Quotation_No,
                            model.TBL_MP_CRM_SalesQuotation.Quotation_Date.ToString("dd MMM yyyy"));
                    }

                    if (model.FK_ProjectID != null)
                    {
                        headerProject.Values.Heading = "PROJECT: "+ model.TBL_MP_PMC_ProjectMaster.ProjectNumber;
                        txtProjectName.Text = model.TBL_MP_PMC_ProjectMaster.ProjectName;
                        txtStartDate.Text = model.TBL_MP_PMC_ProjectMaster.StartDate.ToString("dd MMM yyyy");
                        txtEndDate.Text = model.TBL_MP_PMC_ProjectMaster.EndDate.ToString("dd MMM yyyy");
                        ServiceProject serviceProject = new ServiceProject();
                        txtBillingAddress.Text = serviceProject.GetProjectBillingAddress((int)model.FK_ProjectID);
                        txtSiteAddr.Text = serviceProject.GetProjectSiteAddress((int)model.FK_ProjectID);
                    }

                    if (model.FK_ApprovedBy == null)
                    {
                        lblSOApprovalInfo.Text = "UN-APPROVED";
                        lblSOApprovalInfo.StateCommon.Back.Color1 = Color.Red;
                    }
                    else
                    {
                        lblSOApprovalInfo.Text = string.Format("APPROVED : {0}", ServiceEmployee.GetEmployeeNameByID((int)model.FK_ApprovedBy));
                        lblSOApprovalInfo.StateCommon.Back.Color1 = Color.Green;
                    }

                    if (!ReadOnly)
                    {
                        WhosWhoModel modell = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == this.SALES_ORDER_FORM_ID).FirstOrDefault();
                        if (modell != null)
                        {
                            if (modell.CanApprove)
                                if (model.FK_ApprovedBy == null)
                                    btnApproveSO.Visible = true;
                                else
                                    btnApproveSO.Visible = false;
                            else
                                btnApproveSO.Visible = false;
                        }
                    }
                    /*
                     lblSOApprovalInfo.Text = "Unapproved Order";
                     lblSOApprovalInfo.StateCommon.Back.Color1 = (model.FK_ApprovedBy == null) ? Color.Red : Color.Green;
                     WhosWhoModel premission = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.SALES_ORDER).FirstOrDefault();
                     if (premission != null)
                     {
                         if (premission.CanApprove)
                             if (model.FK_ApprovedBy == null)
                                 btnApproveSO.Visible = true;
                             else
                             {
                                 lblSOApprovalInfo.Text = string.Format("Approved: {0}", ServiceEmployee.GetEmployeeNameByID((int)model.FK_ApprovedBy));
                                 btnApproveSO.Visible = false;
                             }
                         else
                             btnApproveSO.Visible = false;
                     }
                     */

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ControlSalesOrderGeneralInfo::PopulateSalesOrderGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void DoBlanks()
        {
            try
            {
                txtBillingAddress.Text =
                txtClientName.Text =
                txtEndDate.Text =
                txtInstallationServicesInfo.Text =
                txtMaterialSupplyInfo.Text =
                txtPOSource.Text =
                txtProjectName.Text =
                txtQuotationInfo.Text =
                txtSiteAddr.Text =
                txtSOStatus.Text =
                txtStartDate.Text = String.Empty;
                lblCreatedBy.Text =
                lblModifiedBy.Text = String.Empty;
               // lblSOApprovalInfo.Text = String.Empty;

            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ControlSalesOrderGeneralInfo::DoBlanks", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnApproveSO_Click(object sender, EventArgs e)
        {
            try
            {
               bool res = (new ServiceSalesOrder()).ApproveOrder(this.SelectedSalesOrderID, Program.CURR_USER.EmployeeID);
              PopulateSalesOrderGeneralInfo();
                btnApproveSO.Visible = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderGeneralInfo::btnApproveSO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
