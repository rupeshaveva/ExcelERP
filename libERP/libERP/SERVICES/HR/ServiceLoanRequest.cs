using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{
    public class ServiceLoanRequest : DefaultService
    {
        public int REQUEST_STATUS_PENDING_ID = 0;
        public int REQUEST_STATUS_APPROVED_ID = 0;
        public int REQUEST_STATUS_REJECTED_ID = 0;

        public ServiceLoanRequest(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
            PopulateStatusVariables();
        }
        public ServiceLoanRequest()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
            PopulateStatusVariables();
        }

        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                REQUEST_STATUS_PENDING_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusPending_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                REQUEST_STATUS_APPROVED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusApproved_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                REQUEST_STATUS_REJECTED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusRejected_CategoryID).FirstOrDefault().DEFAULT_VALUE;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<vLoanRequestApplication> GetAllLoanRequestsOfEmployee(int empoyeeID)
        {
            List<vLoanRequestApplication> lstLoanRequests = new List<vLoanRequestApplication>();
            try
            {
                lstLoanRequests = _dbContext.vLoanRequestApplications.Where(x => x.FK_EmployeeID == empoyeeID).OrderByDescending(x => x.LoanRequestDate).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::GetAllLoanRequestsOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLoanRequests;
        }
        public List<vLoanRequestApplication> GetAllLoanRequestApplicationsForYear(int yearID)
        {
            List<vLoanRequestApplication> lstLoanRequest = new List<vLoanRequestApplication>();

            try
            {
                lstLoanRequest = _dbContext.vLoanRequestApplications.Where(x => x.Fk_YearID == yearID).OrderByDescending(x => x.LoanRequestDate).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::GetAllLoanRequestApplicationsForYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLoanRequest;
        }
        public List<LoanRequestModel> GetAllLoanRequestsToEmployee(int empID)
        {
            List<LoanRequestModel> dbList = new List<LoanRequestModel>();

            try
            {
 //dbList = _dbContext.vLoanRequestApplications.Where(x => x.RequestTo == empID).OrderByDescending(x => x.LoanRequestDate).ToList();

                List<vLoanRequestApplication> lstRequests = _dbContext.vLoanRequestApplications.Where(x => x.RequestTo == empID).OrderByDescending(x => x.LoanRequestDate).ToList();
                foreach (vLoanRequestApplication item in lstRequests)
                {
                    LoanRequestModel model = new LoanRequestModel();
                    model.PK_LoanRequestID = item.PK_LoanRequestID;
                    model.LoanRequestNo = item.LoanRequestNo;
                    model.LoanRequestDate = item.LoanRequestDate;
                    model.Remarks = item.Remarks;
                    model.RemarksApproved = item.RemarksApproved;
                    model.RequestedLoanAmount = item.RequestedLoanAmount;
                    model.FK_EmployeeID = (int)item.FK_EmployeeID;
                    model.FK_ApprovedBy = item.FK_ApprovedBy;
                    model.EmployeeName = item.EmployeeName;
                    model.ApproverName = item.ApproverName;
                    model.ApprovedAmount = item.ApprovedAmount;
                    model.ApprovalStatus =(int) item.ApprovalStatus;
                    model.ApprovalDate = item.ApprovalDate;
                    model.RequestTo  =(int) item.RequestTo;
                    model.StatusDescription = item.StatusDescription;
                    
                     dbList.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::GetAllLoanRequestsToEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbList;
        }
        public List<SelectListItem> GetAllApprovedLoanRequests()
        {
            List<SelectListItem> lstLoanRequests = new List<SelectListItem>();
            try
            {
                lstLoanRequests = (from xx in _dbContext.TBL_MP_HR_LoanRequestApplication.AsEnumerable()
                                   where xx.ApprovalStatus == REQUEST_STATUS_APPROVED_ID
                                   select new SelectListItem()
                                   {
                                       ID = xx.pk_LoanRequestID,
                                       Description = string.Format("{0}\n{1}", xx.LoanRequestNo, xx.TBL_MP_Master_Employee.EmployeeName)
                                   }
                                 ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::GetAllApprovedLoanRequests", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLoanRequests;
        }
        public List<SelectListItem> GetAllLoanRequestsSelectList()
        {
            List<SelectListItem> lstLoanRequests = new List<SelectListItem>();
            try
            {
                lstLoanRequests = (from xx in _dbContext.TBL_MP_HR_LoanRequestApplication.AsEnumerable()
                                   where xx.ApprovalStatus == REQUEST_STATUS_APPROVED_ID
                                   select new SelectListItem()
                                   {
                                       ID = xx.pk_LoanRequestID,
                                       Description = string.Format("{0}\n{1}", xx.LoanRequestNo, xx.TBL_MP_Master_Employee.EmployeeName)
                                   }
                                 ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::GetAllLoanRequestsSelectList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLoanRequests;
        }
        public string GenerateNewLoanRequestNumber(int currFinYear, int currBrachID, int companyID)
        {
            string keyCode = string.Empty;
            int intPreviousYearCount = 0;
            int cnt;
            string strNumber;
            string strQuery = string.Empty;
            try
            {
                // 0123
                TBL_MP_Admin_VoucherNoSetup objAdvanceSetup = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.LOAN_REQUEST &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();


                if (objAdvanceSetup == null)
                {
                    string strMessage = "Unable to locate Voucher No. setup for the selected Financial Year or Branch";
                    MessageBox.Show(strMessage, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_HR_LoanRequestApplication WHERE FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objAdvanceSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.LOAN_REQUEST &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_HR_LoanRequestApplication lastLeavePrevYear = (from xx in _dbContext.TBL_MP_HR_LoanRequestApplication
                                                                          where xx.FK_YearID == currFinYear - 1 &&
                                                                        xx.FK_BranchID == currBrachID &&
                                                                        xx.FK_CompanyID == companyID
                                                                             orderby xx.LoanRequestDate descending
                                                                             select xx).FirstOrDefault();
                    if (lastLeavePrevYear != null)
                    {
                        string lstnumber = lastLeavePrevYear.LoanRequestNo.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
                        intPreviousYearCount = int.Parse(lstnumber);
                    }
                    else
                        intPreviousYearCount = 1;

                    cnt += intPreviousYearCount;
                }
                else
                {
                    cnt += (int)objAdvanceSetup.NoStartingFrom;
                }

                strNumber = cnt.ToString().PadLeft(objAdvanceSetup.NoPad, '0');
                //0083 

                keyCode += objAdvanceSetup.NoPrefix + objAdvanceSetup.NoSeperator + strNumber + objAdvanceSetup.NoSeperator + objAdvanceSetup.NoPostfix;
                // XL/SO/0083/2018-19
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanRequest::GenerateNewLoanRequestNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        public TBL_MP_HR_LoanRequestApplication GetLoanRequestInfoDbRecord(int LoanRequestID)
        {
            TBL_MP_HR_LoanRequestApplication model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_LoanRequestApplication.Where(x => x.pk_LoanRequestID == LoanRequestID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanRequest" +
                    "::GetLoanRequestInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public vLoanRequestApplication GetLoanRequestViewDbRecord(int LoanReqID)
        {
            vLoanRequestApplication model = null;
            try
            {
                model = _dbContext.vLoanRequestApplications.Where(x => x.PK_LoanRequestID == LoanReqID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanRequest::GetLoanRequestViewDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public int AddNewLoanRequest(TBL_MP_HR_LoanRequestApplication model)
        {
            int newID = 0;
            try
            {
                model.LoanRequestNo = this.GenerateNewLoanRequestNumber(model.FK_YearID, model.FK_BranchID, model.FK_CompanyID);
                model.ApprovalStatus = REQUEST_STATUS_PENDING_ID;
                model.IsDeleted = false;
                model.ApprovalDate = null;
                model.FK_ApprovedBy = null;
                model.RemarksApproved = string.Empty;
                _dbContext.TBL_MP_HR_LoanRequestApplication.Add(model);
                _dbContext.SaveChanges();
                newID = model.pk_LoanRequestID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanRequest::AddNewLoanRequest", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateLoanRequest(TBL_MP_HR_LoanRequestApplication model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LoanRequestApplication dbModel = _dbContext.TBL_MP_HR_LoanRequestApplication.Where(x => x.pk_LoanRequestID == model.pk_LoanRequestID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_EmployeeID = model.FK_EmployeeID;
                    dbModel.RequestTo = model.RequestTo;
                    dbModel.LoanRequestDate = model.LoanRequestDate;
                    dbModel.ProposedDisbursementDate = model.ProposedDisbursementDate;
                    dbModel.RequestedLoanAmount = model.RequestedLoanAmount;
                    dbModel.Remarks = model.Remarks;

                    dbModel.ApprovalDate = model.ApprovalDate;
                    dbModel.ApprovalStatus = model.ApprovalStatus;
                    dbModel.ApprovedAmount = model.ApprovedAmount;
                    dbModel.FK_ApprovedBy = model.FK_ApprovedBy;
                    dbModel.FK_BranchID = model.FK_BranchID;
                    dbModel.FK_CompanyID = model.FK_CompanyID;
                    dbModel.FK_YearID = model.FK_YearID;
                    dbModel.IsDeleted = model.IsDeleted;
                    dbModel.RemarksApproved = model.RemarksApproved;
                    dbModel.RequestTo = model.RequestTo;
                    
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
                MessageBox.Show(errMessage, "ServiceLoanRequest::UpdateLoanRequest", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public bool DeleteLoanRequest(int LoanID)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LoanRequestApplication model = _dbContext.TBL_MP_HR_LoanRequestApplication.Where(x => x.pk_LoanRequestID == LoanID).FirstOrDefault();
                model.IsDeleted = true;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanRequest::DeleteLoanRequest", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public int GetLoanRequestApplicationStatus(int applicationID)
        {
            int statusID = 0;
            try
            {
                TBL_MP_HR_LoanRequestApplication model = _dbContext.TBL_MP_HR_LoanRequestApplication.Where(x => x.pk_LoanRequestID == applicationID).FirstOrDefault();
                if (model != null)
                {
                    statusID = (int)model.ApprovalStatus;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanRequest::GetLoanRequestApplicationStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return statusID;
        }
        public List<LoanRequestModel> GetAllLoanRequestsOfEmployeeForStatus(int empoyeeID)
        {
            List<LoanRequestModel> lstLoanRequests = new List<LoanRequestModel>();
            try
            {
                //lstLoanRequests = _dbContext.vLoanRequestApplications.Where(x => x.FK_EmployeeID == empoyeeID && x.IsDeleted == false).OrderByDescending(x => x.LoanRequestDate).ToList();
                List<vLoanRequestApplication> lstRequests = _dbContext.vLoanRequestApplications.Where(x => x.FK_EmployeeID == empoyeeID && x.IsDeleted == false).OrderByDescending(x => x.LoanRequestDate).ToList();
                foreach (vLoanRequestApplication item in lstRequests)
                {
                    LoanRequestModel model = new LoanRequestModel();
                    model.PK_LoanRequestID = item.PK_LoanRequestID;
                    model.LoanRequestNo = item.LoanRequestNo;
                    model.LoanRequestDate = item.LoanRequestDate;
                    model.Remarks = item.Remarks;
                    model.RemarksApproved = item.RemarksApproved;
                    model.RequestedLoanAmount = item.RequestedLoanAmount;
                    model.FK_EmployeeID = (int)item.FK_EmployeeID;
                    model.FK_ApprovedBy = item.FK_ApprovedBy;
                    model.EmployeeName = item.EmployeeName;
                    model.ApproverName = item.ApproverName;
                    model.ApprovedAmount = item.ApprovedAmount;
                    model.ApprovalStatus = (int)item.ApprovalStatus;
                    model.ApprovalDate = item.ApprovalDate;
                    model.RequestTo =(int) item.RequestTo;
                    model.StatusDescription = item.StatusDescription;
                    model.Fk_BranchID = (int)item.Fk_BranchID;
                    model.FK_CompanyID = (int)item.FK_CompanyID;
                    model.Fk_YearID = (int)item.Fk_YearID;
                    model.IsDeleted = item.IsDeleted;
                    lstLoanRequests.Add(model);

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanApplication::GetAllLoanRequestsOfEmployeeForStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLoanRequests;
        }
    }
}
