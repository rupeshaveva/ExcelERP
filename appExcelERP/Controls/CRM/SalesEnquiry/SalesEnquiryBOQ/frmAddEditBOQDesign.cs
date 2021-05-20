using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.UserList;
using libERP.MODELS;
using libERP.SERVICES;
using ComponentFactory.Krypton.Toolkit;
using libERP.MODELS.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.COMMON;
using libERP.MODELS.CRM;

namespace appExcelERP.Forms
{

    public partial class frmAddEditBOQDesign : KryptonForm
    {
        private int SelectedCategoryID = 0;

        private BindingList<EnquiryBOQItem> _items { get; set; }
        private BindingList<EnquiryBOQItem> _filteredItems { get; set; }

        private BindingList<EnquiryBOQService> _services { get; set; }
        private BindingList<EnquiryBOQService> _filteredServices { get; set; }


        public BindingList<EnquiryBOQItem> BOQ_ITEMS { get; set; }
        public BindingList<EnquiryBOQItem> filtered_BOQ_ITEMS { get; set; }
        public BindingList<EnquiryBOQService> BOQ_SERVICES { get; set; }
        public int SelectedItemTypeID { get; set; }

        public frmAddEditBOQDesign()
        {
            InitializeComponent();
        }

        private void frmAddEditBOQDesign_Resize(object sender, EventArgs e)
        {
            
        }
        private void frmAddEditBOQDesign_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
        private void frmAddEditBOQDesign_Load(object sender, EventArgs e)
        {
            try
            {
                cboItemCategories.DataSource = (new ServiceInventoryItems()).GetInventoryCategories();
                cboItemCategories.DisplayMember = "Description";
                cboItemCategories.ValueMember = "ID";

                PopulateServicesGrid();



                if (this.BOQ_ITEMS == null) BOQ_ITEMS = new BindingList<EnquiryBOQItem>();
                if (this.BOQ_SERVICES == null) BOQ_SERVICES = new BindingList<EnquiryBOQService>();

                PopulateSelectedItemsGrid();
                PopulateSelectedServicesGrid();

                splitContainerMain.SplitterDistance = (int)(this.Width * .7);
                splitItems.SplitterDistance = (int)(this.Height * .3);
                splitServices.SplitterDistance = (int)(this.Height * .5);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::frmAddEditBOQDesign_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #region MANAGE ITEM PARTS
        private void cboItemCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedCategoryID = 0;
                if (cboItemCategories.SelectedItem != null)
                {
                    this.SelectedCategoryID = ((SelectListItem)cboItemCategories.SelectedItem).ID;
                    PopulateItemsGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cboItemCategories::cboItemCategories_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchItems_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredItems = new BindingList<EnquiryBOQItem>(_items.Where(p => p.Description.Contains(txtSearchItems.Text.ToUpper())).ToList());
                gridItems.DataSource = _filteredItems;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::txtSearchItems_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridItems.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridItems.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::gridItems_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridItems.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        int id = (int)row.Cells["ID"].Value;

                        EnquiryBOQItem found = this.BOQ_ITEMS.Where(x => x.ID == id).FirstOrDefault();
                        if (found == null)
                        {
                            this.BOQ_ITEMS.Add(new EnquiryBOQItem()
                            {
                                ID = id,
                                Description = string.Format("{0}", row.Cells["Description"].Value.ToString())
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
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::btnAddItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridSelectedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridSelectedItems.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridSelectedItems.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::gridSelectedItems_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridSelectedItems.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        int id = (int)row.Cells["ID"].Value;

                        EnquiryBOQItem found = this.BOQ_ITEMS.Where(x => x.ID == id).FirstOrDefault();
                        if (found != null)
                        {
                            this.BOQ_ITEMS.Remove(found);
                        }
                    }
                }
                PopulateSelectedItemsGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::btnRemoveItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        private void PopulateItemsGrid()
        {
            try
            {
                _items = AppCommon.ConvertToBindingList<EnquiryBOQItem>((new ServiceInventoryItems()).GetInventoryItemsForMultiselectInBOQ(this.SelectedCategoryID));
                gridItems.DataSource = _items;
                gridItems.Columns["ID"].Visible = false;
                gridItems.Columns["Selected"].Width = 50;
                headerGroupItems.ValuesPrimary.Heading = string.Format("Select Database Items ({0})", _items.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditBOQDesign::PopulateItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateSelectedItemsGrid()
        {
            try
            {
                gridSelectedItems.DataSource = BOQ_ITEMS;
                gridSelectedItems.Columns["ID"].Visible = false;
                gridSelectedItems.Columns["Selected"].Width = 50;
                headerGroupSelectedItems.ValuesPrimary.Heading = string.Format("Select Items ({0})", BOQ_ITEMS.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::PopulateSelectedItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        #region MANAGE SERVICES
        private void PopulateServicesGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _services = AppCommon.ConvertToBindingList<EnquiryBOQService>((new ServiceMASTERS()).GetAllServicesMultiSelectinBOQ());
                gridServices.DataSource = _services;
                gridServices.Columns["ID"].Visible = false;
                gridServices.Columns["Selected"].Width = 50;
                headerGroupServices.ValuesPrimary.Heading = string.Format("Services ({0})", _services.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditBOQDesign::PopulateServicesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
         private void txtSearchServices_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredServices = new BindingList<EnquiryBOQService>(_services.Where(p => p.Description.Contains(txtSearchServices.Text.ToUpper())).ToList());
                gridServices.DataSource = _filteredServices;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::txtSearchServices_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridServices.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridServices.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::gridServices_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PopulateSelectedServicesGrid()
        {
            try
            {
                gridSelectedServices.DataSource = BOQ_SERVICES;
                gridSelectedServices.Columns["ID"].Visible = false;
                gridSelectedServices.Columns["Selected"].Width = 50;
                headerGroupSelectedServices.ValuesPrimary.Heading = string.Format("Selected ({0})", BOQ_SERVICES.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::PopulateSelectedServicesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridSelectedServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridSelectedServices.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridSelectedServices.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::gridSelectedServices_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddServices_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridServices.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        int id = (int)row.Cells["ID"].Value;

                        EnquiryBOQService found = this.BOQ_SERVICES.Where(x => x.ID == id).FirstOrDefault();
                        if (found == null)
                        {
                            this.BOQ_SERVICES.Add(new EnquiryBOQService()
                            {
                                ID = id,
                                Description = string.Format("{0}", row.Cells["Description"].Value.ToString())
                            });
                        }
                    }
                }
                PopulateSelectedServicesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::btnAddServices_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnRemoveServices_Click(object sender, EventArgs e)
        {
            string rowsToRemoveIDs = string.Empty;
            try
            {
                foreach (DataGridViewRow row in gridSelectedServices.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        rowsToRemoveIDs += row.Cells["ID"].Value.ToString() + Program.DefaultStringSeperator;
                    }
                }
                if (rowsToRemoveIDs.EndsWith(Program.DefaultStringSeperator.ToString()))
                {
                    rowsToRemoveIDs=rowsToRemoveIDs.TrimEnd(Program.DefaultStringSeperator);
                }
                if (rowsToRemoveIDs != string.Empty)
                {
                    string[] IDs = rowsToRemoveIDs.Split(Program.DefaultStringSeperator);
                    foreach (string s in IDs)
                    {
                        int id = int.Parse(s);
                        EnquiryBOQService found = this.BOQ_SERVICES.Where(x => x.ID == id).FirstOrDefault();
                        if (found != null)
                        {
                            this.BOQ_SERVICES.Remove(found);
                        }
                    }
                }
                PopulateSelectedServicesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditBOQDesign::btnRemoveServices_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
         #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gridSelectedItems_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (BOQ_ITEMS.Count == 0)
                {
                    errorProvider1.SetError(gridSelectedItems, "No Items Selected");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::gridSelectedItems_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtSheetName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSheetName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSheetName, "Sheet Name Mandatory!!");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::txtSheetName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtSearchSelectedItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filtered_BOQ_ITEMS = new BindingList<EnquiryBOQItem>(BOQ_ITEMS.Where(p => p.Description.Contains(txtSearchSelectedItem.Text.ToUpper())).ToList());
                gridSelectedItems.DataSource = filtered_BOQ_ITEMS;

            }
            catch (Exception ex)
            {


                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::txtSearchSelectedItem_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnNewService_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.MASTERCategoryID = (int)APP_MASTER_CATEGORIES.SERVICES_CATEGORY;
                frm.kryptonHeaderGroup1.ValuesPrimary.Heading = "Add a New Service";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateServicesGrid();
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::btnNewService_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnAddNewItemToDB_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditInventoryItem frm = new frmAddEditInventoryItem();
                frm.SelectedCategoryID = this.SelectedCategoryID;
                frm.SelectedItemTypeID = this.SelectedItemTypeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateItemsGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBOQDesign::btnAddNewItemToDB_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
    }





}
