using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms;
using libERP.MODELS;
using libERP;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.COMMON;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.InventoryItemControls
{
    public partial class ControlInventoryItemSuppliers : UserControl
    {
        public int SelectedItemID { get; set; }
        
        BindingList<SelectListItem> _SupplierList = null;
        BindingList<SelectListItem> _filteredSupplierList = null;
        public ControlInventoryItemSuppliers()
        {
            InitializeComponent();
        }

        private void kryptonHeaderGroup1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void PopulateItemSuppliers()
        {
              this.Cursor = Cursors.WaitCursor;
                try
                {
                     // int selectedCategoryID = 0;
                    _SupplierList = new BindingList<SelectListItem>();
                    _SupplierList = AppCommon.ConvertToBindingList((new ServiceInventoryItems()).GetAllSuppliersForItem(this.SelectedItemID));
                    gridSupplier.DataSource = _SupplierList;
                    gridSupplier.Columns["ID"].Visible = gridSupplier.Columns["Code"].Visible = gridSupplier.Columns["IsActive"].Visible = gridSupplier.Columns["DescriptionToUpper"].Visible = false;
                    gridSupplier.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    headerGroupMain.ValuesSecondary.Heading = string.Format("({0})Records Found", gridSupplier.Rows.Count);



                }
                catch (Exception ex)
                {
                    string errMessage = ex.Message;
                    if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                    MessageBox.Show(errMessage, "ControlInventoryItemSuppliers::PopulateItemSuppliers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;

            

        }

        private void btnAddSuppliers_Click(object sender, EventArgs e)
        {
            try
            {
             
               string supplierIDs = string.Empty;
               frmGridMultiSelect frm = new frmGridMultiSelect(libERP.MODELS.COMMON.APP_ENTITIES.SUPPLIERS);
                frm.SingleSelect = false;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                     foreach (MultiSelectListItem item in frm.SelectedItems)
                     {
                        supplierIDs += item.ID.ToString() + ",";
                     }
                    if (supplierIDs != string.Empty) supplierIDs = supplierIDs.TrimEnd(',');
                    if((new ServiceInventoryItems()).UpdateSuppliers(this.SelectedItemID, supplierIDs))
                    PopulateItemSuppliers();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlInventoryItemSuppliers::btnAddSuppliers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredSupplierList = new BindingList<SelectListItem>(_SupplierList.Where(p => p.Description.ToUpper().Contains(txtSearchSupplier.Text.ToUpper())).ToList());
                gridSupplier.DataSource = _filteredSupplierList;
                headerGroupMain.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridSupplier.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlInventoryItemSuppliers::txtSearchSupplier_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void gridSupplier_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedItemID = 0;
                if (gridSupplier.Rows.Count > 0)
                    this.SelectedItemID = int.Parse(gridSupplier.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlInventoryItemSuppliers::gridSupplier_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Are you sure to Delete selected Suppliers Permanently";
                DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    (new ServiceInventoryItems()).RemoveSupplier(this.SelectedItemID);
                    PopulateItemSuppliers();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlInventoryItemSuppliers::btnRemoveSupplier_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
