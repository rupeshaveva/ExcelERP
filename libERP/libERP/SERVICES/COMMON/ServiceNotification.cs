

using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace libERP.SERVICES.COMMON
{
    public class ServiceNotification : DefaultService
    {
        public ServiceNotification(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceNotification()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public int GenerateNotificationFor(APP_ENTITIES entity, int selectedID, int empID, string titleText, string bodyText)
        {
            int newNotificationID = 0;
            try
            {
                string notificationURL = string.Empty;
                string notificationTitle = string.Empty;
                string notificatrionBody=string.Empty;
                int notificationType = 0;
                switch (entity)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        TBL_MP_CRM_SM_SalesLead lead = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == selectedID).FirstOrDefault();
                        if (lead != null)
                        {

                            notificationTitle = titleText;
                            notificatrionBody = bodyText;
                            notificationURL = string.Format("../CRM/FrmMP_CRM_SM_SalesLead_AddEdit.aspx?LID={0}", selectedID);
                            notificationType = (int)NOTIFICATION_CATEGORIES.NOTIFICATION_CRM;
                        }
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        TBL_MP_CRM_SM_SalesLead enquiry =_dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == selectedID).FirstOrDefault();
                        if (enquiry != null)
                        {
                            notificationTitle = titleText;
                            notificatrionBody = bodyText;
                            notificationURL = string.Format("../CRM/FrmMP_CRM_SM_SalesLead_AddEdit.aspx?LID={0}", selectedID);
                            notificationType = (int)NOTIFICATION_CATEGORIES.NOTIFICATION_CRM;
                        }
                        break;
                    case APP_ENTITIES.SALES_QUOTATION:
                        TBL_MP_CRM_SM_SalesLead quotation = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == selectedID).FirstOrDefault();
                        if (quotation != null)
                        {
                            notificationTitle = titleText;
                            notificatrionBody = bodyText;
                            notificationType = (int)NOTIFICATION_CATEGORIES.NOTIFICATION_CRM;
                        }
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        TBL_MP_CRM_SM_SalesLead order = _dbContext.TBL_MP_CRM_SM_SalesLead.Where(x => x.PK_SalesLeadID == selectedID).FirstOrDefault();
                        if (order != null)
                        {
                            notificationTitle = titleText;
                            notificatrionBody = bodyText;
                            notificationType = (int)NOTIFICATION_CATEGORIES.NOTIFICATION_CRM;
                        }
                        break;
                    
                }
                //insert this notification in notification table
                TBL_MP_COMMON_Notification model = new TBL_MP_COMMON_Notification();
                model.NotificationTitle = notificationTitle;
                model.NotificationBody = notificatrionBody;
                model.FK_EMPLOYEEID = empID;
                model.URL = notificationURL;
                model.FK_NotificationType = notificationType;

                _dbContext.TBL_MP_COMMON_Notification.Add(model);
                _dbContext.SaveChanges();

                newNotificationID = model.PK_NotificationID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newNotificationID;
        }
         public List<NotificationModel> GetAllAssociationNotifications(int empID)
        {
            List<NotificationModel> lst = new List<NotificationModel>();
            try
            {

                List<TBL_MP_COMMON_Notification> dbNotifications = (from xx in _dbContext.TBL_MP_COMMON_Notification
                                                                    where xx.FK_EMPLOYEEID == empID
                                                                    select xx
                                                                    ).ToList();

                foreach (TBL_MP_COMMON_Notification item in dbNotifications)
                {
                    NotificationModel model = new NotificationModel() { ID = item.PK_NotificationID, Key = item.NotificationType, Title = item.NotificationTitle, Description = item.NotificationBody };
                    lst.Add(model);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceNotification::GetAllAssociationNotifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<NotificationModel> GetAllFollowupsNotifications(int empID)
        {
            List<NotificationModel> lst = new List<NotificationModel>();
            try
            {
                string strSQL = string.Format("EXEC MXD_GET_SCHEDULE_NOTIFICATION_FOR_USER {0}", empID);
                lst = _dbContext.Database.SqlQuery<NotificationModel>(strSQL).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceNotification::GetAllFollowupsNotifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<NotificationModel> GetAllLeaveApprovalNotification(int empId,int finYearID)
        {
            List<NotificationModel> lstNotifications = new List<NotificationModel>();
            try
            {
                List<LeaveApplicationModel> lstLeaves = (new ServiceLeaveApplication()).GetAllLeaveRequestsToAuthority(empId, finYearID).Where(X=>X.ApprovedByID==0).ToList();
                int index = 1;
                foreach (LeaveApplicationModel leave in lstLeaves)
                {
                    NotificationModel model = new NotificationModel();
                    model.Description = string.Format("{0}\n{1}", leave.EmployeeName, leave.LeaveDescription);
                    model.Title =string.Format("Leaves for Approval ({0}/{1})", index++, lstLeaves.Count);
                    model.ID = leave.ApplicationID;
                    lstNotifications.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceNotification::GetAllLeaveApprovalNotification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstNotifications;
        }
    }
}
