using libERP.MODELS;
using libERP.SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Forms;
using System.Threading;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.COMMON;

namespace appExcelERP
{
    public partial class frmMDI : Form
    {
        public bool ShowNotifications { get; set; }

        public frmMDI()
        {
            InitializeComponent();
            SetThemesMenuTags();
            kryptonManager1.GlobalPaletteMode = Program.CURRENT_THEME;
            menuStrip.Hide();
            statusStripFooter.Hide();
            SetMenuButtonsTag();

        }
        private void frmMDI_Load(object sender, EventArgs e)
        {

            this.ShowNotifications = true;
            mnuShowNotifications.Checked = true;
            notifyIcon1.Text = "EXCEL ERP";
            notifyIcon1.Visible = true;
            this.BackgroundImage = global::appExcelERP.Properties.Resources.Excel_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SetMenuButtonsTag();
            frmLogin frm = new frmLogin();
            frm.MANAGER = this.kryptonManager1;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.LoginSuccess)
                {
                    this.Cursor = Cursors.WaitCursor;
                    statusLabelUserName.Text = string.Format("Welcome {0} [{1}]", Program.CURR_USER.UserFullName, Program.CURR_USER.RoleName);
                    statusLabelFinYear.Text = string.Format("{0}", Program.CURR_USER.FinanicalYearText);
                    

                    SetMenuButtonAsPerPermission();
                    statusStripFooter.Show();
                    
                    if (backgroundWorker1.IsBusy != true)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }

