using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace libERP.SERVICES.HR
{
    public class ServiceLeaveApplication : DefaultService
    {
        public event LeaveRegisterPreparationForEmployeeCompletedEventHandler EmployeeRecordCompleted;

        // define alll constants that u need to process .. and use them in code
        public int LEAVE_FORM_TYPE_ID = 0;

        public int LEAVE_TYPE_LEAVE_ID = 0;
        public int LEAVE_TYPE_LEAVE_CATEGORY_ID = 0;

        public int LEAVE_TYPE_OUTDOOR_ID = 0;
        public int LEAVE_TYPE_OUTDOOR_CATEGORY_ID = 0;

        public int LEAVE_TYPE_COMP_OFF_ID = 0;
        public int LEAVE_TYPE_LATE_COMING_ID = 0;
        public int LEAVE_TYPE_EARLY_LEAVING_ID = 0;
        

        public int OUTDOOR_FULLSHIFT_ID=0;
        public int OUTDOOR_FIRST_HALF_ID = 0;
        public int OUTDOOR_SECOND_HALF_ID = 0;

        public int LEAVE_STATUS_PENDING_ID = 0;
        public int LEAVE_STATUS_APPROVED_ID = 0;
        public int LEAVE_STATUS_REJECTED_ID = 0;
        
        public int LEAVE_TYPE_HALFDAY_ID = 0; 
        
        public ServiceLeaveApplication(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
            PopulateStatusVariables();
        }
        public ServiceLeaveApplication()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
            PopulateStatusVariables();
        }
        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                LEAVE_FORM_TYPE_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;

                LEAVE_TYPE_LEAVE_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeLeaveID).FirstOrDefault().DEFAULT_VALUE;
                LEAVE_TYPE_OUTDOOR_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeOutDoorID).FirstOrDefault().DEFAULT_VALUE;


                LEAVE_TYPE_LEAVE_CATEGORY_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveType_Leave_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                LEAVE_TYPE_OUTDOOR_CATEGORY_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveType_OutDoorCategoryID).FirstOrDefault().DEFAULT_VALUE;

                OUTDOOR_FULLSHIFT_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.OUTDOOR_FULLSHIFT_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                OUTDOOR_FIRST_HALF_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.OUTDOOR_FIRSTHALF_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                OUTDOOR_SECOND_HALF_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.OUTDOOR_SECONDHALF_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;

                LEAVE_STATUS_PENDING_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusPending_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                LEAVE_STATUS_APPROVED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusApproved_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                LEAVE_STATUS_REJECTED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusRejected_CategoryID).FirstOrDefault().DEFAULT_VALUE;

                LEAVE_TYPE_HALFDAY_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_HALFDAY_ID).FirstOrDefault().DEFAULT_VALUE;

                 LEAVE_TYPE_COMP_OFF_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormType_CompOffID).FirstOrDefault().DEFAULT_VALUE;
                 LEAVE_TYPE_LATE_COMING_ID  = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormType_LateComingID).FirstOrDefault().DEFAULT_VALUE;
                 LEAVE_TYPE_EARLY_LEAVING_ID  = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTpe_EarlyLeavingID).FirstOrDefault().DEFAULT_VALUE;

    }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<SelectListItem> GetAllLeaveFormTypes()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_Admin_UserList
                       where xx.Fk_Admin_CategoryID == this.LEAVE_FORM_TYPE_ID
                       select new SelectListItem()
                       {
                           ID= xx.PKID,
                           Description= xx.Admin_UserList_Desc
                       }).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetAllLeaveFormTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllLeaveTypesForLeaveForm(int leaveFormID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int parentCategoryID = 0;
                if (leaveFormID == LEAVE_TYPE_LEAVE_ID)
                {
                    parentCategoryID = LEAVE_TYPE_LEAVE_CATEGORY_ID;
                    List<TBL_MP_Admin_UserList> dbList = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == parentCategoryID).ToList();
                    foreach (TBL_MP_Admin_UserList item in dbList)
                    {
                        SelectListItem selItem = new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc };
                        lst.Add(selItem);
                    }
                }
                if (leaveFormID == LEAVE_TYPE_OUTDOOR_ID)
                {
                    parentCategoryID = LEAVE_TYPE_OUTDOOR_CATEGORY_ID;
                    List<TBL_MP_Admin_UserList> dbList = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == parentCategoryID).ToList();
                    foreach (TBL_MP_Admin_UserList item in dbList)
                    {
                        SelectListItem selItem = new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc };
                        lst.Add(selItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetAllLeaveTypesForLeaveForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<LeaveApplicationModel> GetAllLeaveApplicationsOfEmployee(int employeeID)
        {
            List<LeaveApplicationModel> lstApplications = new List<LeaveApplicationModel>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select a.PK_LeaveApplicationID as ApplicationID,a.ApplicationNo,a.ApplicationDate, ");
                sb.Append("b.EmployeeDescription as EmployeeName, ");
                sb.Append("a.LeaveFormTypeName + ' ' + IsNull(a.LeaveTypeName,'') as LeaveDescription,") ;
                sb.Append("a.FromTime as FromDateTime, a.ToTime as ToDateTime,a.CreateDateTime,");
                sb.Append("a.PreparedBy as PreparedByID,a.PreparedByName,");
                sb.Append("IsNull(a.FK_ApprovedBy,-1) as ApprovedByID,IsNull(a.ApprovedByName,'--') as ApprovedByName,");
                sb.Append("a.Remarks, a.StatusDescription as ApplicationStatus ");
                sb.Append("from vLeaveApplication a left join vEMPLOYEE_DESCRIPTION b on a.FK_EmployeeID = b.PK_EmployeeId ");
                sb.Append("where (a.FK_EmployeeID ={0} OR a.PreparedBy = {0})  AND a.IsDeleted= 0 ");
                sb.Append("Order by a.FromDate desc");
                string strQuery=string.Format(sb.ToString(),employeeID);
                lstApplications = _dbContext.Database.SqlQuery<LeaveApplicationModel>(strQuery).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetAllLeaveApplicationsOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstApplications;
        }
        public List<LeaveApplicationModel> GetAllLeaveApplicationsForYear(int yearID)
        {
            List<LeaveApplicationModel> lstApplications = new List<LeaveApplicationModel>();

            try
            {
                List<vLeaveApplication> lstLeaves = (from xx in _dbContext.vLeaveApplications
                                                     where xx.FK_YearId== yearID
                                                     orderby xx.FromDate descending
                                                     select xx).ToList();
                foreach (vLeaveApplication item in lstLeaves)
                {
                   
                   
                    string strDescription = item.ApplicationNo;
                    strDescription += string.Format("\nFrom : {0} {1} ", item.FromDate.ToString("dd MMM yyyy"), item.FromTime.Value.ToString("hh:mm tt"));
                    strDescription += string.Format("To : {0} {1}", item.ToDate.ToString("dd MMM yyyy"), item.ToTime.Value.ToString("hh:mm tt"));
                    strDescription += "\n" + item.Remarks;

                    LeaveApplicationModel model = new LeaveApplicationModel();
                    model.ApplicationID = item.PK_LeaveApplicationID;
                    model.ApplicationDate = item.ApplicationDate;
                    model.LeaveDescription = string.Format("{0} {1}", item.LeaveFormTypeName, (item.LeaveTypeName == string.Empty) ? "" : "( " + item.LeaveTypeName + " )");
                    model.ApplicationNo = item.ApplicationNo;
                    model.FromDateTime = (DateTime)item.FromTime;
                    model.ToDateTime = (DateTime)item.ToTime;
                    model.PreparedByID = (int)item.PreparedBy;
                    model.PreparedByName = item.PreparedByName;
                   // model.CreateDateTime = item.CreateDateTime;
                   model.Remarks = strDescription;
                    model.EmployeeName = item.EmployeeName;
                    model.ApplicationStatus = item.StatusDescription;
                    model.ApprovedByName = "--";
                    if(item.FK_ApprovedBy!=null)
                    {
                        model.ApprovedByID = (int)item.FK_ApprovedBy;
                        model.ApprovedByName = item.ApprovedByName;
                    }
                    //if (item.Approval_Date != null)
                    //{
                    //    model.Approval_Date = (DateTime)item.Approval_Date;
                    //}

                    lstApplications.Add(model);
                }
                //List<SelectListItem> lstLeaveFormTypes = this.GetAllLeaveFormTypes();
                //List<SelectListItem> lstLeaveTypeLeaves = this.GetAllLeaveTypesForLeaveForm(LEAVE_TYPE_LEAVE_ID);
                //List<SelectListItem> lstLeaveTypeOutdoor = this.GetAllLeaveTypesForLeaveForm(LEAVE_TYPE_OUTDOOR_ID);
                //List<SelectListItem> lstApprovalStatus = (new ServiceMASTERS()).GetAllApprovalStatuses();

                //List<TBL_MP_HR_LeaveApplication> dbList = _dbContext.TBL_MP_HR_LeaveApplication.Where(x => x.FK_YearID== yearID).OrderByDescending(x => x.ApplicationDate).ToList();
                //foreach (TBL_MP_HR_LeaveApplication item in dbList)
                //{
                //    string strFormTypeName = lstLeaveFormTypes.Where(x => x.ID == item.FK_UserList_LeaveFormTypeID).FirstOrDefault().Description.ToUpper(); ;
                //    string strLeaveTypeName = string.Empty;
                //    if (item.FK_UserList_LeaveFormTypeID == LEAVE_TYPE_LEAVE_ID)
                //    {
                //        strLeaveTypeName = lstLeaveTypeLeaves.Where(x => x.ID == item.fK_UsrLst_LeaveTypeID).FirstOrDefault().Description;
                //    }
                //    if (item.FK_UserList_LeaveFormTypeID == LEAVE_TYPE_OUTDOOR_ID)
                //    {
                //        strLeaveTypeName = lstLeaveTypeOutdoor.Where(x => x.ID == item.fK_UsrLst_LeaveTypeID).FirstOrDefault().Description;
                //    }
                //    string strDescription = item.ApplicationNo;
                //    strDescription += string.Format("\nFrom : {0} {1} ", item.FromDate.ToString("dd MMM yyyy"), item.FromTime.Value.ToString("hh:mm tt"));
                //    strDescription += string.Format("To : {0} {1}", item.ToDate.ToString("dd MMM yyyy"), item.ToTime.Value.ToString("hh:mm tt"));
                //    strDescription += "\n" + item.Remarks;

                //    LeaveApplicationModel model = new LeaveApplicationModel();
                //    model.ApplicationID = item.PK_LeaveApplicationID;
                //    model.ApplicationDate = item.ApplicationDate;
                //    model.FormType = string.Format("{0} {1}", strFormTypeName, (strLeaveTypeName == string.Empty) ? "" : "( " + strLeaveTypeName + " )");
                //    model.Description = strDescription;
                //    model.EmployeeName = item.TBL_MP_Master_Employee.EmployeeName;



                //    SelectListItem selSatus = lstApprovalStatus.Where(x => x.ID == item.FK_UserList_ApprovalStatusID).FirstOrDefault();
                //    if (selSatus != null) model.Status = selSatus.Description;
                //    if (item.FK_UserList_ApprovalStatusID == LEAVE_STATUS_APPROVED_ID || item.FK_UserList_ApprovalStatusID == LEAVE_STATUS_REJECTED_ID)
                //    {
                //        string strStatusDescription = string.Empty;
                //        if (item.FK_ApprovedBy != null)
                //            strStatusDescription += ServiceEmployee.GetEmployeeNameByID((int)item.FK_ApprovedBy);
                //        strStatusDescription += string.Format("\nRemarks:\n{0} dt.{1}", item.RemarksApproval, item.Approval_Date.ToString());
                //        model.StatusDescription = strStatusDescription;
                //    }

                //    lstApplications.Add(model);
                //}


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetAllLeaveApplicationsOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstApplications;
        }
        public List<LeaveApplicationModel> GetAllLeaveApplicationsForEmp(int empId)
        {
            List<LeaveApplicationModel> lstApplications = new List<LeaveApplicationModel>();

            try
            {
                List<vLeaveApplication> lstLeaves = (from xx in _dbContext.vLeaveApplications
                                                     where xx.FK_EmployeeID == empId
                                                     orderby xx.FromDate descending
                                                     select xx).ToList();
                foreach (vLeaveApplication item in lstLeaves)
                {


                    string strDescription = item.ApplicationNo;
                    strDescription += string.Format("\nFrom : {0} {1} ", item.FromDate.ToString("dd MMM yyyy"), item.FromTime.Value.ToString("hh:mm tt"));
                    strDescription += string.Format("To : {0} {1}", item.ToDate.ToString("dd MMM yyyy"), item.ToTime.Value.ToString("hh:mm tt"));
                    strDescription += "\n" + item.Remarks;

                    LeaveApplicationModel model = new LeaveApplicationModel();
                    model.ApplicationID = item.PK_LeaveApplicationID;
                    model.ApplicationDate = item.ApplicationDate;
                    model.LeaveDescription = string.Format("{0} {1}", item.LeaveFormTypeName, (item.LeaveTypeName == string.Empty) ? "" : "( " + item.LeaveTypeName + " )");
                    model.ApplicationNo = item.ApplicationNo;
                    model.FromDateTime = (DateTime)item.FromTime;
                    model.ToDateTime = (DateTime)item.ToTime;
                    model.PreparedByID = (int)item.PreparedBy;
                    model.PreparedByName = item.PreparedByName;
                   // model.CreateDateTime = item.CreateDateTime;
                    model.Remarks = strDescription;
                    model.EmployeeName = item.EmployeeName;
                    model.ApplicationStatus = item.StatusDescription;
                    model.ApprovedByName = "--";
                    if (item.FK_ApprovedBy != null)
                    {
                        model.ApprovedByID = (int)item.FK_ApprovedBy;
                        model.ApprovedByName = item.ApprovedByName;
                    }
                    //if (item.Approval_Date != null)
                    //{
                    //    model.Approval_Date = (DateTime)item.Approval_Date;
                    //}

                    lstApplications.Add(model);
                }
               

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetAllLeaveApplicationsForEmp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstApplications;
        }
        public List<LeaveApplicationModel> GetAllLeaveRequestsToAuthority(int authorityID, int finYearID)
        {
            List<LeaveApplicationModel> lstApplications = new List<LeaveApplicationModel>();
           string strDescription = string.Empty;
            try
            {
                // FIND ALL EMPLOYEES FOR THE SELECTED AUTHORITY
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from vLeaveApplication ");
                sb.Append("where FK_EmployeeID in (select FK_EmployeeId from TBL_MP_Master_Employee_Authority where FK_AuthorityID = {0}) ");
                sb.Append("AND IsDeleted=0 AND FK_YearId={1} ");
                sb.Append("Order by FromDate DESC ");
                string strQuery = string.Format(sb.ToString(), authorityID, finYearID);
                List<vLeaveApplication> lstLeaves = _dbContext.Database.SqlQuery<vLeaveApplication>(strQuery).ToList();
                foreach (vLeaveApplication item in lstLeaves)
                {
                    strDescription = item.ApplicationNo;
                    strDescription += string.Format("\nFrom : {0} {1} ", item.FromDate.ToString("dd MMM yyyy"), item.FromTime.Value.ToString("hh:mm tt"));
                    strDescription += string.Format("To : {0} {1}", item.ToDate.ToString("dd MMM yyyy"), item.ToTime.Value.ToString("hh:mm tt"));
                    strDescription += "\n" + item.Remarks;

                    LeaveApplicationModel model = new LeaveApplicationModel();
                    model.ApplicationID = item.PK_LeaveApplicationID;
                    model.ApplicationDate = item.ApplicationDate;
                    model.LeaveDescription = string.Format("{0} {1}", item.LeaveFormTypeName, (item.LeaveTypeName == string.Empty) ? "" : "( " + item.LeaveTypeName + " )");
                    model.LeaveDescription += string.Format("\n{0}", strDescription);
                    model.ApplicationNo = item.ApplicationNo;
                    model.FromDateTime = (DateTime)item.FromTime;
                    model.ToDateTime =(DateTime) item.ToTime;
                    model.PreparedByID = (int)item.PreparedBy;
                    model.PreparedByName = item.PreparedByName;
                  //  model.CreateDateTime = item.CreateDateTime;
                    if (item.FK_ApprovedBy != null)
                    {
                        model.ApprovedByID = (int)item.FK_ApprovedBy;
                        model.ApprovedByName = item.ApprovedByName;
                    }
                    if (item.Approval_Date != null)
                    {
                        model.Approval_Date = (DateTime)item.Approval_Date;
                    }

                    model.Remarks = item.Remarks;
                    model.EmployeeName = item.EmployeeName;
                    model.ApplicationStatus = item.StatusDescription;
                    lstApplications.Add(model);
                  
                    if (EmployeeRecordCompleted != null)
                    {
                        EmployeeRecordCompleted(this, new MODELS.COMMON.EventArguementModel() { Message = string.Format("{0}", model.EmployeeName) });
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage =string.Format("{0}\n{1}", ex.Message,strDescription);
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetAllLeaveRequestsToAuthority", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstApplications;
        }
        public string GenerateNewLeaveApplicationNumber(int currFinYear, int currBrachID, int companyID)
        {
            string keyCode = string.Empty;
            int intPreviousYearCount = 0;
            int cnt;
            string strNumber;
            string strQuery = string.Empty;
            try
            {
                // 0123
                TBL_MP_Admin_VoucherNoSetup objLeaveApplicationSetup = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.LEAVE_APPLICATIONS &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();


                if (objLeaveApplicationSetup == null)
                {
                    string strMessage = "Unable to locate Voucher No. setup for the selected Financial Year or Branch";
                    MessageBox.Show(strMessage, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_HR_LeaveApplication WHERE FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objLeaveApplicationSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.LEAVE_APPLICATIONS &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_HR_LeaveApplication lastLeavePrevYear = (from xx in _dbContext.TBL_MP_HR_LeaveApplication
                                                                    where xx.FK_YearID == currFinYear - 1 &&
                                                            xx.FK_BranchID == currBrachID &&
                                                            xx.FK_CompanyID == companyID
                                                            orderby xx.ApplicationDate descending
                                                            select xx).FirstOrDefault();
                    if (lastLeavePrevYear != null)
                    {
                        string lstnumber = lastLeavePrevYear.ApplicationNo.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
                        intPreviousYearCount = int.Parse(lstnumber);
                    }
                    else
                        intPreviousYearCount = 1;

                    cnt += intPreviousYearCount;
                }
                else
                {
                    cnt += (int)objLeaveApplicationSetup.NoStartingFrom;
                }

                strNumber = cnt.ToString().PadLeft(objLeaveApplicationSetup.NoPad, '0');
                //0083 

                keyCode += objLeaveApplicationSetup.NoPrefix + objLeaveApplicationSetup.NoSeperator + strNumber + objLeaveApplicationSetup.NoSeperator + objLeaveApplicationSetup.NoPostfix;
                // XL/SO/0083/2018-19
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GenerateNewLeaveApplicationNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }

        public TBL_MP_HR_LeaveApplication GetLeaveApplicationInfoDbRecord(int LeaveAppID)
        {
            TBL_MP_HR_LeaveApplication model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_LeaveApplication.Where(x => x.PK_LeaveApplicationID == LeaveAppID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetLeaveApplicationInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public vLeaveApplication GetLeaveApplicationInfoViewRecord(int LeaveAppID)
        {
            vLeaveApplication model = null;
            try
            {
                model = _dbContext.vLeaveApplications.Where(x => x.PK_LeaveApplicationID == LeaveAppID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetLeaveApplicationInfoViewRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewLeaveApplicationInfo(TBL_MP_HR_LeaveApplication model)
        {
            int newID = 0;
            try
            {
                model.ApplicationNo = this.GenerateNewLeaveApplicationNumber(model.FK_YearID, model.FK_BranchID, model.FK_CompanyID);
                model.FK_UserList_ApprovalStatusID = LEAVE_STATUS_PENDING_ID;
                model.IsDeleted = false;
                model.Approval_Date =null;
                model.FK_ApprovedBy = null;
                model.RemarksApproval = string.Empty;
                _dbContext.TBL_MP_HR_LeaveApplication.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_LeaveApplicationID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::AddNewLeaveApplicationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateLeaveApplicationInfo(TBL_MP_HR_LeaveApplication model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LeaveApplication dbModel = _dbContext.TBL_MP_HR_LeaveApplication.Where(x => x.PK_LeaveApplicationID == model.PK_LeaveApplicationID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_EmployeeID = model.FK_EmployeeID;
                    dbModel.FK_RequestTo = model.FK_RequestTo;
                    dbModel.ApplicationNo = model.ApplicationNo;
                    dbModel.ApplicationDate = model.ApplicationDate;
                    dbModel.FK_UserList_LeaveFormTypeID = model.FK_UserList_LeaveFormTypeID;
                    dbModel.fK_UsrLst_LeaveTypeID = model.fK_UsrLst_LeaveTypeID;
                    dbModel.FromDate = model.FromDate;
                    dbModel.ToDate = model.ToDate;
                    dbModel.FromTime = model.FromTime;
                    dbModel.ToTime = model.ToTime;
                    dbModel.Duration = model.Duration;
                    dbModel.Remarks = model.Remarks;
                    dbModel.Approval_Date = model.Approval_Date;
                    dbModel.CreateDateTime = model.CreateDateTime;
                    _dbContext.SaveChanges();
                    result = true;
                }
                else
                {
                    MessageBox.Show("Unable to Locate this Record in Database", "ERROR");
                    return false;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::UpdateLeaveInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
       
        public LeaveBalanceModel GetLeaveBalanceModelOfEmployeeForYear(int empID, int finyearID, int leaveType)
        {
            LeaveBalanceModel model = new LeaveBalanceModel();
            try
            {
                int leavePL_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_PL_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                int leaveCL_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_CL_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                int leaveSL_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_SL_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;
                int leaveCompOff_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_COMP_OFF_CATEGORY_ID).FirstOrDefault().DEFAULT_VALUE;

                if (leaveType == leavePL_ID || leaveType == leaveCL_ID || leaveType == leaveSL_ID || leaveType== leaveCompOff_ID)
                {
                    TBL_MP_Master_Employee_LeaveConfiguration dbModel = (from xx in _dbContext.TBL_MP_Master_Employee_LeaveConfiguration
                                                                         where xx.FK_EmployeeID == empID && xx.FK_FinYearID == finyearID && xx.FK_LeaveTypeID == leaveType
                                                                         select xx).FirstOrDefault();
                    if (dbModel != null)
                    {
                        model.Allowed = dbModel.MaxDaysAllow;
                        model.Earned = dbModel.LeavesEarned;
                        
                    }
                }
                if (leaveType == leaveCompOff_ID)
                {
                    // GET ALL ATTENDANCE OF EMPLOYEE ON HOLIDAY OR WEEK OFF DAYS
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sb1 = new StringBuilder();
                    sb.Append("Select AttendDate from vAttendanceRegister where FK_EmployeeID ={0} AND AttendanceType={1} ");
                    sb.Append("AND AttendDate IN (select distinct HolidayDate from TBL_MP_HR_HolidaysAndWeekOff where FK_YearId={2})");
                    string strQuery = string.Format(sb.ToString(), empID, (int)ATTENDANCE_TYPE.PRESENT, finyearID);

                    sb1.Append("Select AttendDate from vAttendanceRegister where FK_EmployeeID ={0} AND AttendanceType={1}");
                    sb1.Append("AND AttendDate IN (select distinct HolidayDate from TBL_MP_HR_HolidaysAndWeekOff where FK_YearId={2})");
                    string strQuery1 = string.Format(sb.ToString(), empID, (int)ATTENDANCE_TYPE.OUT_DOOR, finyearID);

                    List<DateTime> lstDates = _dbContext.Database.SqlQuery<DateTime>(strQuery).ToList();
                    List<DateTime> lstDates1 = _dbContext.Database.SqlQuery<DateTime>(strQuery1).ToList();
                   
                    // FOR SOME EMPLOYEES 2ND & 4TH SATURDAY IS NOT A WEEK OFF
                    // SO WE HAVE TO CHECK IF 2&4TH IS WORKING DAY ..REMOVE THAT DAYS FROM THIS LIST
                    List<DateTime> lstExclude = new List<DateTime>();
                    if (!(new ServiceEmployee()).IsWeekOffDayForEmployee("SATURDAY", empID))
                    {
                        foreach (DateTime currDate in lstDates)
                        {
                            if (AppCommon.isSecondSaturday(currDate) || AppCommon.isFourthSaturday(currDate))
                            {
                                lstExclude.Add(currDate);
                            }
                        }
                    }
                    model.Earned += ((lstDates.Count+lstDates1.Count)- lstExclude.Count) ;
                }
                
                List< string> dbAttendance = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                              where (xx.FK_EmployeeID == empID && xx.FK_YearId == finyearID && xx.FK_LeaveTypeID== leaveType) && xx.IsActive == true
                                                      select xx.Duration).ToList();

                decimal totalMins = 0;
                decimal TotalMinEachDay = (8 * 60) + 30;
                foreach (string s in dbAttendance)
                {
                    TimeDuration duration = new TimeDuration(s);
                    totalMins += (duration.Days * 60) + duration.Hours;
                }
                decimal Taken1= (totalMins / TotalMinEachDay);
                model.Taken = Convert.ToDecimal(string.Format("{0:0.00}", Taken1));
                model.Balance = (model.Allowed + model.Earned) - model.Taken;
                model.Balance =Convert.ToDecimal(string.Format("{0:0.00}", model.Balance));
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetLeaveBalanceModelOfEmployeeForYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int GetLeaveApplicationStatus(int applicationID)
        {
            int statusID =0;
            try
            {
                TBL_MP_HR_LeaveApplication model = _dbContext.TBL_MP_HR_LeaveApplication.Where(x => x.PK_LeaveApplicationID == applicationID).FirstOrDefault();
                if (model != null)
                {
                    statusID = model.FK_UserList_ApprovalStatusID;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::GetLeaveApplicationStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return statusID;
        }
        public void UpdateAttendanceForLeaveApplication(int leaveApplicationID)
        {
            TBL_MP_HR_ManualAttendance_Master dbAttendance = null;
            TBL_MP_HR_LeaveApplication dbLeave = null;
            DateTime dayStart = DateTime.Now;
            DateTime dayEnd = DateTime.Now;
            try
            {
                dbLeave = (from xx in _dbContext.TBL_MP_HR_LeaveApplication
                           where xx.PK_LeaveApplicationID == leaveApplicationID
                           select xx).FirstOrDefault();
                if (dbLeave != null)
                {
                    // REMOVE ALL ATTENDACE RECORD FOR THIS LEAVE
                    // SET LEAVEID TO NULL IF ATTENDANCE RECORD FOUND
                    string strQuery = string.Format("DELETE FROM TBL_MP_HR_ManualAttendance_Master where FK_LeaveApplicationID={0}", dbLeave.PK_LeaveApplicationID);
                    _dbContext.Database.ExecuteSqlCommand(strQuery);
                    _dbContext.SaveChanges();

                    ATTENDANCE_TYPE mAttendanceType = ATTENDANCE_TYPE.NONE;
                    if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LEAVE_ID) mAttendanceType = ATTENDANCE_TYPE.LEAVE;
                    if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_OUTDOOR_ID) mAttendanceType = ATTENDANCE_TYPE.OUT_DOOR;
                    if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_COMP_OFF_ID) mAttendanceType = ATTENDANCE_TYPE.COMP_OFF;
                    if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LATE_COMING_ID) mAttendanceType = ATTENDANCE_TYPE.LATE_COMING;
                    if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_EARLY_LEAVING_ID) mAttendanceType = ATTENDANCE_TYPE.EARLY_GOING;

                    if (dbLeave.FromDate.Date == dbLeave.ToDate.Date)
                    {
                        // INSERT ONE DAY LEAVE IN ATTENDANCE TABLE
                        dbAttendance = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                        where xx.FK_EmployeeID == dbLeave.FK_EmployeeID && xx.AttendDate == dbLeave.FromDate 
                                        && xx.AttendanceType == (int)mAttendanceType
                                        select xx).FirstOrDefault();
                        if (dbAttendance == null)
                            dbAttendance = new TBL_MP_HR_ManualAttendance_Master();

                        dayStart = new DateTime(dbLeave.FromDate.Year, dbLeave.FromDate.Month, dbLeave.FromDate.Day);
                        dayEnd = new DateTime(dbLeave.FromDate.Year, dbLeave.FromDate.Month, dbLeave.FromDate.Day);
                        AppCommon.SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                        dbAttendance.FK_EmployeeID = dbLeave.FK_EmployeeID;
                        dbAttendance.AttendDate = new DateTime(dbLeave.FromDate.Year, dbLeave.FromDate.Month, dbLeave.FromDate.Day);
                        dbAttendance.AttendStdInTime = dayStart;
                        dbAttendance.AttendStdOutTime = dayEnd;
                        dbAttendance.AttendInTime = (DateTime)dbLeave.FromTime;
                        dbAttendance.AttendOutTime = (DateTime)dbLeave.ToTime;
                        dbAttendance.Duration = ((TimeSpan)(dbAttendance.AttendOutTime-dbAttendance.AttendInTime)).ToString();
                        dbAttendance.FK_PreparedBy = dbLeave.PreparedBy;
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LEAVE_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Leave";
                            dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_OUTDOOR_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Outdoor";
                            dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_COMP_OFF_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "CompOff";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LATE_COMING_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Late Coming";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_EARLY_LEAVING_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Early Leaving";
                        }

                        dbAttendance.FK_LeaveApplicationID = dbLeave.PK_LeaveApplicationID;
                        
                        dbAttendance.AtWarehouse = false;
                        dbAttendance.IsActive = false;
                        dbAttendance.FK_YearId = dbLeave.FK_YearID;
                        dbAttendance.FK_BranchId = dbLeave.FK_BranchID;
                        dbAttendance.FK_CompanyId = dbLeave.FK_CompanyID;
                        dbAttendance.CreatedDateTime = AppCommon.GetServerDateTime();

                        if (dbAttendance.PK_AttendanceID == 0)
                            (new ServiceAttendance()).AddNewManualAttendance(dbAttendance);
                        else
                            (new ServiceAttendance()).UpdateMannualAttendance(dbAttendance);


                    }
                    else
                    {
                        // INSERT MULTIPLE ATTENDANCE RECORD IN ATTENDANCE TABLE BETWEEN DATES
                        #region INSERT ATTENDANCE FOR FIRST DAY
                        DateTime currDate = dbLeave.FromTime.Value.Date;
                        dbAttendance = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                        where xx.FK_EmployeeID == dbLeave.FK_EmployeeID && xx.AttendDate == dbLeave.FromDate.Date 
                                        && xx.AttendanceType == (int)mAttendanceType
                                        select xx).FirstOrDefault();
                        if (dbAttendance == null)
                            dbAttendance = new TBL_MP_HR_ManualAttendance_Master();

                        dayStart = new DateTime(currDate.Year, currDate.Month, currDate.Day);
                        dayEnd = new DateTime(currDate.Year, currDate.Month, currDate.Day);
                        AppCommon.SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                        dbAttendance.FK_EmployeeID = dbLeave.FK_EmployeeID;
                        dbAttendance.AttendDate = currDate.Date;
                        dbAttendance.AttendStdInTime = dayStart;
                        dbAttendance.AttendStdOutTime = dayEnd;
                        dbAttendance.AttendInTime = (DateTime)dbLeave.FromTime;
                        dbAttendance.AttendOutTime = dayEnd;
                        dbAttendance.Duration= ((TimeSpan)(dbAttendance.AttendOutTime - dbAttendance.AttendInTime)).ToString();
                        dbAttendance.FK_PreparedBy = dbLeave.PreparedBy;
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LEAVE_ID)
                        {
                            dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.LEAVE;
                            dbAttendance.AttendanceRemarks = "Leave";
                            dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_OUTDOOR_ID)
                        {
                            dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.OUT_DOOR;
                            dbAttendance.AttendanceRemarks = "Outdoor";
                            dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_COMP_OFF_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "CompOff";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LATE_COMING_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Late Coming";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_EARLY_LEAVING_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Early Leaving";
                        }
                        dbAttendance.FK_LeaveApplicationID = dbLeave.PK_LeaveApplicationID;
                        
                        dbAttendance.AtWarehouse = false;
                        dbAttendance.IsActive = false;
                        dbAttendance.FK_YearId = dbLeave.FK_YearID;
                        dbAttendance.FK_BranchId = dbLeave.FK_BranchID;
                        dbAttendance.FK_CompanyId = dbLeave.FK_CompanyID;
                        dbAttendance.CreatedDateTime = AppCommon.GetServerDateTime();

                        if (dbAttendance.PK_AttendanceID == 0)
                            (new ServiceAttendance()).AddNewManualAttendance(dbAttendance);
                        else
                            (new ServiceAttendance()).UpdateMannualAttendance(dbAttendance);
                        #endregion
                        
                        #region INSERT ATTENDANCE BETWEEN LEAVE DATES
                        currDate = currDate.AddDays(1);
                        bool isSandwichLeave = false;
                        while (currDate.Date< dbLeave.ToTime.Value.Date)
                        {
                            if (AppCommon.IsSunday(currDate))
                            {
                                isSandwichLeave = true;
                            }
                            if (ServiceEmployee.IsOfficeEmployee(dbLeave.FK_EmployeeID) || ServiceEmployee.IsManagementEmployee(dbLeave.FK_EmployeeID))
                            {
                                if (AppCommon.isSecondSaturday(currDate) || AppCommon.isFourthSaturday(currDate))
                                {
                                    isSandwichLeave = true;
                                }
                            }

                            if (isSandwichLeave)
                            {
                                dbAttendance = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                where xx.FK_EmployeeID == dbLeave.FK_EmployeeID && xx.AttendDate == currDate.Date
                                                && xx.AttendanceType == (int)ATTENDANCE_TYPE.SANDWICH_LEAVE
                                                select xx).FirstOrDefault();
                            }
                            else
                            {
                                dbAttendance = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                                where xx.FK_EmployeeID == dbLeave.FK_EmployeeID && xx.AttendDate == currDate
                                                && xx.AttendanceType == (int) mAttendanceType
                                                select xx).FirstOrDefault();
                            }

                            if (dbAttendance == null)
                                dbAttendance = new TBL_MP_HR_ManualAttendance_Master();

                            dayStart = new DateTime(currDate.Year, currDate.Month, currDate.Day);
                            dayEnd = new DateTime(currDate.Year, currDate.Month, currDate.Day);
                            AppCommon.SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                            dbAttendance.FK_EmployeeID = dbLeave.FK_EmployeeID;
                            dbAttendance.AttendDate = currDate.Date;
                            dbAttendance.AttendStdInTime = dayStart;
                            dbAttendance.AttendStdOutTime = dayEnd;
                            dbAttendance.AttendInTime = dayStart;
                            dbAttendance.AttendOutTime = dayEnd;
                            dbAttendance.Duration= ((TimeSpan)(dbAttendance.AttendOutTime - dbAttendance.AttendInTime)).ToString();
                            dbAttendance.FK_PreparedBy = dbLeave.PreparedBy;
                            if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LEAVE_ID)
                            {
                                dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.LEAVE;
                                dbAttendance.AttendanceRemarks = "Leave";
                                dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                            }
                            if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_OUTDOOR_ID)
                            {
                                dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.OUT_DOOR;
                                dbAttendance.AttendanceRemarks = "Outdoor";
                                dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                            }
                            if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_COMP_OFF_ID)
                            {
                                dbAttendance.AttendanceType = (int)mAttendanceType;
                                dbAttendance.AttendanceRemarks = "CompOff";
                            }
                            if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LATE_COMING_ID)
                            {
                                dbAttendance.AttendanceType = (int)mAttendanceType;
                                dbAttendance.AttendanceRemarks = "Late Coming";
                            }
                            if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_EARLY_LEAVING_ID)
                            {
                                dbAttendance.AttendanceType = (int)mAttendanceType;
                                dbAttendance.AttendanceRemarks = "Early Leaving";
                            }
                            //if (isSandwichLeave)
                            //{
                            //    dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.SANDWICH_LEAVE;
                            //}

                            dbAttendance.FK_LeaveApplicationID = dbLeave.PK_LeaveApplicationID;
                            
                            dbAttendance.AtWarehouse = false;
                            dbAttendance.IsActive = false;
                            dbAttendance.FK_YearId = dbLeave.FK_YearID;
                            dbAttendance.FK_BranchId = dbLeave.FK_BranchID;
                            dbAttendance.FK_CompanyId = dbLeave.FK_CompanyID;
                            dbAttendance.CreatedDateTime = AppCommon.GetServerDateTime();

                            if (dbAttendance.PK_AttendanceID == 0)
                                (new ServiceAttendance()).AddNewManualAttendance(dbAttendance);
                            else
                                (new ServiceAttendance()).UpdateMannualAttendance(dbAttendance);

                            currDate = currDate.AddDays(1);
                        }
                        #endregion

                        #region INSERT INTO ATTENDANCE LAST DAY LEAVE
                        currDate = dbLeave.ToTime.Value.Date;
                        dbAttendance = (from xx in _dbContext.TBL_MP_HR_ManualAttendance_Master
                                        where xx.FK_EmployeeID == dbLeave.FK_EmployeeID && xx.AttendDate == currDate
                                        && xx.AttendanceType == (int)mAttendanceType
                                        select xx).FirstOrDefault();
                        if (dbAttendance == null)
                            dbAttendance = new TBL_MP_HR_ManualAttendance_Master();

                        dayStart = new DateTime(currDate.Year, currDate.Month, currDate.Day);
                        dayEnd = new DateTime(currDate.Year, currDate.Month, currDate.Day);
                        AppCommon.SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                        dbAttendance.FK_EmployeeID = dbLeave.FK_EmployeeID;
                        dbAttendance.AttendDate = currDate.Date;
                        dbAttendance.AttendStdInTime = dayStart;
                        dbAttendance.AttendStdOutTime = dayEnd;
                        dbAttendance.AttendInTime = dayStart;
                        dbAttendance.AttendOutTime = dbLeave.ToTime.Value;
                        dbAttendance.FK_PreparedBy = dbLeave.PreparedBy;
                        dbAttendance.Duration= ((TimeSpan)(dbAttendance.AttendOutTime - dbAttendance.AttendInTime)).ToString();
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LEAVE_ID)
                        {
                            dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.LEAVE;
                            dbAttendance.AttendanceRemarks = "Leave";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_OUTDOOR_ID)
                        {
                            dbAttendance.AttendanceType = (int)ATTENDANCE_TYPE.OUT_DOOR;
                            dbAttendance.AttendanceRemarks = "Outdoor";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_COMP_OFF_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "CompOff";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_LATE_COMING_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Late Coming";
                        }
                        if (dbLeave.FK_UserList_LeaveFormTypeID == this.LEAVE_TYPE_EARLY_LEAVING_ID)
                        {
                            dbAttendance.AttendanceType = (int)mAttendanceType;
                            dbAttendance.AttendanceRemarks = "Early Leaving";
                        }
                        dbAttendance.FK_LeaveApplicationID = dbLeave.PK_LeaveApplicationID;
                        dbAttendance.FK_LeaveTypeID = dbLeave.fK_UsrLst_LeaveTypeID;
                        dbAttendance.AtWarehouse = false;
                        dbAttendance.IsActive = false;
                        dbAttendance.FK_YearId = dbLeave.FK_YearID;
                        dbAttendance.FK_BranchId = dbLeave.FK_BranchID;
                        dbAttendance.FK_CompanyId = dbLeave.FK_CompanyID;
                        dbAttendance.CreatedDateTime = AppCommon.GetServerDateTime();

                        if (dbAttendance.PK_AttendanceID == 0)
                            (new ServiceAttendance()).AddNewManualAttendance(dbAttendance);
                        else
                            (new ServiceAttendance()).UpdateMannualAttendance(dbAttendance);

                        #endregion


                    }

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::UpdateAttendanceForLeaveApplication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ApproveAttendanceForLeave(int leaveID)
        {
            try
            {
                List<TBL_MP_HR_ManualAttendance_Master> lst = _dbContext.TBL_MP_HR_ManualAttendance_Master.Where(x => x.FK_LeaveApplicationID == (int?)leaveID).ToList();
                foreach (TBL_MP_HR_ManualAttendance_Master item in lst)
                {
                    item.IsActive = true;
                    item.isLeaveRejected = false;
                }
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::ApproveAttendanceForLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RejectAttendanceForLeave(int leaverejID)
        {
            try
            {
                List<TBL_MP_HR_ManualAttendance_Master> lst = _dbContext.TBL_MP_HR_ManualAttendance_Master.Where(x => x.FK_LeaveApplicationID == (int?)leaverejID).ToList();
                foreach (TBL_MP_HR_ManualAttendance_Master item in lst)
                {
                    item.IsActive = false;
                    item.isLeaveRejected = true;

                }
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::ApproveAttendanceForLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool DeleteEmployeeLeave(int leaveID)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LeaveApplication model = _dbContext.TBL_MP_HR_LeaveApplication.Where(x => x.PK_LeaveApplicationID == leaveID).FirstOrDefault();
                model.IsDeleted = true;
                _dbContext.SaveChanges();
                // DELETE ATTENDANCE ENTRY FOR THE SELECTED LEAVE
                string strQuery = string.Format("DELETE FROM TBL_MP_HR_ManualAttendance_Master where FK_LeaveApplicationID={0}", leaveID);
                _dbContext.Database.ExecuteSqlCommand(strQuery);
                _dbContext.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveApplication::DeleteEmployeeLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }

    }
}

