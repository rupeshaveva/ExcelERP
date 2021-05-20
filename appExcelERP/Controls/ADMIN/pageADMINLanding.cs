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
using libERP.SERVICES;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.ADMIN
{
    public partial class pageADMINLanding : UserControl
    {
        public KryptonPage tabUserLists { get; set; }
        private PageUserLists _pageUserList = null;

        public KryptonPage tabModules { get; set; }
        private pageModules _pageModules = null;

        public KryptonPage tabRoles { get; set; }
        private pageRoleManager _pageRoles = null;


        public KryptonPage tabUsers { get; set; }
        private PageUserManager _pageUsers = null;

        public KryptonPage tabRestoreAttachments { get; set; }
        private pageDeletedAttachments _pageDeletedAttachments = null;

        public KryptonPage tabCompanyInfo { get; set; }
        private PageCompanyInfo _pageCompanyInfo = null;

        public KryptonPage tabVoucherNoSetup { get; set; }
        private pageVoucherNoSetup _pageVoucherNoSetup = null;

        public KryptonPage tabFinYearSetup { get; set; }
        private PageFinYear _pageFinYear = null;

        public pageADMINLanding()
        {
            InitializeComponent();
            
        }
        private void pageADMINLanding_Load(object sender, EventArgs e)
        {
            try
            {
                SetMenuButtonsTag();
                SetMenuButtonAsPerPermission();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::pageADMINLanding_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void SetMenuButtonsTag()
        {
            try
            {
                toolBtnUserLists.Tag = DB_FORM_IDs.ADMIN_USER_LIST_AN_DEFAULTS;
                toolBtnModules.Tag = DB_FORM_IDs.ADMN_MODULE;
                toolBtnRoles.Tag = DB_FORM_IDs.ADMIN_ROLES;
                toolBtnUsers.Tag = DB_FORM_IDs.APP_USERS;
                toolBtnDeletedAttachments.Tag = DB_FORM_IDs.RESTORE_ATTACHMENT;
                toolBtnVoucherNoSetup.Tag = DB_FORM_IDs.ADMIN_VOUCEHRNO_SETUP;
                toolBtnFinYears.Tag = DB_FORM_IDs.FINANCIAL_YEAR_SETUP;
                toolBtnCompanyInfo.Tag = DB_FORM_IDs.COMPANY_INFO;

                toolBtnUserLists.Enabled =
                toolBtnModules.Enabled =
                toolBtnRoles.Enabled =
                toolBtnUsers.Enabled =
                toolBtnDeletedAttachments.Enabled =
                toolBtnCompanyInfo.Enabled =
                toolBtnFinYears.Enabled = false;


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetMenuButtonAsPerPermission()
        {
            try
            {
                foreach (ToolStripItem btnMenu in toolStripAdminMenu.Items)
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
                MessageBox.Show(errMessage, "pageADMINLanding::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AdminMenuButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DB_FORM_IDs formID = (DB_FORM_IDs)((ToolStripButton)sender).Tag;
                switch (formID)
                {
                    case DB_FORM_IDs.ADMIN_USER_LIST_AN_DEFAULTS:
                        if (tabUserLists == null)
                        {
                            tabUserLists = new KryptonPage() { Text = "ADMIN/MASTER Userlists", Name = "UserLists" };
                            tabADMIN.Pages.Add(tabUserLists);
                            _pageUserList = new PageUserLists();
                            tabUserLists.Controls.Add(_pageUserList);
                            _pageUserList.Dock = DockStyle.Fill;
                            tabUserLists.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabUserLists;
                        break;
                    case DB_FORM_IDs.ADMN_MODULE:
                        if (tabModules == null)
                        {
                            tabModules = new KryptonPage() { Text = "Manage App Modules", Name = "manageAppModules" };
                            tabADMIN.Pages.Add(tabModules);
                            _pageModules = new pageModules();
                            tabModules.Controls.Add(_pageModules);
                            _pageModules.Dock = DockStyle.Fill;
                            tabModules.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabModules;
                        break;
                    case DB_FORM_IDs.ADMIN_ROLES:
                        if (tabRoles == null)
                        {
                            tabRoles = new KryptonPage() { Text = "Manage Roles/Access Rights", Name = "manageRoles" };
                            tabADMIN.Pages.Add(tabRoles);
                            _pageRoles = new pageRoleManager();
                            tabRoles.Controls.Add(_pageRoles);
                            _pageRoles.Dock = DockStyle.Fill;
                            tabRoles.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabRoles;
                        break;
                    case DB_FORM_IDs.APP_USERS:
                        if (tabUsers == null)
                        {
                            tabUsers = new KryptonPage() { Text = "Manage App Users", Name = "manageUsers" };
                            tabADMIN.Pages.Add(tabUsers);
                            _pageUsers = new PageUserManager();
                            tabUsers.Controls.Add(_pageUsers);
                            _pageUsers.Dock = DockStyle.Fill;
                            tabUsers.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabUsers;
                        break;
                    case DB_FORM_IDs.RESTORE_ATTACHMENT:
                        if (tabRestoreAttachments == null)
                        {
                            tabRestoreAttachments = new KryptonPage() { Text = "Deleted Attachments", Name = "DeletedAttachments" };
                            tabADMIN.Pages.Add(tabRestoreAttachments);
                            _pageDeletedAttachments = new pageDeletedAttachments();
                            tabRestoreAttachments.Controls.Add(_pageDeletedAttachments);
                            _pageDeletedAttachments.Dock = DockStyle.Fill;
                            tabRestoreAttachments.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabRestoreAttachments;
                        break;
                    case DB_FORM_IDs.ADMIN_VOUCEHRNO_SETUP:
                        if (tabVoucherNoSetup == null)
                        {
                            tabVoucherNoSetup = new KryptonPage() { Text = "Setup - Voucher Number", Name = "tabVoucherNoSetup" };
                            tabADMIN.Pages.Add(tabVoucherNoSetup);
                            _pageVoucherNoSetup = new pageVoucherNoSetup();
                            tabVoucherNoSetup.Controls.Add(_pageVoucherNoSetup);
                            _pageVoucherNoSetup.Dock = DockStyle.Fill;
                            tabVoucherNoSetup.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabVoucherNoSetup;
                        break;
                    case DB_FORM_IDs.FINANCIAL_YEAR_SETUP:
                        if (tabFinYearSetup == null)
                        {
                            tabFinYearSetup = new KryptonPage() { Text = "Setup - Financial Year", Name = "tabPageFinYear" };
                            tabADMIN.Pages.Add(tabFinYearSetup);
                            _pageFinYear = new PageFinYear();
                            tabFinYearSetup.Controls.Add(_pageFinYear);
                            _pageFinYear.Dock = DockStyle.Fill;
                            tabFinYearSetup.Tag = formID;
                        }
                        tabADMIN.SelectedPage = tabFinYearSetup;
                        break;
                    case DB_FORM_IDs.COMPANY_INFO:
                        if (tabCompanyInfo == null)
                        {
                            tabCompanyInfo = new KryptonPage() { Text = "Company Information", Name = "tabPageCompanyInfo" };
                            tabADMIN.Pages.Add(tabCompanyInfo);
                            _pageCompanyInfo = new PageCompanyInfo();
                            tabCompanyInfo.Controls.Add(_pageCompanyInfo);
                            _pageCompanyInfo.Dock = DockStyle.Fill;
                            tabCompanyInfo.Tag = formID;
                            _pageCompanyInfo.PopulateCompanyInformation();
                        }
                        tabADMIN.SelectedPage = tabCompanyInfo;
                        break;

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::AdminMenuButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }
        private void tabADMIN_CloseAction(object sender, CloseActionEventArgs e)
        {
            try
            {
                if (e.Action == CloseButtonAction.RemovePageAndDispose)
                {
                    DB_FORM_IDs formID = (DB_FORM_IDs)((KryptonPage)e.Item).Tag;
                    switch (formID)
                    {
                        case DB_FORM_IDs.ADMIN_USER_LIST_AN_DEFAULTS: tabUserLists.Controls.Clear(); tabUserLists = null; break;
                        case DB_FORM_IDs.ADMN_MODULE: tabModules.Controls.Clear(); tabModules = null; break;
                        case DB_FORM_IDs.ADMIN_ROLES: tabRoles.Controls.Clear(); tabRoles = null; break;
                        case DB_FORM_IDs.APP_USERS: tabUsers.Controls.Clear(); tabUsers = null; break;
                        case DB_FORM_IDs.RESTORE_ATTACHMENT: tabRestoreAttachments.Controls.Clear(); tabRestoreAttachments = null; break;
                        case DB_FORM_IDs.ADMIN_VOUCEHRNO_SETUP: tabVoucherNoSetup.Controls.Clear(); tabVoucherNoSetup = null; break;
                        case DB_FORM_IDs.COMPANY_INFO: tabCompanyInfo.Controls.Clear(); tabCompanyInfo = null; break;
                        case DB_FORM_IDs.FINANCIAL_YEAR_SETUP: tabFinYearSetup.Controls.Clear(); tabFinYearSetup = null; break;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::tabADMIN_CloseAction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
