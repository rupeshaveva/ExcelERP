using libERP;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.ADMIN
{
    public class ServiceAppDefaults: DefaultService
    {
        public ServiceAppDefaults(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceAppDefaults()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<APP_DEFAULTS> GetAllApplicationDefaultSettings()
        {
            List < APP_DEFAULTS > lst= new List<APP_DEFAULTS>(); 
            try
            {
                lst = _dbContext.APP_DEFAULTS.ToList();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceAppDefaults::GetAllApplicationDefaultSettings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }




    }
}