                    this.Cursor = Cursors.Default;

                }
            }
            else
                Application.Exit();
        }


        #region UI ENABLE/DISABLE
        private void SetMenuButtonsTag()
        {
            try
            {
                mnuAdmin.Enabled = mnuMasters.Enabled = mnuCRM.Enabled = mnuPURCHASE.Enabled = mnuPROJECT.Enabled = mnuSITE.Enabled = false;
                mnuSTORES.Enabled = mnuQAQC.Enabled = mnuINVOICE.Enabled = mnuACCOUNTS.Enabled = mnuHR.Enabled = false;


                mnuAdmin.Tag = APP_MODULES.ADMIN;
                mnuMasters.Tag = APP_MODULES.MASTERS;
                mnuCRM.Tag = APP_MODULES.CRM;
                mnuPURCHASE.Tag = APP_MODULES.PURCHASE;
                mnuPROJECT.Tag = APP_MODULES.PMC;
                mnuSITE.Tag = APP_MODULES.SITE;
                mnuSTORES.Tag = APP_MODULES.STORES;
                mnuQAQC.Tag = APP_MODULES.QAQC;
                mnuINVOICE.Tag = APP_MODULES.INVOICE;
                mnuACCOUNTS.Tag = APP_MODULES.ACCOUNTS;
                mnuHR.Tag = APP_MODULES.HR;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMDI:SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetMenuButtonAsPerPermission()
        {
            try
            {
                List<SelectListItem> lstModuleAccess = (new ServiceRoles()).GetModulesPermissionForRole(Program.CURR_USER.RoleID);
                foreach (SelectListItem item in lstModuleAccess)
                {
                    if (item.IsActive)
                    {
                        foreach (ToolStripMenuItem moduleMenu in menuStrip.Items)
                        {
                            if (moduleMenu.Tag != null)
                            {
                                if ((APP_MODULES)moduleMenu.Tag == (APP_MODULES)item.ID)
                                    moduleMenu.Enabled = true;
                            }
                        }
                    }

                }
                menuStrip.Show();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMDI::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #region BACKGROUND WORKER MANAGING NOTIFICATIONS AND ALERTS
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int delay = 9990;
            statusLabelTime.Text = AppCommon.GetServerDateTime().ToString();
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            while (!worker.CancellationPending)
            {
                if(Program.CURR_USER!=null)
                { 
                    ServiceNotification _serviceNotofication = new ServiceNotification();
                    List<NotificationModel> lstNotiofication = _serviceNotofication.GetAllAssociationNotifications(Program.CURR_USER.EmployeeID);
                    #region FOLLOWP NOTIFICATIONS
                    List<NotificationModel> lstFollowUps = _serviceNotofication.GetAllFollowupsNotifications(Program.CURR_USER.EmployeeID);
                    foreach (NotificationModel model in lstFollowUps)
                    {
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        //notifyIcon1.Icon = new Icon("global::appExcelERP.Properties.Resources.Excel_logo"); 
                        //notifyIcon1.BalloonTipIcon =(new ToolTipIcon()).  global::appExcelERP.Properties.Resources.Excel_logo;
                        notifyIcon1.BalloonTipText = model.Description;
                        notifyIcon1.BalloonTipTitle = model.Title;
                        notifyIcon1.ShowBalloonTip(delay);
                        Thread.Sleep(delay);
                    }
                    #endregion

                    #region APPROVE PENDING LEAVES NOTIFICATION
                    List<NotificationModel> lstApproveLeaves = _serviceNotofication.GetAllLeaveApprovalNotification(Program.CURR_USER.EmployeeID, Program.CURR_USER.FinYearID);
                    foreach (NotificationModel model in lstApproveLeaves)
                    {
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.Icon = System.Drawing.SystemIcons.Information;
                        notifyIcon1.BalloonTipText = model.Description;
                        notifyIcon1.BalloonTipTitle = model.Title;
                        //notifyIcon1.Text = model.Description;
                        notifyIcon1.ShowBalloonTip(5555);
                        Thread.Sleep(5555);
                                                
                    }
                    #endregion

                }
                
            }
            e.Cancel = true;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion  





        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }


        #region APPLICATION THEMES
        public void SetThemesMenuTags()
        {
            
            List<SelectListItem> items = (new AppCommon()).GetAllThemes();
            mnuOffice2007Black.Tag = items.Where(x => x.Code == "Office2007Black").FirstOrDefault().ID;
            mnuOffice2007Blue.Tag = items.Where(x => x.Code == "Office2007Blue").FirstOrDefault().ID;
            mnuOffice2007Silver.Tag = items.Where(x => x.Code == "Office2007Silver").FirstOrDefault().ID;

            mnuOffice2010Black.Tag = items.Where(x => x.Code == "Office2010Black").FirstOrDefault().ID;
            mnuOffice2010Blue.Tag = items.Where(x => x.Code == "Office2010Blue").FirstOrDefault().ID;
            mnuOffice2010Silver.Tag = items.Where(x => x.Code == "Office2010Silver").FirstOrDefault().ID;

            mnuOffice2013White.Tag = items.Where(x => x.Code == "Office2013White").FirstOrDefault().ID;
            mnuSparkleBlue.Tag = items.Where(x => x.Code == "SparkleBlue").FirstOrDefault().ID;
            mnuSparkleOrange.Tag = items.Where(x => x.Code == "SparkleOrange").FirstOrDefault().ID;
            mnuSparklePurple.Tag = items.Where(x => x.Code == "SparklePurple").FirstOrDefault().ID;



            mnuProfessionalOffice2003.Tag = items.Where(x => x.Code == "ProfessionalOffice2003").FirstOrDefault().ID;
            mnuProfessionalSystem.Tag = items.Where(x => x.Code == "ProfessionalSystem").FirstOrDefault().ID;

        }
        private void ThemeMenu_Clicked(object sender, EventArgs e)
        {
            Program.CURRENT_THEME = kryptonManager1.GlobalPaletteMode = (PaletteModeManager)((ToolStripMenuItem)sender).Tag;
            Program.ColorSelected = kryptonManager1.GlobalPalette.ColorTable.SeparatorLight;
            (new ServiceUsers()).SetUserTheme(Program.CURR_USER.EmployeeID, (int)Program.CURRENT_THEME);

        }
        #endregion

        
        private void statusLabelNotifications_LinkClicked(object sender, EventArgs e)
        {
        }

        private void mnuShowNotifications_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void mnuShowNotifications_CheckStateChanged(object sender, EventArgs e)
        {
            
        }
        private void mnuShowNotifications_Click(object sender, EventArgs e)
        {
            if (mnuShowNotifications.Checked)
                mnuShowNotifications.CheckState = CheckState.Unchecked;
            else
                mnuShowNotifications.CheckState = CheckState.Checked;

            this.ShowNotifications = mnuShowNotifications.Checked;
            if (!this.ShowNotifications)
            {
                if (backgroundWorker1.IsBusy == true) backgroundWorker1.CancelAsync();
            }
            else
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
        }
        private void mnuGenerateParties_Click(object sender, EventArgs e)
        {
            frmGenerateParties frm = new frmGenerateParties();
            frm.ShowDialog();
        }
        private void mnuLoginPassword_Click(object sender, EventArgs e)
        {
            frmSetPassword frm = new frmSetPassword(PASSWORD_TYPE.LOGIN_PASSWORD);
            frm.ShowDialog();
        }
        private void mnuEmailPassword_Click(object sender, EventArgs e)
        {
            frmSetPassword frm = new frmSetPassword(PASSWORD_TYPE.EMAIL_PASSWORD);
            frm.ShowDialog();
        }
        private void frmMDI_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    MainMenuStrip.Visible = !MainMenuStrip.Visible;
                    statusStripFooter.Visible = !statusStripFooter.Visible;
                    break;
            }
        }
        
        private void toolStripLabelNotifications_Click(object sender, EventArgs e)
        {

            frmAlertsAndNotificatrionsView frm = new frmAlertsAndNotificatrionsView();
            frm.ShowDialog();
        }
        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            Application.DoEvents();
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            backgroundWorker1.CancelAsync();
            Application.DoEvents();
            Program.CURR_USER = null;
            frmLogin frm = new frmLogin();
            frm.MANAGER = this.kryptonManager1;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.LoginSuccess)
                {

                    //notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    //notifyIcon1.BalloonTipText = string.Format("Welcome {0}\nHave a Nice Day.", Program.CURR_USER.UserFullName);
                    //notifyIcon1.BalloonTipTitle = "Logon Success";
                    //notifyIcon1.ShowBalloonTip(1000);
                    statusLabelUserName.Text = string.Format("Welcome {0}", Program.CURR_USER.UserFullName);
                    statusLabelFinYear.Text = string.Format("{0}", Program.CURR_USER.FinanicalYearText);
                    TBL_User_Master dbUser = (new ServiceUsers()).GetUserDBModelByEmployeeID(Program.CURR_USER.EmployeeID);
                    if (dbUser != null)
                    {
                        if (dbUser.Theme != null)
                            Program.CURRENT_THEME = kryptonManager1.GlobalPaletteMode = (PaletteModeManager)dbUser.Theme;
                    }
                    statusStripFooter.Show();
                    menuStrip.Show();

                    if (backgroundWorker1.IsBusy != true)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
            else
                Application.Exit();
        }
        
        private void mnuSystemSettings_Click(object sender, EventArgs e)
        {

        }

        #region LOAD MODULE FORMS
        private void mnuAdmin_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmADMIN")
                {
                    formExists = true;
                    childForm.Show();
                    childForm.WindowState = FormWindowState.Maximized;
                }

            }
            if (!formExists)
            {
                frmMODULE frm = new frmMODULE(APP_MODULES.ADMIN);
                frm.Name = "frmADMIN";
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = "ADMIN MANAGEMENT";

                frm.Show();
            }
            Application.DoEvents();
        }
        private void mnuMasters_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmMASTERS")
                {
                    formExists = true;
                    childForm.Show();
                    childForm.WindowState = FormWindowState.Maximized;
                }

            }
            if (!formExists)
            {
                frmMODULE frm = new frmMODULE(APP_MODULES.MASTERS);
                frm.Name = "frmMASTERS";
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = "MASTER MANAGEMENT";
                frm.Show();
            }


            Application.DoEvents();
        }
        private void mnuCRM_Click(object sender, EventArgs e)
        {

            bool formExists = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmCRM")
                {

                    formExists = true;
                    childForm.Show();
                    childForm.WindowState = FormWindowState.Maximized;
                }

            }
            if (!formExists)
            {
                frmMODULE frm = new frmMODULE(APP_MODULES.CRM);
                frm.Name = "frmCRM";
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = "CUSTOMER RELATIONSHIP MANAGEMENT";
                frm.Show();
            }

        }
        private void mnuPROJECT_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    if (childForm.Name == "frmPMC")
                    {
                        formExists = true;
                        childForm.Show();
                        childForm.WindowState = FormWindowState.Maximized;
                        return;
                    }

                }
                if (!formExists)
                {
                    frmMODULE frm = new frmMODULE(APP_MODULES.PMC);
                    frm.Name = "frmPMC";
                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Text = "PROJECT MANAGEMENT";
                    frm.Show();
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMDI::mnuPROJECT_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void mnuHR_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmHR")
                {
                    formExists = true;
                    childForm.Show();
                    childForm.WindowState = FormWindowState.Maximized;
                }

            }
            if (!formExists)
            {
                frmMODULE frm = new frmMODULE(APP_MODULES.HR);
                frm.Name = "frmHR";
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = "HR MANAGEMENT";
                frm.Show();
            }
        }
        #endregion

        private void mnuMyInfo_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    if (childForm.Name == "frmUSER_INFO")
                    {
                        formExists = true;
                        childForm.Show();
                        childForm.WindowState = FormWindowState.Maximized;
                        return;
                    }

                }
                if (!formExists)
                {
                    frmMODULE frm = new frmMODULE(APP_MODULES.USER_INFO);
                    frm.Name = "frmUSER_INFO";
                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Text = "MY INFO";
                    frm.Show();
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMDI::mnuMyInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUserPasswords_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                AppCommon.GeneratePasswordFile();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMDI::mnuUserPasswords_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void mnuColorPreferences_Click(object sender, EventArgs e)
        {
            try
            {
                frmColorPreference frm = new frmColorPreference();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMDI::mnuColorPreferences_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
