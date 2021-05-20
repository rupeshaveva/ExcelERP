using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.HR;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.MODELS;
using libERP.MODELS.HR;
using appExcelERP.Controls.HR.Attendance;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeAttendanceViewer : UserControl
    {
        public int EmployeeID { get; set; }
        public DateTime AttendanceMonth { get; set; }

        private ControlEmployeeAttendanceSummary _controlSummary = null;

        public ControlEmployeeAttendanceViewer()
        {
            InitializeComponent();

        }
        public void PopulateCalendarAndSummary()
        {
            try
            {
                PrepareCalendarControl();
                PrepareCalendarSummary();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::PopulateCalendarAndSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void PrepareCalendarControl()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                int cols = 7;
                int rows = 5;
                DateTime startDate = new DateTime(dtAttendanceMonth.Value.Year, dtAttendanceMonth.Value.Month, 1);
                int days = DateTime.DaysInMonth(dtAttendanceMonth.Value.Year, dtAttendanceMonth.Value.Month);
                DateTime endDate= new DateTime(dtAttendanceMonth.Value.Year, dtAttendanceMonth.Value.Month, days);
                DateTime currDate = startDate;
                tableMonthCalendar.Controls.Clear();
                tableMonthCalendar.ColumnStyles.Clear();
                tableMonthCalendar.RowStyles.Clear();
                tableMonthCalendar.VerticalScroll.Enabled = true;
                tableMonthCalendar.HorizontalScroll.Enabled = false;

                //Now we will generate the table, setting up the row and column counts first
                tableMonthCalendar.ColumnCount = cols;
                tableMonthCalendar.RowCount = rows;

                for (int x = 0; x < rows; x++)
                {
                    //First add a column
                    tableMonthCalendar.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    for (int y = 0; y < cols; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        if (x == 0)
                        {
                            tableMonthCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        }
                        KryptonHeaderGroup header = new KryptonHeaderGroup();
                        PrepareAttendanceDescription(header, currDate);
                        tableMonthCalendar.Controls.Add(header, y, x);
                        header.Dock = DockStyle.Fill;
                        currDate = currDate.AddDays(1);
                        if (currDate.Date > endDate.Date)
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::PrepareCalendarControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void PrepareCalendarSummary()
        {
            try
            {
                _controlSummary.EmployeeID = this.EmployeeID;
                _controlSummary.AttendanceMonth = this.AttendanceMonth;
                _controlSummary.PrepareCalendarSummary();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::PrepareCalendarSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ControlEmployeeAttendanceViewer_Load(object sender, EventArgs e)
        {
            try
            {
                _controlSummary = new ControlEmployeeAttendanceSummary();
                panelAttendanceSummary.Controls.Add(_controlSummary);
                _controlSummary.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::ControlEmployeeAttendanceViewer_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnPrepareAttendance_Click(object sender, EventArgs e)
        {
            PrepareCalendarControl();

        }
        private void PrepareAttendanceDescription(KryptonHeaderGroup header, DateTime currDate)
        {
            string strDescription = string.Empty;
            int employeeID = 0;
            List<AttendanceColorModel> lstColors = (new ServiceEmployee()).GetAttendanceColorPreferencesOfEmployee(Program.CURR_USER.EmployeeID);
            try
            {
                header.HeaderStylePrimary = HeaderStyle.DockActive;
                string description = string.Empty;
                header.ValuesPrimary.Heading = string.Format("{0} ({1})", currDate.ToString("dd MMM"), currDate.ToString("ddd"));
                header.ValuesPrimary.Image = null;
                header.ValuesSecondary.Heading = string.Empty;
                List<vAttendanceRegister> dbItems = (new ServiceAttendance()).GetAttendanceInfoDbRecordsOfEmplyeeOnDate(this.EmployeeID, currDate);
                strDescription = string.Empty;
                foreach (vAttendanceRegister item in dbItems)
                {
                    strDescription +=string.Format("{1}-{2} {0}", item.AttendanceRemarks, item.AttendInTime.ToString("hh:mmtt"), item.AttendOutTime.ToString("hh:mmtt"));
                    strDescription += (item.AtWarehouse) ? "At Warehouse ":"";
                    if (item.AttendanceType == (int)ATTENDANCE_TYPE.LEAVE || item.AttendanceType==(int)ATTENDANCE_TYPE.OUT_DOOR)
                    {
                        strDescription += string.Format("({0})\n\n",(item.IsActive)?"Approved":"Unapproved");
                        if (item.isLeaveRejected == true)
                        {
                            strDescription = string.Empty;
                            strDescription += string.Format("{1}-{2} {0}", item.AttendanceRemarks, item.AttendInTime.ToString("hh:mmtt"), item.AttendOutTime.ToString("hh:mmtt"));
                            strDescription += (item.AtWarehouse) ? "At Warehouse " : "";
                            strDescription += string.Format("(Rejected)\n\n");
                        }
                    }

                }

                Label lblDescription = new Label();
                lblDescription.BackColor = Color.Transparent;
                lblDescription.Text = strDescription;
                header.Panel.Controls.Add(lblDescription);
                lblDescription.Dock = DockStyle.Fill;
                if(dbItems.Count>0)
                {
                    if (dbItems.Count == 1)
                    {
                        vAttendanceRegister dbItem = dbItems[0];
                        ATTENDANCE_TYPE attendanceTYPE = (ATTENDANCE_TYPE)dbItem.AttendanceType;

                        switch (attendanceTYPE)
                        {
                            case ATTENDANCE_TYPE.PRESENT:
                                header.ValuesPrimary.Description = "Present";
                                //header.ValuesSecondary.Heading = string.Format("{0} - {1}", dbItem.AttendInTime.ToString("hh:mm tt"), dbItem.AttendOutTime.ToString("hh:mm tt"));
                                //header.ValuesSecondary.Description = string.Format("{0}", dbItem.AttendanceRemarks);
                                header.StateCommon.Back.Color1 = lstColors.Where(x=>x.TypeAttendance== ATTENDANCE_TYPE.PRESENT).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.ABSENT:
                                header.ValuesPrimary.Description = "Absent";
                                //header.ValuesSecondary.Heading = string.Format("{0} - {1}", dbItem.AttendInTime.ToString("hh:mm tt"), dbItem.AttendOutTime.ToString("hh:mm tt"));
                                //header.ValuesSecondary.Description = string.Format("{0}", dbItem.AttendanceRemarks);
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.ABSENT).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.LEAVE:
                                header.ValuesPrimary.Description = "Leave";
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LEAVE).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.OUT_DOOR:
                                header.ValuesPrimary.Description = "Outdoor";
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.OUT_DOOR).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.COMP_OFF:
                                header.ValuesPrimary.Description = "CompOff";
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.COMP_OFF).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.LATE_COMING:
                                header.ValuesPrimary.Description = "Late Coming";
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LATE_COMING).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.EARLY_GOING:
                                header.ValuesPrimary.Description = "Early Leaving";
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.EARLY_GOING).FirstOrDefault().ColorAttendance;
                                break;
                            case ATTENDANCE_TYPE.SANDWICH_LEAVE:
                                header.ValuesPrimary.Description = "Sandwich Leave";
                                header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LEAVE).FirstOrDefault().ColorAttendance;
                                break;

                        }
                    }
                    else
                    {
                        header.ValuesPrimary.Description = "Multiple Entries";
                        header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.MULTIPLE).FirstOrDefault().ColorAttendance;
                    }
                }

                ServiceHolidayAndWeekOffs serviceOff = new ServiceHolidayAndWeekOffs();
                if (serviceOff.IsHolidayOrWeekOff(currDate))
                {
                    TBL_MP_HR_HolidaysAndWeekOff dbOff = serviceOff.GetHolidayDbRecordByDate(currDate);

                    if (dbOff != null)
                    {

                        if (dbOff.HolidayType == (int)ATTENDANCE_TYPE.WEEK_OFF)
                        {
                            if (AppCommon.isSecondSaturday(currDate) || AppCommon.isFourthSaturday(currDate))
                            {
                                if ((new ServiceEmployee()).IsWeekOffDayForEmployee("SATURDAY", this.EmployeeID))
                                {
                                    header.ValuesPrimary.Description = "Week Off";
                                    header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.WEEK_OFF).FirstOrDefault().ColorAttendance;
                                    strDescription += string.Format("Week Off {0}", dbOff.Remarks);
                                    lblDescription.Text = strDescription;
                                }
                            }
                            else
                            { 
                                header.ValuesPrimary.Description = "Week Off";
                            header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.WEEK_OFF).FirstOrDefault().ColorAttendance;
                            strDescription += string.Format("Week Off {0}", dbOff.Remarks);
                            lblDescription.Text = strDescription;
                            }
                        }
                        if (dbOff.HolidayType == (int)ATTENDANCE_TYPE.HOLIDAY)
                        {
                            header.ValuesPrimary.Description = "Holiday";
                            header.StateCommon.Back.Color1 = lstColors.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.HOLIDAY).FirstOrDefault().ColorAttendance;
                            strDescription += string.Format("Holiday {0}", dbOff.Remarks);
                            lblDescription.Text = strDescription;
                        }
                        

                    }
                }
                
                
                
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::PrepareAttendanceDescription", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGenerateManualSheet_Click(object sender, EventArgs e)
        {
            try
            {
                PrepareCalendarControl();
                PrepareCalendarSummary();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::btnGenerateManualSheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void dtAttendanceMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.AttendanceMonth = dtAttendanceMonth.Value;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceViewer::dtAttendanceMonth_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
    }
}
