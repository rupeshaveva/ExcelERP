using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP.MODELS;
using libERP;

using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.CRM;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.PMC;

namespace appExcelERP.Forms
{
    public partial class frmGridMultiSelect : Form
    {

        private ServiceUOW _UOM = null;
        
        private APP_ENTITIES SOURCE_ENTITY = APP_ENTITIES.none;
        private int SOURCE_ENTITY_ID = 0;
        private APP_ENTITIES _ENTITY = APP_ENTITIES.none;

        private bool _singleSelect = false;
        public bool SingleSelect { get { return _singleSelect; } set { _singleSelect = value; gridData.MultiSelect = !value; } }

        public BindingList<MultiSelectListItem> Items { get; set; }
        public BindingList<MultiSelectListItem> SelectedItems { get; set; }

        public frmGridMultiSelect(APP_ENTITIES entity, int sourceEntityID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            _ENTITY = entity;
            SOURCE_ENTITY_ID = sourceEntityID;
        }
        public frmGridMultiSelect(APP_ENTITIES entity, APP_ENTITIES sourceEntity,int sourceEntityID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            _ENTITY = entity;
            SOURCE_ENTITY = sourceEntity;
            SOURCE_ENTITY_ID = sourceEntityID;
        }
        public frmGridMultiSelect(APP_ENTITIES entity)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            _ENTITY = entity;
        }

