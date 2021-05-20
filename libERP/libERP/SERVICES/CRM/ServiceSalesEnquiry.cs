using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

using Newtonsoft.Json;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.MODELS;
using libERP.MODELS.CRM;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;

namespace libERP.SERVICES.CRM
{
    

    public class ServiceSalesEnquiry : DefaultService 
    {
        int STATUS_OPEN_ID = 0;
        int STATUS_LOST_ID = 0;
        int STATUS_CONVERTED_ID = 0;
        int STATUS_CLOSED_ID = 0;
        int STATUS_INPROCESS_ID = 0;
        int STATUS_HOLD_ID = 0;

        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                STATUS_OPEN_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EnquiryStatusOpen).FirstOrDefault().DEFAULT_VALUE;
                STATUS_LOST_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EnquiryStatusLost).FirstOrDefault().DEFAULT_VALUE;
                STATUS_CONVERTED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EnquiryStatusConverted).FirstOrDefault().DEFAULT_VALUE;
                STATUS_CLOSED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.EnquiryStatusClose).FirstOrDefault().DEFAULT_VALUE;
                STATUS_INPROCESS_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusInProcess).FirstOrDefault().DEFAULT_VALUE;
                int STATUS_HOLD_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusHold).FirstOrDefault().DEFAULT_VALUE;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public ServiceSalesEnquiry(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
            PopulateStatusVariables();
        }
        public ServiceSalesEnquiry() { _dbContext = new EXCEL_ERP_TESTEntities(); PopulateStatusVariables(); }

        public string GenerateNewSalesEnquiryNumber(int currFinYear, int currBrachID, int companyID)
        {
            string keyCode = string.Empty;
            int intPreviousYearCount = 0;
            int cnt;
            string strNumber;
            string strQuery = string.Empty;
            try
            {
                // 0123
                TBL_MP_Admin_VoucherNoSetup objVoucherSetup = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.SALES_ENQUIRY &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SalesEnquiry WHERE SalesEnquiry_No NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objVoucherSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.SALES_ENQUIRY &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_CRM_SalesEnquiry lastSEPrevYear = (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry
                                                              where xx.FK_YearID == (currFinYear - 1) &&
                                                            xx.FK_BranchID == currBrachID &&
                                                            xx.FK_CompanyID == companyID
                                                              orderby xx.CreatedDatetime descending
                                                              select xx).FirstOrDefault();
                    if (lastSEPrevYear != null)
                    {
                        string lstnumber = lastSEPrevYear.SalesEnquiry_No.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
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
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GenerateNewSalesEnquiryNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        //public string GeneratePrimaryCode()
        //{
        //    string newCode = string.Empty;
        //    try
        //    {
        //        newCode = new ServiceMASTERS(_dbContext).GetNextEntityCode(DB_FORM_IDs.SALES_ENQUIRY);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return newCode;
        //}

        public BindingList<SelectListItem> GetSalesEnquirySelectionList(int EnquiryStatus)
        {
            BindingList<SelectListItem> lst = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesEnquiry> lstDBItems = null;
                if (EnquiryStatus == 0)
                    lstDBItems = (from x in _dbContext.TBL_MP_CRM_SalesEnquiry where x.IsActive==true orderby x.SalesEnquiry_Date descending select x).ToList();
                else
                    lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry where  xx.FK_Userlist_Enquiry_Status_ID== EnquiryStatus && xx.IsActive == true orderby xx.SalesEnquiry_Date descending select xx).ToList();

                foreach (TBL_MP_CRM_SalesEnquiry item in lstDBItems)
                {
                    SelectListItem newItem = new SelectListItem()
                    {
                        ID = item.PK_SalesEnquiryID,
                        Code=item.SalesEnquiry_No,
                        Description = string.Format("{0}  Dt. {1}\n{2}", item.SalesEnquiry_No, item.SalesEnquiry_Date.ToString("dd-MM-yyyy"), item.Project_Name)
                    };
                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GetSalesEnquirySelectionList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public BindingList<MultiSelectListItem> GetMultiselectSalesEnquiriesList()
        {
            BindingList<MultiSelectListItem> lst = new BindingList<MultiSelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesEnquiry> lstDBItems = null;
                lstDBItems = _dbContext.TBL_MP_CRM_SalesEnquiry.OrderByDescending(x => x.SalesEnquiry_Date).ToList();
                
                foreach (TBL_MP_CRM_SalesEnquiry item in lstDBItems)
                {
                    MultiSelectListItem newItem = new MultiSelectListItem()
                    {
                        ID = item.PK_SalesEnquiryID,
                        Code = item.SalesEnquiry_No,
                        Description = string.Format("{0}  Dt. {1}\n{2}", item.SalesEnquiry_No, item.SalesEnquiry_Date.ToString("dd-MM-yyyy"), item.Project_Name)
                    };
                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }
        public SalesEnquiryMaster GetSalesEnquiryMasterInfo(int enquiryID)
        {
            SalesEnquiryMaster model = new SalesEnquiryMaster();
            TBL_MP_CRM_SalesEnquiry dbModel = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == enquiryID).FirstOrDefault();
            if (dbModel != null)
            {
                model.LeadNumber = dbModel.TBL_MP_CRM_SM_SalesLead.LeadNo.ToString();
                model.EnquiryNo = dbModel.SalesEnquiry_No;
                model.EnquiryDate = (DateTime)dbModel.SalesEnquiry_Date;
                model.ProjectName = dbModel.Project_Name;
                model.ProjectSector = dbModel.Sector;
                model.EnquiryGeneratedBy = dbModel.Enquiry_Genrated_By;
                model.ProjectType = dbModel.FK_Userlist_Project_SubType_ID.ToString();
                model.Description = dbModel.General_Description;

                model.EnquiryType = dbModel.FK_Userlist_EnquiryType_ID.ToString();

                model.EnquiryDueDate = dbModel.Enquiry_Due_Date;
                model.SubmissionModeID = dbModel.FK_Userlist_Submission_Mode_ID.ToString();

                //model.LeadSource = dbModel.FK_Lead_ID.ToString();
                model.EnquirySourceID = dbModel.FK_Userlist_EnquirySource_ID.ToString();
                model.ProjectStatusID = dbModel.FK_Userlist_ProjectStatus_ID.ToString();

                model.ProjectValue = dbModel.Project_Value.ToString();

                //model.ProjectDetails =
                //    "Project Status = " + dbModel.FK_Project_State_ID +
                //    " Project Value = " + dbModel.Project_Value +
                //    " From Projet Value = " + dbModel.Project_Value + "'/n'" +
                //    " To Project Value = " + dbModel.Project_Value +
                //    " Project Country =" + dbModel.FK_Project_Country_ID +
                //    "Project City =" + dbModel.FK_Project_City_ID +
                //    "Project State =" + dbModel.FK_Project_State_ID;

                model.EnquiryStatus = dbModel.FK_Userlist_Enquiry_Status_ID.ToString();
                //model.FromProjectValue = dbModel.projectva.ToString();

                model.ProjectCountry = dbModel.FK_Project_Country_ID.ToString();
                model.ProjectState = dbModel.FK_Project_State_ID.ToString();
                model.ProjectCity = dbModel.FK_Project_City_ID.ToString();

                //model.SiteInchargeName = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == dbModel.Fk_Employee_Site_Incharge_ID).FirstOrDefault().EmployeeName;
                //if (dbModel.FK_WarehouseID != null)
                //    model.WareHouse = _dbContext.TBL_MP_Master_Warehouse.Where(x => x.PK_Warehouse_ID == dbModel.FK_WarehouseID).FirstOrDefault().Warehouse_Name;
            }


            return model;
        }

        public int AddNewSalesEnquiry(TBL_MP_CRM_SalesEnquiry model)
        {
            int newID = 0;
            try
            {
                model.SalesEnquiry_No = this.GenerateNewSalesEnquiryNumber(model.FK_YearID,model.FK_BranchID,model.FK_CompanyID);
                _dbContext.TBL_MP_CRM_SalesEnquiry.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_SalesEnquiryID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiry::AddNewSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateSalesEnquiry(TBL_MP_CRM_SalesEnquiry model)
        {
            try
            {
                TBL_MP_CRM_SalesEnquiry EXISTING= _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == model.PK_SalesEnquiryID).FirstOrDefault();
                EXISTING = model;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateClientIDForSalesEnquiry(int enquiryID, int clientID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesEnquiry dbEnquiry = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == enquiryID).FirstOrDefault();
                if (dbEnquiry != null)
                {
                    dbEnquiry.FK_Customer_ID = clientID;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::UpdateClientIdForSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool ApproveEnquiry(int enquiryID,int employeeID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesEnquiry dbEnquiry = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == enquiryID).FirstOrDefault();
                dbEnquiry.FK_ApprovedBy = employeeID;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::ApproveEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_CRM_SalesEnquiry GetEnquiryMasterDBInfo(int enquiryID)
        {
            TBL_MP_CRM_SalesEnquiry dbModel = null;
            try
            {
                dbModel = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == enquiryID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiry::GetEnquiryMasterDBInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbModel;
        }
        public bool IsEnquiryStatusOPEN(int enquiryID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesEnquiry model = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == enquiryID).FirstOrDefault();
                if (model == null) return result;
                if (model.FK_Userlist_Enquiry_Status_ID == this.STATUS_OPEN_ID) result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ServiceSalesEnquiry::IsEnquirystatusOPEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool SetEnquiryStatusConverted(int enquiryID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesEnquiry model = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == enquiryID).FirstOrDefault();
                if (model != null)
                {
                    model.FK_Userlist_Enquiry_Status_ID = STATUS_CONVERTED_ID;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::SetEnquiryStatusConverted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public BindingList<MultiSelectListItem> GetApprovedOpenEnquiriesMulitiSelectionList()
        {
            BindingList<MultiSelectListItem> lst = new BindingList<MultiSelectListItem>();
            ServiceParties _serviceParty = new ServiceParties();
            string errSource = string.Empty;
            try
            {
                List<TBL_MP_CRM_SalesEnquiry> lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry
                                                            where xx.FK_Userlist_Enquiry_Status_ID == STATUS_OPEN_ID && xx.FK_ApprovedBy != null
                                                            orderby xx.SalesEnquiry_Date descending
                                                            select xx).ToList();

                string strPartyName = string.Empty;
                string strPartyEmail = string.Empty;
                foreach (TBL_MP_CRM_SalesEnquiry item in lstDBItems)
                {
                    errSource = item.SalesEnquiry_No;
                    MultiSelectListItem newItem = new MultiSelectListItem()
                    {
                        ID = item.PK_SalesEnquiryID,
                        Description = string.Format("{0}  Dt. {1}\n{2}", item.SalesEnquiry_No, item.SalesEnquiry_Date.ToString("dd-MM-yyyy"), item.Project_Name)
                    };
                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", errSource, ex.Message), "ServiceSalesEnquiry::GetApprovedOpenEnquiriesMulitiSelectionList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }

        #region CLIENT & CONSULTANT CONTACTS
        public BindingList<SelectListItem> GetAllCompanyContactsForSalesEnquiry(int enquiryID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                               where xx.EntityType== (int)APP_ENTITIES.SALES_ENQUIRY && xx.EntityID==enquiryID && xx.IsDeleted== false
                                                                       select xx).ToList();

                foreach (TBL_MP_CRM_SM_ContactReferences reference in lstReferences)
                {
                    if(reference.Tbl_MP_Master_PartyContact_Detail.Tbl_MP_Master_Party.PartyType=="C")
                    {
                        SelectListItem item = new SelectListItem() { ID = reference.ContactID };
                        string strDescription = string.Format("{0}\n{1}", reference.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName, reference.Tbl_MP_Master_PartyContact_Detail.Address);
                        strDescription += string.Format("\nMobile: {0} {1}", reference.Tbl_MP_Master_PartyContact_Detail.MobileNo, reference.Tbl_MP_Master_PartyContact_Detail.AltMobileNo);
                        strDescription += string.Format("\nTelephone: {0} {1}", reference.Tbl_MP_Master_PartyContact_Detail.TelephoneNo, reference.Tbl_MP_Master_PartyContact_Detail.AltTelephoneNo);
                        strDescription += string.Format("\n{0}", reference.Tbl_MP_Master_PartyContact_Detail.EmailID);
                        item.Description = strDescription;
                        lstContacts.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GetAllCompanyContactsForSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public List<TBL_MP_CRM_SM_ContactReferences> GetAllCompanyContactsForSalesEnquiryDB(int enquiryID)
        {
            List<TBL_MP_CRM_SM_ContactReferences> lstReferences = new List<TBL_MP_CRM_SM_ContactReferences>();
            try
            {
                lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY && xx.EntityID == enquiryID &&
                                                                       xx.Tbl_MP_Master_PartyContact_Detail.Tbl_MP_Master_Party.PartyType=="C" && xx.IsDeleted==false
                                                                       select xx).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GetAllCompanyContactsForSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstReferences;
        }
        public BindingList<SelectListItem> GetAllConsultantContactsForSalesEnquiry(int enquiryID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY && xx.EntityID == enquiryID && xx.IsDeleted==false
                                                                       select xx).ToList();

                foreach (TBL_MP_CRM_SM_ContactReferences reference in lstReferences)
                {
                    if (reference.Tbl_MP_Master_PartyContact_Detail.Tbl_MP_Master_Party.PartyType == "A")
                    {
                        SelectListItem item = new SelectListItem() { ID = reference.ContactID };
                        string strDescription = string.Format("{0}\n{1}", reference.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName, reference.Tbl_MP_Master_PartyContact_Detail.Address);
                        strDescription += string.Format("\nMobile: {0} {1}", reference.Tbl_MP_Master_PartyContact_Detail.MobileNo, reference.Tbl_MP_Master_PartyContact_Detail.AltMobileNo);
                        strDescription += string.Format("\nTelephone: {0} {1}", reference.Tbl_MP_Master_PartyContact_Detail.TelephoneNo, reference.Tbl_MP_Master_PartyContact_Detail.AltTelephoneNo);
                        strDescription += string.Format("\n{0}", reference.Tbl_MP_Master_PartyContact_Detail.EmailID);
                        item.Description = strDescription;
                        lstContacts.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GetAllCompanyContactsForSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public BindingList<SelectListItem> GetAllContactsForSalesEnquiry(int enquiryID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY && xx.EntityID == enquiryID && xx.IsDeleted==false 
                                                                       select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences reference in lstReferences)
                {
                    SelectListItem item = new SelectListItem() { ID = reference.ContactID };
                    string strDescription = string.Format("{0}\n{1}", reference.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName, reference.Tbl_MP_Master_PartyContact_Detail.Address);
                    strDescription += string.Format("\nMobile: {0} {1}", reference.Tbl_MP_Master_PartyContact_Detail.MobileNo, reference.Tbl_MP_Master_PartyContact_Detail.AltMobileNo);
                    strDescription += string.Format("\nTelephone: {0} {1}", reference.Tbl_MP_Master_PartyContact_Detail.TelephoneNo, reference.Tbl_MP_Master_PartyContact_Detail.AltTelephoneNo);
                    strDescription += string.Format("\n{0}", reference.Tbl_MP_Master_PartyContact_Detail.EmailID);
                    item.Description = strDescription;
                    lstContacts.Add(item);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GetAllCompanyContactsForSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public bool UpdateSalesEnquiryContactReferences(int enquiryID, string selectedIDs)
        {
            bool result = false;
            try
            {

                //SET ALL CONTACTS FOR THIS SALES ENQUIRY AS DELETED
                string strQuery = string.Format("UPDATE TBL_MP_CRM_SM_ContactReferences SET ISDELETED=1 WHERE ENTITYTYPE={0} AND ENTITYID={1}", 
                    (int)APP_ENTITIES.SALES_ENQUIRY, enquiryID);
                int cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);



                // SET SELECTED CONTACTS ID TO NOT DELETED ISDELETED=FALSE
                strQuery = string.Format("UPDATE TBL_MP_CRM_SM_ContactReferences SET ISDELETED=0 WHERE ENTITYTYPE={0} AND ENTITYID={1} AND CONTACTID IN ({2})",
                    (int)APP_ENTITIES.SALES_ENQUIRY, enquiryID, selectedIDs.Replace(DefaultStringSeperator,','));
                cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);

                //INSERT NEWLY ADDED CONTACT REFERENCES TO THE TABLE
                string[] arr = selectedIDs.Split(DefaultStringSeperator);
                for (int i = 0; i <= arr.GetUpperBound(0); i++)
                {
                    int contactID = int.Parse(arr[i]);
                    TBL_MP_CRM_SM_ContactReferences dbReference = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                   where xx.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY && xx.EntityID == enquiryID && xx.ContactID == contactID
                                                                   select xx
                                                                 ).FirstOrDefault();
                    if (dbReference == null)
                    {
                        dbReference = new TBL_MP_CRM_SM_ContactReferences() {EntityType= (int)APP_ENTITIES.SALES_ENQUIRY, EntityID= enquiryID, ContactID= contactID, IsDeleted=false };
                        _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(dbReference);
                        _dbContext.SaveChanges();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::UpdateSalesEnquiryContactReferences", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        #endregion

        #region ASSOCIATION
        public List<AssociatedEmployeeModel> GetAssociatesForEnquiryID(int enquiryID)
        {
            List<AssociatedEmployeeModel> lst = new List<AssociatedEmployeeModel>();
            try
            {
                List<TBL_MP_CRM_SalesEnquiry_Associates> lstAssociates =_dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Where(x => x.FK_SalesEnquiryID == enquiryID).ToList();
                List<AssociatedEmployeeModel> lstAllEmployees = (new ServiceMASTERS(_dbContext)).GetAllEmployeesForAssociation();
                foreach (TBL_MP_CRM_SalesEnquiry_Associates item in lstAssociates)
                {
                    AssociatedEmployeeModel model = lstAllEmployees.Where(x => x.ID == item.FK_EmployeeID).FirstOrDefault();
                    if(model!=null) lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }
        public void AssociateEmployees(string IDs, int SelectedID)
        {
            string[] arrIDs = IDs.Split(DefaultStringSeperator);
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int empID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SalesEnquiry_Associates model = _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Where(x => x.FK_SalesEnquiryID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model == null)
                    {
                        model = new TBL_MP_CRM_SalesEnquiry_Associates() { FK_EmployeeID = empID, FK_SalesEnquiryID = SelectedID, AssignDate = AppCommon.GetServerDateTime() };
                        _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Add(model);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void DisassociateEmployees(string IDs, int SelectedID)
        {
            string[] arrIDs = IDs.Split(DefaultStringSeperator);
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int? empID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SalesEnquiry_Associates model = _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Where(x => x.FK_SalesEnquiryID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model != null)
                    {
                        _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Remove(model);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region ATTACHMENTS - SALES ENQUIRY
        public int AddNewSalesEnquiryAttachment(int EnquiryID, int docCategoryID, string title, string sourceFileNameWithPath, int createdBy)
        {
            int newID = 0;
            try
            {
                string newFileName = (new AppCommon()).GetUniqueFileName(sourceFileNameWithPath);
                string serverPath = AppCommon.GetSalesEnquiryAttachmentPath();
                string newFileNameWithPath = string.Format("{0}{1}", serverPath, newFileName);
                File.Copy(sourceFileNameWithPath, newFileNameWithPath, true);

                TBL_MP_CRM_SalesEnquiry_Attachments objEnquiry = new TBL_MP_CRM_SalesEnquiry_Attachments();
                objEnquiry.FK_SalesEnquiryID = EnquiryID;
                objEnquiry.FK_CategoryID = docCategoryID;
                objEnquiry.AttachmentFileName = newFileName;
                objEnquiry.Title = title;
                objEnquiry.IsActive = true;

                _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Add(objEnquiry);
                _dbContext.SaveChanges();
                newID = objEnquiry.PK_AttachmentID;

                // MAINTAINING HISTORY OF ATTACHED DOCUMENT
                TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                history.AttachmentID = newID;
                history.EntityType = (int)APP_ENTITIES.SALES_ENQUIRY;
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
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::AddNewSalesEnquiryAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateSalesEnquiryAttachment(int AttachmentID, int docCategoryID, string title, string sourceFileNameWithPath, int modifiedBy)
        {
            bool result = false;
            try
            {
                string serverPath = AppCommon.GetSalesEnquiryAttachmentPath();
                TBL_MP_CRM_SalesEnquiry_Attachments objLead = _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(x => x.PK_AttachmentID == AttachmentID).FirstOrDefault();

                File.Copy(sourceFileNameWithPath, string.Format("{0}{1}", serverPath, objLead.AttachmentFileName), true);
                objLead.FK_CategoryID = docCategoryID;
                objLead.Title = title;
                _dbContext.SaveChanges();


                TBL_MP_CRM_SM_DocumentHistory historyLead = new TBL_MP_CRM_SM_DocumentHistory();
                historyLead.AttachmentID = AttachmentID;
                historyLead.EntityType = (int)APP_ENTITIES.SALES_LEAD;
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
                MessageBox.Show(errMessage, "ServiceSalesLead::UpdateSalesLeadAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public TBL_MP_CRM_SalesEnquiry_Attachments GetSalesEnquiryAttachmentDBRecord(int attachmentID)
        {
            return _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
        }
        public bool DeleteSalesEnquiryAttachment(int attachmentID, string reason,int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesEnquiry_Attachments editItem = _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeletedDatetime = AppCommon.GetServerDateTime();
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
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::DeleteSalesEnquiryAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public List<SelectListItem> GetAllDeletedSalesEnquiryAttachments()
        {
            List<SelectListItem> lstAttachments = new List<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesEnquiry_Attachments> EnqAttachments = _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(xx=> xx.IsActive == false).ToList();
                foreach (TBL_MP_CRM_SalesEnquiry_Attachments dbItem in EnqAttachments)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = dbItem.PK_AttachmentID;
                    item.Description = string.Format("{0} ({1})\n{2}", dbItem.Title, dbItem.TBL_MP_Master_UserList.Description1, dbItem.TBL_MP_CRM_SalesEnquiry.SalesEnquiry_No);
                    item.Code = AppCommon.GetSalesEnquiryAttachmentPath() + dbItem.AttachmentFileName;
                    lstAttachments.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiry::GetAllDeletedSalesEnquiryAttachments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttachments;
        }
        public bool UndeleteSalesEnquiryAttachment(int attachmentID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesEnquiry_Attachments editItem = _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeletedDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceSalesEnquiry::UndeleteSalesEnquiryAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
        
        public List<MultiSelectListItem> GetAllAssociatesAndContactForEnquiry(int enquiryID)
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {
                List<AssociatedEmployeeModel> lstAssociates = this.GetAssociatesForEnquiryID(enquiryID);
                if (lstAssociates != null)
                {
                    foreach (AssociatedEmployeeModel model in lstAssociates)
                    {
                        MultiSelectListItem item = new MultiSelectListItem() { ID = model.ID, Code = model.Code, EntityType = APP_ENTITIES.EMPLOYEES };
                        item.Description = string.Format("{0}\n{1},{2}\n{3}  {4}", model.Name, model.Designation, model.Department, model.EmailAddress, model.ContactNumber);
                        lst.Add(item);
                    }
                }

                BindingList<SelectListItem> lstContacts = this.GetAllContactsForSalesEnquiry(enquiryID);
                if (lstContacts != null)
                {
                    foreach (SelectListItem model in lstContacts)
                    {
                        MultiSelectListItem item = new MultiSelectListItem() { ID = model.ID, EntityType = APP_ENTITIES.CONTACTS, Description= model.Description};
                        lst.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::GetAllAssociatesAndContactForEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;

        }
        public void GenerateDefaultsFromSalesLeadIntoSalesEnquiry(int salesLeadID, int salesEnquiryID)
        {
            TBL_MP_CRM_SM_SalesLead dbLead = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == salesLeadID).FirstOrDefault();
            TBL_MP_CRM_SalesEnquiry dbEnquiry = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == salesEnquiryID).FirstOrDefault();
            if (dbLead != null)
            {
                if (dbLead.FK_AgentID != null)
                {
                    dbEnquiry.FK_EnqGenerated_Agent_ID = dbLead.FK_AgentID;
                    dbEnquiry.Enquiry_Genrated_By = "A";
                    dbEnquiry.Enquiry_Genrated_By_Name = (new ServiceParties()).GetPartyNameByPartyID((int)dbLead.FK_AgentID);
                    _dbContext.SaveChanges();
                }
            }

            // GET ALL CONTACT REFERENCES FROM SALES LEAD INTO SALES ENQUIRY
            List<TBL_MP_CRM_SM_ContactReferences> leadContacts = _dbContext.TBL_MP_CRM_SM_ContactReferences
                .Where(x => x.EntityID == salesLeadID)
                .Where(x=>x.EntityType==(int)APP_ENTITIES.SALES_LEAD)
                .Where(x=>x.IsDeleted== false).ToList();
            foreach (TBL_MP_CRM_SM_ContactReferences contactRef in leadContacts)
            {
                TBL_MP_CRM_SM_ContactReferences newReference = new TBL_MP_CRM_SM_ContactReferences()
                {
                    EntityID= salesEnquiryID,
                    EntityType= (int)APP_ENTITIES.SALES_ENQUIRY,
                    ContactID= contactRef.ContactID,
                    IsDeleted=false
                };
                _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(newReference);
                _dbContext.SaveChanges();
            }
            
            //GET ALL ASSOCIATES FROM SALES LEAD INTO SALES ENQUIRY
            List<TBL_MP_CRM_SM_SalesLead_Associates> leadAssociates = _dbContext.TBL_MP_CRM_SM_SalesLead_Associates.Where(x => x.FK_SalesLeadID == salesLeadID).ToList();
            foreach (TBL_MP_CRM_SM_SalesLead_Associates associate in leadAssociates)
            {
                TBL_MP_CRM_SalesEnquiry_Associates newAssociate = new TBL_MP_CRM_SalesEnquiry_Associates()
                {
                    AssignDate= AppCommon.GetServerDateTime(),
                    FK_EmployeeID = (int)associate.FK_EmployeeID,
                    FK_SalesEnquiryID= salesEnquiryID,
                };
                _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Add(newAssociate);
                _dbContext.SaveChanges();
            }

            //GET ALL SALES LEAD ATTACHMENT INTO SALES ENQUIRY
            List<TBL_MP_CRM_SM_SalesLead_Attachment> leadAttachments = _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(X => X.FK_SalesLeadID == salesLeadID).ToList();
            foreach (TBL_MP_CRM_SM_SalesLead_Attachment attachment in leadAttachments)
            {
                string leadPath = AppCommon.GetSalesLeadAttachmentPath();
                string enquiryPath = AppCommon.GetSalesEnquiryAttachmentPath();
                string oldFilePath = string.Format("{0}{1}", leadPath, attachment.AttachmentFileName);
                string newFilePath = string.Format("{0}{1}", enquiryPath, attachment.AttachmentFileName);
                File.Copy(oldFilePath, newFilePath, true);


                TBL_MP_CRM_SalesEnquiry_Attachments newAttachment = new TBL_MP_CRM_SalesEnquiry_Attachments()
                {
                    AttachmentFileName= attachment.AttachmentFileName,
                    Title= string.Format("{0} ({1})",attachment.Title,"via LEAD"),
                    FK_SalesEnquiryID= salesEnquiryID,
                    FK_CategoryID= (int)attachment.FK_CategoryID,
                };
                _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Add(newAttachment);
                _dbContext.SaveChanges();
            }




        }
        public async Task<bool> SendSalesEnquiryCreationEmail(int salesEnquiryID)
        {
            bool result = false;
            string strSubject = string.Empty;
            string strMessage = string.Empty;
            string strMailTo = string.Empty;

            try
            {
                //_dbContext = new EXCEL_ERPEntities();
                TBL_MP_CRM_SalesEnquiry enquiry = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == salesEnquiryID).FirstOrDefault();
                if (enquiry == null) { MessageBox.Show(string.Format("Unable to locate Sales Enquiry ID: {0}", enquiry.PK_SalesEnquiryID), "SendSalesEnquiryCreationEmail"); return false; }
                                
                strSubject = string.Format("New Sales Enquiry Generated {0}", enquiry.SalesEnquiry_No);
                strMessage += string.Format("Dear Sir/Madam,\n\n");
                strMessage += string.Format("\nSales Enquiry No: {0} dt.{1}",enquiry.SalesEnquiry_No, enquiry.SalesEnquiry_Date.ToString("dd MMM yyyy hh:mmtt"));
                strMessage += string.Format("\nEnquiry Due Date: {0} ", enquiry.Enquiry_Due_Date.Value.ToString("dd MMM yyyy hh:mmtt"));
                strMessage += string.Format("\nGenerated By: {0} [{1}]", enquiry.Enquiry_Genrated_By_Name, enquiry.Enquiry_Genrated_By);

                TBL_MP_CRM_SM_SalesLead lead = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == enquiry.FK_SalesLeadID).FirstOrDefault();
                strMessage += string.Format("\nReference LEAD No: {0} dt. {1}", lead.LeadNo, lead.LeadDate.ToString("dd MMM yyyy hh:mmtt"));

                strMessage += string.Format("\n\nProject Name: {0}", enquiry.Project_Name);
                strMessage += string.Format("\nProject Country: {0}", enquiry.TBL_MP_Master_Country.CountryName);
                strMessage += string.Format("\nProject State: {0}", enquiry.TBL_MP_Master_State.StateName);
                strMessage += string.Format("\nProject City: {0}", enquiry.TBL_MP_Master_City.CityName);
                List<SelectListItem> projectTypes = (new ServiceMASTERS()).GetAllProjectSectors();
                string strProjectType = projectTypes.Where(x => x.ID == enquiry.FK_Userlist_ProjectType_ID).FirstOrDefault().Description;
                strMessage += string.Format("\nProject Sector: {0}", strProjectType);

                string strPartyName = enquiry.Tbl_MP_Master_Party.PartyName;
                string strContacts = string.Format("\nCONTACTS INFO.\n");
                List<ContactInfoModel> lstContacts = (new ServiceContacts()).GetAllContactsForParty((int)enquiry.FK_Customer_ID);

                foreach (ContactInfoModel model in lstContacts)
                {
                    strContacts += string.Format("{0}\n{1}\n{2}\n\n", model.ContactName.ToUpper(), model.ContactAddress, model.MobileNumber);
                }
                strMessage += string.Format("\nPARTY NAME: {0}\n", strPartyName);
                strMessage += string.Format("\n{0}", strContacts);

                strMessage += string.Format("\nSales Enquiry Requirement:\n{0}", enquiry.General_Description);
                if(enquiry.FK_PreparedBy!=null)
                {
                    string strFullName = ServiceEmployee.GetEmployeeNameByID((int)enquiry.FK_PreparedBy);
                    strMessage += string.Format("\n\nRegards,\n{0}", strFullName);
                }
                

                List<TBL_MP_CRM_SalesEnquiry_Associates> lstAssociates = _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Where(x => x.FK_SalesEnquiryID == salesEnquiryID).ToList();
                foreach (TBL_MP_CRM_SalesEnquiry_Associates ass in lstAssociates)
                {
                    strMailTo += ServiceEmployee.GetEmployeeEmailByID(ass.FK_EmployeeID);
                    
                }
                string strEmpEmailAddress = ServiceEmployee.GetEmployeeEmailByID((int)enquiry.FK_PreparedBy);
                ServiceEmail mail = new ServiceEmail();
                await mail.SendEmail((int)enquiry.FK_PreparedBy,strEmpEmailAddress, strMailTo, strSubject, strMessage);
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceScheduleCallLog::SendSalesEnquiryCreationEmail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public DataTable GenerateDesignBOQItemDataTableDefault()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn() { ColumnName = "SrNo", DataType = typeof(int), AutoIncrement = true, AutoIncrementSeed = 1, AutoIncrementStep = 1 });
                dt.Columns.Add(new DataColumn() { ColumnName = "PartID", DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = "PartName", DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = "UOMID", DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = "UOM", DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = "TotalQty", DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = "UnitPrice", DataType = typeof(double) });
                dt.Columns.Add(new DataColumn() { ColumnName = "TotalPrice", DataType = typeof(double) });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GenerateDesignBOQItemDataTableDefault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public DataTable GenerateBOQChildItemDataTableWithServices(DataTable dt, List<MultiSelectListItem> Services)
        {
            try
            {
                int stIndex = dt.Columns["UOM"].Ordinal;
                stIndex++;
                foreach (MultiSelectListItem item in Services)
                {
                    if (!dt.Columns.Contains(item.Description))
                        dt.Columns.Add(new DataColumn() { ColumnName = item.Description, DataType = typeof(int) });
                    dt.Columns[item.Description].SetOrdinal(stIndex++);
                }
                //dt.Columns["TotalQty"].SetOrdinal(stIndex++);
                //dt.Columns["UnitPrice"].SetOrdinal(stIndex++);
                //dt.Columns["TotalPrice"].SetOrdinal(stIndex++);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GenerateBOQChildItemDataTableWithServices", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return dt;
        }

        public bool GenerateRevision(int sourceEnquiryID)
        {
            bool result = false;
            try
            {

                #region CREATE SALES ENQUIRY MASTER RECORD
                TBL_MP_CRM_SalesEnquiry newENQUIRY = new TBL_MP_CRM_SalesEnquiry();
                TBL_MP_CRM_SalesEnquiry sourceENQUIRY = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x=>x.PK_SalesEnquiryID== sourceEnquiryID).FirstOrDefault();
                string strQuery = string.Format("select count(*) from TBL_MP_CRM_SalesEnquiry where SalesEnquiry_No like'{0}%'", sourceENQUIRY.SalesEnquiry_No.Substring(0, 18));
                int countEnquiries = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();

                newENQUIRY.SalesEnquiry_No = string.Format("{0}-AMMEND({1})", sourceENQUIRY.SalesEnquiry_No.Substring(0, 18), countEnquiries);
                newENQUIRY.SalesEnquiry_Date = AppCommon.GetServerDateTime();
                newENQUIRY.Enquiry_Due_Date = sourceENQUIRY.Enquiry_Due_Date;
                newENQUIRY.FK_SalesLeadID = sourceENQUIRY.FK_SalesLeadID;

                newENQUIRY.Enquiry_Genrated_By = sourceENQUIRY.Enquiry_Genrated_By;
                newENQUIRY.Enquiry_Genrated_By_Name = sourceENQUIRY.Enquiry_Genrated_By_Name;
                newENQUIRY.FK_EnqGenerated_Employee_ID = sourceENQUIRY.FK_EnqGenerated_Employee_ID;
                newENQUIRY.FK_EnqGenerated_Agent_ID = sourceENQUIRY.FK_EnqGenerated_Agent_ID;

                newENQUIRY.Project_Name = sourceENQUIRY.Project_Name;
                newENQUIRY.Project_Value = sourceENQUIRY.Project_Value;

                newENQUIRY.General_Description = sourceENQUIRY.General_Description;
                newENQUIRY.FK_Userlist_Enquiry_Status_ID = sourceENQUIRY.FK_Userlist_Enquiry_Status_ID;
                newENQUIRY.FK_Userlist_ProjectType_ID = sourceENQUIRY.FK_Userlist_ProjectType_ID;
                newENQUIRY.FK_Userlist_Project_SubType_ID = sourceENQUIRY.FK_Userlist_Project_SubType_ID;
                newENQUIRY.FK_Userlist_EnquiryType_ID = sourceENQUIRY.FK_Userlist_EnquiryType_ID;
                newENQUIRY.FK_Userlist_Submission_Mode_ID = sourceENQUIRY.FK_Userlist_Submission_Mode_ID;
                newENQUIRY.FK_Userlist_EnquirySource_ID = sourceENQUIRY.FK_Userlist_EnquirySource_ID;
                newENQUIRY.FK_Userlist_ProjectStatus_ID = sourceENQUIRY.FK_Userlist_ProjectStatus_ID;
                
                
                newENQUIRY.FK_Project_Country_ID = sourceENQUIRY.FK_Project_Country_ID;
                newENQUIRY.FK_Project_State_ID = sourceENQUIRY.FK_Project_State_ID;
                newENQUIRY.FK_Project_City_ID = sourceENQUIRY.FK_Project_City_ID;

                newENQUIRY.FK_Customer_ID = sourceENQUIRY.FK_Customer_ID;
                newENQUIRY.Customer_Name = sourceENQUIRY.Customer_Name;

                //newENQUIRY.FK_PreparedBy = Program.CURR_USER.EmployeeID;
                newENQUIRY.FK_CompanyID =sourceENQUIRY.FK_CompanyID;
                newENQUIRY.FK_BranchID = sourceENQUIRY.FK_BranchID;
                newENQUIRY.FK_YearID = sourceENQUIRY.FK_YearID;
                newENQUIRY.IsActive = true;
                newENQUIRY.CreatedDatetime = AppCommon.GetServerDateTime();
                
                _dbContext.TBL_MP_CRM_SalesEnquiry.Add(newENQUIRY);
                _dbContext.SaveChanges();


                #endregion  

                //GENERATE boq FOR THE NEWLY CREATED ENQUIRY
                TBL_MP_CRM_SalesEnquiry_BOQ prevBOQ = _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ.Where(x => x.ENQUIRY_ID == sourceEnquiryID).FirstOrDefault();
                if (prevBOQ != null)
                {
                    SalesEnquiryDesignBOQViewModel model = new SalesEnquiryDesignBOQViewModel();
                    string json = prevBOQ.BOQ_DESIGN_OBJECT;
                    model = JsonConvert.DeserializeObject<SalesEnquiryDesignBOQViewModel>(json);
                    model.BOQ_ID = 0;
                    model.ENQUIRY_ID = newENQUIRY.PK_SalesEnquiryID;
                    model.BOQ_NUMBER = string.Format("{0}-BOQ", newENQUIRY.SalesEnquiry_No);
                    (new ServiceSalesEnquiryBOQ()).SaveDesignBOQ(model, (int)sourceENQUIRY.FK_PreparedBy);
                }

                // AMMEND ALL CONTACT REFERENCES
                List<TBL_MP_CRM_SM_ContactReferences> references = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                    where xx.EntityID == sourceEnquiryID  && xx.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY && xx.IsDeleted == false
                                                                    select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences item in references)
                {
                    TBL_MP_CRM_SM_ContactReferences newItem = new TBL_MP_CRM_SM_ContactReferences()
                    {
                        ContactID = item.ContactID,
                        EntityType = item.EntityType,
                        EntityID = newENQUIRY.PK_SalesEnquiryID,
                        IsDeleted = item.IsDeleted,
                    };
                    _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(newItem);
                    _dbContext.SaveChanges();
                }
                                
                // AMMEND ALL ASOCIATES
                List<TBL_MP_CRM_SalesEnquiry_Associates> associates = _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Where(x => x.FK_SalesEnquiryID == sourceEnquiryID).ToList();
                foreach (TBL_MP_CRM_SalesEnquiry_Associates item in associates)
                {
                    TBL_MP_CRM_SalesEnquiry_Associates newItem = new TBL_MP_CRM_SalesEnquiry_Associates()
                    {
                        AssignDate = AppCommon.GetServerDateTime(),
                        FK_EmployeeID = item.FK_EmployeeID,
                        FK_SalesEnquiryID = newENQUIRY.PK_SalesEnquiryID
                    };
                    _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Add(newItem);
                    _dbContext.SaveChanges();
                }
                
                //AMMEND ALL ATTACHMENTS
                List<TBL_MP_CRM_SalesEnquiry_Attachments> attachments = _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(x => x.FK_SalesEnquiryID == sourceEnquiryID).ToList();
                foreach (TBL_MP_CRM_SalesEnquiry_Attachments item in attachments)
                {
                    TBL_MP_CRM_SalesEnquiry_Attachments newItem = new TBL_MP_CRM_SalesEnquiry_Attachments()
                    {
                        FK_SalesEnquiryID = newENQUIRY.PK_SalesEnquiryID,
                        FK_CategoryID = item.FK_CategoryID,
                        AttachmentFileName = item.AttachmentFileName,
                        Title = item.Title
                    };
                    _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Add(newItem);
                    _dbContext.SaveChanges();
                    //AMMEND ALL DOCUMENT HISTORY FOR THE NEWLY CREATED ATTACHMENT
                    List<TBL_MP_CRM_SM_DocumentHistory> docHistory = _dbContext.TBL_MP_CRM_SM_DocumentHistory.Where(x => x.AttachmentID == item.PK_AttachmentID).ToList();
                    foreach (TBL_MP_CRM_SM_DocumentHistory itemHistory in docHistory)
                    {
                        TBL_MP_CRM_SM_DocumentHistory newHistory = new TBL_MP_CRM_SM_DocumentHistory()
                        {
                            AttachmentID = newItem.PK_AttachmentID,
                            CreateDatetime = AppCommon.GetServerDateTime(),
                            Description = itemHistory.Description,
                            EmployeeID = itemHistory.EmployeeID,
                            EntityType = itemHistory.EntityType
                        };
                        _dbContext.TBL_MP_CRM_SM_DocumentHistory.Add(newHistory);
                        _dbContext.SaveChanges();
                    }

                }
                
                //AMMEND ALL SCHDEULE CALLS AND FOLLOWUPS
                List<TBL_MP_CRM_ScheduleCallLog> schdeules = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY).Where(x => x.EntityID == sourceEnquiryID).ToList();
                foreach (TBL_MP_CRM_ScheduleCallLog item in schdeules)
                {
                    TBL_MP_CRM_ScheduleCallLog newItem = new TBL_MP_CRM_ScheduleCallLog()
                    {
                        ActionID = item.ActionID,
                        Priority = item.Priority,
                        Completed = item.Completed,
                        ContactNumber = item.ContactNumber,
                        ContactPerson = item.ContactPerson,
                        CreatedBy = item.CreatedBy,
                        CreatedDatetime = item.CreatedDatetime,
                        CustomerName = item.CustomerName,
                        EntityID = newENQUIRY.PK_SalesEnquiryID,
                        EntityType = item.EntityType,
                        EndsAt = item.EndsAt,
                        IsDeleted = item.IsDeleted,
                        Location = item.Location,
                        ModifiedBy = item.ModifiedBy,
                        ModifiedDatetime = item.ModifiedDatetime,
                        Remarks = item.Remarks,
                        Reminder = item.Reminder,
                        ScheduleStatus = item.ScheduleStatus,
                        StartAt = item.StartAt,
                        Subject = item.Subject
                    };
                    _dbContext.TBL_MP_CRM_ScheduleCallLog.Add(newItem);
                    _dbContext.SaveChanges();

                    // ADD ASSIGNEES FOR THE NEWLY CREATED SCHEDULE
                    List<TBL_MP_CRM_ScheduleCallLogAssignee> assignees = _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == item.ScheduleID).Where(x=>x.IsDeleted==false).ToList();
                    foreach (TBL_MP_CRM_ScheduleCallLogAssignee ass in assignees)
                    {
                        TBL_MP_CRM_ScheduleCallLogAssignee newAss = new TBL_MP_CRM_ScheduleCallLogAssignee()
                        {
                            EmployeeID = ass.EmployeeID,
                            IsDeleted = ass.IsDeleted,
                            ScheduleID = newItem.ScheduleID
                        };
                        _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Add(newAss);
                        _dbContext.SaveChanges();
                    }


                    // ADD FOLLOWUPS FOR THE NEWLY CREATED SCHEDULE
                    List<TBL_MP_CRM_ScheduleCallLogFollowUp> followUps = _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.ScheduleID == item.ScheduleID).ToList();
                    foreach (TBL_MP_CRM_ScheduleCallLogFollowUp followup in followUps)
                    {
                        TBL_MP_CRM_ScheduleCallLogFollowUp newFollowUp = new TBL_MP_CRM_ScheduleCallLogFollowUp()
                        {
                            EmployeeID = followup.EmployeeID,
                            FollowUpDateTime = followup.FollowUpDateTime,
                            FollowUpRemark = followup.FollowUpRemark,
                            FollowUpSequence = followup.FollowUpSequence,
                            FollowUpStatus = followup.FollowUpStatus,
                            NextFollowUpContactName = followup.NextFollowUpContactName,
                            NextFollowUpContactNumber = followup.NextFollowUpContactNumber,
                            NextFollowUpEndDatetime = followup.FollowUpDateTime,
                            NextFollowUpLocation = followup.NextFollowUpLocation,
                            NextFollowUpRemainder = followup.NextFollowUpRemainder,
                            NextFollowupRequired = followup.NextFollowupRequired,
                            NextFollowUpStartDatetime = followup.NextFollowUpStartDatetime,
                            NextFollowUpSubject = followup.NextFollowUpSubject,
                            ScheduleID = newItem.ScheduleID,
                        };
                        _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Add(newFollowUp);
                        _dbContext.SaveChanges();
                    }

                }
                
                //GET ALL LEAD FOR THIS REVISION AND SET THEM CLOSE
                strQuery = string.Format("select PK_SalesEnquiryID from TBL_MP_CRM_SalesEnquiry where SalesEnquiry_No like '{0}%' ", sourceENQUIRY.SalesEnquiry_No.Substring(0, 18));
                List<int> lstEnquiries = _dbContext.Database.SqlQuery<int>(strQuery).ToList();
                foreach (int ID in lstEnquiries)
                {
                    TBL_MP_CRM_SalesEnquiry currENQUIRY = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == ID).FirstOrDefault();
                    if (currENQUIRY.PK_SalesEnquiryID != newENQUIRY.PK_SalesEnquiryID)
                    {
                        if (currENQUIRY.FK_Userlist_Enquiry_Status_ID == this.STATUS_OPEN_ID)
                        {
                            currENQUIRY.FK_Userlist_Enquiry_Status_ID = this.STATUS_CLOSED_ID;
                            currENQUIRY.ReasonClose = string.Format("GENERATED NEW REVISION\n{0} dt. {1}", newENQUIRY.SalesEnquiry_No, newENQUIRY.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                            _dbContext.SaveChanges();
                        }
                    }
                }

                //this.SendLeadCreationEmail(newENQUIRY.PK_SalesEnquiryID);
                
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ServiceSalesEnquiry::GenerateRevision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteSalesEnquiry(int EnquiryID, int deletedBy)
        {
            try
            {
                TBL_MP_CRM_SalesEnquiry model = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == EnquiryID).FirstOrDefault();
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
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::DeleteSalesEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
    }
}
