using libERP.SERVICES.ADMIN;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES
{
    public class ServiceUOW
    {
        private EXCEL_ERP_TESTEntities _dbContext = null;
        public EXCEL_ERP_TESTEntities AppDBContext { get { return _dbContext; } }
        public ServiceUOW(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceUOW()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public void RefreshDatabase()
        {
            try
            {
                _dbContext = new EXCEL_ERP_TESTEntities();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "appWorkUnit::RefreshDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //ServiceLogin
        private ServiceUsers _LoginService = null;
        public ServiceUsers LoginService { get { if (_LoginService == null) _LoginService = new ServiceUsers(_dbContext); return _LoginService; } }


        private ServiceMASTERS _MasterService = null;
        public ServiceMASTERS MasterService { get { if (_MasterService == null) _MasterService = new ServiceMASTERS(_dbContext); return _MasterService; } }

        private ServiceEmployee _EmployeeService = null;
        public ServiceEmployee EmployeeService { get { if (_EmployeeService == null) _EmployeeService = new ServiceEmployee(_dbContext); return _EmployeeService; } }

        private ServiceSalesLead _SalesLeadService = null;
        public ServiceSalesLead SalesLeadService { get { if (_SalesLeadService == null) _SalesLeadService = new ServiceSalesLead(_dbContext); return _SalesLeadService; } }

        private ServiceSalesEnquiry _SalesEnquiryService = null;
        public ServiceSalesEnquiry SalesEnquiryService { get { if (_SalesEnquiryService == null) _SalesEnquiryService = new ServiceSalesEnquiry(_dbContext); return _SalesEnquiryService; } }

        private ServiceSalesAttachment _SalesAttachmentService = null;
        public ServiceSalesAttachment SalesAttachmentService { get { if (_SalesAttachmentService == null) _SalesAttachmentService = new ServiceSalesAttachment(_dbContext); return _SalesAttachmentService; } }

        private ServiceFollowUps _FollowupService = null;
        public ServiceFollowUps FollowupService { get { if (_FollowupService == null) _FollowupService = new ServiceFollowUps(_dbContext); return _FollowupService; } }

        private ServiceContacts _ContactService = null;
        public ServiceContacts ContactService { get { if (_ContactService == null) _ContactService = new ServiceContacts(_dbContext); return _ContactService; } }


        private ServiceScheduleCallLog _ScheduleCallLogService = null;
        public ServiceScheduleCallLog ScheduleCallLogService { get { if (_ScheduleCallLogService == null) _ScheduleCallLogService = new ServiceScheduleCallLog(_dbContext); return _ScheduleCallLogService; } }

        private ServiceParties _PartiesService = null;
        public ServiceParties PartiesService { get { if (_PartiesService == null) _PartiesService = new ServiceParties(_dbContext); return _PartiesService; } }

        //ServiceNotification
        private ServiceNotification _NotificationService = null;
        public ServiceNotification NotificationService { get { if (_NotificationService == null) _NotificationService = new ServiceNotification(_dbContext); return _NotificationService; } }
    }
}
