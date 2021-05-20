using libERP;
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

namespace appExcelERP.Forms.UserList
{
    public partial class frmMasterUserList : Form
    {
       
        private ServiceUOW _UOM = null;

        public int MASTERCategoryID { get; set; }
        public int ID { get; set; }

        public frmMasterUserList()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
        }
        public frmMasterUserList(int mID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            ID = mID;
        }

        private void frmMasterUserList_Load(object sender, EventArgs e)
        {
            txtCategoryName.Text = string.Empty;
            chkIsActive.Checked = true;
            if (this.ID != 0)
            {
                TBL_MP_Master_UserList model=_UOM.AppDBContext.TBL_MP_Master_UserList.Where(x => x.pk_UserListId == this.ID).FirstOrDefault();
                if (model != null)
                {
                    txtCategoryName.Text = model.Description1;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.ValidateChildren())
                {
                    if (this.ID == 0)
                    {
                        int newID = _UOM.MasterService.AddNewMASTERUserListItem(this.MASTERCategoryID, txtCategoryName.Text, chkIsActive.Checked,
                            Program.CURR_USER.CompanyID, Program.CURR_USER.BranchID);
                        if (newID > 0)
                        {
                            this.ID = newID;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        TBL_MP_Master_UserList model = _UOM.AppDBContext.TBL_MP_Master_UserList.Where(x => x.pk_UserListId == this.ID).FirstOrDefault();
                        if (model != null)
                        {
                            model.Description1 = txtCategoryName.Text;
                            model.IsActive = chkIsActive.Checked;
                        }
                        _UOM.AppDBContext.SaveChanges();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMasterUserList::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
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
