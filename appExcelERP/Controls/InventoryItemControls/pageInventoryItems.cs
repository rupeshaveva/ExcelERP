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
using ComponentFactory.Krypton.Toolkit;
using libERP;
using appExcelERP.Forms;
using appExcelERP.Controls.CommonControls;
using System.IO;
using appExcelERP.Controls.InventoryItemControls;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.MODELS.COMMON;
using libERP.MODELS.INVENTORY_ITEMS;

namespace appExcelERP.Controls.InventoryItemControls
{
    public partial class pageInventoryItems : UserControl
    {
        public DB_FORM_IDs FormOperationID { get; set; }
        
        public bool _BindingCompleted = false;
        public int SelectedItemTypeID { get; set; }
        
        public int SelectedCategoryID { get; set; }
        private string SelectedCategoryName { get; set; }
        private BindingList<SelectListItem>  _categoryList=null;
        private BindingList<SelectListItem> _filteredCategoryList = null;

        private BindingList<SelectListItem> _specificationList = null;
        private BindingList<SelectListItem> _filteredSpecificationList = null;

        public int SelectedItemID { get; set; }
        private BindingList<InventoryItemModel> _itemList = null;
        private BindingList<InventoryItemModel> _filteredItemList = null;
        
        private ctrlInventoryItemAdditionalInfo ItemAdditionalInfoControl=null;
        private void InitializeItemAdditionalInfoControl()
        {
            tabPageItemGeneralInfo.Controls.Clear();
            ItemAdditionalInfoControl = new ctrlInventoryItemAdditionalInfo();
            tabPageItemGeneralInfo.Controls.Add(ItemAdditionalInfoControl);
            ItemAdditionalInfoControl.Dock = DockStyle.Fill;
        }

        private ctrlAttachments ItemAttachmentControl = null;
        private void InitializeItemAttachmentControl()
        {
            ItemAttachmentControl = new ctrlAttachments(APP_ENTITIES.INVENTORY_ITEM);
            tabPageAttachment.Controls.Add(ItemAttachmentControl);
            ItemAttachmentControl.Dock = DockStyle.Fill;
        }

        private controlAssemblyComposition ItemAssemblyControl = null;
        private void InitializeItemAssemblyControll()
        {
            ItemAssemblyControl = new controlAssemblyComposition();
            tabPageAssembly.Controls.Add(ItemAssemblyControl);
            ItemAssemblyControl.Dock = DockStyle.Fill;
        }

        private ControlInventoryItemSuppliers SupplierControl = null;
        private void InitializeSuppliersControl()
        {
            SupplierControl = new ControlInventoryItemSuppliers();
            tabPageSuppliers.Controls.Add(SupplierControl);
            SupplierControl.Dock = DockStyle.Fill;
        }



        public pageInventoryItems()
        {
            InitializeComponent();
        }
        private void pageInventoryItems_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeItemAdditionalInfoControl();
                InitializeItemAttachmentControl();
                InitializeItemAssemblyControll();
                InitializeSuppliersControl();

                SplitContainerMain.SplitterDistance = (int)(this.Width * .2);
                splitContainerCategory.SplitterDistance = (int)(this.SplitContainerMain.Height * .7);
                splitContainerItemMain.SplitterDistance = (int)(this.SplitContainerMain.Panel2.Width * .5);

