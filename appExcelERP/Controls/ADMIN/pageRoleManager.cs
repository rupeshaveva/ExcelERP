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
using libERP.SERVICES.HR;
using libERP.MODELS.COMMON;
using libERP.MODELS.ADMIN;

namespace appExcelERP.Controls.ADMIN
{
    public partial class pageRoleManager : UserControl
    {
        public int FormOperationID { get; set; }

        public int SelectedRoleID { get; set; }
        private BindingList<SelectListItem> _RolesList = null;
        private BindingList<SelectListItem> _filteredRolesList = null;

        public int SelectedRoleModuleID { get; set; }
        public int SelectedModuleID { get; set; }
        private BindingList<MultiSelectListItem> _roleModulesList = null;
        private BindingList<MultiSelectListItem> _filteredRoleModulesList = null;


        public int SelectedRoleModuleFormID { get; set; }
        public int SelectedFormID { get; set; }
        private BindingList<RoleModuleForm> _roleModuleFormsList = null;
        private BindingList<RoleModuleForm> _filteredRoleModuleFormsList = null;

        public pageRoleManager()
        {
            InitializeComponent();
            //_ctrlAccessRights = new ctrlAddEditAccessRights();
            //splitContainerAccessRights.Panel2.Controls.Add(_ctrlAccessRights);
            //_ctrlAccessRights.Dock = DockStyle.Fill;
        }

