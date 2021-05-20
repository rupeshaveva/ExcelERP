using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using libERP.MODELS.COMMON;
using libERP.MODELS;
using libERP.MODELS.HR;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.PMC;

namespace appExcelERP.Controls.HR.Attendance
{
    public partial class PageAttendanceGridView : UserControl
    {
        public AttendanceGridViewModel SelectedAttendanceModel { get; set; }

        public int SelectedAttendanceID { get; set; }
        public BindingList<AttendanceGridViewModel> _AttendanceList { get; set; }
        public BindingList<AttendanceGridViewModel> _filterAttendanceList { get; set; }

        // EMPLOYEE CATEGORY
        public BindingList<SelectListItem> _EmployeeCategoriesList { get; set; }
        public BindingList<SelectListItem> _filterEmployeeCategoriesList { get; set; }
        // PROJECTS
        public BindingList<SelectListItem> _ProjectsList { get; set; }
        public BindingList<SelectListItem> _filterProjectList { get; set; }
        // DEPARTMENTS
        public BindingList<SelectListItem> _DepartmentsList { get; set; }
        public BindingList<SelectListItem> _filterDepartmentsList { get; set; }
        // EMPLOYEES
        public BindingList<SelectListItem> _EmployeeList { get; set; }
        public BindingList<SelectListItem> _filterEmployeeList { get; set; }
         public PageAttendanceGridView()
        {
            InitializeComponent();
        }

        private void PageAttendanceGridView_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateEmployeeCategories();
                PopulateProjects();
                PopulateDepartments();
                PopulateEmployees();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::PageAttendanceGridView_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }

        #region ATTENDANCE GRID
        private void btnPreareAttendanceGrid_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ServiceAttendance serviceAttendance = new ServiceAttendance();
            string empCategoryIDs = string.Empty;
            string projectIDs = string.Empty;
            string departmentIDs = string.Empty;
            string employeeIDs = string.Empty;

