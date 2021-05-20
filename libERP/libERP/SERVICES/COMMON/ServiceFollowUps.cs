
using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.COMMON
{
    public class ServiceFollowUps: DefaultService 
    {
        public ServiceFollowUps(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceFollowUps()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public List<FollowupModel> GetAllFollowups(APP_ENTITIES entity, int refID)
        {
            List<FollowupModel> lst = new List<FollowupModel>();
            try
            {
                string strRefType = string.Empty;
                switch (entity)
                {
                    case APP_ENTITIES.SALES_QUOTATION: strRefType = "Sales Quotation";  break;
                }
                string strSQL =string.Format("EXEC MXD_FOLLOWUPS '{0}',{1}", strRefType, refID);

                lst = _dbContext.Database.SqlQuery<FollowupModel>(strSQL).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceFollowUps::GetAllFollowups", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lst;
        }
        public TBL_MP_CRM_Followup_Master GetFollowupInfoByFollowUpID(int followupID)
        {
            TBL_MP_CRM_Followup_Master model = _dbContext.TBL_MP_CRM_Followup_Master.Where(x => x.PK_FollowupID == followupID).FirstOrDefault();
            return model;
        }


    }
}
