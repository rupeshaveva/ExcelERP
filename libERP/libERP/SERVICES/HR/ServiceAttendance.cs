
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.PMC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{   
    public class ServiceAttendance: DefaultService
    {
        public event ImportAttendanceRecordStartEventHandler OnImportRecordProcessStart;
        public event ImportAttendanceRecordEndEventHandler OnImportRecordProcessEnd;

        public string COL_EMPID = "EMP_ID";
        public string COL_EMPDESCRIPTION = "EMP_DESCRITPION";
        private string connSmartOffice = "Data Source=192.168.1.250;Initial Catalog=SmartOffice;User ID=sa;Password=ADMin@4321!";

        #region ATTENDANCE SUMMARY DATA COLUMNS
        public string COL_EMP_ID { get { return "EmpID"; } }
        public string COL_EMP_NAME { get { return "EmpName"; } }
        public string COL_TotalDays { get { return "TotalDays"; } }
        public string COL_OffDays { get { return "OffDays"; } }
        public string COL_PaidDays { get { return "PaidDays"; } }
        public string COL_PresentDays { get { return "PresentDays"; } }
        public string COL_PLDays { get { return "PLDays"; } }
        public string COL_CLDays { get { return "CLDays"; } }
        public string COL_SLDays { get { return "SLDays"; } }
        public string COL_OutDoorDays { get { return "OutDoorDays"; } }
        public string COL_CompOffDays { get { return "CompOffDays"; } }
        public string COL_LateComingDays { get { return "LateComingDays"; } }
        public string COL_EarlyLeavingDays { get { return "EarlyLeavingDays"; } }
        public string COL_AbsentDays { get { return "AbsentDays"; } }

        #endregion

        public ServiceAttendance(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceAttendance()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        
        public int GetFinancialYearID(DateTime currDate)
        {
            int yearID = 0;
            try
            {
                string str = string.Format("select pk_ID from tbl_Acct_Financial_Year where '{0}' between fromdate and todate ", currDate.ToString("yyyy-MM-dd"));
                yearID = _dbContext.Database.SqlQuery<int>(str).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetFinancialYearID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return yearID;

        }

        #region SYNC OFFICE EMPLOYEE ATTENDANCE FROM SMARTOFFICE
        public BindingList<OfficeAttendanceModel> GetAllAttendanceFromSmartOfficeInDateRange(DateTime dtStart, DateTime dtEnd)
        {
            BindingList<OfficeAttendanceModel> lst = new BindingList<OfficeAttendanceModel>();
            string strSQL = string.Empty;
            string strTableName = string.Empty;
            try
            {
                strTableName = string.Format("[AttendanceLogs_{0}_{1}]", dtStart.Month, dtStart.Year);
                strSQL = string.Format("select B.EmployeeCode,upper(B.EmployeeName),A.*  from {0} A LEFT JOIN Employees B ON A.EmployeeId = B.EmployeeId where (A.AttendanceDate >='{1}' AND A.AttendanceDate<='{2}') ",
                                    strTableName, dtStart.ToString("yyyy-MM-dd"), dtEnd.ToString("yyyy-MM-dd"));
            using (SqlConnection connection = new SqlConnection(connSmartOffice))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(strSQL, connection))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader.GetDouble(9) > 0)
                                {
                                    OfficeAttendanceModel model = new OfficeAttendanceModel();
                                    model.EmployeeCode = reader.GetString(0);
                                    model.EmployeeName = reader.GetString(1);
                                    model.AttendanceDate = (DateTime)reader.GetSqlDateTime(3);
                                    model.EmployeeIDSmartOffice = reader.GetInt32(4);
                                    model.AttendanceInTime = reader.GetString(5);
                                    model.AttendanceOutTime = reader.GetString(7);
                                    model.Duration= AppCommon.GetDurationBetweenDates(DateTime.Parse(model.AttendanceOutTime),DateTime.Parse(model.AttendanceInTime));
                                    lst.Add(model);
                                }
                            }
                        }
                        reader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAllAttendanceFromSmartOfficeInDateRange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public int PostOfficeAttendanceRecordsToExcelERP(BindingList<OfficeAttendanceModel> listAttendance,int PrepareBy)
        {
            TBL_MP_Master_Employee emp = null;
            string strMessage = string.Empty;
            int mCount = 0;
            try
            {
                foreach (OfficeAttendanceModel model in listAttendance)
                {
                    emp = _dbContext.TBL_MP_Master_Employee.Where(x => x.EmployeeCode == model.EmployeeCode).FirstOrDefault();
                    if (OnImportRecordProcessStart != null)
                    {
                        strMessage = string.Format("Processing {0} {1}\n", model.AttendanceDate.ToString("dd MMM yyyy"), model.Duration);
                        if(emp==null)
                            strMessage += string.Format("Unable to Locate Employee {0}", model.EmployeeCode);
                        else
                            strMessage += string.Format("Found Employee {0}", model.EmployeeCode);

                        OnImportRecordProcessStart(this, new EventArguementModel() { Message = strMessage });
                        if(emp==null) System.Threading.Thread.Sleep(2000);
                    }
                    if (emp != null)
                    {
                        TBL_MP_HR_ManualAttendance_Master dbRec = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                   where xx.FK_EmployeeID == emp.PK_EmployeeId && xx.AttendDate == model.AttendanceDate
                                                                   select xx).FirstOrDefault();
                        if (dbRec == null)
                        {
                            TBL_MP_HR_ManualAttendance_Master newRecord = new TBL_MP_HR_ManualAttendance_Master();
                            newRecord.IsActive = true;
                            newRecord.FK_EmployeeID = emp.PK_EmployeeId;
                            newRecord.AttendStdInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                            newRecord.AttendStdOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                            newRecord.AttendDate = model.AttendanceDate;
                            newRecord.FK_CostCenterId = null;
                            string[] arrTime = model.AttendanceInTime.Split(':');
                            newRecord.AttendInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            arrTime = model.AttendanceOutTime.Split(':');
                            newRecord.AttendOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            //newRecord.Duration = model.Duration;
                            newRecord.Duration = "08:30:00";
                            newRecord.FK_BranchId = emp.FK_BranchID;
                            newRecord.FK_YearId = this.GetFinancialYearID(model.AttendanceDate);
                            newRecord.FK_CompanyId = emp.FK_CompanyID;
                            newRecord.FK_PreparedBy = PrepareBy;
                            newRecord.LastModifiedBy = PrepareBy;
                            newRecord.CreatedDateTime = DateTime.Now;
                            newRecord.LastModifiedDate = DateTime.Now;
                            newRecord.AttendanceRemarks = "Office";
                            newRecord.AttendanceType = (int)ATTENDANCE_TYPE.PRESENT;
                            _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(newRecord);
                            _dbContext.SaveChanges();
                            mCount++;
                            if (OnImportRecordProcessEnd != null)
                            {
                                strMessage = string.Format("ID {0}\n Import Suceeded", newRecord.PK_AttendanceID);
                                OnImportRecordProcessEnd(this, new EventArguementModel() { Message = strMessage });
                            }

                        }

                    }

                    //if attendance type =LEAVE
                    if (emp != null)
                    {
                        TBL_MP_HR_ManualAttendance_Master dbRec = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                   where xx.FK_EmployeeID == emp.PK_EmployeeId && xx.AttendDate == model.AttendanceDate && xx.AttendanceType==3
                                                                   select xx).FirstOrDefault();
                        if (dbRec != null)
                        {
                            TBL_MP_HR_ManualAttendance_Master newRecord = new TBL_MP_HR_ManualAttendance_Master();
                            newRecord.IsActive = true;
                            newRecord.FK_EmployeeID = emp.PK_EmployeeId;
                            newRecord.AttendStdInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                            newRecord.AttendStdOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                            newRecord.AttendDate = model.AttendanceDate;
                            newRecord.FK_CostCenterId = null;
                            string[] arrTime = model.AttendanceInTime.Split(':');
                            newRecord.AttendInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            arrTime = model.AttendanceOutTime.Split(':');
                            newRecord.AttendOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            //newRecord.Duration = model.Duration;
                            newRecord.Duration = "08:30:00";
                            newRecord.FK_BranchId = emp.FK_BranchID;
                            newRecord.FK_YearId = this.GetFinancialYearID(model.AttendanceDate);
                            newRecord.FK_CompanyId = emp.FK_CompanyID;
                            newRecord.FK_PreparedBy = PrepareBy;
                            newRecord.LastModifiedBy = PrepareBy;
                            newRecord.CreatedDateTime = DateTime.Now;
                            newRecord.LastModifiedDate = DateTime.Now;
                            newRecord.AttendanceRemarks = "Office";
                            newRecord.AttendanceType = (int)ATTENDANCE_TYPE.PRESENT;
                            _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(newRecord);
                            _dbContext.SaveChanges();
                            mCount++;
                            if (OnImportRecordProcessEnd != null)
                            {
                                strMessage = string.Format("ID {0}\n Import Suceeded", newRecord.PK_AttendanceID);
                                OnImportRecordProcessEnd(this, new EventArguementModel() { Message = strMessage });
                            }

                        }

                    }

                    //if attendance type=outdoor
                    if (emp != null)
                    {
                        TBL_MP_HR_ManualAttendance_Master dbRec = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                   where xx.FK_EmployeeID == emp.PK_EmployeeId && xx.AttendDate == model.AttendanceDate && xx.AttendanceType == 4
                                                                   select xx).FirstOrDefault();
                        if (dbRec != null)
                        {
                            TBL_MP_HR_ManualAttendance_Master newRecord = new TBL_MP_HR_ManualAttendance_Master();
                            newRecord.IsActive = true;
                            newRecord.FK_EmployeeID = emp.PK_EmployeeId;
                            newRecord.AttendStdInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                            newRecord.AttendStdOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                            newRecord.AttendDate = model.AttendanceDate;
                            newRecord.FK_CostCenterId = null;
                            string[] arrTime = model.AttendanceInTime.Split(':');
                            newRecord.AttendInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            arrTime = model.AttendanceOutTime.Split(':');
                            newRecord.AttendOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            //newRecord.Duration = model.Duration;
                            newRecord.Duration = "08:30:00";
                            newRecord.FK_BranchId = emp.FK_BranchID;
                            newRecord.FK_YearId = this.GetFinancialYearID(model.AttendanceDate);
                            newRecord.FK_CompanyId = emp.FK_CompanyID;
                            newRecord.FK_PreparedBy = PrepareBy;
                            newRecord.LastModifiedBy = PrepareBy;
                            newRecord.CreatedDateTime = DateTime.Now;
                            newRecord.LastModifiedDate = DateTime.Now;
                            newRecord.AttendanceRemarks = "Office";
                            newRecord.AttendanceType = (int)ATTENDANCE_TYPE.PRESENT;
                            _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(newRecord);
                            _dbContext.SaveChanges();
                            mCount++;
                            if (OnImportRecordProcessEnd != null)
                            {
                                strMessage = string.Format("ID {0}\n Import Suceeded", newRecord.PK_AttendanceID);
                                OnImportRecordProcessEnd(this, new EventArguementModel() { Message = strMessage });
                            }

                        }

                    }

                    //if attendance type=late coming
                    if (emp != null)
                    {
                        TBL_MP_HR_ManualAttendance_Master dbRec = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                   where xx.FK_EmployeeID == emp.PK_EmployeeId && xx.AttendDate == model.AttendanceDate && xx.AttendanceType == 10
                                                                   select xx).FirstOrDefault();
                        if (dbRec != null)
                        {
                            TBL_MP_HR_ManualAttendance_Master newRecord = new TBL_MP_HR_ManualAttendance_Master();
                            newRecord.IsActive = true;
                            newRecord.FK_EmployeeID = emp.PK_EmployeeId;
                            newRecord.AttendStdInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                            newRecord.AttendStdOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                            newRecord.AttendDate = model.AttendanceDate;
                            newRecord.FK_CostCenterId = null;
                            string[] arrTime = model.AttendanceInTime.Split(':');
                            newRecord.AttendInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            arrTime = model.AttendanceOutTime.Split(':');
                            newRecord.AttendOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            //newRecord.Duration = model.Duration;
                            newRecord.Duration = "08:30:00";
                            newRecord.FK_BranchId = emp.FK_BranchID;
                            newRecord.FK_YearId = this.GetFinancialYearID(model.AttendanceDate);
                            newRecord.FK_CompanyId = emp.FK_CompanyID;
                            newRecord.FK_PreparedBy = PrepareBy;
                            newRecord.LastModifiedBy = PrepareBy;
                            newRecord.CreatedDateTime = DateTime.Now;
                            newRecord.LastModifiedDate = DateTime.Now;
                            newRecord.AttendanceRemarks = "Office";
                            newRecord.AttendanceType = (int)ATTENDANCE_TYPE.PRESENT;
                            _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(newRecord);
                            _dbContext.SaveChanges();
                            mCount++;
                            if (OnImportRecordProcessEnd != null)
                            {
                                strMessage = string.Format("ID {0}\n Import Suceeded", newRecord.PK_AttendanceID);
                                OnImportRecordProcessEnd(this, new EventArguementModel() { Message = strMessage });
                            }

                        }

                    }

                    //if attendance type=early going
                    if (emp != null)
                    {
                        TBL_MP_HR_ManualAttendance_Master dbRec = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                   where xx.FK_EmployeeID == emp.PK_EmployeeId && xx.AttendDate == model.AttendanceDate && xx.AttendanceType == 11
                                                                   select xx).FirstOrDefault();
                        if (dbRec != null)
                        {
                            TBL_MP_HR_ManualAttendance_Master newRecord = new TBL_MP_HR_ManualAttendance_Master();
                            newRecord.IsActive = true;
                            newRecord.FK_EmployeeID = emp.PK_EmployeeId;
                            newRecord.AttendStdInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 8, 45, 0);
                            newRecord.AttendStdOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, 17, 15, 0);
                            newRecord.AttendDate = model.AttendanceDate;
                            newRecord.FK_CostCenterId = null;
                            string[] arrTime = model.AttendanceInTime.Split(':');
                            newRecord.AttendInTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            arrTime = model.AttendanceOutTime.Split(':');
                            newRecord.AttendOutTime = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day, int.Parse(arrTime[0]), int.Parse(arrTime[1]), 0);
                            //newRecord.Duration = model.Duration;
                            newRecord.Duration = "08:30:00";
                            newRecord.FK_BranchId = emp.FK_BranchID;
                            newRecord.FK_YearId = this.GetFinancialYearID(model.AttendanceDate);
                            newRecord.FK_CompanyId = emp.FK_CompanyID;
                            newRecord.FK_PreparedBy = PrepareBy;
                            newRecord.LastModifiedBy = PrepareBy;
                            newRecord.CreatedDateTime = DateTime.Now;
                            newRecord.LastModifiedDate = DateTime.Now;
                            newRecord.AttendanceRemarks = "Office";
                            newRecord.AttendanceType = (int)ATTENDANCE_TYPE.PRESENT;
                            _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(newRecord);
                            _dbContext.SaveChanges();
                            mCount++;
                            if (OnImportRecordProcessEnd != null)
                            {
                                strMessage = string.Format("ID {0}\n Import Suceeded", newRecord.PK_AttendanceID);
                                OnImportRecordProcessEnd(this, new EventArguementModel() { Message = strMessage });
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //string errMessage = string.Format("{0} ({1})\n{2}",emp.EmployeeName,emp.EmployeeCode, ex.Message);
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::PostAttendanceRecordsToExcelERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return mCount;
        }
        #endregion

        #region SYNC ON-SITE EMPLOYEE ATTENDANCE
        public BindingList<OnSiteAttendanceModel> GetOnSiteAttendanceSheetForDate(DateTime attDate)
        {
            BindingList<OnSiteAttendanceModel> lst = new BindingList<OnSiteAttendanceModel>();
            
            string strTableName = string.Empty;
            try
            {
                APP_DEFAULTS dbItem = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EMPLOYEE_CATEGORY_ON_SITE).FirstOrDefault();
                if (dbItem == null)
                {
                    MessageBox.Show("value of EMPLOYEE_CATEGORY_ON_SITE is not defined in APP_DEFAULTS","Contact Administrator");
                    return new BindingList<OnSiteAttendanceModel>(); ;
                }
                int OnSiteCategory = dbItem.DEFAULT_VALUE; 
                List<TBL_MP_Master_Employee> lstEMP = (from xx in _dbContext.TBL_MP_Master_Employee
                                                       where xx.isActive == true && xx.fk_UL_Cat_Id == OnSiteCategory 
                                                       orderby xx.EmployeeName 
                                                       select xx).ToList();
                foreach (TBL_MP_Master_Employee emp in lstEMP)
                {
                    OnSiteAttendanceModel model = new OnSiteAttendanceModel();
                    model.AttendanceDate = attDate;
                    model.EmployeeID = emp.PK_EmployeeId;
                    model.EmployeeCode = emp.EmployeeCode;
                    model.EmployeeName = emp.EmployeeName;
                    model.AttendanceType = ATTENDANCE_TYPE.PRESENT;
                    model.Remarks = "OnSite";
                    model.AttendanceInTime = new DateTime(attDate.Year,attDate.Month,attDate.Day,8,45,0);
                    model.AttendanceOutTime = new DateTime(attDate.Year, attDate.Month, attDate.Day, 17, 15, 0); ;
                    int mProjectID= GetLatestProjectIDForEmployee(emp.PK_EmployeeId, attDate);
                    if (mProjectID != 0)
                    {
                        model.ProjectID = mProjectID;
                        model.ProjectName = (new ServiceProject()).GetProjectDBInfoByID(mProjectID).ProjectName;
                    }

                    TBL_MP_HR_ManualAttendance_Master attendanceRecord = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                          where xx.FK_EmployeeID == emp.PK_EmployeeId && xx.AttendDate == attDate.Date
                                                                          select xx).FirstOrDefault();
                    if (attendanceRecord != null)
                    {
                        model.AttendanceType =(ATTENDANCE_TYPE)attendanceRecord.AttendanceType;
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
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetOnSiteAttendanceSheetForDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<int> GetEmployeeIDsWhoHaveAttendendaceForProject(int projectID)
        {
            List<int> empIDs = new List<int>();
            try
            {
                string strSQL = string.Format("SELECT DISTINCT FK_EmployeeID from TBL_MP_HR_ManualAttendance_Master where FK_CostCenterId = {0}", projectID);
                empIDs = _dbContext.Database.SqlQuery<int>(strSQL).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetEmployeeIDsWhoHaveAttendendaceForProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return empIDs;
        }
        private int GetLatestProjectIDForEmployee(int empID,DateTime attDate)
        {
            int projectID = 0;
            try
            {
                TBL_MP_HR_ManualAttendance_Master latestRecord = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                  where xx.FK_EmployeeID == empID && xx.AttendDate < attDate
                                                                  orderby xx.AttendDate descending
                                                                  select xx
                                                                ).FirstOrDefault();
                if (latestRecord != null)
                {
                    if(latestRecord.FK_CostCenterId!=null)
                    {
                        projectID = (int)latestRecord.FK_CostCenterId;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetLatestProjectIDForEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return projectID;
        }
        public void PostOnSiteAttendanceRecordsToExcelERP(BindingList<OnSiteAttendanceModel> listAttendance, int PrepareBy,bool AttendType)
        {
            try
            {
                foreach (OnSiteAttendanceModel model in listAttendance)
                {
                    TBL_MP_Master_Employee emp = _dbContext.TBL_MP_Master_Employee.Where(x => x.EmployeeCode == model.EmployeeCode).FirstOrDefault();
                    if (emp != null)
                    {
                        
                        TBL_MP_HR_ManualAttendance_Master dbRec = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                   where    xx.FK_EmployeeID == emp.PK_EmployeeId && 
                                                                            xx.AttendDate == model.AttendanceDate.Date &&
                                                                            xx.AttendanceType == (int)model.AttendanceType
                                                                   select xx).FirstOrDefault();
                        if (dbRec == null)
                        {
                            TBL_MP_HR_ManualAttendance_Master newRecord = new TBL_MP_HR_ManualAttendance_Master();
                            
                            newRecord.IsActive = true;

                            newRecord.FK_EmployeeID = emp.PK_EmployeeId;
                            DateTime dayStart = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day);
                            DateTime dayEnd = new DateTime(model.AttendanceDate.Year, model.AttendanceDate.Month, model.AttendanceDate.Day);
                            AppCommon.SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                            newRecord.AttendStdInTime = dayStart;
                            newRecord.AttendStdOutTime = dayEnd;

                            newRecord.AttendDate = model.AttendanceDate.Date;
                            newRecord.AttendInTime = model.AttendanceInTime;
                            newRecord.AttendOutTime = model.AttendanceOutTime;
                            if (model.ProjectID != 0)
                                newRecord.FK_CostCenterId = model.ProjectID;
                            else
                                newRecord.FK_CostCenterId = null;
                            newRecord.Duration = AppCommon.GetDurationBetweenDates(newRecord.AttendOutTime,newRecord.AttendInTime);
                            newRecord.FK_BranchId = emp.FK_BranchID;
                            newRecord.FK_YearId = this.GetFinancialYearID(model.AttendanceDate);
                            newRecord.FK_CompanyId = 1;
                            newRecord.FK_PreparedBy = PrepareBy;
                            newRecord.LastModifiedBy = PrepareBy;
                            newRecord.CreatedDateTime = DateTime.Now;
                            newRecord.LastModifiedDate = DateTime.Now;
                            newRecord.AttendanceRemarks = model.Remarks;
                            newRecord.AttendanceType = (int)model.AttendanceType;
                            if (newRecord.AttendanceType == 1 || newRecord.AttendanceType == 2)
                            {
                                newRecord.FK_LeaveApplicationID = model.LeaveApplicationID;
                                newRecord.AtWarehouse = model.AtWarehouse;
                                _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(newRecord);
                                _dbContext.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::PostOnSiteAttendanceRecordsToExcelERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region MONTHLY ATTENDANCE
        public DataTable GetAttendanceDatatableForEntireMonth(DateTime fromDate)
        {
            DataTable AttendanceTable = null;
            DataRow currRow = null;
            try
            {
                AttendanceTable = new DataTable();
                AttendanceTable.Columns.Add(new DataColumn() { ColumnName = COL_EMPID, DataType = typeof(int) });
                AttendanceTable.Columns.Add(new DataColumn() { ColumnName = COL_EMPDESCRIPTION, DataType = typeof(string) });

                int mYear = fromDate.Year;
                int mMonth = fromDate.Month;
                int noOfdays = DateTime.DaysInMonth(mYear, mMonth);
                DateTime startDate = new DateTime(mYear, mMonth, 1);
                DateTime endDate = startDate.AddDays(noOfdays-1);
                for (int I = 1; I <= noOfdays; I++)
                {
                    DateTime currDate = new DateTime(mYear, mMonth, I);
                    AttendanceTable.Columns.Add(new DataColumn() {
                        ColumnName = I.ToString(),
                        Caption =string.Format("{0}\n{1}", I, currDate.DayOfWeek.ToString().Substring(0,3)),
                        DataType = typeof(string)
                    });

                }

                DataView dataview = AttendanceTable.DefaultView;
                dataview.Sort = COL_EMPDESCRIPTION;
                AttendanceTable = dataview.ToTable();

                // 1. FILL ATTENDANCE INTO DATABALE & ADD TO LOG
                List<TBL_MP_HR_ManualAttendance_Master> lst = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master where xx.AttendDate >= startDate && xx.AttendDate <= endDate select xx).ToList();
                foreach (TBL_MP_HR_ManualAttendance_Master item in lst)
                {
                    string strExpr = string.Format("[{0}]={1}", COL_EMPID, item.FK_EmployeeID);
                    DataRow[] result = AttendanceTable.Select(strExpr);
                    if (result.Count() == 0)
                    {
                        EmployeeGeneralInfoModel emp = (new ServiceEmployee()).GetEmployeeGeneralInfo(item.FK_EmployeeID);
                        DataRow newRow = AttendanceTable.NewRow();
                        newRow[COL_EMPID] = emp.EmployeeID;
                        newRow[COL_EMPDESCRIPTION] = string.Format("{0}\n{1}, {2}", emp.EmployeeFullName, emp.DesignationInfo.Description, emp.DepartmentInfo.Description);
                        AttendanceTable.Rows.Add(newRow);
                        currRow = newRow;
                    }
                    else
                        currRow = result[0];

                    currRow[item.AttendDate.Day.ToString()] = string.Format("[P]\n{0} {1}\n", item.AttendInTime.ToString("hh:mm"), item.AttendOutTime.ToString("hh:mm"));
                }


                //2. FILL ALL LEAVE TAKEN BY EMLPOYEES WITH GIVEN DATES

                // 3. FILL ALL WEAK-OFFS & HOLIDAYS WITHIN GIVEN DATES
                List<TBL_MP_HR_HolidaysAndWeekOff> lstHolidayWeekOffs = (from xx in _dbContext.TBL_MP_HR_HolidaysAndWeekOff where xx.HolidayDate >= startDate && xx.HolidayDate<= endDate select xx).ToList();
                foreach (TBL_MP_HR_HolidaysAndWeekOff item in lstHolidayWeekOffs)
                {
                    string strCaption = AttendanceTable.Columns[item.HolidayDate.Day.ToString()].Caption;
                    switch ((ATTENDANCE_TYPE)item.HolidayType)
                    {
                        case ATTENDANCE_TYPE.WEEK_OFF:
                            AttendanceTable.Columns[item.HolidayDate.Day.ToString()].Caption = string.Format("[W]\n{0}", strCaption);
                            break;
                        case ATTENDANCE_TYPE.HOLIDAY:
                            AttendanceTable.Columns[item.HolidayDate.Day.ToString()].Caption = string.Format("[H]\n{0}", strCaption);
                            break;
                    }
                    
                    //int stIndex = 0;
                    //int endIndex = item.Remarks.Trim().Length;
                    //foreach (DataRow mRow in AttendanceTable.Rows)
                    //{
                    //    if (stIndex < endIndex)
                    //    {
                    //        mRow[item.HolidayDate.Day.ToString()] = string.Format("{0}", item.Remarks.Substring(stIndex++, 1).ToUpper());
                    //    } 
                    //}
                }


                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceDatatableForEntireMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return AttendanceTable;
        }
        public List<DailyAttendanceRecordModel> GetAttendanceRecordModelListForEntireMonth(DateTime mDate)
        {
            List<DailyAttendanceRecordModel> list = new List<DailyAttendanceRecordModel>();
            try
            {
                DateTime fromDate = new DateTime(mDate.Year, mDate.Month, 1);
                DateTime toDate = new DateTime(mDate.Year, mDate.Month, DateTime.DaysInMonth(mDate.Year, mDate.Month));

                List<TBL_MP_HR_ManualAttendance_Master> lst = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master where xx.AttendDate >= fromDate && xx.AttendDate <= toDate orderby xx.AttendDate  select xx).ToList();
                foreach (TBL_MP_HR_ManualAttendance_Master item in lst)
                {
                    DailyAttendanceRecordModel model = new DailyAttendanceRecordModel();
                    model.AttendanceID = item.PK_AttendanceID;
                    model.AttendanceDate = item.AttendDate;
                    model.AttendanceInTime = item.AttendInTime;
                    model.AttendanceOutTime = item.AttendOutTime;
                    model.Duration = item.Duration;
                    if (item.FK_EmployeeID != 0)
                    {
                        model.EmployeeDescription = string.Format("{0} ({1})", item.TBL_MP_Master_Employee.EmployeeName, item.TBL_MP_Master_Employee.EmployeeCode);
                    }
                    if (item.FK_CostCenterId != null)
                    {
                        model.ProjectDescription = string.Format("{0} ({1})", item.TBL_MP_PMC_ProjectMaster.ProjectName, item.TBL_MP_PMC_ProjectMaster.ProjectNumber);
                    }

                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance:: GetAttendanceRecordModelListForEntireMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        #endregion


        #region MANNUAL ATTENDANCE
        public TBL_MP_HR_ManualAttendance_Master GetAttendanceInfoDbRecordByID(int AttendeID)
        {
            TBL_MP_HR_ManualAttendance_Master model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_ManualAttendance_Master.Where(x => x.PK_AttendanceID == AttendeID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceInfoDbRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewManualAttendance(TBL_MP_HR_ManualAttendance_Master model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_HR_ManualAttendance_Master.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_AttendanceID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::AddNewManualAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateMannualAttendance(TBL_MP_HR_ManualAttendance_Master model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_ManualAttendance_Master dbModel = _dbContext.TBL_MP_HR_ManualAttendance_Master.Where(x => x.PK_AttendanceID == model.PK_AttendanceID).FirstOrDefault();

                dbModel.AttendDate = model.AttendDate;
                dbModel.FK_EmployeeID = model.FK_EmployeeID;
                dbModel.FK_CostCenterId = model.FK_CostCenterId;
                dbModel.AttendInTime = model.AttendInTime;
                dbModel.AttendOutTime = model.AttendOutTime;
                dbModel.Duration= model.Duration;
               
                dbModel.IsActive = model.IsActive;
                dbModel.FK_YearId = model.FK_YearId;
                dbModel.FK_BranchId = model.FK_BranchId;

                _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::UpdateMannualAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public bool DeleteMannualAttendance(int AttendID)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_ManualAttendance_Master dbModel = _dbContext.TBL_MP_HR_ManualAttendance_Master.Where(x => x.PK_AttendanceID == AttendID).FirstOrDefault();
                if (dbModel != null)
                {

                    dbModel.IsActive = false;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::DeleteMannualAttendance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        public List<vAttendanceRegister> GetAttendanceInfoDbRecordsOfEmplyeeOnDate(int employeeID,DateTime attDate)
        {
            List<vAttendanceRegister> model = null;
            try
            {
                model =(from xx in _dbContext.vAttendanceRegisters 
                        where xx.FK_EmployeeID==employeeID && xx.AttendDate == attDate.Date select xx ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceInfoDbRecordOfEmplyeeOnDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public List<TBL_MP_HR_ManualAttendance_Master> GetAttendanceRecordOfEmployeeOnDate(int employeeID, DateTime attDate)
        {
            List<TBL_MP_HR_ManualAttendance_Master> lstRecords = new List<TBL_MP_HR_ManualAttendance_Master>();
            try
            {
                lstRecords = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master where xx.FK_EmployeeID == employeeID && xx.AttendDate == attDate.Date select xx).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceRecordOfEmployeeOnDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRecords;
        }
        public List<vAttendanceRegister> GetAttendanceRecordsBetweenDates(DateTime startDate,DateTime endDate)
        {
            List<vAttendanceRegister> dbList = new List<vAttendanceRegister>();
            try
            {
                dbList = (from xx in _dbContext.vAttendanceRegisters
                          where xx.AttendDate >= startDate && xx.AttendDate <= endDate
                          orderby xx.AttendDate, xx.FK_EmployeeID
                          select xx).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceRecordsForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbList;
        }
        public List<AttendanceGridViewModel> GetAttendanceRecordsForFilter(DateTime startDate, DateTime endDate, string categoryIDs,string projectIDs,string departmentIDs,string employeeIDs)
        {
            List<AttendanceGridViewModel> lstAttendance = new List<AttendanceGridViewModel>();
            try
            {
                string strQuery = string.Format("Select * from vAttendanceRegister WHERE (AttendDate BETWEEN '{0}' AND '{1}' ) AND(  ", startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                if (categoryIDs != string.Empty) strQuery += string.Format(" fk_UL_Cat_Id IN ({0}) OR", categoryIDs);
                if (projectIDs != string.Empty) strQuery += string.Format(" FK_CostCenterID IN ({0}) OR", projectIDs);
                if (departmentIDs != string.Empty) strQuery += string.Format(" FK_DepartmentID IN ({0}) OR", departmentIDs);
                if (employeeIDs != string.Empty) strQuery += string.Format(" FK_EmployeeID IN ({0}) OR", employeeIDs);

                if (strQuery.EndsWith("OR")) strQuery = strQuery.Substring(0, strQuery.Length - 2);
                strQuery += string.Format(") ORDER BY AttendDate,EmployeeDescription ");

                List<vAttendanceRegister>   dbList = _dbContext.Database.SqlQuery<vAttendanceRegister>(strQuery).ToList();
                foreach (vAttendanceRegister item in dbList)
                {
                    AttendanceGridViewModel model = new AttendanceGridViewModel();
                    model.AttendanceID = item.PK_AttendanceID;
                    model.ApprovedBy = item.ApprovedBy;
                    model.AttendDate = item.AttendDate;
                    model.AttendanceType = (ATTENDANCE_TYPE)item.AttendanceType;
                    model.AttendInTime = item.AttendInTime;
                    model.AttendOutTime = item.AttendOutTime;
                    model.AtWarehouse = item.AtWarehouse;
                    model.Duration = item.Duration;
                    model.EmployeeDescription = item.EmployeeDescription;
                    model.AttendanceRemarks = item.AttendanceRemarks;
                    model.ProjectName = item.ProjectName;
                    model.PreparedBy = item.PreparedBy;
                    model.FK_EmployeeID = item.FK_EmployeeID;
                    //   model.AttendanceID = item.PK_AttendanceID;
                    model.CreatedDateTime = item.CreatedDateTime;
                    model.ApprovalStatus = "\t\t\t\t\t\t--";
                    if (item.AttendanceType == 3 || item.AttendanceType == 4)
                    {
                        //  model.IsActive = item.IsActive
                        if (item.IsActive == true)
                            model.ApprovalStatus = "\tapproved";
                        else
                            model.ApprovalStatus = "\tunapproved";
                    }
                    lstAttendance.Add(model);
                }
            } 
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceRecordsForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttendance;
        }
        public List<SelectListItem> GetDistinctEmployeesListForMonthInAttendance(DateTime month)
        {
            List<SelectListItem> dbList = new List<SelectListItem>();
            try
            {
                DateTime startDate = new DateTime(month.Year, month.Month, 1);
                int days = DateTime.DaysInMonth(month.Year, month.Month);
                DateTime endDate = new DateTime(month.Year, month.Month, days);

                string strQuery = string.Format("select distinct FK_EmployeeID as ID,EmployeeDescription as Description from vAttendanceRegister where AttendDate between '{0}' AND '{1}' ORDER BY 2",
                    startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                dbList = _dbContext.Database.SqlQuery<SelectListItem>(strQuery).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceRecordsForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbList;
        }
        public List<DuplicateAttendaceModel> GetDuplicateAttendanceBetweenDates(DateTime startDate,DateTime endDate)
        {
            List<DuplicateAttendaceModel> lstDupicates = new List<DuplicateAttendaceModel>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select AttendDate as AttendanceDate,FK_EmployeeID as EmployeeID, count(*) as TotalRecords ");
                sb.Append("from vAttendanceRegister where Attenddate between '{0}' AND '{1}' ");
                sb.Append("group by AttendDate, FK_EmployeeID having count(*) > 1");
                string strQuery =string.Format(sb.ToString(),startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                lstDupicates = _dbContext.Database.SqlQuery<DuplicateAttendaceModel>(strQuery).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetDuplicateAttendanceForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstDupicates;
        }

        public void DeleteAttendanceAndItsLeave(int attendanceID)
        {
            try
            {
                TBL_MP_HR_ManualAttendance_Master dbRecord = _dbContext.TBL_MP_HR_ManualAttendance_Master.Where(x => x.PK_AttendanceID == attendanceID).FirstOrDefault();
                if (dbRecord != null)
                {
                    int leaveID = 0;
                    if (dbRecord.FK_LeaveTypeID != null)
                    {
                        leaveID = (int)dbRecord.FK_LeaveApplicationID;
                    }
                   // dbRecord.IsActive = false;
                    _dbContext.TBL_MP_HR_ManualAttendance_Master.Remove(dbRecord);
                    _dbContext.SaveChanges();
                    if (leaveID > 0)
                    {
                        TBL_MP_HR_LeaveApplication dbLeave = _dbContext.TBL_MP_HR_LeaveApplication.Where(x => x.PK_LeaveApplicationID == leaveID).FirstOrDefault();
                        if(dbLeave!=null)
                        {
                            dbLeave.IsDeleted = true;
                            //_dbContext.TBL_MP_HR_LeaveApplication.Remove(dbLeave);
                            _dbContext.SaveChanges();
                        }

                    }
                   ;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::DeleteAttendanceAndItsLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public EmployeeAttendanceSummaryModel GetAttendanceSummaryOfEmployeeForMonth(int empID, DateTime month)
        {
            TimeDuration mDuration = new TimeDuration();
            EmployeeAttendanceSummaryModel model = new EmployeeAttendanceSummaryModel();
            // convert durations into mins. and then perform calculations
            // each day woring duration in 08:30mins
            int TotalMinEachDay = (8 * 60) + 30;

            ServiceLeaveApplication serviceLeaves = new ServiceLeaveApplication();
            try
            {
                
                int leavePL_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_PL_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                int leaveCL_ID= _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_CL_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                int leaveSL_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_SL_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                int leaveCompOff_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_COMP_OFF_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;

                 int OutdoorFullShift_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.OUTDOOR_FULLSHIFT_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                 int OutdoorFirstHalf_ID= _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.OUTDOOR_FIRSTHALF_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                 int OutdoorSecondHalf_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.OUTDOOR_SECONDHALF_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;


                DateTime startDate = new DateTime(month.Year, month.Month, 1);
                int days = DateTime.DaysInMonth(month.Year, month.Month);
                DateTime endDate = new DateTime(month.Year, month.Month, days);
                model.TotalDays = new TimeDuration(days, 0, 0);
                // FIND NON-WORKING DAYS
                string strQuery = string.Format("select * from TBL_MP_HR_HolidaysAndWeekOff where HolidayDate between '{0}'  and '{1}'",
                                                startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                List<TBL_MP_HR_HolidaysAndWeekOff> dbOffDays = _dbContext.Database.SqlQuery<TBL_MP_HR_HolidaysAndWeekOff>(strQuery).ToList();
                int nonWorkingDays = 0;
                foreach (TBL_MP_HR_HolidaysAndWeekOff offDay in dbOffDays)
                {

                    if (AppCommon.isSecondSaturday(offDay.HolidayDate) || AppCommon.isFourthSaturday(offDay.HolidayDate))
                    {
                        if ((new ServiceEmployee()).IsWeekOffDayForEmployee("SATURDAY", empID))
                        {
                            nonWorkingDays++;
                        }
                    }
                    else
                    {
                        nonWorkingDays++;
                    }
                }
                foreach (TBL_MP_HR_HolidaysAndWeekOff offDay in dbOffDays)
                {
                    if (AppCommon.isSecondSaturday(offDay.HolidayDate) || AppCommon.isFourthSaturday(offDay.HolidayDate))
                    {
                        if ((new ServiceEmployee()).IsWeekOffDayForEmployee("SATURDAY", empID))
                        {
                            TBL_MP_HR_ManualAttendance_Master present = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                         where xx.FK_EmployeeID == empID && xx.AttendDate == offDay.HolidayDate && xx.AttendanceType == (int)ATTENDANCE_TYPE.PRESENT
                                                                         select xx).FirstOrDefault();
                            if (present != null) nonWorkingDays--;
                        }
                    }
                    else
                    {
                        TBL_MP_HR_ManualAttendance_Master present = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                     where xx.FK_EmployeeID == empID && xx.AttendDate == offDay.HolidayDate && xx.AttendanceType == (int)ATTENDANCE_TYPE.PRESENT

                                                                     select xx).FirstOrDefault();
                        if (present != null) nonWorkingDays--;
                    }

                    // if leave
                    if (AppCommon.isSecondSaturday(offDay.HolidayDate) || AppCommon.isFourthSaturday(offDay.HolidayDate))
                    {
                        if ((new ServiceEmployee()).IsWeekOffDayForEmployee("SATURDAY", empID))
                        {
                            TBL_MP_HR_ManualAttendance_Master present = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                         where xx.FK_EmployeeID == empID && xx.AttendDate == offDay.HolidayDate && xx.AttendanceType == (int)ATTENDANCE_TYPE.LEAVE
                                                                         select xx).FirstOrDefault();
                            if (present != null) nonWorkingDays--;
                        }
                    }
                    else
                    {
                        TBL_MP_HR_ManualAttendance_Master present = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                     where xx.FK_EmployeeID == empID && xx.AttendDate == offDay.HolidayDate && xx.AttendanceType == (int)ATTENDANCE_TYPE.LEAVE

                                                                     select xx).FirstOrDefault();
                        if (present != null) nonWorkingDays--;
                    }

                    // if outdoor
                    if (AppCommon.isSecondSaturday(offDay.HolidayDate) || AppCommon.isFourthSaturday(offDay.HolidayDate))
                    {
                        if ((new ServiceEmployee()).IsWeekOffDayForEmployee("SATURDAY", empID))
                        {
                            TBL_MP_HR_ManualAttendance_Master present = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                         where xx.FK_EmployeeID == empID && xx.AttendDate == offDay.HolidayDate && xx.AttendanceType == (int)ATTENDANCE_TYPE.OUT_DOOR
                                                                         select xx).FirstOrDefault();
                            if (present != null) nonWorkingDays--;
                        }
                    }
                    else
                    {
                        TBL_MP_HR_ManualAttendance_Master present = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                     where xx.FK_EmployeeID == empID && xx.AttendDate == offDay.HolidayDate && xx.AttendanceType == (int)ATTENDANCE_TYPE.OUT_DOOR

                                                                     select xx).FirstOrDefault();
                        if (present != null) nonWorkingDays--;
                    }


                }

                model.NonWorkingDays = new TimeDuration(nonWorkingDays, 0, 0);

                strQuery = string.Format("select * from vAttendanceRegister where FK_EmployeeID={0}  AND IsActive=1  AND AttendDate between '{1}' and '{2}' order by AttendDate",
                    empID, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                List<vAttendanceRegister> dbList = _dbContext.Database.SqlQuery<vAttendanceRegister>(strQuery).ToList();
                foreach (vAttendanceRegister item in dbList)
                {
                    mDuration = new TimeDuration(item.Duration);
                    ATTENDANCE_TYPE attType = (ATTENDANCE_TYPE)item.AttendanceType;
                    switch (attType)
                    {
                        case ATTENDANCE_TYPE.PRESENT:
                            model.Present.Hours += mDuration.Days;
                            model.Present.Mins += mDuration.Hours;
                            break;
                        case ATTENDANCE_TYPE.ABSENT:
                            model.Absent.Hours += mDuration.Days;
                            model.Absent.Mins += mDuration.Hours;
                            break;
                        case ATTENDANCE_TYPE.LEAVE:
                            if (item.FK_UserList_LeaveFormTypeID == serviceLeaves.LEAVE_TYPE_LEAVE_ID)
                            {
                                // TOTAL TIME OF PL LEAVES
                                if (item.FK_LeaveTypeID == leavePL_ID)
                                {
                                    model.PLs.Hours += mDuration.Days;
                                    model.PLs.Mins += mDuration.Hours;
                                }
                                // TOTAL TIME OF CL LEAVES
                                if (item.FK_LeaveTypeID == leaveCL_ID)
                                {
                                    model.CLs.Hours += mDuration.Days;
                                    model.CLs.Mins += mDuration.Hours;
                                }
                                // TOTAL TIME OF SL LEAVES
                                if (item.FK_LeaveTypeID == leaveSL_ID)
                                {
                                    model.SLs.Hours += mDuration.Days;
                                    model.SLs.Mins += mDuration.Hours;
                                }
                                // TOTAL TIME OF compOff LEAVES
                                if (item.FK_LeaveTypeID == leaveCompOff_ID)
                                {
                                    model.CompOffs.Hours += mDuration.Days;
                                    model.CompOffs.Mins += mDuration.Hours;
                                }
                            }
                            break;
                        case ATTENDANCE_TYPE.OUT_DOOR:
                            if (item.FK_UserList_LeaveFormTypeID == serviceLeaves.LEAVE_TYPE_OUTDOOR_ID)
                            {
                                model.Outdoor.Hours += mDuration.Days;
                                model.Outdoor.Mins += mDuration.Hours;
                            }
                            break;
                        case ATTENDANCE_TYPE.LATE_COMING:
                            if (item.FK_UserList_LeaveFormTypeID == serviceLeaves.LEAVE_TYPE_LATE_COMING_ID)
                            {
                                model.LateComings.Hours += mDuration.Days;
                                model.LateComings.Mins += mDuration.Hours;
                            }
                            break;
                        case ATTENDANCE_TYPE.EARLY_GOING:
                            if (item.FK_UserList_LeaveFormTypeID == serviceLeaves.LEAVE_TYPE_EARLY_LEAVING_ID)
                            {
                                model.EarlyGoings.Hours += mDuration.Days;
                                model.EarlyGoings.Mins += mDuration.Hours;
                            }
                            break;

                    }
                }


                #region calculate PRESENT DURATION
                int totalPresentMins= (model.Present.Hours*60)+ model.Present.Mins;
                model.Present.Days = (int)(totalPresentMins / TotalMinEachDay);
                model.Present.Mins = totalPresentMins -( TotalMinEachDay* model.Present.Days);
                if (model.Present.Mins > 60)
                {
                    model.Present.Hours = (int)(model.Present.Mins / 60);
                    model.Present.Mins = model.Present.Mins % 60;
                }
                else
                {
                    model.Present.Hours = 0;
                }
                #endregion

                #region calculate Absent DURATION
               int totalAbsentMins = (model.Absent.Hours * 60) + model.Absent.Mins;
                model.Absent.Days = (int)(totalAbsentMins / TotalMinEachDay);
                model.Absent.Mins = totalAbsentMins - (TotalMinEachDay * model.Absent.Days);
                if (model.Absent.Mins > 60)
                {
                    model.Absent.Hours = (int)(model.Absent.Mins / 60);
                    model.Absent.Mins = model.Absent.Mins % 60;
                }
                else
                {
                    model.Absent.Hours = 0;
                }
                #endregion

                #region calculate OutDoor DURATION
               int totalOutDoorMins = (model.Outdoor.Hours * 60) + model.Outdoor.Mins;
                model.Outdoor.Days = (int)(totalOutDoorMins / TotalMinEachDay);
                model.Outdoor.Mins = totalOutDoorMins - (TotalMinEachDay * model.Outdoor.Days);
                if (model.Outdoor.Mins > 60)
                {
                    model.Outdoor.Hours = (int)(model.Outdoor.Mins / 60);
                    model.Outdoor.Mins = model.Outdoor.Mins % 60;
                }
                else
                {
                    model.Outdoor.Hours = 0;
                }
                #endregion

                #region calculate PL DURATION
                int totalPLsMins = (model.PLs.Hours * 60) + model.PLs.Mins;
                model.PLs.Days = (int)(totalPLsMins / TotalMinEachDay);
                model.PLs.Mins = totalPLsMins - (TotalMinEachDay * model.PLs.Days);
                if (model.PLs.Mins > 60)
                {
                    model.PLs.Hours = (int)(model.PLs.Mins / 60);
                    model.PLs.Mins = model.PLs.Mins % 60;
                }
                else
                {
                    model.PLs.Hours = 0;
                }
                #endregion

                #region calculate Cls DURATION
                int totalClsMins = (model.CLs.Hours * 60) + model.CLs.Mins;
                model.CLs.Days = (int)(totalClsMins / TotalMinEachDay);
                model.CLs.Mins = totalClsMins - (TotalMinEachDay * model.CLs.Days);
                if (model.CLs.Mins > 60)
                {
                    model.CLs.Hours = (int)(model.CLs.Mins / 60);
                    model.CLs.Mins = model.CLs.Mins % 60;
                }
                else
                {
                    model.CLs.Hours = 0;
                }
                #endregion

                #region calculate SL DURATION
                int totalSLsMins = (model.SLs.Hours * 60) + model.SLs.Mins;
                model.SLs.Days = (int)(totalSLsMins / TotalMinEachDay);
                model.SLs.Mins = totalSLsMins - (TotalMinEachDay * model.SLs.Days);
                if (model.SLs.Mins > 60)
                {
                    model.SLs.Hours = (int)(model.SLs.Mins / 60);
                    model.SLs.Mins = model.SLs.Mins % 60;
                }
                else
                {
                    model.SLs.Hours = 0;
                }
                #endregion

                #region calculate CompOff DURATION
               int totalCompOffMins = (model.CompOffs.Hours * 60) + model.CompOffs.Mins;
                model.CompOffs.Days = (int)(totalCompOffMins / TotalMinEachDay);
                model.CompOffs.Mins = totalCompOffMins - (TotalMinEachDay * model.CompOffs.Days);
                if (model.CompOffs.Mins > 60)
                {
                    model.CompOffs.Hours = (int)(model.CompOffs.Mins / 60);
                    model.CompOffs.Mins = model.CompOffs.Mins % 60;
                }
                else
                {
                    model.CompOffs.Hours = 0;
                }
                #endregion

                #region calculate LateComming DURATION
                int totalLateCommingfMins = (model.LateComings.Hours * 60) + model.LateComings.Mins;
                model.LateComings.Days = (int)(totalLateCommingfMins / TotalMinEachDay);
                model.LateComings.Mins = totalLateCommingfMins - (TotalMinEachDay * model.LateComings.Days);
                if (model.LateComings.Mins > 60)
                {
                    model.LateComings.Hours = (int)(model.LateComings.Mins / 60);
                    model.LateComings.Mins = model.LateComings.Mins % 60;
                }
                else
                {
                    model.LateComings.Hours = 0;
                }
                #endregion

                #region calculate EarlyLeaving DURATION
                int totalEarlyLeavingMins = (model.EarlyGoings.Hours * 60) + model.EarlyGoings.Mins;
                model.EarlyGoings.Days = (int)(totalEarlyLeavingMins / TotalMinEachDay);
                model.EarlyGoings.Mins = totalEarlyLeavingMins - (TotalMinEachDay * model.EarlyGoings.Days);
                if (model.EarlyGoings.Mins > 60)
                {
                    model.EarlyGoings.Hours = (int)(model.EarlyGoings.Mins / 60);
                    model.EarlyGoings.Mins = model.EarlyGoings.Mins % 60;
                }
                else
                {
                    model.EarlyGoings.Hours = 0;
                }
                #endregion

                #region CALCULATE PAID DAYS
                model.PaidDays.Days = model.Present.Days + model.NonWorkingDays.Days + model.PLs.Days + model.CLs.Days + model.SLs.Days + model.CompOffs.Days + model.Outdoor.Days+model.LateComings.Days+model.EarlyGoings.Days;
                model.PaidDays.Hours = model.Present.Hours + model.NonWorkingDays.Hours + model.PLs.Hours + model.CLs.Hours + model.SLs.Hours + model.CompOffs.Hours + model.Outdoor.Hours+model.LateComings.Hours+model.EarlyGoings.Hours;
                model.PaidDays.Mins = model.Present.Mins + model.NonWorkingDays.Mins + model.PLs.Mins + model.CLs.Mins + model.SLs.Mins + model.CompOffs.Mins + model.Outdoor.Mins+model.LateComings.Mins+model.EarlyGoings.Mins;
                int totalPaidMins = (model.PaidDays.Days* TotalMinEachDay) + (model.PaidDays.Hours * 60) + model.PaidDays.Mins;
                model.PaidDays.Days = (int)(totalPaidMins / TotalMinEachDay);
                model.PaidDays.Mins = totalPaidMins - (TotalMinEachDay * model.PaidDays.Days);
                if (model.PaidDays.Mins > 60)
                {
                  model.PaidDays.Hours = (int)(model.PaidDays.Mins / 60);
                  model.PaidDays.Mins = model.PaidDays.Mins % 60;
               }
                else
                {
                    model.PaidDays.Hours = 0;
               }
                #endregion

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetAttendanceSummaryOfEmployeeForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public List<MonthlyAttendanceSummaryModel> GetMonthlyAttendanceSummaryForMonth(DateTime monthDate)
        {
            List<MonthlyAttendanceSummaryModel> lstSummary = new List<MonthlyAttendanceSummaryModel>();
            EmployeeAttendanceSummaryModel summary = null;
            try
            {
                // FIND START & END DATE FOR THE MONTH
                DateTime startDate = new DateTime(monthDate.Year, monthDate.Month, 1);
                int days = DateTime.DaysInMonth(monthDate.Year, monthDate.Month);
                DateTime endDate = new DateTime(monthDate.Year, monthDate.Month, days);
                // GET ALL DISTINCT EMPLOYEES FOR THE MONTH 
                string strQuery = string.Format("select distinct FK_EmployeeID as ID,EmployeeDescription as Description from vAttendanceRegister where AttendDate BETWEEN '{0}' AND '{1}' ORDER BY 2 ",
                    startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                List<SelectListItem> lstEmployees = _dbContext.Database.SqlQuery<SelectListItem>(strQuery).ToList();
                
                // PREPARE ATTENDANCE SUMMARY FOR EACH EMPLOYEE
                foreach (SelectListItem emp in lstEmployees)
                {
                    summary = this.GetAttendanceSummaryOfEmployeeForMonth(emp.ID, monthDate);
                    MonthlyAttendanceSummaryModel model = new MonthlyAttendanceSummaryModel();
                    model.EmployeeID = emp.ID;
                    model.EmployeeName = emp.Description;
                    model.TotalDays = summary.TotalDays.Text;
                    model.PaidDays = summary.PaidDays.Text;
                    model.Present = summary.Present.Text;
                    model.NonWorkingDays = summary.NonWorkingDays.Text;
                    model.Absent = summary.Absent.Text;
                    model.PLs = summary.PLs.Text;
                    model.CLs = summary.CLs.Text;
                    model.SLs = summary.SLs.Text;
                    model.Outdoor = summary.Outdoor.Text;
                    model.CompOffs = summary.CompOffs.Text;
                    model.LateComings = summary.LateComings.Text;
                    model.EarlyGoings = summary.EarlyGoings.Text;
                    model.SandwichLeaves = summary.SandwichLeaves.Text;
                    lstSummary.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::GetMonthlyAttendanceSummaryForMonth", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstSummary;
        }

        // update multiple record for delete them
        public bool UpdateAttendanceForDelete(int SelectedAttendanceID, BindingList<AttendanceGridViewModel> SelecetdAttendanceList)
        {
            bool result = false;
            // int selModuleID = 0;
            try
            {
                if (SelecetdAttendanceList.Count > 0)


                    // INSETRING MODULE NOT FOUND IN DATABASE
                    foreach (AttendanceGridViewModel item in SelecetdAttendanceList)
                    {

                        if (item.SelectedAttendance == true)
                        {

                            TBL_MP_HR_ManualAttendance_Master dbModel = (from x in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                                         where x.PK_AttendanceID == item.AttendanceID
                                                                         select x).FirstOrDefault();
                            dbModel.isSelected = true;
                            _dbContext.SaveChanges();
                        }
                    }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += "\n" + ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceSalaryHead::UpdateAttendanceForDelete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public void DeleteMultipleAttendanceAndItsLeave(int attendanceID)
        {
            try
            {

                List<TBL_MP_HR_ManualAttendance_Master> lstRecords = new List<TBL_MP_HR_ManualAttendance_Master>();
                TBL_MP_HR_LeaveApplication lstRecords1 = new TBL_MP_HR_LeaveApplication();
                lstRecords1 = null;
                lstRecords = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master where xx.isSelected == true select xx).ToList();

                //string strQuery = "select FK_LeaveApplicationID from TBL_MP_HR_ManualAttendance_Master where isSelected == true ";
                //lstRecords1 = _dbContext.Database.SqlQuery<TBL_MP_HR_ManualAttendance_Master>(strQuery).ToList();

                lstRecords = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                              where xx.isSelected == true
                              select xx).ToList();

                //        TBL_MP_HR_ManualAttendance_Master lst = new TBL_MP_HR_ManualAttendance_Master();
                foreach (TBL_MP_HR_ManualAttendance_Master lst in lstRecords)
                {
                    lstRecords1 = (from xx in _dbContext.TBL_MP_HR_LeaveApplication
                                   where xx.PK_LeaveApplicationID == lst.FK_LeaveApplicationID
                                   select xx).FirstOrDefault();
                    if (lstRecords1 != null)
                    {
                        lstRecords1.IsDeleted = true;
                        _dbContext.SaveChanges();
                    }
                }
                _dbContext.TBL_MP_HR_ManualAttendance_Master.RemoveRange(lstRecords);
                _dbContext.SaveChanges();
            }

            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAttendance::DeleteMultipleAttendanceAndItsLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
