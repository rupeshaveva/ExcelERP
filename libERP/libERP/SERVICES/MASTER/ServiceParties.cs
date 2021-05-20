
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.MASTER
{
    public class ServiceParties : DefaultService 
    {
        public ServiceParties(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceParties()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<SelectListItem> GetAllParties(string partyType)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<Tbl_MP_Master_Party> lstDB = _dbContext.Tbl_MP_Master_Party.Where(x => x.PartyType == partyType).OrderBy(x => x.PartyName).ToList();
                foreach (Tbl_MP_Master_Party item in lstDB)
                {
                    SelectListItem model = new SelectListItem()
                    {
                        ID = item.PK_PartyId,
                        Description = string.Format("{0} ({1})\nEmail: {2}  Website: {3}\nGSTIN: {4}", item.PartyName, item.PartyCode, item.EmailID, item.Website,item.GSTNO),
                        Code = item.PartyCode,
                        IsActive= (bool)item.IsActive
                    };
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllParties", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return lst;
        }
        public List<SelectListItem> GetAllActiveParties(string partyType)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try 
            {
                List<Tbl_MP_Master_Party> lstDB =(from xx in _dbContext.Tbl_MP_Master_Party where xx.PartyType == partyType && xx.IsActive==true orderby xx.PartyName select xx  ).ToList();
                foreach (Tbl_MP_Master_Party item in lstDB)
                {
                    SelectListItem model = new SelectListItem()
                    {
                        ID = item.PK_PartyId,
                        Description = string.Format("{0} ({1})\nEmail: {2}  Website: {3}\nGSTIN: {4}", item.PartyName, item.PartyCode, item.EmailID, item.Website, item.GSTNO),
                        Code = item.PartyCode,
                        IsActive = (bool)item.IsActive
                    };
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllActiveParties", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return lst;
        }
        public BindingList<MultiSelectListItem> GetAllPartiesOfTypeBindingListMultiSelect(string strType)
        {
            BindingList<MultiSelectListItem> lst = new BindingList<MultiSelectListItem>();
            try
            {
                List<Tbl_MP_Master_Party> lstDB =(from xx in _dbContext.Tbl_MP_Master_Party
                                                  where xx.PartyType == strType && xx.IsActive == true orderby xx.PartyName select xx ).ToList();
                foreach (Tbl_MP_Master_Party item in lstDB)
                {
                    MultiSelectListItem model = new MultiSelectListItem()
                    {
                        ID = item.PK_PartyId,
                        Description = string.Format("{0} ({1})\nEmail: {2}  Website: {3}\nGSTIN: {4}", item.PartyName, item.PartyCode, item.EmailID, item.Website, item.GSTNO),
                        Code = item.PartyCode,
                        Selected = false
                    };
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllPartiesOfTypeBindingListMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lst;
        }
        public List<MultiSelectListItem> GetAllPartiesMultiselect(string partyType)
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {
                List<Tbl_MP_Master_Party> lstDB = _dbContext.Tbl_MP_Master_Party.Where(x => x.PartyType == partyType).Where(X => X.IsActive == true).OrderBy(x => x.PartyName).ToList();
                foreach (Tbl_MP_Master_Party item in lstDB)
                {
                    MultiSelectListItem model = new MultiSelectListItem()
                    {
                        ID = item.PK_PartyId,
                        Description = string.Format("{0} ({1})\nEmail: {2}  Website: {3}\nGSTIN: {4}", item.PartyName, item.PartyCode, item.EmailID, item.Website, item.GSTNO),
                        Code = item.PartyCode
                    };
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllPartiesMultiselect", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return lst;
        }

        public int AddNewParty(Tbl_MP_Master_Party model)
        {
            try
            {
                model.PartyCode = this.GenerateNewPartyCode(model.PartyType);
                model.CreatedDatetime = AppCommon.GetServerDateTime();
                _dbContext.Tbl_MP_Master_Party.Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::AddNewParty", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return model.PK_PartyId;
        }
        public int UpdateParty(Tbl_MP_Master_Party model)
        {
            try
            {
                //model.LastModifiedBy = Program.CURR_USER.EmployeeID;
                model.LastModifiedDate = AppCommon.GetServerDateTime();
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::UpdateParty", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return model.PK_PartyId;
        }
        public bool DeleteParty(int partyID, string reason, int empID)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Party dbParty = _dbContext.Tbl_MP_Master_Party.Where(x => x.PK_PartyId == partyID).FirstOrDefault();
                dbParty.DeleteDateTime = AppCommon.GetServerDateTime();
                dbParty.DeletedBy = empID;
                dbParty.IsActive = false;
                dbParty.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::DeleteParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteParty(int partyID, string reason)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Party editItem = _dbContext.Tbl_MP_Master_Party.Where(x => x.PK_PartyId == partyID).FirstOrDefault();
                editItem.DeleteDateTime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::UndeleteParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string GenerateNewPartyCode(string partyType)
        {
            string newCode = string.Empty;
            try
            {
                int cnt = _dbContext.Tbl_MP_Master_Party.Where(x => x.PartyType == partyType).Count();
                cnt++;
                newCode = string.Format("{0}{1}",partyType, cnt.ToString().PadLeft(5, '0'));
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GenerateNewPartyCode", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newCode;
        }

        public Tbl_MP_Master_Party GetPartyByPartyID(int partyID)
        {
            return _dbContext.Tbl_MP_Master_Party.Where(x => x.PK_PartyId == partyID).FirstOrDefault();
        }
        public string GetPartyNameByPartyID(int partyID)
        {
            string strName = string.Empty;
            Tbl_MP_Master_Party model = this.GetPartyByPartyID(partyID);
            if (model != null)
            {
                strName = model.PartyName;
            }
            return strName;
        }
        public Tbl_MP_Master_Party GetPartyByPartyName(string partyName)
        {
            return _dbContext.Tbl_MP_Master_Party.Where(x => x.PartyName == partyName).FirstOrDefault();
        }

        #region PARTY ADDRESSES
        public List<SelectListItem> GetAllAddressesOfParty(int partyID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<Tbl_MP_Master_Party_Address> lstDB = _dbContext.Tbl_MP_Master_Party_Address.Where(x => x.FK_PartyID == partyID).ToList();
                foreach (Tbl_MP_Master_Party_Address item in lstDB)
                {
                    SelectListItem address = new SelectListItem() { ID = item.PK_AddressID };
                    string strDescription = item.Address;
                    strDescription += string.Format("\n{2}, {1}, {0}", item.TBL_MP_Master_Country.CountryName, item.TBL_MP_Master_State.StateName, item.TBL_MP_Master_City.CityName);
                    strDescription += string.Format("\nPIN: {0}\n", item.PIN_Code);
                    strDescription += (item.IsActive) ? "Active" : "Deactivated";
                    address.Description = strDescription;
                    address.IsActive = item.IsActive;
                    lst.Add(address);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllAddressesOfParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllPartyAddressesForSelection(int partyID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<Tbl_MP_Master_Party_Address> lstDB = _dbContext.Tbl_MP_Master_Party_Address.Where(x => x.FK_PartyID == partyID).ToList();
                foreach (Tbl_MP_Master_Party_Address item in lstDB)
                {
                    SelectListItem address = new SelectListItem() { ID = item.PK_AddressID };
                    string strDescription = item.Address;
                    strDescription += string.Format("\n{2}, {1}, {0}", item.TBL_MP_Master_Country.CountryName, item.TBL_MP_Master_State.StateName, item.TBL_MP_Master_City.CityName);
                    strDescription += string.Format("\nPIN: {0}\n", item.PIN_Code);
                    strDescription += (item.IsActive) ? "Active" : "Deactivated";
                    address.Description = strDescription;
                    address.IsActive = true;
                    lst.Add(address);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllAddressesOfParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public Tbl_MP_Master_Party_Address GetPartyAddressForAddressID(int addID)
        {
            Tbl_MP_Master_Party_Address model = null;
            try
            {
                model = _dbContext.Tbl_MP_Master_Party_Address.Where(x => x.PK_AddressID == addID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetPartyAddressForAddressID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewPartyAddress(Tbl_MP_Master_Party_Address model)
        {
            int newID = 0;
            try
            {
                _dbContext.Tbl_MP_Master_Party_Address.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_AddressID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::AddNewPartyAddress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdatePartyAddress(Tbl_MP_Master_Party_Address model)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Party_Address dbModel = _dbContext.Tbl_MP_Master_Party_Address.Where(x => x.PK_AddressID == model.PK_AddressID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_PartyID = model.FK_PartyID;
                    dbModel.Address = model.Address;
                    dbModel.FK_CountryID = model.FK_CountryID;
                    dbModel.FK_StateID = model.FK_StateID;
                    dbModel.FK_CityID = model.FK_CityID;
                    dbModel.PIN_Code = model.PIN_Code;
                    dbModel.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::UpdatePartyAddress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region PARTY BANK DETAILS
        public List<SelectListItem> GetAllBankDetailsOfParty(int partyID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<Tbl_MP_Master_Party_BankDetail> lstDB = _dbContext.Tbl_MP_Master_Party_BankDetail.Where(x => x.FK_PartyID == partyID).ToList();
                foreach (Tbl_MP_Master_Party_BankDetail item in lstDB)
                {
                    SelectListItem selectListItem = new SelectListItem() { ID = item.PK_PartyBankID };
                    string strDescription = string.Format("A/C NO: {0} ({1})", item.AccountNo, item.TBL_MP_Admin_UserList.Admin_UserList_Desc);
                    strDescription += string.Format("\n{0} Br. ({1})", item.TBL_MP_Master_Bank.BankName, item.TBL_MP_Master_BankBranch.BranchName);
                    strDescription += string.Format("\n{0}", item.TBL_MP_Master_BankBranch.BranchAddress);
                    strDescription += string.Format("\nIFSC :{0}", item.TBL_MP_Master_BankBranch.IFSCCode);
                    selectListItem.Description = strDescription;
                    selectListItem.IsActive = item.IsActive;//YES IT IS
                    lst.Add(selectListItem);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllBankDetailsOfParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public Tbl_MP_Master_Party_BankDetail GetPartyBankDBRecordByPartyBankID(int partybankID)
        {
            Tbl_MP_Master_Party_BankDetail model = null;
            try
            {
                model = _dbContext.Tbl_MP_Master_Party_BankDetail.Where(x => x.PK_PartyBankID == partybankID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetPartyBankDBRecordByPartyBankID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewPartyBankDetail(Tbl_MP_Master_Party_BankDetail model)
        {
            int newID = 0;
            try
            {
                model.IsActive = true;
                _dbContext.Tbl_MP_Master_Party_BankDetail.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_PartyBankID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::AddNewPartyBankDetail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdatePartyBankDetail(Tbl_MP_Master_Party_BankDetail model)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Party_BankDetail dbModel = _dbContext.Tbl_MP_Master_Party_BankDetail.Where(x => x.PK_PartyBankID == model.PK_PartyBankID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_PartyID = model.FK_PartyID;
                    dbModel.FK_BankID = model.FK_BankID;
                    dbModel.FK_BankBranchID = model.FK_BankBranchID;
                    dbModel.FK_AccountType = model.FK_AccountType;
                    dbModel.AccountNo = model.AccountNo;
                    dbModel.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::UpdatePartyBankDetail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
      


    }
}
