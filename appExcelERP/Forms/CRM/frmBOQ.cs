using appExcelERP.Controls.CRM;
using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.CRM.SalesEnquiry
{
    public partial class frmBOQ : Form
    {
        public APP_ENTITIES SelectedEntity { get; set; }
        public int SelectedEntityID { get; set; }

        ControlSalesEnquiryDesignBOQ _ctrlDesignBOQ = null;
        private void InitializeEnquiryBOQInfoControl()
        {

            _ctrlDesignBOQ = new ControlSalesEnquiryDesignBOQ();
            this.Controls.Add(_ctrlDesignBOQ);
            _ctrlDesignBOQ.Dock = DockStyle.Fill;
            _ctrlDesignBOQ.ENTITY = APP_ENTITIES.SALES_ENQUIRY;

        }

        ControlSalesQuotationBOQ _ControlQuotationBOQ = null;
        private void InitializeQuotationBOQInfoControl()
        {
            _ControlQuotationBOQ = new ControlSalesQuotationBOQ();

            this.Controls.Add(_ControlQuotationBOQ);
            _ControlQuotationBOQ.Dock = DockStyle.Fill;
        }

        public frmBOQ()
        {
            InitializeComponent();
        }

        private void frmSalesEnquiryBOQ_Load(object sender, EventArgs e)
        {
            switch(SelectedEntity)
            {
                case APP_ENTITIES.SALES_ENQUIRY:
                    InitializeEnquiryBOQInfoControl();
                    _ctrlDesignBOQ.SalesEnquiryID = this.SelectedEntityID;
                    _ctrlDesignBOQ.ReadOnly = false;
                    _ctrlDesignBOQ.PopulateDesingBOQ();
                    break;
                case APP_ENTITIES.SALES_QUOTATION:
                    InitializeQuotationBOQInfoControl();
                    _ControlQuotationBOQ.SalesQuotationID = this.SelectedEntityID;
                    _ControlQuotationBOQ.ReadOnly = false;
                    _ControlQuotationBOQ.PopulateSalesQuotationBOQ();
                    break;
            }
            
        }
    }
}
