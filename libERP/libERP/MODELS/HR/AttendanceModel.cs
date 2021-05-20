using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
    public class ListItemModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    public class OfficeAttendanceModel
    {
        public DateTime AttendanceDate { get; set; }
        public int EmployeeIDSmartOffice { get; set; }
        public int EmployeeIDExcelERP { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string AttendanceInTime { get; set; }
        public string AttendanceOutTime { get; set; }
        public string Duration { get; set; }
    }

    public class OnSiteAttendanceModel
    {
        public DateTime AttendanceDate { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendanceInTime { get; set; }
        public DateTime AttendanceOutTime { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public ATTENDANCE_TYPE AttendanceType { get; set; }
        public string Remarks { get; set; }
        public bool AtWarehouse { get; set; }
        public int LeaveApplicationID { get; set; }

        public OnSiteAttendanceModel() { this.AttendanceType = ATTENDANCE_TYPE.NONE; }
    }

    public class AttendanceRegisterItemModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeDescription { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string AttendanceNote { get; set; }
        public ATTENDANCE_TYPE AttendanceType { get; set; }
    }

    public class AttendanceRegisterModel
    {
        public DataTable  AttendanceTable { get; set; }
        public List<AttendanceRegisterItemModel> AttendanceLog { get; set; }
        public AttendanceRegisterModel()
        {
            this.AttendanceTable = new DataTable();
            this.AttendanceLog = new List<AttendanceRegisterItemModel>();
        }
    }

    public class DailyAttendanceRecordModel
    {
        public int AttendanceID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string EmployeeDescription { get; set; }
        public DateTime AttendanceInTime { get; set; }
        public DateTime AttendanceOutTime { get; set; }
        public string Duration { get; set; }
        public string ProjectDescription { get; set; }
        public string SearchText { get { return string.Format("{0} {1} {2} ", this.AttendanceDate.ToString("dd MMM yyyy"), this.EmployeeDescription, this.ProjectDescription); } }

    }

    public class DuplicateAttendaceModel
    {
        public DateTime AttendanceDate { get; set; }
        public int EmployeeID { get; set; }
        public int TotalRecords { get; set; }
    }

    public class EmployeeAttendanceSummaryModel
    {
        public TimeDuration TotalDays { get; set; }
        public TimeDuration NonWorkingDays { get; set; }
        public TimeDuration PaidDays { get; set; }
        public TimeDuration Present { get; set; }
        public TimeDuration Absent { get; set; }
        public TimeDuration Outdoor { get; set; }
        public TimeDuration PLs { get; set; }
        public TimeDuration CLs { get; set; }
        public TimeDuration SLs { get; set; }
        public TimeDuration CompOffs { get; set; }
        public TimeDuration LateComings { get; set; }
        public TimeDuration EarlyGoings { get; set; }
        public TimeDuration SandwichLeaves { get; set; }
        public decimal TotalLeaves { get { return  PLs.Days + CLs.Days + SLs.Days + CompOffs.Days; } }

        //  public TimeDuration SandwichLeaves { get; set; }

        public EmployeeAttendanceSummaryModel()
        {
            TotalDays = new TimeDuration();
            NonWorkingDays = new TimeDuration();
            PaidDays = new TimeDuration();
            Present = new TimeDuration();
            Absent = new TimeDuration();
            Outdoor = new TimeDuration();
            PLs = new TimeDuration();
            CLs = new TimeDuration();
            SLs = new TimeDuration();
            CompOffs = new TimeDuration();
            LateComings = new TimeDuration();
            EarlyGoings = new TimeDuration();
            SandwichLeaves = new TimeDuration();

    }

    }

    public class AttendanceGridViewModel
    {
        public int AttendanceID { get; set; }
        public DateTime AttendDate { get; set; }
        public ATTENDANCE_TYPE AttendanceType { get; set; }
        public int FK_EmployeeID { get; set; }
        public string EmployeeDescription { get; set; }
        public DateTime AttendInTime { get; set; }
        public DateTime AttendOutTime { get; set; }
        public string Duration { get; set; }
        public string AttendanceRemarks { get; set; }
        public string ProjectName { get; set; }
        public string PreparedBy { get; set; }
        public string ApprovedBy { get; set; }
        public bool AtWarehouse { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ApprovalStatus { get; set; }
        public bool SelectedAttendance { get; set; }

        public string SearchString { get { return string.Format("{0} {1} {2} {3} {4}",AttendDate.ToString("dd MMM"),  EmployeeDescription, this.AttendanceRemarks.ToUpper(), this.ProjectName, this.PreparedBy); } }

    }

    public class MonthlyAttendanceSummaryModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDescription { get; set; }
        public string TotalDays { get; set; }
        public string NonWorkingDays { get; set; }
        public string PaidDays { get; set; }
        public string Present { get; set; }
        public string Absent { get; set; }
        public string Outdoor { get; set; }
        public string PLs { get; set; }
        public string CLs { get; set; }
        public string SLs { get; set; }
        public string CompOffs { get; set; }
        public string LateComings { get; set; }
        public string EarlyGoings { get; set; }
        public string SandwichLeaves { get; set; }
        public string SearchText { get { return string.Format("{0} ", this.EmployeeName); } }

    }

}
