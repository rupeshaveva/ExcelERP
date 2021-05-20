
using libERP.MODELS;
using libERP.MODELS.ADMIN;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.ADMIN
{
    public class ServiceUsers : DefaultService
    {
        public ServiceUsers()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public ServiceUsers(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }

        public int AddNewUser(TBL_User_Master model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_User_Master.Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUser::AddNewUser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateUser(TBL_User_Master model)
        {
            bool result = false;
            try
            {
                TBL_User_Master dbModel = _dbContext.TBL_User_Master.Where(x => x.PK_UserID == model.PK_UserID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.LoginPassword = model.LoginPassword;
                    dbModel.IsActive = model.IsActive;
                    dbModel.FK_RoleId = model.FK_RoleId;

                    //dbModel.ModifiedBy = model.ModifiedBy;
                    //dbModel.ModifiedDateTime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUser::UpdateEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool IsVaidUser(string usrName, string Password)
        {
            bool result = false;
            try
            {
                string encrPassword = AppCommon.EncryptText(Password);
                TBL_User_Master user = _dbContext.TBL_User_Master.Where(x=>x.LoginId==usrName).Where(xx=>xx.LoginPassword == encrPassword).FirstOrDefault();
                result= (user == null) ? false : true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUser::IsVaidUser", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;

        }
        public string GetEmployeeNameByUserName(string uName)
        {
            string empName = string.Empty;
            try
            {
                TBL_User_Master user = _dbContext.TBL_User_Master.Where(x => x.LoginId == uName).FirstOrDefault();
                if (user != null)
                {
                    TBL_MP_Master_Employee emp = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == user.FK_EmployeeID).FirstOrDefault();
                    if (emp != null)
                        empName = emp.EmployeeName;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUser::GetEmployeeNameByUserName", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return empName;
        }

        public TBL_MP_Master_Employee GetEmployeeDBModelByUserName(string uName)
        {
            TBL_MP_Master_Employee emp = null;
            try
            {
                TBL_User_Master user = _dbContext.TBL_User_Master.Where(x => x.LoginId == uName).FirstOrDefault();
                if (user != null)
                {
                    emp = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == user.FK_EmployeeID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUser::GetEmployeeDBModelByUserName", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return emp;
        }
        public TBL_User_Master GetUserDBModelByEmployeeID(int empID)
        {
            TBL_User_Master model = null;
            try
            {
                model = _dbContext.TBL_User_Master.Where(x => x.FK_EmployeeID== empID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUser::GetUserDBModelByEmployeeID", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public TBL_User_Master GetUserDBModelByUserID(int userID)
        {
            TBL_User_Master model = null;
            try
            {
                model = _dbContext.TBL_User_Master.Where(x => x.PK_UserID == userID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::GetUserDBModelByUserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public TBL_User_Master GetUserDBModelByUserName(string uName)
        {
            TBL_User_Master model = null;
            try
            {
                model = _dbContext.TBL_User_Master.Where(x => x.LoginId == uName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::GetUserDBModelByUserName", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public bool SetUserTheme(int employeeID, int themeID)
        {
            bool result = false;
            try
            {
                TBL_User_Master model = _dbContext.TBL_User_Master.Where(x => x.FK_EmployeeID == employeeID).FirstOrDefault();
                if (model != null)
                {
                    model.Theme = themeID;
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message),"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public List<SelectListItem> GetAllUsers()
        {
            List<SelectListItem> lstUsers = new List<SelectListItem>();
            string strDescription = string.Empty;
            try
            {
                List<TBL_User_Master> dbUsers = _dbContext.TBL_User_Master.ToList();
                List<SelectListItem> Designations = (new ServiceMASTERS()).GetAllDesignation();
                List<SelectListItem> Departments = (new ServiceMASTERS()).GetAllDepartments();
                foreach (TBL_User_Master user in dbUsers)
                {
                    strDescription = string.Empty;
                    if(user.TBL_MP_Master_Employee!=null)
                    {
                        strDescription = string.Format("{0} {1}\n", user.TBL_MP_Master_Employee.EmployeeName, user.TBL_MP_Master_Employee.EmployeeCode);
                        if (user.TBL_MP_Master_Employee.FK_DesignationId != null)
                        {
                            SelectListItem foundDesignation = Designations.Where(x => x.ID == (int)user.TBL_MP_Master_Employee.FK_DesignationId).FirstOrDefault();
                            if (foundDesignation != null)
                            {
                                strDescription += string.Format("{0}, ", foundDesignation.Description);
                            }
                        }
                        if (user.TBL_MP_Master_Employee.FK_DepartmentId != null)
                        {
                            SelectListItem foundDepartment = Departments.Where(x => x.ID == (int)user.TBL_MP_Master_Employee.FK_DepartmentId).FirstOrDefault();
                            if (foundDepartment != null)
                            {
                                strDescription += string.Format("{0} ", foundDepartment.Description);
                            }
                        }

                        if(user.IsActive!=null)
                        {
                            if (!(bool)user.IsActive)
                            {
                                string uniCodeCharacter = "\u274C";
                                strDescription += string.Format(" {0}", uniCodeCharacter);
                            }
                            
                        }
                        SelectListItem item = new SelectListItem() { ID = user.PK_UserID, Description = strDescription, IsActive = (bool)user.IsActive, Code= user.FK_EmployeeID.ToString() };
                        lstUsers.Add(item);
                    }
                    

                }
            }
            catch (Exception ex)
            {
                string errMEssage = ex.Message;
                if (ex.InnerException != null) errMEssage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMEssage, "ServiceUsers::GelAllUsersForBrowse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstUsers;
        }
        public List<SelectListItem> GetAllActiveUsers()
        {
            List<SelectListItem> lstUsers = new List<SelectListItem>();
            string strDescription = string.Empty;
            try
            {
                List<TBL_User_Master> dbUsers = _dbContext.TBL_User_Master.Where(x=>x.IsActive==true).ToList();
                List<SelectListItem> Designations = (new ServiceMASTERS()).GetAllDesignation();
                List<SelectListItem> Departments = (new ServiceMASTERS()).GetAllDepartments();
                foreach (TBL_User_Master user in dbUsers)
                {
                    strDescription = string.Empty;
                    if (user.TBL_MP_Master_Employee != null)
                    {
                        strDescription = string.Format("{0} {1}\n", user.TBL_MP_Master_Employee.EmployeeName, user.TBL_MP_Master_Employee.EmployeeCode);
                        if (user.TBL_MP_Master_Employee.FK_DesignationId != null)
                        {
                            SelectListItem foundDesignation = Designations.Where(x => x.ID == (int)user.TBL_MP_Master_Employee.FK_DesignationId).FirstOrDefault();
                            if (foundDesignation != null)
                            {
                                strDescription += string.Format("{0}, ", foundDesignation.Description);
                            }
                        }
                        if (user.TBL_MP_Master_Employee.FK_DepartmentId != null)
                        {
                            SelectListItem foundDepartment = Departments.Where(x => x.ID == (int)user.TBL_MP_Master_Employee.FK_DepartmentId).FirstOrDefault();
                            if (foundDepartment != null)
                            {
                                strDescription += string.Format("{0} ", foundDepartment.Description);
                            }
                        }

                        if (user.IsActive != null)
                        {
                            if (!(bool)user.IsActive)
                            {
                                string uniCodeCharacter = "\u274C";
                                strDescription += string.Format(" {0}", uniCodeCharacter);
                            }

                        }
                        SelectListItem item = new SelectListItem() { ID = user.PK_UserID, Description = strDescription, IsActive = (bool)user.IsActive, Code = user.FK_EmployeeID.ToString() };
                        lstUsers.Add(item);
                    }


                }
            }
            catch (Exception ex)
            {
                string errMEssage = ex.Message;
                if (ex.InnerException != null) errMEssage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMEssage, "ServiceUsers::GelAllUsersForBrowse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstUsers;
        }
        public List<SelectListItem> GetAllInactiveUsers()
        {
            List<SelectListItem> lstUsers = new List<SelectListItem>();
            string strDescription = string.Empty;
            try
            {
                List<TBL_User_Master> dbUsers = _dbContext.TBL_User_Master.Where(x => x.IsActive == false).ToList();
                List<SelectListItem> Designations = (new ServiceMASTERS()).GetAllDesignation();
                List<SelectListItem> Departments = (new ServiceMASTERS()).GetAllDepartments();
                foreach (TBL_User_Master user in dbUsers)
                {
                    strDescription = string.Empty;
                    if (user.TBL_MP_Master_Employee != null)
                    {
                        strDescription = string.Format("{0} {1}\n", user.TBL_MP_Master_Employee.EmployeeName, user.TBL_MP_Master_Employee.EmployeeCode);
                        if (user.TBL_MP_Master_Employee.FK_DesignationId != null)
                        {
                            SelectListItem foundDesignation = Designations.Where(x => x.ID == (int)user.TBL_MP_Master_Employee.FK_DesignationId).FirstOrDefault();
                            if (foundDesignation != null)
                            {
                                strDescription += string.Format("{0}, ", foundDesignation.Description);
                            }
                        }
                        if (user.TBL_MP_Master_Employee.FK_DepartmentId != null)
                        {
                            SelectListItem foundDepartment = Departments.Where(x => x.ID == (int)user.TBL_MP_Master_Employee.FK_DepartmentId).FirstOrDefault();
                            if (foundDepartment != null)
                            {
                                strDescription += string.Format("{0} ", foundDepartment.Description);
                            }
                        }

                        if (user.IsActive != null)
                        {
                            if (!(bool)user.IsActive)
                            {
                                string uniCodeCharacter = "\u274C";
                                strDescription += string.Format(" {0}", uniCodeCharacter);
                            }

                        }
                        SelectListItem item = new SelectListItem() { ID = user.PK_UserID, Description = strDescription, IsActive = (bool)user.IsActive, Code = user.FK_EmployeeID.ToString() };
                        lstUsers.Add(item);
                    }


                }
            }
            catch (Exception ex)
            {
                string errMEssage = ex.Message;
                if (ex.InnerException != null) errMEssage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMEssage, "ServiceUsers::GetAllInactiveUsers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstUsers;
        }

        public bool UpdateUserRole(int userId, int roleID)
        {
            bool result = false;
            try
            {
                TBL_User_Master model = _dbContext.TBL_User_Master.Where(x => x.PK_UserID == userId).FirstOrDefault();
                if (model != null)
                {
                    model.FK_RoleId = roleID;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMEssage = ex.Message;
                if (ex.InnerException != null) errMEssage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMEssage, "ServiceUsers::UpdateUserRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_User_CustomPermissions GetCustomPermissionByPermissionID(int permissionID)
        {
            TBL_User_CustomPermissions model = null;
            try
            {
                model=_dbContext.TBL_User_CustomPermissions.Where(x => x.pk_CustomPermissionID == permissionID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::GetCustomPermissionByPermissionID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public int AddNewCustomPermission(TBL_User_CustomPermissions permission)
        {
            int newID = 0;
            try
            {
                TBL_User_CustomPermissions newPermission = new TBL_User_CustomPermissions() {

                    CanAddNew = permission.CanAddNew,
                    CanApprove = permission.CanApprove,
                    CanAuthorize = permission.CanAuthorize,
                    CanCheck = permission.CanCheck,
                    CanDelete = permission.CanDelete,
                    CanModify = permission.CanModify,
                    CanPrint = permission.CanPrint,
                    CanView = permission.CanView,
                    fk_ModuleId = permission.fk_ModuleId,
                    fk_FormId = permission.fk_FormId,
                    fk_EmployeeId = permission.fk_EmployeeId
                };
                _dbContext.TBL_User_CustomPermissions.Add(newPermission);
                _dbContext.SaveChanges();
                newID = newPermission.pk_CustomPermissionID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::AddNewCustomPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateCustomPermission(int permissionID,TBL_User_CustomPermissions updatePermission)
        {
            bool result = false;
            try
            {
                TBL_User_CustomPermissions model = _dbContext.TBL_User_CustomPermissions.Where(x => x.pk_CustomPermissionID == permissionID).FirstOrDefault();
                if(model!=null)
                {

                    model.CanAddNew = updatePermission.CanAddNew;
                    model.CanApprove = updatePermission.CanApprove;
                    model.CanAuthorize = updatePermission.CanAuthorize;
                    model.CanCheck = updatePermission.CanCheck;
                    model.CanDelete = updatePermission.CanDelete;
                    model.CanModify = updatePermission.CanModify;
                    model.CanPrint = updatePermission.CanPrint;
                    model.CanView = updatePermission.CanView;
                    model.fk_ModuleId = updatePermission.fk_ModuleId;
                    model.fk_FormId = updatePermission.fk_FormId;
                    model.fk_EmployeeId = updatePermission.fk_EmployeeId;
                    _dbContext.SaveChanges();
                    result = true;
                };
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::AddNewCustomPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool RemoveCustomPermission(int permissionID)
        {
            bool result = false;
            try
            {
                TBL_User_CustomPermissions model=_dbContext.TBL_User_CustomPermissions.Where(x => x.pk_CustomPermissionID == permissionID).FirstOrDefault();
                if (model != null)
                {
                    _dbContext.TBL_User_CustomPermissions.Remove(model);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::RemoveCustomPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public BindingList<UserAccessPermissionsModel> GetRoleWiseAccessPermissionForUser(int userID)
        {
            BindingList<UserAccessPermissionsModel> list = new BindingList<UserAccessPermissionsModel>();
            try
            {
                TBL_User_Master user = this.GetUserDBModelByUserID(userID);
                if (user != null)
                {
                    int roleID = (int)user.FK_RoleId;
                    List<TBL_MP_Master_RoleForm> lstRoleForms = _dbContext.TBL_MP_Master_RoleForm.Where(x => x.FK_RoleID == roleID).ToList();
                    foreach (TBL_MP_Master_RoleForm roleForm in lstRoleForms)
                    {
                        UserAccessPermissionsModel listItem = new UserAccessPermissionsModel() {
                            ID= roleForm.PK_RoleFormID,
                            FormID= roleForm.FK_FormId,
                            FormName= roleForm.Tbl_MP_Master_Module_Forms.DisplayName,
                            ModuleID= (int)roleForm.FK_ModuleId,
                            ModuleName= roleForm.Tbl_MP_Master_Module.DisplayName,
                            RoleID= roleForm.FK_RoleID,
                            RoleName= roleForm.TBL_MP_Master_Role.RoleName
                        };
                        string strDescription = string.Empty;
                        if (roleForm.CanAddNew) strDescription += "ADD ";
                        if (roleForm.CanApprove) strDescription += "APPROVE ";
                        if (roleForm.CanAuthorize) strDescription += "AUTHORIZE ";
                        if (roleForm.CanCheck) strDescription += "CHECK ";
                        if (roleForm.CanDelete) strDescription += "DELETE ";
                        if (roleForm.CanModify) strDescription += "MODIFY ";
                        if (roleForm.CanPrepare) strDescription += "PREPARE ";
                        if (roleForm.CanPrint) strDescription += "PRINT ";
                        if (roleForm.CanView) strDescription += "VIEW ";
                        listItem.Permissions = strDescription;

                        list.Add(listItem);
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::GetRoleWiseAccessPermissionForUser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public BindingList<UserAccessPermissionsModel> GetCustomAccessPermissionForUser(int employeeID)
        {
            BindingList<UserAccessPermissionsModel> list = new BindingList<UserAccessPermissionsModel>();
            try
            {
                List<TBL_User_CustomPermissions> lstCustomPermissions = _dbContext.TBL_User_CustomPermissions.Where(x => x.fk_EmployeeId == employeeID).ToList();
                foreach (TBL_User_CustomPermissions customPermission in lstCustomPermissions)
                {
                    UserAccessPermissionsModel listItem = new UserAccessPermissionsModel()
                    {
                        ID = customPermission.pk_CustomPermissionID,
                        FormID = customPermission.fk_FormId,
                        FormName = customPermission.Tbl_MP_Master_Module_Forms.DisplayName,
                        ModuleID = (int)customPermission.fk_ModuleId,
                        ModuleName = customPermission.Tbl_MP_Master_Module.DisplayName,
                        RoleID = 0,
                        RoleName = "CUSTOM"
                    };

                    string strDescription = string.Empty;
                    if (customPermission.CanAddNew) strDescription += "ADD ";
                    if (customPermission.CanApprove) strDescription += "APPROVE ";
                    if (customPermission.CanAuthorize) strDescription += "AUTHORIZE ";
                    if (customPermission.CanCheck) strDescription += "CHECK ";
                    if (customPermission.CanDelete) strDescription += "DELETE ";
                    if (customPermission.CanModify) strDescription += "MODIFY ";
                    if (customPermission.CanPrepare) strDescription += "PREPARE ";
                    if (customPermission.CanPrint) strDescription += "PRINT ";
                    if (customPermission.CanView) strDescription += "VIEW ";
                    listItem.Permissions = strDescription;

                    list.Add(listItem);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceUsers::GetCustomAccessPermissionForUser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }



    }
}
