using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;
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
    public partial class frmSO_WithoutOrder : KryptonForm
    {
        public int SalesOrderID { get; set; }

        public frmSO_WithoutOrder()
        {
            InitializeComponent();
        }
        public frmSO_WithoutOrder(int ID)
        {
            InitializeComponent();
            SalesOrderID = ID;
        }
        private void frmSO_WithoutOrder_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateClientDropDown();
                PopulatePOSourceDropdown();
                PopulateSOStatusDropdown();
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
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::frmSO_WithoutOrder_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cboPOSource.SelectedItem = ((List<SelectListItem>)cboPOSource.DataSource).Where(x => x.ID == model.FK_POSource).FirstOrDefault();
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

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region POPULATE DROPDOWNS  
        public void PopulateClientDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceParties()).GetAllActiveParties("C"));
                cboClient.DataSource = LST;
                cboClient.DisplayMember = "Description";
                cboClient.ValueMember = "ID";

            }
            catch (Exception ex)
            {


                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::PopulateClientDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void PopulatePOSourceDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllPOSources());
                cboPOSource.DataSource = LST;
                cboPOSource.DisplayMember = "Description";
                cboPOSource.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::PopulatePOSourceDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateSOStatusDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceSalesOrder()).GetAllSalesOrderStatuses());
                cboSalesOrderStatus.DataSource = LST;
                cboSalesOrderStatus.DisplayMember = "Description";
                cboSalesOrderStatus.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::PopulateSOStatusDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VALIDATIONS
        private void txtSalesOrderNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(txtSalesOrderNo.Text.Trim()==string.Empty)
                {
                    errorProvider1.SetError(txtSalesOrderNo, "Can't be left blank.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::txtSalesOrderNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::txtMaterialSupplyPoValidDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::txtInstallationServicePoValidDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboPOSource_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboPOSource.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboPOSource, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::cboPOSource_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboSalesOrderStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboSalesOrderStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboSalesOrderStatus, "Invalid Selection");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::cboSalesOrderStatus_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::cboClient_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        private void txtMaterialSupplyPoValidDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int mDays = 0;
                int.TryParse(txtMaterialSupplyPoValidDays.Text, out mDays);
                dtMaterialSupplyPoExpiryDate.Value = dtMaterialSupplyPoDate.Value.AddDays(mDays);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::txtMaterialSupplyPoValidDays_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtInstallationServicePoValidDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int mDays = 0;
                int.TryParse(txtInstallationServicePoValidDays.Text, out mDays);
                dtInstallationServicePoExpiryDate.Value = dtMaterialSupplyPoDate.Value.AddDays(mDays);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::txtInstallationServicePoValidDays_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
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

                model.FK_SalesOrderType = service.SO_TYPE_WITHOUT_ORDER_ID; 
                model.SalesOrderNo = txtSalesOrderNo.Text;
                model.SalesOrderDate = dtSalesOrderDate.Value;
                model.FK_POSource = ((SelectListItem)cboPOSource.SelectedItem).ID;
                model.FK_SalesOrderStatus = ((SelectListItem)cboSalesOrderStatus.SelectedItem).ID;
                model.FK_ClientID = ((SelectListItem)cboClient.SelectedItem).ID;

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
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::txtInstallationServicePoValidDays_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty("C");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateClientDropDown();
                    cboClient.SelectedItem = ((List<SelectListItem>)cboClient.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_WithoutOrder::btnAddClient_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
