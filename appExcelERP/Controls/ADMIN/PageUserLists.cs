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
using appExcelERP.Forms;
using appExcelERP.Forms.UserList;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.ADMIN
{
    public partial class PageUserLists : UserControl
    {
        public int FormOperationID { get; set; }

        private int _SelectedAdminCategoryID = 0;
        private string _SelectedAdminCategoryName = string.Empty;
        private BindingList<SelectListItem> _AdminCategoryList = null;
        private BindingList<SelectListItem> _filteredAdminCategoryList = null;

        private int _SelectedAdminCategoryValueID = 0;
        private BindingList<SelectListItem> _AdminCategoryValuesList = null;
        private BindingList<SelectListItem> _filteredAdminCategoryValuesList = null;
        
        private int _SelectedMasterCategoryID = 0;
        private string _SelectedMasterCategoryName = string.Empty;
        private BindingList<SelectListItem> _MasterCategoryList = null;
        private BindingList<SelectListItem> _filteredMasterCategoryList = null;

        private int _SelectedMasterCategoryValueID = 0;
        private BindingList<SelectListItem> _MasterCategoryValuesList = null;
        private BindingList<SelectListItem> _filteredMasterCategoryValuesList = null;

        private int _SelectedAppDefaultID = 0;
        private BindingList<SelectListItem> _AppDefaultsList = null;
        private BindingList<SelectListItem> _filteredAppDefaultsList = null;

        public PageUserLists()
        {
            InitializeComponent();
        }
        private void PageUserLists_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateAdminCategoriesGrid();
                PopulateMasterCategoriesGrid();
                PopulateDefaultApplicationSettingsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::PageUserLists_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void PageUserLists_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Width * .6);
        }

          #region ADMIN CATEGORIES
        private void PopulateAdminCategoriesGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _AdminCategoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllAdminCategories().OrderBy(x=>x.Description).ToList());
                gridAdminCategories.DataSource = _AdminCategoryList;
                gridAdminCategories.Columns["ID"].Visible = gridAdminCategories.Columns["Code"].Visible = gridAdminCategories.Columns["IsActive"].Visible = gridAdminCategories.Columns["DescriptionToUpper"].Visible = false;
                headerGroupAdminCategories.ValuesSecondary.Heading = string.Format("({0}) records found.", gridAdminCategories.Rows.Count);
                btnEditAdminCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridAdminCategories.Rows.Count > 0) btnEditAdminCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::PopulateAdminCategoriesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchAdminCategory_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredAdminCategoryList = new BindingList<SelectListItem>(_AdminCategoryList.Where(p => p.DescriptionToUpper.Contains(txtSearchAdminCategory.Text.ToUpper())).ToList());
                gridAdminCategories.DataSource = _filteredAdminCategoryList;
                btnEditAdminCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridAdminCategories.Rows.Count > 0) btnEditAdminCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::txtSearchAdminCategory_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridAdminCategories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _SelectedAdminCategoryID = (int)gridAdminCategories.Rows[e.RowIndex].Cells["ID"].Value;
                _SelectedAdminCategoryName = gridAdminCategories.Rows[e.RowIndex].Cells["Description"].Value.ToString().ToUpper();
                headerGroupAdminCategories.ValuesSecondary.Description = _SelectedAdminCategoryID.ToString();
                headerGroupAdminCategoryValues.ValuesPrimary.Heading = _SelectedAdminCategoryName + " Values:";
                PopulateAdminCategorieValuesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::gridAdminCategories_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void PopulateAdminCategorieValuesGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _AdminCategoryValuesList= AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllAdminCategoryValuesForCategory(_SelectedAdminCategoryID));
                gridAdminCategoryValues.DataSource = _AdminCategoryValuesList;
                gridAdminCategoryValues.Columns["ID"].Visible = gridAdminCategoryValues.Columns["Code"].Visible = gridAdminCategoryValues.Columns["IsActive"].Visible = gridAdminCategoryValues.Columns["DescriptionToUpper"].Visible = false;
                headerGroupAdminCategoryValues.ValuesSecondary.Heading = string.Format("({0}) records found.", gridAdminCategoryValues.Rows.Count);
                btnEditAdminCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridAdminCategoryValues.Rows.Count > 0) btnEditAdminCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::PopulateAdminCategorieValuesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridAdminCategoryValues_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _SelectedAdminCategoryValueID = (int)gridAdminCategoryValues.Rows[e.RowIndex].Cells["ID"].Value;
                headerGroupAdminCategoryValues.ValuesSecondary.Description = _SelectedAdminCategoryValueID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::gridAdminCategoryValues_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchAdminCategoryValues_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredAdminCategoryValuesList = new BindingList<SelectListItem>(_AdminCategoryValuesList.Where(p => p.DescriptionToUpper.Contains(txtSearchAdminCategoryValues.Text.ToUpper())).ToList());
                gridAdminCategoryValues.DataSource = _filteredAdminCategoryValuesList;
                btnEditAdminCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridAdminCategoryValues.Rows.Count > 0) btnEditAdminCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::txtSearchAdminCategoryValues_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewCategoryValue_Click(object sender, EventArgs e)
        {
            try
            {
                frmADMINUserList frm = new frmADMINUserList();
                frm.ADMINCategoryID = _SelectedAdminCategoryID;
                frm.SHORT_CODE_REQUIRED = (new ServiceMASTERS()).IsShortCodeRequiredForAdminCategory(this._SelectedAdminCategoryID);
                frm.Text = string.Format("Add New {0} Value", _SelectedAdminCategoryName);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAdminCategorieValuesGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnAddNewCategoryValue_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnEditAdminCategoryValue_Click(object sender, EventArgs e)
        {
            try
            {
                frmADMINUserList frm = new frmADMINUserList(_SelectedAdminCategoryValueID);
                frm.ADMINCategoryID = _SelectedAdminCategoryID;
                frm.SHORT_CODE_REQUIRED = (new ServiceMASTERS()).IsShortCodeRequiredForAdminCategory(this._SelectedAdminCategoryID);
                frm.Text = string.Format("Modify {0} Value", _SelectedAdminCategoryName);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAdminCategorieValuesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnEditAdminCategoryValue_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
        #endregion

        #region MASTER CATEGORIES
        private void PopulateMasterCategoriesGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _MasterCategoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllMasterCategories().OrderBy(x=>x.Description).ToList());
                gridMasterCategories.DataSource = _MasterCategoryList;
                gridMasterCategories.Columns["ID"].Visible = gridMasterCategories.Columns["Code"].Visible = gridMasterCategories.Columns["IsActive"].Visible = gridMasterCategories.Columns["DescriptionToUpper"].Visible = false;
                headerGroupMasterCategories.ValuesSecondary.Heading = string.Format("({0}) records found.", gridMasterCategories.Rows.Count);
                btnEditMasterCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridMasterCategories.Rows.Count > 0) btnEditMasterCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::PopulateMasterCategoriesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchMasterCategories_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredMasterCategoryList = new BindingList<SelectListItem>(_MasterCategoryList.Where(p => p.DescriptionToUpper.Contains(txtSearchMasterCategories.Text.ToUpper())).ToList());
                gridMasterCategories.DataSource = _filteredMasterCategoryList;
                btnEditMasterCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridMasterCategories.Rows.Count > 0) btnEditMasterCategory.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::txtSearchMasterCategories_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridMasterCategories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _SelectedMasterCategoryID = (int)gridMasterCategories.Rows[e.RowIndex].Cells["ID"].Value;
                _SelectedMasterCategoryName = gridMasterCategories.Rows[e.RowIndex].Cells["Description"].Value.ToString().ToUpper();
                headerGroupMasterCategories.ValuesSecondary.Description = _SelectedMasterCategoryID.ToString();
                headerGroupMasterCategoryValues.ValuesPrimary.Heading = _SelectedMasterCategoryName + " Values:";
                PopulateMasterCategoryValuesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::gridMasterCategories_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateMasterCategoryValuesGrid()
        {
            try
            {
                _MasterCategoryValuesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllMasterCategoryValuesForCategory(_SelectedMasterCategoryID));
                gridMasterCategoryValues.DataSource = _MasterCategoryValuesList;
                gridMasterCategoryValues.Columns["ID"].Visible = gridMasterCategoryValues.Columns["Code"].Visible = gridMasterCategoryValues.Columns["IsActive"].Visible = gridMasterCategoryValues.Columns["DescriptionToUpper"].Visible = false;
                headerGroupMasterCategoryValues.ValuesSecondary.Heading = string.Format("({0}) records found.", gridMasterCategoryValues.Rows.Count);
                btnEditMasterCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridMasterCategoryValues.Rows.Count > 0) btnEditMasterCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::PopulateMasterCategoryValuesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridMasterCategoryValues_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _SelectedMasterCategoryValueID = (int)gridMasterCategoryValues.Rows[e.RowIndex].Cells["ID"].Value;
                headerGroupMasterCategoryValues.ValuesSecondary.Description = _SelectedMasterCategoryValueID.ToString();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "PageUserLists::gridMasterCategoryValues_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void txtSearchMasterCategoryValues_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredMasterCategoryValuesList = new BindingList<SelectListItem>(_MasterCategoryValuesList.Where(p => p.DescriptionToUpper.Contains(txtSearchMasterCategoryValues.Text.ToUpper())).ToList());
                gridMasterCategoryValues.DataSource = _filteredMasterCategoryValuesList;
                btnEditMasterCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridMasterCategoryValues.Rows.Count > 0) btnEditMasterCategoryValue.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::txtSearchMasterCategoryValues_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewMasterCategoryValue_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.MASTERCategoryID = _SelectedMasterCategoryID;
                frm.Text = string.Format("Add New {0} Value", _SelectedMasterCategoryName);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateMasterCategoryValuesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnAddNewMasterCategoryValue_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnEditMasterCategoryValue_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList(_SelectedMasterCategoryValueID);
                frm.MASTERCategoryID = _SelectedMasterCategoryID;
                frm.Text = string.Format("Modify {0} Value", _SelectedMasterCategoryName);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateMasterCategoryValuesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnEditMasterCategoryValue_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
        #endregion

        #region APPLICATION DEFAULT SETTINGS
        private void PopulateDefaultApplicationSettingsGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _AppDefaultsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllDefaultApplicationSettings().OrderBy(x => x.Description).ToList());
                gridApplicationSettings.DataSource = _AppDefaultsList;
                gridApplicationSettings.Columns["ID"].Visible = gridApplicationSettings.Columns["Code"].Visible = gridApplicationSettings.Columns["IsActive"].Visible = gridApplicationSettings.Columns["DescriptionToUpper"].Visible = false;
                headerGroupAppSettings.ValuesSecondary.Heading = string.Format("({0}) records found.", gridApplicationSettings.Rows.Count);
                btnChangeSetting.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                if (gridApplicationSettings.Rows.Count > 0) btnChangeSetting.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::PopulateDefaultApplicationSettingsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridApplicationSettings_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this._SelectedAppDefaultID = (int)gridApplicationSettings.Rows[e.RowIndex].Cells["ID"].Value;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageUserLists::gridApplicationSettings_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRefreshAppSettings_Click(object sender, EventArgs e)
        {
            try
            {
                gridApplicationSettings.DataSource = null;
                PopulateDefaultApplicationSettingsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnRefreshAppSettings_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtSearchApplicationSettings_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredAppDefaultsList = new BindingList<SelectListItem>(_AppDefaultsList.Where(p => p.DescriptionToUpper.Contains(txtSearchApplicationSettings.Text.ToUpper())).ToList());
                gridApplicationSettings.DataSource = _filteredAppDefaultsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::txtSearchApplicationSettings_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateAdminCategoriesGrid();
                PopulateMasterCategoriesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnAddNewAdminCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdminCategory frm = new frmAdminCategory();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    PopulateAdminCategoriesGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnAddNewAdminCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void btnEditAdminCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdminCategory frm = new frmAdminCategory(this._SelectedAdminCategoryID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    PopulateAdminCategoriesGrid();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageUserLists::btnEditAdminCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        
        private void btnShowHideAppSetting_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }

        private void btnAddNewMasterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterCategory frm = new frmMasterCategory();
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateMasterCategoriesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserLists::btnAddNewMasterCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void btnEditMasterCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterCategory frm = new frmMasterCategory(_SelectedMasterCategoryID);
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateMasterCategoriesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserLists::btnAddNewMasterCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
    }
}
