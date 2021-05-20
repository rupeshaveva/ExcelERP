
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    

    public class ServiceSalesQuotation: DefaultService 
    {
        public int STATUS_OPEN_ID = 0;
        public int STATUS_LOST_ID = 0;
        public int STATUS_CONVERTED_ID = 0;
        public int STATUS_CLOSED_ID = 0;
        public int STATUS_INPROCESS_ID = 0;
        public int STATUS_HOLD_ID = 0;

        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                STATUS_OPEN_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusOpen).FirstOrDefault().DEFAULT_VALUE;
                STATUS_LOST_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusLost).FirstOrDefault().DEFAULT_VALUE;
                STATUS_CONVERTED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusConverted).FirstOrDefault().DEFAULT_VALUE;
                STATUS_CLOSED_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusClose).FirstOrDefault().DEFAULT_VALUE;
                STATUS_INPROCESS_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusInProcess).FirstOrDefault().DEFAULT_VALUE;
                STATUS_HOLD_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuotationStatusHold).FirstOrDefault().DEFAULT_VALUE;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ServiceSalesQuotation(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context; PopulateStatusVariables();
        }
        public ServiceSalesQuotation() { _dbContext = new EXCEL_ERP_TESTEntities(); PopulateStatusVariables(); }
        public string GenerateNewSalesQuotationNumber(int currFinYear, int currBrachID, int companyID)
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
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.SALES_QUOTATION &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SalesQuotation WHERE Quotation_No NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objVoucherSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.SALES_QUOTATION &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_CRM_SalesQuotation lastSQPrevYear = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation
                                                                where xx.FK_YearID == (currFinYear - 1) &&
                                                            xx.FK_BranchID == currBrachID &&
                                                            xx.FK_CompanyID == companyID
                                                              orderby xx.CreatedDatetime descending
                                                              select xx).FirstOrDefault();
                    if (lastSQPrevYear != null)
                    {
                        string lstnumber = lastSQPrevYear.Quotation_No.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GenerateNewSalesQuotationNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }

        //public string GeneratePrimaryCode()
        //{
        //    string newCode = string.Empty;
        //    try
        //    {
        //        newCode = new ServiceMASTERS(_dbContext).GetNextEntityCode(DB_FORM_IDs.SALES_QUOTATION);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "ServiceSalesQuotation::GeneratePrimaryCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return newCode;
        //}
        public int AddNewQuotation(TBL_MP_CRM_SalesQuotation model)
        {
            int newID = 0;
            try
            {
                // INSERT NEW QUOTATION
                //model.Quotation_No = this.GenerateNewSalesQuotationNumber(model.FK_YearID,model.FK_BranchID,model.FK_CompanyID);
                model.CreatedDatetime = AppCommon.GetServerDateTime();
                model.IsActive = true;
                model.IsDeleted = false;
                _dbContext.TBL_MP_CRM_SalesQuotation.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_Quotation_ID;
                (new ServiceSalesEnquiry()).SetEnquiryStatusConverted(model.FK_Sales_Enquiry_ID);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::AddNewQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public void GenerateDefaultsFromSalesEnquiryIntoSalesQuotation(int salesEnquiryID, int salesQuotationID)
        {

            try
            {
                TBL_MP_CRM_SalesEnquiry dbEnquiry = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(x => x.PK_SalesEnquiryID == salesEnquiryID).FirstOrDefault();
                if (dbEnquiry == null) return;
                
                //CLIENT-INFO - GET ALL CONTACT REFERENCES FROM SALES ENQUIRY INTO SALES QUOTATION
                List<TBL_MP_CRM_SM_ContactReferences> leadContacts = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                      where xx.EntityID == salesEnquiryID && xx.EntityType == (int)APP_ENTITIES.SALES_ENQUIRY && xx.IsDeleted == false
                                                                      select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences contactRef in leadContacts)
                {
                    TBL_MP_CRM_SM_ContactReferences newReference = new TBL_MP_CRM_SM_ContactReferences()
                    {
                        EntityID = salesQuotationID,
                        EntityType = (int)APP_ENTITIES.SALES_QUOTATION,
                        ContactID = contactRef.ContactID,
                        IsDeleted = false
                    };
                    _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(newReference);
                    _dbContext.SaveChanges();
                }
                
                //GET ALL ASSOCIATES FROM SALES ENQUIRY INTO SALES QUOTATION
                List<TBL_MP_CRM_SalesEnquiry_Associates> leadAssociates = _dbContext.TBL_MP_CRM_SalesEnquiry_Associates.Where(x => x.FK_SalesEnquiryID == salesEnquiryID).ToList();
                foreach (TBL_MP_CRM_SalesEnquiry_Associates associate in leadAssociates)
                {
                    TBL_MP_CRM_SalesQuotation_Associates newAssociate = new TBL_MP_CRM_SalesQuotation_Associates()
                    {
                        AssignDate = AppCommon.GetServerDateTime(),
                        FK_EmployeeID = (int)associate.FK_EmployeeID,
                        FK_SalesQuotationID = salesQuotationID,
                    };
                    _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Add(newAssociate);
                    _dbContext.SaveChanges();
                }

                //GET ALL ATTACHMENT FROM SALES ENQUIRY  INTO SALES QUOTATION
                List<TBL_MP_CRM_SalesEnquiry_Attachments> enquiryAttachments = _dbContext.TBL_MP_CRM_SalesEnquiry_Attachments.Where(X => X.FK_SalesEnquiryID == salesEnquiryID).ToList();
                foreach (TBL_MP_CRM_SalesEnquiry_Attachments attachment in enquiryAttachments)
                {
                    string enquiryPath = AppCommon.GetSalesEnquiryAttachmentPath();
                    string quotationPath = AppCommon.GetSalesQuotationAttachmentPath();
                    string oldFilePath = string.Format("{0}{1}", enquiryPath, attachment.AttachmentFileName);
                    string newFilePath = string.Format("{0}{1}", quotationPath, attachment.AttachmentFileName);
                    File.Copy(oldFilePath, newFilePath, true);


                    TBL_MP_CRM_SalesQuotation_Attachments newAttachment = new TBL_MP_CRM_SalesQuotation_Attachments()
                    {
                        AttachmentFileName = attachment.AttachmentFileName,
                        Title = string.Format("{0} ({1})", attachment.Title, "viaENQ"),
                        FK_SalesQuotationID = salesQuotationID,
                        FK_CategoryID = (int)attachment.FK_CategoryID,
                    };
                    _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Add(newAttachment);
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GenerateDefaultsFromSalesEnquiryIntoSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool UpdateSalesQuotation(TBL_MP_CRM_SalesQuotation model)
        {
            try
            {
                TBL_MP_CRM_SalesQuotation EXISTING = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == model.PK_Quotation_ID).FirstOrDefault();
                EXISTING = model;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::UpdateSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public bool DeleteSalesQuotation(int quotationID, int deletedBy)
        {
            try
            {
                TBL_MP_CRM_SalesQuotation model = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quotationID).FirstOrDefault();
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::DeleteSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public List<SelectListItem> GetAllActiveQuotationStatusesList()
        {
            List<SelectListItem> quotationStatuses = new List<SelectListItem>();
            try
            {
                quotationStatuses=(from xx in _dbContext.TBL_MP_Admin_UserList
                                   where xx.Fk_Admin_CategoryID== (int)APP_ADMIN_CATEGORIES.QUOTATION_STATUS_ADMIN_CATEGORY && xx.IsActive==true 
                                   select new SelectListItem() { ID = xx.PKID, Description=xx.Admin_UserList_Desc  }
                                   ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllActiveQuotationStatusesList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return quotationStatuses;
        }
        public List<SelectListItem> GetAllActiveQuotationPriorityList()
        {
            List<SelectListItem> quotationPriorities = new List<SelectListItem>();
            try
            {
                quotationPriorities = (from xx in _dbContext.TBL_MP_Admin_UserList
                                     where xx.Fk_Admin_CategoryID == (int)APP_ADMIN_CATEGORIES.QUOTATION_PRIORITY_ADMIN_CATEGORY && xx.IsActive == true
                                     orderby xx.Admin_UserList_Desc
                                       select new SelectListItem() { ID = xx.PKID, Description = xx.Admin_UserList_Desc.ToUpper()}
                                   ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllActiveQuotationPriorityList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return quotationPriorities;
        }
        
        public BindingList<SelectListItem> GetSalseQuotationsSelectListForStatus(int quotationStatusID)
        {
            BindingList<SelectListItem> lst = new BindingList<SelectListItem>();
            List<TBL_MP_CRM_SalesQuotation> lstDBItems = null;
            try
            {
                if(quotationStatusID==0)
                    lstDBItems= (from xx in _dbContext.TBL_MP_CRM_SalesQuotation
                                 where xx.IsActive==true && xx.IsDeleted == false
                                 orderby xx.Quotation_Date descending select xx).ToList();
                else
                    lstDBItems = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation where xx.IsActive == true && xx.FK_Userlist_Quotation_Status_ID==quotationStatusID orderby xx.Quotation_Date descending select xx).ToList();


                foreach (TBL_MP_CRM_SalesQuotation item in lstDBItems)
                {
                    SelectListItem newItem = new SelectListItem() { ID = item.PK_Quotation_ID, Code= item.Quotation_No };
                    string strDescription = string.Format("{0}  Dt. {1}", item.Quotation_No, item.Quotation_Date.ToString("dd-MM-yyyy"));
                    strDescription += string.Format("   Valid till {0} ", (item.Quotation_Date.AddDays(item.Quotation_ValidDays)).ToString("dd MMM yy"));
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_OPEN_ID)
                    {
                        DateTime dtLast = item.Quotation_Date.AddDays(item.Quotation_ValidDays);
                        strDescription += string.Format("({0} Days remain)", (int)(dtLast - DateTime.Now).TotalDays);
                    }
                    else
                    {
                        //strDescription += string.Format("{0} Days", item.Quotation_ValidDays);
                    }

                    if (item.Tbl_MP_Master_Party != null) strDescription += string.Format("\n{0}", item.Tbl_MP_Master_Party.PartyName.ToUpper());
                    if (item.TBL_MP_CRM_SalesEnquiry != null) strDescription += string.Format("\n{0}", item.TBL_MP_CRM_SalesEnquiry.SalesEnquiry_No);
                    
                    DateTime stQuotDate = item.Quotation_Date;
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_OPEN_ID) strDescription += string.Format("\nOPEN");
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_CLOSED_ID) strDescription += string.Format("\nCLOSED");
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_LOST_ID) strDescription += string.Format("\nLOST");
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_INPROCESS_ID) strDescription += string.Format("\nIN-PROCESS");
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_HOLD_ID) strDescription += string.Format("\nHOLD");
                    if (item.FK_Userlist_Quotation_Status_ID == STATUS_CONVERTED_ID) strDescription += string.Format("\nCONVERTED");
                    strDescription += string.Format("\n");


                    newItem.Description = strDescription;
                    lst.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetSalseQuotationsSelectListForStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public TBL_MP_CRM_SalesQuotation GetSalesQuotationMasterDBInfo(int quotationID)
        {
            return _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quotationID).FirstOrDefault();
        }

        public bool IsQuotationReadOnly(int quotationID)
        {
            bool result = true;
            try
            {
                TBL_MP_CRM_SalesQuotation dbModel = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quotationID).FirstOrDefault();
                if (dbModel != null)
                {
                    int status = dbModel.FK_Userlist_Quotation_Status_ID;
                    if (status == STATUS_OPEN_ID) result = false;
                    if (status == STATUS_HOLD_ID) result = false;
                    if (status == STATUS_INPROCESS_ID) result = false;
                    if (status == STATUS_CLOSED_ID) result = true;
                    if (status == STATUS_LOST_ID) result = true;
                    if (status == STATUS_CONVERTED_ID) result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::IsQuotationReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool IsQuotationStatusOPEN(int quotationID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuotation model = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quotationID).FirstOrDefault();
                if (model == null) return result;
                if (model.FK_Userlist_Quotation_Status_ID == this.STATUS_OPEN_ID) result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ServiceSalesQuotation::IsQuotationStatusOPEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }


        #region ATTACHMENTS - SALES QUOTATION
        public int AddNewSalesQuotationAttachment(int QuotationID, int docCategoryID, string title, string sourceFileNameWithPath, int createdBy)
        {
            int newID = 0;
            try
            {
                string newFileName = (new AppCommon()).GetUniqueFileName(sourceFileNameWithPath);
                string serverPath = AppCommon.GetSalesQuotationAttachmentPath();
                string newFileNameWithPath = string.Format("{0}{1}", serverPath, newFileName);
                File.Copy(sourceFileNameWithPath, newFileNameWithPath, true);

                TBL_MP_CRM_SalesQuotation_Attachments objQuotation = new TBL_MP_CRM_SalesQuotation_Attachments();
                objQuotation.FK_SalesQuotationID = QuotationID;
                objQuotation.FK_CategoryID = docCategoryID;
                objQuotation.AttachmentFileName = newFileName;
                objQuotation.Title = title;
                objQuotation.IsActive = true;

                _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Add(objQuotation);
                _dbContext.SaveChanges();
                newID = objQuotation.PK_AttachmentID;

                // MAINTAINING HISTORY OF ATTACHED DOCUMENT
                TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                history.AttachmentID = newID;
                history.EntityType = (int)APP_ENTITIES.SALES_QUOTATION;
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::AddNewSalesQuotationAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateSalesQuotationAttachment(int AttachmentID, int docCategoryID, string title, string sourceFileNameWithPath, int modifiedBy)
        {
            bool result = false;
            try
            {
                string serverPath = AppCommon.GetSalesQuotationAttachmentPath();
                TBL_MP_CRM_SalesQuotation_Attachments objQuotation = _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Where(x => x.PK_AttachmentID == AttachmentID).FirstOrDefault();

                File.Copy(sourceFileNameWithPath, string.Format("{0}{1}", serverPath, objQuotation.AttachmentFileName), true);
                objQuotation.FK_CategoryID = docCategoryID;
                objQuotation.Title = title;
                _dbContext.SaveChanges();


                TBL_MP_CRM_SM_DocumentHistory historyLead = new TBL_MP_CRM_SM_DocumentHistory();
                historyLead.AttachmentID = AttachmentID;
                historyLead.EntityType = (int)APP_ENTITIES.SALES_QUOTATION;
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::UpdateSalesQuotationAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public TBL_MP_CRM_SalesQuotation_Attachments GetSalesQuotationAttachmentDBRecord(int attachmentID)
        {
            return _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
        }
        public bool DeleteSalesQuotationAttachment(int attachmentID, string reason,int deletedBY)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuotation_Attachments editItem = _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeletedDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = deletedBY;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::DeleteSalesQuotationAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public List<SelectListItem> GetAllDeletedSalesQuotationAttachments()
        {
            List<SelectListItem> lstAttachments = new List<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesQuotation_Attachments> QuotAttachments = _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Where(xx => xx.IsActive == false).ToList();
                foreach (TBL_MP_CRM_SalesQuotation_Attachments dbItem in QuotAttachments)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = dbItem.PK_AttachmentID;
                    item.Description = string.Format("{0} ({1})\n{2}", dbItem.Title, dbItem.TBL_MP_Master_UserList.Description1, dbItem.TBL_MP_CRM_SalesQuotation.Quotation_No);
                    item.Code = AppCommon.GetSalesQuotationAttachmentPath() + dbItem.AttachmentFileName;
                    lstAttachments.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesQuotation::GetAllDeletedSalesQuotationAttachments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttachments;
        }
        public bool UndeleteSalesQuotationAttachment(int attachmentID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuotation_Attachments editItem = _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeletedDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceSalesQuotation::UndeleteSalesQuotationAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region CLIENT & CONSULTANT CONTACTS
        public BindingList<SelectListItem> GetAllCompanyContactsForSalesQuotation(int quotationID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_QUOTATION && xx.EntityID == quotationID && xx.IsDeleted == false
                                                                       select xx).ToList();

                foreach (TBL_MP_CRM_SM_ContactReferences reference in lstReferences)
                {
                    if (reference.Tbl_MP_Master_PartyContact_Detail.Tbl_MP_Master_Party.PartyType == "C")
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllCompanyContactsForSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public List<TBL_MP_CRM_SM_ContactReferences> GetAllCompanyContactsForSalesQuotationDB(int quotationID)
        {
            List<TBL_MP_CRM_SM_ContactReferences> lstReferences = new List<TBL_MP_CRM_SM_ContactReferences>();
            try
            {
                lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                 where xx.EntityType == (int)APP_ENTITIES.SALES_QUOTATION && xx.EntityID == quotationID &&
                                 xx.Tbl_MP_Master_PartyContact_Detail.Tbl_MP_Master_Party.PartyType == "C" && xx.IsDeleted == false
                                 select xx).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllCompanyContactsForSalesQuotationDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstReferences;
        }
        public BindingList<SelectListItem> GetAllConsultantContactsForSalesQuotation(int quotationID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_QUOTATION && xx.EntityID == quotationID && xx.IsDeleted == false
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllConsultantContactsForSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public BindingList<SelectListItem> GetAllContactsForSalesQuotation(int quotationID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_QUOTATION && xx.EntityID == quotationID && xx.IsDeleted == false
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllContactsForSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public string GetContactNamesForSalesQuotation(int quotationID)
        {
            string strNames = string.Empty;
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_QUOTATION && xx.EntityID == quotationID && xx.IsDeleted == false
                                                                       select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences reference in lstReferences)
                {
                    strNames +=string.Format("{0}, ", reference.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName.ToUpper());
                }

                strNames= (strNames.Trim()).TrimEnd(',');
            }
           
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllContactsForSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strNames;
        }
        public bool UpdateSalesQuotationContactReferences(int quotationID, string selectedIDs)
        {
            bool result = false;
            try
            {

                //SET ALL CONTACTS FOR THIS SALES ENQUIRY AS DELETED
                string strQuery = string.Format("UPDATE TBL_MP_CRM_SM_ContactReferences SET ISDELETED=1 WHERE ENTITYTYPE={0} AND ENTITYID={1}",
                    (int)APP_ENTITIES.SALES_QUOTATION, quotationID);
                int cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);



                // UNDELETE THE CONTACT IF FOUND
                strQuery = string.Format("UPDATE TBL_MP_CRM_SM_ContactReferences SET ISDELETED=0 WHERE ENTITYTYPE={0} AND ENTITYID={1} AND CONTACTID IN ({2})",
                    (int)APP_ENTITIES.SALES_QUOTATION, quotationID, selectedIDs.Replace(DefaultStringSeperator, ','));
                cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);

                //INSERT NEWLY ADDED CONTACT REFERENCES TO THE TABLE
                string[] arr = selectedIDs.Split(DefaultStringSeperator);
                for (int i = 0; i <= arr.GetUpperBound(0); i++)
                {
                    int contactID = int.Parse(arr[i]);
                    TBL_MP_CRM_SM_ContactReferences dbReference = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                   where xx.EntityType == (int)APP_ENTITIES.SALES_QUOTATION && xx.EntityID == quotationID && xx.ContactID == contactID
                                                                   select xx
                                                                 ).FirstOrDefault();
                    if (dbReference == null)
                    {
                        dbReference = new TBL_MP_CRM_SM_ContactReferences() { EntityType = (int)APP_ENTITIES.SALES_QUOTATION, EntityID = quotationID, ContactID = contactID, IsDeleted = false };
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::UpdateSalesQuotationContactReferences", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        #endregion
        
        #region ASSOCIATION
        public List<AssociatedEmployeeModel> GetAssociatesForQuotationID(int quotationID)
        {
            List<AssociatedEmployeeModel> lst = new List<AssociatedEmployeeModel>();
            try
            {
                List<int> lstAssociates = (from x in _dbContext.TBL_MP_CRM_SalesQuotation_Associates where x.FK_SalesQuotationID == quotationID  select x.FK_EmployeeID).ToList();
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
                throw ex;
            }
            return lst;
        }
        public void AssociateEmployees(string IDs, int SelectedID)
        {
            string[] arrIDs = IDs.Split('|');
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int empID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SalesQuotation_Associates model = _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Where(x => x.FK_SalesQuotationID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model == null)
                    {
                        model = new TBL_MP_CRM_SalesQuotation_Associates() { FK_EmployeeID = empID, FK_SalesQuotationID = SelectedID, AssignDate = AppCommon.GetServerDateTime() };
                        _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Add(model);
                        _dbContext.SaveChanges();

                        (new ServiceNotification(_dbContext)).GenerateNotificationFor(APP_ENTITIES.SALES_QUOTATION, SelectedID, (int)empID,"","");
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
            string[] arrIDs = IDs.Split('|');
            try
            {
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int? empID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SalesQuotation_Associates model = _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Where(x => x.FK_SalesQuotationID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model != null)
                    {
                        _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Remove(model);
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

        #region TERMS AND CONDITIONS
        public bool UpdateSpecialNotesForQuotation(int quoteID, string strNotes)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuotation dbModel = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quoteID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.SpecialNotes = strNotes;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::UpdateSpecialNotesForQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public List<SelectListItem> GetAllTermsAndConditionForQuotation(int quotationID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation_TermsAndConditions.AsEnumerable()
                       where xx.FK_Quotation_ID == quotationID
                       orderby xx.Term_Title
                       select new SelectListItem() {
                           ID= xx.PK_Quotation_TermID,
                           Code= xx.Term_Title,
                           Description= xx.Term_Description,
                           IsActive=false
                       }
                     ).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllTermsAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public int AddNewQuotationTermAndCondition(TBL_MP_CRM_SalesQuotation_TermsAndConditions model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_CRM_SalesQuotation_TermsAndConditions.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_Quotation_TermID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::AddNewQuotationTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool RemoveQuotationTermAndCondition(string termIDs, int quotationID)
        {
            bool result = false;
            try
            {
                string[] arrIDs = termIDs.Split(DefaultStringSeperator);
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int termID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SalesQuotation_TermsAndConditions model =(from xx in _dbContext.TBL_MP_CRM_SalesQuotation_TermsAndConditions
                                                                         where xx.FK_Quotation_ID == quotationID && xx.PK_Quotation_TermID == termID
                                                                         select xx).FirstOrDefault();
                    if (model != null)
                    {
                        _dbContext.TBL_MP_CRM_SalesQuotation_TermsAndConditions.Remove(model);
                        _dbContext.SaveChanges();

                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::RemoveQuotationTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UpdateQuotationTermAndConditionDescription(int quotationTermID, string description)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuotation_TermsAndConditions model = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation_TermsAndConditions
                                                                      where xx.PK_Quotation_TermID == quotationTermID select xx).FirstOrDefault();
                if (model != null)
                {
                    model.Term_Description = description;
                    _dbContext.SaveChanges();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::UpdateQuotationTermAndConditionDescription", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region SALES QUOTATION REVISION 
        public bool GenerateRevision(int sourceQuotationID,USER_SESSION currUser )
        {
            bool result = false;
            int sourceENQUIRY_ID = 0;
            int revisedENQUIRY_ID = 0;
            string strQuery = string.Empty;
            try
            {
                TBL_MP_CRM_SalesQuotation sourceQUOTE = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == sourceQuotationID).FirstOrDefault();
                if (sourceQUOTE == null)
                {
                    MessageBox.Show(String.Format("Unable lo locate QUOTATION [{0}]", sourceQuotationID), "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                sourceENQUIRY_ID = sourceQUOTE.FK_Sales_Enquiry_ID;
                #region CHECK IF --- ENQUIRY IS REVISED OR NOT
                TBL_MP_CRM_SalesEnquiry sourceENQUIRY = _dbContext.TBL_MP_CRM_SalesEnquiry.Where(X => X.PK_SalesEnquiryID == sourceENQUIRY_ID).FirstOrDefault();
                if (sourceENQUIRY == null)
                {
                    MessageBox.Show(String.Format("Unable lo locate ENQUIRY [{0}]", sourceQUOTE.FK_Sales_Enquiry_ID), "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string strENQNO = sourceENQUIRY.SalesEnquiry_No.Substring(0,18);
                strQuery= string.Format("select TOP 1 PK_SalesEnquiryID from TBL_MP_CRM_SalesEnquiry where SalesEnquiry_No like'{0}%' ORDER BY 1 DESC", strENQNO);
                revisedENQUIRY_ID = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                string strMESSAGE = string.Empty;
                if (sourceENQUIRY_ID == revisedENQUIRY_ID)
                {
                    strMESSAGE = "Found Revised Enquiry associated with this Quotation.\nWhile generating revision of this SalesQuotation";

                }
                else
                {
                }
                #endregion

                #region CREATE SALES QUOTATION MASTER RECORD

                TBL_MP_CRM_SalesQuotation newQUOTE = new TBL_MP_CRM_SalesQuotation();
                
                strQuery = string.Format("select count(*) from TBL_MP_CRM_SalesQuotation where Quotation_No like'{0}%'", sourceQUOTE.Quotation_No.Substring(0, 18));
                int countQuotes = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();

                newQUOTE.Quotation_No = string.Format("{0}-AMMEND({1})", sourceQUOTE.Quotation_No.Substring(0, 18), countQuotes);
                newQUOTE.Quotation_Date = AppCommon.GetServerDateTime();
                newQUOTE.CreatedDatetime = AppCommon.GetServerDateTime();
                newQUOTE.FK_BOQRepresentativeID = sourceQUOTE.FK_BOQRepresentativeID;
                newQUOTE.FK_BranchID = sourceQUOTE.FK_BranchID;
                newQUOTE.FK_CompanyID = sourceQUOTE.FK_CompanyID;
                newQUOTE.FK_Customer_ID = sourceQUOTE.FK_Customer_ID;
                newQUOTE.FK_PreparedBy = sourceQUOTE.FK_PreparedBy;
                newQUOTE.FK_Project_City_ID = sourceQUOTE.FK_Project_City_ID;
                newQUOTE.FK_RepresentativeID = sourceQUOTE.FK_RepresentativeID;
                newQUOTE.FK_Sales_Enquiry_ID = sourceQUOTE.FK_Sales_Enquiry_ID;
                newQUOTE.FK_Userlist_Priority_ID = sourceQUOTE.FK_Userlist_Priority_ID;
                newQUOTE.FK_Userlist_ProjectSector_ID = sourceQUOTE.FK_Userlist_ProjectSector_ID;
                newQUOTE.FK_Userlist_Quotation_Status_ID = sourceQUOTE.FK_Userlist_Quotation_Status_ID;
                newQUOTE.FK_YearID = sourceQUOTE.FK_YearID;
                newQUOTE.FK_CheckedBy = sourceQUOTE.FK_CheckedBy;
                                                                               
                newQUOTE.FK_PreparedBy = currUser.EmployeeID;
                newQUOTE.FK_CompanyID = currUser.CompanyID;
                newQUOTE.FK_BranchID = currUser.BranchID;
                newQUOTE.FK_YearID = currUser.FinYearID;
                newQUOTE.IsActive = true;
                newQUOTE.CreatedDatetime = AppCommon.GetServerDateTime();

                _dbContext.TBL_MP_CRM_SalesQuotation.Add(newQUOTE);
                _dbContext.SaveChanges();


                #endregion
                #region GENERATE BOQ FOR THE NEWLY CREATED QUOTATION
                TBL_MP_CRM_SalesQuotation_BOQ prevBOQ = _dbContext.TBL_MP_CRM_SalesQuotation_BOQ.Where(x => x.QUOTE_ID == sourceQuotationID).FirstOrDefault();
                if (prevBOQ != null)
                {
                    SalesQuotationBOQViewModel model = new SalesQuotationBOQViewModel();
                    string json = prevBOQ.BOQ_OBJECT;
                    model = JsonConvert.DeserializeObject<SalesQuotationBOQViewModel>(json);
                    model.BOQ_ID =0;
                    model.BOQ_NUMBER = string.Format("{0}-BOQ", newQUOTE.Quotation_No);
                    model.QUOTATION_ID = newQUOTE.PK_Quotation_ID;
                    (new ServiceSalesQuotationBOQ()).SaveBOQToDatabase(model, currUser.EmployeeID);
                }
                #endregion
                #region AMMEND ALL CONTACT REFERENCES
                List<TBL_MP_CRM_SM_ContactReferences> references = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                    where xx.EntityID == sourceQuotationID && xx.EntityType == (int) APP_ENTITIES.SALES_QUOTATION && xx.IsDeleted == false
                                                                    select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences item in references)
                {
                    TBL_MP_CRM_SM_ContactReferences newItem = new TBL_MP_CRM_SM_ContactReferences();
                    newItem.ContactID = item.ContactID;
                    newItem.EntityType = item.EntityType;
                    newItem.EntityID = newQUOTE.PK_Quotation_ID;
                    newItem.IsDeleted = item.IsDeleted;

                    _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(newItem);

                    _dbContext.SaveChanges();
                }
                #endregion
                #region AMMEND ALL ASSOCIATES
                List<TBL_MP_CRM_SalesQuotation_Associates> associates = _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Where(x => x.FK_SalesQuotationID == sourceQuotationID).ToList();
                foreach (TBL_MP_CRM_SalesQuotation_Associates item in associates)
                {
                    TBL_MP_CRM_SalesQuotation_Associates newItem = new TBL_MP_CRM_SalesQuotation_Associates()
                    {
                        AssignDate = AppCommon.GetServerDateTime(),
                        FK_EmployeeID = item.FK_EmployeeID,
                        FK_SalesQuotationID = newQUOTE.PK_Quotation_ID
                    };
                    _dbContext.TBL_MP_CRM_SalesQuotation_Associates.Add(newItem);
                    _dbContext.SaveChanges();
                }
                #endregion
                #region  AMMEND ALL ATTACHMENTS
                List<TBL_MP_CRM_SalesQuotation_Attachments> attachments = _dbContext.TBL_MP_CRM_SalesQuotation_Attachments
                    .Where(x => x.FK_SalesQuotationID == sourceQuotationID)
                    .Where(X=>X.IsActive==true)
                    .ToList();
                foreach (TBL_MP_CRM_SalesQuotation_Attachments item in attachments)
                {
                    TBL_MP_CRM_SalesQuotation_Attachments newItem = new TBL_MP_CRM_SalesQuotation_Attachments()
                    {
                        FK_SalesQuotationID = newQUOTE.PK_Quotation_ID,
                        FK_CategoryID = item.FK_CategoryID,
                        AttachmentFileName = item.AttachmentFileName,
                        Title = item.Title,
                        IsActive=item.IsActive
                    };
                    _dbContext.TBL_MP_CRM_SalesQuotation_Attachments.Add(newItem);
                    _dbContext.SaveChanges();

                    #region AMMEND ALL DOCUMENT HISTORY FOR THE NEWLY CREATED ATTACHMENT
                    List<TBL_MP_CRM_SM_DocumentHistory> docHistory = _dbContext.TBL_MP_CRM_SM_DocumentHistory.Where(x => x.AttachmentID == item.PK_AttachmentID).ToList();
                    foreach (TBL_MP_CRM_SM_DocumentHistory itemHistory in docHistory)
                    {
                        TBL_MP_CRM_SM_DocumentHistory newHistory = new TBL_MP_CRM_SM_DocumentHistory()
                        {
                            CreateDatetime = AppCommon.GetServerDateTime(),
                            Description = itemHistory.Description,
                            EmployeeID = itemHistory.EmployeeID,
                            EntityType = itemHistory.EntityType,
                            AttachmentID = newItem.PK_AttachmentID,
                        };
                        _dbContext.TBL_MP_CRM_SM_DocumentHistory.Add(newHistory);
                        _dbContext.SaveChanges();
                    }
                    #endregion
                }
                #endregion
                #region AMMEND ALL SCHDEULE CALLS AND FOLLOWUPS
                List<TBL_MP_CRM_ScheduleCallLog> schdeules = _dbContext.TBL_MP_CRM_ScheduleCallLog
                    .Where(x => x.EntityType == (int)APP_ENTITIES.SALES_QUOTATION)
                    .Where(x => x.EntityID == sourceQuotationID)
                    .ToList();

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
                        EntityID = newQUOTE.PK_Quotation_ID,
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
                    List<TBL_MP_CRM_ScheduleCallLogAssignee> assignees = _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == item.ScheduleID).Where(x => x.IsDeleted == false).ToList();
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
                #endregion
                #region  GET ALL LEAD FOR THIS REVISION AND SET THEM CLOSE
                //strQuery = string.Format("select PK_SalesEnquiryID from TBL_MP_CRM_SalesEnquiry where SalesEnquiry_No like '{0}%' ", sourceQUOTE.SalesEnquiry_No.Substring(0, 18));
                //List<int> lstEnquiries = _dbContext.Database.SqlQuery<int>(strQuery).ToList();
                //foreach (int ID in lstEnquiries)
                //{
                //    TBL_MP_CRM_SalesQuotation currQUOTE = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == ID).FirstOrDefault();
                //    if (currQUOTE.PK_SalesEnquiryID != newQUOTE.PK_SalesEnquiryID)
                //    {
                //        if (currQUOTE.FK_Userlist_Enquiry_Status_ID == this.STATUS_OPEN_ID)
                //        {
                //            currQUOTE.FK_Userlist_Enquiry_Status_ID = this.STATUS_CLOSED_ID;
                //            currQUOTE.ReasonClose = string.Format("GENERATED NEW REVISION\n{0} dt. {1}", newQUOTE.SalesEnquiry_No, newQUOTE.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                //            _dbContext.SaveChanges();
                //        }
                //    }
                //}
                #endregion

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
        #endregion  

        public List<MultiSelectListItem> GetAllApprovedAndOpenSalesQuotations()
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {

                lst = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation.AsEnumerable()
                       where xx.FK_ApprovedBy != null && xx.FK_Userlist_Quotation_Status_ID== this.STATUS_OPEN_ID
                       select new MultiSelectListItem() {
                           ID= xx.PK_Quotation_ID,
                           Description=string.Format("{0} dt. {1}\n{2}", xx.Quotation_No, xx.Quotation_Date.ToString("dd MMM yy"), xx.Tbl_MP_Master_Party.PartyName)
                       }).ToList();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::GetAllApprovedAndOpenSalesQuotations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public bool ApproveQuotation(int quotID, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuotation dbLead = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quotID).FirstOrDefault();
                dbLead.FK_ApprovedBy = empID;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::ApproveQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
