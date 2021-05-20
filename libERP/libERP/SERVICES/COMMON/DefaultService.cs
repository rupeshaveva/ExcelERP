
using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.SERVICES.COMMON
{
    public class DefaultService
    {
        public EXCEL_ERP_TESTEntities _dbContext = null;
        public static char DefaultStringSeperator = '|';
        public static string LOCAL_DATA_PATH = @"D:\EXCEL_ERP_NEW\ERP_LOCAL_DATA\";
        public static string DOCUMENT_ROOT_PATH = @"\\192.168.1.250\new_erp_app\EXCEL_ERP_DOCUMENTS\";


    }
}
