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
using libERP.SERVICES.HR;

namespace appExcelERP.Controls.HR.Attendance
{
    public partial class ControlEmployeeAttendanceSummary : UserControl
    {
        public int EmployeeID { get; set; }
        public DateTime AttendanceMonth { get; set; }
        public EmployeeAttendanceSummaryModel MODEL { get; set; }

        public ControlEmployeeAttendanceSummary()
        {
            InitializeComponent();
        }
        public void PrepareCalendarSummary()
        {
            try
            {
                headerGroupMain.ValuesPrimary.Heading = string.Format("Attendance {1} {0}", 
                    ServiceEmployee.GetEmployeeNameByID(this.EmployeeID), 
                    AttendanceMonth.ToString("MMMM yyyy"));

                lblTotalDays.Text = lblNonWorkingDays.Text = lblPaidDays.Text = string.Empty;
                lblPL.Text = lblCL.Text = lblSL.Text = lblCompOff.Text = string.Empty;
                lblPresent.Text = lblAbsent.Text = lblOutdoor.Text = lblLateComing.Text = lblEarlyLeaving.Text = string.Empty;

                MODEL = (new ServiceAttendance()).GetAttendanceSummaryOfEmployeeForMonth(this.EmployeeID, this.AttendanceMonth);
                if (MODEL != null)
                {
                    lblTotalDays.Text = MODEL.TotalDays.Text;
                    lblNonWorkingDays.Text = MODEL.NonWorkingDays.Text;
                    lblPaidDays.Text = MODEL.PaidDays.Text;
                    if (MODEL.PaidDays.Days > MODEL.TotalDays.Days)
                    {
                        lblPaidDays.Text = MODEL.TotalDays.Text;
                    }
                    lblPL.Text = MODEL.PLs.Text;
                    lblCL.Text = MODEL.CLs.Text;
                    lblSL.Text = MODEL.SLs.Text;
                    lblCompOff.Text = MODEL.CompOffs.Text;
                    lblPresent.Text = MODEL.Present.Text;
                    lblAbsent.Text = MODEL.Absent.Text;
                    lblOutdoor.Text = MODEL.Outdoor.Text;
                    lblLateComing.Text = MODEL.LateComings.Text;
                    lblEarlyLeaving.Text = MODEL.EarlyGoings.Text;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAttendanceSummary::PrepareCalendarSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
