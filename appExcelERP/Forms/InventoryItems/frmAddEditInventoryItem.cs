

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

using appExcelERP.Forms.UserList;
using libERP.MODELS.INVENTORY_ITEMS;
using libERP;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.COMMON;
using libERP.MODELS.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmAddEditInventoryItem : KryptonForm
    {
        public int ItemID { get; set; }
        public int SelectedItemTypeID { get; set; }
        public int SelectedCategoryID { get; set; }

        private string _uniqueString = string.Empty;

        private List<InventoryItemSpecificationModel> lstItemSpecifications = null;

        public frmAddEditInventoryItem()
        {
            InitializeComponent();
        }
        public frmAddEditInventoryItem(int inventoryItemID)
        {
            this.ItemID = inventoryItemID;
            InitializeComponent();
        }

        private void frmAddEditInventoryItem_Load(object sender, EventArgs e)
        {
            try
            {
                
                PopulateUOMDropdown();
                PopulatePurchaseUOMDropdown();

                PopulateItemTypeDropdown();
               // if (this.SelectedItemTypeID > 0)
                 //   cboItemType.SelectedItem = ((List<SelectListItem>)cboItemType.DataSource).Where(x => x.ID == this.SelectedItemTypeID).FirstOrDefault();
                PopulateItemCategoryDropdown();
              /*  if (this.SelectedCategoryID > 0)
                {
                    cboItemCategory.SelectedItem = ((List<SelectListItem>)cboItemCategory.DataSource).Where(x => x.ID == this.SelectedCategoryID).FirstOrDefault();
                    txtItemCode.Text = (new ServiceInventoryItems()).GenerateNewInventoryItemCode(this.SelectedCategoryID);
                    if (txtHSNCode.Text.Trim() == string.Empty) txtHSNCode.Text = ((SelectListItem)cboItemCategory.SelectedItem).Code;
                }
                */
                if (ItemID != 0)
                {
                    Scatterdata();
                }
                PopulateSpecificationsGrid();
                PrepareDuplicacyCheckProgressBar();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditInventoryItem::frmAddEditInventoryItem_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
       


        private void PopulateItemTypeDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceInventoryItems()).GetInventoryItemTypes());
                cboItemType.DataSource = LST;
                cboItemType.DisplayMember = "Description";
                cboItemType.ValueMember = "ID";

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditInventoryItem::PopulateItemTypeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void PopulateItemCategoryDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceInventoryItems()).GetInventoryCategoriesOfItemType(this.SelectedItemTypeID));
                cboItemCategory.DataSource = LST;
                cboItemCategory.DisplayMember = "Description";
                cboItemCategory.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditInventoryItem::PopulateItemCategoryDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void PopulateUOMDropdown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceMASTERS()).GetAllUOMs());
                cboUOM.DataSource = lstUOMs;
                cboUOM.DisplayMember = "Description";
                cboUOM.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditInventoryItem::PopulateUOMDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
        private void PopulatePurchaseUOMDropdown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceMASTERS()).GetAllUOMs());
                cboPurchaseUOM.DataSource = lstUOMs;
                cboPurchaseUOM.DisplayMember = "Description";
                cboPurchaseUOM.ValueMember = "ID";

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditInventoryItem::PopulatePurchaseUOMDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void PopulateSpecificationsGrid()
        {
            try
            {
                lstItemSpecifications = (new ServiceInventoryItems()).GetInventoryItemSpecificationModelForItemCategory(this.SelectedCategoryID);
                if (ItemID > 0)
                {
                    List<InventoryItemSpecificationModel> dbModel= (new ServiceInventoryItems()).GetInventoryLevelWithValuesForInventoryItem(ItemID);
                    foreach (InventoryItemSpecificationModel item in dbModel)
                    {
                        InventoryItemSpecificationModel model = lstItemSpecifications.Where(x => x.InventoryLevelID == item.InventoryLevelID).FirstOrDefault();
                        if (model != null)
                        {
                            model.PKSpecificationID = item.PKSpecificationID;
                            model.InventoryLevelValueID = item.InventoryLevelValueID;
                            model.InventoryLevelValueDescription = item.InventoryLevelValueDescription;
                        }
                    }
                }    

                gridItemSpecifications.DataSource = lstItemSpecifications;
                gridItemSpecifications.RowHeadersVisible = false;
                gridItemSpecifications.Columns["InventoryLevelDescription"].ReadOnly = true;
                gridItemSpecifications.Columns["InventoryLevelID"].Visible = gridItemSpecifications.Columns["PKSpecificationID"].Visible = gridItemSpecifications.Columns["InventoryLevelValueID"].Visible = false;
                gridItemSpecifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridItemSpecifications.Columns["InventoryLevelDescription"].HeaderText = "Attribute";
                gridItemSpecifications.Columns["InventoryLevelValueDescription"].HeaderText = "Value";


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::PopulateSpecificationsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private string GenerateSpecificationSummaryText()
        {
            string strSummary = string.Empty;
            try
            {
                foreach (DataGridViewRow dr in gridItemSpecifications.Rows)
                {
                    string name = dr.Cells["InventoryLevelDescription"].Value.ToString();
                    string value = string.Empty;
                    if (dr.Cells["InventoryLevelValueDescription"].Value != null)
                    {
                        value= dr.Cells["InventoryLevelValueDescription"].Value.ToString().Trim();
                    }
                    if ((value != string.Empty) && (value!="(Select)"))
                    {
                        strSummary += string.Format("{0}: {1}{2}", name, value,",  ");
                    }
                    //strSummary = strSummary.Trim().TrimEnd(',');
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::GenerateSpecificationSummaryText", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return strSummary;
        }

        private void cboItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboItemType.SelectedItem != null)
                {
                    this.SelectedItemTypeID = ((SelectListItem)cboItemType.SelectedItem).ID;
                    PopulateItemCategoryDropdown();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::cboItemType_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void cboItemCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                if (cboItemCategory.SelectedItem != null)
                {
                    this.SelectedCategoryID = ((SelectListItem)cboItemCategory.SelectedItem).ID;
                    if(txtHSNCode.Text.Trim()==string.Empty) txtHSNCode.Text= ((SelectListItem)cboItemCategory.SelectedItem).Code;
                    PopulateSpecificationsGrid();
                    if (this.ItemID==0)
                        txtItemCode.Text = (new ServiceInventoryItems()).GenerateNewInventoryItemCode(this.SelectedCategoryID);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::cboItemCategory_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridItemSpecifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell objGridDropbox = new DataGridViewComboBoxCell();

                // Check the column  cell, in which it click.  
                if (gridItemSpecifications.Columns[e.ColumnIndex].Name.Contains("InventoryLevelValueDescription"))
                {
                    int levelID = (int)gridItemSpecifications["InventoryLevelID", e.RowIndex].Value;
                    int levelValueID = (int)gridItemSpecifications["InventoryLevelValueID", e.RowIndex].Value;
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridItemSpecifications[e.ColumnIndex, e.RowIndex] = objGridDropbox;
                    objGridDropbox.DataSource = (new ServiceInventoryItems()).GetInventoryLevelValuesForInventoryLevel(levelID); // Bind combobox with datasource.  
                    objGridDropbox.ValueMember = "Description";
                    objGridDropbox.DisplayMember = "Description";
                    objGridDropbox.Value = ((List<SelectListItem>)objGridDropbox.DataSource).Where(x=>x.ID== levelValueID).FirstOrDefault().Description;
                    objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                    objGridDropbox.FlatStyle = FlatStyle.Flat;
                }
            }
        }
        private void gridItemSpecifications_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridItemSpecifications.CurrentCell.ColumnIndex == gridItemSpecifications.Columns["InventoryLevelValueDescription"].Index && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= InventoryLevelValueDescription_SelectionChanged;
                comboBox.SelectedIndexChanged += InventoryLevelValueDescription_SelectionChanged;
            }
        }

        private void InventoryLevelValueDescription_SelectionChanged(object sender, EventArgs e)
        {
            var currentcell = gridItemSpecifications.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            List<SelectListItem> lstValues = (List<SelectListItem>)sendingCB.DataSource;
       
            string strValueDescription= sendingCB.EditingControlFormattedValue.ToString();
            
            if (lstValues != null)
            {
                gridItemSpecifications.Rows[currentcell.Y].Cells["InventoryLevelValueDescription"].Value = strValueDescription;
                SelectListItem selItem = lstValues.Where(x => x.Description == strValueDescription).FirstOrDefault();
                if(selItem!=null)
                    gridItemSpecifications.Rows[currentcell.Y].Cells["InventoryLevelValueID"].Value = selItem.ID;
            }
            txtSpecificName.Text = this.GenerateSpecificationSummaryText();
        }


        private void Scatterdata()
        {
            TBL_MP_Master_Item model = (new ServiceInventoryItems()).GetItemDBRecord(this.ItemID);
            if (model != null)
            {
                txtItemID.Text = model.Pk_ItemID.ToString();
                txtItemCode.Text = model.ItemCode.ToString();
                txtHSNCode.Text = model.HSNCode;
                txtItemName.Text = model.Item_Name;
                txtSpecificName.Text = model.Long_Description;
                txtPartNumber.Text = model.PartNumber;
                chkIsAssembly.Checked = (bool)model.IsAssembly;
                if(model.UniqueString!=null)   _uniqueString = model.UniqueString;
                if (model.Fk_UserList_ItemType_ID != null)
                {
                    this.SelectedItemTypeID = (int)model.Fk_UserList_ItemType_ID;
                    cboItemType.SelectedItem = ((List<SelectListItem>)cboItemType.DataSource).Where(x => x.ID == model.Fk_UserList_ItemType_ID).FirstOrDefault();
                    PopulateItemCategoryDropdown();
                }

                if (model.Fk_InvCategory_ID != null)
                {
                    this.SelectedCategoryID = (int)model.Fk_InvCategory_ID;
                    cboItemCategory.SelectedItem = ((List<SelectListItem>)cboItemCategory.DataSource).Where(x => x.ID == model.Fk_InvCategory_ID).FirstOrDefault();
                    PopulateSpecificationsGrid();
                }

                if(model.Fk_UserList_BaseUOM_ID!=null)
                { 
                    SelectListItem selUnit= ((List<SelectListItem>)cboUOM.DataSource).Where(x => x.ID == model.Fk_UserList_BaseUOM_ID).FirstOrDefault();
                    if (selUnit != null) cboUOM.SelectedItem = selUnit;
                }
                if (model.Fk_UserList_PurchaseUOM_ID != null)
                {
                    SelectListItem selUnit = ((List<SelectListItem>)cboPurchaseUOM.DataSource).Where(x => x.ID == model.Fk_UserList_PurchaseUOM_ID).FirstOrDefault();
                    if (selUnit != null) cboPurchaseUOM.SelectedItem = selUnit;
                }
            }

        }
        private TBL_MP_Master_Item GatherData()
        {
            TBL_MP_Master_Item model = null;
            try
            {
                if (this.ItemID == 0)
                {
                    model = new TBL_MP_Master_Item();
                    model.Pk_ItemID = 0;
                }
                else
                {
                    model = (new ServiceInventoryItems()).GetItemDBRecord(this.ItemID);
                }
                model.ItemCode = txtItemCode.Text;
                model.HSNCode = txtHSNCode.Text;
                model.PartNumber = txtPartNumber.Text.Trim();
                model.Item_Name = txtItemName.Text.Trim().ToUpper();
                model.Long_Description = txtSpecificName.Text.Trim();
                
                model.Fk_UserList_ItemType_ID = ((SelectListItem)cboItemType.SelectedItem).ID;
                model.Fk_InvCategory_ID = ((SelectListItem)cboItemCategory.SelectedItem).ID;
                model.Fk_UserList_BaseUOM_ID= ((SelectListItem)cboUOM.SelectedItem).ID;
                model.Fk_UserList_PurchaseUOM_ID = ((SelectListItem)cboPurchaseUOM.SelectedItem).ID;
                model.IsAssembly = chkIsAssembly.Checked;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::GatherData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }

        #region VALIDATIONS
        private void cboItemType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboItemType.SelectedItem).ID == 0)
                    //if (cboItemType.SelectedItem == null)
                {
                    errorProvider1.SetError(cboItemType, "Type of Item is mandatory.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::cboItemType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void cboItemCategory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboItemCategory.SelectedItem).ID == 0)
                  //  if (cboItemCategory.SelectedItem == null)
                {
                    errorProvider1.SetError(cboItemCategory, "Item Category is mandatory.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) 
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::cboItemCategory_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboUOM_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboUOM.SelectedItem == null)
                {
                    errorProvider1.SetError(cboUOM, "UOM is mandatory.");
                    e.Cancel = true;
                }
                else
                {
                    SelectListItem selItem = (SelectListItem)cboUOM.SelectedItem;
                    if (selItem.ID == 0)
                    {
                        errorProvider1.SetError(cboUOM, "Invalid UOM selected");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::cboUOM_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboPurchaseUOM_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboPurchaseUOM.SelectedItem == null)
                {
                    errorProvider1.SetError(cboPurchaseUOM, "UOM is mandatory.");
                    e.Cancel = true;
                }
                else
                {
                    SelectListItem selItem = (SelectListItem)cboPurchaseUOM.SelectedItem;
                    if (selItem.ID == 0)
                    {
                        errorProvider1.SetError(cboPurchaseUOM, "Invalid UOM selected");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::cboPurchaseUOM_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtItemName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtItemName, "Item Name is mandatory.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::txtItemName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            ServiceInventoryItems _InventoryItemService= new ServiceInventoryItems();
            errorProvider1.Clear();
            if (this.ValidateChildren())
            {
                try
                {
                    
                    TBL_MP_Master_Item item = this.GatherData();
                    PrepareDuplicacyCheckProgressBar();
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        string strMEssage = "The same set of Specification is already assign to any other Item.\nDo you still wish to save this Item"; 
                        DialogResult choice = MessageBox.Show(strMEssage, "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (choice == DialogResult.No) return;
                    }
                    if (item.Pk_ItemID == 0)
                    {
                        ItemID = _InventoryItemService.AddNewInventoryItemMasterInfo(item);
                    }
                    else
                    {
                        bool result = _InventoryItemService.UpdateInventoryItemMasterInfo(item);
                    }
                    _InventoryItemService.UpdateInventoryItemSpecifications(lstItemSpecifications, ItemID);
                    
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    string errMessage = ex.Message;
                    if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                    MessageBox.Show(ex.Message, "frmAddEditInventoryItem::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::btnAddNewItemType_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAddNewCatogory_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryCategory frm = new frmInventoryCategory();
                frm.ItemTypeID = this.SelectedItemTypeID;
                frm.Text = "Add new Category for an Inventory Item";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateItemCategoryDropdown();
                    cboItemCategory.SelectedItem = ((List<SelectListItem>)cboItemCategory.DataSource).Where(x => x.ID == frm.CategoryID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::btnAddNewCatogory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnUpdateSpecificationMater_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryLevel frm = new frmInventoryLevel(this.SelectedCategoryID);
                frm.ShowDialog();
                PopulateSpecificationsGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditInventoryItem::btnUpdateSpecificationMater_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void chkIsAssembly_CheckedChanged(object sender, EventArgs e)
        {
            lblItemName.Text = (chkIsAssembly.Checked == true) ? "ASSEMBLY ITEM NAME " : "ITEM NAME";
        }

        
        private void PrepareDuplicacyCheckProgressBar()
        {
            _uniqueString = string.Empty;
            foreach (InventoryItemSpecificationModel model in lstItemSpecifications)
            {
                _uniqueString += string.Format("{0}|", model.InventoryLevelValueID);
            }

            List<SelectListItem> lstStrings = (new ServiceInventoryItems()).GetUniqueStringsOfItemsForCategory(this.SelectedCategoryID);
            double maxMatchPercent = 0;
            foreach (SelectListItem item in lstStrings)
            {
                if (item.ID != this.ItemID)
                {
                    double matchPercent = AppCommon.CalculateSimilarity(_uniqueString, item.Description);
                    if (matchPercent > maxMatchPercent) maxMatchPercent = matchPercent;
                }
            }
            progressBar1.Maximum = 100;
            progressBar1.Value = (int)(maxMatchPercent*100);
            Application.DoEvents();
        }

        private void gridItemSpecifications_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            PrepareDuplicacyCheckProgressBar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
