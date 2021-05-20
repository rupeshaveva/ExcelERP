using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.HR;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using libERP;
using appExcelERP.Controls.HR;
using ComponentFactory.Krypton.Navigator;

namespace appExcelERP.Controls.USER_INFO
{
    public partial class PageUserInfo : UserControl
    {

        public DB_FORM_IDs SelectedTAB { get; set; }

        public KryptonPage tabPageMyPersonalInfo { get; set; }
        private PageMyPersoanlInfo _pagePersonalInfo = null;

        public KryptonPage tabPageMyAttendance { get; set; }
        private ControlEmployeeAttendanceViewer _AttendanceViewer = null;

        public KryptonPage tabPageMyLeaveApplications { get; set; }
        private PageMyLeaves _pageLeaveApplications = null;

        public KryptonPage tabPageMyAdvanceRequests { get; set; }
        private PageMyAdvanceRequests _pageAdvanceRequests = null;

        public KryptonPage tabPageMyLoanRequests { get; set; }
        private PageMyLoanRequest _pageLoanRequests = null;

        public KryptonPage tabPageMyPayslips { get; set; }
        private PageMyPayslips _pageMyPayslips = null;


        public PageUserInfo()
        {
            InitializeComponent();
        }
        private void PageUserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                SetMenuButtonsTag();
                SetMenuButtonAsPerPermission();
                //this.SelectedTAB = DB_FORM_IDs.MYPERSONALINFO;
               // if (_pagePersonalInfo != null) this.SelectedTAB = (DB_FORM_IDs)tabPageMyPersonalInfo.Tag;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::PageUserInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMenuButtonsTag()
        {
            try
            {
                toolBtnPersonalInfo.Tag = DB_FORM_IDs.MYPERSONALINFO;
                toolBtnLeaveApplications.Tag = DB_FORM_IDs.MYLEAVES;
                toolBtnAdvanceRequests.Tag = DB_FORM_IDs.MYADVANCEREQUESTS;
                toolBtnLoanApplications.Tag = DB_FORM_IDs.MYLOANREQUESTS; 
                toolBtnAttendanceViewer.Tag = DB_FORM_IDs.MYATTENDANCE;
                toolBtnPayslipViewer.Tag = DB_FORM_IDs.MYPAYSLIPS;

                toolBtnPersonalInfo.Visible =
                toolBtnLeaveApplications.Visible =
                toolBtnAdvanceRequests.Visible =
                toolBtnLoanApplications.Visible =
                toolBtnAttendanceViewer.Visible = 
                toolBtnPayslipViewer.Visible=false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetMenuButtonAsPerPermission()
        {
            try
            {
                foreach (ToolStripItem btnMenu in toolStripMain.Items)
                {
                    if (btnMenu.GetType() == typeof(ToolStripButton))
                    {
                        if (btnMenu.Tag != null)
                        {
                            WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)btnMenu.Tag).FirstOrDefault();
                            if (model != null)
                            {
                                btnMenu.Visible = model.CanView;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshTabPage()
        {
            try
            {
                switch (this.SelectedTAB)
                {
                    case DB_FORM_IDs.MYPERSONALINFO:
                        if (tabPageMyPersonalInfo == null)
                        {
                            tabPageMyPersonalInfo = new KryptonPage() { Text = "Personal Info", Name = "pagePersonalInfo" };
                            tabMY_INFO.Pages.Add(tabPageMyPersonalInfo);
                            _pagePersonalInfo = new PageMyPersoanlInfo();
                            tabPageMyPersonalInfo.Controls.Add(_pagePersonalInfo);
                            _pagePersonalInfo.Dock = DockStyle.Fill;
                            tabPageMyPersonalInfo.Tag = SelectedTAB;
                            
                        }
                        tabMY_INFO.SelectedPage = tabPageMyPersonalInfo;
                       
                        break;

                    case DB_FORM_IDs.MYLEAVES:
                        if (tabPageMyLeaveApplications == null)
                        {
                            tabPageMyLeaveApplications = new KryptonPage() { Text = "Leave Applications", Name = "pageMyLeaveApplicationc" };
                            tabMY_INFO.Pages.Add(tabPageMyLeaveApplications);
                            _pageLeaveApplications = new PageMyLeaves();
                            tabPageMyLeaveApplications.Controls.Add(_pageLeaveApplications);
                            _pageLeaveApplications.Dock = DockStyle.Fill;
                            tabPageMyLeaveApplications.Tag = SelectedTAB;
                        }
                        tabMY_INFO.SelectedPage = tabPageMyLeaveApplications;
                        _pageLeaveApplications.PopulateLeavesGrid();
                        break;
                    case DB_FORM_IDs.MYADVANCEREQUESTS:
                        if (tabPageMyAdvanceRequests == null)
                        {
                            tabPageMyAdvanceRequests = new KryptonPage() { Text = "Advance Requests", Name = "PageMyAdvanceRequests" };
                            tabMY_INFO.Pages.Add(tabPageMyAdvanceRequests);
                            _pageAdvanceRequests = new PageMyAdvanceRequests();
                            tabPageMyAdvanceRequests.Controls.Add(_pageAdvanceRequests);
                            _pageAdvanceRequests.Dock = DockStyle.Fill;
                            tabPageMyAdvanceRequests.Tag = SelectedTAB;
                        }
                        tabMY_INFO.SelectedPage = tabPageMyAdvanceRequests;
                        _pageAdvanceRequests.PopulateAdvanceRequestGrid();
                        break;

                    case DB_FORM_IDs.MYLOANREQUESTS:
                        if (tabPageMyLoanRequests == null)
                        {
                            tabPageMyLoanRequests = new KryptonPage() { Text = "Loan Applications", Name = "PageMyLoanRequest" };
                            tabMY_INFO.Pages.Add(tabPageMyLoanRequests);
                            _pageLoanRequests = new PageMyLoanRequest();
                            tabPageMyLoanRequests.Controls.Add(_pageLoanRequests);
                            _pageLoanRequests.Dock = DockStyle.Fill;
                            tabPageMyLoanRequests.Tag = SelectedTAB;
                        }
                        tabMY_INFO.SelectedPage = tabPageMyLoanRequests;
                        break;
                    case DB_FORM_IDs.MYATTENDANCE:
                        if (tabPageMyAttendance == null)
                        {
                            tabPageMyAttendance = new KryptonPage() { Text = "Attendance Viewer", Name = "ControlEmployeeAttendanceViewer" };
                            tabMY_INFO.Pages.Add(tabPageMyAttendance);
                            _AttendanceViewer = new ControlEmployeeAttendanceViewer();
                            _AttendanceViewer.AttendanceMonth = AppCommon.GetServerDateTime();
                            _AttendanceViewer.EmployeeID = Program.CURR_USER.EmployeeID;
                            tabPageMyAttendance.Controls.Add(_AttendanceViewer);
                            _AttendanceViewer.Dock = DockStyle.Fill;
                            tabPageMyAttendance.Tag = SelectedTAB;
                        }
                        tabMY_INFO.SelectedPage = tabPageMyAttendance;
                        break;

                    case DB_FORM_IDs.MYPAYSLIPS:
                        if (tabPageMyPayslips == null)
                        {
                            tabPageMyPayslips = new KryptonPage() { Text = "Payslip Viewer", Name = "PageMyPayslips" };
                            tabMY_INFO.Pages.Add(tabPageMyPayslips);
                            _pageMyPayslips = new PageMyPayslips();
                            tabPageMyPayslips.Controls.Add(_pageMyPayslips);
                            _pageMyPayslips.Dock = DockStyle.Fill;
                            tabPageMyPayslips.Tag = SelectedTAB;
                            
                        }
                        tabMY_INFO.SelectedPage = tabPageMyPayslips;
                        break;


                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::RefreshTabPage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HRMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (sender.GetType() == typeof(ToolStripButton))
                {
                    this.SelectedTAB = (DB_FORM_IDs)((ToolStripButton)sender).Tag;
                    RefreshTabPage();
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::HRMenuItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void tabMY_INFO_SelectedPageChanged(object sender, EventArgs e)
        {
            //this.SelectedTAB = (DB_FORM_IDs)((KryptonPage)((KryptonNavigator)sender).SelectedPage).Tag;
            //RefreshTabPage();
        }
        private void tabMY_INFO_CloseAction(object sender, CloseActionEventArgs e)
        {
            try
            {
                if (e.Action == CloseButtonAction.RemovePageAndDispose)
                {
                    DB_FORM_IDs formID = (DB_FORM_IDs)((KryptonPage)e.Item).Tag;
                    switch (formID)
                    {
                        case DB_FORM_IDs.MYPERSONALINFO: tabPageMyPersonalInfo.Controls.Clear(); tabPageMyPersonalInfo = null; break;
                        case DB_FORM_IDs.MYADVANCEREQUESTS: tabPageMyAdvanceRequests.Controls.Clear(); tabPageMyAdvanceRequests = null; break;
                        case DB_FORM_IDs.MYLEAVES: tabPageMyLeaveApplications.Controls.Clear(); tabPageMyLeaveApplications = null; break;
                        case DB_FORM_IDs.MYLOANREQUESTS: tabPageMyLoanRequests.Controls.Clear(); tabPageMyLoanRequests = null; break;
                        case DB_FORM_IDs.MYATTENDANCE: tabPageMyAttendance.Controls.Clear(); tabPageMyAttendance = null; break;
                        case DB_FORM_IDs.MYPAYSLIPS: tabPageMyPayslips.Controls.Clear(); tabPageMyPayslips = null; break;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageUserInfo::tabUserInfo_CloseAction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
