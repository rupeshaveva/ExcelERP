using libERP;
using libERP.SERVICES;
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
    public partial class frmAddEditInventoryLevelDetail : Form
    {
        public int InventoryCategoryID { get; set; }
        public int InventoryLevelID { get; set; }
        public int InventoryLevelDetailID { get; set; }
        
        public frmAddEditInventoryLevelDetail()
        {
            InitializeComponent();
        }
        public frmAddEditInventoryLevelDetail(int detailID)
        {
            this.InventoryLevelDetailID = detailID;
            InitializeComponent();
        }
        private void frmAddEditInventoryLevelDetail_Load(object sender, EventArgs e)
        {
            PrepareForm();
        }
        private void PrepareForm()
        {
            try
            {
                ServiceInventoryItems _service = new ServiceInventoryItems();
                if (this.InventoryLevelID != 0)
                {
                    TBL_MP_Master_Inventory_Level_Details level = _service.GetInventoryLevelDetailDBItem(this.InventoryLevelDetailID);
                    if (level != null)
                    {
                        txtLevelDetailName.Text = level.Inv_Level_Description;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditInventoryLevelDetail::PrepareForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLevelDetailName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceInventoryItems _service = new ServiceInventoryItems();
                if (this.ValidateChildren())
                {
                    if (this.InventoryLevelDetailID == 0)
                    {
                        TBL_MP_Master_Inventory_Level_Details newDetail = new TBL_MP_Master_Inventory_Level_Details();
                        newDetail.Fk_Inv_Level_ID = this.InventoryLevelID;
                        newDetail.Inv_Level_Description =newDetail.Inv_Level_Value = txtLevelDetailName.Text.Trim();
                        newDetail.IsActive = true;
                        this.InventoryLevelDetailID= _service.AddNewInventoryLevelDetail(newDetail);
                    }
                    else
                    {
                        TBL_MP_Master_Inventory_Level_Details detail = _service.GetInventoryLevelDetailDBItem(this.InventoryLevelDetailID);
                        if (detail != null)
                        {
                            detail.Fk_Inv_Level_ID = this.InventoryLevelID;
                            detail.Inv_Level_Description = detail.Inv_Level_Value = txtLevelDetailName.Text.Trim();
                            _service.UpdateInventoryLevelDetail(detail);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditInventoryLevelDetail::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
