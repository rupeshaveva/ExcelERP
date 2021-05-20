
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace libERP.SERVICES.ADMIN
{
    public class ServiceCompanyInfo : DefaultService
    { 
        public ServiceCompanyInfo(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceCompanyInfo()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public CompanyMaster GetCompanyDbInfo()
        {
            CompanyMaster _dbItem = null;
            try
            {
                _dbItem = _dbContext.CompanyMasters.FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCompanyInfo::GetCompanyDbInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _dbItem;
        }
    }
}
