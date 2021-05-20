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
    public class ServiceLoanDisbursement : DefaultService
    {
        public int LOAN_DISBURSEMENT_STATUS_PENDING_ID = 0;
        public int LOAN_DISBURSEMENT_APPROVED_ID = 0;
        public int LOAN_DISBURSEMENT_REJECTED_ID = 0;

        public ServiceLoanDisbursement(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
            PopulateStatusVariables();
        }
        public ServiceLoanDisbursement()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
            PopulateStatusVariables();
        }
        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                LOAN_DISBURSEMENT_STATUS_PENDING_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusPending_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                LOAN_DISBURSEMENT_APPROVED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusApproved_CategoryID).FirstOrDefault().DEFAULT_VALUE;
                LOAN_DISBURSEMENT_REJECTED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusRejected_CategoryID).FirstOrDefault().DEFAULT_VALUE;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanDisbursement::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<LoanDisbursementModel> GetAllLoanDisbursementList()
        {
            List<LoanDisbursementModel> list = new List<LoanDisbursementModel>();
            try
            {
                List<TBL_MP_HR_LoanDisbursement> dbList = _dbContext.TBL_MP_HR_LoanDisbursement.Where(x => x.IsClosed == false && x.IsDeleted==false).OrderByDescending(x => x.DisbursementDate).ToList();
                foreach (TBL_MP_HR_LoanDisbursement item in dbList)
                {
                    string strDescription = string.Empty;
                    LoanDisbursementModel model = new LoanDisbursementModel();
                    model.DisbursementID = item.PK_LoanDisbursementID;
                    model.DisbursementDate = item.DisbursementDate;
                    model.AmountGiven = item.LoanAmount;
                    model.AmountDue = 0;
                    model.AmountReceived = 0;
                    model.DisbursementInfo = string.Format("{0} E.M.Is of Rs. {1:0.00} @{2}\nfrom {3}\n", item.NoOfInstallment, item.InstallmentAmount, item.InterestRate, item.InstallmentStartDate);
                    model.EmployeeInfo = string.Format("{0} [{1}]", item.TBL_MP_Master_Employee.EmployeeName, item.TBL_MP_Master_Employee.EmployeeCode);
                    model.LoanInfo = string.Format("{0} dt. {1}\n{2}", item.TBL_MP_HR_LoanRequestApplication.LoanRequestNo, item.TBL_MP_HR_LoanRequestApplication.LoanRequestDate.ToString("dd MMM yyyy"), item.TBL_MP_HR_LoanRequestApplication.Remarks);
                    model.StatusInfo = string.Format("{0}", item.TBL_MP_Admin_UserList.Admin_UserList_Desc);

                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanDisbursement::GetAllLoanDisbursementList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public int AddNewLoanDisbursement(TBL_MP_HR_LoanDisbursement model)
        {
            int newID = 0;
            try
            {
                model.IsClosed = false;
                model.IsDeleted = false;
                model.ApprovalStatus = LOAN_DISBURSEMENT_STATUS_PENDING_ID;
                _dbContext.TBL_MP_HR_LoanDisbursement.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_LoanDisbursementID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanDisbursement::AddNewLoanDisbursement", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateLoanDisbursement(TBL_MP_HR_LoanDisbursement model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LoanDisbursement dbModel = _dbContext.TBL_MP_HR_LoanDisbursement.Where(x => x.PK_LoanDisbursementID == model.PK_LoanDisbursementID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_EmployeeID = model.FK_EmployeeID;
                    dbModel.DisbursementDate = model.DisbursementDate;
                    dbModel.LoanAmount = model.LoanAmount;
                    dbModel.InterestRate = model.InterestRate;
                    dbModel.NoOfInstallment = model.NoOfInstallment;
                    dbModel.InstallmentAmount = model.InstallmentAmount;
                    dbModel.InstallmentStartDate = model.InstallmentStartDate;
                    dbModel.FK_PreparedBy = model.FK_PreparedBy;
                    dbModel.FK_ApprovedBy = model.FK_ApprovedBy;
                    dbModel.FK_LoanRequestID = model.FK_LoanRequestID;

                    dbModel.Remarks = model.Remarks;
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
                MessageBox.Show(errMessage, "ServiceLoanDisbursement::UpdateLoanDisbursement", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public bool DeleteLoanDisbursement(int loanDisburseID)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LoanDisbursement model = _dbContext.TBL_MP_HR_LoanDisbursement.Where(x => x.PK_LoanDisbursementID == loanDisburseID).FirstOrDefault();
                if (model != null)
                {
                    model.IsDeleted = true;
                   //model.DeletedBy = deletedBy;
                   // model.DeleteDatetime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanDisbursement::DeleteLoanDisbursement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_HR_LoanDisbursement GetLoanDisbursementInfoDbRecord(int LoanDisbursementID)
        {
            TBL_MP_HR_LoanDisbursement model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_LoanDisbursement.Where(x => x.PK_LoanDisbursementID == LoanDisbursementID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLoanDisbursement ::GetLoanDisbursementInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }


    }
}
