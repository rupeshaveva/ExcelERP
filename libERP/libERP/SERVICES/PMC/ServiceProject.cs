using Braincase.GanttChart;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.PROJECTS;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.PMC
{
    public class ServiceProject : DefaultService
    {
        public int PROJECT_STATUS_OPEN { get; set; }
        public int PROJECT_STATUS_INPROGRESS { get; set; }
        public int PROJECT_STATUS_PROCESSED { get; set; }
        public int PROJECT_STATUS_CLOSED { get; set; }

        public ServiceProject(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
            //   PopulateStatusVariables();
        }
        public ServiceProject()
        {
            _dbContext = new EXCEL_ERP_TESTEntities(); PopulateStatusVariables();
        }
        private void PopulateStatusVariables()
        {
            try
            {
                // POPULATING project STATUS
                PROJECT_STATUS_OPEN = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectStatus_Open).FirstOrDefault().DEFAULT_VALUE;
                PROJECT_STATUS_INPROGRESS = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectStatus_InProgress).FirstOrDefault().DEFAULT_VALUE;
                PROJECT_STATUS_PROCESSED = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectStatus_Processed).FirstOrDefault().DEFAULT_VALUE;
                PROJECT_STATUS_CLOSED = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectStatus_Closed).FirstOrDefault().DEFAULT_VALUE;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<SelectListItem> GetAllProjectStatuses()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectStatusAdminCategory).FirstOrDefault().DEFAULT_VALUE;
                List<TBL_MP_Admin_UserList> lstDB = (from pp in _dbContext.TBL_MP_Admin_UserList where pp.Fk_Admin_CategoryID == catID select pp).ToList();
                foreach (TBL_MP_Admin_UserList item in lstDB)
                {
                    SelectListItem newItem = new SelectListItem();
                    newItem.ID = item.PKID;
                    newItem.Description = item.Admin_UserList_Desc;
                    lst.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetAllProjectStatuses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllProjectsForGridDisplay(int statusID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_PMC_ProjectMaster.AsEnumerable()
                       where xx.FK_ProjectStatusID == statusID && xx.IsActive == true
                       select new SelectListItem()
                       {
                           ID = xx.PK_ProjectID,
                           Description = string.Format("{0}\n{1}\n{2}", xx.ProjectName, xx.ProjectNumber, xx.Tbl_MP_Master_Party.PartyName)
                       }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetAllProjectsForSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllProjectsForSelection()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_PMC_ProjectMaster.AsEnumerable()
                       select new SelectListItem()
                       {
                           ID = xx.PK_ProjectID,
                           Description = string.Format("{0}\n{1}", xx.ProjectName, xx.ProjectNumber)
                       }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetAllProjectsForSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllActiveProjectsForSelection()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_PMC_ProjectMaster.AsEnumerable()
                        where xx.IsActive == true
                        orderby xx.ProjectName
                        select new SelectListItem()
                        {
                            ID = xx.PK_ProjectID,
                            Description = string.Format("{0} [{1}]", xx.ProjectName, xx.ProjectNumber)
                        }).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject:: GetAllActiveProjectsForSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<MultiSelectListItem> GetAllActiveProjectsForMultipleSelection()
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            try
            {
                list = (from xx in _dbContext.TBL_MP_PMC_ProjectMaster.AsEnumerable()
                        where xx.IsActive == true
                        orderby xx.ProjectName
                        select new MultiSelectListItem()
                        {
                            ID = xx.PK_ProjectID,
                            Description = string.Format("{0} [{1}]", xx.ProjectName, xx.ProjectNumber)
                        }).ToList();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject:: GetAllActiveProjectsForMultipleSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return list;
        }
        public List<MultiSelectListItem> GetAllProjectsForMultipleSelection()
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_PMC_ProjectMaster.AsEnumerable()
                       select new MultiSelectListItem()
                       {
                           Selected = false,
                           ID = xx.PK_ProjectID,
                           Description = string.Format("{0}\n{1}", xx.ProjectName, xx.ProjectNumber),
                           EntityType = APP_ENTITIES.ALL_PROJECTS
                       }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetAllProjectsForMultipleSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }

        public TBL_MP_PMC_ProjectMaster GetProjectDBInfoByID(int projectID)
        {
            TBL_MP_PMC_ProjectMaster model = null;
            try
            {
                model = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == projectID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetProjectDBInfoByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public string GenerateNewProjectNumber(int currFinYear, int currBrachID, int companyID)
        {
            string keyCode = string.Empty;
            int intPreviousYearCount = 0;
            int cnt;
            string strNumber;
            string strQuery = string.Empty;
            try
            {
                TBL_MP_Admin_VoucherNoSetup objVoucherSetup = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.PROJECT &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_PMC_ProjectMaster WHERE ProjectNumber NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objVoucherSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.PROJECT &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_PMC_ProjectMaster lastProjectPrevYear = (from xx in _dbContext.TBL_MP_PMC_ProjectMaster
                                                                    where xx.FK_YearID == currFinYear - 1 &&
                                                                    xx.FK_BranchID == currBrachID &&
                                                                    xx.FK_CompanyID == companyID
                                                                    orderby xx.CreatedDatetime descending
                                                                    select xx).FirstOrDefault();
                    if (lastProjectPrevYear != null)
                    {
                        string lstnumber = lastProjectPrevYear.ProjectNumber.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
                        intPreviousYearCount = int.Parse(lstnumber);
                    }
                    else
                        intPreviousYearCount = 1;

                    cnt += intPreviousYearCount;
                }
                else
                {
                    cnt += (int)objVoucherSetup.NoStartingFrom;
                }

                strNumber = cnt.ToString().PadLeft(objVoucherSetup.NoPad, '0');
                //0083 

                keyCode += objVoucherSetup.NoPrefix + objVoucherSetup.NoSeperator + strNumber + objVoucherSetup.NoSeperator + objVoucherSetup.NoPostfix;
                // XL/SO/0083/2018-19
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GenerateNewProjectNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        public int AddNewProject(TBL_MP_PMC_ProjectMaster model)
        {
            int newID = 0;
            try
            {
                //model.ProjectNumber = this.GenerateNewProjectNumber(model.FK_YearID, model.FK_BranchID, model.FK_CompanyID);
                _dbContext.TBL_MP_PMC_ProjectMaster.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_ProjectID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::AddNewProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateProject(TBL_MP_PMC_ProjectMaster model)
        {
            bool result = false;
            try
            {
                TBL_MP_PMC_ProjectMaster dbModel = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == model.PK_ProjectID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.ProjectName = model.ProjectName;
                    dbModel.ProjectDate = model.ProjectDate;
                    dbModel.StartDate = model.StartDate;
                    dbModel.EndDate = model.EndDate;
                    dbModel.BillingClientID = model.BillingClientID;
                    dbModel.BillingClientAddressID = model.BillingClientAddressID;
                    dbModel.SiteClientID = model.SiteClientID;
                    dbModel.SiteClientAddressID = model.SiteClientAddressID;
                    dbModel.ModifiedBy = model.ModifiedBy;
                    dbModel.ModifiedDatetime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::UpdateProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteProject(int ProjectID, int deletedBy)
        {
            try
            {
                TBL_MP_PMC_ProjectMaster model = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == ProjectID).FirstOrDefault();
                if (model != null)
                {
                    model.IsActive = false;
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
                MessageBox.Show(errMessage, "ServiceProject::DeleteProject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        public string GetProjectBillingAddress(int projectID)
        {
            string strAddress = string.Empty;
            try
            {

                TBL_MP_PMC_ProjectMaster dbProject = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == projectID).FirstOrDefault();
                int BillingAddressID = dbProject.BillingClientAddressID;
                Tbl_MP_Master_Party_Address dbAddress = _dbContext.Tbl_MP_Master_Party_Address.Where(x => x.PK_AddressID == BillingAddressID).FirstOrDefault();
                strAddress = dbAddress.Address;
                strAddress += string.Format("\n{0} {1}, {2}",
                    dbAddress.TBL_MP_Master_City.CityName,
                    dbAddress.TBL_MP_Master_State.StateName,
                    dbAddress.TBL_MP_Master_Country.CountryName
                    );
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetProjectBillingAddress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strAddress;
        }
        public string GetProjectSiteAddress(int projectID)
        {
            string strAddress = string.Empty;
            try
            {
                TBL_MP_PMC_ProjectMaster dbProject = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == projectID).FirstOrDefault();
                int SiteAddressID = dbProject.SiteClientAddressID;
                Tbl_MP_Master_Party_Address dbAddress = _dbContext.Tbl_MP_Master_Party_Address.Where(x => x.PK_AddressID == SiteAddressID).FirstOrDefault();
                strAddress = dbAddress.Address;
                strAddress += string.Format("\n{0} {1}, {2}",
                    dbAddress.TBL_MP_Master_City.CityName,
                    dbAddress.TBL_MP_Master_State.StateName,
                    dbAddress.TBL_MP_Master_Country.CountryName
                    );
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetProjectSiteAddress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strAddress;
        }

        #region PROJECT PLANNING
        public bool UpdateProjectPlanning(int projectID, ProjectManager _mManager, PROJECT_PLAN_TYPE SelectedPlanType)
        {
            bool result = false;
            TBL_MP_PMC_Project_Planning model = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(ms, _mManager);
                ms.Seek(0, 0);
                byte[] arrProject = ms.ToArray();

                model = _dbContext.TBL_MP_PMC_Project_Planning.Where(x => x.FK_ProjectID == projectID).Where(x => x.ProjectPlanType == (int)SelectedPlanType).FirstOrDefault();
                if (model == null)
                    model = new TBL_MP_PMC_Project_Planning() { FK_ProjectID = projectID };

                model.ProjectPlan = arrProject;
                model.ProjectPlanType = (int)SelectedPlanType;

                if (model.PK_ProjectPlanID == 0)
                    _dbContext.TBL_MP_PMC_Project_Planning.Add(model);

                _dbContext.SaveChanges();

                ms.Close();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::UpdateProjectPlanning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public ProjectManager GetProjectPlanForProjectID(int ID, PROJECT_PLAN_TYPE planType)
        {
            TBL_MP_PMC_Project_Planning model = null;
            ProjectManager _manager = null;
            try
            {
                model = _dbContext.TBL_MP_PMC_Project_Planning.Where(x => x.FK_ProjectID == ID).Where(x => x.ProjectPlanType == (int)planType).FirstOrDefault();
                if (model != null)
                {
                    MemoryStream ms2 = new MemoryStream();
                    byte[] buf = model.ProjectPlan;
                    ms2.Write(buf, 0, buf.Length);
                    ms2.Seek(0, 0);
                    BinaryFormatter b = new BinaryFormatter();
                    _manager = (ProjectManager)b.Deserialize(ms2);
                    ms2.Close();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetProjectPlanofProjectID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _manager;
        }
        #endregion

        public ProjectGeneralInfo GetProjectGeneralInfo(int ProjID)
        {
            ProjectGeneralInfo model = null;
            try
            {
                TBL_MP_PMC_ProjectMaster dbmodel = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == ProjID).FirstOrDefault();

                if (dbmodel != null)
                {
                    model = new ProjectGeneralInfo();
             
                    model.ProjectID = dbmodel.PK_ProjectID;
                    model.ProjectCode = dbmodel.ProjectNumber;
                    model.ProjectName = dbmodel.ProjectName;
                    if (dbmodel.ProjectDate != null)
                        model.EntryDate = (DateTime)dbmodel.ProjectDate;
                    else
                        model.EntryDate = null;
                    if (dbmodel.StartDate != null)
                        model.StartDate = (DateTime)dbmodel.StartDate;
                    else
                        model.StartDate = null;
                    if (dbmodel.EndDate != null)
                        model.EndDate = (DateTime)dbmodel.EndDate;
                    else
                        model.EndDate = null;

                    model.ProjectStatus = dbmodel.FK_ProjectStatusID.ToString();
                    model.BillingClientID = (int)dbmodel.BillingClientID;
                    model.BillingClientAddressID = dbmodel.BillingClientAddressID;
                    model.SiteClientID = (int)dbmodel.SiteClientID;
                    model.SiteClientAddressID = dbmodel.SiteClientAddressID;
                    model.IsActive = dbmodel.IsActive;
                   



                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::GetProjectGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return model;
        }
        public bool SetProjectGeneralInfo(ProjectGeneralInfo model)
        {
            bool result = false;
            try
            {
                TBL_MP_PMC_ProjectMaster dbModel = _dbContext.TBL_MP_PMC_ProjectMaster.Where(x => x.PK_ProjectID == model.ProjectID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.ProjectNumber = model.ProjectCode;
                    dbModel.ProjectName = model.ProjectName;
                    dbModel.ProjectDate = (DateTime)model.EntryDate;
                    dbModel.StartDate = (DateTime)model.StartDate;
                    dbModel.EndDate = (DateTime)model.EndDate;
                    dbModel.BillingClientID = model.BillingClientID;
                    dbModel.BillingClientAddressID = model.BillingClientAddressID;
                    dbModel.SiteClientID = model.SiteClientID;
                    dbModel.SiteClientAddressID = model.SiteClientAddressID;
                    dbModel.FK_ProjectStatusID = int.Parse(model.ProjectStatus);
                    dbModel.IsActive = model.IsActive;

                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProject::SetProjectGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

     

    }

}
