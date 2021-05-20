

using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace libERP.SERVICES.MASTER
{
    public class ServiceMASTERS : DefaultService
    {

        public ServiceMASTERS(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceMASTERS()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        #region ADMIN CATEGORIES
        public List<SelectListItem> GetAllAdminCategories()
        {
            List<SelectListItem> lstItems = null;
            try
            {
                lstItems = (from xx in _dbContext.TBL_MP_Admin_Category
                            select new SelectListItem { Description = xx.Admin_Category_Description, ID = xx.Pk_Admin_CategoryID }
                            ).ToList();

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllAdminCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstItems;
        }
        public List<SelectListItem> GetAllAdminCategoryValuesForCategory(int adminCategoryID)
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            try
            {

                List<TBL_MP_Admin_UserList> lst = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == adminCategoryID).ToList();
                foreach (TBL_MP_Admin_UserList item in lst)
                {
                    SelectListItem model = new SelectListItem { ID = item.PKID };
                    model.Description = string.Format("{0} ({1})", item.Admin_UserList_Desc, (item.IsActive == true) ? "Active" : "Deactivated");
                    lstItems.Add(model);
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllAdminCategoryValuesForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstItems;
        }
        public TBL_MP_Admin_Category GetAdminMasterDBCategory(int admincategoryID)
        {
            TBL_MP_Admin_Category model = null;
            try
            {
                model = _dbContext.TBL_MP_Admin_Category.Where(x => x.Pk_Admin_CategoryID == admincategoryID).FirstOrDefault();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAdminMasterDBCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }
        public int AddNewAdminMasterCategory(TBL_MP_Admin_Category model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Admin_Category.Add(model);
                _dbContext.SaveChanges();
                newID = model.Pk_Admin_CategoryID;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::AddNewAdminMasterCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateAdminMasterCategory(TBL_MP_Admin_Category model)
        {
            bool result = false;
            try
            {
                TBL_MP_Admin_Category dbModel = _dbContext.TBL_MP_Admin_Category.Where(x => x.Pk_Admin_CategoryID == model.Pk_Admin_CategoryID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.Admin_Category_Description = model.Admin_Category_Description;
                    dbModel.ShortCodeRequired = model.ShortCodeRequired;
                    dbModel.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::UpdateAdminMasterCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool IsShortCodeRequiredForAdminCategory(int adminCategoryID)
        {
            bool result = false;
            try
            {
                TBL_MP_Admin_Category model = _dbContext.TBL_MP_Admin_Category.Where(x => x.Pk_Admin_CategoryID == adminCategoryID).FirstOrDefault();
                if (model != null)
                    result = model.ShortCodeRequired;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::IsShortCodeRequiredForAdminCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_Admin_UserList GetAdminUserListDBCategory(int userListID)
        {
            TBL_MP_Admin_UserList model = null;
            try
            {
                model = _dbContext.TBL_MP_Admin_UserList.Where(x => x.PKID == userListID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAdminUserListDBCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }
        public int AddNewADMINUserListItem(TBL_MP_Admin_UserList model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Admin_UserList.Add(model);
                _dbContext.SaveChanges();
                newID = model.PKID;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::AddNewADMINUserListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateADMINUserListItem(TBL_MP_Admin_UserList model)
        {
            bool result = false;
            try
            {
                TBL_MP_Admin_UserList dbModel = _dbContext.TBL_MP_Admin_UserList.Where(x => x.PKID == model.PKID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.Admin_UserList_Desc = model.Admin_UserList_Desc;
                    dbModel.Fk_Admin_CategoryID = model.Fk_Admin_CategoryID;
                    dbModel.ShortCode = model.ShortCode;
                    dbModel.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;

                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::UpdateADMINUserListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region MASTER CATEGORIES
        public List<SelectListItem> GetAllMasterCategories()
        {
            List<SelectListItem> lstItems = null;
            try
            {
                lstItems = (from xx in _dbContext.TBL_MP_Master_Category
                            select new SelectListItem { Description = xx.CategoryDescription, ID = xx.pk_CategoryId }
                            ).ToList();

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllMasterCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstItems;
        }
        public TBL_MP_Master_Category GetMasterDBCategory(int masterCategoryID)
        {
            TBL_MP_Master_Category model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Category.Where(x => x.pk_CategoryId == masterCategoryID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetMasterDBCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }
        public List<SelectListItem> GetAllMasterCategoryValuesForCategory(int masterCategoryID)
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            try
            {

                List<TBL_MP_Master_UserList> lst = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == masterCategoryID).ToList();
                foreach (TBL_MP_Master_UserList item in lst)
                {
                    SelectListItem model = new SelectListItem { ID = item.pk_UserListId };
                    model.Description = string.Format("{0} ({1})", item.Description1, (item.IsActive == true) ? "Active" : "Deactivated");
                    lstItems.Add(model);
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllMasterCategoryValuesForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstItems;
        }
        public int AddNewMASTERUserListItem(int masterCategory, string categoryName, bool isActive, int companyID,int BranchID)
        {
            int newID = 0;
            try
            {
                TBL_MP_Master_UserList model = new TBL_MP_Master_UserList()
                {
                    Description1 = categoryName,
                    fk_CategoryId = masterCategory,
                    FK_Branch_ID = BranchID,
                    FK_Company_ID = companyID,
                    IsActive = isActive
                };

                _dbContext.TBL_MP_Master_UserList.Add(model);
                _dbContext.SaveChanges();
                newID = model.pk_UserListId;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::AddNewMASTERUserListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public List<SelectListItem> GetMasterListForAdminCategories(APP_ADMIN_CATEGORIES listType)
        {
            List<SelectListItem> lstItems = null;
            try
            {
                lstItems = (from xx in _dbContext.TBL_MP_Master_UserList
                            where xx.fk_CategoryId == (int)listType
                            select new SelectListItem { Description = xx.Description1, ID = xx.pk_UserListId }
                            ).ToList();

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetMasterListForAdminCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstItems;
        }
        public List<SelectListItem> GetAllPOSources()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int POSourceCategoryID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.POSource).FirstOrDefault().DEFAULT_VALUE;

                lst = (from xx in _dbContext.TBL_MP_Master_UserList
                       where xx.fk_CategoryId == POSourceCategoryID
                       select new SelectListItem() { ID = xx.pk_UserListId, Description = xx.Description1 }
                       ).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllPOSources", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public int AddNewMasterCategory(TBL_MP_Master_Category model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_Category.Add(model);
                _dbContext.SaveChanges();
                newID = model.pk_CategoryId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::AddNewMasterCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateMasterCategory(TBL_MP_Master_Category model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Category obj = _dbContext.TBL_MP_Master_Category.Where(X => X.pk_CategoryId == model.pk_CategoryId).FirstOrDefault();
                obj.CategoryDescription = model.CategoryDescription;
                obj.IsActive = model.IsActive;
                _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::UpdateMasterCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region APPLICATION DEFAULT MAPPINGS
        public List<SelectListItem> GetAllDefaultApplicationSettings()
        {
            List<SelectListItem> lstAppSettings = new List<SelectListItem>();
            string strDescription = string.Empty;

            try
            {
                List<APP_DEFAULTS> dbSettings = _dbContext.APP_DEFAULTS.ToList();
                if (dbSettings != null)
                {
                    foreach (APP_DEFAULTS setting in dbSettings)
                    {
                        SelectListItem item = new SelectListItem();
                        item.ID = setting.ID;
                        strDescription = string.Format("{0} : {1}", setting.DESCRIPTION, setting.DEFAULT_VALUE);
                        if (setting.DEFAULT_VALUE != 0)
                        {
                            switch (setting.FROM_TABLE)
                            {
                                case "TBL_MP_Master_Country":
                                    TBL_MP_Master_Country country = _dbContext.TBL_MP_Master_Country.Where(x => x.pk_CountryId == setting.DEFAULT_VALUE).FirstOrDefault();
                                    if (country != null)
                                    {
                                        if (setting.DESCRIPTION.Contains("Currency"))
                                            strDescription += string.Format("\n{0} ({1})", country.CurrencyName, setting.FROM_TABLE);
                                        if (setting.DESCRIPTION.Contains("Country"))
                                            strDescription += string.Format("\n{0} ({1})", country.CountryName, setting.FROM_TABLE);
                                    }
                                    break;
                                case "TBL_MP_Admin_UserList":
                                    TBL_MP_Admin_UserList adminList = _dbContext.TBL_MP_Admin_UserList.Where(x => x.PKID == setting.DEFAULT_VALUE).FirstOrDefault();
                                    if (adminList != null)
                                        strDescription += string.Format("\n{0} ({1})", adminList.Admin_UserList_Desc, setting.FROM_TABLE);
                                    break;
                                case "TBL_MP_Master_UserList":
                                    TBL_MP_Master_UserList masterList = _dbContext.TBL_MP_Master_UserList.Where(x => x.pk_UserListId == setting.DEFAULT_VALUE).FirstOrDefault();
                                    if (masterList != null)
                                        strDescription += string.Format("\n{0} ({1})", masterList.Description1, setting.FROM_TABLE);
                                    break;
                            }
                        }

                        item.Description = strDescription;
                        lstAppSettings.Add(item);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceMASTERS::GetAllDefaultApplicationSettings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAppSettings;
        }
        #endregion  

        #region COMMON
        public TBL_MP_Admin_Company_Master MyCompanyInfo()
        {
            TBL_MP_Admin_Company_Master model = null;
            try
            {
                model = _dbContext.TBL_MP_Admin_Company_Master.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::MyCompanyInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        #region FINANCIAL YEAR
        public List<SelectListItem> GetAllDistinctFinancialYearsList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                List<tbl_Acct_Financial_Year> dbList = (from xx in _dbContext.tbl_Acct_Financial_Year where xx.IsDeleted==false orderby xx.FromDate descending select xx).ToList();
                foreach (tbl_Acct_Financial_Year model in dbList)
                {
                    list.Add(new SelectListItem() { ID = model.ToDate.Year, Description = model.ToDate.Year.ToString() });
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllDistinctFinancialYearsList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllFinancialYears()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.tbl_Acct_Financial_Year.Where(x=>x.IsDeleted==false).OrderByDescending(x => x.PK_ID).ToList()
                        select new SelectListItem()
                        {
                            ID = xx.PK_ID,
                            Description = xx.FinYearName,
                            Code = xx.PK_ID.ToString()
                        }).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllFinancialYears", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public tbl_Acct_Financial_Year GetFinancialYearDbRecordByID(int finID)
        {
            tbl_Acct_Financial_Year model = null;
            try
            {
                model = _dbContext.tbl_Acct_Financial_Year.Where(x => x.PK_ID == finID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetFinancialYearDbRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewFinancialYear(tbl_Acct_Financial_Year model)
        {
            int newID = 0;
            try
            {
                model.IsDeleted = false;
                _dbContext.tbl_Acct_Financial_Year.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_ID;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::AddNewFinancialYear", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return newID ;
        }
        public bool UpdateFinancialYear(tbl_Acct_Financial_Year model)
        {
            bool result = false;
            try

            {
                tbl_Acct_Financial_Year dbmodel = _dbContext.tbl_Acct_Financial_Year.Where(x => x.PK_ID == model.PK_ID).FirstOrDefault();
                dbmodel.FK_BranchID = model.FK_BranchID;
                dbmodel.FK_CompanyID = model.FK_CompanyID;
                dbmodel.FromDate = model.FromDate;
                dbmodel.ToDate = model.ToDate;
                dbmodel.FinYearName = model.FinYearName;
                _dbContext.SaveChanges();
                result = true;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::UpdateFinancialYear", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return result;
        }
        public bool DeleteFinancialYear(int FinYearID, int deletedBy)
        {
            try
            {
                tbl_Acct_Financial_Year model = _dbContext.tbl_Acct_Financial_Year.Where(x => x.PK_ID == FinYearID).FirstOrDefault();
                if (model != null)
                {

                    model.IsDeleted = true;
                    model.DeletedBy = deletedBy;
                    model.DeleteDateTime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::DeleteFinancialYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        #endregion

        public List<SelectListItem> GetAllCompanies()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Admin_Company_Master.AsEnumerable()
                        select new SelectListItem()
                        {
                            ID = xx.PK_CompanyID,
                            Description = string.Format("{0} - {1}", xx.CompanyCode, xx.Company_name),
                            Code = xx.CompanyCode
                        }).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllCompanies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllBraches()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Admin_Branch_Master.AsEnumerable()
                        select new SelectListItem()
                        {
                            ID = xx.pk_BranchId,
                            Description = string.Format("{0} - {1}", xx.BranchCode, xx.BranchName),
                            Code = xx.BranchCode
                        }).ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllBraches", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllCurrencies()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_Country.AsEnumerable()
                        orderby xx.CurrencyName
                        select new SelectListItem()
                        {
                            ID = xx.pk_CountryId,
                            Description = string.Format("{0}", xx.CurrencyCode),
                            Code = xx.CurrencyCode
                        }).ToList();


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllCurrencies", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<SelectListItem> GetAllPlaces()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                string strSQL = "EXEC MXD_PLACES_LIST";
                list = _dbContext.Database.SqlQuery<SelectListItem>(strSQL).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllPlaces", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllCountries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_Country.AsEnumerable()
                        where xx.IsActive == true
                        orderby xx.CountryName
                        select new SelectListItem()
                        {
                            ID = xx.pk_CountryId,
                            Description = string.Format("{0}", xx.CountryName)
                        }).ToList();


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllCountries", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<SelectListItem> GetAllStates()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_State.AsEnumerable()
                        orderby xx.StateName
                        select new SelectListItem()
                        {
                            ID = xx.PK_StateId,
                            Description = string.Format("{0}", xx.StateName)
                        }).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllStates", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<SelectListItem> GetAllStatesForCountry(int countryID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_State.AsEnumerable()
                        where xx.FK_CountryId == countryID
                        orderby xx.StateName
                        select new SelectListItem()
                        {
                            ID = xx.PK_StateId,
                            Description = string.Format("{0}", xx.StateName)
                        }).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllStatesForCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<SelectListItem> GetAllCities()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_City.AsEnumerable()
                        orderby xx.CityName
                        select new SelectListItem()
                        {
                            ID = xx.pk_CityId,
                            Description = string.Format("{0}", xx.CityName)
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllCities", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<SelectListItem> GetAllCitiesForState(int stateID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_City.AsEnumerable()
                        where xx.fk_StateId == stateID
                        orderby xx.CityName
                        select new SelectListItem()
                        {
                            ID = xx.pk_CityId,
                            Description = string.Format("{0}", xx.CityName)
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllCitiesForState", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<SelectListItem> GetAllUOMs()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_UserList.AsEnumerable()
                        where xx.fk_CategoryId == (int)APP_MASTER_CATEGORIES.UOM_CATEGORY
                        orderby xx.Description1
                        select new SelectListItem()
                        {
                            ID = xx.pk_UserListId,
                            Description = string.Format("{0}", xx.Description1)
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllUOMs", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<MultiSelectListItem> GetAllUOMsMultiSelect()
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_UserList.AsEnumerable()
                        where xx.fk_CategoryId == (int)APP_MASTER_CATEGORIES.UOM_CATEGORY && xx.IsActive == true
                        orderby xx.Description1
                        select new MultiSelectListItem()
                        {
                            Selected = false,
                            ID = xx.pk_UserListId,
                            Description = string.Format("{0}", xx.Description1),
                            EntityType = APP_ENTITIES.UOM_LIST
                        }).ToList();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllUOMsMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public string GetNextEntityCode(DB_FORM_IDs form_type, USER_SESSION CURR_USER)
        {
            string keyCode = string.Empty;
            TBL_MP_Admin_VoucherNoSetup objSource = null;
            int intPreviousYearCount = 0;
            int cnt;
            string strNumber;
            string strQuery = string.Empty;
            try
            {
                switch (form_type)
                {
                    case DB_FORM_IDs.SALES_LEAD:
                        //preview - XL/SL/0001/2017-18
                        objSource =
                           _dbContext.TBL_MP_Admin_VoucherNoSetup
                           .Where(x => x.fk_FormID == (int)form_type)
                           .Where(x => x.Fk_YearID == CURR_USER.FinYearID)
                           .Where(X => X.Fk_BranchID == CURR_USER.BranchID)
                           .FirstOrDefault();
                        if (objSource == null)
                        {
                            MessageBox.Show("Error Reading Voucher Setup for Sale Lead", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new System.ArgumentNullException();
                        }
                        strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SM_SalesLead WHERE LeadNo NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                                    CURR_USER.FinYearID, CURR_USER.BranchID, CURR_USER.CompanyID);
                        cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                        cnt += (int)objSource.NoStartingFrom;
                        strNumber = cnt.ToString().PadLeft(objSource.NoPad, '0');
                        keyCode += objSource.NoPrefix + objSource.NoSeperator + strNumber + objSource.NoSeperator + objSource.NoPostfix;
                        break;


                    case DB_FORM_IDs.SALES_ENQUIRY: //preview - XL/SL/0001/2017-18
                        objSource =
                           _dbContext.TBL_MP_Admin_VoucherNoSetup
                           .Where(x => x.fk_FormID == (int)form_type)
                           .Where(x => x.Fk_YearID == CURR_USER.FinYearID)
                           .Where(X => X.Fk_BranchID == CURR_USER.BranchID)
                           .FirstOrDefault();

                        strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SalesEnquiry WHERE SalesEnquiry_No NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                                    CURR_USER.FinYearID, CURR_USER.BranchID, CURR_USER.CompanyID);
                        cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                        // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                        if ((bool)objSource.Is_NoContinuedNextYear)
                        {
                            TBL_MP_CRM_SalesEnquiry lastEnquiryPrevYear = (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry
                                                                           where xx.FK_YearID == CURR_USER.FinYearID - 1 && xx.FK_BranchID == CURR_USER.BranchID && xx.FK_CompanyID == CURR_USER.CompanyID
                                                                           orderby xx.CreatedDatetime descending
                                                                           select xx).FirstOrDefault();
                            if (lastEnquiryPrevYear != null)
                            {
                                string lstnumber = lastEnquiryPrevYear.SalesEnquiry_No.Replace("XL/SE/", "");
                                string[] arr = lstnumber.Split('/');
                                intPreviousYearCount = int.Parse(arr[0]);
                            }
                            else
                                intPreviousYearCount = 1;
                            cnt += intPreviousYearCount;
                        }
                        else
                        {
                            cnt += (int)objSource.NoStartingFrom;
                        }
                        strNumber = cnt.ToString().PadLeft(objSource.NoPad, '0');
                        keyCode += objSource.NoPrefix + objSource.NoSeperator + strNumber + objSource.NoSeperator + objSource.NoPostfix;
                        break;


                    case DB_FORM_IDs.SALES_QUOTATION://preview - XL/SL/2987/2017-18
                        objSource = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                     where xx.fk_FormID == (int)form_type && xx.Fk_YearID == CURR_USER.FinYearID & xx.Fk_BranchID == CURR_USER.BranchID
                                     select xx).FirstOrDefault();

                        strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SalesQuotation WHERE Quotation_No NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                                    CURR_USER.FinYearID, CURR_USER.BranchID, CURR_USER.CompanyID);
                        cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                        // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                        if ((bool)objSource.Is_NoContinuedNextYear)
                        {
                            TBL_MP_CRM_SalesQuotation lastQuotPrevYear = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation
                                                                          where xx.FK_YearID == CURR_USER.FinYearID - 1 && xx.FK_BranchID == CURR_USER.BranchID && xx.FK_CompanyID == CURR_USER.CompanyID
                                                                          orderby xx.CreatedDatetime descending
                                                                          select xx).FirstOrDefault();
                            if (lastQuotPrevYear != null)
                            {
                                string lstnumber = lastQuotPrevYear.Quotation_No.Replace("XL/SQ/", "");
                                string[] arr = lstnumber.Split('/');
                                intPreviousYearCount = int.Parse(arr[0]);
                            }
                            else
                                intPreviousYearCount = 1;
                            cnt += intPreviousYearCount;
                        }
                        else
                        {
                            cnt += (int)objSource.NoStartingFrom;
                        }

                        strNumber = cnt.ToString().PadLeft(objSource.NoPad, '0');
                        keyCode += objSource.NoPrefix + objSource.NoSeperator + strNumber + objSource.NoSeperator + objSource.NoPostfix;
                        break;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "serviceMASTERS::GetNextEntityCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        public List<SelectListItem> GetAllAreas()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_Area.AsEnumerable()
                        select new SelectListItem()
                        {
                            ID = xx.PK_AreaID,
                            Description = string.Format("{0} - {1}", xx.AreaCode, xx.AreaName),
                            Code = xx.AreaCode
                        }).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllAreas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllAreaForCity(int cityID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_Area.AsEnumerable()
                        where xx.Fk_CityID == cityID
                        orderby xx.AreaName
                        select new SelectListItem()
                        {
                            ID = xx.PK_AreaID,
                            Description = string.Format("{0}", xx.AreaName)
                        }).ToList();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllAreaForCity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        #endregion

        #region MASTERS

        public List<SelectListItem> GetAllApprovalStatuses()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int adminCatID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ApprovalStatusAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList
                        where xx.Fk_Admin_CategoryID == adminCatID
                        select new SelectListItem() { ID = xx.PKID, Description= xx.Admin_UserList_Desc }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllApprovalStatuses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllCountriesGrid()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_Country> countries = _dbContext.TBL_MP_Master_Country.OrderBy(x => x.CountryName).ToList();
                foreach (TBL_MP_Master_Country country in countries)
                {
                    SelectListItem item = new SelectListItem() { ID = country.pk_CountryId };
                    item.Description = string.Format(
                        "{0} ISD: {1} Currency: {2} ({3})\n{4}",
                        country.CountryName, country.ISDCode, country.CurrencyCode, country.Denomination,
                        ((country.IsActive) ? "Active" : "Deactivated")
                        );

                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllCountriesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllCitiesWithStateNamesForCountry(int countryID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Master_City
                        where xx.fk_CountryId == countryID && xx.IsActive == true
                        orderby xx.CityName
                        select new SelectListItem()
                        {
                            ID = xx.pk_CityId,
                            Description = xx.CityName + " (" + xx.TBL_MP_Master_State.StateShortName + ")"
                        }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllCitiesWithStateNamesForCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllStatesGridForCountry(int countryID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_State> states = _dbContext.TBL_MP_Master_State.Where(x => x.FK_CountryId == countryID).OrderBy(x => x.StateName).ToList();
                foreach (TBL_MP_Master_State state in states)
                {
                    SelectListItem item = new SelectListItem() { ID = state.PK_StateId };
                    item.Description = string.Format("{0} ({1})", state.StateName, ((state.IsActive) ? "Active" : "Deactivated"));
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllStatesGridForCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllCitiesGridForState(int stateID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_City> cities = _dbContext.TBL_MP_Master_City.Where(x => x.fk_StateId == stateID).OrderBy(x => x.CityName).ToList();
                foreach (TBL_MP_Master_City city in cities)
                {
                    SelectListItem item = new SelectListItem() { ID = city.pk_CityId };
                    item.Description = string.Format("{0} STD: {1} ({2})", city.CityName, city.STDCode, ((city.IsActive) ? "Active" : "Deactivated"));
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllCitiesGridForState", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

       
        public TBL_MP_Master_City GetCityDBRecordByCityID(int cityID)
        {
            TBL_MP_Master_City model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_City.Where(x => x.pk_CityId == cityID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetCityDBRecordByCityID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public TBL_MP_Master_State GetStateDBRecordByStateID(int stateID)
        {
            TBL_MP_Master_State model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_State.Where(x => x.PK_StateId == stateID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetStateDBRecordByStateID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public TBL_MP_Master_Country GetCountryDBRecordByCountryID(int countryID)
        {
            TBL_MP_Master_Country model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Country.Where(x => x.pk_CountryId == countryID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetCountryDBRecordByCountryID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewCountry(TBL_MP_Master_Country model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_Country.Add(model);
                _dbContext.SaveChanges();
                newID = model.pk_CountryId;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::AddNewCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool EditCountry(TBL_MP_Master_Country model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Country dbModel = _dbContext.TBL_MP_Master_Country.Where(x => x.pk_CountryId == model.pk_CountryId).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.CountryName = model.CountryName;
                    dbModel.CurrencyName = model.CurrencyName;
                    dbModel.CurrencyCode = model.CurrencyCode;
                    dbModel.Denomination = model.Denomination;
                    dbModel.Upto_Decimal = model.Upto_Decimal;
                    dbModel.IsActive = model.IsActive;
                    dbModel.ISDCode = model.ISDCode;
                    dbModel.FK_CompanyID = model.FK_CompanyID;
                    dbModel.FK_BranchID = model.FK_BranchID;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::EditCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public int AddNewState(TBL_MP_Master_State model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_State.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_StateId;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::AddNewState", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool EditState(TBL_MP_Master_State model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_State dbModel = _dbContext.TBL_MP_Master_State.Where(x => x.PK_StateId == model.PK_StateId).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.StateName = model.StateName;
                    dbModel.FK_CountryId = model.FK_CountryId;
                    dbModel.IsActive = model.IsActive;
                    dbModel.FK_CompanyID = model.FK_CompanyID;
                    dbModel.FK_BranchID = model.FK_BranchID;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::EditState", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region SALES QUESTIONNAIR
        public List<SelectListItem> GetAllSalesQuestionCategories()
        {
            List<SelectListItem> lstQueCategories = new List<SelectListItem>();
            try
            {
                int masterCategoryID =_dbContext.APP_DEFAULTS.Where(x=>x.ID== (int)APP_DEFAULT_VALUES.QuestionMasterCategoryID).FirstOrDefault().DEFAULT_VALUE;
                lstQueCategories = (from xx in _dbContext.TBL_MP_Master_UserList
                                    where xx.fk_CategoryId== masterCategoryID && xx.IsActive == true
                                    select new SelectListItem() {
                                        ID= xx.pk_UserListId,
                                        Description= xx.Description1
                                    }).ToList();
            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllSalesQuestionCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<SelectListItem> list = new List<SelectListItem>();
            return lstQueCategories.OrderBy(x => x.Description).ToList();

        }
        // SalesQuestionRelatedCategories
        public List<SelectListItem> GetAllSalesQuestionRelatedCategories()
        {
            List<SelectListItem> lstQueRelatedToCategories = new List<SelectListItem>();
            try
            {
                int masterRelatedToCategoryID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuestionMasterRelatedToCategoryID).FirstOrDefault().DEFAULT_VALUE;
                lstQueRelatedToCategories = (from xx in _dbContext.TBL_MP_Master_UserList
                                             where xx.fk_CategoryId == masterRelatedToCategoryID && xx.IsActive==true
                                             select new SelectListItem()
                                    {
                                        ID = xx.pk_UserListId,
                                        Description = xx.Description1
                                    }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllSalesQuestionRelatedCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<SelectListItem> list = new List<SelectListItem>();
            return lstQueRelatedToCategories.OrderBy(x => x.Description).ToList();

        }
        #endregion

        #region SALES LEAD
        public List<SelectListItem> GetAllLeadStatuses()
        {
           List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Admin_UserList> lstCategories = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.SALES_LEAD_STATUS).ToList();
            foreach (TBL_MP_Admin_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc });
            }
            return list;
        }
        public List<SelectListItem> GetSalesLeadStatusList()
        {

            
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Admin_UserList> lstCategories = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.SALES_LEAD_STATUS).ToList();
            foreach (TBL_MP_Admin_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc });
            }
            return list;
        }
        public List<SelectListItem> GetAllLeadSources()
        {

            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.LEAD_SOURCE).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllActiveLeadSources()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = (from xx in _dbContext.TBL_MP_Master_UserList where xx.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.LEAD_SOURCE && xx.IsActive == true select xx).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1.ToUpper() });
            }
            return list.OrderBy(x => x.Description).ToList();
        }
        #endregion

        #region PROJECTS
        public List<SelectListItem> GetAllProjectSectors()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.PROJECT_SECTOR).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1.ToUpper() });
            }
            return list.OrderBy(x => x.Description).ToList();
        }
        public List<SelectListItem> GetAllProjectTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.PROJECT_TYPE).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllProjectStatuses()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Admin_UserList> lstCategories = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.PROJECT_STATUS).ToList();
                foreach (TBL_MP_Admin_UserList item in lstCategories)
                {
                    list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }
        #endregion
        #region HR
        public List<SelectListItem> GetAllEmployeeCategories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EmployeeCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Master_UserList
                        where xx.fk_CategoryId == catID
                        select new SelectListItem()
                        {
                            ID = xx.pk_UserListId,
                            Description = xx.Description1,
                            IsActive= false,
                        }).ToList();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllEmployeeCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return list;

        }
        public List<MultiSelectListItem> GetAllEmployeesMultiSelect()
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            try
            {
                List<SelectListItem> lstDepartment = this.GetAllDepartments();
                List<SelectListItem> lstDesignations = this.GetAllDesignation();
                List<TBL_MP_Master_Employee> dbEmployees = _dbContext.TBL_MP_Master_Employee.Where(x=>x.isActive==true).Where(x => x.IsResigned == false).Where(x => x.IsDelete == false).OrderBy(x => x.EmployeeName).ToList();
                foreach (TBL_MP_Master_Employee emp in dbEmployees)
                {
                    string deptName = string.Empty;
                    string designName = string.Empty;

                    SelectListItem deptItem = lstDepartment.Where(x => x.ID == emp.FK_DepartmentId).FirstOrDefault();
                    if (deptItem != null) deptName = deptItem.Description;

                    SelectListItem designItem = lstDesignations.Where(x => x.ID == emp.FK_DesignationId).FirstOrDefault();
                    if (designItem != null) designName = designItem.Description;

                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        Selected = false,
                        ID = emp.PK_EmployeeId,
                        Description = string.Format("{0} ({1})\n{2}, {3}\n{4}", emp.EmployeeName, emp.EmployeeCode, designName, deptName, emp.EmailAddress),
                        Code = emp.EmployeeCode,
                        EntityType = APP_ENTITIES.EMPLOYEES
                    };
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllEmployeesMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<AssociatedEmployeeModel> GetAllEmployeesForAssociation()
        {
            List<AssociatedEmployeeModel> lst = new List<AssociatedEmployeeModel>();
            try
            {
                List<SelectListItem> lstDepartment = this.GetAllDepartments();
                List<SelectListItem> lstDesignations = this.GetAllDesignation();
                List<TBL_MP_Master_Employee> dbEmployees = (from xx in _dbContext.TBL_MP_Master_Employee
                                                            where xx.IsDelete == false && xx.IsResigned == false
                                                            orderby xx.EmployeeName
                                                            select xx
                                                           ).ToList();
                foreach (TBL_MP_Master_Employee emp in dbEmployees)
                {
                    string deptName = string.Empty;
                    string designName = string.Empty;

                    SelectListItem deptItem = lstDepartment.Where(x => x.ID == emp.FK_DepartmentId).FirstOrDefault();
                    if (deptItem != null) deptName = deptItem.Description;

                    SelectListItem designItem = lstDesignations.Where(x => x.ID == emp.FK_DesignationId).FirstOrDefault();
                    if (designItem != null) designName = designItem.Description;
                    AssociatedEmployeeModel model = new AssociatedEmployeeModel()
                    {
                        ID = emp.PK_EmployeeId,
                        Code = emp.EmployeeCode,
                        ContactNumber = emp.PhoneNo1,
                        Department = deptName,
                        Designation = designName,
                        EmailAddress = emp.EmailAddress,
                        ImagePath = emp.PhotoPath,
                        Name = emp.EmployeeName,
                        Selected = false
                    };
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllEmployeesForAssociation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllDepartments()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.DEPARTMENT).OrderBy(x => x.Description1).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllDesignation()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.DESIGNATION).OrderBy(x => x.Description1).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllIndustryTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.INDUSTRY_TYPE).OrderBy(x => x.Description1).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }

        public List<SelectListItem> GetAllFamilyRelationships()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.FamilyRelationshipCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID =
xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllFamilyRelationships", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllBloodGroups()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.BloodGroupCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllBloodGroups", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllGenders()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.GenderAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllGenders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllMeritalStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.MeritalstatusAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllMeritalStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllBankAccountTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.BankAccountTypeAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllMeritalStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllModeOfSalaryPayment()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ModeOfPaymentAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllModeOfSalaryPayment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public List<SelectListItem> GetAllSalaryHeads()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalaryHeadAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID && xx.IsActive==true
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllSalaryHeads", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllSalaryHeadsNature()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalaryHeadNatureAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllSalaryHeadsNature", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllSalaryHeadsType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalaryHeadTypeAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllSalaryHeadsType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public List<SelectListItem> GetAllEmploymentType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EmploymentTypeAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                list = (from xx in _dbContext.TBL_MP_Admin_UserList.AsEnumerable()
                        where xx.Fk_Admin_CategoryID == catID
                        select new SelectListItem()
                        {
                            ID = xx.PKID,
                            Description = xx.Admin_UserList_Desc,
                        }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllEmploymentType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public List<SelectListItem> GetAllVisa()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.VisaTypeMasterCategoryID).FirstOrDefault().DEFAULT_VALUE;
                lst = (from xx in _dbContext.TBL_MP_Master_UserList.AsEnumerable()
                       where xx.fk_CategoryId == catID && xx.IsActive == true
                       select new SelectListItem()
                       {
                           ID = xx.pk_UserListId,
                           Description = xx.Description1
                       }
                       ).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllVisaType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllVisaType()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.VISA_TYPE).OrderBy(x => x.Description1).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllLeaveType()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.LEAVE_TYPE).OrderBy(x => x.Description1).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }

        #endregion
        
        public List<MultiSelectListItem> GetAllPartiesMultiSelect()
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            List<Tbl_MP_Master_Party> dbParties = _dbContext.Tbl_MP_Master_Party.Where(x => x.PartyType == "C").Where(x => x.IsActive == true).OrderBy(x => x.PartyName).ToList();
            try
            {
                foreach (Tbl_MP_Master_Party party in dbParties)
                {
                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        Selected = false,
                        ID = party.PK_PartyId,
                        Description = string.Format("{0} ({1})\n{2}", party.PartyName, party.PartyCode, party.EmailID),
                        Code = party.PartyCode,
                        EntityType = APP_ENTITIES.PARTIES
                    };
                    list.Add(item);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllPartiesMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public void UpdatecontactReferences(APP_ENTITIES entity, int entityID, string contactIDs)
        {

        }

        /// <summary>
        /// this method will fetch all project types
        /// </summary>
        /// <returns></returns>

        public List<SelectListItem> GetAttachmentCategories()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.ATTACHMENT_DOCUMENT_TYPE).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetDocumentsOfEntityForID(APP_ENTITIES _entity, int mID)
        {
            List<SelectListItem> lst = null;
            try
            {
                string rootPath = string.Empty;
                switch (_entity)
                {

                    case APP_ENTITIES.SALES_LEAD:
                        rootPath = AppCommon.GetSalesLeadAttachmentPath();
                        lst = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment
                               where xx.FK_SalesLeadID == mID && xx.IsActive == true
                               select new SelectListItem() { ID = xx.PK_AttachmentID, Description = xx.Title, Code = rootPath + xx.AttachmentFileName }
                             ).ToList();
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        rootPath = AppCommon.GetSalesEnquiryAttachmentPath();
                        lst = (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments
                               where xx.FK_SalesEnquiryID == mID && xx.IsActive == true
                               select new SelectListItem() { ID = xx.PK_AttachmentID, Description = xx.Title, Code = rootPath + xx.AttachmentFileName }
                             ).ToList();
                        break;
                    case APP_ENTITIES.SALES_QUOTATION:
                        rootPath = AppCommon.GetSalesQuotationAttachmentPath();
                        lst = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation_Attachments
                               where xx.FK_SalesQuotationID == mID && xx.IsActive == true
                               select new SelectListItem() { ID = xx.PK_AttachmentID, Description = xx.Title, Code = rootPath + xx.AttachmentFileName }
                             ).ToList();
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        rootPath = AppCommon.GetSalesOrderAttachmentPath();
                        lst = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_Attachment
                               where xx.FK_SalesOrderID == mID && xx.IsActive == true
                               select new SelectListItem() { ID = xx.PK_AttachmentID, Description = xx.Title, Code = rootPath + xx.AttachmentFileName }
                             ).ToList();
                        break;


                    case APP_ENTITIES.INVENTORY_ITEM:
                        rootPath = AppCommon.GetInventoryItemAttachmentsImagePath();
                        lst = (from xx in _dbContext.TBL_MP_Master_Item_Attachments
                               where xx.FK_Inventory_Item_ID == mID && xx.IsActive == true
                               select new SelectListItem() { ID = xx.PK_AttachmentID, Description = xx.Title, Code = rootPath + xx.AttachmentFileName, IsActive = true }
                             ).ToList();
                        break;
                    case APP_ENTITIES.EMPLOYEES:
                        rootPath = AppCommon.GetEmployeeAttachmentsImagePath();
                        lst = (from xx in _dbContext.TBL_MP_Master_Employee_Attachment
                               where xx.FK_EmployeeId == mID && xx.IsActive == true
                               select new SelectListItem() { ID = xx.PK_AttachmentID, Description = xx.Title, Code = rootPath + xx.AttachmentFileName, IsActive = true }
                             ).ToList();
                        break;


                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetDocumentsOfEntityForID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        
        #region SALES ENQUIRY
        public List<SelectListItem> GetAllSalesEnquiryType()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.ENQUIRY_TYPE).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllSalesEnquirySubmissionMode()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.SUMISSION_MODE).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllSalesEnquirySources()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.ENQUIRY_SOURCE).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllSalesEnquiryStatuses()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_Admin_UserList
                        where xx.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.ENQUIRY_STATUS && xx.IsActive == true
                        select new SelectListItem() { ID = xx.PKID, Description = xx.Admin_UserList_Desc }
                        ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllSalesEnquiryStatuses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }
        #endregion
        
        #region FOLLOWUP AND CALL LOGS
        public List<SelectListItem> GetAllScheduleCallPriorities()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst.Add(new SelectListItem() { ID = (int)SCHEDULECALL_PRIORITY.NONE, Description = "(None)" });
                lst.Add(new SelectListItem() { ID = (int)SCHEDULECALL_PRIORITY.HIGH, Description = "High" });
                lst.Add(new SelectListItem() { ID = (int)SCHEDULECALL_PRIORITY.MODERATE, Description = "Moderate" });
                lst.Add(new SelectListItem() { ID = (int)SCHEDULECALL_PRIORITY.LOW, Description = "Low" });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllScheduleCallActions()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.CALL_SCHEDULE_ACTIONS).ToList();
            foreach (TBL_MP_Master_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.pk_UserListId, Description = item.Description1 });
            }
            return list;
        }
        public List<SelectListItem> GetAllScheduleCallsStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Admin_UserList> lstCategories = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.CALL_SCHEDULE_STATUS).ToList();
            foreach (TBL_MP_Admin_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc });
            }
            return list;
        }
        public List<SelectListItem> GetAllScheduleCallsReminders()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Admin_UserList> lstCategories = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == (int)APP_MASTER_CATEGORIES.CALL_SCHEDULE_REMINDER).ToList();
            foreach (TBL_MP_Admin_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc });
            }
            return list;
        }
        public List<SelectListItem> GetAllFollowUpStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            List<TBL_MP_Admin_UserList> lstCategories = _dbContext.TBL_MP_Admin_UserList.Where(x => x.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.CALL_FOLLOWUP_STATUS).ToList();
            foreach (TBL_MP_Admin_UserList item in lstCategories)
            {
                list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc });
            }
            return list;
        }
        #endregion
        
        #region BOQ
        public List<MultiSelectListItem> GetAllServicesMultiSelect()
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            List<TBL_MP_Master_UserList> dbServices = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.SERVICES_CATEGORY).Where(x => x.IsActive == true).OrderBy(x => x.Description1).ToList();
            try
            {
                foreach (TBL_MP_Master_UserList service in dbServices)
                {
                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        Selected = false,
                        ID = service.pk_UserListId,
                        Description = service.Description1,
                        EntityType = APP_ENTITIES.BOQ_SERVICES
                    };
                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllServicesMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<EnquiryBOQService> GetAllServicesMultiSelectinBOQ()
        {
            List<EnquiryBOQService> list = new List<EnquiryBOQService>();
            List<TBL_MP_Master_UserList> dbServices = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_MASTER_CATEGORIES.SERVICES_CATEGORY).Where(x => x.IsActive == true).OrderBy(x => x.Description1).ToList();
            try
            {
                foreach (TBL_MP_Master_UserList service in dbServices)
                {
                    EnquiryBOQService item = new EnquiryBOQService()
                    {
                        Selected = false,
                        ID = service.pk_UserListId,
                        Description = service.Description1
                    };
                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllServicesMultiSelectinBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        #endregion
        
        #region PROJECT CHECK POINT
        public List<SelectListItem> GetAllProjectCheckPoints()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectChecklistPointCategory).FirstOrDefault().DEFAULT_VALUE;
                lst = (from xx in _dbContext.TBL_MP_Master_UserList.AsEnumerable()
                       where xx.fk_CategoryId==catID
                       select new SelectListItem() {
                           ID= xx.pk_UserListId,
                           Description= string.Format("{0} ({1}) ",xx.Description1, (xx.IsActive )?"Active":"Deactivated")
                       }
                       ).ToList();
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllProjectCheckPoints", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllActiveProjectCheckPoints()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectChecklistPointCategory).FirstOrDefault().DEFAULT_VALUE;
                lst = (from xx in _dbContext.TBL_MP_Master_UserList.AsEnumerable()
                       where xx.fk_CategoryId == catID && xx.IsActive==true

                       select new SelectListItem()
                       {
                           ID = xx.pk_UserListId,
                           Description = xx.Description1
                       }
                       ).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceMASTERS::GetAllActiveProjectCheckPoints", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        #endregion


    }
}
