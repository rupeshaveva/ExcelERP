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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    public class ServiceSalesOrder : DefaultService
    {
        public int SO_TYPE_PRIMARY_ID { get; set; }
        public int SO_TYPE_WITHOUT_ORDER_ID { get; set; }
        public int SO_TYPE_FOC_ID { get; set; }
        public int SO_TYPE_GFC_ID { get; set; }

        public int SO_STATUS_OPEN_ID { get; set; }
        public int SO_STATUS_CLOSED_ID { get; set; }
        public int SO_STATUS_PROCESSED_ID { get; set; }

        public ServiceSalesOrder() { _dbContext = new EXCEL_ERP_TESTEntities(); PopulateSalesOrderVariables(); }
        public ServiceSalesOrder(EXCEL_ERP_TESTEntities conn) { _dbContext = conn; PopulateSalesOrderVariables(); }
        private void PopulateSalesOrderVariables()
        {
            try
            {
                // POPULATING SO TYPES
                SO_TYPE_PRIMARY_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOType_PrimaryOrder).FirstOrDefault().DEFAULT_VALUE;
                SO_TYPE_WITHOUT_ORDER_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOType_WithoutOrder).FirstOrDefault().DEFAULT_VALUE;
                SO_TYPE_FOC_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOType_FOCOrder).FirstOrDefault().DEFAULT_VALUE;
                SO_TYPE_GFC_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOType_GFCOrder).FirstOrDefault().DEFAULT_VALUE;

                // POPULATING SO STATUSESD
                SO_STATUS_OPEN_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOStatus_Open).FirstOrDefault().DEFAULT_VALUE;
                SO_STATUS_CLOSED_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOStatus_Closed).FirstOrDefault().DEFAULT_VALUE;
                SO_STATUS_PROCESSED_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SOStatus_Processed).FirstOrDefault().DEFAULT_VALUE;


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::PopulateSalesOrderTypeVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<SelectListItem> GetAllSalesOrderStatuses()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int catID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.SalesOrderStatusAdminCategory).FirstOrDefault().DEFAULT_VALUE;
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
                MessageBox.Show(ex.Message, "ServiceSalesOrders::GetAllSalesOrderStatuses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public string GenerateNewSalesOrderNumber(int currFinYear, int currBrachID, int companyID)
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
                                                               where xx.fk_FormID == (int)DB_FORM_IDs.SALES_ORDER &&
                                                               xx.Fk_YearID == currFinYear &&
                                                               xx.Fk_BranchID == currBrachID
                                                               select xx).FirstOrDefault();

                strQuery = string.Format("SELECT count(*) FROM TBL_MP_CRM_SalesOrder WHERE SalesOrderNo NOT LIKE '%AMMEND%' and FK_YearID={0} AND FK_BranchID={1} AND FK_CompanyID={2}",
                                            currFinYear, currBrachID, companyID);
                cnt = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                // IF NO. CONTINUED FROM PREVIOUS YEAR GENERATE NEXT NUMBER BY REFEREING PREVIOUS YEAR MAX. NUMBER
                if (objVoucherSetup.Is_NoContinuedNextYear)
                {
                    TBL_MP_Admin_VoucherNoSetup objVoucherSetupPrevYear = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                                                                           where xx.fk_FormID == (int)DB_FORM_IDs.SALES_ORDER &&
                                                                           xx.Fk_YearID == currFinYear - 1 &&
                                                                           xx.Fk_BranchID == currBrachID
                                                                           select xx).FirstOrDefault();
                    TBL_MP_CRM_SalesOrder lastSOPrevYear = (from xx in _dbContext.TBL_MP_CRM_SalesOrder
                                                            where xx.FK_YearID == currFinYear - 1 &&
                                                            xx.FK_BranchID == currBrachID &&
                                                            xx.FK_CompanyID == companyID
                                                            orderby xx.CreatedDate descending
                                                            select xx).FirstOrDefault();
                    if (lastSOPrevYear != null)
                    {
                        string lstnumber = lastSOPrevYear.SalesOrderNo.Replace(objVoucherSetupPrevYear.NoPrefix, "").Replace(objVoucherSetupPrevYear.NoPostfix, "").Replace(objVoucherSetupPrevYear.NoSeperator, "");
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
                MessageBox.Show(errMessage, "ServiceSalesOrder::GenerateNewSalesOrderNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return keyCode;
        }
        public List<SelectListItem> GetAllSOWithStatusForGridDisplay(int statusID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesOrder> dbOrders = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.FK_SalesOrderStatus == statusID && x.IsActive==true).OrderByDescending(x => x.SalesOrderDate).ToList();
                foreach (TBL_MP_CRM_SalesOrder model in dbOrders)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = model.PK_SalesOrderID;
                    item.Code = model.SalesOrderNo;
                    string strDescription = string.Format("{0} dt.{1}", model.SalesOrderNo, model.SalesOrderDate.ToString("dd MMMyy"));
                    strDescription += string.Format("\n{0}", model.Tbl_MP_Master_Party.PartyName);
                    if (model.FK_QuotationID != null)
                    {
                        strDescription += string.Format("\nQUOT: {0} dt.{1}", model.TBL_MP_CRM_SalesQuotation.Quotation_No,
                            model.TBL_MP_CRM_SalesQuotation.Quotation_Date.ToString("dd MMMyy"));
                    }
                    if (model.FK_ProjectID != null)
                    {
                        strDescription += string.Format("\nPROJECT: {0} ({1})",
                            model.TBL_MP_PMC_ProjectMaster.ProjectName,
                            model.TBL_MP_PMC_ProjectMaster.ProjectNumber);
                    }
                    item.Description = strDescription;
                    lst.Add(item);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::UpdateSalesOrder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllSOWithStatus(int statusID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesOrder> dbOrders = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.FK_SalesOrderStatus == statusID).OrderByDescending(x => x.SalesOrderDate).ToList();
                foreach (TBL_MP_CRM_SalesOrder model in dbOrders)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = model.PK_SalesOrderID;
                    item.Code = model.FK_SalesOrderType.ToString();
                    item.Description = string.Format("{0} dt.{1}", model.SalesOrderNo, model.SalesOrderDate.ToString("dd MMMyy"));
                    item.Description += string.Format("\n{0}", model.Tbl_MP_Master_Party.PartyName);
                    if (model.FK_QuotationID != null)
                    {
                        item.Description += string.Format("\nQUOT: {0} dt.{1}", model.TBL_MP_CRM_SalesQuotation.Quotation_No,
                            model.TBL_MP_CRM_SalesQuotation.Quotation_Date.ToString("dd MMMyy"));
                    }
                    item.Description += string.Format("\n");
                    lst.Add(item);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::UpdateSalesOrder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public TBL_MP_CRM_SalesOrder GetSalesOrderDBInfoByID(int soID)
        {
            TBL_MP_CRM_SalesOrder model = null;
            try
            {
                model = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == soID).FirstOrDefault();
            }

            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::GetSalesOrderDBInfoByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        #region SALES ORDER MASTER INFO
        public int AddNewSalesOrder(TBL_MP_CRM_SalesOrder model)
        {
            int newID = 0;
            try
            {
                model.SalesOrderNo = this.GenerateNewSalesOrderNumber(model.FK_YearID, model.FK_BranchID, model.FK_CompanyID);
                _dbContext.TBL_MP_CRM_SalesOrder.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_SalesOrderID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::AddNewSalesOrder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateSalesOrder(TBL_MP_CRM_SalesOrder model)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesOrder dbModel = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == model.PK_SalesOrderID).FirstOrDefault();
                if (dbModel != null)
                {

                    dbModel.FK_ClientID = model.FK_ClientID;
                    dbModel.FK_ProjectID = model.FK_ProjectID;
                    dbModel.FK_QuotationID = model.FK_QuotationID;
                    dbModel.IsActive = model.IsActive;
                    dbModel.InstallationServicePODate = model.InstallationServicePODate;
                    dbModel.InstallationServicePOExpiryDate = model.InstallationServicePOExpiryDate;
                    dbModel.InstallationServicePONo = model.InstallationServicePONo;
                    dbModel.InstallationServicePOValidDays = model.InstallationServicePOValidDays;
                    dbModel.MaterialSupplyPODate = model.MaterialSupplyPODate;
                    dbModel.MaterialSupplyPOExpiryDate = model.MaterialSupplyPOExpiryDate;
                    dbModel.MaterialSupplyPONo = model.MaterialSupplyPONo;
                    dbModel.MaterialSupplyPOValidDays = model.MaterialSupplyPOValidDays;
                    dbModel.SalesOrderDate = model.SalesOrderDate;
                    dbModel.SalesOrderNo = model.SalesOrderNo;
                    dbModel.FK_SalesOrderStatus = model.FK_SalesOrderStatus;

                    dbModel.ModifiedBy = model.ModifiedBy;
                    dbModel.ModifiedDate = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::UpdateSalesOrder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        public int GetSalesOrderType(int orderID)
        {
            int mType = 0;
            try
            {
                TBL_MP_CRM_SalesOrder record = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == orderID).FirstOrDefault();
                if (record != null) mType = record.FK_SalesOrderType;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::GetSalesOrderType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return mType;
        }
        public bool IsSalesOrderReadOnly(int orderID)
        {
            bool result = true;
            try
            {
                TBL_MP_CRM_SalesOrder dbModel = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == orderID).FirstOrDefault();
                if (dbModel != null)
                {
                    int status = dbModel.FK_SalesOrderStatus;
                    if (status == SO_STATUS_OPEN_ID) result = false;
                    if (status == SO_STATUS_CLOSED_ID) result = true;
                    if (status == SO_STATUS_PROCESSED_ID) result = true;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrder::IsSalesOrderReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool IsSalesOrderStatusOPEN(int orderID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesOrder model = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == orderID).FirstOrDefault();
                if (model == null) return result;
                if (model.FK_SalesOrderStatus == this.SO_STATUS_OPEN_ID) result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "ServiceSalesOrder::IsSalesOrderStatusOPEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        #region SALES ORDER ATTACHMENTS
        public int AddNewSalesOrderAttachment(int OrderID, int docCategoryID, string title, string sourceFileNameWithPath, int createdBy)
        {
            int newID = 0;
            try
            {
                string newFileName = (new AppCommon()).GetUniqueFileName(sourceFileNameWithPath);
                string serverPath = AppCommon.GetSalesOrderAttachmentPath();
                string newFileNameWithPath = string.Format("{0}{1}", serverPath, newFileName);
                File.Copy(sourceFileNameWithPath, newFileNameWithPath, true);

                TBL_MP_CRM_SalesOrder_Attachment objOrder = new TBL_MP_CRM_SalesOrder_Attachment();
                objOrder.FK_SalesOrderID = OrderID;
                objOrder.FK_CategoryID = docCategoryID;
                objOrder.AttachmentFileName = newFileName;
                objOrder.Title = title;
                objOrder.IsActive = true;

                _dbContext.TBL_MP_CRM_SalesOrder_Attachment.Add(objOrder);
                _dbContext.SaveChanges();
                newID = objOrder.PK_AttachmentID;

                // MAINTAINING HISTORY OF ATTACHED DOCUMENT
                TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                history.AttachmentID = newID;
                history.EntityType = (int)APP_ENTITIES.SALES_ORDER;
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
                MessageBox.Show(errMessage, "ServiceSalesOrder::AddNewSalesOrderAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateSalesOrderAttachment(int AttachmentID, int docCategoryID, string title, string sourceFileNameWithPath, int modifiedBy)
        {
            bool result = false;
            try
            {
                string serverPath = AppCommon.GetSalesOrderAttachmentPath();
                TBL_MP_CRM_SalesOrder_Attachment objOrder = _dbContext.TBL_MP_CRM_SalesOrder_Attachment.Where(x => x.PK_AttachmentID == AttachmentID).FirstOrDefault();

                File.Copy(sourceFileNameWithPath, string.Format("{0}{1}", serverPath, objOrder.AttachmentFileName), true);
                objOrder.FK_CategoryID = docCategoryID;
                objOrder.Title = title;
                _dbContext.SaveChanges();


                TBL_MP_CRM_SM_DocumentHistory historyLead = new TBL_MP_CRM_SM_DocumentHistory();
                historyLead.AttachmentID = AttachmentID;
                historyLead.EntityType = (int)APP_ENTITIES.SALES_ORDER;
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
        public TBL_MP_CRM_SalesOrder_Attachment GetSalesOrderAttachmentDBRecord(int attachmentID)
        {
            return _dbContext.TBL_MP_CRM_SalesOrder_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
        }
        public List<SelectListItem> GetAllDeletedSalesOrderAttachments()
        {
            List<SelectListItem> lstAttachments = new List<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SalesOrder_Attachment> OrderAttachments = _dbContext.TBL_MP_CRM_SalesOrder_Attachment.Where(xx => xx.IsActive == false).ToList();
                foreach (TBL_MP_CRM_SalesOrder_Attachment dbItem in OrderAttachments)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = dbItem.PK_AttachmentID;
                    item.Description = string.Format("{0} ({1})\n{2}", dbItem.Title, dbItem.TBL_MP_Master_UserList.Description1, dbItem.TBL_MP_CRM_SalesOrder.SalesOrderNo);
                    item.Code = AppCommon.GetSalesOrderAttachmentPath() + dbItem.AttachmentFileName;
                    lstAttachments.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesOrder::GetAllDeletedSalesOrderAttachments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttachments;
        }
        public bool UndeleteSalesOrderAttachment(int attachmentID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesOrder_Attachment editItem = _dbContext.TBL_MP_CRM_SalesOrder_Attachment.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceSalesOrder::UndeleteSalesOrderAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

        #region Association
        public List<AssociatedEmployeeModel> GetAssociatesForSalesOrderID(int orderID)
        {
            List<AssociatedEmployeeModel> lst = new List<AssociatedEmployeeModel>();
            try
            {
                List<int> lstAssociates = (from x in _dbContext.TBL_MP_CRM_SalesOrder_Associates where x.FK_SalesOrderID == orderID select x.FK_EmployeeID).ToList();
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
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrder::GetAssociatesForOrderID", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    TBL_MP_CRM_SalesOrder_Associates model = _dbContext.TBL_MP_CRM_SalesOrder_Associates.Where(x => x.FK_SalesOrderID== SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model == null)
                    {
                        model = new TBL_MP_CRM_SalesOrder_Associates() { FK_EmployeeID = empID, FK_SalesOrderID = SelectedID, AssignDate = AppCommon.GetServerDateTime() };
                        _dbContext.TBL_MP_CRM_SalesOrder_Associates.Add(model);
                        _dbContext.SaveChanges();

                        (new ServiceNotification(_dbContext)).GenerateNotificationFor(APP_ENTITIES.SALES_ORDER, SelectedID, (int)empID, "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrder::AssociateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    TBL_MP_CRM_SalesOrder_Associates model = _dbContext.TBL_MP_CRM_SalesOrder_Associates.Where(x => x.FK_SalesOrderID == SelectedID).Where(x => x.FK_EmployeeID == empID).FirstOrDefault();
                    if (model != null)
                    {
                        _dbContext.TBL_MP_CRM_SalesOrder_Associates.Remove(model);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrder::DisassociateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        #region CONTACT REFERENCES FOR SALES ORDER
        public List<TBL_MP_CRM_SM_ContactReferences> GetAllCompanyContactsForSalesOrderDB(int orderID)
        {
            List<TBL_MP_CRM_SM_ContactReferences> lstReferences = new List<TBL_MP_CRM_SM_ContactReferences>();
            try
            {
                lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                 where xx.EntityType == (int)APP_ENTITIES.SALES_ORDER && xx.EntityID == orderID &&
                                 xx.Tbl_MP_Master_PartyContact_Detail.Tbl_MP_Master_Party.PartyType == "C" && xx.IsDeleted == false
                                 select xx).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrder::GetAllCompanyContactsForSalesOrder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstReferences;
        }
        public BindingList<SelectListItem> GetAllCompanyContactsForSalesOrder(int orderID)
        {
            BindingList<SelectListItem> lstContacts = new BindingList<SelectListItem>();
            try
            {
                List<TBL_MP_CRM_SM_ContactReferences> lstReferences = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                       where xx.EntityType == (int)APP_ENTITIES.SALES_ORDER && xx.EntityID == orderID && xx.IsDeleted == false
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
                MessageBox.Show(errMessage, "ServiceSalesOrder::GetAllCompanyContactsForSalesOrder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstContacts;
        }
        public bool UpdateSalesOrderContactReferences(int orderID, string selectedIDs)
        {
            bool result = false;
            try
            {

                //SET ALL CONTACTS FOR THIS SALES ORDER AS DELETED
                string strQuery = string.Format("UPDATE TBL_MP_CRM_SM_ContactReferences SET ISDELETED=1 WHERE ENTITYTYPE={0} AND ENTITYID={1}",
                    (int)APP_ENTITIES.SALES_ORDER, orderID);
                int cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);
                               
                // UNDELETE THE CONTACT IF FOUND
                strQuery = string.Format("UPDATE TBL_MP_CRM_SM_ContactReferences SET ISDELETED=0 WHERE ENTITYTYPE={0} AND ENTITYID={1} AND CONTACTID IN ({2})",
                    (int)APP_ENTITIES.SALES_ORDER, orderID, selectedIDs.Replace(DefaultStringSeperator, ','));
                cnt = _dbContext.Database.ExecuteSqlCommand(strQuery);

                //INSERT NEWLY ADDED CONTACT REFERENCES TO THE TABLE
                string[] arr = selectedIDs.Split(DefaultStringSeperator);
                for (int i = 0; i <= arr.GetUpperBound(0); i++)
                {
                    int contactID = int.Parse(arr[i]);
                    TBL_MP_CRM_SM_ContactReferences dbReference = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                   where xx.EntityType == (int)APP_ENTITIES.SALES_ORDER && xx.EntityID == orderID && xx.ContactID == contactID
                                                                   select xx
                                                                 ).FirstOrDefault();
                    if (dbReference == null)
                    {
                        dbReference = new TBL_MP_CRM_SM_ContactReferences() { EntityType = (int)APP_ENTITIES.SALES_ORDER, EntityID = orderID, ContactID = contactID, IsDeleted = false };
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
                MessageBox.Show(errMessage, "ServiceSalesQuotation::UpdateSalesOrderContactReferences", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        #endregion

        #region TERMS AND CONDITIONS
        public List<TermsAndConditionModel> GetAllTermsAndConditionForOrder(int orderID)
        {
            List<TermsAndConditionModel> lst = new List<TermsAndConditionModel>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions.AsEnumerable()
                       where xx.FK_SalesOrderID == orderID
                       orderby xx.Sequence
                       select new TermsAndConditionModel() {
                           TermID = xx.PK_Order_TermID,
                           //TitleID= (int)xx.FK_TermTitleID,
                           TermTitle=xx.TermTitle,
                           //TermTitle = xx.TBL_MP_Admin_UserList.Admin_UserList_Desc,
                           TermDescription= xx.Term_Description,
                           //Sequence=xx.Sequence
                           IsActive = false
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
        public int AddNewOrderTermAndCondition(TBL_MP_CRM_SalesOrder_TermsAndConditions model)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_Order_TermID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotation::AddNewQuotationTermAndCondition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool RemoveOrderTermAndCondition(string termIDs, int OrderID)
        {
            bool result = false;
            try
            {
                string[] arrIDs = termIDs.Split(DefaultStringSeperator);
                for (int i = 0; i <= arrIDs.GetUpperBound(0); i++)
                {
                    int termID = int.Parse(arrIDs[i]);
                    TBL_MP_CRM_SalesOrder_TermsAndConditions model = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions
                                                                      where xx.FK_SalesOrderID == OrderID && xx.PK_Order_TermID == termID
                                                                          select xx).FirstOrDefault();
                    if (model != null)
                    {
                        _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions.Remove(model);
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
        public bool UpdateOrderTermAndConditionDescription(int OrderTermID, string description)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesOrder_TermsAndConditions model = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions
                                                                  where xx.PK_Order_TermID == OrderTermID
                                                                  select xx).FirstOrDefault();
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
        public bool DeleteSalesOrder(int orderID,int deletedBy)
        {
            try
            {
                TBL_MP_CRM_SalesOrder model = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == orderID).FirstOrDefault();
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

        #region SALES ORDER REVISION 
        public bool GenerateRevision(int sourceOrderID, USER_SESSION currUser)
        {
            bool result = false;
            int sourceQUOTATION_ID = 0;
            int revisedQUOTATION_ID = 0;
            string strQuery = string.Empty;
            try
            {
                TBL_MP_CRM_SalesOrder sourceORDER = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == sourceOrderID).FirstOrDefault();
                if (sourceORDER == null)
                {
                    MessageBox.Show(String.Format("Unable lo locate ORDER [{0}]", sourceOrderID), "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                sourceQUOTATION_ID = (int)sourceORDER.FK_QuotationID;
                #region CHECK IF --- QUOTATION IS REVISED OR NOT
                TBL_MP_CRM_SalesQuotation sourceQUOT = _dbContext.TBL_MP_CRM_SalesQuotation.Where(X => X.PK_Quotation_ID == sourceQUOTATION_ID).FirstOrDefault();
                if (sourceQUOT == null)
                {
                    MessageBox.Show(String.Format("Unable lo locate Quotation [{0}]", sourceORDER.FK_QuotationID), "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string strQUOTNO = sourceQUOT.Quotation_No.Substring(0, 18);
                strQuery = string.Format("select TOP 1 PK_Quotation_ID from TBL_MP_CRM_SalesQuotation where Quotation_No like'{0}%' ORDER BY 1 DESC", strQUOTNO);
                revisedQUOTATION_ID = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();
                string strMESSAGE = string.Empty;
                if (sourceQUOTATION_ID == revisedQUOTATION_ID)
                {
                    strMESSAGE = "Found Revised Quotation associated with this Order.\nWhile generating revision of this SalesOrder";

                }
                else
                {
                }
                #endregion

                #region CREATE SALES ORDER MASTER RECORD

                TBL_MP_CRM_SalesOrder newORD = new TBL_MP_CRM_SalesOrder();

                strQuery = string.Format("select count(*) from TBL_MP_CRM_SalesOrder where SalesOrderNo like'{0}%'", sourceORDER.SalesOrderNo.Substring(0, 18));
                int countOrder = _dbContext.Database.SqlQuery<int>(strQuery).FirstOrDefault();

                newORD.SalesOrderNo = string.Format("{0}-AMMEND({1})", sourceORDER.SalesOrderNo.Substring(0, 18), countOrder);
                newORD.SalesOrderDate = AppCommon.GetServerDateTime();
                newORD.FK_QuotationID = sourceORDER.FK_QuotationID;
                newORD.FK_BOQRepresentativeID = sourceORDER.FK_BOQRepresentativeID;
                newORD.FK_ClientID = sourceORDER.FK_ClientID;
                newORD.FK_ProjectID = sourceORDER.FK_ProjectID;
                newORD.FK_POSource = sourceORDER.FK_POSource;
                newORD.FK_SalesOrderStatus = sourceORDER.FK_SalesOrderStatus;
                newORD.FK_SalesOrderType = sourceORDER.FK_SalesOrderType;

                #region INSATLLATION VALUE
                newORD.InstallationCGSTAmount = sourceORDER.InstallationCGSTAmount;
                newORD.InstallationCGSTPercent = sourceORDER.InstallationCGSTPercent;
                newORD.InstallationDiscountAmount = sourceORDER.InstallationDiscountAmount;
                newORD.InstallationDiscountType = sourceORDER.InstallationDiscountType;
                newORD.InstallationDiscountValue = sourceORDER.InstallationDiscountValue;
                newORD.InstallationFinalAmount = sourceORDER.InstallationFinalAmount;
                newORD.InstallationIGSTAmount = sourceORDER.InstallationIGSTAmount;
                newORD.InstallationIGSTPercent = sourceORDER.InstallationIGSTPercent;
                newORD.InstallationServicePODate = sourceORDER.InstallationServicePODate;
                newORD.InstallationServicePOExpiryDate = sourceORDER.InstallationServicePOExpiryDate;
                newORD.InstallationServicePONo = sourceORDER.InstallationServicePONo;
                newORD.InstallationServicePOValidDays = sourceORDER.InstallationServicePOValidDays;
                newORD.InstallationSGSTAmount = sourceORDER.InstallationSGSTAmount;
                newORD.InstallationSGSTPercent = sourceORDER.InstallationSGSTPercent;
                newORD.InstallationTotalAmount = sourceORDER.InstallationTotalAmount;
                #endregion
                #region MATERIAL VALUE
                newORD.MaterialSupplyCGSTAmount = sourceORDER.MaterialSupplyCGSTAmount;
                newORD.MaterialSupplyCGSTPercent = sourceORDER.MaterialSupplyCGSTPercent;
                newORD.MaterialSupplyDiscountamount = sourceORDER.MaterialSupplyDiscountamount;
                newORD.MaterialSupplyDiscountType = sourceORDER.MaterialSupplyDiscountType;
                newORD.MaterialSupplyDiscountValue = sourceORDER.MaterialSupplyDiscountValue;
                newORD.MaterialSupplyFinalAmount = sourceORDER.MaterialSupplyFinalAmount;
                newORD.MaterialSupplyIGSTAmount = sourceORDER.MaterialSupplyIGSTAmount;
                newORD.MaterialSupplyIGSTPercent = sourceORDER.MaterialSupplyIGSTPercent;
                newORD.MaterialSupplyPODate = sourceORDER.MaterialSupplyPODate;
                newORD.MaterialSupplyPOExpiryDate = sourceORDER.MaterialSupplyPOExpiryDate;
                newORD.MaterialSupplyPONo = sourceORDER.MaterialSupplyPONo;
                newORD.MaterialSupplyPOValidDays = sourceORDER.MaterialSupplyPOValidDays;
                newORD.MaterialSupplySGSTAmount = sourceORDER.MaterialSupplySGSTAmount;
                newORD.MaterialSupplySGSTPercent = sourceORDER.MaterialSupplySGSTPercent;
                newORD.MaterialSupplyTotalAmount = sourceORDER.MaterialSupplyTotalAmount;
                #endregion
                newORD.OrderFinalAmount = sourceORDER.OrderFinalAmount;

                newORD.FK_CompanyID = currUser.CompanyID;
                newORD.FK_BranchID = currUser.BranchID;
                newORD.FK_YearID = currUser.FinYearID;
                newORD.CreatedBy = currUser.EmployeeID;
                newORD.CreatedDate = AppCommon.GetServerDateTime();
                newORD.DeletedBy = currUser.EmployeeID;
                newORD.DeleteDateTime = AppCommon.GetServerDateTime();
                newORD.FK_ApprovedBy = sourceORDER.FK_ApprovedBy;
                newORD.ModifiedBy = currUser.EmployeeID;
                newORD.ModifiedDate = AppCommon.GetServerDateTime();
                newORD.IsActive = true;
        

                _dbContext.TBL_MP_CRM_SalesOrder.Add(newORD);
                _dbContext.SaveChanges();


                #endregion

                #region GENERATE BOQ FOR THE NEWLY CREATED ORDER
                /* TBL_MP_CRM_SalesOrder_BOQ prevBOQ = _dbContext.TBL_MP_CRM_SalesOrder_BOQ.Where(x => x.ORDER_ID == sourceOrderID
).FirstOrDefault();
                if (prevBOQ != null)
                {
                    SalesQuotationBOQViewModel model = new SalesQuotationBOQViewModel();
                    string json = prevBOQ.BOQ_OBJECT;
                    model = JsonConvert.DeserializeObject<SalesQuotationBOQViewModel>(json);
                    model.BOQ_ID = 0;
                    model.BOQ_NUMBER = string.Format("{0}-BOQ", newQUOTE.Quotation_No);
                    model.QUOTATION_ID = newQUOTE.PK_Quotation_ID;
                    (new ServiceSalesQuotationBOQ()).SaveBOQToDatabase(model, currUser.EmployeeID);
                }
                 */
                #endregion

                #region AMMEND ALL CONTACT REFERENCES
                List<TBL_MP_CRM_SM_ContactReferences> references = (from xx in _dbContext.TBL_MP_CRM_SM_ContactReferences
                                                                    where xx.EntityID == sourceOrderID && xx.EntityType == (int)APP_ENTITIES.SALES_ORDER && xx.IsDeleted == false
                                                                    select xx).ToList();
                foreach (TBL_MP_CRM_SM_ContactReferences item in references)
                {
                    TBL_MP_CRM_SM_ContactReferences newItem = new TBL_MP_CRM_SM_ContactReferences();
                    newItem.ContactID = item.ContactID;
                    newItem.EntityID = newORD.PK_SalesOrderID;
                    newItem.EntityType = item.EntityType;
                    newItem.IsDeleted = item.IsDeleted;

                   
                    _dbContext.TBL_MP_CRM_SM_ContactReferences.Add(newItem);

                    _dbContext.SaveChanges();
                }
                #endregion

                #region AMMEND ALL ASSOCIATES
                List<TBL_MP_CRM_SalesOrder_Associates> associates = _dbContext.TBL_MP_CRM_SalesOrder_Associates.Where(x => x.FK_SalesOrderID == sourceOrderID).ToList();
                foreach (TBL_MP_CRM_SalesOrder_Associates item in associates)
                {
                    TBL_MP_CRM_SalesOrder_Associates newItem = new TBL_MP_CRM_SalesOrder_Associates()
                    {
                        AssignDate = AppCommon.GetServerDateTime(),
                        FK_EmployeeID = item.FK_EmployeeID,
                        FK_SalesOrderID = newORD.PK_SalesOrderID
                    };
                    _dbContext.TBL_MP_CRM_SalesOrder_Associates.Add(newItem);
                    _dbContext.SaveChanges();
                }
                #endregion

                #region  AMMEND ALL ATTACHMENTS
                List<TBL_MP_CRM_SalesOrder_Attachment> attachments = _dbContext.TBL_MP_CRM_SalesOrder_Attachment
                    .Where(x => x.FK_SalesOrderID == sourceOrderID)
                    .Where(X => X.IsActive == true)
                    .ToList();
                foreach (TBL_MP_CRM_SalesOrder_Attachment item in attachments)
                {
                    TBL_MP_CRM_SalesOrder_Attachment newItem = new TBL_MP_CRM_SalesOrder_Attachment()
                    {
                        FK_SalesOrderID = newORD.PK_SalesOrderID,
                        FK_CategoryID = item.FK_CategoryID,
                        AttachmentFileName = item.AttachmentFileName,
                        Title = item.Title,
                        IsActive = item.IsActive
                    };
                    _dbContext.TBL_MP_CRM_SalesOrder_Attachment.Add(newItem);
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
                    .Where(x => x.EntityType == (int)APP_ENTITIES.SALES_ORDER)
                    .Where(x => x.EntityID == sourceOrderID)
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
                        EntityID = newORD.PK_SalesOrderID,
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

                #region AMMEND TERMS AND CONDITION
                List<TBL_MP_CRM_SalesOrder_TermsAndConditions> TNC = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions
                                                                      where xx.FK_SalesOrderID == sourceOrderID && xx.FK_TermTitleID == (int)APP_ENTITIES.SALES_ORDER 
                                                                    select xx).ToList();
                foreach (TBL_MP_CRM_SalesOrder_TermsAndConditions item in TNC)
                {
                    TBL_MP_CRM_SalesOrder_TermsAndConditions newItem = new TBL_MP_CRM_SalesOrder_TermsAndConditions();
                    newItem.FK_TermTitleID = item.FK_TermTitleID;
                    newItem.Sequence = item.Sequence;
                    newItem.Term_Description = item.Term_Description;
                   


                    _dbContext.TBL_MP_CRM_SalesOrder_TermsAndConditions.Add(newItem);

                    _dbContext.SaveChanges();
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
        public bool ApproveOrder(int OrdID, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesOrder dbLead = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == OrdID).FirstOrDefault();
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
