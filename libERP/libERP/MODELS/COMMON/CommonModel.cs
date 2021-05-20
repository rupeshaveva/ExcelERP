using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.MODELS
{
    public class AttendanceColorModel
    {
        public ATTENDANCE_TYPE TypeAttendance { get; set; }
        public Color ColorAttendance { get; set; }
    }
    public class SelectListItem
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DescriptionToUpper { get { return (this.Description!=null) ? Description.ToUpper()+ " "+ this.Code : string.Empty; } set { } }
        public bool IsActive { get; set; }
    }

    public class MultiSelectListItem
    {
        public bool Selected { get; set; }
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DescriptionToUpper { get { return (this.Description != null) ? Description.ToUpper() : string.Empty; } set { } }
        public  APP_ENTITIES EntityType { get; set; }
    }

    // 10days4hrs
    public class TimeDuration
    {
        public int Days { get; set; }//int
        public int Hours { get; set; }
        public int Mins { get; set; }
        public string Text { get { return string.Format("{0:00}:{1:00}:{2:00}", this.Days, this.Hours,this.Mins); } }
        public TimeDuration() { Days = 0; Hours = 0;Mins = 0; }
        public TimeDuration(int d, int h,int m) { Days = d; Hours = h;Mins = m; }
        public TimeDuration(string duration)
        {
            try
            {
                string[] arr = duration.Split(':');
                this.Days = int.Parse(arr[0]);
                this.Hours = int.Parse(arr[1]);
                this.Mins = int.Parse(arr[2]);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "TimeDuration::TimeDuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    
}