                _categoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceInventoryItems()).GetInventoryCategories());
                PopulateInventoryCategories(_categoryList);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::pageInventoryItems_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void SetPermissionwiseButtonStatus()
        {
            try
            {
                WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == this.FormOperationID).FirstOrDefault();
                if (model != null)
                {
                    if (!model.CanAddNew)
                        btnAddNewCategory.Enabled = btnAddNewItem.Enabled = ButtonEnabled.False;
                    if (!model.CanModify)
                        btnEditCategory.Enabled = btnEditItem.Enabled = btnUpdateSpecifications.Enabled= ButtonEnabled.False;
                    if (!model.CanDelete)
                        btnDeleteItem.Enabled = ButtonEnabled.False;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::SetPermissionwiseButtonStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region INVENTORY CATEGORY CODE BLOCKS
        private void PopulateInventoryCategories(BindingList<SelectListItem> list)
        {
            try
            {
                //_BindingCompleted = false;
                gridInventoryCategories.DataSource = list;
                gridInventoryCategories.Columns["ID"].Visible = gridInventoryCategories.Columns["Code"].Visible = gridInventoryCategories.Columns["IsActive"].Visible = gridInventoryCategories.Columns["DescriptionToUpper"].Visible = false;
                gridInventoryCategories.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupCategory.ValuesPrimary.Heading = string.Format("Categories ({0})", gridInventoryCategories.RowCount);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::PopulateInventoryCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridInventoryCategories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedItemID = 0;
                tabPageAssembly.Visible = false;
                ItemAttachmentControl.ReadOnly = true;
                OnItemSelectionChange();
                SelectedCategoryID = (int)gridInventoryCategories.Rows[e.RowIndex].Cells["ID"].Value;
                SelectedItemTypeID = (new ServiceInventoryItems()).GetItemTypeIDforInventoryCategory(this.SelectedCategoryID);
                SelectedCategoryName = gridInventoryCategories.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                PopulateInventoryLevelGrid();
                PopulateInventoryItemsForSelectedCategories();
                SetPermissionwiseButtonStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::gridInventoryCategories_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridInventoryCategories_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in gridInventoryCategories.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridInventoryCategories.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridInventoryCategories.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::gridInventoryCategories_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        
        #region INVENTORY ITEM CODE BLOCKS
        private void PopulateInventoryItemsForSelectedCategories()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                
                btnEditItem.Enabled = btnDeleteItem.Enabled = ButtonEnabled.False;
                List<InventoryItemModel> itemModelList = (new ServiceInventoryItems()).GetInventoryItemModelListForCategory(this.SelectedCategoryID);
                _itemList = AppCommon.ConvertToBindingList<InventoryItemModel>(itemModelList);
                gridItems.DataSource = _itemList;
                foreach (DataGridViewColumn col in gridItems.Columns)
                {
                    col.Visible = false;
                }
                gridItems.Columns["SearchText"].Visible = true;
                gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //gridItems.Columns["ID"].Visible = gridItems.Columns["Code"].Visible = gridItems.Columns["DescriptionToUpper"].Visible = false;
                //gridItems.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                headerGroupItemGrid.ValuesPrimary.Heading = string.Format("{0} ({1})", SelectedCategoryName, gridItems.RowCount);
                //FormatItemsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::PopulateInventoryItemsForSelectedCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void gridItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //if (!gridItems.Focused) return;
                SelectedItemID = (int)gridItems.Rows[e.RowIndex].Cells["ItemID"].Value;
                if (SelectedItemID != 0)
                {
                    btnEditItem.Enabled = btnDeleteItem.Enabled = ButtonEnabled.True;
                }
                
                bool assembly = (bool)gridItems.Rows[e.RowIndex].Cells["IsAssembly"].Value;
                tabPageAssembly.Visible = false;
                if (assembly)
                {
                    tabPageAssembly.Visible = true;
                }
                bool active = (bool)gridItems.Rows[e.RowIndex].Cells["IsActive"].Value;
                if (active)
                {
                    this.ItemAttachmentControl.ReadOnly = false;
                    btnDeleteItem.Text = "&Delete Item";
                    btnEditItem.Enabled = ButtonEnabled.True;
                    
                }
                else
                {
                    btnDeleteItem.Text = "&Undelete Item";
                    this.ItemAttachmentControl.ReadOnly = true;
                    btnEditItem.Enabled = ButtonEnabled.False;
                }

                OnItemSelectionChange();
                SetPermissionwiseButtonStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::gridItems_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void OnItemSelectionChange()
        {
            
            try
            {

                ItemAdditionalInfoControl.SelectedItemID = this.SelectedItemID;
                ItemAdditionalInfoControl.PopulateAdditionalInfo();
                ItemAdditionalInfoControl.Refresh();


                ItemAttachmentControl.SelectedEntityID = this.SelectedItemID;
                ItemAttachmentControl.PopulateDocuments();
                ItemAttachmentControl.Refresh();

                if(tabPageAssembly.Visible)
                {
                    ItemAssemblyControl.ASSEMBLY_ITEM_ID = this.SelectedItemID;
                    ItemAssemblyControl.PopulateParentItems();
                }

                SupplierControl.SelectedItemID = this.SelectedItemID;
                SupplierControl.PopulateItemSuppliers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::OnItemSelectionChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    
        private void FormatItemsGrid()
        {
            try
            {
                foreach (DataGridViewRow row in gridItems.Rows)
                {
                    if (row.Cells["IsAssembly"] != null)
                    {
                        bool assembly = bool.Parse(row.Cells["IsAssembly"].Value.ToString());
                        if (assembly)
                        {
                            row.DefaultCellStyle.Font = new Font(gridItems.Font, FontStyle.Bold);
                        }
                    }
                    if (row.Cells["IsActive"] != null)
                    {
                        bool active = bool.Parse(row.Cells["IsActive"].Value.ToString());
                        if (!active)
                        {
                            row.DefaultCellStyle.Font = new Font(gridItems.Font, FontStyle.Strikeout);
                            row.DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::FormatItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmAddEditInventoryItem frm = new frmAddEditInventoryItem();
                frm.ItemID = this.SelectedItemID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateInventoryItemsForSelectedCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::gridItems_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                _filteredItemList = new BindingList<InventoryItemModel>(_itemList.Where(p => p.SearchText.Contains(txtSearchItem.Text.ToUpper())).ToList());
                gridItems.DataSource = _filteredItemList;
                headerGroupItems.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridItems.Rows.Count);
                FormatItemsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtSearchItem_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditInventoryItem frm = new frmAddEditInventoryItem();
                frm.SelectedCategoryID = this.SelectedCategoryID;
                frm.SelectedItemTypeID = this.SelectedItemTypeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateInventoryItemsForSelectedCategories();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::btnAddNewItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void btnEditItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditInventoryItem frm = new frmAddEditInventoryItem();
                frm.ItemID = this.SelectedItemID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateInventoryItemsForSelectedCategories();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::btnEditItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (btnDeleteItem.Text)
                {
                    case "&Delete Item":
                        frmDelete frm = new frmDelete(APP_ENTITIES.INVENTORY_ITEM, this.SelectedItemID);
                        if (frm.ShowDialog() == DialogResult.OK)
                            PopulateInventoryItemsForSelectedCategories();
                        break;
                    case "&Undelete Item":
                        string strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMM yy hh:mmtt"));
                        (new ServiceInventoryItems()).UndeleteInventoryItemMasterInfo(this.SelectedItemID, strRemarks);
                        PopulateInventoryItemsForSelectedCategories();
                        break;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::btnDeleteItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
        #endregion

        private void PopulateInventoryLevelGrid()
        {
            try
            {
                _specificationList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceInventoryItems()).GetInventoryLevelSelectlistItemsForCategories(SelectedCategoryID));
                gridInventoryLevels.DataSource = _specificationList;
                gridInventoryLevels.Columns["ID"].Visible = gridInventoryLevels.Columns["Code"].Visible = gridInventoryLevels.Columns["IsActive"].Visible = gridInventoryLevels.Columns["DescriptionToUpper"].Visible = false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageInventoryItems::PopulateInventoryLevelGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }
        private void txtSearchInventoryCategory_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                
                _filteredCategoryList = new BindingList<SelectListItem>(_categoryList.Where(p => p.DescriptionToUpper.Contains(txtSearchInventoryCategory.Text.ToUpper())).ToList());
                PopulateInventoryCategories(_filteredCategoryList);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::txtSearchInventoryCategory_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchSpecifications_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                
                _filteredSpecificationList= new BindingList<SelectListItem>(_specificationList.Where(p => p.DescriptionToUpper.Contains(txtSearchSpecifications.Text.ToUpper())).ToList());
                gridInventoryLevels.DataSource = _filteredSpecificationList;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::txtSearchSpecifications_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryCategory frm = new frmInventoryCategory();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _categoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceInventoryItems()).GetInventoryCategories());
                    PopulateInventoryCategories(_categoryList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::btnAddNewCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryCategory frm = new frmInventoryCategory(this.SelectedCategoryID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _categoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceInventoryItems()).GetInventoryCategories());
                    PopulateInventoryCategories(_categoryList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::btnEditCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnUpdateSpecifications_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryLevel frm = new frmInventoryLevel(this.SelectedCategoryID);
                frm.ShowDialog();
                PopulateInventoryLevelGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::btnUpdateSpecifications_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnUpdateAssemblyItems_Click(object sender, EventArgs e)
        {
                        
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryList = null;
                _categoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceInventoryItems()).GetInventoryCategories());
                PopulateInventoryCategories(_categoryList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

         }
}
