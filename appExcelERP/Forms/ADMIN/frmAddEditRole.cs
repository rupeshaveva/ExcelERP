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
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.ADMIN;

namespace appExcelERP.Forms.ADMIN
{
    public partial class frmAddEditRole : KryptonForm
    {
        public int ROLE_ID { get; set; }
        public frmAddEditRole()
        {
            InitializeComponent();
        }
        public frmAddEditRole(int roleID)
        {
            InitializeComponent();
            this.ROLE_ID = roleID;
        }
        private void frmAddEditRole_Load(object sender, EventArgs e)
        {
            try
            {
                txtRoleName.Text = txtRoleNo.Text = string.Empty;
                chkIsActive.Checked = true;
                txtRoleNo.Text = (new ServiceRoles()).GetNewRoleNo();
                this.Text = "Application Role [ADD NEW]";
                if (this.ROLE_ID != 0)
                {
                    TBL_MP_Master_Role role = (new ServiceRoles()).GetRoleDBRecordByID(this.ROLE_ID);
                    if (role != null)
                    {
                        txtRoleNo.Text = role.RoleNo;
                        txtRoleName.Text = role.RoleName;
                        chkIsActive.Checked = (bool)role.IsActive;
                    }
                    this.Text = "Application Role [EDIT]";
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditRole::frmAddEditRole_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TBL_MP_Master_Role model = null;
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    if (this.ROLE_ID == 0)
                    {
                        model = new TBL_MP_Master_Role()
                        {
                            RoleName = txtRoleName.Text.Trim(),
                            RoleNo = txtRoleNo.Text.Trim(),
                            IsActive = chkIsActive.Checked
                        };
                        this.ROLE_ID = (new ServiceRoles()).AddNewRole(model);
                        if (this.ROLE_ID != 0) this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        model = (new ServiceRoles()).GetRoleDBRecordByID(this.ROLE_ID);
                        if (model != null)
                        {
                            model.RoleName = txtRoleName.Text.Trim();
                            model.RoleNo = txtRoleNo.Text.Trim();
                            model.IsActive = chkIsActive.Checked;
                            bool res = (new ServiceRoles()).UpdateRole(model);
                            if (res) this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditRole::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
        private void txtRoleName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtRoleName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRoleName, "Mandatory!! and Unique");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditRole::txtRoleName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
