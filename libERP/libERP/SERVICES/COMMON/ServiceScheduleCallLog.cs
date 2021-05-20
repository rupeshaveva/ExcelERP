using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using System.ComponentModel;
using libERP.MODELS.COMMON;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.MODELS.CRM;
using libERP.SERVICES.HR;
using libERP.SERVICES.CRM;

namespace libERP.SERVICES.COMMON
{
    public class ServiceScheduleCallLog : DefaultService 
    {
        private int CALL_STATUS_CLOSE_ID = 0;
        private int FOLLOWUP_STATUS_CLOSE_ID = 0;
        public ServiceScheduleCallLog(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context; PopulateStatusVariables();
        }
        public ServiceScheduleCallLog()
        {
            _dbContext = new EXCEL_ERP_TESTEntities(); PopulateStatusVariables();
        }

        private void PopulateStatusVariables()
        {
            try
            {
                List<APP_DEFAULTS> lstDefaults = _dbContext.APP_DEFAULTS.ToList();
                CALL_STATUS_CLOSE_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ScheduleCallStatusClose).FirstOrDefault().DEFAULT_VALUE;
                FOLLOWUP_STATUS_CLOSE_ID = lstDefaults.Where(x => x.ID == (int)APP_DEFAULT_VALUES.FollowUpStatusClose).FirstOrDefault().DEFAULT_VALUE;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiry::PopulateStatusVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        frmProgress progressForm = null;
        public bool IsScuccess { get; set; }
        #region scheduled call logs
        public async Task<int> AddNewScheduleCall(ScheduleCallAddEditModel model, int createdBy)
        {
            string strMessage = string.Empty;
            string strAssignees = string.Empty;
            string strRequirements = string.Empty;

            try
            {
                progressForm = new frmProgress();
                progressForm.Text = "CREATING A NEW SCHEDULE CALL";
                progressForm.lblProgressText.Text = "Inserting a New Business Schecule Call";
                progressForm.Show();
                Application.DoEvents();


                model.DB_MODEL.EntityType = (int)model.SOURCE_ENTITY;
                model.DB_MODEL.EntityID = (int)model.SOURCE_ENTITY_ID;
                model.DB_MODEL.CreatedBy = createdBy;
                model.DB_MODEL.CreatedDatetime = AppCommon.GetServerDateTime();
                model.DB_MODEL.Reminder = model.DB_MODEL.Reminder;
                model.DB_MODEL.IsDeleted = false;
                model.DB_MODEL.Completed = false;
                _dbContext.TBL_MP_CRM_ScheduleCallLog.Add(model.DB_MODEL);
                _dbContext.SaveChanges();
                model.ScheduleID = model.DB_MODEL.ScheduleID;

                progressForm.SetProgress(30, string.Format("\nSuccess ID: {0}\n\nInserting Assignees for this schedule in Database.", model.ScheduleID));
                Application.DoEvents();
                string mailTo = string.Empty;
                foreach (MultiSelectListItem item in model.listAssignees)
                {

                    _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Add(new TBL_MP_CRM_ScheduleCallLogAssignee()
                    {
                        EmployeeID = item.ID,
                        IsDeleted = false,
                        ScheduleID = model.ScheduleID
                    });
                    strAssignees += item.Description.Split('\n')[0] + " , ";
                    _dbContext.SaveChanges();
                    mailTo += ServiceEmployee.GetEmployeeEmailByID(item.ID) + ";";
                }
                strAssignees = strAssignees.TrimEnd(' ').TrimEnd(',');
                mailTo += "sachin.a.patwardhan@gmail.com";
                progressForm.SetProgress(60, string.Format("\nSuccess: {0} Assignee(s) inserted in Database for Schdeule #{1}", model.listAssignees.Count, model.ScheduleID));
                progressForm.SetProgress(60, string.Format("\n\n\nSending Email to {0}", mailTo.Replace(";", "; ")));
                Application.DoEvents();
                ServiceEmail mail = new ServiceEmail();
                string strSubject = string.Format("New Schedule Call: {0}", model.DB_MODEL.Subject.ToUpper());

                switch (model.SOURCE_ENTITY)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        LeadMasterInfoModel lead = (new ServiceSalesLead(_dbContext)).GetLeadMasterInfo(model.SOURCE_ENTITY_ID);
                        if (lead != null)
                        {
                            strMessage += String.Format("\n\n\nLead No.: {0} dt. {1}\nParty Name: {2}\n", lead.LeadNo, lead.LeadDate.Value.ToString("dd MMMyy"), lead.LeadName);
                            strRequirements = string.Format("Lead Requirements:\n{0}", lead.LeadRequirement);
                        }
                        break;

                    case APP_ENTITIES.SALES_ENQUIRY:
                        TBL_MP_CRM_SalesEnquiry enquiry = (new ServiceSalesEnquiry(_dbContext)).GetEnquiryMasterDBInfo(model.SOURCE_ENTITY_ID);
                        if (enquiry != null)
                        {
                            strMessage += String.Format("\n\n\nEnquiry No.: {0} dt. {1}\nParty Name: {2}\n",
                                enquiry.SalesEnquiry_No,
                                enquiry.SalesEnquiry_Date.ToString("dd MMMyy"),
                                enquiry.Tbl_MP_Master_Party.PartyName);
                            strRequirements = string.Format("Description:\n{0}", enquiry.General_Description);
                        }
                        break;

                    case APP_ENTITIES.SALES_QUOTATION:
                        TBL_MP_CRM_SalesQuotation quotation = (new ServiceSalesQuotation(_dbContext)).GetSalesQuotationMasterDBInfo(model.SOURCE_ENTITY_ID);
                        if (quotation != null)
                        {
                            strMessage += String.Format("\n\n\n Quotation No.: {0} dt. {1}\nParty Name: {2}\n",
                                quotation.Quotation_No,
                                quotation.Quotation_Date.ToString("dd MMMyy"),
                                quotation.Tbl_MP_Master_Party.PartyName);
                            strRequirements = string.Format("Special Note:\n{0}", quotation.SpecialNotes);
                        }
                        break;

                    case APP_ENTITIES.SALES_ORDER:
                        TBL_MP_CRM_SalesOrder order = (new ServiceSalesOrder(_dbContext)).GetSalesOrderDBInfoByID(model.SOURCE_ENTITY_ID);
                        if (order != null)
                        {
                            strMessage += String.Format("\n\n\n Order No.: {0} dt. {1}\nParty Name: {2}\n",
                                order.SalesOrderNo,
                                order.SalesOrderDate.ToString("dd MMMyy"),
                                order.Tbl_MP_Master_Party.PartyName);
                            strRequirements = string.Empty;
                        }
                        break;




                }
                strMessage += string.Format("\nContact Person(s) : {0}", model.DB_MODEL.ContactPerson);
                strMessage += string.Format("\nContact Number(s) : {0}", model.DB_MODEL.ContactNumber);
                strMessage += string.Format("\nAddress : {0}", model.DB_MODEL.Location);
                strMessage += string.Format("\n\nSCHEDULE\nSchedule Type: {0}", (new ServiceMASTERS(_dbContext)).GetAllScheduleCallActions().Where(x => x.ID == model.DB_MODEL.ActionID).FirstOrDefault().Description);
                strMessage += string.Format("\nSchdeule Date: {0}\nSchedule Time:{1}", model.DB_MODEL.StartAt.Value.ToString("dd MMM yyyy"), model.DB_MODEL.StartAt.Value.ToString("hh:mm tt"));
                strMessage += string.Format("\nPlan/Action: {0}", model.DB_MODEL.Subject.ToUpper());
                strMessage += string.Format("\nRemarks: {0}\n", model.DB_MODEL.Remarks);


                strMessage += string.Format("\nAssigned To : {0}", strAssignees);

                strMessage += string.Format("\n\n{0}", strRequirements);


                string strEmailFrom = ServiceEmployee.GetEmployeeEmailByID(createdBy);
                await mail.SendScheduleCallCreatedEmailNotification(createdBy, strEmailFrom, mailTo, strSubject, strMessage);
                Application.DoEvents();
                progressForm.Close();
                this.IsScuccess = true;
                return model.ScheduleID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::AddNewScheduleCall", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model.ScheduleID;

        }
        public async Task<bool> UpdateScheduleCall(ScheduleCallAddEditModel model, int empID)
        {
            try
            {
                progressForm = new frmProgress();
                progressForm.Text = "UPDAING SCHEDULE CALL ID: " + model.ScheduleID;
                progressForm.lblProgressText.Text = "Updating Business Schecule Call Master Info";
                progressForm.Show();
                Application.DoEvents();
                int statusClose = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ScheduleCallStatusClose).FirstOrDefault().DEFAULT_VALUE;
                if (model.DB_MODEL.ScheduleStatus == statusClose)
                {
                    model.DB_MODEL.Completed = true;
                }

                model.DB_MODEL.EntityType = (int)model.SOURCE_ENTITY;
                model.DB_MODEL.EntityID = (int)model.SOURCE_ENTITY_ID;
                model.DB_MODEL.ModifiedBy = empID;
                model.DB_MODEL.ModifiedDatetime = AppCommon.GetServerDateTime();
                model.DB_MODEL.Reminder = model.DB_MODEL.Reminder;

                TBL_MP_CRM_ScheduleCallLog dbModel = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == model.ScheduleID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.Subject = model.DB_MODEL.Subject;
                    dbModel.Priority = model.DB_MODEL.Priority;
                    dbModel.ActionID = model.DB_MODEL.ActionID;
                    dbModel.ScheduleStatus = model.DB_MODEL.ScheduleStatus;
                    dbModel.Completed = model.DB_MODEL.Completed;
                    dbModel.ContactNumber = model.DB_MODEL.ContactNumber;
                    dbModel.ContactPerson = model.DB_MODEL.ContactPerson;
                    dbModel.CustomerName = model.DB_MODEL.CustomerName;
                    dbModel.EndsAt = model.DB_MODEL.EndsAt;
                    dbModel.StartAt = model.DB_MODEL.StartAt;
                    dbModel.Reminder = model.DB_MODEL.Reminder;
                    dbModel.EntityID = model.DB_MODEL.EntityID;
                    dbModel.EntityType = model.DB_MODEL.EntityType;
                    dbModel.ModifiedBy = empID;
                    dbModel.ModifiedDatetime = AppCommon.GetServerDateTime();
                    dbModel.Remarks = model.DB_MODEL.Remarks;

                    _dbContext.SaveChanges();
                }
                progressForm.SetProgress(25, string.Format("\nSuccess: Updated Schedule Call Information into the Database"));
                Application.DoEvents();


                progressForm.SetProgress(30, string.Format("\nSuccess ID: \n\nUpdating Assignees for this schedule in Database."));
                Application.DoEvents();
                string mailTo = string.Empty;

                // MARK ALL ASSIGNEES AS DELETED
                List<TBL_MP_CRM_ScheduleCallLogAssignee> dbAssignees = _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == model.ScheduleID).ToList();
                foreach (TBL_MP_CRM_ScheduleCallLogAssignee item in dbAssignees)
                {
                    item.IsDeleted = true;
                }
                _dbContext.SaveChanges();
                // OF EMPLOYEE FOUND SET DELETED=FALSE OR INSERT IF NOT FOUND
                foreach (MultiSelectListItem item in model.listAssignees)
                {
                    TBL_MP_CRM_ScheduleCallLogAssignee emp = _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == model.ScheduleID).Where(x => x.EmployeeID == item.ID).FirstOrDefault();
                    if (emp != null)
                        emp.IsDeleted = false;
                    else
                    {
                        _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Add(new TBL_MP_CRM_ScheduleCallLogAssignee()
                        {
                            EmployeeID = item.ID,
                            IsDeleted = false,
                            ScheduleID = model.ScheduleID
                        });
                    }
                    _dbContext.SaveChanges();
                    mailTo += ServiceEmployee.GetEmployeeEmailByID(item.ID) + ";";
                }

