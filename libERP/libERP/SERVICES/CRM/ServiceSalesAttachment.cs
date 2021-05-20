using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace libERP.SERVICES.CRM
{
    public class ServiceSalesAttachment: DefaultService
    {
        public ServiceSalesAttachment(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
         public List<TBL_MP_CRM_SM_DocumentHistory> GetDocumentHistory(int attachmentID, APP_ENTITIES entity)
        {
            return _dbContext.TBL_MP_CRM_SM_DocumentHistory
                .Where(x => x.AttachmentID == attachmentID)
                .Where(x => x.EntityType == (int)entity)
                .OrderByDescending(x=>x.CreateDatetime)
                .ToList();
        }
    }
}
