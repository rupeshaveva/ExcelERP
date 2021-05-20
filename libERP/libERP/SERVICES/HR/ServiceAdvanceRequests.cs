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
    public class ServiceAdvanceRequest : DefaultService
    {
        public int REQUEST_STATUS_PENDING_ID = 0;
        public int REQUEST_STATUS_APPROVED_ID = 0;
        public int REQUEST_STATUS_REJECTED_ID = 0;
       
        public ServiceAdvanceRequest(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
            PopulateStatusVariables();
        }
        public ServiceAdvanceRequest()
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
                MessageBox.Show(errMessage, "ServiceLeaveApplication::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<AdvanceRequestModel> GetAllAdvanceRequestsToEmployee(int empoyeeID)
        {
            List< AdvanceRequestModel> lst = new List<AdvanceRequestModel>();
            try
            {
                List<vAdvanceRequestApplication> lstRequests = _dbContext.vAdvanceRequestApplications.Where(x => x.FK_RequestTo == empoyeeID).OrderByDescending(x => x.RequestDate).ToList();
                foreach (vAdvanceRequestApplication item in lstRequests)
                {
                    AdvanceRequestModel model = new AdvanceRequestModel();
                    model.PK_AdvancRequestID = item.PK_AdvancRequestID;
                    model.RequestDate = item.RequestDate;
                    model.RequestedAmount = item.RequestedAmount;
                    model.Remarks = item.Remarks;
                    model.RemarksApproved = item.RemarksApproved;
                    model.FK_RequestTo = item.FK_RequestTo;
                    model.FK_EmployeeID = item.FK_EmployeeID;
                    model.FK_ApprovedBy = item.FK_ApprovedBy;
                    model.EmployeeName = item.EmployeeName;
                    model.ApproverName = item.ApproverName;
                    model.ApprovedAmount = item.ApprovedAmount;
                    model.ApprovalStatus = item.ApprovalStatus;
                    model.ApprovalDate = item.ApprovalDate;
                    model.AdvanceRequestNo = item.AdvanceRequestNo;
                    model.Fk_BranchID = item.Fk_BranchID;
                    model.FK_CompanyID = item.FK_CompanyID;
                    model.Fk_YearID = item.Fk_YearID;
                    model.IsDeleted = item.IsDeleted;
                    model.StatusDescription = item.StatusDescription;
                    
                     lst.Add(model);

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAllAdvanceRequestsOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<vAdvanceRequestApplication> GetAllAdvanceRequestApplicationsForYear(int yearID)
        {
            List<vAdvanceRequestApplication> lstRequest = new List<vAdvanceRequestApplication>();

            try
            {
                lstRequest = _dbContext.vAdvanceRequestApplications.Where(x => x.Fk_YearID == yearID).OrderByDescending(x => x.RequestDate).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAllAdvanceRequestApplicationsForYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRequest;
        }
        public List<vAdvanceRequestApplication> GetAllAdvanceRequestsOfEmployee(int empID)
        {
            List<vAdvanceRequestApplication> dbList = new List<vAdvanceRequestApplication>();

            try
            {
                dbList = _dbContext.vAdvanceRequestApplications.Where(x => x.FK_RequestTo == empID).OrderByDescending(x => x.RequestDate).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAllAdvanceRequestsToEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbList;
        }

        public string GenerateNewAdvanceRequestNumber(int currFinYear, int currBrachID, int companyID)
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
                                                                        where xx.fk_FormID == (int)DB_FORM_IDs.ADVANCE_REQUEST &&
                                                                        xx.Fk_YearID == currFinYear &&
                                                                        xx.Fk_BranchID == currBrachID
                                                                        select xx).FirstOrDefault();


                if (objAdvanceSetup == null)
                {
                    string strMessage = "Unable to locate Voucher No. setup for the selected Financial Year or Branch";
                    MessageBox.Show(strMessage, "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_HR_AdvanceRequestApplication WHERE FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objAdvanceSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.ADVANCE_REQUEST &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_HR_AdvanceRequestApplication lastLeavePrevYear = (from xx in _dbContext.TBL_MP_HR_AdvanceRequestApplication
                                                                    where xx.Fk_YearID == currFinYear - 1 &&
                                                               xx.Fk_BranchID == currBrachID &&
                                                               xx.FK_CompanyID == companyID
                                                                    orderby xx.RequestDate descending
                                                                    select xx).FirstOrDefault();
                    if (lastLeavePrevYear != null)
                    {
                        string lstnumber = lastLeavePrevYear.AdvanceRequestNo.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
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
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GenerateNewAdvanceRequestNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }

        public TBL_MP_HR_AdvanceRequestApplication GetAdvanceRequestInfoDbRecord(int AdvRequestID)
        {
            TBL_MP_HR_AdvanceRequestApplication model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_AdvanceRequestApplication.Where(x => x.PK_AdvancRequestID == AdvRequestID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAdvanceRequestInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public vAdvanceRequestApplication GetAdvanceRequestViewDbRecord(int AdvRequestID)
        {
            vAdvanceRequestApplication model = null;
            try
            {
                model = _dbContext.vAdvanceRequestApplications.Where(x => x.PK_AdvancRequestID == AdvRequestID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAdvanceRequestViewDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int GetAdvanceRequestApplicationStatus(int applicationID)
        {
            int statusID = 0;
            try
            {
                TBL_MP_HR_AdvanceRequestApplication model = _dbContext.TBL_MP_HR_AdvanceRequestApplication.Where(x => x.PK_AdvancRequestID == applicationID).FirstOrDefault();
                if (model != null)
                {
                    statusID = model.ApprovalStatus;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAdvanceRequestApplicationStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return statusID;
        }
        public int AddNewAdvanceRequest(TBL_MP_HR_AdvanceRequestApplication model)
        {
            int newID = 0;
            try
            {
                model.AdvanceRequestNo = this.GenerateNewAdvanceRequestNumber(model.Fk_YearID, model.Fk_BranchID, model.FK_CompanyID);
                model.ApprovalStatus = REQUEST_STATUS_PENDING_ID;
                model.IsDeleted = false;
                model.ApprovalDate = null;
                model.FK_ApprovedBy = null;
                model.RemarksApproved = string.Empty;
                _dbContext.TBL_MP_HR_AdvanceRequestApplication.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_AdvancRequestID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::AddNewAdvanceRequest", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateAdvanceRequest(TBL_MP_HR_AdvanceRequestApplication model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_AdvanceRequestApplication dbModel = _dbContext.TBL_MP_HR_AdvanceRequestApplication.Where(x => x.PK_AdvancRequestID == model.PK_AdvancRequestID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_EmployeeID = model.FK_EmployeeID;
                    dbModel.FK_RequestTo = model.FK_RequestTo;
                    dbModel.RequestDate = model.RequestDate;
                    dbModel.ExpectedDate = model.ExpectedDate;
                    dbModel.RequestedAmount = model.RequestedAmount;
                    dbModel.Remarks = model.Remarks;

                    dbModel.AdvanceRequestNo = model.AdvanceRequestNo;
                    dbModel.ApprovalDate = model.ApprovalDate;
                    dbModel.ApprovalStatus = model.ApprovalStatus;
                    dbModel.ApprovedAmount = model.ApprovedAmount;
                    dbModel.FK_ApprovedBy = model.FK_ApprovedBy;
                    dbModel.Fk_BranchID = model.Fk_BranchID;
                    dbModel.FK_CompanyID = model.FK_CompanyID;
                    dbModel.Fk_YearID = model.Fk_YearID;
                    dbModel.IsDeleted = model.IsDeleted;
                    dbModel.RemarksApproved = model.RemarksApproved;
                   
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
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::UpdateAdvanceRequest", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public List<AdvanceRequestModel> GetAllAdvanceRequestsOfEmployeeForStatus(int empoyeeID)
        {
            List<AdvanceRequestModel> lst = new List<AdvanceRequestModel>();
            try
            {
                List<vAdvanceRequestApplication> lstRequests = _dbContext.vAdvanceRequestApplications.Where(x => x.FK_EmployeeID == empoyeeID && x.IsDeleted == false).OrderByDescending(x => x.RequestDate).ToList();
                foreach (vAdvanceRequestApplication item in lstRequests)
                {
                    AdvanceRequestModel model = new AdvanceRequestModel();
                    model.PK_AdvancRequestID = item.PK_AdvancRequestID;
                    model.RequestDate = item.RequestDate;
                    model.RequestedAmount = item.RequestedAmount;
                    model.Remarks = item.Remarks;
                    model.RemarksApproved = item.RemarksApproved;
                    model.FK_RequestTo = item.FK_RequestTo;
                    model.FK_EmployeeID = item.FK_EmployeeID;
                    model.FK_ApprovedBy = item.FK_ApprovedBy;
                    model.EmployeeName = item.EmployeeName;
                    model.ApproverName = item.ApproverName;
                    model.ApprovedAmount = item.ApprovedAmount;
                    model.ApprovalStatus = item.ApprovalStatus;
                    model.ApprovalDate = item.ApprovalDate;
                    model.AdvanceRequestNo = item.AdvanceRequestNo;
                    model.StatusDescription = item.StatusDescription;
                    
                 lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::GetAllAdvanceRequestsOfEmployeeForStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public bool DeleteAdvancedRequest(int AdvcancedID)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_AdvanceRequestApplication model = _dbContext.TBL_MP_HR_AdvanceRequestApplication.Where(x => x.PK_AdvancRequestID == AdvcancedID).FirstOrDefault();
                model.IsDeleted = true;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAdvanceRequest::DeleteAdvancedRequest", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }

       
    }
}
