
using libERP;
using libERP.MODELS;
using libERP.MODELS.INVENTORY_ITEMS;
using libERP.SERVICES.COMMON;
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

namespace appExcelERP.Forms.InventoryItems
{
    public partial class frmAddAssemblyChildItems : Form
    {
        public int AssemblyItemID { get; set; }
        public int SelectedCategoryID { get; set; }

        public BindingList<MultiSelectListItem> _ItemsList = null;
        public BindingList<MultiSelectListItem> _filteredItemsList = null;
        public BindingList<AssemblyParentItem> SELECTED_ITEMS = null;
       
        public frmAddAssemblyChildItems()
        {
            InitializeComponent();
        }
        public frmAddAssemblyChildItems(int itemID)
        {
            this.AssemblyItemID = itemID;
            InitializeComponent();
        }
        private void frmAddAssemblyChildItems_Load(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Height * .5);
            PopulateItemCategoryDropdown();
            cboItemCategory.SelectedIndex = 0;
            TBL_MP_Master_Item dbItem = (new ServiceInventoryItems()).GetItemDBRecord(this.AssemblyItemID);
            if (dbItem != null)
            {
                this.Text = string.Format("ASSEMBLY: {0}", dbItem.Item_Name);
            }
            PopulateAssemblyChildItems();
        }

        #region populates
        private void PopulateAssemblyChildItems()
        {
            gridChildItems.DataSource = this.SELECTED_ITEMS;

            //List<AssemblyParentItem> itemModelList = (new ServiceInventoryItems()).GetInventoryItemListForAssembly(this.AssemblyItemID);
            //gridChildItems.DataSource = itemModelList;
            foreach (DataGridViewColumn col in gridChildItems.Columns)
            {
                col.Visible = false;
            }
            //gridChildItems.ReadOnly = true;
            //gridChildItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //gridChildItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //gridChildItems.Columns["ItemDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridChildItems.Columns["ItemDescription"].Visible = true;
            gridChildItems.Columns["Selected"].Visible = true;
            gridChildItems.Columns["Selected"].Width = 50;
            //gridChildItems.RowHeadersVisible = false;
            //gridChildItems.ColumnHeadersVisible = false;
            

            headerGroupSelectedItems.ValuesSecondary.Heading = string.Format("{0} records found.", gridChildItems.RowCount);

        }
        private void PopulateItemCategoryDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceInventoryItems()).GetInventoryCategories());
                cboItemCategory.DataSource = LST;
                cboItemCategory.DisplayMember = "Description";
                cboItemCategory.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddAssemblyChildItems::PopulateItemCategoryDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PopulateInventoryItemsForSelectedCategories()
        {
            gridItems.DataSource = null;
            try
            {
                _ItemsList = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceInventoryItems()).GetNonAssemblyMultiSelectInventoryItemListForCategory(this.SelectedCategoryID));
                gridItems.DataSource = _ItemsList;
                foreach (DataGridViewColumn col in gridItems.Columns)
                {
                    col.Visible = false;
                }
                gridItems.Columns["Description"].Visible = true;
                gridItems.Columns["Selected"].Visible = true;
                gridItems.Columns["Selected"].Width= (int)(gridItems.Width*.1);
                gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                headerGroupChooseItems.ValuesSecondary.Heading = string.Format("{0} records found.", gridItems.RowCount);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddAssemblyChildItems::PopulateInventoryItemsForSelectedCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        #endregion

        private void cboItemCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboItemCategory.SelectedItem != null)
                {
                    this.SelectedCategoryID = ((SelectListItem)cboItemCategory.SelectedItem).ID;
                    PopulateInventoryItemsForSelectedCategories();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddAssemblyChildItems::cboItemCategory_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridItems.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridItems.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        private void gridChildItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridChildItems.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridChildItems.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        private void btnAddAssemblyChildItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow row in gridItems.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {

                        int itemID = (int)row.Cells["ID"].Value;
                        AssemblyParentItem item= this.SELECTED_ITEMS.Where(x => x.ItemID == itemID).FirstOrDefault();
                        if (item == null)
                        {
                            item = new AssemblyParentItem();
                            item.ItemDescription = row.Cells["Description"].Value.ToString();
                            item.ItemID = itemID;
                            item.DefaultQTY = 0;
                            item.IsAssembly = false;
                            this.SELECTED_ITEMS.Add(item);
                        }
                    }
                }
                PopulateAssemblyChildItems();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddAssemblyChildItems::btnAddAssemblyChildItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }
        private void btnRemoveChildItemsFromAssembly_Click(object sender, EventArgs e)
        {
            try
            {
                string strSelectedIDs = string.Empty;
                foreach (DataGridViewRow row in gridChildItems.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        strSelectedIDs += row.Cells["ItemID"].Value.ToString() + Program.DefaultStringSeperator;
                    }
                }
                strSelectedIDs = strSelectedIDs.TrimEnd(Program.DefaultStringSeperator);
                if (strSelectedIDs.Trim() != string.Empty)
                {
                    string[] IDs = strSelectedIDs.Split(Program.DefaultStringSeperator);
                    foreach (string ID in IDs)
                    {
                        int mID = int.Parse(ID);
                        AssemblyParentItem delItem = SELECTED_ITEMS.Where(x => x.ItemID == mID).FirstOrDefault();
                        if (delItem != null)
                            SELECTED_ITEMS.Remove(delItem);
                    }
                    PopulateAssemblyChildItems();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddAssemblyChildItems::btnRemoveChildItemsFromAssembly_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            _filteredItemsList = new BindingList<MultiSelectListItem>(_ItemsList.Where(p => p.DescriptionToUpper.Contains(txtSearchItem.Text.ToUpper())).ToList());
            gridItems.DataSource = _filteredItemsList;
            headerGroupChooseItems.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridItems.Rows.Count);
        }

        #region validation
        private void cboItemCategory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboItemCategory.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboItemCategory, "Invalid Item Category");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddAssemblyChildItems::cboItemCategory_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