                mailTo += "sachin.a.patwardhan@gmail.com";
                progressForm.SetProgress(60, string.Format("\nSuccess: {0} Assignee(s) updated in Database for Schdeule #{1}", model.listAssignees.Count, model.ScheduleID));
                progressForm.SetProgress(60, string.Format("\n\n\nSending Email to {0}", mailTo.Replace(";", "; ")));
                Application.DoEvents();
                List<SelectListItem> scheduleStatusList = (new ServiceMASTERS()).GetAllScheduleCallsStatus();
                ServiceEmail mail = new ServiceEmail();
                string strSubject = string.Format("Updated Schedule Call: {0}", model.DB_MODEL.Subject);
                string strMessage = string.Empty;
                strMessage += string.Format("{0}\nStatus: {1}", model.DB_MODEL.Subject.ToUpper(), scheduleStatusList.Where(x => x.ID == model.DB_MODEL.ScheduleStatus).FirstOrDefault().Description);
                strMessage += string.Format("\nRemarks:{0}\n", model.DB_MODEL.Remarks);
                strMessage += string.Format("\nParty : {0}", model.DB_MODEL.CustomerName);
                strMessage += string.Format("\nContact Person(s) : {0}", model.DB_MODEL.ContactPerson);
                strMessage += string.Format("\nContact Number(s) : {0}", model.DB_MODEL.ContactNumber);
                strMessage += string.Format("\nLocation : {0}", model.DB_MODEL.Location);
                strMessage += string.Format("\n\nStarts At : {0}", model.DB_MODEL.StartAt.Value.ToString("dd MMMyy hh:mmtt"));
                strMessage += string.Format("\nEnds At : {0}", model.DB_MODEL.StartAt.Value.ToString("dd MMMyyy hh:mmtt"));

