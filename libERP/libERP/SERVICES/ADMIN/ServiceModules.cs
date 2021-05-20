using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.ADMIN
{
    public class ServiceModules : DefaultService
    {
        USER_SESSION CURR_USER = null;

        public ServiceModules(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceModules()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public ServiceModules(USER_SESSION currUser)
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
            CURR_USER = currUser;
        }
 
        #region APPLICATION MODULES
        public List<SelectListItem> GetAllModules()
        {
            List<SelectListItem> lstModules = new List<SelectListItem>();
            try
            {
                List<Tbl_MP_Master_Module> dbModules = _dbContext.Tbl_MP_Master_Module.ToList();
                foreach (Tbl_MP_Master_Module dbItem in dbModules)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        ID = dbItem.pk_ModuleId,
                        IsActive = (bool)dbItem.IsActive,
                        Code = dbItem.SequenceNo.ToString()
                    };
                    item.Description = string.Format("{0}\nDisplay Name: {1}", dbItem.ModuleName, dbItem.DisplayName);
                    lstModules.Add(item);
                }
                lstModules= lstModules.OrderBy(x => x.Description).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceModules::GetAllModules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstModules;
        }
        public List<SelectListItem> GetAllActiveModules()
        {
            List<SelectListItem> lstModules = new List<SelectListItem>();
            try
            {
                List<Tbl_MP_Master_Module> dbModules = _dbContext.Tbl_MP_Master_Module.Where(x=>x.IsActive==true).ToList();
                foreach (Tbl_MP_Master_Module dbItem in dbModules)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        ID = dbItem.pk_ModuleId,
                        IsActive = (bool)dbItem.IsActive,
                        Code = dbItem.SequenceNo.ToString()
                    };
                    item.Description = string.Format("{0}\nDisplay Name: {1}", dbItem.ModuleName, dbItem.DisplayName);
                    lstModules.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceModules::GetAllActiveModules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstModules;
        }
        public List<MultiSelectListItem> GetActiveModulesMultiSelectionList()
        {
            List<MultiSelectListItem> lstModules = new List<MultiSelectListItem>();
            try
            {
                lstModules = (
                    from xx in _dbContext.Tbl_MP_Master_Module
                    where xx.IsActive == true
                    select new MultiSelectListItem() {
                        ID= xx.pk_ModuleId,
                        Description= xx.DisplayName,
                        Selected=false,
                        Code= xx.ModuleName 
                    }).OrderBy(x=>x.Description).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceModules::GetActiveModulesMultiSelectionList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstModules;
        }
        public Tbl_MP_Master_Module GetModuleDBRecordByID(int moduleID)
        {
            Tbl_MP_Master_Module module = null;
            try
            {
                module = _dbContext.Tbl_MP_Master_Module.Where(x => x.pk_ModuleId == moduleID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetModuleDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return module;
        }

        public int AddNewModule(Tbl_MP_Master_Module model)
        {
            int newID = 0;
            try
            {
                Tbl_MP_Master_Module newModule = new Tbl_MP_Master_Module();
                newModule.ModuleName = model.ModuleName;
                newModule.DisplayName = model.DisplayName;
                newModule.IsActive = model.IsActive;
                newModule.SequenceNo = model.SequenceNo;
                _dbContext.Tbl_MP_Master_Module.Add(newModule);
                _dbContext.SaveChanges();
                newID = newModule.pk_ModuleId;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::AddNewModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateModule(Tbl_MP_Master_Module model)
        {
            bool result=false;
            try
            {
                Tbl_MP_Master_Module newModule = _dbContext.Tbl_MP_Master_Module.Where(x=>x.pk_ModuleId==model.pk_ModuleId).FirstOrDefault();
                if(newModule!=null)
                {
                    newModule.ModuleName = model.ModuleName;
                    newModule.DisplayName = model.DisplayName;
                    newModule.IsActive = model.IsActive;
                    newModule.SequenceNo = model.SequenceNo;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::UpdateModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public int GetNewModuleSequenceNo()
        {
            int newNo = 0;
            try
            {
                newNo = _dbContext.Tbl_MP_Master_Module.Max(x => x.SequenceNo);
                newNo++;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetNewModuleSequenceNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newNo;
        }
        public bool DeleteModuleMasterInfo(int moduleID, string reason)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Module editItem = _dbContext.Tbl_MP_Master_Module.Where(x => x.pk_ModuleId == moduleID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = CURR_USER.EmployeeID;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                string strQuery = string.Format("UPDATE Tbl_MP_Master_Module_Forms SET DeletedBy={0}, DeleteDatetime='{1}', DeleteRemarks='{2}',IsActive=0 WHERE FK_ModuleID={3}",
                    CURR_USER.EmployeeID, AppCommon.GetServerDateTime().ToString("yyyy-MM-dd hh:ss"),reason,moduleID);
                int cnt=_dbContext.Database.ExecuteSqlCommand(strQuery);
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::DeleteModuleMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteModuleMasterInfo(int moduleID, string reason)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Module editItem = _dbContext.Tbl_MP_Master_Module.Where(x => x.pk_ModuleId == moduleID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::UndeleteModuleMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteModuleMasterInfo(int moduleID, string reason, int deletedBy)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Module editItem = _dbContext.Tbl_MP_Master_Module.Where(x => x.pk_ModuleId == moduleID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                // editItem.DeletedBy = CURR_USER.EmployeeID;
                editItem.DeletedBy = deletedBy;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                string strQuery = string.Format("UPDATE Tbl_MP_Master_Module_Forms SET DeletedBy={0}, DeleteDatetime='{1}', DeleteRemarks='{2}',IsActive=0 WHERE FK_ModuleID={3}",
                    deletedBy, AppCommon.GetServerDateTime().ToString("yyyy-MM-dd hh:ss"), reason, moduleID);
                int cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::DeleteModuleMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region  MODULE FORMS
        public List<SelectListItem> GetAllFormsForModule(int moduleID)
        {
            List<SelectListItem> lstForms = new List<SelectListItem>();
            try
            {
                lstForms = (from xx in _dbContext.Tbl_MP_Master_Module_Forms
                            where xx.FK_ModuleId == moduleID 
                            select new SelectListItem() { ID = xx.PK_FormId, Description = xx.FormName.ToUpper()+"\nDisplay Name :"+ xx.DisplayName, Code = xx.FormName, IsActive = xx.IsActive }
                            ).OrderBy(x=>x.Description).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetAllFormsForModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstForms;
        }
        public List<SelectListItem> GetAllActiveFormsForModule(int moduleID)
        {
            List<SelectListItem> lstForms = new List<SelectListItem>();
            try
            {
                lstForms = (from xx in _dbContext.Tbl_MP_Master_Module_Forms
                            where xx.FK_ModuleId == moduleID && xx.IsActive == true
                            orderby xx.DisplayName
                            select new SelectListItem() { ID= xx.PK_FormId, Description= xx.DisplayName, Code= xx.FormName, IsActive= xx.IsActive }
                            ).ToList();
                lstForms = lstForms.OrderBy(x => x.Description).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetAllActiveFormsForModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstForms;
        }
        public List<MultiSelectListItem> GetMultiSelectActiveFormsForModule(int moduleID)
        {
            List<MultiSelectListItem> lstForms = new List<MultiSelectListItem>();
            try
            {
                lstForms = (from xx in _dbContext.Tbl_MP_Master_Module_Forms
                            where xx.FK_ModuleId == moduleID && xx.IsActive == true
                            select new MultiSelectListItem() {
                                ID = xx.PK_FormId,
                                Description = xx.DisplayName,
                                Code = xx.FormName,
                                EntityType= APP_ENTITIES.MODULES_FORMS
                            }).ToList();
                lstForms = lstForms.OrderBy(x => x.Description).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetAllActiveFormsForModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstForms;
        }
        public Tbl_MP_Master_Module_Forms GetModuleFormDBRecordByID(int formID)
        {
            Tbl_MP_Master_Module_Forms form = null;
            try
            {
                form = _dbContext.Tbl_MP_Master_Module_Forms.Where(x => x.PK_FormId == formID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetModuleDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return form;
        }

        public int AddNewModuleForm(Tbl_MP_Master_Module_Forms model)
        {
            int newID = 0;
            try
            {
                Tbl_MP_Master_Module_Forms newModuleForm = new Tbl_MP_Master_Module_Forms();
                newModuleForm.FK_ModuleId = model.FK_ModuleId;
                newModuleForm.FormName = model.FormName;
                newModuleForm.DisplayName = model.DisplayName;
                newModuleForm.IsActive = model.IsActive;
                _dbContext.Tbl_MP_Master_Module_Forms.Add(newModuleForm);
                _dbContext.SaveChanges();
                newID = newModuleForm.PK_FormId;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::AddNewModuleForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateModuleForm(Tbl_MP_Master_Module_Forms model)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Module_Forms newModule = _dbContext.Tbl_MP_Master_Module_Forms.Where(x => x.PK_FormId == model.PK_FormId).FirstOrDefault();
                if (newModule != null)
                {
                    newModule.FormName = model.FormName;
                    newModule.DisplayName = model.DisplayName;
                    newModule.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::UpdateModuleForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteModuleFormMasterInfo(int formID, string reason, int deletedBy)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Module_Forms editItem = _dbContext.Tbl_MP_Master_Module_Forms.Where(x => x.PK_FormId == formID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = deletedBy;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::DeleteModuleFormMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteModuleFormMasterInfo(int formID, string reason)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_Module_Forms editItem = _dbContext.Tbl_MP_Master_Module_Forms.Where(x => x.PK_FormId == formID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::UndeleteModuleFormMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

       
    }
}
