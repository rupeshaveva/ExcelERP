using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.Sales.SalesQuotation
{
    public partial class frmSalesQuotationGenerateRevision : Form
    {
        public int previousQuotationID { get; set; }
        public int newEnquiryID { get; set; }

        public frmSalesQuotationGenerateRevision(int QuotationID)
        {
            InitializeComponent();
            this.previousQuotationID = QuotationID;
        }

        public void PopulateEnquiryRevisionsForQuotation()
        {
            try
            {

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmSalesQuotationGenerateRevision::PopulateEnquiryRevisionsForQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
