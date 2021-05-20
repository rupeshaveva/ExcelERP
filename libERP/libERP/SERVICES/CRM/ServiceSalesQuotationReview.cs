
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    public class ServiceSalesQuotationReview: DefaultService
    {
       
        public ServiceSalesQuotationReview(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceSalesQuotationReview() { _dbContext = new EXCEL_ERP_TESTEntities(); }
        public List<MultiSelectListItem> GetAllQuotationsForSelectintoReview()
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {
                string strQuery = "Select PK_QUOTATION_ID from TBL_MP_CRM_SalesQuotation where quotation_no NOT LIKE '%AMMEND%' AND PK_QUOTATION_ID NOT IN(SELECT DISTINCT FK_QUOTATIONID FROM TBL_MP_CRM_SalesQuotation_Review)";
                List<int> lstQuotes = _dbContext.Database.SqlQuery<int>(strQuery).ToList();
                foreach (int quoteID in lstQuotes)
                {
                    TBL_MP_CRM_SalesQuotation dbQuote = _dbContext.TBL_MP_CRM_SalesQuotation.Where(x => x.PK_Quotation_ID == quoteID).FirstOrDefault();
                    if (dbQuote != null)
                    {
                        lst.Add(new MultiSelectListItem()
                        {
                            ID = dbQuote.PK_Quotation_ID,
                            Description = string.Format("{0} dt. {1}\n{2}", dbQuote.Quotation_No, dbQuote.Quotation_Date.ToString("dd MMM yy"), dbQuote.Tbl_MP_Master_Party.PartyName)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationReview::GetAllQuotationsForSelectintoReview", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }





    }
}