        private void pageRoleManager_Load(object sender, EventArgs e)
        {
            try
            {
                splitContainerMain.SplitterDistance = (int)(this.Width * .35);
                splitContainerModuleAndForms.SplitterDistance = (int)(splitContainerMain.Panel2.Width * .5);
                PopulateRoles();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::pageRoleManager_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateRoles();
        }


        #region USER ROLES
        private void PopulateRoles()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _RolesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceRoles()).GetAllRoles());
                gridRoles.DataSource = _RolesList;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::PopulateRoles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void FormatRolesGrid()
        {
            try
            {

                foreach (DataGridViewRow row in gridRoles.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridRoles.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridRoles.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::FormatRolesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridRoles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridRoles.Columns["ID"].Visible = gridRoles.Columns["Code"].Visible = gridRoles.Columns["IsActive"].Visible = gridRoles.Columns["DescriptionToUpper"].Visible = false;
                gridRoles.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupRoles.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridRoles.RowCount);
                FormatRolesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::gridRoles_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void gridRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void gridRoles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SelectedRoleID = (int)gridRoles.Rows[e.RowIndex].Cells["ID"].Value;
                    headerGroupModule.ValuesPrimary.Heading = string.Format("[{0}] - Accessible Modules", gridRoles.Rows[e.RowIndex].Cells["Description"].Value);
                    PopulateRoleModules();
                }

                headerGroupDeleteRole.ValuesPrimary.Heading = string.Empty;
                txtDeleteRoleInfo.Text = string.Empty;

                bool isactive = (bool)gridRoles.Rows[e.RowIndex].Cells["IsActive"].Value;
                if (isactive)
                {
                    btnAddNewRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnEditRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnDeleteRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnRestoreRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;

                    headerGroupModule.Enabled = headerGroupForms.Enabled= true;
                }
                else
                {
                    btnAddNewRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnEditRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnDeleteRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnRestoreRole.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;

                    headerGroupModule.Enabled = headerGroupForms.Enabled = false;

                }

                TBL_MP_Master_Role dbRole = (new ServiceRoles()).GetRoleDBRecordByID(this.SelectedRoleID);
                if (dbRole != null)
                {
                    if (dbRole.DeletedBy != null)
                    {
                        string empName = ServiceEmployee.GetEmployeeNameByID((int)dbRole.DeletedBy);
                        headerGroupDeleteRole.ValuesPrimary.Heading = string.Format("Deleted by {0} dt. {1}", empName, dbRole.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                    }
                    txtDeleteRoleInfo.Text = dbRole.DeleteRemarks;
                }



            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::gridRoles_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchRoles_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                _filteredRolesList = new BindingList<SelectListItem>(_RolesList.Where(p => p.DescriptionToUpper.Contains(txtSearchRoles.Text.ToUpper())).ToList());
                gridRoles.DataSource = _filteredRolesList;
                headerGroupRoles.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridRoles.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::txtSearchRoles_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
         private void btnAddNewRole_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditRole frm = new frmAddEditRole();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateRoles();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnAddNewRole_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEditRole_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditRole frm = new frmAddEditRole(this.SelectedRoleID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateRoles();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnEditRole_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            try
            {
                frmDelete frm = new frmDelete(APP_ENTITIES.ROLES, this.SelectedRoleID);
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateRoles();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnDeleteRole_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRestoreRole_Click(object sender, EventArgs e)
        {
            try
            {
                string strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MM yy hh:sstt"));
                (new ServiceRoles()).UndeleteRoleMasterInfo(this.SelectedRoleID, strRemarks);
                PopulateRoles();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnRestoreRole_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region ROLE MODULES
        private void PopulateRoleModules()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedModuleID = 0;
                _roleModuleFormsList = new BindingList<RoleModuleForm>();
                gridForms.DataSource = _roleModuleFormsList;
                _roleModulesList = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceRoles()).GetMultiSelectModulesForRole(this.SelectedRoleID));
                gridModules.DataSource = _roleModulesList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::PopulateRoleModules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor; 
        }
        private void gridModules_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridModules.Columns["Selected"].Visible = false;
                gridModules.Columns["ID"].Visible = gridModules.Columns["Code"].Visible = gridModules.Columns["EntityType"].Visible = gridModules.Columns["DescriptionToUpper"].Visible = false;
                gridModules.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupModule.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridModules.RowCount);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::gridModules_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void txtSearchModule_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                _filteredRoleModulesList = new BindingList<MultiSelectListItem>(_roleModulesList.Where(p => p.DescriptionToUpper.Contains(txtSearchModule.Text.ToUpper())).ToList());
                gridModules.DataSource = _filteredRoleModulesList;
                headerGroupRoles.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridModules.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::txtSearchModule_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridModules_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SelectedModuleID = int.Parse(gridModules.Rows[e.RowIndex].Cells["Code"].Value.ToString());
                    SelectedRoleModuleID = (int)gridModules.Rows[e.RowIndex].Cells["ID"].Value;
                    SelectedRoleModuleFormID = 0;
                    PopulateRoleModuleForms();
                    headerGroupForms.ValuesPrimary.Heading = string.Format("[{0}] - Operations List", gridModules.Rows[e.RowIndex].Cells["Description"].Value);
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::gridModules_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewModule_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.APPLICATION_MODULES);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.SelectedItems != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (MultiSelectListItem item in frm.SelectedItems)
                        {
                            MultiSelectListItem foundItem = _roleModulesList.Where(x => x.Code == item.ID.ToString()).FirstOrDefault();
                            if (foundItem == null)
                                _roleModulesList.Add(new MultiSelectListItem() { ID = 0, Code = item.ID.ToString(), Description = item.Description });
                        }
                        (new ServiceRoles()).UpdateRoleModules(this.SelectedRoleID, _roleModulesList);
                        PopulateRoleModules();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnAddNewModule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            try
            {
                // IN GRID WE HAVE {{CODE}} COLUMN TO HOLD MODULE-ID
                MultiSelectListItem selItem = _roleModulesList.Where(x => x.ID == this.SelectedRoleModuleID).FirstOrDefault();
                if (selItem != null)
                {
                    string strMessage = "Are You sure to remove " + selItem.Description + " from the List of Assigned Modules";
                    if (MessageBox.Show(strMessage, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        (new ServiceRoles()).RemoveRoleModule(this.SelectedRoleModuleID);
                        PopulateRoleModules();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnDeleteModule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        #endregion  

        #region ROLE MODULES FORMS
        private void PopulateRoleModuleForms()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _roleModuleFormsList = AppCommon.ConvertToBindingList<RoleModuleForm>((new ServiceRoles()).GetFormsGridForRoleModule(this.SelectedRoleID, this.SelectedModuleID));
                gridForms.DataSource = _roleModuleFormsList;
                
                
                //FormatModulesGrid();
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::PopulateRoleModuleForms", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void txtSearchForm_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredRoleModuleFormsList = new BindingList<RoleModuleForm>(_roleModuleFormsList.Where(p => p.SearchString.Contains(txtSearchForm.Text.ToUpper())).ToList());
                gridForms.DataSource = _filteredRoleModuleFormsList;
                headerGroupForms.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridForms.Rows.Count);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::txtSearchForm_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridForms_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridForms.Columns["ID"].Visible = gridForms.Columns["RoleID"].Visible = gridForms.Columns["ModuleID"].Visible = gridForms.Columns["FormID"].Visible = gridForms.Columns["SearchString"].Visible = false;
                gridForms.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupForms.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridForms.RowCount);
                gridForms.Columns["Selected"].Width = 50;
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::gridForms_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void gridForms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    gridForms.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridForms.Rows[e.RowIndex].Cells["Selected"].Value);
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "pageRoleManager::gridForms_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridForms_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRoleModuleFormID = 0;
            try
            {
                SelectedRoleModuleFormID = (int)gridForms.Rows[e.RowIndex].Cells["ID"].Value;
                if (SelectedRoleModuleFormID != 0)
                    btnChangeAccessRights.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                else
                    btnChangeAccessRights.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;

            }
            catch (Exception ex)
            {
                string errMessgae = ex.Message;
                if (ex.InnerException != null) errMessgae += "\n" + ex.InnerException.Message;
                MessageBox.Show(ex.Message, "pageRoleManager::gridForms_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveRoleForms_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new ServiceRoles()).UpdateRoleModuleForms(this.SelectedRoleID, this._roleModuleFormsList);
                PopulateRoleModuleForms();

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnSaveRoleForms_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnChangeAccessRights_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedRoleModuleFormID == 0)
                {
                    MessageBox.Show("In order to perform Permission Setting, You need a valid FORM or OPERATION", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmAddEditFormPermission frm = new frmAddEditFormPermission(this.SelectedRoleModuleFormID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateRoleModuleForms();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageRoleManager::btnSaveRoleForms_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

       
    }
}
