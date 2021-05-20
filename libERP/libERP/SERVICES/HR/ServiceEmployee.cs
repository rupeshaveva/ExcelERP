using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

using libERP.SERVICES.COMMON;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.MODELS.HR;
using libERP.MODELS.COMMON;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.ADMIN;
using System.Drawing;
using Newtonsoft.Json;

namespace libERP.SERVICES.HR
{
    public class ServiceEmployee : DefaultService
    {
       
        public ServiceEmployee(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceEmployee()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        
        public List<SelectListItem> GetAllEmployees()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<TBL_MP_Master_Employee> dbEmployees = _dbContext.TBL_MP_Master_Employee.OrderBy(x => x.EmployeeName).ToList();
            try
            {
                ServiceMASTERS service = new ServiceMASTERS();
                List<SelectListItem> lstDepartment = service.GetAllDepartments();
                List<SelectListItem> lstDesignations = service.GetAllDesignation();
                foreach (TBL_MP_Master_Employee emp in dbEmployees)
                {
                    string deptName = string.Empty;
                    SelectListItem dept = lstDepartment.Where(x => x.ID == emp.FK_DepartmentId).FirstOrDefault();
                    if (dept != null) deptName = dept.Description;
                    string designationName = string.Empty;
                    SelectListItem designation= lstDesignations.Where(x => x.ID == emp.FK_DesignationId).FirstOrDefault();
                    if (designation != null) designationName = designation.Description;

                    SelectListItem item = new SelectListItem()
                    {
                        ID = emp.PK_EmployeeId,
                        Code = emp.EmployeeCode,
                        IsActive = true
                    };

                    item.Description = string.Format("{0} ({1})\n{2}, {3}", emp.EmployeeName, emp.EmployeeCode, designationName, deptName);
                    if (emp.IsResigned!=null)
                        item.IsActive = !((bool)emp.IsResigned);
                    list.Add(item);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::GetAllEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllActiveEmployees()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<TBL_MP_Master_Employee> dbEmployees = (from xx in _dbContext.TBL_MP_Master_Employee
                                                        where xx.isActive == true orderby xx.EmployeeName
                                                        select xx).ToList();
            try
            {
                List<SelectListItem> lstDepartment = (new ServiceMASTERS()).GetAllDepartments();
                List<SelectListItem> lstDesignations = (new ServiceMASTERS()).GetAllDesignation();
                foreach (TBL_MP_Master_Employee emp in dbEmployees)
                {
                    string deptName = string.Empty;
                    SelectListItem dept = lstDepartment.Where(x => x.ID == emp.FK_DepartmentId).FirstOrDefault();
                    if (dept != null) deptName = dept.Description;

                    string designationName = string.Empty;
                    SelectListItem designation = lstDesignations.Where(x => x.ID == emp.FK_DesignationId).FirstOrDefault();
                    if (designation != null) designationName = designation.Description;

                    SelectListItem item = new SelectListItem()
                    {
                        ID = emp.PK_EmployeeId,
                        Code = emp.EmployeeCode,
                        IsActive = true
                    };

                    item.Description = string.Format("{0} ({1})\n{2}, {3}", emp.EmployeeName.ToUpper(), emp.EmployeeCode, designationName, deptName);
                    if (emp.IsResigned != null)
                        item.IsActive = !((bool)emp.IsResigned);
                    list.Add(item);
                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllActiveEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllInactiveEmployees()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<TBL_MP_Master_Employee> dbEmployees = (from xx in _dbContext.TBL_MP_Master_Employee
                                                        where xx.IsResigned == true || xx.IsDelete == true || xx.isActive==false
                                                        select xx).ToList();
            try
            {
                List<SelectListItem> lstDepartment = (new ServiceMASTERS()).GetAllDepartments();
                List<SelectListItem> lstDesignations = (new ServiceMASTERS()).GetAllDesignation();
                foreach (TBL_MP_Master_Employee emp in dbEmployees)
                {
                    string deptName = string.Empty;
                    SelectListItem dept = lstDepartment.Where(x => x.ID == emp.FK_DepartmentId).FirstOrDefault();
                    if (dept != null) deptName = dept.Description;

                    string designationName = string.Empty;
                    SelectListItem designation = lstDesignations.Where(x => x.ID == emp.FK_DesignationId).FirstOrDefault();
                    if (designation != null) designationName = designation.Description;

                    SelectListItem item = new SelectListItem()
                    {
                        ID = emp.PK_EmployeeId,
                        Code = emp.EmployeeCode,
                        IsActive = true
                    };

                    item.Description = string.Format("{0} ({1})\n{2}, {3}", emp.EmployeeName, emp.EmployeeCode, designationName, deptName);
                    if (emp.IsResigned != null)
                        item.IsActive = !((bool)emp.IsResigned);
                    list.Add(item);
                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllInactiveEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<SelectListItem> GetAllActiveEmployeesBetweenDates(DateTime fromDate, DateTime toDate)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                string strQuery = string.Format("select distinct FK_EmployeeID as ID, EmployeeDescription as Description from vAttendanceRegister where AttendDate between '{0}' AND '{1}'",
                fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
                list = _dbContext.Database.SqlQuery<SelectListItem>(strQuery).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllActiveEmployeesBetweenDates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }


        public void UpdateEmailPassword(int empID, string newPassword)
        {
            try
            {
                TBL_User_Master emp = _dbContext.TBL_User_Master.Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                if (emp != null)
                {
                    emp.EmailPassword = AppCommon.EncryptText(newPassword);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::UpdateEmailPassword", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void UpdateLoginPassword(int empID, string newPassword)
        {
            try
            {
                TBL_User_Master emp = _dbContext.TBL_User_Master.Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                if (emp != null)
                {
                    emp.LoginPassword = AppCommon.EncryptText(newPassword);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::UpdateLoginPassword", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static string GetEmailPasswordForEmployee(int empID)
        {
            string strPassword = string.Empty;
            try
            {
                TBL_User_Master emp = (new EXCEL_ERP_TESTEntities()).TBL_User_Master.Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                if (emp != null)
                {
                    if (emp.EmailPassword == null)
                        strPassword = string.Empty;
                    else
                        strPassword = AppCommon.DecryptText(emp.EmailPassword.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::GetEmailPasswordForEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strPassword;
        }

        public string GetEmployeeCompleteDescription(int empID)
        {
            string strDescription = string.Empty;
            try
            {
                EmployeeGeneralInfoModel model = this.GetEmployeeGeneralInfo(empID);
                strDescription = string.Format("{0} Code: {1}", model.EmployeeFullName, model.EmployeeCode);
                strDescription+= string.Format("\n{0}, {1}", model.DesignationInfo.Description, model.DepartmentInfo.Description);
                strDescription += string.Format("\nContact: {0}, {1}", model.EmployeeContactNumbers, model.EmployeeEmailAddress);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeCompleteDescription", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strDescription;
        }
        public static string GetEmployeeEmailByID(int mID)
        {
            string mailID = string.Empty;
            try
            {
                TBL_MP_Master_Employee emp = (new EXCEL_ERP_TESTEntities()).TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    mailID = emp.EmailAddress.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::GetEmployeeEmailByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return mailID;
        }
        public static string GetEmployeeNameByID(int mID)
        {
            string strName = string.Empty;
            try
            {
                TBL_MP_Master_Employee emp = (new EXCEL_ERP_TESTEntities()).TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    strName = emp.EmployeeName.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::GetEmployeeNameByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strName;
        }

        public static bool IsOfficeEmployee(int mID)
        {
            bool result = false;
            int officeEmployeeCategoryID = 0;
            try
            {
                EXCEL_ERP_TESTEntities conn = new EXCEL_ERP_TESTEntities();
                TBL_MP_Master_Employee emp = conn.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    APP_DEFAULTS dbDefault = conn.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EMPLOYEE_CATEGORY_OFFICE).FirstOrDefault();
                    if (dbDefault != null)
                    {
                        officeEmployeeCategoryID = dbDefault.DEFAULT_VALUE;
                        if (emp.fk_UL_Cat_Id == officeEmployeeCategoryID)
                            result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::IsOfficeEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public static bool IsOnSiteEmployee(int mID)
        {
            bool result = false;
            int OnSiteEmployeeCategoryID = 0;
            try
            {
                EXCEL_ERP_TESTEntities conn = new EXCEL_ERP_TESTEntities();
                TBL_MP_Master_Employee emp = conn.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    APP_DEFAULTS dbDefault = conn.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EMPLOYEE_CATEGORY_ON_SITE).FirstOrDefault();
                    if (dbDefault != null)
                    {
                        OnSiteEmployeeCategoryID = dbDefault.DEFAULT_VALUE;
                        if (emp.fk_UL_Cat_Id == OnSiteEmployeeCategoryID)
                            result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::IsOnSiteEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public static bool IsManagementEmployee(int mID)
        {
            bool result = false;
            int ManagementEmployeeCategoryID = 0;
            try
            {
                EXCEL_ERP_TESTEntities conn = new EXCEL_ERP_TESTEntities();
                TBL_MP_Master_Employee emp = conn.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    APP_DEFAULTS dbDefault = conn.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EMPLOYEE_CATEGORY_MANAGEMENT).FirstOrDefault();
                    if (dbDefault != null)
                    {
                        ManagementEmployeeCategoryID = dbDefault.DEFAULT_VALUE;
                        if (emp.fk_UL_Cat_Id == ManagementEmployeeCategoryID)
                            result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::IsManagementEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public static bool IsOnCashRollEmployee(int mID)
        {
            bool result = false;
            int OnCashRollEmployeeCategoryID = 0;
            try
            {
                EXCEL_ERP_TESTEntities conn = new EXCEL_ERP_TESTEntities();
                TBL_MP_Master_Employee emp = conn.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    APP_DEFAULTS dbDefault = conn.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EMPLOYEE_CATEGORY_ON_CASH_ROLL).FirstOrDefault();
                    if (dbDefault != null)
                    {
                        OnCashRollEmployeeCategoryID = dbDefault.DEFAULT_VALUE;
                        if (emp.fk_UL_Cat_Id == OnCashRollEmployeeCategoryID)
                            result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::IsOnCashRollEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public static bool IsDeletedEmployee(int mID)
        {
            bool result = false;
            try
            {
                EXCEL_ERP_TESTEntities conn = new EXCEL_ERP_TESTEntities();
                TBL_MP_Master_Employee emp = conn.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == mID).FirstOrDefault();
                if (emp != null)
                {
                    return (bool) emp.IsDelete;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::IsDeletedEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }


        public TBL_MP_Master_Employee GetEmployeeDbRecordByID(int empID)
        {
            TBL_MP_Master_Employee dbItem = null;
            try
            {
                dbItem = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeDbRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbItem;
        }
        public vEmployee GetEmployeeViewRecordByID(int empID)
        {
            vEmployee dbItem = null;
            try
            {
                dbItem = _dbContext.vEmployees.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeViewRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbItem;
        }

        //currFinYear
        public string GenerateNewEmployeeCode(int? currFinYear, int? currBrachID, int? companyID)
        {
            string keyCode = string.Empty;
            
            try
            {
                string strQry = "select top 1 EmployeeCode from TBL_MP_Master_Employee order by PK_EmployeeId desc";
                string LatestCode = _dbContext.Database.SqlQuery<string>(strQry).FirstOrDefault();
                int codevalue = int.Parse(LatestCode.Remove(0,1));
                codevalue++;
                keyCode = string.Format("E{0}", codevalue.ToString().PadLeft(5, '0'));

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GenerateNewEmployeeCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        public void UpdateEmployeeImageFileName(int empID, string strSourceFile)
        {
            try
            {
                string fName = string.Empty;
                TBL_MP_Master_Employee dbItem = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
                if (dbItem != null)
                {

                    if (dbItem.PhotoPath != null)
                        fName = dbItem.PhotoPath.ToString();
                    else
                        fName = (new AppCommon()).GetUniqueFileName(strSourceFile);

                    string newFilePath = string.Format("{0}{1}", AppCommon.GetEmployeeImagePath(), fName);
                    dbItem.PhotoPath = fName;
                    _dbContext.SaveChanges();

                    File.Copy(strSourceFile, newFilePath, true);

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeeImageFileName", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        public int AddNewEmployee(TBL_MP_Master_Employee model)
        {
            int newID = 0;
            try
            {
                // SAVE EMPLOYEE RECORD
                model.EmployeeCode = this.GenerateNewEmployeeCode(model.FK_YearID, model.FK_BranchID, model.FK_CompanyID);
                model.IsDelete = false;
                _dbContext.TBL_MP_Master_Employee.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_EmployeeId;

                // CREATE DEFAULT USER & SAVE 
                TBL_User_Master USR = new TBL_User_Master();
                USR.FK_EmployeeID = newID;
                USR.LoginId = model.EmployeeCode;
                USR.LoginPassword = AppCommon.EncryptText("default");
                USR.FK_RoleId = (new ServiceDesignationwiseDefaultRole()).GetDefaultRoleIdForDesignation((int)model.FK_DesignationId);
                USR.IsActive = true;
                USR.FK_BranchId = model.FK_BranchID;
                USR.Theme = (int)PaletteModeManager.Office2007Black;
                (new ServiceUsers()).AddNewUser(USR);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateEmployee(TBL_MP_Master_Employee model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee dbModel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == model.PK_EmployeeId).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.EmployeeCode = model.EmployeeCode;
                    dbModel.EmployeeName = model.EmployeeName;
                    dbModel.EmailAddress = model.EmailAddress;
                    dbModel.PhoneNo1 = model.PhoneNo1;
                    dbModel.FK_DepartmentId = model.FK_DepartmentId;
                    dbModel.FK_DesignationId = model.FK_DesignationId;
                    dbModel.FK_EmploymentTypeID = model.FK_EmploymentTypeID;
                    dbModel.isActive = model.isActive;
                    dbModel.IsResigned = model.IsResigned;
                    
                    dbModel.ModifiedBy = model.ModifiedBy;
                    dbModel.ModifiedDateTime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteEmployee(int empID, bool deletORnot)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee emp = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
                if (emp != null)
                {
                    emp.IsDelete = deletORnot;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::DeleteEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeactivateEmployee(int empID, bool activateORnot)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee emp = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
                if (emp != null)
                {
                    emp.isActive = activateORnot;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::DeactivateEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        #region GENERAL INFORMATION OF EMPLOYEE
        public EmployeeGeneralInfoModel GetEmployeeGeneralInfo(int empID)
        {
            EmployeeGeneralInfoModel model = null;
            try
            {
                TBL_MP_Master_Employee dbmodel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();

                if (dbmodel != null)
                {
                    model = new EmployeeGeneralInfoModel();
                    model.EmployeeID = dbmodel.PK_EmployeeId;
                    model.EmployeeCode = dbmodel.EmployeeCode;
                    model.ImageFileName = dbmodel.PhotoPath;

                    model.EmployeeFullName = dbmodel.EmployeeName;
                    if (dbmodel.DateOfAppointmnet != null)
                        model.DateOfAppointment = (DateTime)dbmodel.DateOfAppointmnet;
                    else
                        model.DateOfAppointment = null;

                    if (dbmodel.DateOfJoinig != null)
                        model.DateOfJoining = (DateTime)dbmodel.DateOfJoinig;
                    else
                        model.DateOfJoining = null;

                    if (dbmodel.ConfirmationDate != null)
                        model.ConfirmationDate = (DateTime)dbmodel.ConfirmationDate;
                    else
                        model.ConfirmationDate = null;

                    if(dbmodel.NoticePeriod!= null) model.NoticePeriod = (float)dbmodel.NoticePeriod;
                    if(dbmodel.ProbationPeriod != null) model.NoticePeriod = (float)dbmodel.ProbationPeriod;

                    model.ResidentialAddress = dbmodel.ResidentialAddress;
                    model.PermanentAddress = dbmodel.PermanentAddress;
                    if(dbmodel.JoiningLocationCityID!=null)
                        model.JoiningLocationCityID = (int)dbmodel.JoiningLocationCityID;
                    else
                        model.JoiningLocationCityID =0;
                    model.PhoneNo1 = dbmodel.PhoneNo1;
                    model.AltPhoneNo = dbmodel.AltPhoneNo;
                    model.EmployeeEmailAddress = dbmodel.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbmodel.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null)
                        model.DepartmentInfo = selItem;


                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbmodel.FK_DesignationId).FirstOrDefault();
                    if (selItem != null)
                        model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllBraches();
                    selItem = lstValues.Where(x => x.ID == int.Parse(dbmodel.FK_BranchID.ToString())).FirstOrDefault();
                    if (selItem != null)
                        model.EmployeeBranchInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null)
                        model.CategoryInfo = selItem;

                    lstValues = (new ServiceEmployee()).GetAllActiveEmployees();
                    selItem = lstValues.Where(x => x.ID == dbmodel.FK_BossID).FirstOrDefault();
                    if (selItem != null)
                        model.EmployeeBossInfo = selItem;

                    model.WeekOffDays = dbmodel.WeekOffDays;
                   model.OfficialPhoneNo = dbmodel.OfficePhoneNo;
                   model.OfficialEmailAddress = dbmodel.OfficeEmailAddr;



                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SetEmployeeGeneralInfo(EmployeeGeneralInfoModel model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee dbModel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == model.EmployeeID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.EmployeeName = model.EmployeeFullName;
                    dbModel.EmailAddress = model.EmployeeEmailAddress;
                    dbModel.PhoneNo1 = model.PhoneNo1;
                    dbModel.FK_DepartmentId = model.DepartmentInfo.ID;
                    dbModel.FK_DesignationId = model.DesignationInfo.ID;
                    dbModel.fk_Branch_BranchID = model.EmployeeBranchInfo.ID.ToString();
                    dbModel.fk_UL_Cat_Id = model.CategoryInfo.ID;
                    dbModel.DateOfAppointmnet = model.DateOfAppointment;
                    dbModel.DateOfJoinig = model.DateOfJoining;
                    dbModel.ConfirmationDate = model.ConfirmationDate;
                    dbModel.NoticePeriod = model.NoticePeriod;
                    dbModel.ProbationPeriod = model.ProbationPeriod;
                    dbModel.ResidentialAddress = model.ResidentialAddress;
                    dbModel.PermanentAddress = model.PermanentAddress;
                    dbModel.JoiningLocationCityID = model.JoiningLocationCityID;
                    dbModel.AltPhoneNo = model.AltPhoneNo;
                    dbModel.FK_BossID = model.EmployeeBossInfo.ID;
                    dbModel.WeekOffDays = model.WeekOffDays;
                   dbModel.OfficeEmailAddr = model.OfficialEmailAddress;
                    dbModel.OfficePhoneNo = model.OfficialPhoneNo;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetEmployeeGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            return result;
        }
        #endregion
      
        #region RESIGNATION INFORMATION OF EMPLOYEE
        public EmployeeResignationInfoModel GetEmployeeResignationInfo(int empID)
        {
            EmployeeResignationInfoModel model = null;
            try
            {
                TBL_MP_Master_Employee dbmodel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
                if (dbmodel != null)
                {
                    model = new EmployeeResignationInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbmodel.PK_EmployeeId;
                    model.EmployeeCode = dbmodel.EmployeeCode;
                    model.EmployeeFullName = dbmodel.EmployeeName;
                    model.EmployeeEmailAddress = dbmodel.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbmodel.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbmodel.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion  

                    if ((bool)dbmodel.IsResigned == true)
                    {
                        model.HoldSalary = (bool)dbmodel.HoldSalary;
                        model.IsResigned = (bool)dbmodel.IsResigned;

                        if (dbmodel.ResignedDate != null)
                            model.ResignedDate = (DateTime)dbmodel.ResignedDate;
                        else
                            model.ResignedDate = null;
                        if (dbmodel.LeavingDate != null)
                            model.LeavingDate = (DateTime)dbmodel.LeavingDate;
                        else
                            model.LeavingDate = null;

                        model.ReasonForResigning = dbmodel.ReasonForResigning;
                    }
                    else
                    {
                        model.IsResigned = model.HoldSalary = false;
                        model.ResignedDate = model.LeavingDate = null;
                        model.ReasonForResigning = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeResignationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SetEmployeeResignationInfo(EmployeeResignationInfoModel model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee dbModel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == model.EmployeeID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.ResignedDate = model.ResignedDate;
                    dbModel.LeavingDate = model.LeavingDate;
                    dbModel.ReasonForResigning = model.ReasonForResigning;
                    dbModel.HoldSalary = model.HoldSalary;
                    dbModel.IsResigned = model.IsResigned;

                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetEmployeeResignationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            return result;
        }
        #endregion

        #region GENERAL PERSONAL OF EMPLOYEE
        public EmployeePersonalInfoModel GetEmployeePersonalInfo(int empID)
        {
            EmployeePersonalInfoModel model = null;
            try
            {
                TBL_MP_Master_Employee dbmodel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();

                if (dbmodel != null)
                {
                    model = new EmployeePersonalInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbmodel.PK_EmployeeId;
                    model.EmployeeCode = dbmodel.EmployeeCode;
                    model.EmployeeFullName = dbmodel.EmployeeName;
                    model.EmployeeEmailAddress = dbmodel.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbmodel.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbmodel.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion

                    if (dbmodel.DateOfBirth != null)
                        model.DateOfBirth = (DateTime)dbmodel.DateOfBirth;
                    else
                        model.DateOfBirth = null;
                    model.BirthPlace = dbmodel.BirthPlace;

                    if (dbmodel.fk_UL_Gender_Id != null)
                    {
                        lstValues = (new ServiceMASTERS()).GetAllGenders();
                        selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_Gender_Id).FirstOrDefault();
                        if (selItem != null) model.GenderInfo = selItem;
                    }
                    else
                        model.GenderInfo = new SelectListItem() { };

                    if(dbmodel.FK_UL_BloodGroup_ID!=null)
                    {
                        lstValues = (new ServiceMASTERS()).GetAllBloodGroups();
                        selItem = lstValues.Where(x => x.ID == dbmodel.FK_UL_BloodGroup_ID).FirstOrDefault();
                        if (selItem != null) model.BloodGroupInfo = selItem;
                    }
                    else
                        model.BloodGroupInfo = new SelectListItem() { };
                    if (dbmodel.FK_UL_MaritalStatus_ID!=null)
                    {
                        lstValues = (new ServiceMASTERS()).GetAllMeritalStatus();
                        selItem = lstValues.Where(x => x.ID == dbmodel.FK_UL_MaritalStatus_ID).FirstOrDefault();
                        if (selItem != null) model.MeritalStatusInfo = selItem;
                    }
                    else
                        model.MeritalStatusInfo = new SelectListItem() { };

                    if (dbmodel.AnniversaryDate != null)
                        model.AnniversaryDate = dbmodel.AnniversaryDate;
                    else
                        model.AnniversaryDate = null;
                    model.Language = dbmodel.Language;

                    if (dbmodel.SeniorCitizen != null)
                        model.SeniorCitizen = (bool)dbmodel.SeniorCitizen;
                    else
                        model.SeniorCitizen = false;

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeePersonalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SetEmployeePersonalInfo(EmployeePersonalInfoModel model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee dbModel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == model.EmployeeID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.DateOfBirth = model.DateOfBirth;
                    dbModel.BirthPlace = model.BirthPlace;
                    dbModel.fk_UL_Gender_Id = model.GenderInfo.ID;
                    dbModel.FK_UL_BloodGroup_ID = model.BloodGroupInfo.ID;
                    dbModel.FK_UL_MaritalStatus_ID = model.MeritalStatusInfo.ID;
                    dbModel.Language = model.Language;
                    dbModel.AnniversaryDate = model.AnniversaryDate;
                    dbModel.SeniorCitizen = model.SeniorCitizen;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetEmployeePersonalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        #endregion
        #region WEEK-OFFS
        public bool IsWeekOffDayForEmployee(string upperDAY,int empID)
        {
            bool result = false;
            TBL_MP_Master_Employee dbEMP = null;
            try
            {
                dbEMP = this.GetEmployeeDbRecordByID(empID);
                if (dbEMP != null)
                {
                    if (dbEMP.WeekOffDays != null)
                    {
                        string[] arrWeekOffs = dbEMP.WeekOffDays.Split(',');
                        foreach (string s in arrWeekOffs)
                        {
                            if (s == upperDAY) result = true;
                        }
                    }
                    else
                    {
                        string strMessage = string.Format("WeekOff Days not defined for {0} ({1})", dbEMP.EmployeeName,dbEMP.EmployeeCode);
                        MessageBox.Show(strMessage, "Aborting operation");
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::IsWeekOffDayForEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion


        #region EMPLOYEE FAMILY & OTHER RELATIVES
        public List<EmployeeRelativeInfoModel> GetAllRelativesOfEmployee(int empID)
        {
            List<EmployeeRelativeInfoModel> lstRelatives = new List<EmployeeRelativeInfoModel>();
            try
            {
                List<SelectListItem> lstRelations = (new ServiceMASTERS()).GetAllFamilyRelationships();
                TBL_MP_Master_Employee dbEMP = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();
                
                List<TBL_MP_Master_Employee_Relative> dbRelatives = _dbContext.TBL_MP_Master_Employee_Relative.Where(x => x.FK_EmployeeID == empID).Where(x => x.IsDeleted == false).ToList();
                foreach (TBL_MP_Master_Employee_Relative dbModel in dbRelatives)
                {
                    EmployeeRelativeInfoModel model = new EmployeeRelativeInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbEMP.PK_EmployeeId;
                    model.EmployeeCode = dbEMP.EmployeeCode;
                    model.EmployeeFullName = dbEMP.EmployeeName;
                    model.EmployeeEmailAddress = dbEMP.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbEMP.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbEMP.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbEMP.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion
                    SelectListItem selRelation= lstRelations.Where(x => x.ID == dbModel.FK_UL_RelationID).FirstOrDefault();
                    model.EmplooyeeRelativeID = dbModel.EmployeeRelationshipID;
                    model.RelationshipID = selRelation.ID;
                    model.RelationshipName = selRelation.Description;
                    model.RelativeName = dbModel.RelativeName;
                    model.RelativeDOB = dbModel.RelativeDOB;
                    model.Remarks = dbModel.Remarks;
                    //model.ImageFileName = dbmodel.PhotoPath;
                    lstRelatives.Add(model);
                   
                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllRelativesOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstRelatives;
        }
        public TBL_MP_Master_Employee_Relative GetEmployeeRelativeDBRecordByID(int empRelationID)
        {
            TBL_MP_Master_Employee_Relative model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Employee_Relative.Where(x => x.EmployeeRelationshipID == empRelationID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeRelativeDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewEmployeeRelative(TBL_MP_Master_Employee_Relative model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_Employee_Relative.Add(model);
                _dbContext.SaveChanges();
                newID = model.EmployeeRelationshipID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewEmployeeRelative", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateEmployeeRelative(TBL_MP_Master_Employee_Relative model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_Relative dbModel = _dbContext.TBL_MP_Master_Employee_Relative.Where(x => x.EmployeeRelationshipID == model.EmployeeRelationshipID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_UL_RelationID = model.FK_UL_RelationID;
                    dbModel.RelativeName = model.RelativeName;
                    dbModel.RelativeDOB = model.RelativeDOB;
                    dbModel.Remarks = model.Remarks;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeeRelative", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteEmployeeRelative(int empRelID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_Relative model = _dbContext.TBL_MP_Master_Employee_Relative.Where(x => x.EmployeeRelationshipID == empRelID).FirstOrDefault();
                model.IsDeleted = true;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::DeleteEmployeeRelative", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        #endregion

        #region EMPLOYEE Bank Info
        public EmployeeBankInfoModel GetEmployeeBankInfo(int empID)
        {
            EmployeeBankInfoModel model = null;
           try
            {
                TBL_MP_Master_Employee dbmodel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empID).FirstOrDefault();

                if (dbmodel != null)
                {
                    model = new EmployeeBankInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbmodel.PK_EmployeeId;
                    model.EmployeeCode = dbmodel.EmployeeCode;
                    model.EmployeeFullName = dbmodel.EmployeeName;
                    model.EmployeeEmailAddress = dbmodel.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbmodel.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbmodel.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion
                    //these 2 fields have relation, so we can do like i mentioned below
                    if (dbmodel.FK_BankID != null)
                        model.BankInfo = new SelectListItem() { ID =(int)dbmodel.FK_BankID, Description = dbmodel.TBL_MP_Master_Bank.BankName };
                    if (dbmodel.FK_BankBranchID != null)
                        model.BankBranchInfo = new SelectListItem() { ID = (int)dbmodel.FK_BankBranchID, Description = dbmodel.TBL_MP_Master_BankBranch.BranchName };
                    // but for accounttype and payment mode...you do the same way  as done for populating others ex. category, department, designation etc.
                    lstValues = (new ServiceMASTERS()).GetAllBankAccountTypes();
                    selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_AccType_Id).FirstOrDefault();
                    if (selItem != null) model.BankAccountType = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllModeOfSalaryPayment();
                    selItem = lstValues.Where(x => x.ID == dbmodel.ModeOfPayment).FirstOrDefault();
                    if (selItem != null) model.PaymentModeType = selItem;
                    //now populate remaining fields
                    model.AccountNo = dbmodel.AccountNo;
                    model.DebitCardNo = dbmodel.ATMNo;
                    model.CreditCardNo = dbmodel.CreditCardNo;
                    model.PFNumber = dbmodel.PFNo;
                    model.ESICNumber = dbmodel.ESICNo;
                    model.NextCheckUpDate = dbmodel.DueDateOfNextMedicalCheckUp;
                    model.LastCheckUpDate = dbmodel.DateOfLastMedicalCheckUp;
                    model.PANNumber = dbmodel.PanNo;
                    model.UANNumber = dbmodel.UANNo;
                 }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeBankInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SetEmployeeBankInfo(EmployeeBankInfoModel model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee dbModel = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == model.EmployeeID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.FK_BankID = model.BankInfo.ID;
                    dbModel.FK_BankBranchID = model.BankBranchInfo.ID;
                    dbModel.AccountNo = model.AccountNo;
                    dbModel.fk_UL_AccType_Id = model.BankAccountType.ID;
                    dbModel.ATMNo = model.DebitCardNo;
                    dbModel.CreditCardNo = model.CreditCardNo;
                    dbModel.PFNo = model.PFNumber;
                    dbModel.ESICNo = model.ESICNumber;
                    dbModel.DateOfLastMedicalCheckUp = model.LastCheckUpDate;
                    dbModel.DueDateOfNextMedicalCheckUp = model.NextCheckUpDate;
                    dbModel.PanNo = model.PANNumber;
                    dbModel.UANNo = model.UANNumber;
                    dbModel.ModeOfPayment = model.PaymentModeType.ID;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetEmployeeBankInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            return result;
        }
        #endregion

        #region Employee ATTACHMENTS
        public int AddNewEmployeeAttachment(int empID, int docCategoryID, string title, string sourceFileNameWithPath, int createdBy)
        {
            int newID = 0;
            try
            {
                string newFileName = (new AppCommon()).GetUniqueFileName(sourceFileNameWithPath);
                string serverPath = AppCommon.GetEmployeeAttachmentsImagePath();
                string newFileNameWithPath = string.Format("{0}{1}", serverPath, newFileName);
                try
                {
                    File.Copy(sourceFileNameWithPath, newFileNameWithPath, true);
                }
                catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); return 0; }
                catch (ArgumentException ex) { MessageBox.Show(ex.Message); return 0; }
                catch (PathTooLongException ex) { MessageBox.Show(ex.Message); return 0; }
                catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); return 0; }
                catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); return 0; }
                catch (IOException ex) { MessageBox.Show(ex.Message); return 0; }
                catch (NotSupportedException ex) { MessageBox.Show(ex.Message); return 0; }



                TBL_MP_Master_Employee_Attachment objEmp = new TBL_MP_Master_Employee_Attachment();
                objEmp.FK_EmployeeId= empID;
                objEmp.FK_CategoryID = docCategoryID;
                objEmp.AttachmentFileName = newFileName;
                objEmp.Title = title;
                objEmp.IsActive = true;

                _dbContext.TBL_MP_Master_Employee_Attachment.Add(objEmp);
                _dbContext.SaveChanges();
                newID = objEmp.PK_AttachmentID;

                // MAINTAINING HISTORY OF ATTACHED DOCUMENT
                TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                history.AttachmentID = newID;
                history.EntityType = (int)APP_ENTITIES.EMPLOYEES;
                history.EmployeeID = createdBy;
                history.CreateDatetime = AppCommon.GetServerDateTime();
                string userName = ServiceEmployee.GetEmployeeNameByID(createdBy);
                history.Description = string.Format("New Document created by {0} dt. {1}", userName, history.CreateDatetime.Value.ToString("dd MMMyy hh:mmtt"));
                _dbContext.TBL_MP_CRM_SM_DocumentHistory.Add(history);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewEmployeeAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateEmployeeAttachment(int AttachmentID, int docCategoryID, string title, string sourceFileNameWithPath, int modifiedBy)
        {
            bool result = false;
            try
            {
                string serverPath = AppCommon.GetEmployeeAttachmentsImagePath();
                TBL_MP_Master_Employee_Attachment objEmp = _dbContext.TBL_MP_Master_Employee_Attachment.Where(x => x.PK_AttachmentID == AttachmentID).FirstOrDefault();

                File.Copy(sourceFileNameWithPath, string.Format("{0}{1}", serverPath, objEmp.AttachmentFileName), true);
                objEmp.FK_CategoryID = docCategoryID;
                objEmp.Title = title;
                _dbContext.SaveChanges();


                TBL_MP_CRM_SM_DocumentHistory historyLead = new TBL_MP_CRM_SM_DocumentHistory();
                historyLead.AttachmentID = AttachmentID;
                historyLead.EntityType = (int)APP_ENTITIES.EMPLOYEES;
                historyLead.EmployeeID = modifiedBy;
                historyLead.CreateDatetime = AppCommon.GetServerDateTime();
                string userName = ServiceEmployee.GetEmployeeNameByID(modifiedBy);
                historyLead.Description = string.Format("Modified by {0} dt. {1}", userName, historyLead.CreateDatetime.Value.ToString("dd MMMyy hh:mmtt"));
                _dbContext.TBL_MP_CRM_SM_DocumentHistory.Add(historyLead);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeeAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public bool DeleteEmployeeAttachment(int attachmentID, string reason, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_Attachment editItem = _dbContext.TBL_MP_Master_Employee_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = empID;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::DeleteEmployeeAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public TBL_MP_Master_Employee_Attachment GetEmployeeAttachmentDBRecord(int attachmentID)
        {
            return _dbContext.TBL_MP_Master_Employee_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
        }
        public List<SelectListItem> GetAllDeletedEmployeeAttachments()
        {
            List<SelectListItem> lstAttachments = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_Employee_Attachment > empAttachments = _dbContext.TBL_MP_Master_Employee_Attachment.Where(xx => xx.IsActive == false).ToList();
                foreach (TBL_MP_Master_Employee_Attachment dbItem in empAttachments)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = dbItem.PK_AttachmentID;
                    item.Description = string.Format("{0} ({1})\n{2}", dbItem.Title, dbItem.TBL_MP_Master_UserList.Description1, dbItem.TBL_MP_Master_Employee.EmployeeName);
                    item.Code = AppCommon.GetEmployeeAttachmentsImagePath() + dbItem.AttachmentFileName;
                    lstAttachments.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceEmployee::GetAllDeletedEmployeeAttachments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttachments;
        }
        public bool UndeleteEmployeeAttachment(int attachmentID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_Attachment editItem = _dbContext.TBL_MP_Master_Employee_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceEmployee::UndeleteEmployeeAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region Employee Qualification Info
        public List<EmployeeQualificationInfoModel> GetAllQualificationOfEmployee(int empQuaID)
        {
            List<EmployeeQualificationInfoModel> lstQual = new List<EmployeeQualificationInfoModel>();
            try
            {
               // List<SelectListItem> lstRelations = (new ServiceMASTERS()).GetAllFamilyRelationships();
                TBL_MP_Master_Employee dbEMP = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == empQuaID).FirstOrDefault();

                List<TBL_MP_Master_Employee_Qualification> dbQualification = _dbContext.TBL_MP_Master_Employee_Qualification.Where(x => x.FK_EmployeeId == empQuaID).ToList();
                foreach (TBL_MP_Master_Employee_Qualification dbModel in dbQualification)
                {
                    EmployeeQualificationInfoModel model = new EmployeeQualificationInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbEMP.PK_EmployeeId;
                    model.EmployeeCode = dbEMP.EmployeeCode;
                    model.EmployeeFullName = dbEMP.EmployeeName;
                    model.EmployeeEmailAddress = dbEMP.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbEMP.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbEMP.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbEMP.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion
                    //SelectListItem selRelation = lstRelations.Where(x => x.ID == dbModel.FK_UL_RelationID).FirstOrDefault();
                    model.EmployeeQualificationID = dbModel.EmployeeQualificationID;
                    model.QualificationName = dbModel.Qualification;
                    model.NameOfInstitute = dbModel.NameOfInstitute;
                    model.Grade = dbModel.Grade;
                    lstQual.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllRelativesOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstQual;
        }
        public TBL_MP_Master_Employee_Qualification GetEmployeeQualificationDBRecordByID(int empQualID)
        {
            TBL_MP_Master_Employee_Qualification model = null;
            try
            {
              model = _dbContext.TBL_MP_Master_Employee_Qualification.Where(x => x.EmployeeQualificationID == empQualID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeQualificationDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewEmployeeQualification(TBL_MP_Master_Employee_Qualification model)
        {
            int newID = 0;
            try
            {
                model.isActive = true;
                _dbContext.TBL_MP_Master_Employee_Qualification.Add(model);
                _dbContext.SaveChanges();
               newID = model.EmployeeQualificationID;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewEmployeeQualification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateEmployeeQualification(TBL_MP_Master_Employee_Qualification model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_Qualification dbModel = _dbContext.TBL_MP_Master_Employee_Qualification.Where(x => x.EmployeeQualificationID == model.EmployeeQualificationID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.Qualification = model.Qualification;
                    dbModel.NameOfInstitute = model.NameOfInstitute;
                    dbModel.Grade= model.Grade;
                    
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeeQualification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region Last  Employer Info
        public List<LastEmployerInfoModel> GetAllLastEmployerInfo(int LstEmpID)
        {
            List<LastEmployerInfoModel> lstEmployer = new List<LastEmployerInfoModel>();
            try
            {
                // List<SelectListItem> lstRelations = (new ServiceMASTERS()).GetAllFamilyRelationships();
                TBL_MP_Master_Employee dbEMP = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == LstEmpID).FirstOrDefault();

                List<TBL_MP_Master_Employee_LastEmployerDetail> dbLastEmployer = _dbContext.TBL_MP_Master_Employee_LastEmployerDetail.Where(x => x.FK_EmployeeId == LstEmpID).ToList();
                foreach (TBL_MP_Master_Employee_LastEmployerDetail dbModel in dbLastEmployer)
                {
                    LastEmployerInfoModel model = new LastEmployerInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbEMP.PK_EmployeeId;
                    model.EmployeeCode = dbEMP.EmployeeCode;
                    model.EmployeeFullName = dbEMP.EmployeeName;
                    model.EmployeeEmailAddress = dbEMP.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbEMP.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbEMP.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbEMP.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion
                    //SelectListItem selRelation = lstRelations.Where(x => x.ID == dbModel.FK_UL_RelationID).FirstOrDefault();
                    model.isActive = dbModel.isActive;
                    model.LastEmployerID = dbModel.LastEmployerID;
                    model.LastEmployerName = dbModel.LastEmployerName;
                    model.LastEmployerAddress = dbModel.Address;
                    model.ContactNo = (int)dbModel.ContactNo;
                    
                    lstEmployer.Add(model);

                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllLastEmployerInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstEmployer;
        }
        public TBL_MP_Master_Employee_LastEmployerDetail GetLastEmployerInfoDBRecordByID(int LastEmpID)
        {
            TBL_MP_Master_Employee_LastEmployerDetail model = null;
            try
            {
                 model = _dbContext.TBL_MP_Master_Employee_LastEmployerDetail.Where(x => x.LastEmployerID == LastEmpID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetLastEmployerInfoDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewLastEmployerInfo(TBL_MP_Master_Employee_LastEmployerDetail model)
        {
            int newID = 0;
            try
            {
                model.isActive = true;
                _dbContext.TBL_MP_Master_Employee_LastEmployerDetail.Add(model);
                _dbContext.SaveChanges();
                newID = model.LastEmployerID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewLastEmployerInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateLastEmployerInfo(TBL_MP_Master_Employee_LastEmployerDetail model)
        {
            bool result = false;
            try
            {
                 TBL_MP_Master_Employee_LastEmployerDetail dbModel = _dbContext.TBL_MP_Master_Employee_LastEmployerDetail.Where(x => x.LastEmployerID== model.LastEmployerID).FirstOrDefault();
                 if (dbModel != null)
                 {

                     dbModel.LastEmployerID = model.LastEmployerID;
                     dbModel.LastEmployerName = model.LastEmployerName;
                     dbModel.Address = model.Address;
                     dbModel.ContactNo = model.ContactNo;
                    dbModel.isActive = model.isActive;
                     _dbContext.SaveChanges();
                     result = true;
                 }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateLastEmployerInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }


        #endregion
        #region EMPLOYEE ADDITIONAL AND MEDICAL INFO
        public EmployeeAdditionalInfoModel GetEmployeeAdditonalAndMedicalInfo(int empID)
        {
            //  EmployeeAdditionalInfoModel model = new EmployeeAdditionalInfoModel();
            EmployeeAdditionalInfoModel model = null;
            try
            {

                TBL_MP_Master_Employee dbmodel = this.GetEmployeeDbRecordByID(empID);
                if (dbmodel != null)
                {
                    //populate all basic & additional info of the employee
                    //populate all medical records into model


                    model = new EmployeeAdditionalInfoModel();
                    #region scatter base model
                    model.EmployeeID = dbmodel.PK_EmployeeId;
                    model.EmployeeCode = dbmodel.EmployeeCode;
                    model.EmployeeFullName = dbmodel.EmployeeName;
                    model.EmployeeEmailAddress = dbmodel.EmailAddress;
                    List<SelectListItem> lstValues = (new ServiceMASTERS()).GetAllDepartments();
                    SelectListItem selItem = lstValues.Where(x => x.ID == dbmodel.FK_DepartmentId).FirstOrDefault();
                    if (selItem != null) model.DepartmentInfo = selItem;
                    lstValues = (new ServiceMASTERS()).GetAllDesignation();
                    selItem = lstValues.Where(x => x.ID == dbmodel.FK_DesignationId).FirstOrDefault();
                    if (selItem != null) model.DesignationInfo = selItem;

                    lstValues = (new ServiceMASTERS()).GetAllEmployeeCategories();
                    selItem = lstValues.Where(x => x.ID == dbmodel.fk_UL_Cat_Id).FirstOrDefault();
                    if (selItem != null) model.CategoryInfo = selItem;
                    #endregion

                    model.Nationality = dbmodel.Nationality;
                    model.AADHAR_NO = dbmodel.UniqueIdNo;

                    //for licence Info
                    model.LicenceNo = dbmodel.LicenceNo;
                    if (dbmodel.LicenceIssueDate != null)
                        model.LicenceIssueDate = (DateTime)dbmodel.LicenceIssueDate;
                    else
                        model.LicenceIssueDate = null;

                    if (dbmodel.LicenceExpiryDate != null)
                        model.LicenceExpiryDate = (DateTime)dbmodel.LicenceExpiryDate;
                    else
                        model.LicenceExpiryDate = null;

                    //For PASSPORT INFO
                    model.PassportNo = dbmodel.PassportNo;
                    if (dbmodel.PassportIssueDate != null)
                        model.PassportIssueDate = (DateTime)dbmodel.PassportIssueDate;
                    else
                        model.PassportIssueDate = null;
                    if (dbmodel.PassportExpiryDate != null)
                        model.PassportExpiryDate = (DateTime)dbmodel.PassportExpiryDate;
                    else
                        model.PassportExpiryDate = null;

                    //FOR VISA INFO
                    model.VisaNo = dbmodel.VisaNo;
                    if (dbmodel.VisaIssueDate != null)
                        model.VisaIssueDate = (DateTime)dbmodel.VisaIssueDate;
                    else
                        model.VisaIssueDate = null;
                    if (dbmodel.VisaExpiryDate != null)
                        model.VisaExpiryDate = (DateTime)dbmodel.VisaExpiryDate;
                    else
                        model.VisaExpiryDate = null;
                    if (dbmodel.Fk_VisaType != null)
                    {
                        lstValues = (new ServiceMASTERS()).GetAllVisaType();
                        selItem = lstValues.Where(x => x.ID == dbmodel.Fk_VisaType).FirstOrDefault();
                        if (selItem != null) model.VisaTypeInfo = selItem;
                    }
                    else
                        model.VisaTypeInfo = new SelectListItem() { };


                    //WORK PERMIT INFO
                    model.WorkPermitNo = dbmodel.WorkPermit;
                    model.WorkPermitType = dbmodel.Fk_WorkPermityType;
                    if (dbmodel.WorkPermitIssueDate != null)
                        model.WorkPermitIssueDate = (DateTime)dbmodel.WorkPermitIssueDate;
                    else
                        model.WorkPermitIssueDate = null;
                    if (dbmodel.WorkPermitExpiryDate != null)
                        model.WorkPermitExpiryDate = (DateTime)dbmodel.WorkPermitExpiryDate;
                    else
                        model.WorkPermitExpiryDate = null;


                    model.MedicalInfo = this.GetEmployeeMedicalInfoDbRecordsList(empID);

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeAdditonalAndMedicalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SetEmployeeAdditonalInfo(EmployeeAdditionalInfoModel model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee dbmodel = this.GetEmployeeDbRecordByID(model.EmployeeID);
                if (dbmodel != null)
                {
                    // replce all values from additional info object into employee master table
                    dbmodel.Nationality = model.Nationality;
                    dbmodel.UniqueIdNo = model.AADHAR_NO;
                    dbmodel.LicenceNo = model.LicenceNo;
                    dbmodel.LicenceIssueDate = model.LicenceIssueDate;
                    dbmodel.LicenceExpiryDate = model.LicenceExpiryDate;
                    dbmodel.PassportNo = model.PassportNo;
                    dbmodel.PassportIssueDate = model.PassportIssueDate;
                    dbmodel.PassportExpiryDate = model.PassportExpiryDate;
                    dbmodel.VisaNo = model.VisaNo;
                    dbmodel.Fk_VisaType = model.VisaTypeInfo.ID;
                    dbmodel.VisaIssueDate = model.VisaIssueDate;
                    dbmodel.VisaExpiryDate = model.VisaExpiryDate;
                    dbmodel.WorkPermit = model.WorkPermitNo;
                    dbmodel.Fk_WorkPermityType = model.WorkPermitType;
                    dbmodel.WorkPermitIssueDate = model.WorkPermitIssueDate;
                    dbmodel.WorkPermitExpiryDate = model.WorkPermitExpiryDate;
                    _dbContext.SaveChanges();
                    result = true;

                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetEmployeeAdditonalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public List<TBL_MP_Master_Employee_MedicalDetail> GetEmployeeMedicalInfoDbRecordsList(int empID)
        {
            List<TBL_MP_Master_Employee_MedicalDetail> lstMedical = new List<TBL_MP_Master_Employee_MedicalDetail>();
            try
            {
                lstMedical.AddRange(_dbContext.TBL_MP_Master_Employee_MedicalDetail.Where(c => c.fk_EmployeeId == empID).ToList());

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeMedicalInfoDbRecordsList", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstMedical;
        }
        public TBL_MP_Master_Employee_MedicalDetail GetEmployeeMedicalInfoDbRecord(int empMedicalID)
        {
            TBL_MP_Master_Employee_MedicalDetail model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Employee_MedicalDetail.Where(x => x.Pk_EmpMedicalId == empMedicalID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeMedicalInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public List<SelectListItem> GetEmployeeMedicalInfoList(int empID)
        {
            List<SelectListItem> lstMedical = new List<SelectListItem>();
            try
            {
                lstMedical = (from xx in _dbContext.TBL_MP_Master_Employee_MedicalDetail.AsEnumerable()
                              where xx.fk_EmployeeId == empID && xx.IsActive == true
                              select new SelectListItem()
                              {
                                  ID = xx.Pk_EmpMedicalId,
                                  Code = xx.MedicalName,
                                  Description = string.Format("Company: {0}\nCard: {1} {2}\n", xx.CompanyName, xx.CardNo, xx.CardType),
                                  IsActive = xx.IsActive
                              }).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeMedicalInfoDbRecordsList", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstMedical;
        }

        public int AddNewEmployeeMedicalnfo(TBL_MP_Master_Employee_MedicalDetail model)
        {
            int newID = 0;
            try
            {
                model.IsActive = true;
                _dbContext.TBL_MP_Master_Employee_MedicalDetail.Add(model);
                _dbContext.SaveChanges();
                newID = model.Pk_EmpMedicalId;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewEmployeeMedicalnfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateEmployeeMedicalnfo(TBL_MP_Master_Employee_MedicalDetail model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_MedicalDetail dbModel = _dbContext.TBL_MP_Master_Employee_MedicalDetail.Where(sachin => sachin.Pk_EmpMedicalId == model.Pk_EmpMedicalId).FirstOrDefault();
                dbModel.MedicalName = model.MedicalName;
                dbModel.FK_UL_RelationID = model.FK_UL_RelationID;
                dbModel.CardNo = model.CardNo;
                dbModel.CardType = model.CardType;
                dbModel.CompanyName = model.CompanyName;
                dbModel.IssueDate = model.IssueDate;
                dbModel.ExpiryDate = model.ExpiryDate;
                dbModel.Remark = model.Remark;
                dbModel.IsActive = model.IsActive;


                _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeeMedicalnfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        #endregion
    
        #region EMPLOYEEWISE CTC CONFIG.
        public List<EmployeeSalaryHeadModel> GetAllAllouncesSalaryHeadsForEmployee(int empID)
        {
            List<EmployeeSalaryHeadModel> lstAllounces = new List<EmployeeSalaryHeadModel>();
            try
            {
                int designationID = 0;
                int typeID = 0;
                TBL_MP_Master_Employee dbEMP = this.GetEmployeeDbRecordByID(empID);
                if (dbEMP != null)
                {
                    designationID = (int)dbEMP.FK_DesignationId;
                    typeID = dbEMP.FK_EmploymentTypeID;
                }

                List<SelectListItem> lstSalaryHeads = (new ServiceMASTERS()).GetAllSalaryHeads();
                int ALLOUNCE_CATAGAORY_ID = 0;
                ALLOUNCE_CATAGAORY_ID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadEARNINGType).FirstOrDefault().DEFAULT_VALUE;
                List<TBl_MP_HR_SalaryHead> lstSalaryHeadsAllounces = (new ServiceSalaryHead()).GetAllSalaryHeadsofType(ALLOUNCE_CATAGAORY_ID);
                foreach (TBl_MP_HR_SalaryHead salaryHeadItem in lstSalaryHeadsAllounces)
                {
                    EmployeeSalaryHeadModel model = new EmployeeSalaryHeadModel();
                    model.ID = 0;
                    model.EmployeeID = empID;
                    model.SalaryHeadID = salaryHeadItem.pK_SH_ID;
                    model.SalaryHeadName = lstSalaryHeads.Where(x => x.ID == salaryHeadItem.fK_Usrlst_SH_ID).FirstOrDefault().Description;
                    model.ApplicableChargesType = ITEM_CHARGE_TYPE.LUMPSUM;
                    model.ApplicableChargesValue = 0;
                    model.SalaryHeadAmount = 0;
                    model.IsSelected = false;
                    //model.EmploymentType = EmploymentType;
                    lstAllounces.Add(model);
                }


                foreach (EmployeeSalaryHeadModel item in lstAllounces)
                {
                    TBL_MP_Master_Employee_CTC foundEmployee = (from xx in _dbContext.TBL_MP_Master_Employee_CTC
                                                                where xx.FK_EmployeeId == empID && xx.FK_SalaryHeadID == item.SalaryHeadID
                                                                select xx
                                                        ).FirstOrDefault();

                    if (foundEmployee != null)
                    {
                        item.ApplicableChargesType = (ITEM_CHARGE_TYPE)foundEmployee.ApplicableChargesType;
                        item.ApplicableChargesValue = foundEmployee.ApplicableChargesValue;
                        item.ID = foundEmployee.PK_ID;
                        item.HeadForCalculation = (SalaryHeadCalculatedOn)foundEmployee.SalaryHeadCalculatedOn;
                        item.SalaryHeadAmount = foundEmployee.SalaryHeadAmount;
                        item.EmploymentTYPE = (EMPLOYMENT_TYPE)foundEmployee.FK_EmploymentTypeID;
                        item.IsSelected = !foundEmployee.IsDeleted;

                    }
                    else
                    {
                        TBL_MP_HR_DesignationwiseSalaryHeads found = (from xx in _dbContext.TBL_MP_HR_DesignationwiseSalaryHeads
                                                                      where xx.FK_DesignationID == designationID && xx.FK_SalaryHeadID == item.SalaryHeadID && xx.IsDeleted == false && xx.FK_EmploymentTypeID == typeID
                                                                      select xx
                                                                ).FirstOrDefault();

                        if (found != null)
                        {
                            item.ApplicableChargesType = (ITEM_CHARGE_TYPE)found.ApplicableChargesType;
                            item.ApplicableChargesValue = found.ApplicableChargesValue;
                            item.SalaryHeadAmount = found.SalaryHeadAmount;
                            item.ID = 0;

                            item.EmploymentTYPE = (EMPLOYMENT_TYPE)found.FK_EmploymentTypeID;
                            if (!found.IsDeleted) item.IsSelected = true;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllAllouncesSalaryHeadsForEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAllounces;

        }
        public List<EmployeeSalaryHeadModel> GetAllDeductionsSalaryHeadsForEmployee(int empID)
        {
            List<EmployeeSalaryHeadModel> lstDeduction = new List<EmployeeSalaryHeadModel>();
            try
            {
                int designationID = 0;
                int typeID = 0;
                TBL_MP_Master_Employee dbEMP = this.GetEmployeeDbRecordByID(empID);
                if (dbEMP != null)
                {
                    designationID = (int)dbEMP.FK_DesignationId;
                    typeID = dbEMP.FK_EmploymentTypeID;
                }

                List<SelectListItem> lstSalaryHeads = (new ServiceMASTERS()).GetAllSalaryHeads();
                int DEDUCTION_CATAGAORY_ID = 0;
                DEDUCTION_CATAGAORY_ID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadDEDUCTIONType).FirstOrDefault().DEFAULT_VALUE;
                List<TBl_MP_HR_SalaryHead> lstSalaryHeadsDeduction = (new ServiceSalaryHead()).GetAllSalaryHeadsofType(DEDUCTION_CATAGAORY_ID);
                foreach (TBl_MP_HR_SalaryHead salaryHeadItem in lstSalaryHeadsDeduction)
                {
                    EmployeeSalaryHeadModel model = new EmployeeSalaryHeadModel();
                    model.ID = 0;
                    model.EmployeeID = empID;
                    model.SalaryHeadID = salaryHeadItem.pK_SH_ID;
                    model.SalaryHeadName = lstSalaryHeads.Where(x => x.ID == salaryHeadItem.fK_Usrlst_SH_ID).FirstOrDefault().Description;
                    model.ApplicableChargesType = ITEM_CHARGE_TYPE.LUMPSUM;
                    model.ApplicableChargesValue = 0;
                    model.SalaryHeadAmount = 0;
                    model.IsSelected = false;
                    //model.EmploymentType = EmploymentType;
                    lstDeduction.Add(model);
                }


                foreach (EmployeeSalaryHeadModel item in lstDeduction)
                {
                    TBL_MP_Master_Employee_CTC foundEmployee = (from xx in _dbContext.TBL_MP_Master_Employee_CTC
                                                                where xx.FK_EmployeeId == empID && xx.FK_SalaryHeadID == item.SalaryHeadID
                                                                select xx
                                                        ).FirstOrDefault();

                    if (foundEmployee != null)
                    {
                        item.ApplicableChargesType = (ITEM_CHARGE_TYPE)foundEmployee.ApplicableChargesType;
                        item.ApplicableChargesValue = foundEmployee.ApplicableChargesValue;
                        item.ID = foundEmployee.PK_ID;
                        item.HeadForCalculation =(SalaryHeadCalculatedOn) foundEmployee.SalaryHeadCalculatedOn;
                        item.SalaryHeadAmount = foundEmployee.SalaryHeadAmount;
                        item.EmploymentTYPE = (EMPLOYMENT_TYPE)foundEmployee.FK_EmploymentTypeID;
                        item.IsSelected = !foundEmployee.IsDeleted;
                    }
                    else
                    {
                        TBL_MP_HR_DesignationwiseSalaryHeads found = (from xx in _dbContext.TBL_MP_HR_DesignationwiseSalaryHeads
                                                                      where xx.FK_DesignationID == designationID && xx.FK_SalaryHeadID == item.SalaryHeadID && xx.IsDeleted == false && xx.FK_EmploymentTypeID == typeID
                                                                      select xx
                                                                ).FirstOrDefault();

                        if (found != null)
                        {
                            item.ApplicableChargesType = (ITEM_CHARGE_TYPE)found.ApplicableChargesType;
                            item.ApplicableChargesValue = found.ApplicableChargesValue;
                            item.SalaryHeadAmount = found.SalaryHeadAmount;
                            item.ID = 0;

                            item.EmploymentTYPE = (EMPLOYMENT_TYPE)found.FK_EmploymentTypeID;
                            if (!found.IsDeleted) item.IsSelected = true;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllDeductionsSalaryHeadsForEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstDeduction;
        }
        public bool UpdateEmployeewiseSalaryHead(EmployeeSalaryHeadModel model)
        {
            bool result = false;
            TBL_MP_Master_Employee_CTC dbModel = null;
            try
            {
                if (model.ID == 0)
                    dbModel = new TBL_MP_Master_Employee_CTC();
                else
                    dbModel = _dbContext.TBL_MP_Master_Employee_CTC.Where(x => x.PK_ID == model.ID).FirstOrDefault();

                if (model.IsSelected)
                {

                    dbModel.FK_EmployeeId = model.EmployeeID;
                    dbModel.FK_SalaryHeadID = model.SalaryHeadID;
                    dbModel.ApplicableChargesType = (int)model.ApplicableChargesType;
                    dbModel.ApplicableChargesValue = model.ApplicableChargesValue;
                    dbModel.SalaryHeadAmount = model.SalaryHeadAmount;
                    dbModel.IsDeleted = !model.IsSelected;
                    dbModel.SalaryHeadCalculatedOn = (int)model.HeadForCalculation;
                    dbModel.FK_EmploymentTypeID = (int)model.EmploymentTYPE;
                }
                else
                {
                    // dbModel.FK_EmployeeId = model.EmployeeID;
                    //  dbModel.FK_SalaryHeadID = model.SalaryHeadID;
                    dbModel.SalaryHeadCalculatedOn =(int) SalaryHeadCalculatedOn.NONE;
                    dbModel.ApplicableChargesType = (int)ITEM_CHARGE_TYPE.LUMPSUM;
                    dbModel.ApplicableChargesValue = 0;
                    dbModel.SalaryHeadAmount = 0;
                    dbModel.IsDeleted = true;
                }


                if (dbModel.PK_ID == 0)
                    _dbContext.TBL_MP_Master_Employee_CTC.Add(dbModel);

                _dbContext.SaveChanges();
                result = true;


            }


            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeewiseSalaryHead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public decimal GetEmployeeBasicSalary(int empID)
        {
            decimal basicAmount = 0;
            try
            {
                APP_DEFAULTS defaultBasicSalaryHead = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault();
                if (defaultBasicSalaryHead == null)
                {
                    MessageBox.Show("Basic Salary Head ID is not defined in APP_DEFAULTS", "Contact Administrator");
                    return 0;
                }
                int basicSalaryHeadID = defaultBasicSalaryHead.DEFAULT_VALUE;
                TBL_MP_Master_Employee_CTC ctc=(from xx in _dbContext.TBL_MP_Master_Employee_CTC where xx.FK_EmployeeId == empID && xx.FK_SalaryHeadID == basicSalaryHeadID select xx).FirstOrDefault();
                if (ctc != null)
                {
                    basicAmount = ctc.SalaryHeadAmount;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeeBasicSalary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return basicAmount;
        }
        #endregion

        #region EMPLOYEE LEAVE CONFIGURATION
        public List<LeaveConfigurationModel> GetAllLeavesConfigurationOfEmployeeForYear(int empID, int yearID)
        {
            List<LeaveConfigurationModel> lstLeaves = new List<LeaveConfigurationModel>();
            try
            {
                List<TBL_MP_Master_Employee_LeaveConfiguration> lst = _dbContext.TBL_MP_Master_Employee_LeaveConfiguration.Where(x => x.FK_FinYearID == yearID && x.FK_EmployeeID == empID).ToList();
                foreach (TBL_MP_Master_Employee_LeaveConfiguration item in lst)
                {
                    LeaveConfigurationModel model = new LeaveConfigurationModel();
                    model.LeaveID = item.PK_LeaveID;
                    model.LeaveTypeID = item.FK_LeaveTypeID;
                    model.LeaveTypeName = item.TBL_MP_Admin_UserList.Admin_UserList_Desc;
                    model.MaxDaysAllow = item.MaxDaysAllow;
                    model.LeavesEarned = item.LeavesEarned;
                    model.LeaveEnchashable = item.LeaveEnchashable;
                    model.CarryForwardLeave = item.CarryForwardLeave;
                    model.CarryForwardLimitDays = item.CarryForwardLimitDays;
                    model.ApplicableInProbation = item.ApplicableInProbation;
                    model.EncashableSalaryHeadIDs = item.EncashableSalaryHeadIDs;
                    model.EncashableSalaryHeadNames = item.EncashableSalaryHeadNames;
                    model.EmployeeID = item.FK_EmployeeID;
                    model.FinYearID = item.FK_FinYearID;
                    model.IsActive = item.IsActive;

                    lstLeaves.Add(model);


                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllLeavesForBranchAndYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLeaves;

        }
        public TBL_MP_Master_Employee_LeaveConfiguration GetEmpLeaveInfoDbRecord(int LeaveID)
        {
            TBL_MP_Master_Employee_LeaveConfiguration model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Employee_LeaveConfiguration.Where(x => x.PK_LeaveID == LeaveID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmpLeaveInfoDbRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewEmpLeaveConfiguration(TBL_MP_Master_Employee_LeaveConfiguration model)
        {
            int newID = 0;
            try
            {

                _dbContext.TBL_MP_Master_Employee_LeaveConfiguration.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_LeaveID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::AddNewEmpLeaveConfiguration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateEmpLeaveConfiguration(TBL_MP_Master_Employee_LeaveConfiguration model)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_LeaveConfiguration dbModel = _dbContext.TBL_MP_Master_Employee_LeaveConfiguration.Where(x => x.PK_LeaveID == model.PK_LeaveID).FirstOrDefault();
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
                dbModel.FK_EmployeeID = model.FK_EmployeeID;
                dbModel.LeavesEarned = model.LeavesEarned;
              
                _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmpLeaveConfiguration", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        #endregion
    
        #region ATTENDANCE COLOR
        public void SetColorPreference(int empID, ATTENDANCE_TYPE typeAttendnace, Color clr)
        {
            try
            {
                string strColor= JsonConvert.SerializeObject(clr);
                TBL_ColorPreference model = _dbContext.TBL_ColorPreference.Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                if (model == null)
                {
                    model = new TBL_ColorPreference();
                    model.FK_EmployeeID = empID;
                    _dbContext.TBL_ColorPreference.Add(model);
                    _dbContext.SaveChanges();
                }

                model = _dbContext.TBL_ColorPreference.Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                switch (typeAttendnace)
                {
                    case ATTENDANCE_TYPE.PRESENT: model.ColorPresent = strColor; break;
                    case ATTENDANCE_TYPE.ABSENT: model.ColorAbsent = strColor; break;
                    case ATTENDANCE_TYPE.LEAVE: model.ColorLeave = strColor; break;
                    case ATTENDANCE_TYPE.OUT_DOOR: model.ColorOutdoor = strColor; break;
                    case ATTENDANCE_TYPE.COMP_OFF: model.ColorCompOff = strColor; break;
                    case ATTENDANCE_TYPE.LATE_COMING: model.ColorLateComing = strColor; break;
                    case ATTENDANCE_TYPE.EARLY_GOING: model.ColorEarlyLeaving = strColor; break;
                    case ATTENDANCE_TYPE.HOLIDAY: model.ColorHoliday = strColor; break;
                    case ATTENDANCE_TYPE.WEEK_OFF: model.ColorWeekOff = strColor; break;
                    case ATTENDANCE_TYPE.MULTIPLE: model.ColorDuplicates = strColor; break;
                }
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetColorPreference", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<AttendanceColorModel> GetAttendanceColorPreferencesOfEmployee(int empID)
        {
            List<AttendanceColorModel> lst = new List<AttendanceColorModel>();
            try
            {
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.PRESENT, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.ABSENT, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.LEAVE, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.OUT_DOOR, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.COMP_OFF, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.LATE_COMING, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.EARLY_GOING, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.HOLIDAY, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.WEEK_OFF, ColorAttendance = Color.White });
                lst.Add(new AttendanceColorModel() { TypeAttendance = ATTENDANCE_TYPE.MULTIPLE, ColorAttendance = Color.White });


                TBL_ColorPreference model = _dbContext.TBL_ColorPreference.Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.ColorPresent))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.PRESENT).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorPresent);

                    if (!string.IsNullOrEmpty(model.ColorAbsent))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.ABSENT).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorAbsent);

                    if (!string.IsNullOrEmpty(model.ColorLeave))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LEAVE).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorLeave);

                    if (!string.IsNullOrEmpty(model.ColorOutdoor))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.OUT_DOOR).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorOutdoor);

                    if (!string.IsNullOrEmpty(model.ColorCompOff))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.COMP_OFF).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorCompOff);

                    if (!string.IsNullOrEmpty(model.ColorLateComing))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.LATE_COMING).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorLateComing);

                    if (!string.IsNullOrEmpty(model.ColorEarlyLeaving))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.EARLY_GOING).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorEarlyLeaving);

                    if (!string.IsNullOrEmpty(model.ColorHoliday))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.HOLIDAY).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorHoliday);

                    if (!string.IsNullOrEmpty(model.ColorWeekOff))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.WEEK_OFF).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorWeekOff);

                    if (!string.IsNullOrEmpty(model.ColorDuplicates))
                        lst.Where(x => x.TypeAttendance == ATTENDANCE_TYPE.MULTIPLE).FirstOrDefault().ColorAttendance = JsonConvert.DeserializeObject<Color>(model.ColorDuplicates);

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAttendanceColorPreferencesOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        #endregion
        
        #region EMPLOYEE PAYSLIP GENERATION
        public EmployeePayslipModel GetEmployeePayslipModel(int empID, DateTime salaryMonth)
        {
            EmployeePayslipModel model = new EmployeePayslipModel();
            try
            { 
                /*  CHECK IF PAYSLIP IS GENERATED FOR THIS EMPLOYEE OR NNOT
                    IF THE PAYSLIP EXISTS..GET JSON OBJECT FROM DATABASE AND SERIALIZE
                    ELSE GENERATE NEW EmployeePayslipModel OBJECT
                */

                string paySlipMonth = string.Format("{0}", salaryMonth.ToString("MMM-yyyy").ToUpper());
               
                TBL_MP_HR_PayslipMaster dbPayslip = (from xx in _dbContext.TBL_MP_HR_PayslipMaster where xx.FK_EmployeeID==empID && xx.PayslipMonth==paySlipMonth select xx).FirstOrDefault();
                if (dbPayslip == null)
                {
                    model = GenerateNewPayslip(empID, salaryMonth);
                }
                else
                {
                    string strJSON = dbPayslip.PayslipJSON;
                    model = JsonConvert.DeserializeObject<EmployeePayslipModel>(strJSON);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetEmployeePayslipModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public EmployeePayslipModel GenerateNewPayslip(int empID, DateTime salaryMonth)
        {
            EmployeePayslipModel model = new EmployeePayslipModel();
            int basicSalaryHeadID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
            int daSalaryHeadID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.daSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;

            try
            {

                model.EmployeeID = empID;
                if(model.EmployeeID== 23303)
                {

                }
                model.FromDate = new DateTime(salaryMonth.Year, salaryMonth.Month, 1);
                model.ToDate = new DateTime(salaryMonth.Year, salaryMonth.Month, DateTime.DaysInMonth(salaryMonth.Year, salaryMonth.Month));
                model.SalaryMonth = string.Format("{0}", salaryMonth.ToString("MMM-yyyy").ToUpper());
                model.EmployeeName = ServiceEmployee.GetEmployeeNameByID(empID);
                EmployeeAttendanceSummaryModel summary = (new ServiceAttendance()).GetAttendanceSummaryOfEmployeeForMonth(empID, salaryMonth);
                if (summary != null)
                {
                    model.TotalDays = summary.TotalDays.Days;
                    model.PaidDays = (summary.PaidDays.Days >= summary.TotalDays.Days)? summary.TotalDays.Days : summary.PaidDays.Days ;
                    model.BasicSalaryDefault = this.GetEmployeeBasicSalary(empID);
                    model.BasicSalaryPerDay = model.BasicSalaryDefault / model.TotalDays;
                    model.BasicSalaryApplied = (model.BasicSalaryDefault / model.TotalDays) * model.PaidDays;
                    
                }
                #region GET ALL EARNING ALLOUNCES
                List<EmployeeSalaryHeadModel> lstAllAllounces = this.GetAllAllouncesSalaryHeadsForEmployee(empID);
                APP_DEFAULTS earningType = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalaryHeadEARNINGType).FirstOrDefault();
                if (earningType == null)
                {
                    MessageBox.Show("Earnings Type of SalaryHead is not configured in APP_DEFAULTS", "Contact Administrator");
                    return null;
                }
                int AllounceCategoryID = earningType.DEFAULT_VALUE;
                List<vEmployCTC> lstEmpAllounces = (from xx in _dbContext.vEmployCTCs where xx.FK_EmployeeId == empID && xx.fk_Usrlst_HdrType_ID == AllounceCategoryID select xx).ToList();
                foreach (EmployeeSalaryHeadModel headItem in lstAllAllounces)
                {
                    EmployeePayslipItemModel itemAllunce = new EmployeePayslipItemModel();
                    itemAllunce.SalaryHeadID = headItem.SalaryHeadID;
                    itemAllunce.SalaryHeadName = headItem.SalaryHeadName;
                    itemAllunce.ChargesType = ITEM_CHARGE_TYPE.NONE;
                    itemAllunce.SalaryHeadValue = 0;
                    itemAllunce.SalaryHeadAmount = 0;
                    itemAllunce.IsStandard = true;
                    itemAllunce.IsApplied =false;
                    itemAllunce.HeadForCalculation = SalaryHeadCalculatedOn.NONE;
                    vEmployCTC foundSalaryHead =lstEmpAllounces.Where(x => x.FK_SalaryHeadID == headItem.SalaryHeadID).FirstOrDefault();
                    if (foundSalaryHead != null)
                    {
                        if(headItem.SalaryHeadID== basicSalaryHeadID)
                            foundSalaryHead.SalaryHeadAmount = model.BasicSalaryApplied;
                                                                     
                        itemAllunce.HeadForCalculation =(SalaryHeadCalculatedOn) foundSalaryHead.SalaryHeadCalculatedOn;
                        ITEM_CHARGE_TYPE mType = (ITEM_CHARGE_TYPE)foundSalaryHead.ApplicableChargesType;
                        switch (mType)
                        {
                            case ITEM_CHARGE_TYPE.LUMPSUM:
                                if (itemAllunce.SalaryHeadID != 1)
                                {
                                    itemAllunce.SalaryHeadAmount = foundSalaryHead.SalaryHeadAmount;
                                    decimal perdayallowance = (itemAllunce.SalaryHeadAmount / model.TotalDays) * model.PaidDays;
                                    itemAllunce.SalaryHeadAmount = perdayallowance;
                                }
                                if (itemAllunce.SalaryHeadID == 1)
                                    itemAllunce.SalaryHeadAmount = foundSalaryHead.SalaryHeadAmount;
                                break;
                            case ITEM_CHARGE_TYPE.PERCENTAGE:
                                if (headItem.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                    itemAllunce.SalaryHeadAmount = (model.BasicSalaryApplied * foundSalaryHead.ApplicableChargesValue) / 100;

                                if (headItem.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                    itemAllunce.SalaryHeadAmount = (model.GrossSalaryAmount * foundSalaryHead.ApplicableChargesValue) / 100;


                                if (headItem.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                                {
                                    decimal basicAmount = model.MonthlyAllounces.Where(x => x.SalaryHeadID == basicSalaryHeadID).FirstOrDefault().SalaryHeadAmount;
                                    decimal daAmount = model.MonthlyAllounces.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;
                                    headItem.SalaryHeadAmount = ((basicAmount + daAmount) * headItem.ApplicableChargesValue)/ 100;

                                }
                                break;
                        }

                        itemAllunce.HeadForCalculation = (SalaryHeadCalculatedOn)foundSalaryHead.SalaryHeadCalculatedOn;
                        itemAllunce.ChargesType = mType;
                        itemAllunce.SalaryHeadValue = foundSalaryHead.ApplicableChargesValue;
                        itemAllunce.IsApplied = true;
                    }

                    model.MonthlyAllounces.Add(itemAllunce);

                }
                #endregion
                #region GET ALL DEDUCTIONS
                List<EmployeeSalaryHeadModel> lstAllDeductions = this.GetAllDeductionsSalaryHeadsForEmployee(empID);
                APP_DEFAULTS deductionType = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalaryHeadDEDUCTIONType).FirstOrDefault();
                if (deductionType == null)
                {
                    MessageBox.Show("Deduction type of SalaryHEad is not configured in APP_DEFAULTS", "Contact Administrator");
                    return null;
                }
                int DeductionCategoryID = deductionType.DEFAULT_VALUE;
                List<vEmployCTC> lstEmpDeductions = (from xx in _dbContext.vEmployCTCs where xx.FK_EmployeeId == empID && xx.fk_Usrlst_HdrType_ID == DeductionCategoryID select xx).ToList();
                foreach (EmployeeSalaryHeadModel item in lstAllDeductions)
                {
                    EmployeePayslipItemModel itemDeduction = new EmployeePayslipItemModel();
                    itemDeduction.SalaryHeadID = item.SalaryHeadID;
                    itemDeduction.SalaryHeadName = item.SalaryHeadName;
                    itemDeduction.ChargesType = ITEM_CHARGE_TYPE.NONE;
                    itemDeduction.SalaryHeadValue = 0;
                    itemDeduction.SalaryHeadAmount = 0;
                    itemDeduction.IsStandard = true;
                    itemDeduction.IsApplied = false;
                    vEmployCTC foundSalaryHead = lstEmpDeductions.Where(x => x.FK_SalaryHeadID == item.SalaryHeadID).FirstOrDefault();
                    if (foundSalaryHead != null)
                    {
                        itemDeduction.HeadForCalculation = (SalaryHeadCalculatedOn)foundSalaryHead.SalaryHeadCalculatedOn;
                        itemDeduction.ChargesType =(ITEM_CHARGE_TYPE) foundSalaryHead.ApplicableChargesType;
                        itemDeduction.SalaryHeadValue = foundSalaryHead.ApplicableChargesValue;
                        itemDeduction.IsApplied = true;
                        itemDeduction.SalaryHeadValue = foundSalaryHead.ApplicableChargesValue;
                        itemDeduction.IsApplied = true;
                    }
                    model.MonthlyDeducations.Add(itemDeduction);
                }
                #endregion
                #region CALCULATE DEDUCTION 
                foreach (EmployeePayslipItemModel item in model.MonthlyDeducations)
                {
                    if (item.SalaryHeadID == basicSalaryHeadID)
                        item.SalaryHeadAmount = model.BasicSalaryApplied;
                    
                    switch (item.ChargesType)
                    {
                        case ITEM_CHARGE_TYPE.LUMPSUM:
                            item.SalaryHeadAmount = item.SalaryHeadValue;
                            break;
                        case ITEM_CHARGE_TYPE.PERCENTAGE:
                            if(item.HeadForCalculation== SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                item.SalaryHeadAmount = (model.BasicSalaryApplied * item.SalaryHeadValue) / 100;
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                item.SalaryHeadAmount = (model.GrossSalaryAmount * item.SalaryHeadValue) / 100;
                            if (item.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            {
                                decimal daAmount = model.MonthlyAllounces.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;
                                item.SalaryHeadAmount = ((model.BasicSalaryApplied + daAmount)*item.SalaryHeadValue) / 100;
                            }
                            break;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GenerateNewPayslip", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SaveEmployeePayslip(EmployeePayslipModel model)
        {
            bool result = false;
            TBL_MP_HR_PayslipMaster dbModel = null;
            string strJSON = string.Empty;
            try
            {
                if (model == null)
                {
                    MessageBox.Show("Error locating Payroll data, EmployeePayslipModel received null.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dbModel = (from xx in _dbContext.TBL_MP_HR_PayslipMaster
                           where xx.FK_EmployeeID == model.EmployeeID && xx.PayslipMonth == model.SalaryMonth
                           select xx).FirstOrDefault();
                if (dbModel == null)
                {
                    dbModel = new TBL_MP_HR_PayslipMaster();
                    dbModel.IsApproved = false;
                }

                dbModel.FK_EmployeeID = model.EmployeeID;
                dbModel.FromDate = model.FromDate;
                dbModel.ToDate = model.ToDate;
                dbModel.PayslipMonth = model.SalaryMonth.ToUpper();
                dbModel.BasicSalary = model.BasicSalaryApplied;
                dbModel.GrossSalary = model.GrossSalaryAmount;
                dbModel.TotalAllounces = model.AdditionalAllouncesAmount + model.StandardAllouncesAmount;
                dbModel.TotalDeductions = model.StandardDeducationAmount + model.AdditionalDeducationAmount;
                dbModel.NetSalary = model.NetSalaryAmount;
                
                if (dbModel.PayslipID == 0)
                {
                    dbModel.PayslipJSON = "";
                    _dbContext.TBL_MP_HR_PayslipMaster.Add(dbModel);
                    _dbContext.SaveChanges();
                    model.PayslipID = dbModel.PayslipID;
                }
                
                dbModel = (from xx in _dbContext.TBL_MP_HR_PayslipMaster
                           where xx.PayslipID== dbModel.PayslipID select xx).FirstOrDefault();
                if (dbModel != null)
                {
                    string output = JsonConvert.SerializeObject(model);
                    dbModel.PayslipJSON = output;
                }
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SaveEmployeePayslip", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion


        #region EMPLOYEE AUTHORITIES
        public List<vEmployee> GetAllAuthoritiesOfEmployee(int empID)
        {
            List<vEmployee> lstAuthorities = new List<vEmployee>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from vEmployee where PK_EmployeeId IN ");
                sb.Append("(select FK_AuthorityID from TBL_MP_Master_Employee_Authority where FK_EmployeeID={0}) ");
                string strQuery = string.Format(sb.ToString(), empID);
                lstAuthorities = _dbContext.Database.SqlQuery<vEmployee>(strQuery).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::GetAllAuthoritiesOfEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAuthorities;
        }
        public bool UpdateEmployeeAuthorities(int EmployeeID, string selectedAuthorityIDs)
        {
            bool result = false;
            try
            {
                string[] arrAuthorities = selectedAuthorityIDs.Split(',');
                for (int i = 0; i < arrAuthorities.GetUpperBound(0); i++)
                {
                    int currAuthorityID = int.Parse(arrAuthorities[i]);
                    TBL_MP_Master_Employee_Authority dbRec = (  from xx in _dbContext.TBL_MP_Master_Employee_Authority
                                                                where xx.FK_EmployeeID == EmployeeID && xx.FK_AuthorityID == currAuthorityID
                                                                select xx).FirstOrDefault();
                    if (dbRec == null)
                    {
                        dbRec = new TBL_MP_Master_Employee_Authority();
                        dbRec.FK_EmployeeID = EmployeeID;
                        dbRec.FK_AuthorityID = currAuthorityID;
                        _dbContext.TBL_MP_Master_Employee_Authority.Add(dbRec);
                        _dbContext.SaveChanges();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::UpdateEmployeeAuthorities", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool RemoveEmployeeAuthority(int EmployeeID, int SelectedAuthorityID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Employee_Authority dbRec = (from xx in _dbContext.TBL_MP_Master_Employee_Authority
                                                          where xx.FK_EmployeeID == EmployeeID && xx.FK_AuthorityID ==SelectedAuthorityID
                                                          select xx).FirstOrDefault();
                if (dbRec != null)
                {
                    _dbContext.TBL_MP_Master_Employee_Authority.Remove(dbRec);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::RemoveEmployeeAuthority", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion 


    }
}
