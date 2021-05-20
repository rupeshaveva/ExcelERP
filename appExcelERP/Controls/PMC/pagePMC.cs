using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using libERP.SERVICES;

using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.PMC;
using appExcelERP.Forms.PMC;

namespace appExcelERP.Controls.PMC
{
    public partial class pagePMC : UserControl
    {
        public int selectedStatusID { get; set; }
        public int selectedProjectID { get; set; }

        BindingList<SelectListItem> _ProjectsList = null;
        BindingList<SelectListItem> _filteredProjectsList = null;
        public DB_FORM_IDs SelectedTAB { get; set; }

        #region CUSTOM CONTROLS FOR EACH TAB

        ControlProjectCloserChecklist _ctrlProjectCheckList = null;
        private void InitializeControlProjectCloserChecklist()
        {
            try
            {
                _ctrlProjectCheckList = new ControlProjectCloserChecklist();
                tabPageProjectCloserChecklist.Controls.Add(_ctrlProjectCheckList);
                _ctrlProjectCheckList.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::InitializeControlProjectCloserChecklist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        ControlProjectPlan _ctrlProjectPlan = null;
        private void InitializeProjectPlanControl()
        {
            try
            {
                _ctrlProjectPlan = new ControlProjectPlan();
                tabPageProjectPlan.Controls.Add(_ctrlProjectPlan);
                _ctrlProjectPlan.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::InitializeProjectPlanControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private ControlProjectGeneralInfo _ProjectGeneralInfo= null;
        private void InitializeProjectGeneralInfoControl()
        {
            try
            {
                _ProjectGeneralInfo = new ControlProjectGeneralInfo();
                tabPageGeneralInfo.Controls.Clear();
                tabPageGeneralInfo.Controls.Add(_ProjectGeneralInfo);
                _ProjectGeneralInfo.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::InitializeProjectGeneralInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        


        #endregion

        public pagePMC()
        {
            InitializeComponent();
            SetTabPagesTag();

        }
        private void pagePMC_Load(object sender, EventArgs e)
        {
            try
            {
                SetProjectTabAsPerPermission();
                PopulateProjectStatusDropdown();
                SelectedTAB = (DB_FORM_IDs)tabPageGeneralInfo.Tag;
                this.RefreshTabPage();
                tabProject.SelectedPage = tabPageGeneralInfo;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::pagePMC_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetTabPagesTag()
        {
            try
            {
                tabPageGeneralInfo.Tag = DB_FORM_IDs.PROJECT_GENERAL_INFO;
                tabPageProjectConfiguration.Tag = DB_FORM_IDs.PROJECT_CONFIGURATION;
                tabPageProjectPlan.Tag = DB_FORM_IDs.PROJECT_PLANNING;
                tabPageSalesOrder.Tag = DB_FORM_IDs.PROJECT_SALES_ORDER;
                tabPageVariationToContract.Tag = DB_FORM_IDs.PROJECT_VARIATION_TO_CONTRACT;
                tabPageMaterialTakeOff.Tag = DB_FORM_IDs.PROJECT_MATERIAL_TAKE_OFF;
                tabPageProjectCalendar.Tag = DB_FORM_IDs.PROJECT_CALENDAR;
                tabPageProjectCloserChecklist.Tag = DB_FORM_IDs.PROJECT_CLOSER_CHECKLIST;
                tabPageExtraWorksheetQuotation.Tag = DB_FORM_IDs.PROJECT_EXTRA_WORKSHEET_QUOTATION;
                



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::SetTabPagesTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetProjectTabAsPerPermission()
        {
            WhosWhoModel model = null;
            try
            {
                // SET TAB PAGES VISIBILITYY AS PER PERMISSION
                foreach (KryptonPage currPage in tabProject.Pages)
                {
                    if (currPage.Tag != null)
                    {
                        DB_FORM_IDs currOperation = (DB_FORM_IDs)currPage.Tag;
                        model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == currOperation).FirstOrDefault();
                        if (model != null)
                        {
                            currPage.Visible = model.CanView;
                            switch ((DB_FORM_IDs)model.FormID)
                            {
                                case DB_FORM_IDs.PROJECT_CLOSER_CHECKLIST: InitializeControlProjectCloserChecklist(); break;
                                case DB_FORM_IDs.PROJECT_PLANNING: InitializeProjectPlanControl(); break;
                                case DB_FORM_IDs.PROJECT_GENERAL_INFO: InitializeProjectGeneralInfoControl(); break;
                            }
                        }
                    }
                }

                // SET  BUTTON VISIBILITY AS PER PERMISSION
                model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.PROJECT).FirstOrDefault();
                if (model != null)
                {
                    btnAddNewProject.Visible = model.CanAddNew;
                    btnEditProject.Visible = model.CanModify;
                    btnDeleteProject.Visible = model.CanDelete;
                }
                    
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::SetProjectTabAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //bool readOnly = _service.IsSalesOrderReadOnly(this.SelectedOrderID);
                //if (readOnly)
                //    btnAddPrimarySO.Enabled = btnAddWithoutOrderSO.Enabled = btnEditOrder.Enabled = btnDeleteOrder.Enabled = ButtonEnabled.False;
                //else
                //    btnAddPrimarySO.Enabled = btnAddWithoutOrderSO.Enabled = btnEditOrder.Enabled = btnDeleteOrder.Enabled = ButtonEnabled.True;

                switch (this.SelectedTAB)
                {
                    case DB_FORM_IDs.PROJECT_CLOSER_CHECKLIST:
                        if (_ctrlProjectCheckList == null) return;
                        _ctrlProjectCheckList.SelectedProjectID = this.selectedProjectID;
                        //_ctrlGeneralDetails.ReadOnly = readOnly;
                        _ctrlProjectCheckList.PopulateProjectCheckList();
                        break;
                    case DB_FORM_IDs.PROJECT_PLANNING:
                        if (_ctrlProjectPlan == null) return;
                        _ctrlProjectPlan.SelectedProjectID = this.selectedProjectID;
                        //_ctrlGeneralDetails.ReadOnly = readOnly;
                        _ctrlProjectPlan.PopulatePalnAndExecutionGanttCharts();
                        break;
                    case DB_FORM_IDs.PROJECT_GENERAL_INFO:
                       if (_ProjectGeneralInfo == null) return;
                       _ProjectGeneralInfo.SelectedProjectID = this.selectedProjectID;
                        //_ctrlGeneralDetails.ReadOnly = readOnly;
                        _ProjectGeneralInfo.PopulateProjectGeneralInfo();
                        break;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::RefreshTabPage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void PopulateProjectStatusDropdown()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceProject()).GetAllProjectStatuses());
                cboProjectStatuses.DataSource = lst;
                cboProjectStatuses.DisplayMember = "Description";
                cboProjectStatuses.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::PopulateProjectStatusDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void PopulateProjectsGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _ProjectsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceProject()).GetAllProjectsForGridDisplay(selectedStatusID));
                gridProjects.DataSource = _ProjectsList;
                gridProjects.Columns["ID"].Visible = gridProjects.Columns["Code"].Visible = gridProjects.Columns["DescriptionToUpper"].Visible = gridProjects.Columns["ISActive"].Visible = false;
                headerGroupMain.ValuesSecondary.Heading = string.Format("{0} rows found.", gridProjects.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::PopulateProjectsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }


        private void btnToggleProject_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainerMain.Panel1Collapsed = !splitContainerMain.Panel1Collapsed;
                headerGroupMain.HeaderVisibleSecondary = !headerGroupMain.HeaderVisibleSecondary;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::btnToggleProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void tabProject_TabClicked(object sender, KryptonPageEventArgs e)
        {
            this.SelectedTAB = (DB_FORM_IDs)((KryptonNavigator)sender).Pages[e.Index].Tag;
            this.RefreshTabPage();
        }
        private void gridProjects_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.selectedProjectID = int.Parse(gridProjects.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                string[] arr = _ProjectsList.Where(x => x.ID == this.selectedProjectID).FirstOrDefault().Description.Split('\n');
                headerGroupMain.ValuesPrimary.Heading = arr[0];
                RefreshTabPage();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::gridProjects_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditProject frm = new frmAddEditProject();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateProjectsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::btnAddNewProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnEditProject_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditProject frm = new frmAddEditProject(this.selectedProjectID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateProjectsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::btnEditProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Project {0}", this.selectedProjectID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   if ((new ServiceProject()).DeleteProject(this.selectedProjectID,Program.CURR_USER.EmployeeID))

                        PopulateProjectsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::btnDeleteProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchProject_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _filteredProjectsList = new BindingList<SelectListItem>(_ProjectsList.Where(p => p.DescriptionToUpper.Contains(txtSearchProject.Text.ToUpper())).ToList());
                gridProjects.DataSource = _filteredProjectsList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pagePMC::txtSearchProject_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cboProjectStatuses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.selectedStatusID = ((SelectListItem)cboProjectStatuses.SelectedItem).ID;
                PopulateProjectsGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pagePMC::cboProjectStatuses_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateProjectsGrid();
        }
    }
}
