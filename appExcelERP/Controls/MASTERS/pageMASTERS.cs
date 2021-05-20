using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using appExcelERP.Controls.InventoryItemControls;
using appExcelERP.Controls.CRM;
using libERP.MODELS;
using libERP.SERVICES;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.MASTERS
{
    public partial class pageMASTERS : UserControl
    {
        public KryptonPage tabLocations { get; set; }
        private pageLocations _pageLocations = null;

        public KryptonPage tabInventoryItems { get; set; }
        private pageInventoryItems _pageInventoryItems = null;

        public KryptonPage tabCustomers { get; set; }
        private PageParties _pageCustomers = null;

        public KryptonPage tabSupplier { get; set; }
        private PageParties _pageSuppliers = null;

        public KryptonPage tabAgents { get; set; }
        private PageParties _pageagents = null;

        public KryptonPage tabTermAndCondition { get; set; }
        private PageTermsAndConditions _pageTermAndCondition = null;

        public KryptonPage tabBankMaster { get; set; }
        private PageBankMaster _pageBankMaster = null;

         public pageMASTERS()
        {
            InitializeComponent();
            
        }
        private void pageMASTERS_Load(object sender, EventArgs e)
        {
            SetMenuButtonsTag();
            SetMenuButtonAsPerPermission();
        }

        private void SetMenuButtonsTag()
        {
            try
            {
                toolBtnLocations.Tag = DB_FORM_IDs.LOCATION; //LOCATION FORM ID
                toolBtnSuppliers.Tag = DB_FORM_IDs.SUPPLIERS; // SUPPLIER FORM ID
                toolBtnCustomers.Tag = DB_FORM_IDs.CUSTOMERS; // CUSTOMERS FORM ID
                toolBtnAgents.Tag = DB_FORM_IDs.AGENTS; // AGENTS FORM ID
                toolBtnInventoryItems.Tag = DB_FORM_IDs.INVENTORY_ITEMS; //INVENTORY ITEMS FORM ID
                toolBtnTernsAndConditions.Tag = DB_FORM_IDs.TNC_MASTER; //TERMS AND CONDITION FORM ID
                toolBtnBank.Tag = DB_FORM_IDs.BANK_MASTER;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageMASTERS::SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetMenuButtonAsPerPermission()
        {
            try
            {
                foreach (ToolStripItem btnMenu in toolStripMasterMenu.Items)
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
                MessageBox.Show(errMessage, "pageMASTERS::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormOperationbutton_Clicked(object sender, EventArgs e)
        {
            DB_FORM_IDs formID;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (sender.GetType() == typeof(ToolStripButton))
                {
                    ToolStripButton formButton = (ToolStripButton)sender;
                    if (formButton.Tag == null) return;
                    formID = (DB_FORM_IDs)formButton.Tag;

                    switch (formID)
                    {
                        case DB_FORM_IDs.LOCATION: //FORM ID FOR LOCATION MANAGEMENT
                            if (tabLocations == null)
                            {
                                tabLocations = new KryptonPage() { Text = "Manage Locations", Name = "tabPageLocations" };
                                tabMASTERS.Pages.Add(tabLocations);
                                _pageLocations = new pageLocations();
                                _pageLocations.FormOperationID = (DB_FORM_IDs)formButton.Tag;
                                tabLocations.Controls.Add(_pageLocations);
                                _pageLocations.Dock = DockStyle.Fill;
                                tabLocations.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabLocations;
                            break;
                        case DB_FORM_IDs.SUPPLIERS: //FORM ID FOR SUPPLIER MANAGEMENT
                            if (tabSupplier == null)
                            {
                                tabSupplier = new KryptonPage() { Text = "Suppliers", Name = "tabPageSuppliers" };
                                tabMASTERS.Pages.Add(tabSupplier);
                                _pageSuppliers = new PageParties("S");
                                _pageSuppliers.FormOperationID = formID;
                                tabSupplier.Controls.Add(_pageSuppliers);
                                _pageSuppliers.Dock = DockStyle.Fill;
                                tabSupplier.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabSupplier;
                            break;
                        case DB_FORM_IDs.CUSTOMERS: //FORM ID FOR CUSTOMERS
                            if (tabCustomers == null)
                            {
                                tabCustomers = new KryptonPage() { Text = "Customers", Name = "tabPageCustomers" };
                                tabMASTERS.Pages.Add(tabCustomers);
                                _pageCustomers = new PageParties("C");
                                _pageCustomers.FormOperationID = formID;
                                tabCustomers.Controls.Add(_pageCustomers);
                                _pageCustomers.Dock = DockStyle.Fill;
                                tabCustomers.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabCustomers;
                            break;
                        case DB_FORM_IDs.AGENTS: //FORM ID FOR AGENTS
                            if (tabAgents == null)
                            {
                                tabAgents = new KryptonPage() { Text = "Agents", Name = "tabPageSuppliers" };
                                tabMASTERS.Pages.Add(tabAgents);
                                _pageagents = new PageParties("A");
                                _pageagents.FormOperationID = formID;
                                tabAgents.Controls.Add(_pageagents);
                                _pageagents.Dock = DockStyle.Fill;
                                tabAgents.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabAgents;
                            break;
                        case DB_FORM_IDs.INVENTORY_ITEMS: //FORM ID FOR MANAGING INVENTORY ITEMS
                            if (tabInventoryItems == null)
                            {
                                tabInventoryItems = new KryptonPage() { Text = "Inventory Items", Name = "tabPageInventoryItems" };
                                tabMASTERS.Pages.Add(tabInventoryItems);
                                _pageInventoryItems = new pageInventoryItems();
                                _pageInventoryItems.FormOperationID = (DB_FORM_IDs)formButton.Tag;
                                tabInventoryItems.Controls.Add(_pageInventoryItems);
                                _pageInventoryItems.Dock = DockStyle.Fill;
                                tabInventoryItems.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabInventoryItems;
                            break;
                        case DB_FORM_IDs.TNC_MASTER: //FORM ID FOR MANAGING TERMS AND CONDITIONS
                            if (tabTermAndCondition == null)
                            {
                                tabTermAndCondition = new KryptonPage() { Text = "Terms && Conditions", Name = "tabPageTERMS_CONDITION" };
                                tabMASTERS.Pages.Add(tabTermAndCondition);
                                _pageTermAndCondition = new PageTermsAndConditions();
                                _pageTermAndCondition.FormOperationID = (int)formButton.Tag;
                                tabTermAndCondition.Controls.Add(_pageTermAndCondition);
                                _pageTermAndCondition.Dock = DockStyle.Fill;
                                tabTermAndCondition.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabTermAndCondition;
                            break;
                        case DB_FORM_IDs.BANK_MASTER:
                            if (tabBankMaster == null)
                            {
                                tabBankMaster = new KryptonPage() { Text = "Banks", Name = "tabPageBANK_MASTER" };
                                tabMASTERS.Pages.Add(tabBankMaster);
                                _pageBankMaster = new PageBankMaster();
                                //_pageTermAndCondition.FormOperationID = (int)formButton.Tag;
                                tabBankMaster.Controls.Add(_pageBankMaster);
                                _pageBankMaster.Dock = DockStyle.Fill;
                                tabBankMaster.Tag = formID;
                            }
                            tabMASTERS.SelectedPage = tabBankMaster;
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageMASTERS::FormOperationbutton_Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void tabMASTERS_CloseAction(object sender, CloseActionEventArgs e)
        {
            try
            {
                if (e.Action == CloseButtonAction.RemovePageAndDispose)
                {
                    DB_FORM_IDs formID = (DB_FORM_IDs)((KryptonPage)e.Item).Tag;
                    switch (formID)
                    {
                        case DB_FORM_IDs.LOCATION: tabLocations.Controls.Clear(); tabLocations = null; break;
                        case DB_FORM_IDs.SUPPLIERS: tabSupplier.Controls.Clear(); tabSupplier = null; break;
                        case DB_FORM_IDs.CUSTOMERS: tabCustomers.Controls.Clear(); tabCustomers = null; break;
                        case DB_FORM_IDs.AGENTS: tabAgents.Controls.Clear(); tabAgents = null; break;
                        case DB_FORM_IDs.INVENTORY_ITEMS: tabInventoryItems.Controls.Clear(); tabInventoryItems = null; break;
                        case DB_FORM_IDs.TNC_MASTER: tabTermAndCondition.Controls.Clear(); tabTermAndCondition = null; break;
                        case DB_FORM_IDs.BANK_MASTER: tabBankMaster.Controls.Clear(); tabBankMaster = null; break;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageMASTERS::tabMASTERS_CloseAction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
