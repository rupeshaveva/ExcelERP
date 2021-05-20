using ComponentFactory.Krypton.Toolkit;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms
{
    public partial class frmColorPreference : Form
    {
        public frmColorPreference()
        {
            InitializeComponent();
        }

        private void frmColorPreference_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {

                throw;
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
                MessageBox.Show(errMessage, "frmColorPreference::OnColorChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
