using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using libERP.SERVICES;
using appExcelERP.Forms.ADMIN;
using appExcelERP.Forms;
using libERP;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.HR;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.ADMIN
{
    public partial class pageModules : UserControl
    {
        public int FormOperationID { get; set; }

        public int SelectedModuleID { get; set; }
        private BindingList<SelectListItem> _ModulesList = null;
        private BindingList<SelectListItem> _filteredModulesList = null;


        public int SelectedFormID { get; set; }
        private BindingList<SelectListItem> _FormsList = null;
        private BindingList<SelectListItem> _filteredFormsList = null;

        public pageModules()
        {
            InitializeComponent();
        }

        private void pageModules_Load(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Width * .5);
            PopulateModules();
           
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateModules();
        }

        #region MODULES
        private void PopulateModules()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _ModulesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceModules()).GetAllModules());
                gridModules.DataSource = _ModulesList;
                gridModules.Columns["ID"].Visible = gridModules.Columns["Code"].Visible = gridModules.Columns["IsActive"].Visible = gridModules.Columns["DescriptionToUpper"].Visible = false;
                gridModules.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupModule.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridModules.RowCount);
                //FormatModulesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageModules::PopulateModules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void FormatModulesGrid()
        {
            try
            {
                
                foreach (DataGridViewRow row in gridModules.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridModules.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridModules.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::FormatModulesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridModules_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                headerGroupDeleteModule.ValuesPrimary.Heading = string.Empty;
                txtDeleteModuleInfo.Text = string.Empty;

                if (e.RowIndex >= 0)
                {
                    SelectedModuleID = (int)gridModules.Rows[e.RowIndex].Cells["ID"].Value;
                    PopulateForms();

                }
                bool isactive = (bool)gridModules.Rows[e.RowIndex].Cells["IsActive"].Value;
                if (isactive)
                {
                    btnRestoreModule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnEditModule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnDeleteModule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;

                    btnAddNewForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnEditForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnDeleteForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnRestoreForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                {
                    btnRestoreModule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnEditModule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnDeleteModule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;

                    btnAddNewForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnEditForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnDeleteForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnRestoreForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }

                Tbl_MP_Master_Module dbModule = (new ServiceModules()).GetModuleDBRecordByID(this.SelectedModuleID);
                if (dbModule != null)
                {
                    if (dbModule.DeletedBy != null)
                    {
                        string empName = ServiceEmployee.GetEmployeeNameByID((int)dbModule.DeletedBy);
                        headerGroupDeleteModule.ValuesPrimary.Heading = string.Format("Deleted by {0} dt. {1}", empName, dbModule.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                    }
                    txtDeleteModuleInfo.Text = dbModule.DeleteRemarks;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageModules::gridModules_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchModule_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                _filteredModulesList = new BindingList<SelectListItem>(_ModulesList.Where(p => p.DescriptionToUpper.Contains(txtSearchModule.Text.ToUpper())).ToList());
                gridModules.DataSource = _filteredModulesList;
                headerGroupModule.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridModules.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageModules::txtSearchModule_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void gridModules_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatModulesGrid();
        }
        private void btnAddNewModule_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAppModule frm = new frmAddEditAppModule();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateModules();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnAddNewModule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditModule_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAppModule frm = new frmAddEditAppModule(this.SelectedModuleID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateModules();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnEditModule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteModule_Click(object sender, EventArgs e)
        {

            try
            {
                frmDelete frm = new frmDelete(APP_ENTITIES.APPLICATION_MODULES, this.SelectedModuleID);
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateModules();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnDeleteModule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRestoreModule_Click(object sender, EventArgs e)
        {
            try
            {
                string strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MM yy hh:sstt"));
                (new ServiceModules()).UndeleteModuleMasterInfo(this.SelectedModuleID, strRemarks);
                PopulateModules();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnRestoreModule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region FORMS
        private void PopulateForms()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _FormsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceModules()).GetAllFormsForModule(this.SelectedModuleID));
                gridForms.DataSource = _FormsList;
                gridForms.Columns["Code"].Visible = gridForms.Columns["IsActive"].Visible = gridForms.Columns["DescriptionToUpper"].Visible = false;
                gridForms.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridForms.Columns["ID"].Width= (int)(gridForms.Width*.2);
                headerGroupForms.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridForms.RowCount);
                //FormatModulesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageModules::PopulateForms", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void FormatFormsGrid()
        {
            try
            {

                foreach (DataGridViewRow row in gridForms.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridForms.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridForms.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::FormatFormsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridForms_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                headerGroupDeleteForm.ValuesPrimary.Heading = string.Empty;
                txtDeleteFormInfo.Text = string.Empty;

                if (e.RowIndex >= 0)
                {
                    SelectedFormID = (int)gridForms.Rows[e.RowIndex].Cells["ID"].Value;
                }
                bool isactive = (bool)gridForms.Rows[e.RowIndex].Cells["IsActive"].Value;
                if (isactive)
                {
                    btnRestoreForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnEditForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnDeleteForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
                else
                {
                    btnRestoreForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnEditForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnDeleteForm.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }


                Tbl_MP_Master_Module_Forms dbModuleForm = (new ServiceModules()).GetModuleFormDBRecordByID(this.SelectedFormID);
                if (dbModuleForm != null)
                {
                    if (dbModuleForm.DeletedBy != null)
                    {
                        string empName = ServiceEmployee.GetEmployeeNameByID((int)dbModuleForm.DeletedBy);
                        headerGroupDeleteForm.ValuesPrimary.Heading = string.Format("Deleted by {0} dt. {1}", empName, dbModuleForm.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                    }
                    txtDeleteFormInfo.Text = dbModuleForm.DeleteRemarks;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageModules::gridForms_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchForm_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredFormsList = new BindingList<SelectListItem>(_FormsList.Where(p => p.DescriptionToUpper.Contains(txtSearchForm.Text.ToUpper())).ToList());
                gridForms.DataSource = _filteredFormsList;
                headerGroupForms.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridForms.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageModules::btnSearchForm_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridForms_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatFormsGrid();
        }
        private void btnAddNewForm_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditModuleForm frm = new frmAddEditModuleForm();
                frm.ModuleID = this.SelectedModuleID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateForms();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnAddNewForm_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditForm_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditModuleForm frm = new frmAddEditModuleForm(this.SelectedFormID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateForms();
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnEditForm_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteForm_Click(object sender, EventArgs e)
        {
            try
            {
                frmDelete frm = new frmDelete(APP_ENTITIES.MODULES_FORMS, this.SelectedFormID);
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateForms();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnDeleteForm_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRestoreForm_Click(object sender, EventArgs e)
        {
            try
            {
                string strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MM yy hh:sstt"));
                (new ServiceModules()).UndeleteModuleFormMasterInfo(this.SelectedFormID, strRemarks);
                PopulateForms();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageModules::btnRestoreForm_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion

       
    }
}
