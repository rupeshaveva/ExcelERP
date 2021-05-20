using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms
{
    public partial class frmAddEditInventoryLevel : KryptonForm
    {
        public int InventoryLevelID { get; set; }
        public int CategoryID { get; set; }

        public frmAddEditInventoryLevel()
        {
            InitializeComponent();
        }

        private void frmAddEditInventoryLevel_Load(object sender, EventArgs e)
        {
            PrepareForm();
        }

        private void PrepareForm()
        {
            try
            {
                ServiceInventoryItems _service = new ServiceInventoryItems();
                if (this.CategoryID != 0)
                {
                    TBL_MP_Master_Inventory_Category cat = _service.GetInventoryCategoriesDBItem(this.CategoryID);
                    if (cat != null)
                    {
                        this.Text = "Add New Specification for " + cat.Inv_Category;
                        int newSequence=_service.GetGetNextSequenceNumberOfInventoryLevelForCategory(CategoryID);
                        txtSequence.Text = newSequence.ToString();
                    }
                }
                if (this.InventoryLevelID != 0)
                {
                    TBL_MP_Master_Inventory_Level level = _service.GetInventoryLevelDBItem(this.InventoryLevelID);
                    if (level != null)
                    {
                        txtLevelName.Text = level.Inventory_Level;
                        txtSequence.Text = level.Sequence.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtLevelName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLevelName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtLevelName, "Can't ne left Blank");
                e.Cancel = true;
            }

        }

        private void txtSequence_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSequence.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSequence, "Can't ne left Blank");
                    e.Cancel = true;
                }

                try
                {
                    int seq = 0;
                    int.TryParse(txtSequence.Text, out seq);
                }
                catch (Exception)
                {
                    errorProvider1.SetError(txtSequence, "not a Valid Integer");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditInventoryLevel::txtSequence_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceInventoryItems _service = new ServiceInventoryItems();
                if (this.ValidateChildren())
                {
                    if (this.InventoryLevelID == 0)
                    {
                        TBL_MP_Master_Inventory_Level newLevel = new TBL_MP_Master_Inventory_Level();
                        newLevel.Fk_InvCategory_ID = this.CategoryID;
                        newLevel.Inventory_Level = txtLevelName.Text.Trim();
                        newLevel.Sequence = int.Parse(txtSequence.Text);
                        newLevel.IsActive = true;
                        this.InventoryLevelID = _service.AddNewInventoryLevel(newLevel);
                    }
                    else
                    {
                        TBL_MP_Master_Inventory_Level level = _service.GetInventoryLevelDBItem(this.InventoryLevelID);
                        if (level != null)
                        {
                            level.Fk_InvCategory_ID = this.CategoryID;
                            level.Inventory_Level = txtLevelName.Text.Trim();
                            level.Sequence = int.Parse(txtSequence.Text);
                            _service.UpdateInventoryLevel(level);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditInventoryLevel::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
