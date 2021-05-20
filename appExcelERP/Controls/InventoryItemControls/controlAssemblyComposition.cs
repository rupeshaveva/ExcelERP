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
using libERP.MODELS.INVENTORY_ITEMS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.InventoryItemControls
{
    public partial class controlAssemblyComposition : UserControl
    {
        public int ASSEMBLY_ITEM_ID { get; set; }
        private BindingList<AssemblyParentItem> _assemblyItems = null;
        private BindingList<AssemblyParentItem> _filteredAssemblyItems = null;
        public controlAssemblyComposition()
        {
            InitializeComponent();
        }

        #region ASSEMBLY COMPOSITION
        private void controlAssemblyComposition_Load(object sender, EventArgs e)
        {
            
        }
        public void PopulateParentItems()
        {
            try
            {
                _assemblyItems = AppCommon.ConvertToBindingList<AssemblyParentItem>((new ServiceInventoryItems()).GetInventoryItemListForAssembly(this.ASSEMBLY_ITEM_ID));
                RefreshParentItemGrid();
                //FormatItemsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "controlAssemblyComposition::PopulateParentItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void RefreshParentItemGrid()
        {
            try
            {
                gridParentItems.DataSource = _assemblyItems;
                foreach (DataGridViewColumn col in gridParentItems.Columns)
                {
                    col.Visible = false;
                }
                gridParentItems.Columns["ItemDescription"].Visible = gridParentItems.Columns["DefaultQTY"].Visible = true;
                gridParentItems.Columns["ItemDescription"].ReadOnly = true;
                gridParentItems.Columns["Selected"].Width = 50;
                gridParentItems.Columns["DefaultQTY"].Width = (int)(gridParentItems.Width * .1);
                gridParentItems.Columns["DefaultQTY"].HeaderText = "Qty.";
                gridParentItems.Columns["DefaultQTY"].DefaultCellStyle.Format = "n3";
                //gridParentItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridParentItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                headerGroupParent.ValuesSecondary.Heading = string.Format("{0} records found.", gridParentItems.RowCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "controlAssemblyComposition::RefreshParentItemGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatItemsGrid()
        {
            try
            {
                foreach (DataGridViewRow row in gridParentItems.Rows)
                {
                    if (row.Cells["IsAssembly"] != null)
                    {
                        bool assembly = bool.Parse(row.Cells["IsAssembly"].Value.ToString());
                        if (assembly)
                        {
                            row.DefaultCellStyle.Font = new Font(gridParentItems.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "controlAssemblyComposition::FormatItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddRemoveItems_Click(object sender, EventArgs e)
        {
            try
            {

                appExcelERP.Forms.InventoryItems.frmAddAssemblyChildItems frm = new Forms.InventoryItems.frmAddAssemblyChildItems();
                frm.AssemblyItemID = this.ASSEMBLY_ITEM_ID;
                frm.SELECTED_ITEMS = this._assemblyItems;
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _assemblyItems = frm.SELECTED_ITEMS;
                    RefreshParentItemGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "controlAssemblyComposition::btnAddParentItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnSaveAssembly_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new ServiceInventoryItems()).UpdateAssemblyChildItems(this.ASSEMBLY_ITEM_ID, _assemblyItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "controlAssemblyComposition::btnSaveAssembly_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchParentItems_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredAssemblyItems = new BindingList<AssemblyParentItem>(_assemblyItems.Where(p => p.ItemDescription.Contains(txtSearchParentItems.Text.ToUpper())).ToList());
                gridParentItems.DataSource = _filteredAssemblyItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "controlAssemblyComposition::txtSearchParentItems_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

    }
}