                switch (model.SOURCE_ENTITY)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        LeadMasterInfoModel lead = (new ServiceSalesLead(_dbContext)).GetLeadMasterInfo(model.SOURCE_ENTITY_ID);
                        if (lead != null)
                        {
                            strMessage += String.Format("\n\n\nSOURCE INFO.\nLead: {0} dt. {1}\n{2}", lead.LeadNo, lead.LeadDate.Value.ToString("dd MMMyy"), lead.LeadRequirement);
                        }
                        break;
                }
                string strEmailAddress = ServiceEmployee.GetEmployeeEmailByID(empID);
                await mail.SendScheduleCallCreatedEmailNotification(empID, strEmailAddress, mailTo, strSubject, strMessage);
                Application.DoEvents();
                progressForm.Close();
                this.IsScuccess = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::UpdateScheduleCall", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsScuccess;
        }
        public bool DeletedScheduledcallLog(int scheduledCallID, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_ScheduleCallLog dbScheduledCall = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == scheduledCallID).FirstOrDefault();
                dbScheduledCall.DeleteDateTime = AppCommon.GetServerDateTime();
                dbScheduledCall.DeletedBy = empID;
                dbScheduledCall.IsDeleted = true;
                // dbScheduledCall.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceParties::DeleteParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public List<SelectListItem> GetActiveScheduleCallsFor(APP_ENTITIES entity, int entityID)
        {
            List<SelectListItem> lstCalls = new List<SelectListItem>();
            try
            {
                int Status = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ScheduleCallStatusInProgress).FirstOrDefault().DEFAULT_VALUE;
                List<TBL_MP_CRM_ScheduleCallLog> callLogs = (
                    from xx in _dbContext.TBL_MP_CRM_ScheduleCallLog
                    where xx.EntityType == (int)entity && xx.EntityID == entityID && xx.ScheduleStatus == Status && xx.IsDeleted==false
                    orderby xx.CreatedDatetime descending
                    select xx

                    ).ToList();
                callLogs = callLogs.OrderByDescending(x => x.Priority).ToList();
                List<SelectListItem> actions = (new ServiceMASTERS(_dbContext)).GetAllScheduleCallActions();
                List<SelectListItem> priorities = (new ServiceMASTERS(_dbContext)).GetAllScheduleCallPriorities();
                foreach (TBL_MP_CRM_ScheduleCallLog log in callLogs)
                {

                    SelectListItem item = new SelectListItem() { ID = log.ScheduleID };
                    string strDescription = string.Empty;
                    if (log.ActionID != null)
                        strDescription = string.Format("{0}", actions.Where(x => x.ID == log.ActionID).FirstOrDefault().Description);
                    if (log.Priority != null)
                        strDescription = string.Format("  ({0})", priorities.Where(x => x.ID == log.Priority).FirstOrDefault().Description);

                    strDescription += string.Format("\n{0}\n{1}", log.Subject.ToUpper(), log.CustomerName);
                    strDescription += string.Format("\nInbetween {0} - {1}", log.StartAt.Value.ToString("ddMMMyy hh:mmtt"), log.EndsAt.Value.ToString("ddMMMyy hh:mmtt"));
                    strDescription += string.Format("\n\nCreated: {0}", log.CreatedDatetime.Value.ToString("ddMMMyy hh:mmtt"));
                    if (log.ModifiedDatetime != null)
                    {
                        strDescription += string.Format("\nModified: {0}", log.ModifiedDatetime.Value.ToString("ddMMMyy hh:mmtt"));
                    }

                    item.Description = strDescription;
                    lstCalls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "ServiceScheduleCallLog::GetActiveScheduleCallsFor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstCalls;
        }
        public List<SelectListItem> GetPastScheduleCallsFor(APP_ENTITIES entity, int entityID)
        {
            List<SelectListItem> lstCalls = new List<SelectListItem>();
            try
            {
                int STATUS = CALL_STATUS_CLOSE_ID;
                List<TBL_MP_CRM_ScheduleCallLog> callLogs = (
                    from xx in _dbContext.TBL_MP_CRM_ScheduleCallLog
                    where xx.EntityType == (int)entity && xx.EntityID == entityID && xx.ScheduleStatus == STATUS
                    orderby xx.CreatedDatetime descending
                    select xx

                    ).ToList();
                List<SelectListItem> actions = (new ServiceMASTERS(_dbContext)).GetAllScheduleCallActions();
                foreach (TBL_MP_CRM_ScheduleCallLog log in callLogs)
                {

                    SelectListItem item = new SelectListItem() { ID = log.ScheduleID };
                    item.Description = string.Format("{0} - {1}\n{2}\nInbetween {3} - {4}",
                        actions.Where(x => x.ID == log.ActionID).FirstOrDefault().Description,
                        log.Subject, log.CustomerName, log.StartAt.Value.ToString("ddMMMyy hh:mmtt"), log.EndsAt.Value.ToString("ddMMMyy hh:mmtt"));

                    lstCalls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetActiveScheduleCallsFor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstCalls;
        }
        public ScheduleCallAddEditModel GetSchdeuledCallAddEditModelForSchedule(int scheduleID)
        {
            ScheduleCallAddEditModel model = new ScheduleCallAddEditModel() { ScheduleID = scheduleID };
            try
            {
                TBL_MP_CRM_ScheduleCallLog log = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == model.ScheduleID).FirstOrDefault();
                if (log != null)
                {
                    model.SOURCE_ENTITY = (APP_ENTITIES)log.EntityType;
                    model.SOURCE_ENTITY_ID = (int)log.EntityID;
                    model.DB_MODEL = log;
                    model.listAssignees = this.GelAllAssigneesForSchedule(model.ScheduleID);
                    string strCaption = string.Empty;
                    switch (model.SOURCE_ENTITY)
                    {
                        case APP_ENTITIES.SALES_LEAD:
                            LeadMasterInfoModel leadInfo = (new ServiceSalesLead(_dbContext)).GetLeadMasterInfo(model.SOURCE_ENTITY_ID);
                            strCaption = string.Format("LEAD: {0} {1} dt. {2}", leadInfo.LeadNo, leadInfo.LeadName, leadInfo.LeadDate.Value.ToString("dd MMM yyyy"));
                            break;
                        case APP_ENTITIES.SALES_ENQUIRY:
                            TBL_MP_CRM_SalesEnquiry EnquiryInfo = (new ServiceSalesEnquiry(_dbContext)).GetEnquiryMasterDBInfo(model.SOURCE_ENTITY_ID);
                            strCaption = string.Format("ENQURIY: {0} dt. {1}", EnquiryInfo.SalesEnquiry_No, EnquiryInfo.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                            break;
                        case APP_ENTITIES.SALES_QUOTATION:
                            TBL_MP_CRM_SalesQuotation QuotationInfo = (new ServiceSalesQuotation(_dbContext)).GetSalesQuotationMasterDBInfo(model.SOURCE_ENTITY_ID);
                            strCaption = string.Format("QUOTATION: {0} dt. {1}", QuotationInfo.Quotation_No, QuotationInfo.Quotation_Date.ToString("dd MMM yyyy"));
                            break;
                        case APP_ENTITIES.SALES_ORDER:
                            TBL_MP_CRM_SalesOrder OrderInfo = (new ServiceSalesOrder(_dbContext)).GetSalesOrderDBInfoByID(model.SOURCE_ENTITY_ID);
                            strCaption = string.Format("ORDER: {0} dt. {1}", OrderInfo.SalesOrderNo, OrderInfo.SalesOrderDate.ToString("dd MMM yyyy"));
                            break;

                    }
                    model.HeaderTitle = strCaption;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::GetSchdeuledCallInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public BindingList<MultiSelectListItem> GelAllAssigneesForSchedule(int scheduleID)
        {
            BindingList<MultiSelectListItem> assignedEmployees = new BindingList<MultiSelectListItem>();
            try
            {
                BindingList<MultiSelectListItem> allEmployees = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceMASTERS(_dbContext)).GetAllEmployeesMultiSelect());
                List<TBL_MP_CRM_ScheduleCallLogAssignee> assignees = _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == scheduleID).Where(x => x.IsDeleted == false).ToList();
                foreach (TBL_MP_CRM_ScheduleCallLogAssignee item in assignees)
                {
                    MultiSelectListItem selItem = allEmployees.Where(x => x.ID == item.EmployeeID).FirstOrDefault();
                    if (selItem != null) assignedEmployees.Add(selItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::GelAllAssigneesForSchedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return assignedEmployees;
        }
        #endregion

        #region Follow UP
        public async Task<int> AddNewFollowUp(TBL_MP_CRM_ScheduleCallLogFollowUp model, int empID)
        {
            int newID = 0;
            try
            {

                model.CreatedBy = empID;
                model.CreatedDatetime = AppCommon.GetServerDateTime();
                _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Add(model);
                _dbContext.SaveChanges();

                int cnt = (from xx in _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp where xx.ScheduleID == model.ScheduleID select xx).Count();
                model.FollowUpSequence = cnt;
                _dbContext.SaveChanges();

                if (model.FollowUpStatus == FOLLOWUP_STATUS_CLOSE_ID)
                {
                    TBL_MP_CRM_ScheduleCallLog log = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == model.ScheduleID).FirstOrDefault();
                    log.ScheduleStatus = CALL_STATUS_CLOSE_ID;
                    _dbContext.SaveChanges();
                }


                newID = model.FollowUpID;
                this.IsScuccess = await this.SendFollowUpEmail(newID);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::AddNewFollowUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public async Task<bool> UpdateFollowUp(TBL_MP_CRM_ScheduleCallLogFollowUp model, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_ScheduleCallLogFollowUp followup = _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.FollowUpID == model.FollowUpID).FirstOrDefault();
                if (followup != null)
                {
                    followup.FollowUpRemark = model.FollowUpRemark;
                    followup.FollowUpStatus = model.FollowUpStatus;
                    followup.NextFollowupRequired = model.NextFollowupRequired;
                    if ((bool)followup.NextFollowupRequired)
                    {
                        followup.NextFollowupRequired = true;
                        followup.NextFollowUpContactName = model.NextFollowUpContactName;
                        followup.NextFollowUpContactNumber = model.NextFollowUpContactNumber;
                        followup.NextFollowUpEndDatetime = model.NextFollowUpEndDatetime;
                        followup.NextFollowUpLocation = model.NextFollowUpLocation;
                        followup.NextFollowUpRemainder = model.NextFollowUpRemainder;
                        followup.NextFollowUpStartDatetime = model.NextFollowUpStartDatetime;
                        followup.NextFollowUpSubject = model.NextFollowUpSubject;
                    }
                    else
                    {
                        followup.NextFollowupRequired = false;
                        followup.NextFollowUpContactName = "";
                        followup.NextFollowUpContactNumber = "";
                        followup.NextFollowUpEndDatetime = null;
                        followup.NextFollowUpLocation = "";
                        followup.NextFollowUpRemainder = null;
                        followup.NextFollowUpStartDatetime = null;
                        followup.NextFollowUpSubject = "";
                    }

                }
                followup.ReasonClose = model.ReasonClose;
                followup.ModifiedBy = empID;
                followup.ModifiedDatetime = AppCommon.GetServerDateTime();
                _dbContext.SaveChanges();
                if (model.FollowUpStatus == FOLLOWUP_STATUS_CLOSE_ID)
                {
                    TBL_MP_CRM_ScheduleCallLog log = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == model.ScheduleID).FirstOrDefault();
                    log.ScheduleStatus = CALL_STATUS_CLOSE_ID;
                    _dbContext.SaveChanges();
                }
                result = await this.SendFollowUpEmail(model.FollowUpID);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::AddNewFollowUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeletedFollowUp(int FollowUpID, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_ScheduleCallLogFollowUp dbFollowUP = _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.FollowUpID == FollowUpID).FirstOrDefault();
                dbFollowUP.DeleteDateTime = AppCommon.GetServerDateTime();
                dbFollowUP.DeleteBy = empID;
                dbFollowUP.IsDeleted = true;
                // dbFollowUP.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceParties::DeleteParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public async Task<bool> SendFollowUpEmail(int followupID)
        {
            bool result = false;
            string strSubject = string.Empty;
            string strMessage = string.Empty;
            string strMailTo = string.Empty;

            try
            {
                TBL_MP_CRM_ScheduleCallLogFollowUp followup = _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.FollowUpID == followupID).FirstOrDefault();
                if (followup == null) { MessageBox.Show("Unable to locate a valid Followup"); return false; }

                TBL_MP_CRM_ScheduleCallLog schdeule = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == followup.ScheduleID).FirstOrDefault();
                if (schdeule == null) { MessageBox.Show("Unable to locate a valid Schedule for the selected FolowUp"); return false; }

                strSubject = string.Format("FOLLOWUP- {0}", schdeule.Subject);
                strMessage += string.Format("REMARKS\n{0}\n", followup.FollowUpRemark);
                strMessage += string.Format("\nAttended By - {0}", followup.TBL_MP_Master_Employee.EmployeeName);
                strMessage += string.Format("\nStatus - {0}", followup.TBL_MP_Admin_UserList.Admin_UserList_Desc);

                if ((bool)followup.NextFollowupRequired)
                {
                    strMessage += string.Format("\n\nNEXT FOLLOWUP DETAILS\n\n");
                    strMessage += String.Format("{0}\n", followup.NextFollowUpSubject);
                    strMessage += String.Format("Timings: {0} - {1}\n\n", followup.NextFollowUpStartDatetime.Value.ToString("dd MMM yy hh:mmtt"), followup.NextFollowUpEndDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                    strMessage += String.Format("\nParty Name: {0}", schdeule.CustomerName.ToUpper());
                    strMessage += String.Format("\nContact: {0}", followup.NextFollowUpContactName.ToUpper());
                    strMessage += String.Format("\nPhone: {0}", followup.NextFollowUpContactNumber);
                    strMessage += String.Format("\nLocation: {0}\n", followup.NextFollowUpLocation);
                }
                else
                {
                    strMessage += string.Format("\n\nCLIENT INFO.\n");
                    strMessage += String.Format("\nParty Name: {0}", schdeule.CustomerName.ToUpper());
                    strMessage += String.Format("\nContact: {0}", schdeule.ContactPerson);
                    strMessage += String.Format("\nPhone: {0}", schdeule.ContactNumber);
                    strMessage += String.Format("\nLocation: {0}\n", schdeule.Location);
                }

                strMessage += String.Format("\n\nSOURCE INFO:\n");
                switch ((APP_ENTITIES)schdeule.EntityType)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        TBL_MP_CRM_SM_SalesLead lead = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == schdeule.EntityID).FirstOrDefault();
                        if (lead != null)
                        {
                            strMessage += String.Format("\nLead: {0} dt. {1}\n", lead.LeadNo, lead.LeadDate.ToString("dd MMM yyyy"));
                            strMessage += String.Format("\n{0}\n", lead.LeadRequirement);
                        }
                        break;

                }

                List<TBL_MP_CRM_ScheduleCallLogAssignee> lstAssignees = _dbContext.TBL_MP_CRM_ScheduleCallLogAssignee.Where(x => x.ScheduleID == schdeule.ScheduleID).Where(x => x.IsDeleted == false).ToList();
                foreach (TBL_MP_CRM_ScheduleCallLogAssignee ass in lstAssignees)
                {
                    strMailTo += ass.TBL_MP_Master_Employee.EmailAddress + ";";
                }
                string strMailFrom = ServiceEmployee.GetEmployeeEmailByID((int)followup.CreatedBy);
                ServiceEmail mail = new ServiceEmail();
                await mail.SendEmail((int)followup.CreatedBy, strMailFrom, strMailTo, strSubject, strMessage);
                result = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::SendFollowUpEmail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public List<FollowUpListModel> GetAllFollowupsForSchedule(int scheduleID)
        {
            List<FollowUpListModel> list = new List<FollowUpListModel>();
            try
            {
                List<TBL_MP_CRM_ScheduleCallLogFollowUp> dbList = (from xx in _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp where xx.ScheduleID == scheduleID  orderby xx.FollowUpSequence descending select xx).ToList();
                foreach (TBL_MP_CRM_ScheduleCallLogFollowUp item in dbList)
                {
                    FollowUpListModel model = new FollowUpListModel()
                    {
                        FollowUpID = item.FollowUpID,
                        EmployeeID = (int)item.EmployeeID,
                        ScheduleID = (int)item.ScheduleID,
                        StatusID = (int)item.FollowUpStatus,
                    };
                    model.AttendedBy = item.TBL_MP_Master_Employee.EmployeeName;

                    model.FollowUpDescription = string.Format("{0}\nStatus:{2}\n\nCreated:{1}", item.FollowUpRemark, item.FollowUpDateTime.Value.ToString("dd MMMyy hh:mmtt"), item.TBL_MP_Admin_UserList.Admin_UserList_Desc);
                    if (item.ModifiedDatetime != null)
                    {
                        model.FollowUpDescription += string.Format("\nModified: {0}", item.ModifiedDatetime.Value.ToString("dd MMMyy hh:mmtt"));
                    }
                    if ((bool)item.NextFollowupRequired)
                    {
                        model.NextFollowUpDescription = string.Format("{0}\n\nContact:{1} {2}\nLocation: {3}\n\nTimings:{4} - {5}",
                            item.NextFollowUpSubject, item.NextFollowUpContactName, item.NextFollowUpContactNumber, item.NextFollowUpLocation,
                             item.NextFollowUpStartDatetime.Value.ToString("dd MMMyy hh:mmtt"), item.NextFollowUpEndDatetime.Value.ToString("dd MMMyy hh:mmtt")
                            );
                    }
                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::GetAllFollowupsForSchedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public TBL_MP_CRM_ScheduleCallLogFollowUp GetFollowUpDBItembyFollowUpID(int followupID)
        {
            TBL_MP_CRM_ScheduleCallLogFollowUp model = null;
            try
            {
                model = _dbContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.FollowUpID == followupID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetFollowUpDBItembyFollowUpID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int GetLatestFollowUpIDForSchdeuleCall(int schdeuleID)
        {
            int followUpID = 0;
            try
            {
                string strSQL = string.Format("select top 1 Followupid from TBL_MP_CRM_ScheduleCallLogFollowUp where ScheduleID = {0} order by FollowUpSequence desc", schdeuleID);
                followUpID = _dbContext.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceScheduleCallLog::GetLatestFollowUpIdForSchdeuleCall", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return followUpID;
        }
        public bool IsSchdeuleClosed(int schdeuleID)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_ScheduleCallLog model = _dbContext.TBL_MP_CRM_ScheduleCallLog.Where(x => x.ScheduleID == schdeuleID).FirstOrDefault();
                if (model.ScheduleStatus == CALL_STATUS_CLOSE_ID)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion

    }
}

