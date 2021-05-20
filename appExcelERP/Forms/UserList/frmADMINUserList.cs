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


using libERP;

namespace appExcelERP.Forms.UserList
{
    public partial class frmADMINUserList : Form
    {
        private ServiceUOW _UOM = null;
        
        public int ADMINCategoryID { get; set; }
        public bool SHORT_CODE_REQUIRED { get; set; }

        public int UserListID { get; set; }

        public frmADMINUserList()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
        }
        public frmADMINUserList(int valueID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.UserListID = valueID;
        }

        private void frmADMINCategory_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
            txtCategoryName.Text = string.Empty;

            if (this.UserListID != 0)
            {
                TBL_MP_Admin_UserList model=_UOM.AppDBContext.TBL_MP_Admin_UserList.Where(x => x.PKID == this.UserListID).FirstOrDefault();
                if (model != null)
                {
                    txtCategoryName.Text = model.Admin_UserList_Desc;
                    txtShortCode.Text = model.ShortCode;
                    chkIsActive.Checked = model.IsActive;
                }
            }
        }

        private void txtCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCategoryName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCategoryName, "Category name can't be left blank.");
                e.Cancel = true;
            }
        }
        private void txtShortCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtShortCode.Text.Trim() == string.Empty)
            {
                if (this.SHORT_CODE_REQUIRED)
                {
                    errorProvider1.SetError(txtShortCode, "Short Code Required.");
                    e.Cancel = true;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                TBL_MP_Admin_UserList model = null;
                if (!this.ValidateChildren()) return;
                if (this.UserListID == 0)
                    model = new TBL_MP_Admin_UserList();
                else
                    model = _UOM.MasterService.GetAdminUserListDBCategory(UserListID);

                if (model != null)
                {
                    model.Fk_Admin_CategoryID = this.ADMINCategoryID;
                    model.Admin_UserList_Desc = txtCategoryName.Text.Trim();
                    model.ShortCode = txtShortCode.Text.Trim();
                    model.IsActive = chkIsActive.Checked;
                }
                if (this.UserListID == 0)
                {
                    int newID = _UOM.MasterService.AddNewADMINUserListItem(model);
                    if (newID > 0)
                    {
                        this.UserListID = newID;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    bool result = _UOM.MasterService.UpdateADMINUserListItem(model);
                    if (result) this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmADMINUserList::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmADMINCategory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

       
    }
}
