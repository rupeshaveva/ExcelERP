using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
using libERP.SERVICES;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms.UserList
{
    public partial class frmAdminCategory : Form
    {
        public int ADMINCategoryID { get; set; }

        public frmAdminCategory()
        {
            InitializeComponent();
        }
        public frmAdminCategory(int adminCatID)
        {
            InitializeComponent();
            this.ADMINCategoryID = adminCatID;
        }

        private void frmAdminCategory_Load(object sender, EventArgs e)
        {
            txtCategoryName.Text = string.Empty;
            chkIsActive.Checked = true;

            if (this.ADMINCategoryID != 0)
            {
                TBL_MP_Admin_Category model = (new ServiceMASTERS()).GetAdminMasterDBCategory(this.ADMINCategoryID);
                if (model != null)
                {
                    txtCategoryName.Text = model.Admin_Category_Description;
                    chkShortCodeRequired.Checked = model.ShortCodeRequired;
                    chkIsActive.Checked = model.IsActive;

                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ServiceMASTERS _masterService = new ServiceMASTERS();
            try
            {
                if (!this.ValidateChildren()) return;
                TBL_MP_Admin_Category model = null;
                if (this.ADMINCategoryID == 0)
                    model = new TBL_MP_Admin_Category();
                else
                    model = _masterService.GetAdminMasterDBCategory(this.ADMINCategoryID);

                model.Admin_Category_Description = txtCategoryName.Text.Trim();
                model.ShortCodeRequired = chkShortCodeRequired.Checked;
                model.IsActive = chkIsActive.Checked;

                if (this.ADMINCategoryID == 0)
                {
                    int mID = _masterService.AddNewAdminMasterCategory(model);
                    if (mID > 0)
                    {
                        this.ADMINCategoryID = mID;
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    bool res = _masterService.UpdateAdminMasterCategory(model);
                    if (res) DialogResult = DialogResult.OK;
                }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAdminCategory::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCategoryName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCategoryName, "Can't be left Blank");
                e.Cancel = true;
            }

        }
    }
}
