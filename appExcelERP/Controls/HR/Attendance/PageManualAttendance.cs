using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.HR;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.PMC;
using libERP.MODELS;
using appExcelERP.Forms;
using libERP;
using appExcelERP.Forms.HR;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.HR.Attendance
{
    public partial class PageManualAttendance : UserControl
    {
        private int selectedOnSiteEmployeeID = 0;
        public bool selectedLeaveType = false;
        private string selectedOnSiteEmployeeName = string.Empty;
        private ATTENDANCE_TYPE selectedAttendanceTYPE = ATTENDANCE_TYPE.NONE;
        private ServiceAttendance _serviceAttendance = null;

        public OnSiteAttendanceModel _selectedAttendanceRecord { get; set; }
        public BindingList<OnSiteAttendanceModel> listOnSiteATTENDANCE { get; set; }
        public BindingList<OnSiteAttendanceModel> _filteredListOnSiteATTENDANCE { get; set; }
        public PageManualAttendance()
        {
            InitializeComponent();
        }
        private void PageManualAttendance_Load(object sender, EventArgs e)
        {
            this.Text = "EXCEL Gas & Equipments Pvt. Ltd. [Sync. Attendance Data]";
            btnRemoveOnsiteemployeeFromSheet.Visible = false;
            PopulateProjects();
            
        }
       private void PopulateProjects()
        {
            try
            {
                List<SelectListItem> lstProjets = new List<SelectListItem>();
                lstProjets.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstProjets.AddRange((new ServiceProject()).GetAllActiveProjectsForSelection());
                cboProject.DataSource = lstProjets;
                cboProject.DisplayMember = "Description";
                cboProject.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::PopulateProjects", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ONSITE EMPLOYEES
        private void btnGenerateOnsiteSheet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                listOnSiteATTENDANCE = (new ServiceAttendance()).GetOnSiteAttendanceSheetForDate(dtSiteAttendanceDate.Value);
                gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnGenerateOnsiteSheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridOnSiteAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (e.ColumnIndex > -1)
                {
                    // Bind grid cell with combobox and than bind combobox with datasource.  
                    DataGridViewComboBoxCell objGridDropbox = new DataGridViewComboBoxCell();

                    // Check the column  cell, in which it click.  
                    if (gridOnSiteAttendance.Columns[e.ColumnIndex].Name.Contains("ProjectID"))
                    {
                        int pID = (int)gridOnSiteAttendance["ProjectID", e.RowIndex].Value;
                        // On click of datagridview cell, attched combobox with this click cell of datagridview  
                        gridOnSiteAttendance[e.ColumnIndex, e.RowIndex] = objGridDropbox;
                        List<SelectListItem> lstProjects = new List<SelectListItem>();
                        lstProjects.Add(new SelectListItem() { ID = 0, Description = "(None)" });
                        lstProjects.AddRange((new ServiceProject()).GetAllActiveProjectsForSelection());
                        objGridDropbox.DataSource = lstProjects; // Bind combobox with datasource.  
                        objGridDropbox.ValueMember = "ID";
                        objGridDropbox.DisplayMember = "Description";
                        objGridDropbox.Value = ((List<SelectListItem>)objGridDropbox.DataSource).Where(x => x.ID == pID).FirstOrDefault().ID;
                        objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                        objGridDropbox.FlatStyle = FlatStyle.Flat;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::gridOnSiteAttendance_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridOnSiteAttendance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (gridOnSiteAttendance.CurrentCell.ColumnIndex == gridOnSiteAttendance.Columns["ProjectID"].Index && e.Control is ComboBox)
                {
                    ComboBox comboBox = e.Control as ComboBox;
                    comboBox.SelectedIndexChanged -= Project_SelectionChanged;
                    comboBox.SelectedIndexChanged += Project_SelectionChanged;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::gridOnSiteAttendance_EditingControlShowing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Project_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var currentcell = gridOnSiteAttendance.CurrentCellAddress;
                var sendingCB = sender as DataGridViewComboBoxEditingControl;
                List<ListItemModel> lstValues = (List<ListItemModel>)sendingCB.DataSource;


                if (lstValues != null)
                {
                    int mID = ((ListItemModel)sendingCB.SelectedItem).ID;
                    gridOnSiteAttendance.Rows[currentcell.Y].Cells["ProjectID"].Value = mID;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::Project_SelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnPostOnSiteAttendanceToERP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new ServiceAttendance()).PostOnSiteAttendanceRecordsToExcelERP(listOnSiteATTENDANCE, Program.CURR_USER.EmployeeID, selectedLeaveType);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnPostOnSiteAttendanceToERP_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridOnSiteAttendance_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    chkbtnAbsent.Checked = false;
                    chkbtnLeave.Checked = false;
                    chkbtnLeave.Checked = false;
                    chkbtnOutdoor.Checked = false;
                    this.selectedOnSiteEmployeeID = (int)gridOnSiteAttendance.Rows[e.RowIndex].Cells["EmployeeID"].Value;
                    this.selectedOnSiteEmployeeName = gridOnSiteAttendance.Rows[e.RowIndex].Cells["EmployeeName"].Value.ToString();
                    this._selectedAttendanceRecord = listOnSiteATTENDANCE.Where(x => x.EmployeeID == this.selectedOnSiteEmployeeID).FirstOrDefault();
                    headerGroupOnSiteAttendanceInput.ValuesSecondary.Heading = "Selected: " + selectedOnSiteEmployeeName;
                    this.selectedAttendanceTYPE = (ATTENDANCE_TYPE)gridOnSiteAttendance.Rows[e.RowIndex].Cells["AttendanceType"].Value;

                    PopulateAttendanceEntryForm();
                    //SelectListItem typeItem = ((List<SelectListItem>)cboAttendanceType.DataSource).Where(x => x.ID == (int)this.selectedAttendanceTYPE).FirstOrDefault();
                    //if (typeItem != null)
                    //{
                    //    cboAttendanceType.SelectedItem = typeItem;
                    //    txtAttendanceRemarks.Text = gridOnSiteAttendance.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                    //}
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::gridOnSiteAttendance_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateAttendanceEntryForm()
        {
            try
            {
                if (this._selectedAttendanceRecord != null)
                {
                    switch (_selectedAttendanceRecord.AttendanceType)
                    {
                        case ATTENDANCE_TYPE.PRESENT:
                            chkbtnPresent.Checked = true;
                            chkbtnAbsent.Checked = chkbtnLeave.Checked = chkbtnOutdoor.Checked = false; break;
                        case ATTENDANCE_TYPE.ABSENT:
                            chkbtnAbsent.Checked = true;
                            chkbtnPresent.Checked = chkbtnOutdoor.Checked = chkbtnLeave.Checked = false; break;
                        case ATTENDANCE_TYPE.LEAVE:
                            chkbtnLeave.Checked = true;
                            chkbtnAbsent.Checked = chkbtnPresent.Checked = chkbtnOutdoor.Checked = false; break;
                        case ATTENDANCE_TYPE.OUT_DOOR:
                            chkbtnOutdoor.Checked = true;
                            chkbtnAbsent.Checked = chkbtnPresent.Checked = chkbtnLeave.Checked = false; break;
                    }
                    chkBtnWarehouse.Checked = _selectedAttendanceRecord.AtWarehouse;
                    chkBtnOnSite.Checked = !_selectedAttendanceRecord.AtWarehouse;

                    if (chkBtnOnSite.Checked == true)
                        chkBtnWarehouse.Checked = false;
                    if (chkBtnWarehouse.Checked == true)
                        chkBtnOnSite.Checked = false;

                    SelectListItem projectItem = ((List<SelectListItem>)cboProject.DataSource).Where(x => x.ID == _selectedAttendanceRecord.ProjectID).FirstOrDefault();
                    if (projectItem != null) cboProject.SelectedItem = projectItem;
                    dtOnSiteInTime.Value = _selectedAttendanceRecord.AttendanceInTime;
                    dtOnSiteOutTime.Value = _selectedAttendanceRecord.AttendanceOutTime;
                    txtRemarks.Text = _selectedAttendanceRecord.Remarks;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::PopulateAttendanceEntryForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveOnsiteemployeeFromSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.selectedOnSiteEmployeeID != 0)
                {
                    string strMessage = string.Format("Are you sure to remove Attendance of \n\n{0}\n\n from this Sheet", this.selectedOnSiteEmployeeName);
                    if (MessageBox.Show(strMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        OnSiteAttendanceModel selItem = listOnSiteATTENDANCE.Where(x => x.EmployeeID == selectedOnSiteEmployeeID).FirstOrDefault();
                        listOnSiteATTENDANCE.Remove(selItem);
                        headerGroupOnSiteAttendance.ValuesSecondary.Heading = string.Format("{0} Records found.", listOnSiteATTENDANCE.Count);
                    }


                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnRemoveOnsiteemployeeFromSheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchOnsiteEmployee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchOnsiteEmployee.Text.Trim() == string.Empty)
                {
                    gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;
                }
                else
                {
                    _filteredListOnSiteATTENDANCE = new BindingList<OnSiteAttendanceModel>(listOnSiteATTENDANCE.Where(p => p.EmployeeName.Contains(txtSearchOnsiteEmployee.Text.ToUpper())).ToList());
                    gridOnSiteAttendance.DataSource = _filteredListOnSiteATTENDANCE;
                }

                headerGroupOnSiteAttendance.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridOnSiteAttendance.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::txtSearchOnsiteEmployee_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewOnSiteAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.EMPLOYEES);
                frm.SingleSelect = false;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (MultiSelectListItem item in frm.SelectedItems)
                    {
                        OnSiteAttendanceModel model = new OnSiteAttendanceModel();
                        TBL_MP_Master_Employee emp = (new ServiceEmployee()).GetEmployeeDbRecordByID(item.ID);
                        if (emp != null)
                        {
                            model.EmployeeID = emp.PK_EmployeeId;
                            model.EmployeeCode = emp.EmployeeCode;
                            model.EmployeeName = emp.EmployeeName;
                        }
                        model.AttendanceDate = dtSiteAttendanceDate.Value;
                        model.AttendanceInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                        model.AttendanceOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                        model.AttendanceType = ATTENDANCE_TYPE.PRESENT;
                        model.Remarks = "";
                        List<TBL_MP_HR_ManualAttendance_Master> dbRecords = (new ServiceAttendance()).GetAttendanceRecordOfEmployeeOnDate(emp.PK_EmployeeId, model.AttendanceDate);
                        if (dbRecords.Count > 0)
                        {
                            TBL_MP_HR_ManualAttendance_Master attendanceRecord = dbRecords[0];
                            model.AttendanceType = (ATTENDANCE_TYPE)attendanceRecord.AttendanceType;
                            model.AttendanceInTime = attendanceRecord.AttendInTime;
                            model.AttendanceOutTime = attendanceRecord.AttendOutTime;
                            model.AtWarehouse = attendanceRecord.AtWarehouse;
                            if (attendanceRecord.FK_LeaveApplicationID != null)
                                model.LeaveApplicationID = (int)attendanceRecord.FK_LeaveApplicationID;
                            if (attendanceRecord.FK_CostCenterId != null)
                            {
                                model.ProjectID = (int)attendanceRecord.FK_CostCenterId;
                                model.ProjectName = attendanceRecord.TBL_MP_PMC_ProjectMaster.ProjectName;
                            }
                            model.Remarks = attendanceRecord.AttendanceRemarks;
                        }

                        if (listOnSiteATTENDANCE == null) listOnSiteATTENDANCE = new BindingList<OnSiteAttendanceModel>();
                        listOnSiteATTENDANCE.Add(model);
                    }
                    gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnAddNewManualAttendance_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void chkbtnPresent_Click(object sender, EventArgs e)
        {
            chkbtnAbsent.Checked = false;
            chkbtnLeave.Checked = false;
            chkbtnOutdoor.Checked = false;
            txtRemarks.Text = GetAttendanceRemarks();
        }
        private void chkbtnAbsent_Click(object sender, EventArgs e)
        {
            chkbtnPresent.Checked = false;
            chkbtnLeave.Checked = false;
            chkbtnOutdoor.Checked = false;
            txtRemarks.Text = GetAttendanceRemarks();
        }
        private void chkbtnLeave_Click(object sender, EventArgs e)
        {
            chkbtnPresent.Checked = false;
            chkbtnAbsent.Checked = false;
            chkbtnOutdoor.Checked = false;
            try
            {
                frmAddEditLeaveApplication frm = null;
                if (chkbtnLeave.Checked)
                {
                    selectedLeaveType = true;
                    if (_selectedAttendanceRecord.LeaveApplicationID == 0)
                    {
                        frm = new frmAddEditLeaveApplication();
                        frm.EmployeeID = _selectedAttendanceRecord.EmployeeID;
                        frm.SelectedLeavFormTypeID = (new ServiceLeaveApplication()).LEAVE_TYPE_LEAVE_ID;
                        frm.dtLeaveApplicationDate.Value = _selectedAttendanceRecord.AttendanceDate;
                        frm.dtFromDate.Value = frm.dtFromTime.Value = frm.dtToDate.Value = frm.dtToTime.Value = _selectedAttendanceRecord.AttendanceDate;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _selectedAttendanceRecord.LeaveApplicationID = frm.LeaveApplicationID;
                            vLeaveApplication leave = (new ServiceLeaveApplication()).GetLeaveApplicationInfoViewRecord(_selectedAttendanceRecord.LeaveApplicationID);
                            txtRemarks.Text = string.Format("{0} ({1})", leave.LeaveFormTypeName, leave.LeaveTypeName);
                            _selectedAttendanceRecord.AttendanceType = ATTENDANCE_TYPE.LEAVE;
                           
                            dtOnSiteInTime.Value = leave.FromTime.Value;
                            dtOnSiteOutTime.Value = leave.ToTime.Value;
                        }
                    }
                    else
                    {
                          //frm = new frmAddEditLeaveApplication(_selectedAttendanceRecord.LeaveApplicationID);
                          MessageBox.Show("LEAVE is already entered...","Caution",MessageBoxButtons.OK); 
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::chkbtnLeave_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void chkbtnOutdoor_Click(object sender, EventArgs e)
        {
            chkbtnPresent.Checked = false;
            chkbtnAbsent.Checked = false;
            chkbtnLeave.Checked = false;
            try
            {
                if (chkbtnOutdoor.Checked)
                {
                    selectedLeaveType = true;
                    if (_selectedAttendanceRecord.LeaveApplicationID == 0)
                    {
                        frmAddEditLeaveApplication frm = new frmAddEditLeaveApplication();
                        frm.EmployeeID = _selectedAttendanceRecord.EmployeeID;
                        frm.SelectedLeavFormTypeID = (new ServiceLeaveApplication()).LEAVE_TYPE_OUTDOOR_ID;
                        frm.dtLeaveApplicationDate.Value = _selectedAttendanceRecord.AttendanceDate;
                        frm.dtFromDate.Value = frm.dtFromTime.Value = frm.dtToDate.Value = frm.dtToTime.Value = _selectedAttendanceRecord.AttendanceDate;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _selectedAttendanceRecord.LeaveApplicationID = frm.LeaveApplicationID;
                            vLeaveApplication leave = (new ServiceLeaveApplication()).GetLeaveApplicationInfoViewRecord(_selectedAttendanceRecord.LeaveApplicationID);
                            txtRemarks.Text = string.Format("{0} ({1})", leave.LeaveFormTypeName, leave.LeaveTypeName);
                            _selectedAttendanceRecord.AttendanceType = ATTENDANCE_TYPE.OUT_DOOR;
                            dtOnSiteInTime.Value = leave.FromTime.Value;
                            dtOnSiteOutTime.Value = leave.ToTime.Value;

                        }
                    }
                    else
                    {
                        //frm = new frmAddEditLeaveApplication(_selectedAttendanceRecord.LeaveApplicationID);
                        MessageBox.Show("OUTDOOR is already entered...", "Caution", MessageBoxButtons.OK);
                    }

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageDailyAttendance::chkbtnOutdoor_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateManualAttendance_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (chkbtnPresent.Checked) _selectedAttendanceRecord.AttendanceType = ATTENDANCE_TYPE.PRESENT;
                if (chkbtnAbsent.Checked) _selectedAttendanceRecord.AttendanceType = ATTENDANCE_TYPE.ABSENT;
                if (chkbtnLeave.Checked) _selectedAttendanceRecord.AttendanceType = ATTENDANCE_TYPE.LEAVE;
                if (chkbtnOutdoor.Checked) _selectedAttendanceRecord.AttendanceType = ATTENDANCE_TYPE.OUT_DOOR;

                _selectedAttendanceRecord.AtWarehouse = chkBtnWarehouse.Checked;

                _selectedAttendanceRecord.ProjectID = ((SelectListItem)cboProject.SelectedItem).ID;
                _selectedAttendanceRecord.ProjectName = ((SelectListItem)cboProject.SelectedItem).Description;

                _selectedAttendanceRecord.AttendanceInTime = dtOnSiteInTime.Value;
                _selectedAttendanceRecord.AttendanceOutTime = dtOnSiteOutTime.Value;
                _selectedAttendanceRecord.Remarks = txtRemarks.Text;

                gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;
                gridOnSiteAttendance.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::chkbtnLeave_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void chkBtnOnSite_Click(object sender, EventArgs e)
        {
            try
            {
                chkBtnWarehouse.Checked = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::chkBtnOnSite_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkBtnWarehouse_Click(object sender, EventArgs e)
        {
            try
            {
                chkBtnOnSite.Checked = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::chkBtnWarehouse_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetAttendanceRemarks()
        {
            string strRemarks = string.Empty;
            try
            {
                if (chkbtnPresent.Checked) strRemarks += "Present";
                if (chkbtnAbsent.Checked) strRemarks += "Absent";
                if (chkbtnLeave.Checked) strRemarks += "Leave";
                if (chkbtnOutdoor.Checked) strRemarks += "Outdoor";

                if (chkBtnOnSite.Checked) strRemarks += "Onsite";
                if (chkBtnWarehouse.Checked) strRemarks += "Warehouse";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::GetAttendanceRemarks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strRemarks;
        }
        private void gridOnSiteAttendance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridOnSiteAttendance.ReadOnly = true;
                gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;
                gridOnSiteAttendance.Columns["EmployeeID"].Visible = false;
                gridOnSiteAttendance.Columns["AttendanceDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                gridOnSiteAttendance.Columns["AttendanceDate"].Width = 80;
                gridOnSiteAttendance.Columns["AttendanceDate"].HeaderText = "Date";
                gridOnSiteAttendance.Columns["EmployeeCode"].HeaderText = "Emp Code";
                gridOnSiteAttendance.Columns["EmployeeCode"].Width = 80;
                gridOnSiteAttendance.Columns["AttendanceInTime"].DefaultCellStyle.Format = "hh:mm tt";
                gridOnSiteAttendance.Columns["AttendanceInTime"].HeaderText = "Time IN";
                gridOnSiteAttendance.Columns["AttendanceInTime"].Width = 65;
                gridOnSiteAttendance.Columns["AttendanceOutTime"].DefaultCellStyle.Format = "hh:mm tt";
                gridOnSiteAttendance.Columns["AttendanceOutTime"].HeaderText = "Time OUT";
                gridOnSiteAttendance.Columns["AttendanceOutTime"].Width = 65;
                gridOnSiteAttendance.Columns["ProjectID"].Visible = false;
                gridOnSiteAttendance.Columns["LeaveApplicationID"].Visible = false;

                headerGroupOnSiteAttendance.ValuesSecondary.Heading = string.Format("{0} Records found.", listOnSiteATTENDANCE.Count);

                if (listOnSiteATTENDANCE.Count > 0) btnRemoveOnsiteemployeeFromSheet.Visible = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::gridOnSiteAttendance_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dtSiteAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (AppCommon.IsSunday(dtSiteAttendanceDate.Value))
                {
                    MessageBox.Show("You are not permitted to Prepare Attendance on Sunday", "Caution");
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::dtSiteAttendanceDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClearManualAttendancesheet_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Erase all Attendance Records on {0}", dtSiteAttendanceDate.Value.ToString("dd MMM yyyy"));
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listOnSiteATTENDANCE = new BindingList<OnSiteAttendanceModel>();
                    gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;
                    headerGroupOnSiteAttendanceInput.ValuesSecondary.Heading = "Selected: ";
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnClearManualAttendancesheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSelectProject_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.ACTIVE_PROJECT);
                frm.SingleSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int selectedProjectID = frm.SelectedItems[0].ID;
                    List<int> _employeeIDs = (new ServiceAttendance()).GetEmployeeIDsWhoHaveAttendendaceForProject(selectedProjectID);
                    foreach (int empID in _employeeIDs)
                    {
                        OnSiteAttendanceModel model = new OnSiteAttendanceModel();
                        TBL_MP_Master_Employee emp = (new ServiceEmployee()).GetEmployeeDbRecordByID(empID);
                        if (emp != null)
                        {
                            model.EmployeeID = emp.PK_EmployeeId;
                            model.EmployeeCode = emp.EmployeeCode;
                            model.EmployeeName = emp.EmployeeName; 
                        }
                        model.AttendanceDate = dtSiteAttendanceDate.Value;
                      
                        model.AttendanceInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                        model.AttendanceOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                        model.AttendanceType = ATTENDANCE_TYPE.PRESENT;
                        model.ProjectID = selectedProjectID;
                        model.ProjectName = (new ServiceProject()).GetProjectDBInfoByID(selectedProjectID).ProjectName;
                        model.Remarks = "Present";
                        if (listOnSiteATTENDANCE == null) listOnSiteATTENDANCE = new BindingList<OnSiteAttendanceModel>();
                        listOnSiteATTENDANCE.Add(model);

                    }
                    listOnSiteATTENDANCE = AppCommon.ConvertToBindingList<OnSiteAttendanceModel>(listOnSiteATTENDANCE.OrderBy(x => x.EmployeeName).ToList());
                    gridOnSiteAttendance.DataSource = listOnSiteATTENDANCE;


                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnSelectProject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }


        #endregion

        private void btnRemoveMultiple_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in gridOnSiteAttendance.SelectedRows)
                    selectedRows.Add(row);
                if (selectedRows.Count > 0)
                {
                    string strMessage = string.Format("Are you sure?? you want to remove Selected '{0}' Attendance Record from list ",selectedRows.Count); 
                    if (MessageBox.Show(strMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //now delete rows:
                        foreach (DataGridViewRow row in selectedRows)
                        gridOnSiteAttendance.Rows.Remove(row);
                    }
                }
                else
                {
                    MessageBox.Show("There is no any Attendance Record to delete...", "Confirm", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageManualAttendance::btnRemoveMultiple_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
