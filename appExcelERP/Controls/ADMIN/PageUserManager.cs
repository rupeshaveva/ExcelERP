using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using libERP.SERVICES;
using libERP;

using appExcelERP.Forms.ADMIN;
using appExcelERP.Forms;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.ADMIN;
using libERP.MODELS.ADMIN;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.ADMIN
{
    public partial class PageUserManager : UserControl
    {
        public int FormOperationID { get; set; }

        public int SelectedUserID { get; set; }
        public int SelectedEmployeeID { get; set; }

        private BindingList<SelectListItem> _ActiveUsersList = null;
        private BindingList<SelectListItem> _filteredActiveUsersList = null;

        private BindingList<SelectListItem> _InactiveUsersList = null;
        private BindingList<SelectListItem> _filteredInactiveUsersList = null;


        private BindingList<UserAccessPermissionsModel> _RolewiseAccessPermissionList = null;
        private BindingList<UserAccessPermissionsModel> _filteredRolewiseAccessPermissionList = null;

        public int SelectedCustomPermissionID { get; set; }
        private BindingList<UserAccessPermissionsModel> _CustomAccessPermissionList = null;
        private BindingList<UserAccessPermissionsModel> _filteredCustomAccessPermissionList = null;


        public PageUserManager()
        {
            InitializeComponent();
        }
        private void PageUserManager_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateInactiveUsers();
                PopulateActiveUsers();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::PageUserManager_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region ACTIVE USERS
        private void PopulateActiveUsers()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _ActiveUsersList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceUsers()).GetAllActiveUsers());
                gridActiveUsers.DataSource = _ActiveUsersList;
                gridActiveUsers.Columns["ID"].Visible = gridActiveUsers.Columns["Code"].Visible = gridActiveUsers.Columns["IsActive"].Visible = gridActiveUsers.Columns["DescriptionToUpper"].Visible = false;
                headerGroupActiveUsers.ValuesSecondary.Heading = string.Format("{0} Record(s) found", gridActiveUsers.Rows.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::PopulateUsers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridActiveUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedUserID = (int)gridActiveUsers.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedEmployeeID = int.Parse(gridActiveUsers.Rows[e.RowIndex].Cells["Code"].Value.ToString());
                bool isactive = (bool)gridActiveUsers.Rows[e.RowIndex].Cells["IsActive"].Value;
                headerGroupAssignedRoles.Enabled = headerGroupCustomPrivileges.Enabled = isactive;
                headerGroupUserManager.ValuesPrimary.Heading = gridActiveUsers.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                PopulateRoleInfo();
                PopulateCustomPermissions();
  
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::gridActiveUsers_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchActiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredActiveUsersList = new BindingList<SelectListItem>(_ActiveUsersList.Where(p => p.DescriptionToUpper.Contains(txtSearchActiveUsers.Text.ToUpper())).ToList());
                gridActiveUsers.DataSource = _filteredActiveUsersList;
                headerGroupActiveUsers.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridActiveUsers.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::txtSearchUsers_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region IN-ACTIVE USERS
        private void PopulateInactiveUsers()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _InactiveUsersList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceUsers()).GetAllInactiveUsers());
                gridInactiveUsers.DataSource = _InactiveUsersList;
                gridInactiveUsers.Columns["ID"].Visible = gridInactiveUsers.Columns["Code"].Visible = gridInactiveUsers.Columns["IsActive"].Visible = gridInactiveUsers.Columns["DescriptionToUpper"].Visible = false;
                headerGroupInActiveUsers.ValuesSecondary.Heading = string.Format("{0} Record(s) found", gridInactiveUsers.Rows.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::PopulateInactiveUsers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridInactiveUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedUserID = (int)gridInactiveUsers.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedEmployeeID = int.Parse(gridInactiveUsers.Rows[e.RowIndex].Cells["Code"].Value.ToString());
                bool isactive = (bool)gridInactiveUsers.Rows[e.RowIndex].Cells["IsActive"].Value;
                headerGroupAssignedRoles.Enabled = headerGroupCustomPrivileges.Enabled = isactive;
                headerGroupUserManager.ValuesPrimary.Heading = gridInactiveUsers.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                PopulateRoleInfo();
                PopulateCustomPermissions();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::gridInactiveUsers_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchInactiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredInactiveUsersList = new BindingList<SelectListItem>(_InactiveUsersList.Where(p => p.DescriptionToUpper.Contains(btnSearchInactiveUsers.Text.ToUpper())).ToList());
                gridInactiveUsers.DataSource = _filteredInactiveUsersList;
                headerGroupInActiveUsers.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridInactiveUsers.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::txtSearchInactiveUsers_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion
        
        #region USER ROLE ACCESS AND PERMISSIONS
        private void PopulateRoleInfo()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _RolewiseAccessPermissionList = null;
                gridAssignedRoleForms.DataSource = null;
                headerGroupAssignedRoles.ValuesPrimary.Heading = string.Empty;
                TBL_User_Master dbUser = (new ServiceUsers()).GetUserDBModelByUserID(this.SelectedUserID);
                if (dbUser != null)
                {
                    if (dbUser.FK_RoleId != null)
                    {
                        TBL_MP_Master_Role dbRole = (new ServiceRoles()).GetRoleDBRecordByID((int)dbUser.FK_RoleId);
                        if (dbRole != null)
                        {
                            headerGroupAssignedRoles.ValuesPrimary.Heading = dbRole.RoleName.ToUpper() + " (Assigned Role)";
                        }
                        _RolewiseAccessPermissionList = (new ServiceUsers()).GetRoleWiseAccessPermissionForUser(this.SelectedUserID);
                        gridAssignedRoleForms.DataSource = _RolewiseAccessPermissionList;
                        headerGroupAssignedRoles.ValuesSecondary.Heading = string.Format("{0} Records found.", gridAssignedRoleForms.Rows.Count);
                    }
                   

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::PopulateRoleInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridRoleForms_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridAssignedRoleForms.Columns["ID"].Visible = gridAssignedRoleForms.Columns["RoleID"].Visible = gridAssignedRoleForms.Columns["ModuleID"].Visible = gridAssignedRoleForms.Columns["FormID"].Visible = false;
                gridAssignedRoleForms.Columns["RoleName"].Visible = gridAssignedRoleForms.Columns["SearchString"].Visible = false;
                gridAssignedRoleForms.Columns["ModuleName"].Width = (int)(gridAssignedRoleForms.Width * .2);
                gridAssignedRoleForms.Columns["FormName"].Width = (int)(gridAssignedRoleForms.Width * .3);
                gridAssignedRoleForms.Columns["Permissions"].Width = (int)(gridAssignedRoleForms.Width * .5);
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::gridRoleForms_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                _ActiveUsersList = null;
                _InactiveUsersList = null;
                PopulateInactiveUsers();
                PopulateActiveUsers();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnAddModifyRole_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.ROLES);
                frm.SingleSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.SelectedItems.Count > 0)
                    {
                        int roleID = frm.SelectedItems[0].ID;
                        (new ServiceUsers()).UpdateUserRole(this.SelectedUserID, roleID);
                        PopulateRoleInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::btnAddModifyRole_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchRolePermissions_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredRolewiseAccessPermissionList = new BindingList<UserAccessPermissionsModel>(_RolewiseAccessPermissionList.Where(p => p.SearchString.Contains(txtSearchAssignedRoleForms.Text.ToUpper())).ToList());
                gridAssignedRoleForms.DataSource = _filteredRolewiseAccessPermissionList;
                headerGroupAssignedRoles.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridAssignedRoleForms.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::btnSearchRolePermissions_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        #endregion

        #region USER CUSTOM PERMISSION
        private void PopulateCustomPermissions()
        {
            try
            {
                _CustomAccessPermissionList = (new ServiceUsers()).GetCustomAccessPermissionForUser(this.SelectedEmployeeID);
                gridCustomPermissions.DataSource = _CustomAccessPermissionList;
                headerGroupCustomPrivileges.ValuesSecondary.Heading = string.Format("{0} Records found.", gridCustomPermissions.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::PopulateCustomPermissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridCustomPermissions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridCustomPermissions.Columns["ID"].Visible = gridCustomPermissions.Columns["RoleID"].Visible = gridCustomPermissions.Columns["ModuleID"].Visible = gridCustomPermissions.Columns["FormID"].Visible = false;
                gridCustomPermissions.Columns["RoleName"].Visible = gridCustomPermissions.Columns["SearchString"].Visible = false;
                gridCustomPermissions.Columns["ModuleName"].Width = (int)(gridCustomPermissions.Width * .2);
                gridCustomPermissions.Columns["FormName"].Width = (int)(gridCustomPermissions.Width * .3);
                gridCustomPermissions.Columns["Permissions"].Width = (int)(gridCustomPermissions.Width * .5);

                if (gridCustomPermissions.Rows.Count == 0)
                    btnEditPermission.Enabled = btnRemoveCustomPermission.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                else
                    btnEditPermission.Enabled = btnRemoveCustomPermission.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::gridCustomPermissions_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridCustomPermissions_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedCustomPermissionID = (int)gridCustomPermissions.Rows[e.RowIndex].Cells["ID"].Value;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::gridCustomPermissions_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchCustomPermission_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredCustomAccessPermissionList = new BindingList<UserAccessPermissionsModel>(_CustomAccessPermissionList.Where(p => p.SearchString.Contains(txtSearchActiveUsers.Text.ToUpper())).ToList());
                gridCustomPermissions.DataSource = _filteredCustomAccessPermissionList;
                headerGroupCustomPrivileges.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCustomPermissions.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::txtSearchCustomPermission_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddCustomPermission_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCustomPermission frm = new frmAddEditCustomPermission();
                frm.SelectedEmployeeID = this.SelectedEmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCustomPermissions();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::btnAddCustomPermission_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEditPermission_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCustomPermission frm = new frmAddEditCustomPermission(this.SelectedCustomPermissionID);
                frm.SelectedEmployeeID = this.SelectedEmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCustomPermissions();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserManager::btnEditPermission_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchCustomPermissions_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredCustomAccessPermissionList = new BindingList<UserAccessPermissionsModel>(_CustomAccessPermissionList.Where(p => p.SearchString.Contains(txtSearchCustomPermission.Text.ToUpper())).ToList());
                gridCustomPermissions.DataSource = _filteredCustomAccessPermissionList;
                headerGroupCustomPrivileges.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCustomPermissions.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::btnSearchCustomPermissions_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnRemoveCustomPermission_Click(object sender, EventArgs e)
        {
            string strMessage = "Are you sure to revoke selected Custom Permission from theUser";
            try
            {
                if (MessageBox.Show(strMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    (new ServiceUsers()).RemoveCustomPermission(this.SelectedCustomPermissionID);
                    PopulateCustomPermissions();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::btnSearchCustomPermissions_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion


    }
}