        private void frmGridMultiSelect_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
            Cursor = Cursors.Default;
        }
        public void PopulateDataGrid()
        {
            this.Items = null;
            SelectedItems = null;
            switch (_ENTITY)
            {
                case APP_ENTITIES.AGENTS:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Agents";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.PartiesService.GetAllPartiesMultiselect("A"));
                    break;
                case APP_ENTITIES.EMPLOYEES:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Employees";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>( _UOM.MasterService.GetAllEmployeesMultiSelect());
                    break;
                case APP_ENTITIES.PARTIES:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Parties";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.MasterService.GetAllPartiesMultiSelect());
                    break;
                case APP_ENTITIES.CUSTOMERS:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Customer";
                    this.Items = (new ServiceParties()).GetAllPartiesOfTypeBindingListMultiSelect("C"); ;
                    break;
                case APP_ENTITIES.CONTACTS:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Contacts";
                    switch (this.SOURCE_ENTITY)
                    {
                        case APP_ENTITIES.SALES_LEAD:
                            List<SelectContactModel> lst = _UOM.SalesLeadService.GetContactsForLeadID(this.SOURCE_ENTITY_ID);
                            List<MultiSelectListItem> listContacts = new List<MultiSelectListItem>();
                            foreach (SelectContactModel model in lst)
                            {
                                MultiSelectListItem itm = new MultiSelectListItem() {
                                    ID= model.ContactID,
                                    Description= model.Description1,
                                    EntityType= APP_ENTITIES.CONTACTS
                                };
                                listContacts.Add(itm);
                            }
                            this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(listContacts);
                            break;
                        case APP_ENTITIES.SALES_ENQUIRY:
                            BindingList<SelectListItem> lstContacts = (new ServiceSalesEnquiry()).GetAllContactsForSalesEnquiry(this.SOURCE_ENTITY_ID);
                            this.Items = new BindingList<MultiSelectListItem>();
                            if (lstContacts != null)
                            {
                                foreach (SelectListItem model in lstContacts)
                                {
                                    MultiSelectListItem item = new MultiSelectListItem() { ID = model.ID, EntityType = APP_ENTITIES.CONTACTS, Description = model.Description };
                                    Items.Add(item);
                                }
                            }
                            break;

                    }
                    break;
                case APP_ENTITIES.ASSOCIATES_AND_CONTACTS:
                    switch (this.SOURCE_ENTITY)
                    {
                        case APP_ENTITIES.SALES_LEAD:
                            this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.SalesLeadService.GetAllAssociatesAndContactForLead(this.SOURCE_ENTITY_ID));
                            break;
                        case APP_ENTITIES.SALES_ENQUIRY:
                            this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.SalesEnquiryService.GetAllAssociatesAndContactForEnquiry(this.SOURCE_ENTITY_ID));
                            break;
                    }
                    headerGroupSelection.ValuesPrimary.Heading = "Select Contacts & Employees";
                    break;
                case APP_ENTITIES.SALES_LEAD:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Open Sales Lead";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.SalesLeadService.GetLeadsMulitiSelectionList(Program.LIST_DEFAULTS[(int) APP_DEFAULT_VALUES.LeadStatusOpen].DEFAULT_VALUE).ToList());
                    break;
                case APP_ENTITIES.SALES_LEAD_APPROVED_OPEN:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Open Sales Lead";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.SalesLeadService.GetApprovedOpenLeadsMulitiSelectionList().ToList());
                    break;
                case APP_ENTITIES.BOQ_SERVICES:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Multiple Services";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.MasterService.GetAllServicesMultiSelect());
                    break;
                case APP_ENTITIES.UOM_LIST:
                    headerGroupSelection.ValuesPrimary.Heading = "Select UNIT OF MEASUREMENT";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.MasterService.GetAllUOMsMultiSelect());
                    break;
                case APP_ENTITIES.INVENTORY_ITEMS_LIST:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Multiple Part Numbers";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceInventoryItems()).GetAllInventoryItemsMultiSelect());
                    break;
                case APP_ENTITIES.APPLICATION_MODULES:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Multiple Application Modules";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceModules()).GetActiveModulesMultiSelectionList());
                    break;
                case APP_ENTITIES.MODULES_FORMS:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Multiple Module Operations";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceModules()).GetMultiSelectActiveFormsForModule(this.SOURCE_ENTITY_ID));
                    break;
                case APP_ENTITIES.ROLES:
                    headerGroupSelection.ValuesPrimary.Heading =string .Format("Select {0} Roles ", (_singleSelect)?" a ":" Multiple ");
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceRoles()).GetAllActiveRolesMultiSelect());
                    break;
                case APP_ENTITIES.INVENTORY_ASSEMBLY_ITEMS:
                    headerGroupSelection.ValuesPrimary.Heading = string.Format("Select {0} Child Items", (_singleSelect) ? " a " : " Multiple ");
                    this.Items = (new ServiceInventoryItems()).GetMultiselectInventoryItemListForAssembly(this.SOURCE_ENTITY_ID);
                    break;
                case APP_ENTITIES.SALES_ENQUIRY:
                    headerGroupSelection.ValuesPrimary.Heading = string.Format("Select {0} Sales Enquiry", (_singleSelect) ? " a " : " Multiple ");
                    this.Items = (new ServiceSalesEnquiry()).GetMultiselectSalesEnquiriesList();
                    break;
                case APP_ENTITIES.SALES_ENQUIRY_APPROVED_OPEN:
                    headerGroupSelection.ValuesPrimary.Heading = "Select SALES ENQUIRY";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceSalesEnquiry()).GetApprovedOpenEnquiriesMulitiSelectionList().ToList());
                    break;
                case APP_ENTITIES.SALES_QUOTATION_TERMS_AND_CONDITIONS:
                    headerGroupSelection.ValuesPrimary.Heading = "SALES QUOTATION - TERMS & CONDITIONS";
                    int _temp= Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.TermAndConditionSalesQuotationCategory].DEFAULT_VALUE;
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceTermsAndConditions()).GetAllTermsAndConditionsForCategoryMultiSelectListItem(_temp));
                    break;
                case APP_ENTITIES.SALES_QUOTATION_REVIEW_SELECT_QUOTATION:
                    this.Text = "Select Sales Quotartion for Review";
                    headerGroupSelection.ValuesPrimary.Heading = "SALES QUOTATION";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceSalesQuotationReview()).GetAllQuotationsForSelectintoReview());
                    break;
                case APP_ENTITIES.SALES_ORDER_SELECT_QUOTATION:
                    this.Text = "Select Sales Quotation";
                    headerGroupSelection.ValuesPrimary.Heading = "SALES QUOTATION(s)";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceSalesQuotation()).GetAllApprovedAndOpenSalesQuotations());
                    break;
                case APP_ENTITIES.SALES_ORDER_TERMS_AND_CONDITIONS:
                    headerGroupSelection.ValuesPrimary.Heading = "SALES ORDERS - TERMS & CONDITIONS";
                    int soTNCCategoryID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.TermAndConditionSalesOrderCategory].DEFAULT_VALUE;
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceTermsAndConditions()).GetAllTermsAndConditionsForCategoryMultiSelectListItem(soTNCCategoryID));
                    break;
                case APP_ENTITIES.ALL_PROJECTS:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Source Project";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceProject()).GetAllProjectsForMultipleSelection());
                    break;
                case APP_ENTITIES.ACTIVE_PROJECT:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Source Project/Site";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceProject()).GetAllActiveProjectsForMultipleSelection());
                    break;
                case APP_ENTITIES.SUPPLIERS:
                    headerGroupSelection.ValuesPrimary.Heading = "Select Suppliers";
                    this.Items = AppCommon.ConvertToBindingList<MultiSelectListItem>(_UOM.PartiesService.GetAllPartiesMultiselect("S"));
                    break;
            }

            gridData.DataSource = this.Items;
            gridData.Columns["ID"].Visible = gridData.Columns["Code"].Visible = gridData.Columns["DescriptionToUpper"].Visible = gridData.Columns["EntityType"].Visible = false;
            gridData.Columns["Selected"].Width = (int)(gridData.Width * .1);
            gridData.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            if(this.Items!=null)
                headerGroupSelection.ValuesSecondary.Heading = string.Format("{0} records found.", this.Items.Count);

        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SingleSelect)
                DeselectAll();

            gridData.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridData.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gridData.DataSource = new BindingList<MultiSelectListItem>(Items.Where(p => p.DescriptionToUpper.Contains(txtSearch.Text.ToUpper())).ToList()); ;
        }
        
        private void btnCancelSelection_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSaveSelection_Click(object sender, EventArgs e)
        {
            this.SelectedItems = new BindingList<MultiSelectListItem>();
            foreach (MultiSelectListItem item in this.Items)
            {
                if (item.Selected)
                    SelectedItems.Add(item);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void DeselectAll()
        {
            foreach (DataGridViewRow row in gridData.Rows)
            {
                row.Cells["Selected"].Value = false;
            }
        }

        private void frmGridMultiSelect_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}
