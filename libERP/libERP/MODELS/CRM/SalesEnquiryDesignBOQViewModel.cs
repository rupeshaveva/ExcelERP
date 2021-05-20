using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
using System.ComponentModel;
using libERP.MODELS.COMMON;

namespace libERP.MODELS.CRM
{
    public class SalesEnquiryDesignBOQViewModel
    {
        public int ENQUIRY_ID { get; set; }
        public int  BOQ_ID { get; set; }
        public string BOQ_NUMBER { get; set; }


        public List<SalesEnquiryDesignBOQSheet> SHEETS { get; set; }
      

        public SalesEnquiryDesignBOQViewModel()
        {
            this.SHEETS = new List<SalesEnquiryDesignBOQSheet>();
            
        }
    }

    public class SalesEnquiryDesignBOQSheet
    {
        public string SheetName { get; set; }
        public string SheetDescription { get; set; }
        public BindingList<EnquiryBOQItem> BOQ_ITEMS { get; set; }
        public BindingList<EnquiryBOQService> BOQ_SERVICES { get; set; }
        public DataTable datatableBOQ { get; set; }
    }

    public class EnquiryBOQItem
    {
        public bool Selected { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
    }
    public class EnquiryBOQService
    {
        public bool Selected { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
    }

    



}
