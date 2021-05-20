using libERP.MODELS;
using libERP.MODELS.MASTER;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.MASTER
{
    public class ServiceBankMaster : DefaultService 
    {
        public ServiceBankMaster() { _dbContext = new EXCEL_ERP_TESTEntities();  }
        public ServiceBankMaster(EXCEL_ERP_TESTEntities conn) { _dbContext = conn;  }

        #region MANAGE BANK INFO
        public List<SelectListItem> GetAllBanks()
        {
            List<SelectListItem> lstBanks = new List<SelectListItem>();
            try
            {
                lstBanks = (from xx in _dbContext.TBL_MP_Master_Bank
                            orderby xx.BankName
                            select new SelectListItem() {
                                ID = xx.PK_BankID, Description=xx.BankName,IsActive=xx.IsActive
                            }).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::GetAllBanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstBanks;
        }
        public List<SelectListItem> GetAllActiveBanks()
        {
            List<SelectListItem> lstBanks = new List<SelectListItem>();
            try
            {
                lstBanks = (from xx in _dbContext.TBL_MP_Master_Bank
                            where xx.IsActive==true
                            orderby xx.BankName
                            select new SelectListItem() {
                                ID = xx.PK_BankID, Description = xx.BankName, IsActive = xx.IsActive
                            }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::GetAllBanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstBanks;
        }

        public int AddNewBank(TBL_MP_Master_Bank model)
        {
            int newID = 0;
            try
            {
                model.IsActive = true;
                _dbContext.TBL_MP_Master_Bank.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_BankID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::AddNewBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateBank(TBL_MP_Master_Bank model)
        {
            bool result=false;
            try
            {
                TBL_MP_Master_Bank dbModel = _dbContext.TBL_MP_Master_Bank.Where(x => x.PK_BankID == model.PK_BankID).FirstOrDefault();
                dbModel.BankName = model.BankName;
                dbModel.IsActive = model.IsActive;
                _dbContext.SaveChanges();
                result = true;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::UpdateBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_Master_Bank GetBankDbRecord(int bankID)
        {
            return _dbContext.TBL_MP_Master_Bank.Where(x => x.PK_BankID == bankID).FirstOrDefault();
        }

        #endregion

        #region MANAGE BANK BRANCHES
        public List<BankBranchModel> GetAllBankBranches(int bankID)
        {
            List<BankBranchModel> lstBanks = new List<BankBranchModel>();
            try
            {
                lstBanks = (from xx in _dbContext.TBL_MP_Master_BankBranch
                            where xx.FK_BankID==bankID
                            orderby xx.BranchName
                            select new BankBranchModel()
                            {
                                BankBranchID = xx.PK_BankBranchID,
                                BankID=xx.FK_BankID,
                                BankBranchName=xx.BranchName,
                                BankBranchAddress=xx.BranchAddress,
                                BankBranchLocation= xx.TBL_MP_Master_City.CityName +", "+ xx.TBL_MP_Master_State.StateName+", "+ xx.TBL_MP_Master_Country.CountryName,
                                IFSCCode=xx.IFSCCode,
                                IsActive= xx.IsActive
                            }).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::GetAllBanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstBanks;
        }
        public List<SelectListItem> GetAllActiveBankBranchesForSelection(int bankID)
        {
            List<SelectListItem> lstBanks = new List<SelectListItem>();
            try
            {
                lstBanks = (from xx in _dbContext.TBL_MP_Master_BankBranch
                            where xx.FK_BankID == bankID && xx.IsActive==true
                            orderby xx.BranchName
                            select new SelectListItem()
                            {
                                ID = xx.PK_BankBranchID,
                                Description = xx.BranchName,
                            }).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::GetAllActiveBankBranchesForSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstBanks;
        }
        public int AddNewBankBranch(TBL_MP_Master_BankBranch model)
        {
            int newID = 0;
            try
            {
                model.IsActive = true;
                _dbContext.TBL_MP_Master_BankBranch.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_BankBranchID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::AddNewBankBranch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateBankBranch(TBL_MP_Master_BankBranch model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_BankBranch dbModel = _dbContext.TBL_MP_Master_BankBranch.Where(x => x.PK_BankBranchID == model.PK_BankBranchID).FirstOrDefault();
                dbModel.BranchAddress = model.BranchAddress;
                dbModel.BranchName = model.BranchName;
                dbModel.FK_BankID = model.FK_BankID;
                dbModel.FK_CityID = model.FK_CityID;
                dbModel.FK_CountryID = model.FK_CountryID;
                dbModel.FK_StateID = model.FK_StateID;
                dbModel.IFSCCode = model.IFSCCode;
                dbModel.IsActive = model.IsActive;
                _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceBankMaster::UpdateBankBranch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_Master_BankBranch GetBankBranchDbRecord(int branchID)
        {
            return _dbContext.TBL_MP_Master_BankBranch.Where(x => x.PK_BankBranchID == branchID).FirstOrDefault();
        }
        #endregion



    }
}
