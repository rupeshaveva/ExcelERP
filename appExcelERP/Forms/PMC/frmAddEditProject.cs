
using appExcelERP.Forms.Parties;
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
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

namespace appExcelERP.Forms.PMC
{
    public partial class frmAddEditProject : KryptonForm
    {
        public int ProjectID { get; set; }
        public int selectedBillingClientID { get; set; }
        public int selectedSiteClientID { get; set; }
        public int selectedBillingAddressID = 0;
        public int selectedSiteAddressID = 0;
        
        public frmAddEditProject()
        {
            InitializeComponent();
        }
        public frmAddEditProject(int ID)
        {
            InitializeComponent();
            this.ProjectID = ID;
        }
        private void frmAddEditProject_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateProjectStatus();
                PopulateBillingClients();
                PopulateSiteClients();
                PopulateOurCompanyAddress();
                if (this.ProjectID == 0)
                {
                    //txtProjectNo.Text = (new ServiceProject()).GenerateNewProjectNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                    dtProjectDate.Value = AppCommon.GetServerDateTime();
                    cboProjectStatus.SelectedItem = ((List<SelectListItem>)cboProjectStatus.DataSource).Where(x => x.ID == (new ServiceProject()).PROJECT_STATUS_OPEN).FirstOrDefault();
                    cboProjectStatus.Enabled = false;

                    if (this.selectedBillingClientID != 0)
                    {
                        cboBillingClient.SelectedItem = ((List<SelectListItem>)cboBillingClient.DataSource).Where(x => x.ID == this.selectedBillingClientID).FirstOrDefault();
                        PopulateBillingClientAddresses();
                    }
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
                MessageBox.Show(errMessage, "frmAddEditProject::frmAddEditProject_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void ScatterData()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                TBL_MP_PMC_ProjectMaster model = (new ServiceProject()).GetProjectDBInfoByID(this.ProjectID);
                if (model != null)
                {
                    txtProjectNo.Text = model.ProjectNumber;
                    txtProjectName.Text = model.ProjectName;
                    dtProjectDate.Value = model.ProjectDate;
                    dtProjectStartDate.Value = model.StartDate;
                    dtProjectEndDate.Value = model.EndDate;
                    cboProjectStatus.SelectedItem = ((List<SelectListItem>)cboProjectStatus.DataSource).Where(x => x.ID == model.FK_ProjectStatusID).FirstOrDefault();
                    cboBillingClient.SelectedItem = ((List<SelectListItem>)cboBillingClient.DataSource).Where(x => x.ID == model.BillingClientID).FirstOrDefault();
                    this.selectedBillingClientID = (int)model.BillingClientID;
                    PopulateBillingClientAddresses();
                    foreach (DataGridViewRow row in gridClientBillingAddress.Rows)
                    {
                        if (int.Parse(row.Cells["ID"].Value.ToString()) == model.BillingClientAddressID)
                        {
                            row.Cells["ISActive"].Value = true;
                            this.selectedBillingAddressID = model.BillingClientAddressID;
                        }
                    }

                    cboSiteClient.SelectedItem = ((List<SelectListItem>)cboSiteClient.DataSource).Where(x => x.ID == model.SiteClientID).FirstOrDefault();
                    this.selectedSiteClientID = (int)model.SiteClientID;
                    PopulateSiteClientAddresses();
                    foreach (DataGridViewRow row in gridClientSiteAddress.Rows)
                    {
                        if (int.Parse(row.Cells["ID"].Value.ToString()) == model.SiteClientAddressID)
                        {
                            row.Cells["ISActive"].Value = true;
                            this.selectedSiteAddressID = model.SiteClientAddressID;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::Scatterdata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void PopulateProjectStatus()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceProject()).GetAllProjectStatuses());
                cboProjectStatus.DataSource = LST;
                cboProjectStatus.DisplayMember = "Description";
                cboProjectStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::PopulateProjectStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region BILLING PARTY AND ADDRESS
        private void PopulateBillingClients()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceParties()).GetAllParties("C"));
                cboBillingClient.DataSource = LST;
                cboBillingClient.DisplayMember = "Description";
                cboBillingClient.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::PopulateBillingClients", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboBillingClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.selectedBillingClientID = ((SelectListItem)cboBillingClient.SelectedItem).ID;
                PopulateBillingClientAddresses();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::cboBillingClient_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateBillingClientAddresses()

        {
            try
            {
                gridClientBillingAddress.DataSource = (new ServiceParties()).GetAllPartyAddressesForSelection(this.selectedBillingClientID);
                gridClientBillingAddress.Columns["ID"].Visible =
                gridClientBillingAddress.Columns["Code"].Visible =
                gridClientBillingAddress.Columns["DescriptionToUpper"].Visible = false;
                gridClientBillingAddress.Columns["IsActive"].Width = 50;
                gridClientBillingAddress.Columns["Description"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::PopulateBillingClientAddresses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewBillingClient_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty("C");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBillingClients();
                    cboBillingClient.SelectedItem = ((List<SelectListItem>)cboBillingClient.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::btnAddNewBillingClient_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewBillingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboBillingClient.SelectedItem == null )
                {
                    MessageBox.Show("Select a Valid party to add its Billing address.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int selPartyID = ((SelectListItem)cboBillingClient.SelectedItem).ID;
                if (selPartyID == 0)
                {
                    MessageBox.Show("Select a Valid party to add its Billing address.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmAddEditAddress frm = new frmAddEditAddress();
                frm.SelectedPartyType = "C";
                frm.SelectedPartyID = selPartyID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBillingClientAddresses();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::btnAddNewBillingAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridClientBillingAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DeselectAll(gridClientBillingAddress);
                gridClientBillingAddress.Rows[e.RowIndex].Cells["IsActive"].Value = true;
                selectedBillingAddressID = int.Parse(gridClientBillingAddress.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::gridClientBillingAddress_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region SITE PARTY AND ADDRESS
        private void PopulateSiteClients()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceParties()).GetAllParties("C"));
                cboSiteClient.DataSource = LST;
                cboSiteClient.DisplayMember = "Description";
                cboSiteClient.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::PopulateSiteClients", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboSiteClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.selectedSiteClientID = ((SelectListItem)cboSiteClient.SelectedItem).ID;
                PopulateSiteClientAddresses();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::cboSiteClient_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateSiteClientAddresses()

        {
            try
            {
                gridClientSiteAddress.DataSource = (new ServiceParties()).GetAllPartyAddressesForSelection(this.selectedSiteClientID);
                gridClientSiteAddress.Columns["ID"].Visible =
                gridClientSiteAddress.Columns["Code"].Visible =
                gridClientSiteAddress.Columns["DescriptionToUpper"].Visible = false;
                gridClientSiteAddress.Columns["IsActive"].Width = 50;
                gridClientSiteAddress.Columns["Description"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::PopulateSiteClientAddresses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewSiteClient_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty("C");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSiteClients();
                    cboSiteClient.SelectedItem = ((List<SelectListItem>)cboSiteClient.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::btnAddNewSiteClient_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewSiteAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboBillingClient.SelectedItem == null)
                {
                    MessageBox.Show("Select a Valid party to add its Site address.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int selPartyID = ((SelectListItem)cboSiteClient.SelectedItem).ID;
                if (selPartyID == 0)
                {
                    MessageBox.Show("Select a Valid party to add its Site address.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmAddEditAddress frm = new frmAddEditAddress();
                frm.SelectedPartyType = "C";
                frm.SelectedPartyID = selPartyID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSiteClientAddresses();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::btnAddNewSiteAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridClientSiteAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DeselectAll(gridClientSiteAddress);
                gridClientSiteAddress.Rows[e.RowIndex].Cells["IsActive"].Value = true;
                selectedSiteAddressID = int.Parse(gridClientSiteAddress.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::gridClientSiteAddress_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VALIDATIONS
        private void cboBillingClient_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboBillingClient.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboBillingClient, "Invalid Billing client");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject ::cboBillingClient_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboSiteClient_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboSiteClient.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboSiteClient, "Invalid Site Client");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::cboSiteClient_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtProjectName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtProjectName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtProjectName, "Can't be left blank.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::txtProjectName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridClientBillingAddress_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridClientBillingAddress.Rows)
                {
                    if ((bool)row.Cells["IsActive"].Value == true) return;
                }
                errorProvider1.SetError(gridClientBillingAddress, "Select Billing Address");
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::gridClientBillingAddress_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridClientSiteAddress_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridClientSiteAddress.Rows)
                {
                    if ((bool)row.Cells["IsActive"].Value == true) return;
                }
                errorProvider1.SetError(gridClientSiteAddress, "Select Site Address");
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::gridClientSiteAddress_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void PopulateOurCompanyAddress()
        {
            try
            {
                TBL_MP_Admin_Company_Master myComp = (new ServiceMASTERS()).MyCompanyInfo();
                if (myComp != null)
                {
                    txtMyCompanyAddress.Text = myComp.Address;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::frmAddEditProject_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeselectAll(KryptonDataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Cells["IsActive"].Value = false;
            }
        }

        private void btnCopyBillingInfoToSiteInfo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateSiteClients();
                cboSiteClient.SelectedItem = ((List<SelectListItem>)cboSiteClient.DataSource).Where(x => x.ID == selectedBillingClientID).FirstOrDefault();
                this.selectedSiteClientID = ((SelectListItem)cboSiteClient.SelectedItem).ID;
                PopulateSiteClientAddresses();
                foreach (DataGridViewRow row in gridClientSiteAddress.Rows)
                {
                    int mID = int.Parse(row.Cells["ID"].Value.ToString());
                    if (mID == selectedBillingAddressID)
                    {
                        row.Cells["IsActive"].Value = true;
                        this.selectedSiteAddressID = mID;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::btnCopyBillingInfoToSiteInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_PMC_ProjectMaster model = null;
            ServiceProject serviceProject = new ServiceProject();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.ProjectID == 0)
                    model = new TBL_MP_PMC_ProjectMaster();
                else
                    model = serviceProject.GetProjectDBInfoByID(this.ProjectID);
                
                #region GATHER DATA INTO MODEL FROM VIEW
                model.ProjectNumber = txtProjectNo.Text;
                model.ProjectName = txtProjectName.Text.Trim();
                model.ProjectDate = dtProjectDate.Value;
                model.StartDate = dtProjectStartDate.Value;
                model.EndDate = dtProjectEndDate.Value;
                model.FK_ProjectStatusID = ((SelectListItem)cboProjectStatus.SelectedItem).ID;
                model.BillingClientID= selectedBillingClientID;
                model.BillingClientAddressID = selectedBillingAddressID;
                model.SiteClientID = selectedSiteClientID;
                model.SiteClientAddressID = selectedSiteAddressID;
                #endregion

                if (this.ProjectID == 0)
                {
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;
                    model.FK_YearID = Program.CURR_USER.FinYearID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.CreatedBy = Program.CURR_USER.EmployeeID;
                    model.CreatedDatetime = AppCommon.GetServerDateTime();
                    this.ProjectID= serviceProject.AddNewProject(model);
                }
                else
                {
                    model.ModifiedBy = Program.CURR_USER.EmployeeID;
                    model.ModifiedDatetime = AppCommon.GetServerDateTime();
                    serviceProject.UpdateProject(model);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditProject::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
    }
}
