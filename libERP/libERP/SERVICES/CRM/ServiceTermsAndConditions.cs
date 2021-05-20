
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    public class ServiceTermsAndConditions: DefaultService
    {
         public ServiceTermsAndConditions() { _dbContext = new EXCEL_ERP_TESTEntities(); }

        public List<SelectListItem> GetAllActiveTermAndConditionCategories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int tncAdminCategoryID= _dbContext.APP_DEFAULTS.Where(x=>x.ID== (int)APP_DEFAULT_VALUES.TermAndConditionCategory).FirstOrDefault().DEFAULT_VALUE;
                List<TBL_MP_Admin_UserList> lstCategories = (from xx in _dbContext.TBL_MP_Admin_UserList where xx.Fk_Admin_CategoryID == tncAdminCategoryID && xx.IsActive == true select xx).ToList();
                foreach (TBL_MP_Admin_UserList item in lstCategories)
                {
                    list.Add(new SelectListItem() { ID = item.PKID, Description = item.Admin_UserList_Desc.ToUpper() });
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::GetAllActiveTermAndConditionCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return list.OrderBy(x => x.Description).ToList();
        }
        public List<SelectListItem> GetAllActiveTermAndConditionTitles()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                int tncAdminCategoryID = _dbContext.APP_DEFAULTS.Where(x=>x.ID==(int)APP_DEFAULT_VALUES.TermAndConditionTitleAdminCategory).FirstOrDefault().DEFAULT_VALUE;
                list= (from xx in _dbContext.TBL_MP_Admin_UserList
                       where xx.Fk_Admin_CategoryID == tncAdminCategoryID && xx.IsActive == true
                       select new SelectListItem() { ID= xx.PKID, Description= xx.Admin_UserList_Desc, IsActive= xx.IsActive }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::GetAllActiveTermAndConditionTitles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list.OrderBy(x => x.Description).ToList();
        }
        public List<SelectListItem> GetAllTermsAndConditionsForCategory(int CategoryID)
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            try
            {
               lstItems = (from xx in _dbContext.TBL_MP_Master_TnC.AsEnumerable()
                           where xx.Term_CategoryID==CategoryID  
                           select new SelectListItem() {  ID= xx.PK_TermID,Code= xx.TBL_MP_Admin_UserList.Admin_UserList_Desc, Description=  xx.Term_Description, IsActive= xx.IsActive} 
                           ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::GetAllTermsAndConditionsForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstItems;
        }
        public List<MultiSelectListItem> GetAllTermsAndConditionsForCategoryMultiSelectListItem(int CategoryID)
        {
            List<MultiSelectListItem> lstItems = new List<MultiSelectListItem>();
            try
            {
                lstItems = (from xx in _dbContext.TBL_MP_Master_TnC.AsEnumerable()
                            where xx.Term_CategoryID == CategoryID 
                            select new MultiSelectListItem() { ID = xx.PK_TermID, Code = xx.TBL_MP_Admin_UserList.Admin_UserList_Desc, Description =  xx.Term_Description, Selected =false }
                            ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::GetAllTermsAndConditionsForCategoryMultiSelectListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstItems;
        }
        public bool DeactivateTermAndConditionCategory(int catID)
        {
            bool result = false;
            try
            {
                TBL_MP_Admin_UserList model = _dbContext.TBL_MP_Admin_UserList.Where(x => x.PKID == catID).FirstOrDefault();
                if (model != null)
                {
                    model.IsActive = false;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::DeactivateTermAndConditionCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_Master_TnC GetTermConditionItemDBRecordByID(int termID)
        {
            return _dbContext.TBL_MP_Master_TnC.Where(x => x.PK_TermID == termID).FirstOrDefault();
        }
        public int AddNewTermAndCondition(TBL_MP_Master_TnC model)
        {
            int newID = 0;
            try
            {
                TBL_MP_Master_TnC newTerm = new TBL_MP_Master_TnC();
                newTerm.Term_CategoryID = model.Term_CategoryID;
                newTerm.Term_Description = model.Term_Description;
                newTerm.Term_TitleID = model.Term_TitleID;
                newTerm.IsActive = model.IsActive;
                _dbContext.TBL_MP_Master_TnC.Add(newTerm);
                _dbContext.SaveChanges();
                newID = newTerm.PK_TermID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::AddNewTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateTermAndCondition(TBL_MP_Master_TnC model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_TnC objTerm = _dbContext.TBL_MP_Master_TnC.Where(x => x.PK_TermID == model.PK_TermID).FirstOrDefault();
                if (objTerm != null)
                {
                    objTerm.Term_CategoryID = model.Term_CategoryID;
                    objTerm.Term_Description = model.Term_Description;
                    objTerm.Term_TitleID = model.Term_TitleID;
                    objTerm.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::UpdateTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeactivateTermAndCondition(int termID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_TnC model = _dbContext.TBL_MP_Master_TnC.Where(x => x.PK_TermID == termID).FirstOrDefault();
                if (model != null)
                {
                    model.IsActive = false;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::DeactivateTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool ActivateTermAndCondition(int termID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_TnC model = _dbContext.TBL_MP_Master_TnC.Where(x => x.PK_TermID == termID).FirstOrDefault();
                if (model != null)
                {
                    model.IsActive = true;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceTermsAndConditions::ActivateTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }


    }
}
