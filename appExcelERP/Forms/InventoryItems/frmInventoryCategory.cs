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
using libERP.SERVICES.MASTER;
using appExcelERP.Forms.UserList;
using libERP.MODELS.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmInventoryCategory : KryptonForm
    {
        public int CategoryID { get; set; }
        public int ItemTypeID { get; set; }

        public frmInventoryCategory()
        {
            InitializeComponent();
            this.CategoryID = 0;
        }
        public frmInventoryCategory(int catID)
        {
            InitializeComponent();
            this.CategoryID = catID;
        }
        private void frmInventoryCategory_Load(object sender, EventArgs e)
        {
            try
            {
                chkIsActive.Checked = true;
                PopulateItemTypeDropdown();
                if (this.ItemTypeID != 0)
                    cboItemType.SelectedItem = ((List<SelectListItem>)cboItemType.DataSource).Where(x => x.ID == this.ItemTypeID).FirstOrDefault();
                ScatterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryCategory::frmInventoryCategory_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateItemTypeDropdown()
        {
            try
            {
                List<SelectListItem> lstTypes = new List<SelectListItem>();
                lstTypes.Add(new SelectListItem() {ID=0, Description="(Select)" });
                lstTypes.AddRange((new ServiceInventoryItems()).GetInventoryItemTypes());
                cboItemType.DataSource = lstTypes;
                cboItemType.DisplayMember = "Description";
                cboItemType.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryCategory::PopulateItemTypeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cboItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboItemType.SelectedItem != null)
            {
                this.ItemTypeID = ((SelectListItem)cboItemType.SelectedItem).ID;
            }
        }
        private void ScatterData()
        {
            try
            {
                if (this.CategoryID == 0)
                {
                    txtCategoryDescription.Text = txtShortCode.Text = txtCategoryName.Text = string.Empty;
                }
                else
                {
                    TBL_MP_Master_Inventory_Category model = (new ServiceInventoryItems()).GetInventoryCategoriesDBItem(this.CategoryID);
                    if (model != null)
                    {
                        txtCategoryName.Text = model.Inv_Category;
                        txtShortCode.Text = model.Category_ShortCode;
                        txtCategoryDescription.Text = model.Category_Description;
                        if(model.FK_Userlist_ItemType_ID!=null)
                        {
                            this.ItemTypeID = (int)model.FK_Userlist_ItemType_ID;
                            cboItemType.SelectedItem = ((List<SelectListItem>)cboItemType.DataSource).Where(x => x.ID == model.FK_Userlist_ItemType_ID).FirstOrDefault();
                        }
                        chkIsActive.Checked = (bool)model.IsActive;
                        txtHSNCode.Text = model.HSNCode;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryCategory::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCategoryName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCategoryName,"Can't be left Blank");
                e.Cancel = true;
            }
        }
        private void txtShortCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtShortCode.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtShortCode, "Can't be left Blank");
                e.Cancel = true;
            }
        }

        private void cboItemType_Validating(object sender, CancelEventArgs e)
        {
            if (cboItemType.SelectedItem == null)
            {
                errorProvider1.SetError(cboItemType, "Invalid selection");
                e.Cancel = true;
                return;
            }
            if (((SelectListItem)cboItemType.SelectedItem).ID == 0)
            {
                errorProvider1.SetError(cboItemType, "Invalid selection");
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Inventory_Category model = null;
            try
            {
                if (this.ValidateChildren())
                {
                    this.Cursor = Cursors.WaitCursor;
                    ServiceInventoryItems _service = new ServiceInventoryItems();

                    if (this.CategoryID == 0)
                    {
                        model = new TBL_MP_Master_Inventory_Category();
                        model.FK_BranchID = Program.CURR_USER.BranchID;
                        model.FK_CompanyID = Program.CURR_USER.CompanyID;
                    }
                    else
                        model = _service.GetInventoryCategoriesDBItem(this.CategoryID);

                    if (model != null)
                    {
                        model.Inv_Category = txtCategoryName.Text;
                        model.Category_ShortCode = txtShortCode.Text;
                        model.Category_Description = txtCategoryDescription.Text;
                        model.HSNCode = txtHSNCode.Text;
                        model.FK_Userlist_ItemType_ID = this.ItemTypeID;
                        model.IsActive = chkIsActive.Checked;
                    }

                    if (this.CategoryID == 0)
                        this.CategoryID = _service.AddNewInventoryCategory(model);
                    else

                        _service.UpdateInventoryCategory(model);

                    this.DialogResult = DialogResult.OK;
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryCategory::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
            }
          
        }

        private void btnAddNewItemType_Click(object sender, EventArgs e)
        {
            try
            {
                frmADMINUserList frm = new frmADMINUserList();
                frm.Text = "Add new Item Type";
                frm.ADMINCategoryID = (int)APP_ADMIN_CATEGORIES.ITEM_TYPE;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateItemTypeDropdown();
                    cboItemType.SelectedItem = ((List<SelectListItem>)cboItemType.DataSource).Where(x => x.ID == frm.UserListID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmInventoryCategory::btnAddNewItemType_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
