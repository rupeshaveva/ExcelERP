using libERP.MODELS;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{

    public class ServiceLeaveConfiguration : DefaultService
    {
        public event EmployeeLeaveConfigurationCompletedEventHandler OnEmployeeLeaveConfigurationCompleted;
        public ServiceLeaveConfiguration(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceLeaveConfiguration()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<LeaveConfigurationModel> GetAllLeavesConfigurationForBranchAndYear(int branchId, int yearID)
        {
            List<LeaveConfigurationModel> lstLeaves = new List<LeaveConfigurationModel>();
            try
            {
                List< TBL_MP_HR_LeaveConfiguration> lst = _dbContext.TBL_MP_HR_LeaveConfiguration.Where(x => x.FK_FinYearID == yearID && x.FK_BranchID == branchId).ToList();
                foreach (TBL_MP_HR_LeaveConfiguration item in lst)
                {
                    LeaveConfigurationModel model = new LeaveConfigurationModel();
                    model.LeaveID = item.PK_LeaveID;
                    model.LeaveTypeID = item.FK_LeaveTypeID;
                    model.LeaveTypeName = item.TBL_MP_Admin_UserList.Admin_UserList_Desc;
                    model.MaxDaysAllow = item.MaxDaysAllow;
                    model.LeaveEnchashable = item.LeaveEnchashable;
                    model.CarryForwardLeave = item.CarryForwardLeave;
                    model.CarryForwardLimitDays = item.CarryForwardLimitDays;
                    model.ApplicableInProbation = item.ApplicableInProbation;
                    model.EncashableSalaryHeadIDs = item.EncashableSalaryHeadIDs;
                    model.EncashableSalaryHeadNames = item.EncashableSalaryHeadNames;
                    model.IsActive = item.IsActive;

                    lstLeaves.Add(model);


                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveConfiguration::GetAllLeavesConfigurationForBranchAndYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLeaves;

        }
        public List<TBL_MP_HR_LeaveConfiguration> GetAllLeavesDBConfigurationForBranchAndYear(int branchId, int yearID)
        {
            List<TBL_MP_HR_LeaveConfiguration> lstLeaves = new List<TBL_MP_HR_LeaveConfiguration>();
            try
            {
                lstLeaves = _dbContext.TBL_MP_HR_LeaveConfiguration.Where(x => x.FK_FinYearID == yearID && x.FK_BranchID == branchId).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveConfiguration::GetAllLeavesDBConfigurationForBranchAndYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLeaves;

        }
        public TBL_MP_HR_LeaveConfiguration GetLeaveInfoDbRecord(int LeaveID)
        {
            TBL_MP_HR_LeaveConfiguration model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_LeaveConfiguration.Where(x => x.PK_LeaveID == LeaveID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveConfiguration::GetLeaveInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public int AddNewLeaveConfiguration(TBL_MP_HR_LeaveConfiguration model)
        {
            int newID = 0;
            try
            {

                _dbContext.TBL_MP_HR_LeaveConfiguration.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_LeaveID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveConfiguration::AddNewLeaveConfiguration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateLeaveConfiguration(TBL_MP_HR_LeaveConfiguration model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_LeaveConfiguration dbModel = _dbContext.TBL_MP_HR_LeaveConfiguration.Where(x => x.PK_LeaveID == model.PK_LeaveID).FirstOrDefault();
                dbModel.FK_LeaveTypeID = model.FK_LeaveTypeID;
                dbModel.MaxDaysAllow = model.MaxDaysAllow;
                dbModel.CarryForwardLeave = model.CarryForwardLeave;
                dbModel.CarryForwardLimitDays = model.CarryForwardLimitDays;
                dbModel.ApplicableInProbation = model.ApplicableInProbation;
                dbModel.LeaveEnchashable = model.LeaveEnchashable;
                dbModel.EncashableSalaryHeadIDs = model.EncashableSalaryHeadIDs;
                dbModel.EncashableSalaryHeadNames = model.EncashableSalaryHeadNames;
                dbModel.IsActive = model.IsActive;
                dbModel.FK_FinYearID = model.FK_FinYearID;
                dbModel.FK_BranchID = model.FK_BranchID;
               _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveConfiguration::UpdateLeaveConfiguration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public bool DeleteLeaveConfiguration(int ConfigID)
      {
          bool result = false;
          try
          {
              TBL_MP_HR_LeaveConfiguration model = _dbContext.TBL_MP_HR_LeaveConfiguration.Where(x => x.PK_LeaveID == ConfigID).FirstOrDefault();
              model.IsActive = false;
              _dbContext.SaveChanges();
              result = true;
          }
          catch (Exception ex)
          {
              string errMessage = ex.Message;
              if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
              MessageBox.Show(errMessage, "ServiceLeaveConfiguration::DeleteLeaveConfiguration", MessageBoxButtons.OK, MessageBoxIcon.Error);

          }
          return result;
      }

        public void GenerateEmployeeLeaveConfigurationsForFinYear(int companyID, int branchID, int yearID)
        {
            try
            {
                int idx = 1;
                List<TBL_MP_HR_LeaveConfiguration> lstMasterLeaves = (from xx in _dbContext.TBL_MP_HR_LeaveConfiguration
                                                                      where xx.FK_FinYearID == yearID && xx.FK_BranchID == branchID select xx).ToList();
                foreach (SelectListItem emp in (new ServiceEmployee()).GetAllActiveEmployees())
                {
                    string strMessage = string.Empty;
                    strMessage =string.Format("\n{0}: {1}\n",idx++, emp.Description.ToUpper());
                    foreach (TBL_MP_HR_LeaveConfiguration item in lstMasterLeaves)
                    {
                        TBL_MP_Master_Employee_LeaveConfiguration confExist = 
                            (   from xx in _dbContext.TBL_MP_Master_Employee_LeaveConfiguration
                                where xx.FK_EmployeeID == emp.ID && xx.FK_FinYearID == yearID && xx.FK_LeaveTypeID == item.FK_LeaveTypeID select xx ).FirstOrDefault();
                        if (confExist==null)
                        {
                            TBL_MP_Master_Employee_LeaveConfiguration newConf = new TBL_MP_Master_Employee_LeaveConfiguration();
                            newConf.ApplicableInProbation = item.ApplicableInProbation;
                            newConf.CarryForwardLeave = item.CarryForwardLeave;
                            newConf.CarryForwardLimitDays = item.CarryForwardLimitDays;
                            newConf.EncashableSalaryHeadIDs = item.EncashableSalaryHeadIDs;
                            newConf.EncashableSalaryHeadNames = item.EncashableSalaryHeadNames;
                            newConf.FK_BranchID = branchID;
                            newConf.FK_FinYearID = yearID;
                            newConf.FK_EmployeeID = emp.ID;
                            newConf.FK_LeaveTypeID = item.FK_LeaveTypeID;
                            newConf.IsActive = true;
                            newConf.LeaveEnchashable = item.LeaveEnchashable;
                            newConf.LeavesEarned = 0;
                            newConf.MaxDaysAllow = item.MaxDaysAllow;

                            //int totalLeavesTaken= (
                            //    from xx in _dbContext.TBL_MP_HR_LeaveApplication
                            //    where xx.FK_EmployeeID == emp.ID && xx.fK_UsrLst_LeaveTypeID == item.FK_LeaveTypeID && xx.FK_YearID == yearID
                            //    select xx.NoOfDays
                            //    ).Sum();

                            (new ServiceEmployee()).AddNewEmpLeaveConfiguration(newConf);
                        }
                    }
                    strMessage += string.Format("Success.......\n");
                    if (OnEmployeeLeaveConfigurationCompleted != null)
                    {
                        OnEmployeeLeaveConfigurationCompleted(this, new MODELS.COMMON.EventArguementModel() { Message = strMessage });
                    }
                }

                if (OnEmployeeLeaveConfigurationCompleted != null)
                {
                    OnEmployeeLeaveConfigurationCompleted(this, new MODELS.COMMON.EventArguementModel() { Message = "Completed Leave configuration.\n\n" });
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceLeaveConfiguration::GenerateEmployeeLeaveConfigurationsForFinYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    
    }
}
