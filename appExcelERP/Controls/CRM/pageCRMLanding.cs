using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using ComponentFactory.Krypton.Navigator;
using libERP.MODELS;
using appExcelERP.Controls.InventoryItemControls;
using appExcelERP.Controls.CRM.SalesOrder;
using appExcelERP.Controls.CRM.SalesQuotationReview;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class pageCRMLanding : UserControl
    {

        
        public CRM_Pages _selectedPage { get; set; }

        //public KryptonPage tabQuestionniar { get; set; }
        //private pageQuestionnaier _pageQuestionnaier = null;
        public KryptonPage tabQuestionnaire { get; set; }
        private pageQuestionnaire _pageQuestionnaire = null;


        public KryptonPage tabSalesLead { get; set; }
        private pageSalesLead _pageSalesLead = null;

        public KryptonPage tabSalesEnquiry { get; set; }
        private pageSalesEnquiry _pageSalesEnquiry = null;

        public KryptonPage tabSalesQuotation { get; set; }
        private pageSalesQuotation _pageSalesQuotation = null;

        public KryptonPage tabQuotationReview { get; set; }
        private pageSalesQuotationReview _pageQuotationReview = null;
        
        public KryptonPage tabProjectChecklist { get; set; }
        //private pageSalesQuotation _pageSalesQuotation = null;


        //public KryptonPage tabSalesOrder { get; set; }
        //private pageSalesOrder _pageSalesOrders = null;

        public KryptonPage tabCustomers { get; set; }
        private PageParties _pageCustomers = null;

        public KryptonPage tabInventoryItems { get; set; }
        private pageInventoryItems _pageInventoryItems = null;

        public KryptonPage tabSalesOrder { get; set; }
        private pageSalesOrder _pageSalesOrder = null;


        public pageCRMLanding()
        {
            InitializeComponent();
            SetMenuButtonsTag();
        }
        private void pageCRMLanding_Load(object sender, EventArgs e)
        {
            SetMenuButtonAsPerPermission();
        }

        private void SetMenuButtonsTag()
        {
            try
            {
                toolBtnQuestionnaire.Tag = DB_FORM_IDs.SALES_QUESTIONNAIRE;
                toolBtnSalesLead.Tag = DB_FORM_IDs.SALES_LEAD; //SALES LEAD FOMR ID
                toolBtnSalesEnquiry.Tag = DB_FORM_IDs.SALES_ENQUIRY; // SALES ENQUIRY FORM ID
                toolBtnCustomers.Tag = DB_FORM_IDs.CUSTOMERS; // CUSTOMERS FORM ID
                toolBtnInventoryItems.Tag = DB_FORM_IDs.INVENTORY_ITEMS; //INVENTORY ITEMS FORM ID
                toolBtnSalesQuotations.Tag = DB_FORM_IDs.SALES_QUOTATION; // SALES QUOTATION FORM ID
                toolBtnSalesOrder.Tag = DB_FORM_IDs.SALES_ORDER; // SALES ORDER
                toolBtnQuotationReview.Tag = DB_FORM_IDs.SALES_QUOTATION_REVIEW;
                toolBtnProjectChecklist.Tag = DB_FORM_IDs.PROJECT_CHECHLIST;

                toolBtnQuestionnaire.Enabled=
                toolBtnSalesLead.Enabled = 
                toolBtnCustomers.Enabled = 
                toolBtnInventoryItems.Enabled = 
                toolBtnSalesEnquiry.Enabled= 
                toolBtnSalesQuotations.Enabled=
                toolBtnQuotationReview.Enabled=
                false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageCRMLanding::SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetMenuButtonAsPerPermission()
        {
            try
            {
                foreach (ToolStripItem btnMenu in toolStripCRMforms.Items)
                {
                    if (btnMenu.GetType() == typeof(ToolStripButton))
                    {
                        if (btnMenu.Tag != null)
                        {
                            WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)btnMenu.Tag).FirstOrDefault();
                            if (model != null)
                            {
                                btnMenu.Enabled = model.CanView;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageCRMLanding::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetButtonTags()
        {
            toolBtnQuestionnaire.Tag = DB_FORM_IDs.SALES_QUESTIONNAIRE;
            toolBtnCustomers.Tag = DB_FORM_IDs.CUSTOMERS;
            toolBtnInventoryItems.Tag = DB_FORM_IDs.INVENTORY_ITEMS;
            
            toolBtnSalesLead.Tag = DB_FORM_IDs.SALES_LEAD;
            toolBtnSalesEnquiry.Tag = DB_FORM_IDs.SALES_ENQUIRY;
            toolBtnSalesQuotations.Tag = DB_FORM_IDs.SALES_QUOTATION;
            toolBtnSalesOrder.Tag = DB_FORM_IDs.SALES_ORDER;

            toolBtnProjectChecklist.Tag = DB_FORM_IDs.PROJECT_CLOSER_CHECKLIST;
            toolBtnQuotationReview.Tag = DB_FORM_IDs.SALES_QUOTATION_REVIEW;
        }

        private void SalesPageSelected(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DB_FORM_IDs formID = (DB_FORM_IDs)((ToolStripButton)sender).Tag;
            switch (formID)
            {
                case DB_FORM_IDs.SALES_QUESTIONNAIRE:
                    if (tabQuestionnaire == null)
                    {
                        tabQuestionnaire = new KryptonPage() { Text = "Sales Questionnaire", Name = "SalesQuestionnaire" };
                        tabCRM.Pages.Add(tabQuestionnaire);
                        _pageQuestionnaire = new pageQuestionnaire();
                        //_pageQuestionnaire.ParentTABControl = tabSalesLead;
                        //_pageQuestionnaire.FormOperationID = (int)formID;
                        tabQuestionnaire.Controls.Add(_pageQuestionnaire);
                        _pageQuestionnaire.Dock = DockStyle.Fill;
                        tabCRM.SelectedPage = tabQuestionnaire;
                        tabQuestionnaire.Tag = formID;
                    }
                    tabCRM.SelectedPage = tabQuestionnaire;
                    break;
                case DB_FORM_IDs.PROJECT_CHECHLIST:
                    if(tabProjectChecklist==null)
                    { 
                        tabProjectChecklist = new KryptonPage() { Text="Manage Checklists", Name= "pageProjectChecklist" };
                        tabCRM.Pages.Add(tabProjectChecklist);
                        pageProjectChecklist ctrlProjectchecklist = new pageProjectChecklist();
                        tabProjectChecklist.Controls.Add(ctrlProjectchecklist);
                        ctrlProjectchecklist.Dock = DockStyle.Fill;
                        tabProjectChecklist.Tag = formID;
                    }
                    tabCRM.SelectedPage = tabProjectChecklist;
                    break;
                case DB_FORM_IDs.CUSTOMERS: 
                    if(tabCustomers == null)
                    { 
                        tabCustomers = new KryptonPage() { Text = "Customer Info", Name = "Customers" };
                        tabCRM.Pages.Add(tabCustomers);
                        _pageCustomers = new PageParties("C");
                        _pageCustomers.FormOperationID = (DB_FORM_IDs)formID;
                        _pageCustomers.SelectionChanged += _pageCustomers_SelectionChanged;
                        tabCustomers.Controls.Add(_pageCustomers);
                        _pageCustomers.Dock = DockStyle.Fill;
                        tabCustomers.Tag = formID;
                    }
                    tabCRM.SelectedPage = tabCustomers;
                    break;
                case DB_FORM_IDs.INVENTORY_ITEMS:
                    if (tabInventoryItems == null)
                    {
                        tabInventoryItems = new KryptonPage() { Text = "Inventory Items", Name = "InventoryItems" };
                        tabCRM.Pages.Add(tabInventoryItems);
                        _pageInventoryItems = new pageInventoryItems();
                        _pageInventoryItems.FormOperationID = (DB_FORM_IDs)formID;
                        //_pageInventoryItems.SelectionChanged += _pageCustomers_SelectionChanged;
                        tabInventoryItems.Controls.Add(_pageInventoryItems);
                        _pageInventoryItems.Dock = DockStyle.Fill;
                        tabInventoryItems.Tag = formID;
                    }
                    tabCRM.SelectedPage = tabInventoryItems;
                    break;
                case DB_FORM_IDs.SALES_LEAD:
                    tabSalesLead = new KryptonPage() { Text = "Sales Leads", Name = "SalesLead" };
                    tabCRM.Pages.Add(tabSalesLead);
                    _pageSalesLead = new pageSalesLead();
                    _pageSalesLead.ParentTABControl = tabSalesLead;
                    _pageSalesLead.FormOperationID = (int)formID;
                    tabSalesLead.Controls.Add(_pageSalesLead);
                    _pageSalesLead.Dock = DockStyle.Fill;
                    tabCRM.SelectedPage = tabSalesLead;
                    tabSalesLead.Tag = formID;
                    break;
                case DB_FORM_IDs.SALES_ENQUIRY :
                    tabSalesEnquiry = new KryptonPage() { Text = "Sales Enquiry", Name = "SalesEnquiry" };
                    tabCRM.Pages.Add(tabSalesEnquiry);
                    _pageSalesEnquiry = new pageSalesEnquiry();
                    _pageSalesEnquiry.FormOperationID = (int)formID;
                    _pageSalesEnquiry.ParentTABControl = tabSalesEnquiry;
                    tabSalesEnquiry.Controls.Add(_pageSalesEnquiry);
                    _pageSalesEnquiry.Dock = DockStyle.Fill;
                    tabCRM.SelectedPage = tabSalesEnquiry;
                    tabSalesEnquiry.Tag = formID;
                    break;
                case DB_FORM_IDs.SALES_QUOTATION: 
                    tabSalesQuotation = new KryptonPage() { Text = "Sales Quotation", Name = "SalesQuotation" };
                    tabCRM.Pages.Add(tabSalesQuotation);
                    _pageSalesQuotation = new pageSalesQuotation();
                    _pageSalesQuotation.FormOperationID = (int)formID;
                    _pageSalesQuotation.ParentTABControl = tabSalesQuotation;
                    tabSalesQuotation.Controls.Add(_pageSalesQuotation);
                    _pageSalesQuotation.Dock = DockStyle.Fill;
                    tabCRM.SelectedPage = tabSalesQuotation;
                    tabSalesQuotation.Tag = formID;
                    break;
                case DB_FORM_IDs.SALES_QUOTATION_REVIEW:
                    if(tabQuotationReview==null)
                    {
                        tabQuotationReview = new KryptonPage() { Text = "Quotation Review", Name = "tabPageQuotationReview" };
                        tabCRM.Pages.Add(tabQuotationReview);
                        _pageQuotationReview = new pageSalesQuotationReview();
                        tabQuotationReview.Controls.Add(_pageQuotationReview);
                        _pageQuotationReview.Dock = DockStyle.Fill;
                        tabQuotationReview.Tag = formID;
                    }
                    tabCRM.SelectedPage = tabQuotationReview;
                    break;
                case DB_FORM_IDs.SALES_ORDER:
                    tabSalesOrder = new KryptonPage() { Text="Sales Order" };
                    tabCRM.Pages.Add(tabSalesOrder);
                    tabCRM.SelectedPage = tabSalesOrder;
                    _pageSalesOrder = new pageSalesOrder();
                    tabSalesOrder.Controls.Add(_pageSalesOrder);
                    _pageSalesOrder.Dock = DockStyle.Fill;
                    tabSalesOrder.Tag = formID;
                    break;

            }

            Cursor.Current = Cursors.Default;

        }
                
        private void _pageSalesOrders_KeyUp(object sender, KeyEventArgs e)
        {
           throw new NotImplementedException();
        }
        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
        
        #region
        private void _pageSalesLead_SelectionChanged(object sender, EventArguementModel e)
        {
            tabSalesLead.Text = string.Format("{0}", e.Message);
            Application.DoEvents();
        }
        private void _pageCustomers_SelectionChanged(object sender, EventArguementModel e)
        {
            tabCustomers.Text = string.Format("{0}", e.Message);
        }
        private void _pageSalesEnquiry_SelectionChanged(object sender, EventArguementModel e)
        {
            tabSalesEnquiry.Text = string.Format("{0}", e.Message);
        }
        private void _pageSalesQuotation_SelectionChanged(object sender, EventArguementModel e)
        {
            tabSalesQuotation.Text = string.Format("{0}", e.Message);
        }
        private void _pageSalesOrders_SelectionChanged(object sender, EventArguementModel e)
        {
            //tabSalesOrder.Text = string.Format("SO- {0}", e.Message);
        }
        #endregion

        private void tabCRM_CloseAction(object sender, CloseActionEventArgs e)
        {
            try
            {
                if (e.Action == CloseButtonAction.RemovePageAndDispose)
                {
                    DB_FORM_IDs formID = (DB_FORM_IDs)((KryptonPage)e.Item).Tag;
                    switch (formID)
                    {
                        case DB_FORM_IDs.SALES_QUESTIONNAIRE: tabQuestionnaire.Controls.Clear(); tabQuestionnaire = null; break;
                        case DB_FORM_IDs.CUSTOMERS: tabCustomers.Controls.Clear(); tabCustomers = null; break;
                        case DB_FORM_IDs.INVENTORY_ITEMS: tabInventoryItems.Controls.Clear(); tabInventoryItems = null; break;
                        case DB_FORM_IDs.PROJECT_CLOSER_CHECKLIST: tabProjectChecklist.Controls.Clear(); tabProjectChecklist = null; break;
                        case DB_FORM_IDs.SALES_QUOTATION_REVIEW: tabQuotationReview.Controls.Clear(); tabQuotationReview = null; break;
                        case DB_FORM_IDs.SALES_LEAD: tabSalesLead.Controls.Clear(); tabSalesLead = null; break;
                        case DB_FORM_IDs.SALES_ENQUIRY: tabSalesEnquiry.Controls.Clear(); tabSalesEnquiry = null; break;
                        case DB_FORM_IDs.SALES_QUOTATION: tabSalesQuotation.Controls.Clear(); tabSalesQuotation = null; break;
                        case DB_FORM_IDs.SALES_ORDER: tabSalesOrder.Controls.Clear(); tabSalesOrder = null; break;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageCRMLanding::tabCRM_CloseAction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
