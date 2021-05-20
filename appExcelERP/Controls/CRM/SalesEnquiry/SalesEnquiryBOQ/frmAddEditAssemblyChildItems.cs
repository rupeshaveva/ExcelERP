using libERP.MODELS;
using libERP.SERVICES;
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

namespace appExcelERP.Controls.CRM.SalesEnquiry.SalesEnquiryBOQ
{
    public partial class frmAddEditAssemblyChildItems : Form
    {
        public BindingList<MultiSelectListItem> SelectedItems { get; set; }
        public BindingList<MultiSelectListItem> filteredSelectedItems { get; set; }

        private BindingList<MultiSelectListItem> AssemblyChildItems { get; set; }
        private BindingList<MultiSelectListItem> filteredAssemblyChildItems { get; set; }

        private BindingList<MultiSelectListItem> InventoryItems { get; set; }
        private BindingList<MultiSelectListItem> filteredInventoryItems { get; set; }

        public int AssemblyParentItemID { get; set; }
        private int SelectedCategoryID = 0;

        public frmAddEditAssemblyChildItems()
        {
            InitializeComponent();
        }
        private void frmAddEditAssemblyChildItems_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateAssemblyChildItemsGrid();
                PopulateItemCategories();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::PopulateAssemblyChildItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateSelectedItemsGrid()
        {
            try
            {                
                gridSelectedItems.DataSource = this.SelectedItems;
                gridSelectedItems.Columns["ID"].Visible = false;
                gridSelectedItems.Columns["Description"].Visible = false;
                gridSelectedItems.Columns["EntityType"].Visible = false;

                gridSelectedItems.Columns["Code"].Width = (int)(gridSelectedItems.Width * .10);
                gridSelectedItems.Columns["Selected"].Width = 50;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::PopulateAssemblyChildItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchSelectedItems_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filteredSelectedItems = new BindingList<MultiSelectListItem>(SelectedItems.Where(p => p.DescriptionToUpper.Contains(txtSearchSelectedItems.Text.ToUpper())).ToList());
                gridSelectedItems.DataSource = filteredSelectedItems;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::txtSearchSelectedItems_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateAssemblyChildItemsGrid()
        {
            try
            {
                this.AssemblyChildItems = (new ServiceInventoryItems()).GetMultiselectInventoryItemListForAssembly(this.AssemblyParentItemID);
                gridAssembyChildItems.DataSource = this.AssemblyChildItems;
                gridAssembyChildItems.Columns["ID"].Visible = false;
                gridAssembyChildItems.Columns["Description"].Visible = false;
                gridAssembyChildItems.Columns["EntityType"].Visible = false;

                gridAssembyChildItems.Columns["Code"].Width = (int)(gridAssembyChildItems.Width * .10);
                gridAssembyChildItems.Columns["Selected"].Width = 50;
                headerGroupAssemblyChildItems.ValuesSecondary.Heading = gridAssembyChildItems.Rows.Count + " Record(s) found";
            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::PopulateAssemblyChildItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchChildItems_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filteredAssemblyChildItems = new BindingList<MultiSelectListItem>(AssemblyChildItems.Where(p => p.DescriptionToUpper.Contains(txtSearchChildItems.Text.ToUpper())).ToList());
                gridAssembyChildItems.DataSource = filteredAssemblyChildItems;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::txtSearchChildItems_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnAddAssemblyChildItems_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridAssembyChildItems.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        int id = (int)row.Cells["ID"].Value;

                        MultiSelectListItem found = this.SelectedItems.Where(x => x.ID == id).FirstOrDefault();
                        if (found == null)
                        {
                            this.SelectedItems.Add(
                                new MultiSelectListItem()
                                {
                                    ID = id,
                                    Description = string.Format("{0}", row.Cells["Description"].Value.ToString()),
                                    Code = row.Cells["Code"].Value.ToString()
                                });
                        }
                    }
                }
                PopulateSelectedItemsGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::btnAddAssemblyChildItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void PopulateItemCategories()
        {
            try
            {
                cboItemCategories.DataSource = (new ServiceInventoryItems()).GetInventoryCategories();
                cboItemCategories.DisplayMember = "Description";
                cboItemCategories.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::PopulateItemCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboItemCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedCategoryID = 0;
                if (cboItemCategories.SelectedItem != null)
                {
                    this.SelectedCategoryID = ((SelectListItem)cboItemCategories.SelectedItem).ID;
                    PopulateInventoryItemsGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditAssemblyChildItems::cboItemCategories_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PopulateInventoryItemsGrid()
        {
            try
            {
                InventoryItems = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceInventoryItems()).GetInventoryItemsForCategoriesMultiselect(this.SelectedCategoryID));
                gridInventoryItem.DataSource = InventoryItems;
                gridInventoryItem.Columns["EntityType"].Visible = gridInventoryItem.Columns["ID"].Visible = gridInventoryItem.Columns["DescriptionToUpper"].Visible = false;
                gridInventoryItem.Columns["Code"].Width = (int)(gridInventoryItem.Width * .10);
                gridInventoryItem.Columns["Selected"].Width = 50;
                headerGroupInventoryItems.ValuesSecondary.Heading = string.Format("({0}) Items", InventoryItems.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditAssemblyChildItems::PopulateInventoryItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchInventoryItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filteredInventoryItems = new BindingList<MultiSelectListItem>(SelectedItems.Where(p => p.DescriptionToUpper.Contains(txtSearchInventoryItem.Text.ToUpper())).ToList());
                gridInventoryItem.DataSource = filteredInventoryItems;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::txtSearchInventoryItem_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddInventoryItems_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridInventoryItem.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        int id = (int)row.Cells["ID"].Value;

                        MultiSelectListItem found = this.SelectedItems.Where(x => x.ID == id).FirstOrDefault();
                        if (found == null)
                        {
                            this.SelectedItems.Add(
                                new MultiSelectListItem()
                                {
                                    ID = id,
                                    Description = string.Format("{0}", row.Cells["Description"].Value.ToString()),
                                    Code = row.Cells["Code"].Value.ToString()
                                });
                        }
                    }
                }
                PopulateSelectedItemsGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAssemblyChildItems::btnAddInventoryItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
