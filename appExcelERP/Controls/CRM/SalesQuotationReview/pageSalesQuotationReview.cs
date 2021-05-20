using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using appExcelERP.Controls.CommonControls;
using ComponentFactory.Krypton.Navigator;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;

namespace appExcelERP.Controls.CRM.SalesQuotationReview
{
    public partial class pageSalesQuotationReview : UserControl
    {

        public ServiceSalesQuotationReview _service = null;
        public DB_FORM_IDs SelectedTAB { get; set; }
        public int SelectedReviewID { get; set; }
        public int SelectedQuotationID { get; set; }

        BindingList<SelectListItem> _DocumentsList = null;


        ctrlAttachments _ctrlSalesQuotationReviewAttachment = null;
        private void InitializeAttachmentInfoControl()
        {
            _ctrlSalesQuotationReviewAttachment = new ctrlAttachments(APP_ENTITIES.SALES_QUOTATION_REVIEW_SELECT_QUOTATION);
            _ctrlSalesQuotationReviewAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
            tabPageAttachments.Controls.Add(_ctrlSalesQuotationReviewAttachment);
            _ctrlSalesQuotationReviewAttachment.Dock = DockStyle.Fill;
        }


        public pageSalesQuotationReview()
        {
            InitializeComponent();
        }
        private void pageSalesQuotationReview_Load(object sender, EventArgs e)
        {
            try
            {
                SetSalesLeadTabTags();
                SetSalesLeadTabAsPerPermission();
                //if (_ctrlGeneralDetails != null) this.SelectedTAB = (DB_FORM_IDs)tabPageGeneralInfo.Tag;

                // InitLeadStatusDropdown();
                // _SelectedStatus = ((SelectListItem)cboLeadStatuses.Items[0]).ID;
                // splitContainerMain.SplitterDistance = (int)(this.Width * .25);
                // PopulateLeads();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotationReview::pageSalesQuotationReview_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetSalesLeadTabTags()
        {
            try
            {
               tabPageAttachments.Tag = DB_FORM_IDs.SALES_QUOTATION_REVIEW_ATTACHMENTS; 
              

                tabPageAttachments.Visible  = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotationReview::SetSalesLeadTabTags", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSalesLeadTabAsPerPermission()
        {
            try
            {
                foreach (KryptonPage tabSelected in tabREVIEWS.Pages)
                {
                    if (tabSelected.Tag != null)
                    {
                        WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)tabSelected.Tag).FirstOrDefault();
                        if (model != null)
                        {
                            tabSelected.Visible = model.CanView;
                            if (tabSelected.Visible)
                            {
                                switch ((DB_FORM_IDs)model.FormID)
                                {
                                   case DB_FORM_IDs.SALES_QUOTATION_REVIEW_ATTACHMENTS: InitializeAttachmentInfoControl(); break;
                                    
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesLead::SetSalesLeadTabAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
            //bool readOnly = (new ServiceSalesQuotation()).IsQuotationReadOnly(this.SelectedQuotationID);
            //if (readOnly)
            //    btnEditQuotation.Enabled = btnDeleteQuotation.Enabled = btnGenerateRevision.Enabled = ButtonEnabled.False;
            //else
            //    btnEditQuotation.Enabled = btnDeleteQuotation.Enabled = btnGenerateRevision.Enabled = ButtonEnabled.True;

            switch (this.SelectedTAB)
            {
              
                case DB_FORM_IDs.SALES_QUOTATION_REVIEW_ATTACHMENTS:
                    if (_ctrlSalesQuotationReviewAttachment == null) return;
                    _ctrlSalesQuotationReviewAttachment.SelectedEntityID = this.SelectedQuotationID;
                    //_ctrlSalesQuotationReviewAttachment.ReadOnly = readOnly;
                    _ctrlSalesQuotationReviewAttachment.PopulateDocuments();
                    break;
                

            }

        }
        private void btnAddNewQuotationReview_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_QUOTATION_REVIEW_SELECT_QUOTATION);
                frm.SingleSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if(frm.SelectedItems.Count>0)
                    {
                        SelectedQuotationID = frm.SelectedItems[0].ID;

                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesQuotationReview::btnAddNewQuotationReview_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
