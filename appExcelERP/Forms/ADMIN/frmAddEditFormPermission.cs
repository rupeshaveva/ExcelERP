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
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.ADMIN;

namespace appExcelERP.Forms.ADMIN
{
    public partial class frmAddEditFormPermission : KryptonForm
    {
        string uniCodeCharacter = "\u2714";
        public int RoleFormID { get; set; }
        public int RoleID { get; set; }
        public int ModuleID { get; set; }
        public int FormID { get; set; }


        public frmAddEditFormPermission(int roleformID)
        {
            InitializeComponent();
            this.RoleFormID = roleformID;
            
        }
        private void SetPermissionButtonsTag()
        {
            try
            {
                btnCanAddNewRecord.Tag = PERMISSIONS.ADD_NEW;
                btnCanApproveRecord.Tag = PERMISSIONS.APPROVE;
                btnCanAuthorizeRecord.Tag = PERMISSIONS.AUTHORIZE;
                btnCanCheckRecord.Tag = PERMISSIONS.CHECK;
                btnCanDeleteRecord.Tag = PERMISSIONS.DELETE;
                btnCanModifyRecord.Tag = PERMISSIONS.MODIFY;
                btnCanPrintRecord.Tag = PERMISSIONS.PRINT;
                btnCanViewRecord.Tag = PERMISSIONS.VIEW;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFormPermission::SetPermissionButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void frmAddEditFormPermission_Load(object sender, EventArgs e)
        {
            try
            {
                SetPermissionButtonsTag();
                if (RoleFormID != 0)
                {
                    TBL_MP_Master_RoleForm model = (new ServiceRoles()).GetRoleModuleFormDBRecordByID(this.RoleFormID);
                    if (model != null)
                    {
                        Tbl_MP_Master_Module dbModule = (new ServiceModules()).GetModuleDBRecordByID((int)model.FK_ModuleId);
                        if (dbModule != null)
                            lblModuleName.Text = dbModule.DisplayName.ToUpper();

                        Tbl_MP_Master_Module_Forms dbModuleForm = (new ServiceModules()).GetModuleFormDBRecordByID((int)model.FK_FormId);
                        if (dbModuleForm != null)
                            lblFormName.Text =dbModuleForm.DisplayName;

                        btnCanAddNewRecord.Checked = model.CanAddNew;
                        PermissionsButton_Click(btnCanAddNewRecord, new EventArgs());

                        btnCanApproveRecord.Checked = model.CanApprove;
                        PermissionsButton_Click(btnCanApproveRecord, new EventArgs());

                        btnCanAuthorizeRecord.Checked = model.CanAuthorize;
                        PermissionsButton_Click(btnCanAuthorizeRecord, new EventArgs());

                        btnCanCheckRecord.Checked = model.CanCheck;
                        PermissionsButton_Click(btnCanCheckRecord, new EventArgs());

                        btnCanDeleteRecord.Checked = model.CanDelete;
                        PermissionsButton_Click(btnCanDeleteRecord, new EventArgs());

                        btnCanModifyRecord.Checked = model.CanModify;
                        PermissionsButton_Click(btnCanModifyRecord, new EventArgs());

                        btnCanPrintRecord.Checked = model.CanPrint;
                        PermissionsButton_Click(btnCanPrintRecord, new EventArgs());

                        btnCanViewRecord.Checked = model.CanView;
                        PermissionsButton_Click(btnCanViewRecord, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFormPermission::frmAddEditFormPermission_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                
        }
        private void PermissionsButton_Click(object sender, EventArgs e)
        {
            try
            {
                PERMISSIONS permissionType = (PERMISSIONS)((ComponentFactory.Krypton.Toolkit.KryptonCheckButton)sender).Tag;
                bool isChecked = ((ComponentFactory.Krypton.Toolkit.KryptonCheckButton)sender).Checked;
                string strText = string.Empty;
                switch (permissionType)
                {
                    case PERMISSIONS.ADD_NEW: strText = "Can Add a New Record"; break;
                    case PERMISSIONS.APPROVE: strText = "Can Approve  Record"; break;
                    case PERMISSIONS.AUTHORIZE: strText = "Can Authorize  Record"; break;
                    case PERMISSIONS.CHECK: strText = "Can Check  Record"; break;
                    case PERMISSIONS.DELETE: strText = "Can Delete  Record"; break;
                    case PERMISSIONS.MODIFY: strText = "Can Modify  Record"; break;
                    case PERMISSIONS.PRINT: strText = "Can Print  Record"; break;
                    case PERMISSIONS.SEARCH: strText = "Can Search  Record"; break;
                    case PERMISSIONS.UNDELETE: strText = "Can Undelete  Record"; break;
                    case PERMISSIONS.VIEW: strText = "Can View  Record"; break;
                }
                if (isChecked) strText += string.Format(" {0}", uniCodeCharacter);
                ((ComponentFactory.Krypton.Toolkit.KryptonCheckButton)sender).Text = strText;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFormPermission::PermissionsButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                TBL_MP_Master_RoleForm model = (new ServiceRoles()).GetRoleModuleFormDBRecordByID(this.RoleFormID);
                if (model != null)
                {
                    model.CanAddNew = btnCanAddNewRecord.Checked;
                    model.CanApprove = btnCanApproveRecord.Checked;
                    model.CanAuthorize = btnCanAuthorizeRecord.Checked;
                    model.CanCheck = btnCanCheckRecord.Checked;
                    model.CanDelete = btnCanDeleteRecord.Checked;
                    model.CanModify = btnCanModifyRecord.Checked;
                    model.CanPrint = btnCanPrintRecord.Checked;
                    model.CanView = btnCanViewRecord.Checked;
                    bool result=(new ServiceRoles()).UpdateRoleModuleFormPermission(model);
                    if (result) this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditFormPermission::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
