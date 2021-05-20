using libERP.MODELS;
using libERP.SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.InventoryItems;
using libERP.MODELS.INVENTORY_ITEMS;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms
{
    public partial class frmInventoryLevel : Form
    {
        public int CategoryID { get; set; }
        public int SelectedLevelID { get; set; }
        public int SelectedLevelValueID { get; set; }

        List<InventoryLevelModel> LEVELS = null;
        

        public frmInventoryLevel()
        {
            InitializeComponent();
        }
        public frmInventoryLevel(int catID)
        {
            CategoryID = catID;
            InitializeComponent();
        }

        private void GetAllInventoryLevels()
        {
            LEVELS = (new ServiceInventoryItems()).GetInventoryLevelWithDetailsForCategory(this.CategoryID);
        }

        private void PopulateInventoryLevelGrid()
        {

            try
            {
                gridLevels.DataSource = this.LEVELS;
                gridLevels.RowHeadersVisible = false;
                gridLevels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridLevels.Columns["CategoryID"].Visible = gridLevels.Columns["ISActive"].Visible = gridLevels.Columns["CategoryID"].Visible =false;
                gridLevels.ReadOnly = true;
                gridLevels.Columns["InventoryLevelName"].Width = (int)(gridLevels.Width * .7);
                gridLevels.Columns["InventoryLevelName"].HeaderText = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryLevel::PopulateInventoryLevelGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateInventoryLevelDetailGrid()
        {
            try
            {
                InventoryLevelModel model = LEVELS.Where(x => x.InventoryLevelID == this.SelectedLevelID ).FirstOrDefault();
                if (model != null)
                {
                    gridLevelDetails.DataSource = model.VALUES;
                    gridLevelDetails.RowHeadersVisible = false;
                    gridLevelDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    gridLevelDetails.Columns["InventoryLevelID"].Visible = gridLevelDetails.Columns["InventoryLevelDetailID"].Visible = false;
                    gridLevelDetails.ReadOnly = true;
                    gridLevelDetails.Columns["InventoryLevelDetailName"].Width = (int)(gridLevels.Width * .7);
                    gridLevelDetails.Columns["InventoryLevelDetailName"].HeaderText = "Value";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryLevel::PopulateInventoryLevelDetailGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInventoryLevel_Load(object sender, EventArgs e)
        {
            if (this.CategoryID != 0)
            {
                headerGroupMain.ValuesPrimary.Heading=  (new ServiceInventoryItems()).GetInventoryCategoryNameForCategoryID(this.CategoryID);
            }
            LEVELS = (new ServiceInventoryItems()).GetInventoryLevelWithDetailsForCategory(this.CategoryID);
            PopulateInventoryLevelGrid();
        }

        private void btnAddNewSpecification_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditInventoryLevel frm = new frmAddEditInventoryLevel();
                frm.CategoryID = this.CategoryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LEVELS = (new ServiceInventoryItems()).GetInventoryLevelWithDetailsForCategory(this.CategoryID);
                    PopulateInventoryLevelGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryLevel::btnAddNewSpecification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditSpecification_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditInventoryLevel frm = new frmAddEditInventoryLevel();
                frm.CategoryID = this.CategoryID;
                frm.InventoryLevelID = this.SelectedLevelID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LEVELS = (new ServiceInventoryItems()).GetInventoryLevelWithDetailsForCategory(this.CategoryID);
                    PopulateInventoryLevelGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmInventoryLevel::btnEditSpecification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridLevels_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedLevelID = (int)gridLevels.Rows[e.RowIndex].Cells["InventoryLevelID"].Value;
            headerGroupLevelDetails.ValuesPrimary.Heading =string.Format("Level : {0}", gridLevels.Rows[e.RowIndex].Cells["InventoryLevelName"].Value.ToString());
            PopulateInventoryLevelDetailGrid();
        }
        private void gridLevelDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedLevelValueID = (int)gridLevelDetails.Rows[e.RowIndex].Cells["InventoryLevelDetailID"].Value;
        }
        private void btnAddNewValue_Click(object sender, EventArgs e)
        {
            frmAddEditInventoryLevelDetail frm = new frmAddEditInventoryLevelDetail();
            frm.InventoryCategoryID = this.CategoryID;
            frm.InventoryLevelID = this.SelectedLevelID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GetAllInventoryLevels();
                PopulateInventoryLevelDetailGrid();
            }

        }

        private void btnEditValue_Click(object sender, EventArgs e)
        {
            frmAddEditInventoryLevelDetail frm = new frmAddEditInventoryLevelDetail(this.SelectedLevelValueID);
            frm.InventoryCategoryID = this.CategoryID;
            frm.InventoryLevelID = this.SelectedLevelID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GetAllInventoryLevels();
                PopulateInventoryLevelGrid();
                PopulateInventoryLevelDetailGrid();
            }
        }

        private void btnDeleteSpecification_Click(object sender, EventArgs e)
        {

            try
            {
                string strMessage = string.Format("Are you sure to Remove Inventory Item", this.CategoryID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceInventoryItems()).DeleteInventoryItemInfo(this.SelectedLevelID))
                         GetAllInventoryLevels();
                        PopulateInventoryLevelGrid();
                    //PopulateInventoryLevelDetailGrid();
                }

                //frmDelete frm = new frmDelete(APP_ENTITIES.INVENTORY_ITEM, this.SelectedLevelValueID);
                //if (frm.ShowDialog() == DialogResult.OK)
                //    PopulateInventoryLevelDetailGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmInventoryLevel::btnDeleteSpecification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteValue_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Inventory Item value", this.SelectedLevelValueID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceInventoryItems()).DeleteInventoryItemvalueInfo(this.SelectedLevelValueID))
                           GetAllInventoryLevels();
                     //     PopulateInventoryLevelGrid();
                        PopulateInventoryLevelDetailGrid(); 
                   
                }

                //frmDelete frm = new frmDelete(APP_ENTITIES.INVENTORY_ITEM, this.SelectedLevelValueID);
                //if (frm.ShowDialog() == DialogResult.OK)
                //    PopulateInventoryLevelDetailGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmInventoryLevel::btnDeleteValue_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