            try
            {
                // get all selected CATEGORY IDs in a string
                foreach (DataGridViewRow mRow in gridEmployeeCategories.Rows)
                {
                    if ((bool)mRow.Cells["IsActive"].Value == true)
                        empCategoryIDs += string.Format("{0},", mRow.Cells["ID"].Value);
                }
                if (empCategoryIDs != string.Empty) empCategoryIDs = empCategoryIDs.TrimEnd(',');
                // do the same for PROJECTS, DEPAQRTMENTS & EMPLOYEES..THIS WAY WE GET ALL SELECTED IDs

                //for projects
                foreach (DataGridViewRow mRow in gridProjects.Rows)
                {
                    if ((bool)mRow.Cells["IsActive"].Value == true)
                        projectIDs += string.Format("{0},", mRow.Cells["ID"].Value);
                }
                if (projectIDs != string.Empty) projectIDs = projectIDs.TrimEnd(',');

                //for departments
                foreach (DataGridViewRow mRow in gridDepartments.Rows)
                {
                    if ((bool)mRow.Cells["IsActive"].Value == true)
                        departmentIDs += string.Format("{0},", mRow.Cells["ID"].Value);
                }
                if (departmentIDs != string.Empty) departmentIDs = departmentIDs.TrimEnd(',');


                //for employee
                foreach (DataGridViewRow mRow in gridEmployees.Rows)
                {
                    if ((bool)mRow.Cells["IsActive"].Value == true)
                        employeeIDs += string.Format("{0},", mRow.Cells["ID"].Value);
                }
                if (employeeIDs != string.Empty) employeeIDs = employeeIDs.TrimEnd(',');





                gridAttendance.DataSource = null;
                headerGroupOptions.ValuesSecondary.Heading = string.Format("Fetching list of Distinct Employees for month ({0})", dtToDate.Value.ToString("MMMM"));
                Application.DoEvents();
                _AttendanceList = AppCommon.ConvertToBindingList<AttendanceGridViewModel>((new ServiceAttendance()).GetAttendanceRecordsForFilter(
                    dtFromDate.Value, dtToDate.Value, empCategoryIDs, projectIDs, departmentIDs, employeeIDs));
                headerGroupOptions.ValuesSecondary.Heading = string.Format("Fetched {0} Attendance Records. Now Binding to Grid", _AttendanceList.Count());
                Application.DoEvents();
                gridAttendance.DataSource = _AttendanceList;

                FormatAttendanceGrid();
                Application.DoEvents();
                SetAttendanceRowColor();
                headerGroupOptions.ValuesSecondary.Heading = string.Format("Attendance Sheet for month ({0}) generated successfully", dtToDate.Value.ToString("MMMM"));
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnPreareAttendanceGrid_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void FormatAttendanceGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatting Attendance Sheet Started ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["AttendanceID"].Visible = false;
                gridAttendance.Columns["FK_EmployeeID"].Visible = false;
                gridAttendance.Columns["AttendanceType"].Visible = false;
                //gridAttendance.Columns["AttendanceTypeName"].Visible = false;
                //gridAttendance.Columns["FK_CostCenterId"].Visible = false;
                gridAttendance.Columns["ApprovedBy"].Visible = false;
                gridAttendance.Columns["PreparedBy"].Visible = true;
                gridAttendance.Columns["SearchString"].Visible = false;
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Hiding Grid Columns ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();

                int gridWidth = gridAttendance.Width;

                gridAttendance.Columns["AttendDate"].DefaultCellStyle.Format = "dd MMM yy";
                gridAttendance.Columns["AttendDate"].Width = 70;
                gridAttendance.Columns["AttendDate"].HeaderText = "Date";
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Attendance Date Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();

                gridAttendance.Columns["EmployeeDescription"].Width = (int)(gridWidth * .15);
                gridAttendance.Columns["EmployeeDescription"].HeaderText = "Employee";
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Employee Description Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();

                gridAttendance.Columns["AttendInTime"].HeaderText = "In Time";
                gridAttendance.Columns["AttendInTime"].Width = 62;
                gridAttendance.Columns["AttendInTime"].DefaultCellStyle.Format = "hh:mm tt";
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Attendnace In Time Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["AttendOutTime"].HeaderText = "Out Time";
                gridAttendance.Columns["AttendOutTime"].Width = 62;
                gridAttendance.Columns["AttendOutTime"].DefaultCellStyle.Format = "hh:mm tt";
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Attendnace Out Time Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["Duration"].HeaderText = "Duration";
                gridAttendance.Columns["Duration"].Width = 62;
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Duration Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();



                gridAttendance.Columns["AtWarehouse"].HeaderText = "(WH)";
                gridAttendance.Columns["AtWarehouse"].Width = 40;

                gridAttendance.Columns["AttendanceRemarks"].HeaderText = "Remarks";
                //gridAttendance.Columns["AttendanceRemarks"].Width = 80;
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Attendance Remarks Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["PreparedBy"].Width = (int)(gridWidth * .15);
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatted Prepareb By Column");
                Application.DoEvents();
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatting Attendance Sheet Completed....({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["CreatedDateTime"].HeaderText = "CreatedDateTime";
                gridAttendance.Columns["CreatedDateTime"].Width = 80;

                gridAttendance.Columns["ApprovalStatus"].Visible = true;
                gridAttendance.Columns["ApprovalStatus"].Width = (int)(gridWidth * .10);
                //gridAttendance.Columns["ApprovalStatus"]
                gridAttendance.Columns["SelectedAttendance"].Width = 60;

                Application.DoEvents();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::FormatAttendanceGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetAttendanceRowColor()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<AttendanceColorModel> lstColors = (new ServiceEmployee()).GetAttendanceColorPreferencesOfEmployee(Program.CURR_USER.EmployeeID);
                foreach (DataGridViewRow row in gridAttendance.Rows)
                {
                    headerGroupGrid.ValuesSecondary.Heading = string.Format("Applying Color : {0} ({1}/{2})",
                        ((DateTime)row.Cells["AttendDate"].Value).ToString("dd MMM yyyy"),
                        row.Index,
                        _AttendanceList.Count);
                    ATTENDANCE_TYPE mType = (ATTENDANCE_TYPE)row.Cells["AttendanceType"].Value;
                    switch (mType)
                    {
                        case ATTENDANCE_TYPE.PRESENT:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.PRESENT).FirstOrDefault().ColorAttendance;
                            break;
                        case ATTENDANCE_TYPE.ABSENT:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.ABSENT).FirstOrDefault().ColorAttendance;
                            break;

                        case ATTENDANCE_TYPE.LEAVE:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LEAVE).FirstOrDefault().ColorAttendance;
                            break;
                        case ATTENDANCE_TYPE.OUT_DOOR:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.OUT_DOOR).FirstOrDefault().ColorAttendance;
                            break;
                        case ATTENDANCE_TYPE.COMP_OFF:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.COMP_OFF).FirstOrDefault().ColorAttendance;
                            break;
                        case ATTENDANCE_TYPE.LATE_COMING:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LATE_COMING).FirstOrDefault().ColorAttendance;
                            break;
                        case ATTENDANCE_TYPE.EARLY_GOING:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.EARLY_GOING).FirstOrDefault().ColorAttendance;
                            break;
                        case ATTENDANCE_TYPE.MULTIPLE:
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.MULTIPLE).FirstOrDefault().ColorAttendance;
                            break;
                    }
                    Application.DoEvents();
                   
                }
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Identifying Dulicate Attendance Records & highlighting with defined Color");
                Application.DoEvents();
                List<DuplicateAttendaceModel> lstDuplicates = (new ServiceAttendance()).GetDuplicateAttendanceBetweenDates(dtFromDate.Value, dtToDate.Value);
                foreach (DuplicateAttendaceModel model in lstDuplicates)
                {
                    foreach (DataGridViewRow row in gridAttendance.Rows)
                    {
                        if ((DateTime)row.Cells["AttendDate"].Value == model.AttendanceDate && (int)row.Cells["FK_EmployeeID"].Value == model.EmployeeID)
                        {
                            row.DefaultCellStyle.BackColor = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.MULTIPLE).FirstOrDefault().ColorAttendance;

                        }
                    }

                }
                headerGroupGrid.ValuesSecondary.Heading = string.Format("Formatting completed for {0} rows", gridAttendance.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::SetAttendanceRowColor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchOnsite_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (txtSearchOnsiteEmployee.Text.Trim() == string.Empty)
                {
                    gridAttendance.DataSource = _AttendanceList;
                    SetAttendanceRowColor();
                }
                else
                {
                    _filterAttendanceList = new BindingList<AttendanceGridViewModel>(_AttendanceList.Where(p => p.SearchString.Contains(txtSearchOnsiteEmployee.Text.ToUpper())).ToList());
                    gridAttendance.DataSource = _filterAttendanceList;
                    SetAttendanceRowColor();
                }
                headerGroupGrid.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridAttendance.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::txtSearchOnsiteEmployee_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion



        private void gridAttendance_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedAttendanceID = (int)gridAttendance.Rows[e.RowIndex].Cells["AttendanceID"].Value;
                SelectedAttendanceModel = _AttendanceList.Where(x => x.AttendanceID == this.SelectedAttendanceID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridAttendance_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveAttendance_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnRemoveAttendance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region EMPLOYEE CATEGORY
        private void PopulateEmployeeCategories()
        {
            try
            {
                _EmployeeCategoriesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllEmployeeCategories());
                gridEmployeeCategories.DataSource = _EmployeeCategoriesList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::PopulateEmployeeCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridEmployeeCategories_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridEmployeeCategories.Columns["ID"].Visible = gridEmployeeCategories.Columns["Code"].Visible = gridEmployeeCategories.Columns["DescriptionToUpper"].Visible = false;
                gridEmployeeCategories.Columns["IsActive"].Width = 50;
                gridEmployeeCategories.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridEmployeeCategories_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridEmployeeCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridEmployeeCategories.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridEmployeeCategories.Rows[e.RowIndex].Cells["IsActive"].Value);
                headerEmployeeCategory.Values.Heading= GetGridCount(gridEmployeeCategories);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridEmployeeCategories_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefreshEmployeecategories_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployeeCategories();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnRefreshEmployeecategories_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnClearCategorySelections_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SelectListItem item in _EmployeeCategoriesList)
                {
                    if (item.IsActive) item.IsActive = false;
                }
                gridEmployeeCategories.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnClearCategorySelections_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filterEmployeeCategoriesList = new BindingList<SelectListItem>(_EmployeeCategoriesList.Where(p => p.DescriptionToUpper.Contains(txtSearchCategory.Text.ToUpper())).ToList());
                gridEmployeeCategories.DataSource = _filterEmployeeCategoriesList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::txtSearchCategory_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region PROJECTS
        private void PopulateProjects()
        {
            try
            {
                _ProjectsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceProject()).GetAllProjectsForSelection());
                gridProjects.DataSource = _ProjectsList;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::PopulateProjects", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridProjects_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                headerProjects.Values.Heading = string.Format("Selected {0} of {1}", gridProjects.SelectedRows.Count, gridProjects.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridProjects_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnRefreshProjects_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateProjects();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnRefreshProjects_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ;
            }
        }
        private void gridProjects_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridProjects.Columns["ID"].Visible = gridProjects.Columns["Code"].Visible = gridProjects.Columns["DescriptionToUpper"].Visible = false;
                gridProjects.Columns["IsActive"].Width = 50;
                gridProjects.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridProjects_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtSearchProjects_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void gridProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridProjects.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridProjects.Rows[e.RowIndex].Cells["IsActive"].Value);
                headerProjects.Values.Heading = GetGridCount(gridProjects);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridProjects_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnClearProjectSelection_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SelectListItem item in _ProjectsList)
                {
                    if (item.IsActive) item.IsActive = false;
                }
                gridProjects.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnClearProjectSelection_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchProjects_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filterProjectList = new BindingList<SelectListItem>(_ProjectsList.Where(p => p.DescriptionToUpper.Contains(txtSearchProjects.Text.ToUpper())).ToList());
                gridProjects.DataSource = _filterProjectList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::txtSearchProjects_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region DEPARTMENTS
        private void PopulateDepartments()
        {
            try
            {
                _DepartmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllDepartments());
                gridDepartments.DataSource = _DepartmentsList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::PopulateDepartments", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridDepartments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridDepartments.Columns["ID"].Visible = gridDepartments.Columns["Code"].Visible = gridDepartments.Columns["DescriptionToUpper"].Visible = false;
                gridDepartments.Columns["IsActive"].Width = 50;
                gridDepartments.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridDepartments_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridDepartments_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                headerDepartment.Values.Heading = string.Format("Selected {0} of {1}", gridDepartments.SelectedRows.Count, gridDepartments.Rows.Count);
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridDepartments_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridDepartments.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridDepartments.Rows[e.RowIndex].Cells["IsActive"].Value);
                headerDepartment.Values.Heading = GetGridCount(gridDepartments);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridDepartments_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRefreshDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateDepartments();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnRefreshDepartment_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchDepartments_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnClearDepartmentSelection_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SelectListItem item in _DepartmentsList)
                {
                    if (item.IsActive) item.IsActive = false;
                }
                gridDepartments.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnClearDepartmentSelection_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchdepartments_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filterDepartmentsList = new BindingList<SelectListItem>(_DepartmentsList.Where(p => p.DescriptionToUpper.Contains(txtSearchDepartments.Text.ToUpper())).ToList());
                gridDepartments.DataSource = _filterDepartmentsList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::txtSearchDepartments_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region EMPLOYEE
        private void PopulateEmployees()
        {
            try
            {
                _EmployeeList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceEmployee()).GetAllActiveEmployeesBetweenDates(dtFromDate.Value,dtToDate.Value));
                gridEmployees.DataSource = _EmployeeList;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::PopulateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                headerEmployees.Values.Heading = string.Format("Selected {0} of {1}", gridEmployees.SelectedRows.Count, gridEmployees.Rows.Count);
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridEmployees_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridEmployees.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridEmployees.Rows[e.RowIndex].Cells["IsActive"].Value);
                headerEmployees.Values.Heading = GetGridCount(gridEmployees);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridEmployees_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridEmployees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridEmployees.Columns["ID"].Visible = gridEmployees.Columns["Code"].Visible = gridEmployees.Columns["DescriptionToUpper"].Visible = false;
                gridEmployees.Columns["IsActive"].Width = 50;
                gridEmployees.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::gridEmployees_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnClearEmployeeSelection_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SelectListItem item in _EmployeeList)
                {
                    if (item.IsActive) item.IsActive = false;
                }
                gridEmployees.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnClearEmployeeSelection_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefreshEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployees();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnRefreshEmployees_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchEmployees_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filterEmployeeList = new BindingList<SelectListItem>(_EmployeeList.Where(p => p.DescriptionToUpper.Contains(txtSearchEmployees.Text.ToUpper())).ToList());
                gridEmployees.DataSource = _filterEmployeeList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::txtSearchEmployees_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion
        private void btnDeleteAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                String strMessage = "Are you sure to delete Attendance\n";
                if (this.SelectedAttendanceModel != null)
                {
                    strMessage += string.Format("{0} {1}\ndated {2} \n\n\n",
                        SelectedAttendanceModel.AttendanceType,
                        SelectedAttendanceModel.EmployeeDescription.Split('\n')[0],
                        SelectedAttendanceModel.AttendInTime.ToString("dd MMM yyyy"));
                    strMessage += "This will delete associated Leave Application.. if exists";
                    if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        (new ServiceAttendance()).DeleteAttendanceAndItsLeave(this.SelectedAttendanceID);
                        //_AttendanceList = AppCommon.ConvertToBindingList<vAttendanceRegister>((new ServiceAttendance()).GetAttendanceRecordsForMonth(dtToDate.Value));
                        gridAttendance.DataSource = _AttendanceList;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnDeleteAttendance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnShowHideOptions_Click(object sender, EventArgs e)
        {
            headerGroupOptions.Visible = !headerGroupOptions.Visible;
        }
        private string GetGridCount(DataGridView grid)
        {
            string strText = string.Empty;
            try
            {
                int selected = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if ((bool)row.Cells["IsActive"].Value == true)
                        selected++;
                }
                strText = string.Format("{0}/{1}", selected, grid.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::GetGridCount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strText;
        }
        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateEmployees();
        }
        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateEmployees();
        }
         private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string fName = string.Format("Attendance {0}.xls", dtFromDate.Value.ToString("MMM yyyy"));
                string fileNameWithPath = string.Format("{0}{1}", AppCommon.GetDefaultStorageFolderPath(),fName);
               (new ServiceExcelApp()).ExportAttendanceDatatoExcel(_AttendanceList, fileNameWithPath, dtFromDate.Value, dtToDate.Value);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnExportToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteMultipleRecord_Click(object sender, EventArgs e)
        {
            try
            {
                String strMessage = "Are you sure to delete selected Attendance Records\n";
                if (this.SelectedAttendanceModel != null)
                {
                    //strMessage += string.Format("{0} {1}\ndated {2} \n\n\n",
                    //SelectedAttendanceModel.AttendanceType,
                    //SelectedAttendanceModel.EmployeeDescription.Split('\n')[0],
                    //SelectedAttendanceModel.AttendInTime.ToString("dd MMM yyyy"));
                    strMessage += "This will delete associated Leave Application.. if exists";

                    if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        (new ServiceAttendance()).UpdateAttendanceForDelete(SelectedAttendanceID, this._AttendanceList);
                        (new ServiceAttendance()).DeleteMultipleAttendanceAndItsLeave(this.SelectedAttendanceID);
                        //_AttendanceList = AppCommon.ConvertToBindingList<vAttendanceRegister>((new ServiceAttendance()).GetAttendanceRecordsForMonth(dtToDate.Value));
                        // gridAttendance.DataSource = _AttendanceList;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceGridView::btnDeleteAttendance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void gridAttendance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gridAttendance.Rows[e.RowIndex].Cells["SelectedAttendance"].Value = !(bool)(gridAttendance.Rows[e.RowIndex].Cells["SelectedAttendance"].Value);
        }
    }
}

