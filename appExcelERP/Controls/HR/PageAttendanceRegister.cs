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
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.MODELS;
using ComponentFactory.Krypton.Toolkit;

namespace appExcelERP.Controls.HR
{
    public partial class PageMonthlyAttendanceManager : UserControl
    {
        public vAttendanceRegister SelectedAttendanceModel { get; set; }

        public int SelectedAttendanceID { get; set; }
        public BindingList<vAttendanceRegister> _AttendanceList { get; set; }
        public BindingList<vAttendanceRegister> _filterAttendanceList { get; set; }

        public int SelectedEmployeeID { get; set; }
        public BindingList<SelectListItem> _EmployeesList { get; set; }
        public BindingList<SelectListItem> _filteredEmployeesList { get; set; }

        private ControlEmployeeAttendanceViewer _EmployeeAttendaceViewer = null;
        public PageMonthlyAttendanceManager()
        {
            InitializeComponent();
        }

        private void PageMonthlyAttendanceManager_Load(object sender, EventArgs e)
        {
            try
            {
                btnPresentColor.Tag = ATTENDANCE_TYPE.PRESENT;
                btnAbsentColor.Tag = ATTENDANCE_TYPE.ABSENT;
                btnLeaveColor.Tag = ATTENDANCE_TYPE.LEAVE;
                btnOutdoorColor.Tag = ATTENDANCE_TYPE.OUT_DOOR;
                btnCompOffColor.Tag = ATTENDANCE_TYPE.COMP_OFF;
                btnLateComingColor.Tag = ATTENDANCE_TYPE.LATE_COMING;
                btnEarlyLeavingColor.Tag = ATTENDANCE_TYPE.EARLY_GOING;
                btnHolidayColor.Tag = ATTENDANCE_TYPE.HOLIDAY;
                btnWeekOffColor.Tag = ATTENDANCE_TYPE.WEEK_OFF;
                btnDuplicatesColor.Tag = ATTENDANCE_TYPE.MULTIPLE;
                // GET COLOR PREFERENCE OF THE USER FROM DATABASE AND SET IT ON THE COLOR BUTTONS
                List<AttendanceColorModel> lst = (new ServiceEmployee()).GetAttendanceColorPreferencesOfEmployee(Program.CURR_USER.EmployeeID);
                btnPresentColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.PRESENT).FirstOrDefault().ColorAttendance;
                btnAbsentColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.ABSENT).FirstOrDefault().ColorAttendance;
                btnLeaveColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LEAVE).FirstOrDefault().ColorAttendance;
                btnOutdoorColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.OUT_DOOR).FirstOrDefault().ColorAttendance;
                btnCompOffColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.COMP_OFF).FirstOrDefault().ColorAttendance;
                btnLateComingColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LATE_COMING).FirstOrDefault().ColorAttendance;
                btnEarlyLeavingColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.EARLY_GOING).FirstOrDefault().ColorAttendance;
                btnHolidayColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.HOLIDAY).FirstOrDefault().ColorAttendance;
                btnWeekOffColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.WEEK_OFF).FirstOrDefault().ColorAttendance;
                btnDuplicatesColor.SelectedColor = lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.MULTIPLE).FirstOrDefault().ColorAttendance;


                _EmployeeAttendaceViewer = new ControlEmployeeAttendanceViewer();
                SplitContainerChartView.Panel2.Controls.Clear();
                SplitContainerChartView.Panel2.Controls.Add(_EmployeeAttendaceViewer);
                _EmployeeAttendaceViewer.Dock = DockStyle.Fill;

                //_EmployeesList = new BindingList<SelectListItem>();
                //FormatEmployeeGrid();
                //_AttendanceList = new BindingList<vAttendanceRegister>();
                //FormatAttendanceGrid();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::PageMonthlyAttendanceManager_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OnColorChange(object sender, ColorEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ATTENDANCE_TYPE mType = (ATTENDANCE_TYPE)((KryptonColorButton)sender).Tag;
                Color strColor = Color.White;
                switch (mType)
                {
                    case ATTENDANCE_TYPE.PRESENT: strColor = btnPresentColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.ABSENT: strColor = btnAbsentColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.LEAVE: strColor = btnLeaveColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.OUT_DOOR: strColor = btnOutdoorColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.COMP_OFF: strColor = btnCompOffColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.LATE_COMING: strColor = btnLateComingColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.EARLY_GOING: strColor = btnEarlyLeavingColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.HOLIDAY: strColor = btnHolidayColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.WEEK_OFF: strColor = btnWeekOffColor.SelectedColor; break;
                    case ATTENDANCE_TYPE.MULTIPLE: strColor = btnDuplicatesColor.SelectedColor; break;
                }

                (new ServiceEmployee()).SetColorPreference(Program.CURR_USER.EmployeeID, mType, strColor);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::OnColorChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnPrepareMonthlySheet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ServiceAttendance serviceAttendance = new ServiceAttendance();
            try
            {
                gridAttendance.DataSource = null;
                
                headerGridView.Values.Heading = string.Format("Fetching list of Distinct Employees for month ({0})", dtAttendanceMonth.Value.ToString("MMMM"));
                Application.DoEvents();
                _EmployeesList = AppCommon.ConvertToBindingList<SelectListItem>(serviceAttendance.GetDistinctEmployeesListForMonthInAttendance(dtAttendanceMonth.Value));
                gridActiveEmployees.DataSource = _EmployeesList;
                FormatEmployeeGrid();
                Application.DoEvents();
                headerGridView.Values.Heading = string.Format("Fetching list of Distinct Employees Completed....", dtAttendanceMonth.Value.ToString("MMMM"));
                Application.DoEvents();
                headerGridView.Values.Heading = string.Format("Preparing Attendance Sheet for month ({0})", dtAttendanceMonth.Value.ToString("MMMM"));
                Application.DoEvents();
                //_AttendanceList = AppCommon.ConvertToBindingList<vAttendanceRegister>((new ServiceAttendance()).GetAttendanceRecordsForMonth(dtAttendanceMonth.Value));
                headerGridView.Values.Heading = string.Format("Fetched {0} Attendance Records. Now Binding to Grid", _AttendanceList.Count());
                Application.DoEvents();
                gridAttendance.DataSource = _AttendanceList;
                
                FormatAttendanceGrid();
                Application.DoEvents();
                SetAttendanceRowColor();
                headerGridView.Values.Heading = string.Format("Attendance Sheet for month ({0}) generated successfully", dtAttendanceMonth.Value.ToString("MMMM"));
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::btnPrepareAttendance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void gridAttendance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::gridAttendance_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtSearchOnsiteEmployee_TextChanged(object sender, EventArgs e)
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
                    _filterAttendanceList = new BindingList<vAttendanceRegister>(_AttendanceList.Where(p => p.EmployeeDescription.Contains(txtSearchOnsiteEmployee.Text.ToUpper())).ToList());
                    gridAttendance.DataSource = _filterAttendanceList;
                    SetAttendanceRowColor();
                }

                headerGroupActiveEmployees.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridAttendance.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::txtSearchOnsiteEmployee_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void gridAttendance_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedAttendanceID = (int)gridAttendance.Rows[e.RowIndex].Cells["PK_AttendanceID"].Value;
                SelectedAttendanceModel = _AttendanceList.Where(x => x.PK_AttendanceID == this.SelectedAttendanceID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::gridAttendance_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                String strMessage = "Are you sure to delete Attendance\n";
                if (this.SelectedAttendanceModel != null)
                {
                    strMessage += string.Format("{0} {1}\ndated {2} \n\n\n",
                        SelectedAttendanceModel.AttendanceTypeName, 
                        SelectedAttendanceModel.EmployeeDescription.Split('\n')[0],
                        SelectedAttendanceModel.AttendInTime.ToString("dd MMM yyyy"));
                    strMessage += "This will delete associated Leave Application.. if exists";
                    if(MessageBox.Show(strMessage,"Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        (new ServiceAttendance()).DeleteAttendanceAndItsLeave(this.SelectedAttendanceID);
                        //_AttendanceList = AppCommon.ConvertToBindingList<vAttendanceRegister>((new ServiceAttendance()).GetAttendanceRecordsForMonth(dtAttendanceMonth.Value));
                        gridAttendance.DataSource = _AttendanceList;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::btnRemoveAttendance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }


        private void FormatEmployeeGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                gridActiveEmployees.Columns["ID"].Visible =
                gridActiveEmployees.Columns["Code"].Visible =
                gridActiveEmployees.Columns["DescriptionToUpper"].Visible =
                gridActiveEmployees.Columns["IsActive"].Visible = false;
                headerGridView.Values.Heading = "Formatting Employee's Grid Completed";
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::FormatEmployeeGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void FormatAttendanceGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                headerGridView.Values.Heading = string.Format("Formatting Attendance Sheet Started ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["PK_AttendanceID"].Visible = false;
                gridAttendance.Columns["FK_EmployeeID"].Visible = false;
                gridAttendance.Columns["AttendanceType"].Visible = false;
                gridAttendance.Columns["AttendanceTypeName"].Visible = false;
                gridAttendance.Columns["FK_CostCenterId"].Visible = false;
                gridAttendance.Columns["FK_ApprovedBy"].Visible = false;
                gridAttendance.Columns["FK_PreparedBy"].Visible = false;
                gridAttendance.Columns["FK_YearId"].Visible = false;
                gridAttendance.Columns["FK_CompanyId"].Visible = false;
                gridAttendance.Columns["FK_BranchId"].Visible = false;
                gridAttendance.Columns["IsActive"].Visible = false;
                headerGridView.Values.Heading = string.Format("Hiding Grid Columns ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();

                int gridWidth = gridAttendance.Width;

                gridAttendance.Columns["AttendDate"].DefaultCellStyle.Format = "dd MMM yy";
                gridAttendance.Columns["AttendDate"].Width = 70;
                gridAttendance.Columns["AttendDate"].HeaderText = "Date";
                headerGridView.Values.Heading = string.Format("Formatted Attendance Date Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();

                gridAttendance.Columns["EmployeeDescription"].Width = (int)(gridWidth * .15);
                gridAttendance.Columns["EmployeeDescription"].HeaderText = "Employee";
                headerGridView.Values.Heading = string.Format("Formatted Employee Description Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();

                gridAttendance.Columns["AttendInTime"].HeaderText = "In Time";
                gridAttendance.Columns["AttendInTime"].Width = 62;
                gridAttendance.Columns["AttendInTime"].DefaultCellStyle.Format = "hh:mm tt";
                headerGridView.Values.Heading = string.Format("Formatted Attendnace In Time Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["AttendOutTime"].HeaderText = "Out Time";
                gridAttendance.Columns["AttendOutTime"].Width = 62;
                gridAttendance.Columns["AttendOutTime"].DefaultCellStyle.Format = "hh:mm tt";
                headerGridView.Values.Heading = string.Format("Formatted Attendnace Out Time Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["Duration"].HeaderText = "Duration";
                gridAttendance.Columns["Duration"].Width = 62;
                headerGridView.Values.Heading = string.Format("Formatted Duration Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                
                

                gridAttendance.Columns["AtWarehouse"].HeaderText = "(WH)";
                gridAttendance.Columns["AtWarehouse"].Width = 40;

                gridAttendance.Columns["AttendanceRemarks"].HeaderText = "Remarks";
                //gridAttendance.Columns["AttendanceRemarks"].Width = 80;
                headerGridView.Values.Heading = string.Format("Formatted Attendance Remarks Column ({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                gridAttendance.Columns["PreparedBy"].Width = (int)(gridWidth * .15);
                headerGridView.Values.Heading = string.Format("Formatted Prepareb By Column");
                Application.DoEvents();
                headerGridView.Values.Heading = string.Format("Formatting Attendance Sheet Completed....({0} rows)", _AttendanceList.Count);
                Application.DoEvents();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::FormatAttendanceGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetAttendanceRowColor()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow row in gridAttendance.Rows)
                {
                    headerGridView.Values.Heading = string.Format("Applying Color : {0} ({1}/{2})", 
                        ((DateTime)row.Cells["AttendDate"].Value).ToString("dd MMM yyyy"), 
                        row.Index,
                        _AttendanceList.Count);
                    ATTENDANCE_TYPE mType = (ATTENDANCE_TYPE)row.Cells["AttendanceType"].Value;
                    switch (mType)
                    {
                        case ATTENDANCE_TYPE.PRESENT: row.DefaultCellStyle.BackColor = btnPresentColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.ABSENT: row.DefaultCellStyle.BackColor = btnAbsentColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.LEAVE: row.DefaultCellStyle.BackColor = btnLeaveColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.OUT_DOOR: row.DefaultCellStyle.BackColor = btnOutdoorColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.COMP_OFF: row.DefaultCellStyle.BackColor = btnCompOffColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.LATE_COMING: row.DefaultCellStyle.BackColor = btnLateComingColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.EARLY_GOING: row.DefaultCellStyle.BackColor = btnEarlyLeavingColor.SelectedColor; break;
                        case ATTENDANCE_TYPE.MULTIPLE: row.DefaultCellStyle.BackColor = btnDuplicatesColor.SelectedColor; break;
                    }
                    Application.DoEvents();

                }
                headerGridView.Values.Heading = string.Format("Identifying Dulicate Attendance Records & highlighting with defined Color");
                Application.DoEvents();
                //List<DuplicateAttendaceModel> lstDuplicates = (new ServiceAttendance()).GetDuplicateAttendance(dtAttendanceMonth.Value);
                //foreach (DuplicateAttendaceModel model in lstDuplicates)
                //{
                //    foreach (DataGridViewRow row in gridAttendance.Rows)
                //    {
                //        if ((DateTime)row.Cells["AttendDate"].Value == model.AttendanceDate && (int)row.Cells["FK_EmployeeID"].Value == model.EmployeeID)
                //        {
                //            row.DefaultCellStyle.BackColor = btnDuplicatesColor.SelectedColor;

                //        }
                //    }

                //}

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageMonthlyAttendanceManager::SetAttendanceRowColor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void gridActiveEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (_EmployeeAttendaceViewer != null)
                {
                    _EmployeeAttendaceViewer.EmployeeID = (int)gridActiveEmployees.Rows[e.RowIndex].Cells["ID"].Value;
                    _EmployeeAttendaceViewer.dtAttendanceMonth.Value= _EmployeeAttendaceViewer.AttendanceMonth = dtAttendanceMonth.Value;
                    _EmployeeAttendaceViewer.headerGroupOptions.Visible = false;
                    _EmployeeAttendaceViewer.PopulateCalendarAndSummary();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            this.Cursor = Cursors.Default;
        }
    }
}
