using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    
    public class ServiceSalesLead : DefaultService
    {
       int OPEN_STATUS_ID = 0;
        int CLOSE_STATUS_ID = 0;
        int LOST_STATUS_ID = 0;
        int CONVERTED_STATUS_ID = 0;

        public ServiceSalesLead(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context; PopulateStatusVariables();
        }

        public ServiceSalesLead() { _dbContext = new EXCEL_ERP_TESTEntities(); PopulateStatusVariables(); }
        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                OPEN_STATUS_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeadStatusOpen).FirstOrDefault().DEFAULT_VALUE;
                LOST_STATUS_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeadStatusLost).FirstOrDefault().DEFAULT_VALUE;
                CONVERTED_STATUS_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeadStatusConverted).FirstOrDefault().DEFAULT_VALUE;
                CLOSE_STATUS_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeadStatusClose).FirstOrDefault().DEFAULT_VALUE;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string GenerateNewSalesLeadNumber(int currFinYear, int currBrachID, int companyID)
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
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.SALES_LEAD &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SM_SalesLead WHERE LeadNo NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objVoucherSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.SALES_LEAD &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_CRM_SM_SalesLead lastSLPrevYear = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead
                                                              where xx.FK_YearID == (currFinYear - 1) &&
                                                            xx.FK_BranchID == currBrachID &&
                                                            xx.FK_CompanyID == companyID
                                                            orderby xx.CreateDate descending
                                                            select xx).FirstOrDefault();
                    if (lastSLPrevYear != null)
                    {
                        string lstnumber = lastSLPrevYear.LeadNo.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
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
                MessageBox.Show(errMessage, "ServiceSalesLead::GenerateNewSalesLeadNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        
        public BindingList<SelectListItem> GetLeadsSelectionList(int _status)
        {
            BindingList<SelectListItem> lst = new BindingList<SelectListItem>();
            ServiceParties _serviceParty = new ServiceParties();
            string errSource = string.Empty;
            try
            {
                List<TBL_MP_CRM_SM_SalesLead> lstDBItems = null;
                if (_status != 0)
                    lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead
                                  where xx.FK_Status == (int)_status && xx.IsActive == true
                                  orderby xx.LeadDate descending
                                  select xx).ToList();
                else
                    lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead where xx.IsActive == true
                                  orderby xx.LeadDate descending
                                  select xx
                                  ).ToList();

                string strPartyName = string.Empty;
                string strPartyEmail = string.Empty;
                foreach (TBL_MP_CRM_SM_SalesLead item in lstDBItems)
                {
                    errSource = item.LeadNo;
                    //if (item.LeadNo == "XL/SL/0009/2017-18")
                    //{
                    //    MessageBox.Show("Halt......");
                    //}
                   SelectListItem newItem = new SelectListItem() {
                        ID = item.PK_SalesLeadID,
                        Code= item.LeadNo,
                        Description = string.Format("{0}  Dt. {1}\n{2}\n{3}\n", item.LeadNo, item.LeadDate.ToString("dd-MM-yyyy"), item.LeadName, item.ContactPersone) };

                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}",errSource, ex.Message), "ServiceSalesLead::GetLeadsSelectionList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public BindingList<MultiSelectListItem> GetLeadsMulitiSelectionList(int _status)
        {
            BindingList<MultiSelectListItem> lst = new BindingList<MultiSelectListItem>();
            ServiceParties _serviceParty = new ServiceParties();
            string errSource = string.Empty;
            try
            {
                List<TBL_MP_CRM_SM_SalesLead> lstDBItems = null;
                if (_status != 0)
                    lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead
                                  where xx.FK_Status == (int)_status
                                  orderby xx.LeadDate descending
                                  select xx).ToList();
                else
                    lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead
                                  orderby xx.LeadDate descending
                                  select xx
                                  ).ToList();

                string strPartyName = string.Empty;
                string strPartyEmail = string.Empty;
                foreach (TBL_MP_CRM_SM_SalesLead item in lstDBItems)
                {
                    errSource = item.LeadNo;
                    //if (item.LeadNo == "XL/SL/0009/2017-18")
                    //{
                    //    MessageBox.Show("Halt......");
                    //}
                    MultiSelectListItem newItem = new MultiSelectListItem()
                    {
                        ID = item.PK_SalesLeadID,
                        Description = string.Format("{0}  Dt. {1}\n{2}\n{3}\n", item.LeadNo, item.LeadDate.ToString("dd-MM-yyyy"), item.LeadName, item.ContactPersone)
                    };

                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", errSource, ex.Message), "ServiceSalesLead::GetLeadsMulitiSelectionList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public BindingList<MultiSelectListItem> GetApprovedOpenLeadsMulitiSelectionList()
        {
            BindingList<MultiSelectListItem> lst = new BindingList<MultiSelectListItem>();
            ServiceParties _serviceParty = new ServiceParties();
            string errSource = string.Empty;
            try
            {
                List<TBL_MP_CRM_SM_SalesLead> lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead
                                  where xx.FK_Status == OPEN_STATUS_ID && xx.FK_ApprovedBy!=null 
                                  orderby xx.LeadDate descending
                                  select xx).ToList();
                
                string strPartyName = string.Empty;
                string strPartyEmail = string.Empty;
                foreach (TBL_MP_CRM_SM_SalesLead item in lstDBItems)
                {
                    errSource = item.LeadNo;
                    //if (item.LeadNo == "XL/SL/0009/2017-18")
                    //{
                    //    MessageBox.Show("Halt......");
                    //}
                    MultiSelectListItem newItem = new MultiSelectListItem()
                    {
                        ID = item.PK_SalesLeadID,
                        Description = string.Format("{0}  Dt. {1}\n{2}\n{3}\n", item.LeadNo, item.LeadDate.ToString("dd-MM-yyyy"), item.LeadName, item.ContactPersone)
                    };

                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\n{1}", errSource, ex.Message), "ServiceSalesLead::GetLeadsMulitiSelectionList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }


        public LeadMasterInfoModel GetLeadMasterInfo(int leadID)
        {
            LeadMasterInfoModel model = new LeadMasterInfoModel();
            try
            {
                TBL_MP_CRM_SM_SalesLead dbModel = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == leadID).FirstOrDefault();
                if (dbModel != null)
                {
                    model.LeadNo = dbModel.LeadNo;
                    model.LeadDate = (DateTime)dbModel.LeadDate;
                    if (dbModel.FK_ApprovedBy != null)
                    {
                        model.IsApproved = true;
                        model.ApprovedBy = string.Format("Approved By:\n{0}", ServiceEmployee.GetEmployeeNameByID((int)dbModel.FK_ApprovedBy));
                    }
                    else
                    {
                        model.IsApproved = false;
                        model.ApprovedBy = "\nUNAPPROVED LEAD\n";
                    }
                    if (dbModel.FK_Status != null)
                    {
                        model.LeadStatus = (new ServiceMASTERS(_dbContext)).GetSalesLeadStatusList().Where(x => x.ID == (int)dbModel.FK_Status).FirstOrDefault().Description;
                        if (dbModel.FK_Status == CLOSE_STATUS_ID || dbModel.FK_Status == LOST_STATUS_ID || dbModel.FK_Status == CONVERTED_STATUS_ID)
                        {
                            if (dbModel.ReasonClose != null)
                                model.LeadStatusDescription = dbModel.ReasonClose.ToString();
                            else
                                model.LeadStatusDescription = string.Empty;
                        }
                    }

                    Tbl_MP_Master_Party party = (new ServiceParties(_dbContext)).GetPartyByPartyID((int)dbModel.FK_PartyID);
                    if (party != null)
                    {
                        model.LeadName = party.PartyName;
                        model.EmailId = party.EmailID;
                        model.WebSite = party.Website;
                    }
                    model.LeadRequirement = dbModel.LeadRequirement;

                    model.LeadSource = _dbContext.TBL_MP_Master_UserList.Where(p => p.pk_UserListId == dbModel.FK_LeadSource).FirstOrDefault().Description1;
                    model.EstimatedValue = string.Format("{0:0.00}", dbModel.EstimatedValue);
                    if (dbModel.FK_EstimatedCurrency != null)
                        model.EstimatedValueCurrency = _dbContext.TBL_MP_Master_Country.Where(p => p.pk_CountryId == dbModel.FK_EstimatedCurrency).FirstOrDefault().CurrencyCode;

                    model.NextFollowUpDate = dbModel.NextFollowupDate;

                    model.GeneratedBy = _dbContext.TBL_MP_Master_Employee.Where(p => p.PK_EmployeeId == dbModel.FK_LeadGeneratedBy).FirstOrDefault().EmployeeName;
                    model.AssignedTo = _dbContext.TBL_MP_Master_Employee.Where(p => p.PK_EmployeeId == dbModel.FK_LeadAssignTo).FirstOrDefault().EmployeeName;

                    model.ProjectSector = _dbContext.TBL_MP_Master_UserList.Where(p => p.pk_UserListId == dbModel.FK_ProjectType).FirstOrDefault().Description1;

                    model.CreationInfo = string.Empty;
                    if (model.GeneratedBy != null)
                        model.CreationInfo = string.Format("Created : {0}", model.GeneratedBy);

                    if (dbModel.CreateDate != null)
                        model.CreationInfo += string.Format(" dt. {0}", dbModel.CreateDate.Value.ToString("dd-MMM-yy hh:mmtt"));

                    if (dbModel.LastModifiedDate != null)
                    {
                        string modifiedBy = _dbContext.TBL_MP_Master_Employee.Where(p => p.PK_EmployeeId == dbModel.FK_LastModifiedBy).FirstOrDefault().EmployeeName;
                        model.ModificationInfo = string.Format("Last Modified: {0} dt. {1}", modifiedBy, dbModel.LastModifiedDate.Value.ToString("dd-MMM-yy hh:mmtt"));
                    }
                    //model.SiteInchargeName = _dbContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == dbModel.Fk_Employee_Site_Incharge_ID).FirstOrDefault().EmployeeName;
                    //if (dbModel.FK_WarehouseID != null)
                    //    model.WareHouse = _dbContext.TBL_MP_Master_Warehouse.Where(x => x.PK_Warehouse_ID == dbModel.FK_WarehouseID).FirstOrDefault().Warehouse_Name;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GetLeadMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


            return model;
        }
        public TBL_MP_CRM_SM_SalesLead GetLeadMasterDBInfo(int leadID)
        {
            TBL_MP_CRM_SM_SalesLead dbModel = null;
            try
            {
                dbModel= _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == leadID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dbModel;
        }
        public int AddNewSalesLead(TBL_MP_CRM_SM_SalesLead model)
        {
            int newID = 0;
            try
            {
                
                model.CreateDate = AppCommon.GetServerDateTime();
                model.LeadNo = this.GenerateNewSalesLeadNumber(model.FK_YearID, model.FK_BranchID, model.FK_CompanyID);

                _dbContext.TBL_MP_CRM_SM_SalesLead.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_SalesLeadID;

                


                //ServiceNotification _serviceNotification = new ServiceNotification();
                ////create a notification for GENERATOR
                //string bodyText = string.Format("You have created a new Sales Lead\n{0}  {1}", model.LeadName, model.LeadNo);
                //_serviceNotification.GenerateNotificationFor(APP_ENTITIES.SALES_LEAD, newID, (int)model.FK_LeadGeneratedBy, "Lead Generated", bodyText);
                ////create a notification for ASSIGNED TO
                //bodyText = string.Format("You are assigned a new Sales Lead\n{0}  {1}", model.LeadName, model.LeadNo);
                //_serviceNotification.GenerateNotificationFor(APP_ENTITIES.SALES_LEAD, newID, (int)model.FK_LeadAssignTo, "Lead Assigned", bodyText);
                // ASSOCIATE GENERATOR & ASSIGN TO INTO SALES LEAD ASSOCIATION



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if(ex.InnerException!=null) errMessage+= string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesLead::AddNewSalesLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }

        public async Task<bool> SendLeadCreationEmail(int leadID)
        {
            bool result = false;
            string strSubject = string.Empty;
            string strMessage = string.Empty;
            string strRequirements = string.Empty;
            string strMailFrom = string.Empty;
            string strMailTo = string.Empty;

            try
            {
                TBL_MP_CRM_SM_SalesLead lead = this.GetLeadMasterDBInfo(leadID);
                if (lead != null)
                {
                    strSubject = string.Format("Sales Lead Created");
                    if (lead.LeadNo.Contains("AMMEND")) strSubject = "New Revision for a Sales Lead Generated";
                    strMessage += String.Format("\n\nLEAD NO.: {0} dt. {1} \nPARTY NAME:{2}\n", lead.LeadNo, lead.LeadDate.ToString("dd MMMyy"), lead.LeadName);
                    strRequirements = string.Format("REQUIREMENTS:\n{0}", lead.LeadRequirement);

                    List<SelectContactModel> lstContacts = this.GetContactsForLeadID(leadID);
                    strMessage += string.Format("\nCONTACT INFO.\n\n");
                    foreach (SelectContactModel contact in lstContacts)
                    {
                        strMessage += string.Format("{0}\n{1}\n\n", contact.Description1, contact.Description2);
                    }
                    strMessage += strRequirements;
                    ServiceEmail _mailService = new ServiceEmail();
                    strMailFrom = ServiceEmployee.GetEmployeeEmailByID((int)lead.FK_LeadGeneratedBy);
                    strMailTo = ServiceEmployee.GetEmployeeEmailByID((int)lead.FK_LeadAssignTo);
                    await _mailService.SendEmail((int)lead.FK_LeadGeneratedBy,strMailFrom, strMailTo, strSubject, strMessage);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLEad::SendLeadCreationEmail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
            
                       
        }
        public bool UpdateSalesLeadMasterInfo(TBL_MP_CRM_SM_SalesLead model)
        {
            bool result = false;
            try
            {
                _dbContext.SaveChanges();
                result= true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::UpdateSalesLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool ApproveLead(int leadID, int approverID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SM_SalesLead dbLead = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == leadID).FirstOrDefault();
                dbLead.FK_ApprovedBy = approverID;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesLead::ApproveLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public List<TBL_MP_CRM_SM_SalesLead> GetAllSalesLeadDBItems()
        {
            return _dbContext.TBL_MP_CRM_SM_SalesLead.ToList();
        }
        public List<SelectListItem> GetAllDeletedLeadAttachments()
        {
            List<SelectListItem> lstAttachments = new List<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_SalesLead_Attachment> EmpAttachments = (from xx in _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment
                                                                          where xx.IsActive == false
                                                                      select xx
                                                                     ).ToList();
                foreach (TBL_MP_CRM_SM_SalesLead_Attachment dbItem in EmpAttachments)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = dbItem.PK_AttachmentID;
                    item.Description = string.Format("{0} ({1})\n{2}", dbItem.Title, dbItem.TBL_MP_Master_UserList.Description1, dbItem.TBL_MP_CRM_SM_SalesLead.LeadName);
                    item.Code = AppCommon.GetSalesLeadAttachmentPath() + dbItem.AttachmentFileName;
                    lstAttachments.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GetAllDeletedLeadAttachments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttachments;
        }
        public int GetLeadStatus(int salesLeadID)
        {
            int status = 0;
            try
            {
                string strQuery = string.Format("select FK_Status from TBL_MP_CRM_SM_SalesLead where PK_SalesLeadID={0}", salesLeadID);
                status = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        #region CONTACT REFERENCES
        public List<SelectContactModel> GetContactsForLeadID(int leadID)
        {
            List<SelectContactModel> lstContacts = new List<SelectContactModel>();
            try
            {
                List<int> ContactIDs = (from x in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                           where x.EntityType == (int)APP_ENTITIES.SALES_LEAD &&  x.EntityID == leadID && x.IsDeleted==false
                                           select (int)x.ContactID).ToList();
                List<AssociatedEmployeeModel> lstAllEmployees = (new ServiceMASTERS(_dbContext)).GetAllEmployeesForAssociation();
                foreach (int item in ContactIDs)
                {
                    Tbl_MP_Master_PartyContact_Detail contact = _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(xx => xx.PK_PartyContactDetails == (int?)item).FirstOrDefault();
                    if (contact != null)
                    {
                        SelectContactModel model = new SelectContactModel();
                        model.Selected = true;
                        model.ContactID = (int)contact.PK_PartyContactDetails;

                        model.Description1 = string.Format("{0}   {1}\n{2}\n{3}, {4}", contact.ContactPersoneName, contact.EmailID, contact.Address, contact.FK_Designation_Text, contact.FK_Department_Text);
                        string strDescription2 = string.Empty;
                        if (contact.TelephoneNo.Trim() != string.Empty && contact.TelephoneNo.Trim() != "0")
                            strDescription2 = string.Format("Phone :{0}  {1}\n", contact.TelephoneNo, contact.AltTelephoneNo);
                        if (contact.MobileNo.Trim() != string.Empty && contact.MobileNo.Trim() != "0")
                            strDescription2 = string.Format("Phone :{0}  {1}\n", contact.MobileNo, contact.AltMobileNo);
                        if (contact.FaxNo.Trim() != string.Empty && contact.FaxNo.Trim() != "0")
                            strDescription2 = string.Format("FaxNo :{0}", contact.FaxNo);

                        model.Description2 = strDescription2;
                        lstContacts.Add(model);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GetContactsForLeadID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public void UpdateContactReferences(string IDs, int SelectedID)
        {
            string[] arrIDs = IDs.Split(DefaultStringSeperator);
            
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> contacts = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences where xx.EntityType == (int)APP_ENTITIES.SALES_LEAD && xx.EntityID == SelectedID select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences item in contacts)
                {
                    item.IsDeleted = true;
                    _dbContext.SaveChanges();
                }
                

                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int contactID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SM_ContactReferences model = _dbContext.TBL_MP_CRM_SM_ContactReferences
                        .Where(x=>x.EntityType==(int)APP_ENTITIES.SALES_LEAD)
                        .Where(x => x.EntityID == SelectedID)
                        .Where(x => x.ContactID == contactID).FirstOrDefault();

                    if (model == null)
                    {
                        model = new TBL_MP_CRM_SM_ContactReferences()
                        {
                            ContactID = contactID,
                            EntityType = (int)APP_ENTITIES.SALES_LEAD,
                            EntityID = SelectedID,
                            IsDeleted = false
                        };
                        _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(model);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        model.IsDeleted = false;
                        _dbContext.SaveChanges();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::UpdateContactReferences", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void UpdateContactNamesInSalesLeadMaster (string IDs, int SelectedID)
        {
            string[] arrIDs = IDs.Split(DefaultStringSeperator);
            string strNames = string.Empty;
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int contactID = int.Parse(arrIDs[i]);
                    Tbl_MP_Master_PartyContact_Detail model = (new ServiceContacts(_dbContext)).GetContactByContactID(contactID);
                    if (model != null)
                    {
                        strNames += model.ContactPersoneName + " ";
                    }

                }
                TBL_MP_CRM_SM_SalesLead lead = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == SelectedID).FirstOrDefault();
                if (lead != null)
                {
                    lead.ContactPersone = strNames;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::UpdateContactNamesInSalesLeadMaster", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public List<MultiSelectListItem> GetAllAssociatesAndContactForLead(int leadID)
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {
                List<AssociatedEmployeeModel> lstAssociates= this.GetAssociatesForLeadID(leadID);
                if (lstAssociates != null)
                {
                    foreach (AssociatedEmployeeModel model in lstAssociates)
                    {
                        MultiSelectListItem item = new MultiSelectListItem() { ID = model.ID, Code = model.Code, EntityType= APP_ENTITIES.EMPLOYEES};
                        item.Description = string.Format("{0}\n{1},{2}\n{3}  {4}", model.Name, model.Designation, model.Department, model.EmailAddress, model.ContactNumber);
                        lst.Add(item);
                    }
                }
                List<SelectContactModel> lstContacts = this.GetContactsForLeadID(leadID);
                if (lstContacts != null)
                {
                    foreach (SelectContactModel model in lstContacts)
                    {
                        MultiSelectListItem item = new MultiSelectListItem() { ID = model.ContactID, EntityType= APP_ENTITIES.CONTACTS, Description = model.Description1+ " "+ model.Description2 };
                        lst.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GetAllAssociatesAndContactForLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;

        }
        #endregion  
        
        #region ASSOCIATION
        public List<AssociatedEmployeeModel> GetAssociatesForLeadID(int leadID)
        {
            List<AssociatedEmployeeModel> lst = new List<AssociatedEmployeeModel>();
            try
            {
                List<int> lstAssociates = (from x in _dbContext.TBL_MP_CRM_SM_SalesLead_Associates
                                           where x.FK_SalesLeadID == leadID && x.FK_EmployeeID != null
                                           select (int)x.FK_EmployeeID).ToList();
                List<AssociatedEmployeeModel> lstAllEmployees = (new ServiceMASTERS(_dbContext)).GetAllEmployeesForAssociation();
                foreach (int item in lstAssociates)
                {
                    AssociatedEmployeeModel model = lstAllEmployees.Where(x => x.ID == item).FirstOrDefault();
                    if (model != null)
                    {
                        lst.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GetAssociatesForLeadID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public void AssociateEmployees(string IDs, int SelectedID) {
            string[] arrIDs = IDs.Split(DefaultStringSeperator);
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int? empID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SM_SalesLead_Associates model = _dbContext.TBL_MP_CRM_SM_SalesLead_Associates.Where(x => x.FK_SalesLeadID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model == null)
                    {
                        model = new TBL_MP_CRM_SM_SalesLead_Associates() { FK_EmployeeID = empID, FK_SalesLeadID = SelectedID, AssignDate = AppCommon.GetServerDateTime() };
                        _dbContext.TBL_MP_CRM_SM_SalesLead_Associates.Add(model);
                        _dbContext.SaveChanges();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesLead::AssociateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void DisassociateEmployees(string IDs, int SelectedID)
        {
            string[] arrIDs = IDs.Split('|');
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int? empID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SM_SalesLead_Associates model = _dbContext.TBL_MP_CRM_SM_SalesLead_Associates.Where(x => x.FK_SalesLeadID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model != null)
                    {
                        _dbContext.TBL_MP_CRM_SM_SalesLead_Associates.Remove(model);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesLead::DisassociateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region SUSPECT INFO
        public List<SuspectingInfoModel> GetSuspectingInfoForSalesLead(int salesLeadId)
        {

            List<SuspectingInfoModel> list = new List<SuspectingInfoModel>();
            try
            {
                List<TBL_MP_Master_UserList> lstCategories = _dbContext.TBL_MP_Master_UserList.Where(x => x.fk_CategoryId == (int)APP_ADMIN_CATEGORIES.SUSPECTING_INFO).ToList();
                foreach (TBL_MP_Master_UserList model in lstCategories)
                {
                    SuspectingInfoModel item = new SuspectingInfoModel() { CategoryID = model.pk_UserListId, CategoryName = model.Description1 };
                    TBL_MP_CRM_SM_SalesLead_SuspectingInfo _dbItem = _dbContext.TBL_MP_CRM_SM_SalesLead_SuspectingInfo.Where(x => x.FK_SalesLeadID == salesLeadId).Where(x => x.FK_SuspectCategory == model.pk_UserListId).FirstOrDefault();
                    if (_dbItem != null)
                    {
                        item.CategoryDiscription = _dbItem.Brief_Description;
                    }
                    item.CategoryID = model.pk_UserListId;
                    item.Entity = APP_ENTITIES.SALES_LEAD;
                    item.PKId = salesLeadId;
                    list.Add(item);
                }
                list=list.OrderBy(x => x.ContentLength).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GetSuspectingInfoForSalesLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public void UpdateSuspectingInfoForSalesLead(List<SuspectingInfoModel> lst, int salesLeadID)
        {
            try
            {
                foreach (SuspectingInfoModel model in lst)
                {
                    if (model.CategoryDiscription.Trim() != string.Empty)
                    {
                        TBL_MP_CRM_SM_SalesLead_SuspectingInfo _dbItem = _dbContext.TBL_MP_CRM_SM_SalesLead_SuspectingInfo.Where(x => x.FK_SalesLeadID == salesLeadID).Where(x => x.FK_SuspectCategory == model.CategoryID).FirstOrDefault();
                        if (_dbItem == null)
                        {
                            _dbItem = new TBL_MP_CRM_SM_SalesLead_SuspectingInfo()
                            {
                                Brief_Description = model.CategoryDiscription,
                                FK_SalesLeadID = salesLeadID,
                                FK_SuspectCategory = model.CategoryID
                            };
                            _dbContext.TBL_MP_CRM_SM_SalesLead_SuspectingInfo.Add(_dbItem);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            _dbItem.Brief_Description = model.CategoryDiscription;
                            _dbContext.SaveChanges();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::UpdateSuspectingInfoForSalesLead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ATTACHMENT
        public int AddNewSalesLeadAttachment(int leadID,int docCategoryID,string title, string sourceFileNameWithPath, int createdBy)
        {
            int newID = 0;
            try
            {
                string newFileName = (new AppCommon()).GetUniqueFileName(sourceFileNameWithPath);
                string serverPath = AppCommon.GetSalesLeadAttachmentPath();
                string newFileNameWithPath = string.Format("{0}{1}", serverPath, newFileName);
                File.Copy(sourceFileNameWithPath, newFileNameWithPath, true);
                
                TBL_MP_CRM_SM_SalesLead_Attachment objLead = new TBL_MP_CRM_SM_SalesLead_Attachment();
                objLead.FK_SalesLeadID = leadID;
                objLead.FK_CategoryID = docCategoryID;
                objLead.AttachmentFileName = newFileName;
                objLead.Title = title;
                objLead.IsActive = true;

                _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment.Add(objLead);
                _dbContext.SaveChanges();
                newID = objLead.PK_AttachmentID;

                // MAINTAINING HISTORY OF ATTACHED DOCUMENT
                TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                history.AttachmentID = newID;
                history.EntityType = (int)APP_ENTITIES.SALES_LEAD;
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
                MessageBox.Show(errMessage, "ServiceSalesLead::AddNewSalesLeadAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateSalesLeadAttachment(int AttachmentID, int docCategoryID, string title, string sourceFileNameWithPath,int modifiedBy)
        {
            bool result = false;
            try
            {
                string serverPath = AppCommon.GetSalesLeadAttachmentPath();
                TBL_MP_CRM_SM_SalesLead_Attachment objLead = _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(x => x.PK_AttachmentID == AttachmentID).FirstOrDefault();
                
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
        public TBL_MP_CRM_SM_SalesLead_Attachment GetSalesLeadAttachmentDBRecord(int attachmentID)
        {
            return _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
        }
        public bool DeleteSalesLeadAttachment(int attachmentID, string reason, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SM_SalesLead_Attachment editItem = _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
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
                MessageBox.Show(errMessage, "ServiceSalesLead::DeleteSalesLeadAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return result;
        }
        public bool UndeleteSalesLeadAttachment(int attachmentID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SM_SalesLead_Attachment editItem = _dbContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceSalesLead::UndeleteSalesLeadAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        public async Task<bool> GenerateRevision(int sourceLeadID, int empID)
        {
            bool result = false;
            ServiceUOW _UNIT = new ServiceUOW();
            try
            {
                
                frmProgress frm = new frmProgress();
                frm.Text = "Generating New Revision for Sales Lead";
                frm.progressBar1.Maximum = 100;
                frm.Show();


                #region CREATE SALES LEAD MASTER RECORD
                TBL_MP_CRM_SM_SalesLead newLead = new TBL_MP_CRM_SM_SalesLead();
                TBL_MP_CRM_SM_SalesLead sourceLead = _UNIT.SalesLeadService.GetLeadMasterDBInfo(sourceLeadID);
                frm.SetProgress(0, string.Format("Creating New Revision for Sales Lead {0}", sourceLead.LeadNo));
                string strQuery = string.Format("select count(*) from TBL_MP_CRM_SM_SalesLead where leadno like'{0}%'", sourceLead.LeadNo.Substring(0, 18));
                int countLeads = _UNIT.AppDBContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();

                newLead.LeadNo = string.Format("{0}-AMMEND({1})", sourceLead.LeadNo.Substring(0, 18), countLeads);
                newLead.LeadDate = AppCommon.GetServerDateTime();
                newLead.FK_LeadGeneratedBy = sourceLead.FK_PreparedBy;
                newLead.FK_PartyID = sourceLead.FK_PartyID;
                newLead.LeadName = sourceLead.LeadName;
                newLead.ContactPersone = sourceLead.ContactPersone;
                newLead.LeadEmailID = sourceLead.LeadEmailID;
                newLead.LeadWebsite = sourceLead.LeadWebsite;
                newLead.LeadRequirement = sourceLead.LeadRequirement;
                newLead.EstimatedValue = sourceLead.EstimatedValue;
                newLead.FK_EstimatedCurrency = sourceLead.FK_EstimatedCurrency;
                newLead.FK_LeadAssignTo = sourceLead.FK_LeadAssignTo;
                newLead.FK_ProjectType = sourceLead.FK_ProjectType;
                newLead.FK_Status = sourceLead.FK_Status;
                newLead.ReasonClose = sourceLead.ReasonClose;
                newLead.FK_LeadSource = sourceLead.FK_LeadSource;
                newLead.FK_AgentID = sourceLead.FK_AgentID;

                newLead.FK_PreparedBy = empID;
                newLead.FK_LeadGeneratedBy = empID;
                newLead.FK_CompanyID = sourceLead.FK_CompanyID;
                newLead.FK_BranchID = sourceLead.FK_BranchID;
                newLead.FK_YearID = sourceLead.FK_YearID;
                newLead.CreateDate = AppCommon.GetServerDateTime();
                _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead.Add(newLead);
                _UNIT.AppDBContext.SaveChanges();
                frm.SetProgress(20, string.Format("\nSuccess : Created New Revision Sales Lead {0}", newLead.LeadNo));
                Application.DoEvents();
                #endregion  

                // AMMEND ALL CONTACT REFERENCES
                List<TBL_MP_CRM_SM_ContactReferences> references = ( from xx in _UNIT.AppDBContext.TBL_MP_CRM_SM_ContactReferences
                                                                     where xx.EntityID == sourceLeadID && xx.EntityType == (int)APP_ENTITIES.SALES_LEAD && xx.IsDeleted==false select xx ).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences item in references)
                {
                    TBL_MP_CRM_SM_ContactReferences newItem = new TBL_MP_CRM_SM_ContactReferences()
                    {
                        ContactID = item.ContactID,
                        EntityType = item.EntityType,
                        EntityID = newLead.PK_SalesLeadID,
                        IsDeleted = item.IsDeleted,
                    };
                    _UNIT.AppDBContext.TBL_MP_CRM_SM_ContactReferences.Add(newItem);
                    _UNIT.AppDBContext.SaveChanges();
                }
                frm.SetProgress(40, string.Format("\nSuccess : {0} Contact References added with New Revision", references.Count));
                Application.DoEvents();

                // AMMEND ALL ASOCIATES
                List<TBL_MP_CRM_SM_SalesLead_Associates> associates = _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead_Associates.Where(x => x.FK_SalesLeadID == sourceLeadID).ToList();
                foreach (TBL_MP_CRM_SM_SalesLead_Associates item in associates)
                {
                    TBL_MP_CRM_SM_SalesLead_Associates newItem = new TBL_MP_CRM_SM_SalesLead_Associates()
                    {
                        AssignDate = AppCommon.GetServerDateTime(),
                        FK_EmployeeID = item.FK_EmployeeID,
                        FK_SalesLeadID = newLead.PK_SalesLeadID
                    };
                    _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead_Associates.Add(newItem);
                    _UNIT.AppDBContext.SaveChanges();
                }
                frm.SetProgress(40, string.Format("\nSuccess : Associated {0} Employees with New Revision", associates.Count));
                Application.DoEvents();

                //AMMEND ALL ATTACHMENTS
                List<TBL_MP_CRM_SM_SalesLead_Attachment> attachments = _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(x => x.FK_SalesLeadID == sourceLeadID).ToList();
                foreach (TBL_MP_CRM_SM_SalesLead_Attachment item in attachments)
                {
                    TBL_MP_CRM_SM_SalesLead_Attachment newItem = new TBL_MP_CRM_SM_SalesLead_Attachment()
                    {
                        FK_SalesLeadID = newLead.PK_SalesLeadID,
                        FK_CategoryID = item.FK_CategoryID,
                        AttachmentFileName = item.AttachmentFileName,
                        Title = item.Title
                    };
                    _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead_Attachment.Add(newItem);
                    _UNIT.AppDBContext.SaveChanges();
                    //AMMEND ALL DOCUMENT HISTORY FOR THE NEWLY CREATED ATTACHMENT
                    List<TBL_MP_CRM_SM_DocumentHistory> docHistory = _UNIT.AppDBContext.TBL_MP_CRM_SM_DocumentHistory.Where(x => x.AttachmentID == item.PK_AttachmentID).ToList();
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
                        _UNIT.AppDBContext.TBL_MP_CRM_SM_DocumentHistory.Add(newHistory);
                        _UNIT.AppDBContext.SaveChanges();
                    }

                }
                frm.SetProgress(60, string.Format("\nSuccess : Attached {0} Documents with History to the New Revision", attachments.Count));
                Application.DoEvents();

                //AMMEND ALL SUSPECT INFO
                List<TBL_MP_CRM_SM_SalesLead_SuspectingInfo> suspectInfo = _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead_SuspectingInfo.Where(x => x.FK_SalesLeadID == sourceLeadID).ToList();
                foreach (TBL_MP_CRM_SM_SalesLead_SuspectingInfo item in suspectInfo)
                {
                    TBL_MP_CRM_SM_SalesLead_SuspectingInfo newItem = new TBL_MP_CRM_SM_SalesLead_SuspectingInfo()
                    {
                        FK_SalesLeadID = newLead.PK_SalesLeadID,
                        Brief_Description = item.Brief_Description,
                        FK_SuspectCategory = item.FK_SuspectCategory
                    };
                    _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead_SuspectingInfo.Add(newItem);
                    _UNIT.AppDBContext.SaveChanges();
                }
                frm.SetProgress(80, string.Format("\nSuccess : {0} Suspect Information attached with the New Revision", suspectInfo.Count));
                Application.DoEvents();

                //AMMEND ALL SCHDEULE CALLS AND FOLLOWUPS
                List<TBL_MP_CRM_ScheduleCallLog> schdeules = _UNIT.AppDBContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.EntityType == (int)APP_ENTITIES.SALES_LEAD).Where(x => x.EntityID == sourceLeadID).ToList();
                foreach (TBL_MP_CRM_ScheduleCallLog item in schdeules)
                {
                    TBL_MP_CRM_ScheduleCallLog newItem = new TBL_MP_CRM_ScheduleCallLog()
                    {
                        ActionID = item.ActionID,
                        Priority= item.Priority,
                        Completed = item.Completed,
                        ContactNumber = item.ContactNumber,
                        ContactPerson = item.ContactPerson,
                        CreatedBy = item.CreatedBy,
                        CreatedDatetime = item.CreatedDatetime,
                        CustomerName = item.CustomerName,
                        EntityID = newLead.PK_SalesLeadID,
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
                    _UNIT.AppDBContext.TBL_MP_CRM_ScheduleCallLog.Add(newItem);
                    _UNIT.AppDBContext.SaveChanges();

                    // ADD ASSIGNEES FOR THE NEWLY CREATED SCHEDULE
                    List<TBL_MP_CRM_ScheduleCallLogAssignee> assignees = _UNIT.AppDBContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == item.ScheduleID).ToList();
                    foreach (TBL_MP_CRM_ScheduleCallLogAssignee ass in assignees)
                    {
                        TBL_MP_CRM_ScheduleCallLogAssignee newAss = new TBL_MP_CRM_ScheduleCallLogAssignee()
                        {
                            EmployeeID = ass.EmployeeID,
                            IsDeleted = ass.IsDeleted,
                            ScheduleID = newItem.ScheduleID
                        };
                        _UNIT.AppDBContext.TBL_MP_CRM_ScheduleCallLogAssignee.Add(newAss);
                        _UNIT.AppDBContext.SaveChanges();
                    }


                    // ADD FOLLOWUPS FOR THE NEWLY CREATED SCHEDULE
                    List<TBL_MP_CRM_ScheduleCallLogFollowUp> followUps = _UNIT.AppDBContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.ScheduleID == item.ScheduleID).ToList();
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
                        _UNIT.AppDBContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Add(newFollowUp);
                        _UNIT.AppDBContext.SaveChanges();
                    }

                }
                Application.DoEvents();
                frm.SetProgress(100, string.Format("\nSuccess : {0} Schdeule Calls & FollowUps with the New Revision\n\n", schdeules.Count));



                //GET ALL LEAD FOR THIS REVISION AND SET THEM CLOSE
                strQuery = string.Format("select PK_SalesLeadID from TBL_MP_CRM_SM_SalesLead where leadno like '{0}%' ", sourceLead.LeadNo.Substring(0, 18));
                List<int> lstLeads=_UNIT.AppDBContext.Database.SqlQuery<int>(strQuery).ToList();
                foreach (int ID in lstLeads)
                {
                    TBL_MP_CRM_SM_SalesLead currLead = _UNIT.AppDBContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == ID).FirstOrDefault();
                    if (currLead.PK_SalesLeadID != newLead.PK_SalesLeadID)
                    {
                        if (currLead.FK_Status != CLOSE_STATUS_ID)
                        {
                            currLead.FK_Status = CLOSE_STATUS_ID;
                            currLead.ReasonClose = string.Format("GENERATED NEW REVISION\n{0} dt. {1}", newLead.LeadNo,newLead.LeadDate.ToString("dd MMM yyyy"));
                            _UNIT.AppDBContext.SaveChanges();
                        }
                    }
                }

                Application.DoEvents();
                frm.SetProgress(100, string.Format("\n\nSending Email for newly created Revision : {0}", newLead.LeadNo));
                Application.DoEvents();
                await this.SendLeadCreationEmail(newLead.PK_SalesLeadID);
                frm.Close();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesLead::GenerateRevision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteSalesLead(int leadID, int deletedBy)
        {
            try
            {
                TBL_MP_CRM_SM_SalesLead model = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == leadID).FirstOrDefault();
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::DeleteSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
    }

}
