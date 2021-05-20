using appExcelERP.Forms.PMC;
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.PMC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.CRM.SalesOrder
{
    public partial class frmSO_Primary : KryptonForm
    {
        public int SalesOrderID { get; set; }
        public int SelectedQuotationID { get; set; }
        public int SelectedProjectID { get; set; }
        
        public frmSO_Primary()
        {
            InitializeComponent();
        }
        public frmSO_Primary(int soID)
        {
            InitializeComponent();
            this.SalesOrderID = soID;
        }
        private void frmSO_Primary_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateSalesOrderStatus();
                PopulatePOSources();
                PopulateCompaniesDropdown();
                PopulateProjectsDropdown();

                if (this.SalesOrderID == 0)
                {
                    txtSalesOrderNo.Text = (new ServiceSalesOrder()).GenerateNewSalesOrderNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                    dtSalesOrderDate.Value = AppCommon.GetServerDateTime();

                    int statusOpenID = (new ServiceSalesOrder()).SO_STATUS_OPEN_ID;
                    cboSalesOrderStatus.SelectedItem = ((List<SelectListItem>)cboSalesOrderStatus.DataSource).Where(x => x.ID == statusOpenID).FirstOrDefault();
                    cboSalesOrderStatus.Enabled = false;
                }
                else
                {
                    ScatterData();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::frmSalesOrder_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScatterData()
        {
            try
            {
                TBL_MP_CRM_SalesOrder model = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(this.SalesOrderID);
                if (model != null)
                {
                    txtSalesOrderNo.Text = model.SalesOrderNo;
                    dtSalesOrderDate.Value = model.SalesOrderDate;
                    cboPOSources.SelectedItem = ((List<SelectListItem>)cboPOSources.DataSource).Where(x => x.ID == model.FK_POSource).FirstOrDefault();
                    cboSalesOrderStatus.SelectedItem = ((List<SelectListItem>)cboSalesOrderStatus.DataSource).Where(x => x.ID == model.FK_SalesOrderStatus).FirstOrDefault();
                    cboClient.SelectedItem = ((List<SelectListItem>)cboClient.DataSource).Where(x => x.ID == model.FK_ClientID).FirstOrDefault();

                    if (model.MaterialSupplyPONo != null) txtMaterialSupplyPoNo.Text = model.MaterialSupplyPONo;
                    if (model.MaterialSupplyPODate != null) dtMaterialSupplyPoDate.Value = (DateTime)model.MaterialSupplyPODate;
                    if (model.MaterialSupplyPOValidDays != null) txtMaterialSupplyPoValidDays.Text = model.MaterialSupplyPOValidDays.ToString();
                    if (model.MaterialSupplyPOExpiryDate != null) dtInstallationServicePoExpiryDate.Value = (DateTime)model.MaterialSupplyPOExpiryDate;

                    if (model.InstallationServicePONo != null) txtInstallationServicePoNo.Text = model.InstallationServicePONo;
                    if (model.InstallationServicePODate != null) dtInstallationServicePoDate.Value = (DateTime)model.InstallationServicePODate;
                    if (model.InstallationServicePOValidDays != null) txtInstallationServicePoValidDays.Text = model.InstallationServicePOValidDays.ToString();
                    if (model.InstallationServicePOExpiryDate != null) dtInstallationServicePoExpiryDate.Value = (DateTime)model.InstallationServicePOExpiryDate;

                    if (model.FK_QuotationID != null)
                    {
                        txtQuotationNumber.Text = string.Format("{0} dt. {1}", model.TBL_MP_CRM_SalesQuotation.Quotation_No, model.TBL_MP_CRM_SalesQuotation.Quotation_Date.ToString("dd MMM yy"));
                    }
                    if (model.FK_ProjectID != null)
                    {
                        cboProjects.SelectedItem = ((List<SelectListItem>)cboProjects.DataSource).Where(x => x.ID == model.FK_ProjectID).FirstOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region POPULATE DROPDOWNS
        public void PopulateSalesOrderStatus()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceSalesOrder()).GetAllSalesOrderStatuses());
                cboSalesOrderStatus.DataSource =LST ;
                cboSalesOrderStatus.DisplayMember = "Description";
                cboSalesOrderStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::PopulateSalesOrderStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulatePOSources()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllPOSources());
                cboPOSources.DataSource =LST ;
                cboPOSources.DisplayMember = "Description";
                cboPOSources.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::PopulatePOSources", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateCompaniesDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceParties()).GetAllActiveParties("C"));
                cboClient.DataSource = LST;
                cboClient.ValueMember = "ID";
                cboClient.DisplayMember = "Description";


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::PopulateCompaniesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
             }
        private void PopulateProjectsDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceProject()).GetAllProjectsForSelection());
                cboProjects.DataSource = LST;
                cboProjects.ValueMember = "ID";
                cboProjects.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::PopulateProjectsDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateSalesQuotationInfo()
        {
            try
            {
                TBL_MP_CRM_SalesQuotation dbModel = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(this.SelectedQuotationID);
                if (dbModel != null)
                {
                    txtQuotationNumber.Text = string.Format("{0}  dt. {1}", dbModel.Quotation_No, dbModel.Quotation_Date.ToString("dd MMM yyyy"));
                    int clientID = dbModel.FK_Customer_ID;
                    cboClient.SelectedItem = ((List<SelectListItem>)cboClient.DataSource).Where(x => x.ID == clientID).FirstOrDefault();

                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::PopulateSalesQuotationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region validating
        private void txtMaterialSupplyPoValidDays_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMaterialSupplyPoNo.Text.Trim() != string.Empty)
                {
                    if (txtMaterialSupplyPoValidDays.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtMaterialSupplyPoValidDays, "Mandatory");
                        e.Cancel = true;
                        return;
                    }
                    if (!txtMaterialSupplyPoValidDays.Text.All(Char.IsDigit))
                    {
                        errorProvider1.SetError(txtMaterialSupplyPoValidDays, "Enter Digits only [0-9]");
                        e.Cancel = true;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtMaterialSupplyPoValidDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtInstallationServicePoValidDays_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtInstallationServicePoNo.Text.Trim() != string.Empty)
                {
                    if (txtInstallationServicePoValidDays.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtInstallationServicePoValidDays, "Mandatory");
                        e.Cancel = true;
                        return;
                    }
                    if (!txtInstallationServicePoValidDays.Text.All(Char.IsDigit))
                    {
                        errorProvider1.SetError(txtInstallationServicePoValidDays, "Enter Digits only [0-9]");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtInstallationServicePoValidDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPOSources_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboPOSources.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboPOSources, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::cboPOSources_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmSO_Primary::cboClient_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProjects_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (((SelectListItem)cboProjects.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProjects, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::cboProjects_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void headerGroupQuotation_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtQuotationNumber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.SelectedQuotationID == 0)
                {
                    errorProvider1.SetError(txtQuotationNumber, "Select Valid Sales Quotation");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtQuotationNumber_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtMaterialSupplyPoNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMaterialSupplyPoNo.Text.Trim() == string.Empty && txtInstallationServicePoNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtMaterialSupplyPoNo, "Enter PO No., either Material Supply or Installation Service");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtMaterialSupplyPoNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtInstallationServicePoNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMaterialSupplyPoNo.Text.Trim() == string.Empty && txtInstallationServicePoNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtInstallationServicePoNo, "Enter PO No.,  either Material Supply or Installation Service");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtInstallationServicePoNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion


        private void btnSelectSalesQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_ORDER_SELECT_QUOTATION);
                frm.SingleSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.SelectedItems.Count > 0)
                    {
                        SelectedQuotationID = frm.SelectedItems[0].ID;
                        PopulateSalesQuotationInfo();

                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::btnSelectSalesQuotation_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaterialSupplyPoValidDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int noDays = 0;
                int.TryParse(txtMaterialSupplyPoValidDays.Text, out noDays);
                dtMaterialSupplyPoExpiryDate.Value = dtMaterialSupplyPoDate.Value.AddDays(noDays);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtMaterialSupplyPoValidDays_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtInstallationServicePoValidDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int noDays = 0;
                int.TryParse(txtInstallationServicePoValidDays.Text, out noDays);
                dtInstallationServicePoExpiryDate.Value = dtInstallationServicePoDate.Value.AddDays(noDays);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::txtInstallationServicePoValidDays_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectProject_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.ACTIVE_PROJECT);
                frm.SingleSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.SelectedItems.Count > 0)
                    {
                        SelectedProjectID = frm.SelectedItems[0].ID;
                        //PopulateProject();

                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::btnSelectProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditProject frm = new frmAddEditProject();
                frm.selectedBillingClientID = ((SelectListItem)cboClient.SelectedItem).ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SelectedProjectID = frm.ProjectID;
                    PopulateProjectsDropdown();
                    cboProjects.SelectedItem = ((List<SelectListItem>)cboProjects.DataSource).Where(x => x.ID == this.SelectedProjectID).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::btnAddNewProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_CRM_SalesOrder model = null;
            ServiceSalesOrder service = new ServiceSalesOrder();
            try
            {
                errorProvider1.Clear();
                if (!this.ValidateChildren()) return;
                               
                if (this.SalesOrderID == 0)
                    model = new TBL_MP_CRM_SalesOrder();
                else
                    model = service.GetSalesOrderDBInfoByID(this.SalesOrderID);

                model.FK_SalesOrderType = service.SO_TYPE_PRIMARY_ID;
                model.SalesOrderNo = txtSalesOrderNo.Text;
                model.SalesOrderDate = dtSalesOrderDate.Value;
                model.FK_POSource = ((SelectListItem)cboPOSources.SelectedItem).ID;
                model.FK_SalesOrderStatus = ((SelectListItem)cboSalesOrderStatus.SelectedItem).ID;
                model.FK_ClientID = ((SelectListItem)cboClient.SelectedItem).ID;
                model.FK_QuotationID = this.SelectedQuotationID;
                model.FK_ProjectID= ((SelectListItem)cboProjects.SelectedItem).ID;
                model.IsActive = true;

                if (txtMaterialSupplyPoNo.Text.Trim() != string.Empty)
                {
                    model.MaterialSupplyPONo = txtMaterialSupplyPoNo.Text.Trim();
                    model.MaterialSupplyPODate = dtMaterialSupplyPoDate.Value;
                    model.MaterialSupplyPOValidDays = int.Parse(txtMaterialSupplyPoValidDays.Text.Trim());
                    model.MaterialSupplyPOExpiryDate = dtMaterialSupplyPoExpiryDate.Value;
                }
                else
                {
                    model.MaterialSupplyPONo = null;
                    model.MaterialSupplyPODate = null;
                    model.MaterialSupplyPOValidDays = null;
                    model.MaterialSupplyPOExpiryDate = null;
                }

                if (txtInstallationServicePoNo.Text.Trim() != string.Empty)
                {
                    model.InstallationServicePONo = txtInstallationServicePoNo.Text.Trim();
                    model.InstallationServicePODate = dtInstallationServicePoDate.Value;
                    model.InstallationServicePOValidDays = int.Parse(txtInstallationServicePoValidDays.Text.Trim());
                    model.InstallationServicePOExpiryDate = dtInstallationServicePoExpiryDate.Value;
                }
                else
                {
                    model.InstallationServicePONo = null;
                    model.InstallationServicePODate = null;
                    model.InstallationServicePOValidDays = null;
                    model.InstallationServicePOExpiryDate = null;
                }

                if (this.SalesOrderID == 0)
                {
                    model.CreatedBy = Program.CURR_USER.EmployeeID;
                    model.CreatedDate = AppCommon.GetServerDateTime();
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.FK_YearID = Program.CURR_USER.FinYearID;
                    this.SalesOrderID = service.AddNewSalesOrder(model);
                }
                else
                {
                    model.ModifiedBy = Program.CURR_USER.EmployeeID;
                    model.ModifiedDate = AppCommon.GetServerDateTime();
                    service.UpdateSalesOrder(model);
                }

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty("C");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCompaniesDropdown();
                    cboClient.SelectedItem = ((List<SelectListItem>)cboClient.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::btnAddNewCustomer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

    }

}
