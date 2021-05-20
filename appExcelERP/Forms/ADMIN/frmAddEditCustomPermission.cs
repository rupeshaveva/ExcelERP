
using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.ADMIN
{
    public partial class frmAddEditCustomPermission : Form
    {
        string uniCodeCharacter = "\u2714";
        
        public int CustomPermissionID { get; set; }
        public int SelectedEmployeeID { get; set; }
        public int SelectedModuleID { get; set; }
        public int SelectedFormID { get; set; }

        public frmAddEditCustomPermission()
        {
            InitializeComponent();
        }
        public frmAddEditCustomPermission(int pkID)
        {
            InitializeComponent();
            this.CustomPermissionID = pkID;
        }

        private void frmAddEditCustomPermission_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SetPermissionButtonsTag();
                PopulateModulesDropdown();
                PopulateModuleFormsDropdown();

                if (this.CustomPermissionID != 0)
                {
                    TBL_User_CustomPermissions model=(new ServiceUsers()).GetCustomPermissionByPermissionID(this.CustomPermissionID);
                    if (model != null)
                    {
                        this.SelectedModuleID = (int)model.fk_ModuleId;
                        cboModules.SelectedItem = ((List<SelectListItem>)cboModules.DataSource).Where(x => x.ID == SelectedModuleID).FirstOrDefault();

                        this.SelectedFormID = (int)model.fk_FormId;
                        cboForms.SelectedItem = ((List<SelectListItem>)cboForms.DataSource).Where(x => x.ID == SelectedFormID).FirstOrDefault();

                        btnCanAddNewRecord.Checked = model.CanAddNew;
                        PermissionsButton_Click(btnCanAddNewRecord, null);
                        btnCanApproveRecord.Checked = model.CanApprove;
                        PermissionsButton_Click(btnCanApproveRecord, null);
                        btnCanAuthorizeRecord.Checked = model.CanAuthorize;
                        PermissionsButton_Click(btnCanAuthorizeRecord, null);
                        btnCanCheckRecord.Checked = model.CanCheck;
                        PermissionsButton_Click(btnCanCheckRecord, null);
                        btnCanDeleteRecord.Checked = model.CanDelete;
                        PermissionsButton_Click(btnCanDeleteRecord, null);
                        btnCanModifyRecord.Checked = model.CanModify;
                        PermissionsButton_Click(btnCanModifyRecord, null);
                        btnCanPrintRecord.Checked = model.CanPrint;
                        PermissionsButton_Click(btnCanPrintRecord, null);
                        btnCanViewRecord.Checked = model.CanView;
                        PermissionsButton_Click(btnCanViewRecord, null);
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::frmAddEditCustomPermission_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
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
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::SetPermissionButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::PermissionsButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void PopulateModulesDropdown()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceModules()).GetAllActiveModules());
                cboModules.DataSource = LST;
                cboModules.ValueMember = "ID";
                cboModules.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::PopulateModulesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void PopulateModuleFormsDropdown()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceModules()).GetAllActiveFormsForModule(this.SelectedModuleID));
                cboForms.DataSource = LST;
                cboForms.ValueMember = "ID";
                cboForms.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::PopulateModuleFormsDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                TBL_User_CustomPermissions model = null;
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    if (this.CustomPermissionID != 0)
                    {
                        model = (new ServiceUsers()).GetCustomPermissionByPermissionID(this.CustomPermissionID);
                        model.CanAddNew = btnCanAddNewRecord.Checked;
                        model.CanApprove = btnCanApproveRecord.Checked;
                        model.CanAuthorize = btnCanAuthorizeRecord.Checked;
                        model.CanCheck = btnCanCheckRecord.Checked;
                        model.CanDelete = btnCanDeleteRecord.Checked;
                        model.CanModify = btnCanModifyRecord.Checked;
                        model.CanPrint = btnCanPrintRecord.Checked;
                        model.CanView = btnCanViewRecord.Checked;

                        model.fk_ModuleId = this.SelectedModuleID;
                        model.fk_FormId = this.SelectedFormID;
                        model.fk_EmployeeId = this.SelectedEmployeeID;
                        if ((new ServiceUsers()).UpdateCustomPermission(this.CustomPermissionID, model))
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        model = new TBL_User_CustomPermissions()
                        {
                            CanAddNew = btnCanAddNewRecord.Checked,
                            CanApprove = btnCanApproveRecord.Checked,
                            CanAuthorize = btnCanAuthorizeRecord.Checked,
                            CanCheck = btnCanCheckRecord.Checked,
                            CanDelete = btnCanDeleteRecord.Checked,
                            CanModify = btnCanModifyRecord.Checked,
                            CanPrint = btnCanPrintRecord.Checked,
                            CanView = btnCanViewRecord.Checked,
                            fk_ModuleId = this.SelectedModuleID,
                            fk_FormId = this.SelectedFormID,
                            fk_EmployeeId = this.SelectedEmployeeID
                        };
                        int newID = (new ServiceUsers()).AddNewCustomPermission(model);
                        if (newID > 0)
                            this.DialogResult = DialogResult.OK;
                    }


                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void cboModules_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedModuleID = ((SelectListItem)cboModules.SelectedItem).ID;
                PopulateModuleFormsDropdown();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::cboModules_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboForms_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelectedFormID = ((SelectListItem)cboForms.SelectedItem).ID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::cboForms_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboModules_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboModules.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboModules, "Module is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::cboModules_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboForms_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboModules.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboModules, "Forms is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCustomPermission::cboForms_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
