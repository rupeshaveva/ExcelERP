
using libERP.MODELS;
using libERP.MODELS.ADMIN;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.ADMIN
{
    public class ServiceRoles: DefaultService
    {
        USER_SESSION CURR_USER = null;

        public ServiceRoles(USER_SESSION currUser)
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
            CURR_USER = currUser;
        }
        public ServiceRoles(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceRoles()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        #region ROLES   
        public List<SelectListItem> GetAllRoles()
        {
            List<SelectListItem> lstRoles = new List<SelectListItem>();
            try
            {

                lstRoles = (from dbItem in _dbContext.TBL_MP_Master_Role
                            select new SelectListItem()
                            {
                                ID = dbItem.PK_RoleId,
                                IsActive = (bool)dbItem.IsActive,
                                Code = dbItem.RoleNo,
                                Description = dbItem.RoleName
                            }).OrderBy(x => x.Description).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetAllRoles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRoles;
        }
        public List<SelectListItem> GetAllActiveRoles()
        {
            List<SelectListItem> lstRoles = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_Role> dbRoles = _dbContext.TBL_MP_Master_Role.Where(x => x.IsActive == true).ToList();
                foreach (TBL_MP_Master_Role dbItem in dbRoles)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        ID = dbItem.PK_RoleId,
                        IsActive = (bool)dbItem.IsActive,
                        Code = dbItem.RoleNo
                    };
                    item.Description = string.Format("{0}", dbItem.RoleName);
                    lstRoles.Add(item);
                }
                lstRoles = lstRoles.OrderBy(x => x.Description).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetAllActiveRoles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRoles;
        }
        public List<MultiSelectListItem> GetAllActiveRolesMultiSelect()
        {
            List<MultiSelectListItem> lstRoles = new List<MultiSelectListItem>();
            try
            {
                List<TBL_MP_Master_Role> dbRoles = _dbContext.TBL_MP_Master_Role.Where(x => x.IsActive == true).ToList();
                foreach (TBL_MP_Master_Role dbItem in dbRoles)
                {
                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        ID = dbItem.PK_RoleId,
                        Code = dbItem.RoleNo
                    };
                    item.Description = string.Format("{0}", dbItem.RoleName);
                    lstRoles.Add(item);
                }
                lstRoles = lstRoles.OrderBy(x => x.Description).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetAllActiveRoles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRoles;
        }
        public TBL_MP_Master_Role GetRoleDBRecordByID(int roleID)
        {
            TBL_MP_Master_Role role = null;
            try
            {
                role = _dbContext.TBL_MP_Master_Role.Where(x => x.PK_RoleId == roleID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetRoleDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return role;
        }

        public int AddNewRole(TBL_MP_Master_Role model)
        {
            int newID = 0;
            try
            {
                TBL_MP_Master_Role newRole = new TBL_MP_Master_Role();
                newRole.RoleName = model.RoleName;
                newRole.RoleNo = this.GetNewRoleNo();
                newRole.IsActive = model.IsActive;
                _dbContext.TBL_MP_Master_Role.Add(newRole);
                _dbContext.SaveChanges();
                newID = newRole.PK_RoleId;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::AddNewRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateRole(TBL_MP_Master_Role model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Role newRole = _dbContext.TBL_MP_Master_Role.Where(x => x.PK_RoleId == model.PK_RoleId).FirstOrDefault();
                if (newRole != null)
                {
                    newRole.RoleName = model.RoleName;
                    newRole.IsActive = model.IsActive;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::UpdateRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string GetNewRoleNo()
        {
            int newNo = 0;
            string newRoleno = string.Empty;
            try
            {
                newNo = _dbContext.TBL_MP_Master_Role.Count();
                newNo++;
                newRoleno = string.Format("R{0}", newNo.ToString().PadLeft(5, '0'));
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceModules::GetNewModuleSequenceNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newRoleno;
        }
        public bool DeleteRoleMasterInfo(int roleID, string reason,int deletedBy)
        {
            bool result = false;
            
            try
            {
                TBL_MP_Master_Role editItem = _dbContext.TBL_MP_Master_Role.Where(x => x.PK_RoleId == roleID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = deletedBy;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();

                //DEACTIVATE ALL MODULES ASSOCIATED WITH THIS ROLE
                string strQuery = string.Format("UPDATE TBL_MP_Master_RoleModule SET DeletedBy={0}, DeleteDatetime='{1}', DeleteRemarks='{2}',IsActive=0 WHERE FK_RoleId={3}",
                    deletedBy, AppCommon.GetServerDateTime().ToString("yyyy-MM-dd hh:ss"), reason, roleID);
                int cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);

                //DEACTIVATE ALL MODULE FORMS ASSOCIATED WITH THIS ROLE
                strQuery = string.Format("UPDATE TBL_MP_Master_RoleForm SET DeletedBy={0}, DeleteDatetime='{1}', DeleteRemarks='{2}',IsActive=0 WHERE FK_RoleId={3}",
                    CURR_USER.EmployeeID, AppCommon.GetServerDateTime().ToString("yyyy-MM-dd hh:ss"), reason, roleID);
                cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::DeleteRoleMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteRoleMasterInfo(int roleID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Role editItem = _dbContext.TBL_MP_Master_Role.Where(x => x.PK_RoleId == roleID).FirstOrDefault();
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
                MessageBox.Show(errMessage, "ServiceRoles::UndeleteRoleMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region ROLE MODULES
        public int GetModuleIDforRoleModule(int roleModuleID)
        {
            int moduleID = 0;
            try
            {
                TBL_MP_Master_RoleModule dbRoleModule = _dbContext.TBL_MP_Master_RoleModule.Where(x => x.PK_RoleModuleID == roleModuleID).FirstOrDefault();
                if (dbRoleModule != null)
                    moduleID = dbRoleModule.FK_ModuleId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetModuleIDforRoleModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return moduleID;

        }
        public List<MultiSelectListItem> GetMultiSelectModulesForRole(int roleID)
        {
            List<MultiSelectListItem> lstRoleModules = new List<MultiSelectListItem>();
            try
            {
                lstRoleModules = (
                    from dbItem in _dbContext.TBL_MP_Master_RoleModule.AsEnumerable()
                    where dbItem.FK_RoleId == roleID
                    select new MultiSelectListItem()
                    {
                        ID = dbItem.PK_RoleModuleID,
                        Selected = false,
                        Code = dbItem.FK_ModuleId.ToString(),
                        Description = dbItem.Tbl_MP_Master_Module.DisplayName.ToUpper(),
                        EntityType= APP_ENTITIES.APPLICATION_MODULES
                    }).ToList();
               
            }
            catch (Exception ex)
            {   string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += "\n" + ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceRoles::GetMultiSelectModulesForRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRoleModules;
        }
        public List<SelectListItem> GetAllModulesForRole(int roleID)
        {
            List<SelectListItem> lstRoleModules = new List<SelectListItem>();
            try
            {
                lstRoleModules = (
                    from dbItem in _dbContext.TBL_MP_Master_RoleModule.AsEnumerable()
                    where dbItem.FK_RoleId == roleID
                    select new SelectListItem()
                    {
                        ID = dbItem.PK_RoleModuleID,
                        IsActive = true,
                        Code = dbItem.FK_ModuleId.ToString(),
                        Description = dbItem.Tbl_MP_Master_Module.DisplayName
                    }).ToList();
            }
            catch (Exception ex)
            {
                string errMessge = ex.Message;
                if (ex.InnerException != null) errMessge += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessge, "ServiceRoles::GetAllModulesForRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRoleModules;
        }
        //public List<SelectListItem> GetAllFormsForRoleModule(int roleID, int moduleID)
        //{
        //    List<SelectListItem> lstForms = new List<SelectListItem>();
        //    try
        //    {
        //        List<TBL_MP_Master_RoleForm> dbForms = (from xx in _dbContext.TBL_MP_Master_RoleForm
        //                                                where xx.FK_RoleID == roleID && xx.FK_ModuleId == moduleID
        //                                                select xx).ToList();
        //        foreach (TBL_MP_Master_RoleForm dbItem in dbForms)
        //        {
        //            SelectListItem item = new SelectListItem()
        //            {
        //                ID = dbItem.PK_RoleFormID,


        //            };
        //            item.Description = dbItem.Tbl_MP_Master_Module_Forms.DisplayName;
        //            lstForms.Add(item);
        //        }
        //        lstForms = lstForms.OrderBy(x => x.Description).ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceRoles::GetAllFormsForRoleModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return lstForms;
        //}


        //public List<MultiSelectListItem> GetMultiselectModuleFormsForRole(int roleID, int moduleID)
        //{
        //    List<MultiSelectListItem> lstForms = new List<MultiSelectListItem>();
        //    try
        //    {
        //        lstForms= (from xx in _dbContext.TBL_MP_Master_RoleForm.AsEnumerable()
        //                   where xx.FK_RoleID == roleID && xx.FK_ModuleId == moduleID
        //                   select new MultiSelectListItem() {
        //                       ID= xx.PK_RoleFormID,
        //                       Code= xx.FK_FormId.ToString(),
        //                       Description=xx.Tbl_MP_Master_Module_Forms.DisplayName,
        //                       EntityType= APP_ENTITIES.ROLE_MODULE_FORMS,
        //                       Selected=false
        //                   }).ToList();
        //        lstForms = lstForms.OrderBy(x => x.Description).ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        string strError = ex.Message;
        //        if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
        //        MessageBox.Show(strError, "ServiceRoles::GetMultiselectModuleFormsForRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return lstForms;
        //}
        public bool RemoveRoleModule(int roleModuleID)
        {
            bool result = false;
            
            try
            {
                int roleID = 0;
                int moduleID = 0;
                TBL_MP_Master_RoleModule model = _dbContext.TBL_MP_Master_RoleModule.Where(x => x.PK_RoleModuleID == roleModuleID).FirstOrDefault();
                if (model != null)
                {
                    roleID = model.FK_RoleId;
                    moduleID = model.FK_ModuleId;
                    _dbContext.TBL_MP_Master_RoleModule.Remove(model);
                    _dbContext.SaveChanges();
                    string strQuery = string.Format("DELETE FROM TBL_MP_Master_RoleForm WHERE FK_ROLEID={0} AND FK_MODULEID={1}", roleID, moduleID);
                    _dbContext.Database.ExecuteSqlCommand(strQuery);
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += "\n" + ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceRoles::UpdateRoleModules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UpdateRoleModules(int roleID, BindingList<MultiSelectListItem> roleModules)
        {
            bool result = false;
            try
            {
                // INSETRING MODULE NOT FOUND IN DATABASE
                foreach (MultiSelectListItem item in roleModules)
                {
                    int moduelID = int.Parse(item.Code);
                    TBL_MP_Master_RoleModule dbRoleModule = (from xx in _dbContext.TBL_MP_Master_RoleModule where xx.FK_RoleId == roleID && xx.FK_ModuleId == moduelID select xx).FirstOrDefault();
                    if (dbRoleModule == null)
                    {
                        
                        _dbContext.TBL_MP_Master_RoleModule.Add(new TBL_MP_Master_RoleModule() { FK_RoleId = roleID, FK_ModuleId = moduelID});
                        _dbContext.SaveChanges();
                    }
                }

                // DELETING MODULE NOT FOUND IN COLLECTION
                String deleteIDs = string.Empty;
                List<TBL_MP_Master_RoleModule> dbItems = _dbContext.TBL_MP_Master_RoleModule.Where(x => x.FK_RoleId == roleID).ToList();
                foreach (TBL_MP_Master_RoleModule item in dbItems)
                {
                    MultiSelectListItem mItem = roleModules.Where(x => x.Code == item.FK_ModuleId.ToString()).FirstOrDefault();
                    if (mItem == null)
                    {
                        deleteIDs += item.FK_ModuleId.ToString() + DefaultStringSeperator;
                    }
                }
                if (deleteIDs != string.Empty)
                {
                    deleteIDs = deleteIDs.TrimEnd(DefaultStringSeperator).Replace(DefaultStringSeperator, ',');
                    string strQuery = string.Format("DELETE FROM TBL_MP_Master_RoleModule WHERE FK_ROLEID={0} AND FK_MODULEID IN ({1})", roleID, deleteIDs);
                    _dbContext.Database.ExecuteSqlCommand(strQuery);
                    
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if(ex.InnerException!=null) errMessage+="\n"+ ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceRoles::UpdateRoleModules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region ROLE MODULE-FORMS
        public TBL_MP_Master_RoleForm GetRoleModuleFormDBRecordByID(int roleFormID)
        {
            TBL_MP_Master_RoleForm roleForm = null;
            try
            {
                roleForm = _dbContext.TBL_MP_Master_RoleForm.Where(x => x.PK_RoleFormID == roleFormID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetRoleModuleFormDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return roleForm;
        }
        public TBL_MP_Master_RoleForm GetRoleFormDBRecordByRoleIDnFormID(int roleID,int formID)
        {
            TBL_MP_Master_RoleForm roleForm = null;
            try
            {
                roleForm =(from xx in _dbContext.TBL_MP_Master_RoleForm where xx.FK_RoleID == roleID && xx.FK_FormId== formID select xx ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetRoleFormDBRecordByRoleIDnFormID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return roleForm;
        }

        public TBL_User_CustomPermissions GetEmpRoleFormDBRecordByRoleIDnFormID(int EmpID, int formID)
        {
            TBL_User_CustomPermissions EmproleForm = null;
            try
            {
                EmproleForm = (from xx in _dbContext.TBL_User_CustomPermissions where xx.fk_EmployeeId == EmpID && xx.fk_FormId == formID select xx).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetRoleFormDBRecordByRoleIDnFormID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return EmproleForm;
        }

        public List<RoleModuleForm> GetFormsGridForRoleModule(int roleID, int moduleID)
        {
            List<RoleModuleForm> lstData = new List<RoleModuleForm>();
            try
            {
                // GET ALL FORMS FOR THE MODULE
                List<SelectListItem> lstForms = (new ServiceModules()).GetAllActiveFormsForModule(moduleID);
                foreach (SelectListItem form in lstForms)
                {
                    RoleModuleForm lstItem = new RoleModuleForm() { Description = form.Description, FormID= form.ID , ModuleID= moduleID};
                    TBL_MP_Master_RoleForm dbRoleForm = (from xx in _dbContext.TBL_MP_Master_RoleForm where xx.FK_RoleID == roleID && xx.FK_FormId== form.ID select xx).FirstOrDefault();
                    if (dbRoleForm != null)
                    {
                        string strDescription = string.Empty;
                        if (dbRoleForm.CanAddNew) strDescription += "Add ";
                        if (dbRoleForm.CanApprove) strDescription += "Approve ";
                        if (dbRoleForm.CanAuthorize) strDescription += "Authorize ";
                        if (dbRoleForm.CanCheck) strDescription += "Check ";
                        if (dbRoleForm.CanDelete) strDescription += "Delete ";
                        if (dbRoleForm.CanModify) strDescription += "Modify ";
                        if (dbRoleForm.CanPrepare) strDescription += "Prepare ";
                        if (dbRoleForm.CanPrint) strDescription += "Print ";
                        if (dbRoleForm.CanView) strDescription += "View ";
                        lstItem.Selected = true;
                        lstItem.ID = dbRoleForm.PK_RoleFormID;
                        lstItem.RoleID = dbRoleForm.FK_RoleID;
                        lstItem.ModuleID = (int)dbRoleForm.FK_ModuleId;
                        lstItem.FormID = dbRoleForm.FK_FormId;
                        lstItem.Description += "\n" + strDescription.ToUpper();
                    }
                    lstData.Add(lstItem);

                }



            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "ServiceRoles::GetFormsGridForRoleModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstData;
        }
        public List<SelectListItem> GetFormsGridforRole(int roleID)
        {
            List<SelectListItem> lstData = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_RoleForm> lstRoleForm = (from xx in _dbContext.TBL_MP_Master_RoleForm where xx.FK_RoleID == roleID select xx).ToList();
                foreach (TBL_MP_Master_RoleForm dbItem in lstRoleForm)
                {
                    string strDescription = string.Empty;
                    Tbl_MP_Master_Module dbModule = (new ServiceModules()).GetModuleDBRecordByID((int)dbItem.FK_ModuleId);
                    if (dbModule != null)
                        strDescription = dbModule.DisplayName.ToUpper();

                    Tbl_MP_Master_Module_Forms dbModuleForm = (new ServiceModules()).GetModuleFormDBRecordByID((int)dbItem.FK_FormId);
                    if (dbModuleForm != null)
                        strDescription = string.Format("{0} ({1})\n", strDescription, dbModuleForm.DisplayName);


                    if (dbItem.CanAddNew) strDescription += "ADD ";
                    if (dbItem.CanApprove) strDescription += "APPROVE ";
                    if (dbItem.CanAuthorize) strDescription += "AUTHORIZE ";
                    if (dbItem.CanCheck) strDescription += "CHECK ";
                    if (dbItem.CanDelete) strDescription += "DELETE ";
                    if (dbItem.CanModify) strDescription += "MODIFY ";
                    if (dbItem.CanPrepare) strDescription += "PREPARE ";
                    if (dbItem.CanPrint) strDescription += "PRINT ";
                    if (dbItem.CanView) strDescription += "VIEW ";

                    SelectListItem item = new SelectListItem() { ID = dbItem.PK_RoleFormID };
                    item.Description = strDescription;
                    lstData.Add(item);
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                if (ex.InnerException != null) strError += "\n" + ex.InnerException.Message;
                MessageBox.Show(strError, "ServiceRoles::GetFormsGridForRoleModule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstData;
        }
        public int AddNewRoleModuleForm(int formID, int moduleID, int roleID)
        {
            int newRoleFormID = 0;
            try
            {
                TBL_MP_Master_RoleForm dbRoleForm = _dbContext.TBL_MP_Master_RoleForm.Where(x => (x.FK_RoleID == roleID && x.FK_ModuleId == moduleID && x.FK_FormId == formID)).FirstOrDefault();
                if (dbRoleForm == null)
                {
                    TBL_MP_Master_RoleForm newRoleForm = new TBL_MP_Master_RoleForm()  {
                        FK_RoleID=roleID,
                        FK_ModuleId=moduleID,
                        FK_FormId=formID
                    };
                    _dbContext.TBL_MP_Master_RoleForm.Add(newRoleForm);
                    _dbContext.SaveChanges();
                    newRoleFormID = newRoleForm.PK_RoleFormID;
                }

            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::AddNewRoleModuleForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newRoleFormID;
        }
        public bool UpdateRoleModuleForms(int roleID, BindingList<RoleModuleForm> roleModuleForms)
        {
            bool result = false;
            int selModuleID = 0;
            try
            {
                if (roleModuleForms.Count > 0)
                    selModuleID = roleModuleForms[0].ModuleID;

                // INSETRING MODULE NOT FOUND IN DATABASE
                foreach (RoleModuleForm item in roleModuleForms)
                {
                    if (item.Selected)
                    {
                        if (item.ID == 0)
                        {
                            TBL_MP_Master_RoleForm newItem = new TBL_MP_Master_RoleForm();
                            newItem.FK_RoleID = roleID;
                            newItem.FK_ModuleId = item.ModuleID;
                            newItem.FK_FormId = item.FormID;
                            newItem.CanAddNew = newItem.CanApprove = newItem.CanAuthorize = newItem.CanCheck = newItem.CanDelete = newItem.CanModify = newItem.CanPrepare = newItem.CanPrint = newItem.CanView = false;
                            _dbContext.TBL_MP_Master_RoleForm.Add(newItem);
                            _dbContext.SaveChanges();
                            item.ID = newItem.PK_RoleFormID;
                        }
                    }
                    
                }

                // DELETING MODULE NOT FOUND IN COLLECTION
                String deleteIDs = string.Empty;
                List<TBL_MP_Master_RoleForm> dbItems = (from xx in _dbContext.TBL_MP_Master_RoleForm where xx.FK_RoleID== roleID && xx.FK_ModuleId== selModuleID select xx).ToList();
                foreach (TBL_MP_Master_RoleForm item in dbItems)
                {
                    RoleModuleForm mItem = roleModuleForms.Where(x => x.ID == item.PK_RoleFormID).FirstOrDefault();
                    if (mItem != null)
                    {
                        if(!mItem.Selected)
                            deleteIDs += string.Format("{0}{1}",mItem.FormID , DefaultStringSeperator);
                    }
                }
                if (deleteIDs != string.Empty)
                {
                    deleteIDs = deleteIDs.TrimEnd(DefaultStringSeperator).Replace(DefaultStringSeperator, ',');
                    string strQuery = string.Format("DELETE FROM TBL_MP_Master_RoleForm WHERE FK_RoleID={0} AND FK_FormId IN ({1})", roleID, deleteIDs);
                    _dbContext.Database.ExecuteSqlCommand(strQuery);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += "\n" + ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceRoles::UpdateRoleModuleForms", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UpdateRoleModuleFormPermission(TBL_MP_Master_RoleForm roleForm)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_RoleForm model =_dbContext.TBL_MP_Master_RoleForm.Where(x=>x.PK_RoleFormID== roleForm.PK_RoleFormID).FirstOrDefault();
                if (model != null)
                {
                    model.CanAddNew = roleForm.CanAddNew ;
                    model.CanApprove = roleForm.CanApprove;
                    model.CanAuthorize = roleForm.CanAuthorize;
                    model.CanCheck = roleForm.CanCheck;
                    model.CanDelete = roleForm.CanDelete;
                    model.CanModify = roleForm.CanModify;
                    model.CanPrint = roleForm.CanPrint;
                    model.CanView = roleForm.CanView;
                    _dbContext.SaveChanges();
                    result = true;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if(ex.InnerException!=null) errMessage+=string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::UpdateRoleModuleFormPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion  
        public List<SelectListItem> GetModulesPermissionForRole(int roleID)
        {
            List<SelectListItem> lstModule = null;
            try
            {
                lstModule = (from XX in _dbContext.Tbl_MP_Master_Module where XX.IsActive == true
                             select new SelectListItem() {
                                 ID= XX.pk_ModuleId,
                                 Description= XX.ModuleName,
                                 IsActive=false
                             }).ToList();
                List<TBL_MP_Master_RoleModule> roleModules = (from xx in _dbContext.TBL_MP_Master_RoleModule where xx.FK_RoleId == roleID select xx).ToList();
                foreach (SelectListItem item in lstModule)
                {
                    TBL_MP_Master_RoleModule dbModule = roleModules.Where(x => x.FK_ModuleId == (int?)item.ID).FirstOrDefault();
                    if (dbModule != null)
                    {
                        item.IsActive = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceRoles::GetModulesPermissionForRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstModule;
        }



    }
}
