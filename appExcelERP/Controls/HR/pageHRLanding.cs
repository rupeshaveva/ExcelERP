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
using appExcelERP.Controls.HR.EmployeeSalary;
using appExcelERP.Controls.HR.Attendance;

namespace appExcelERP.Controls.HR
{
    public partial class pageHRLanding : UserControl
    {
        public DB_FORM_IDs SelectedTAB { get; set; }

        public KryptonPage tabPageEmployees { get; set; }
        private pageEmployees _pageEmployees = null;

        public KryptonPage tabPageSalaryHead { get; set; }
        private PageSalaryHeads _pageSalaryHeads = null;

        public KryptonPage tabPageConfigureCTC { get; set; }
        private PageCTCConfiguration _pageConfigureCTC = null;

        public KryptonPage tabPageManageLeave { get; set; }
        private PageHR_LeavesConfiguration _pageManageLeave = null;

        public KryptonPage tabPageLeavesRegister { get; set; }
        private PageLeavesRegister _pageLeavesRegister = null;

        public KryptonPage tabPageAdvanceRegister { get; set; }
        private PageAdvanceRequestsRegister _pageAdvanceRegister = null;

        public KryptonPage tabPageLoanRequestRegister { get; set; }
        private PageLoanRequestRegister _pageLoanRequestRegister = null;

        public KryptonPage tabPageLoanDisbursementRegister { get; set; }
        private PageLoanDisbursement _pageLoanDisbursementRegister = null;


        public KryptonPage tabPageManualAtendanceEntry { get; set; }
        private PageManualAttendance _pageManualAttendance = null;

        public KryptonPage tabPageImportAttendance { get; set; }
        private PageImportAttendance _pageImportAttendance = null;

        public KryptonPage tabPageAttendanceChartView { get; set; }
        private PageAttendanceChartView _pageAttendancechartview = null;

        public KryptonPage tabPageAttendanceGridView { get; set; }
        private PageAttendanceGridView _pageAttendanceGridView = null;

        public KryptonPage tabPageAttendanceSummaryView { get; set; }
        private PageAttendanceSummaryView _pageAttendanceSummaryView = null;



        public KryptonPage tabPageOrganizationChart { get; set; }
        private PageOrganizationChart _pageOrganizationChart = null;

        public KryptonPage tabPageHolidaysAndWeekOffs { get; set; }
        private PageHolidayAndWeekOffs _pageHolidaysAndWeekOffs = null;


        public KryptonPage tabPageGeneratePayslips { get; set; }
        private PageGeneratePayslips _pageGeneratePayslips = null;

        public KryptonPage tabPageViewPayslips { get; set; }
        private PageViewPayslips _pageViewPayslips = null;


        public pageHRLanding()
        {
            InitializeComponent();
        }
        private void pageHRLanding_Load(object sender, EventArgs e)
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
                MessageBox.Show(errMessage, "pageHRLanding::pageHRLanding_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void SetMenuButtonsTag()
        {
            try
            {
                toolBtnEmployees.Tag = DB_FORM_IDs.EMPLOYEE; //EMPLOYEE FORM ID
                toolBtnSalaryHead.Tag = DB_FORM_IDs.SALARY_HEADS;
                toolBtnConfigureCTC.Tag = DB_FORM_IDs.CTC_CONFIGURATION;
                toolBtnLeaveMaster.Tag = DB_FORM_IDs.HR_LEAVE_CONFIGURATION;
                toolBtnLeaveResgister.Tag = DB_FORM_IDs.LEAVE_APPLICATIONS;
                toolBtnOrgChart.Tag = DB_FORM_IDs.ORGANIZATION_CHART;
                toolBtnHolidayCalender.Tag = DB_FORM_IDs.HOLIDAYS_AND_WEEKOFFS;
                toolBtnAdvanceRequestsReister.Tag = DB_FORM_IDs.ADVANCE_REQUEST;
                toolBtnLoanRequestsReister.Tag = DB_FORM_IDs.LOAN_REQUEST;
                toolBtnloanDisbursementRegister.Tag = DB_FORM_IDs.LOAN_DISBURSEMENT;

                mnuPayRoll.Tag= DB_FORM_IDs.PAYROLL;
                toolBtnGeneratePayslips.Tag = DB_FORM_IDs.PAYROLL_GENERATE;
                toolBtnViewPayslips.Tag = DB_FORM_IDs.PAYROLL_VIEW;

                toolBtnImportAttendance.Tag = DB_FORM_IDs.ATTENDANCE_IMPORT;
                toolBtnAttendanceEntry.Tag = DB_FORM_IDs.ATTENDANCE_ENTRY_MANUAL;
                toolBtnAttendanceChartView.Tag = DB_FORM_IDs.ATTENDANCE_CHART_VIEW;
                toolBtnAttendanceGridView.Tag = DB_FORM_IDs.ATTENDANCE_GRID_VIEW;
                toolBtnAttendanceSummaryView.Tag = DB_FORM_IDs.ATTENDANCE_SUMMARY_VIEW;



                toolBtnSalaryHead.Visible =
                toolBtnEmployees.Visible =
                toolBtnLeaveMaster.Visible =
                toolBtnLeaveResgister.Visible=
                toolBtnConfigureCTC.Visible=
                toolBtnAttendanceEntry.Visible=
                toolBtnAttendanceChartView.Visible=
                toolBtnOrgChart.Visible= 
                toolBtnHolidayCalender.Visible=
                toolBtnAdvanceRequestsReister.Visible=
                toolBtnLoanRequestsReister.Visible =
                toolBtnAttendanceGridView.Visible=
                toolBtnImportAttendance.Visible= 
                toolBtnAttendanceSummaryView.Visible=
                toolBtnGeneratePayslips.Visible=false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageHRLanding::SetMenuButtonsTag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetMenuButtonAsPerPermission()
        {
            try
            {
                foreach (ToolStripItem btnMenu in toolStripHRMenu.Items)
                {
                    if (btnMenu.GetType() == typeof(ToolStripMenuItem))
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
                    if (btnMenu.GetType() == typeof(ToolStripDropDownButton))
                    {
                        ToolStripDropDownButton dropDownBtn = (ToolStripDropDownButton)btnMenu;
                        foreach (ToolStripItem item in dropDownBtn.DropDownItems)
                        {
                            if (item.Tag != null)
                            {
                                WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)item.Tag).FirstOrDefault();
                                if (model != null)
                                {
                                    ((ToolStripMenuItem)item).Visible = model.CanView;
                                }
                            }
                        }
                    }
                }
                mnuAttendance.Visible = mnuAttendance.Enabled= true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageHRLanding::SetMenuButtonAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HRMenuButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                DB_FORM_IDs formID = DB_FORM_IDs.NONE;
                if (sender.GetType() == typeof(ToolStripButton)) formID = (DB_FORM_IDs)((ToolStripButton)sender).Tag;
                if (sender.GetType() == typeof(ToolStripMenuItem)) formID = (DB_FORM_IDs)((ToolStripMenuItem)sender).Tag;

                switch (formID)
                {
                    case DB_FORM_IDs.SALARY_HEADS:
                        if (tabPageSalaryHead == null)
                        {
                            tabPageSalaryHead = new KryptonPage() { Text = "Salary Heads Master", Name = "pageSalaryHeadsMaster" };
                            tabHR.Pages.Add(tabPageSalaryHead);
                            _pageSalaryHeads = new PageSalaryHeads();
                            tabPageSalaryHead.Controls.Add(_pageSalaryHeads);
                            _pageSalaryHeads.Dock = DockStyle.Fill;
                            tabPageSalaryHead.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageSalaryHead;
                        break;
                    case DB_FORM_IDs.EMPLOYEE:
                        if (tabPageEmployees == null)
                        {
                            tabPageEmployees = new KryptonPage() { Text = "Employee", Name = "pageEmployeeMaster" };
                            tabHR.Pages.Add(tabPageEmployees);
                            _pageEmployees = new pageEmployees();
                            tabPageEmployees.Controls.Add(_pageEmployees);
                            _pageEmployees.Dock = DockStyle.Fill;
                            tabPageEmployees.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageEmployees;
                        break;
                    case DB_FORM_IDs.CTC_CONFIGURATION:
                        if (tabPageConfigureCTC == null)
                        {
                            tabPageConfigureCTC = new KryptonPage() { Text = "CTC Designationwise", Name = "pageConfigureCTC" };
                            tabHR.Pages.Add(tabPageConfigureCTC);
                            _pageConfigureCTC = new PageCTCConfiguration();
                            tabPageConfigureCTC.Controls.Add(_pageConfigureCTC);
                            _pageConfigureCTC.Dock = DockStyle.Fill;
                            tabPageConfigureCTC.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageConfigureCTC;
                        break;
                    case DB_FORM_IDs.HR_LEAVE_CONFIGURATION:
                        if (tabPageManageLeave == null)
                        {
                            tabPageManageLeave = new KryptonPage() { Text = "Manage/Configure Leave(s)", Name = "PageHR_ManageLeaves" };
                            tabHR.Pages.Add(tabPageManageLeave);
                            _pageManageLeave = new PageHR_LeavesConfiguration();
                            tabPageManageLeave.Controls.Add(_pageManageLeave);
                            _pageManageLeave.Dock = DockStyle.Fill;
                            tabPageManageLeave.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageManageLeave;
                        break;
                    case DB_FORM_IDs.LEAVE_APPLICATIONS:
                        if (tabPageLeavesRegister == null)
                        {
                            tabPageLeavesRegister = new KryptonPage() { Text = "Leaves Register", Name = "tabPageLeavesRegister" };
                            tabHR.Pages.Add(tabPageLeavesRegister);
                            _pageLeavesRegister = new PageLeavesRegister();
                            tabPageLeavesRegister.Controls.Add(_pageLeavesRegister);
                            _pageLeavesRegister.Dock = DockStyle.Fill;
                            tabPageLeavesRegister.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageLeavesRegister;
                        break;
                    case DB_FORM_IDs.ADVANCE_REQUEST:
                        if (tabPageAdvanceRegister == null)
                        {
                            tabPageAdvanceRegister = new KryptonPage() { Text = "Advance Requests Register", Name = "tabPageAdvanceRequest" };
                            tabHR.Pages.Add(tabPageAdvanceRegister);
                            _pageAdvanceRegister = new PageAdvanceRequestsRegister();
                            tabPageAdvanceRegister.Controls.Add(_pageAdvanceRegister);
                            _pageAdvanceRegister.Dock = DockStyle.Fill;
                            tabPageAdvanceRegister.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageAdvanceRegister;
                        break;
                    case DB_FORM_IDs.LOAN_REQUEST:
                        if (tabPageLoanRequestRegister == null)
                        {
                            tabPageLoanRequestRegister = new KryptonPage() { Text = "Loan Requests", Name = "tabPageLoanRequestRegister" };
                            tabHR.Pages.Add(tabPageLoanRequestRegister);
                            _pageLoanRequestRegister = new PageLoanRequestRegister();
                            tabPageLoanRequestRegister.Controls.Add(_pageLoanRequestRegister);
                            _pageLoanRequestRegister.Dock = DockStyle.Fill;
                            tabPageLoanRequestRegister.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageLoanRequestRegister;
                        break;
                    case DB_FORM_IDs.LOAN_DISBURSEMENT:
                        if (tabPageLoanDisbursementRegister == null)
                        {
                            tabPageLoanDisbursementRegister = new KryptonPage() { Text = "Loan Disbursement", Name = "tabPageLoanDisbursementRegister" };
                            tabHR.Pages.Add(tabPageLoanDisbursementRegister);
                            _pageLoanDisbursementRegister = new PageLoanDisbursement();
                            tabPageLoanDisbursementRegister.Controls.Add(_pageLoanDisbursementRegister);
                            _pageLoanDisbursementRegister.Dock = DockStyle.Fill;
                            tabPageLoanDisbursementRegister.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageLoanDisbursementRegister;
                        break;
                    case DB_FORM_IDs.ATTENDANCE_ENTRY_MANUAL:
                        if (tabPageManualAtendanceEntry == null)
                        {
                            tabPageManualAtendanceEntry = new KryptonPage() { Text = "Attendance Entry -Manual", Name = "PageManualAttendance" };
                            tabHR.Pages.Add(tabPageManualAtendanceEntry);
                            _pageManualAttendance = new PageManualAttendance();
                            tabPageManualAtendanceEntry.Controls.Add(_pageManualAttendance);
                            _pageManualAttendance.Dock = DockStyle.Fill;
                            tabPageManualAtendanceEntry.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageManualAtendanceEntry;
                        break;
                    case DB_FORM_IDs.ATTENDANCE_IMPORT:
                        if (tabPageImportAttendance == null)
                        {
                            tabPageImportAttendance = new KryptonPage() { Text = "Attendance Import", Name = "PageImportAttendance" };
                            tabHR.Pages.Add(tabPageImportAttendance);
                            _pageImportAttendance = new PageImportAttendance();
                            tabPageImportAttendance.Controls.Add(_pageImportAttendance);
                            _pageImportAttendance.Dock = DockStyle.Fill;
                            tabPageImportAttendance.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageImportAttendance;
                        break;
                    case DB_FORM_IDs.ATTENDANCE_CHART_VIEW:
                        if (tabPageAttendanceChartView == null)
                        {
                            tabPageAttendanceChartView = new KryptonPage() { Text = "Attendance Chart View", Name = "PageAttendanceChartView" };
                            tabHR.Pages.Add(tabPageAttendanceChartView);
                            _pageAttendancechartview = new PageAttendanceChartView();
                            tabPageAttendanceChartView.Controls.Add(_pageAttendancechartview);
                            _pageAttendancechartview.Dock = DockStyle.Fill;
                            tabPageAttendanceChartView.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageAttendanceChartView;
                        break;
                    case DB_FORM_IDs.ATTENDANCE_GRID_VIEW:
                        if (tabPageAttendanceGridView == null)
                        {
                            tabPageAttendanceGridView = new KryptonPage() { Text = "Attendance Grid View", Name = "PageAttendanceGridView" };
                            tabHR.Pages.Add(tabPageAttendanceGridView);
                            _pageAttendanceGridView = new PageAttendanceGridView();
                            tabPageAttendanceGridView.Controls.Add(_pageAttendanceGridView);
                            _pageAttendanceGridView.Dock = DockStyle.Fill;
                            tabPageAttendanceGridView.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageAttendanceGridView;
                        break;
                    case DB_FORM_IDs.ATTENDANCE_SUMMARY_VIEW:
                        if (tabPageAttendanceSummaryView == null)
                        {
                            tabPageAttendanceSummaryView = new KryptonPage() { Text = "Attendance Summary View", Name = "PageAttendanceSummaryView" };
                            tabHR.Pages.Add(tabPageAttendanceSummaryView);
                            _pageAttendanceSummaryView = new PageAttendanceSummaryView();
                            tabPageAttendanceSummaryView.Controls.Add(_pageAttendanceSummaryView);
                            _pageAttendanceSummaryView.Dock = DockStyle.Fill;
                            tabPageAttendanceSummaryView.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageAttendanceSummaryView;
                        break;
                    case DB_FORM_IDs.ORGANIZATION_CHART:
                        if (tabPageOrganizationChart == null)
                        {
                            tabPageOrganizationChart = new KryptonPage() { Text = "Organization Hierarchy", Name = "PageOrganizationChart" };
                            tabHR.Pages.Add(tabPageOrganizationChart);
                            _pageOrganizationChart = new PageOrganizationChart();
                            tabPageOrganizationChart.Controls.Add(_pageOrganizationChart);
                            _pageOrganizationChart.Dock = DockStyle.Fill;
                            tabPageOrganizationChart.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageOrganizationChart;
                        break;
                    case DB_FORM_IDs.HOLIDAYS_AND_WEEKOFFS:
                        if (tabPageHolidaysAndWeekOffs == null)
                        {
                            tabPageHolidaysAndWeekOffs = new KryptonPage() { Text = "HR Calendar", Name = "tabPageHolidaysAndWeekOffs" };
                            tabHR.Pages.Add(tabPageHolidaysAndWeekOffs);
                            _pageHolidaysAndWeekOffs = new PageHolidayAndWeekOffs();
                            tabPageHolidaysAndWeekOffs.Controls.Add(_pageHolidaysAndWeekOffs);
                            _pageHolidaysAndWeekOffs.Dock = DockStyle.Fill;
                            tabPageHolidaysAndWeekOffs.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageHolidaysAndWeekOffs;
                        break;
                    case DB_FORM_IDs.PAYROLL_GENERATE:
                        if (tabPageGeneratePayslips == null)
                        {
                            tabPageGeneratePayslips = new KryptonPage() { Text = "Generate Payslips", Name = "tabPageGeneratePayslips" };
                            tabHR.Pages.Add(tabPageGeneratePayslips);
                            _pageGeneratePayslips = new PageGeneratePayslips();
                            tabPageGeneratePayslips.Controls.Add(_pageGeneratePayslips);
                            _pageGeneratePayslips.Dock = DockStyle.Fill;
                            tabPageGeneratePayslips.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageGeneratePayslips;
                        break;
                    case DB_FORM_IDs.PAYROLL_VIEW:
                        if (tabPageViewPayslips == null)
                        {
                            tabPageViewPayslips = new KryptonPage() { Text = "Payslip Viewer", Name = "tabPageViewPayslips" };
                            tabHR.Pages.Add(tabPageViewPayslips);
                            _pageViewPayslips = new PageViewPayslips();
                            tabPageViewPayslips.Controls.Add(_pageViewPayslips);
                            _pageViewPayslips.Dock = DockStyle.Fill;
                            tabPageViewPayslips.Tag = formID;
                        }
                        tabHR.SelectedPage = tabPageViewPayslips;
                        break;



                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageHRLanding::HRMenuButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void toolBtnEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                tabPageEmployees = new KryptonPage() { Text = "Manage Employees", Name = "tabEmployees" };
                tabHR.Pages.Add(tabPageEmployees);
                _pageEmployees = new pageEmployees();
                tabPageEmployees.Controls.Add(_pageEmployees);
                _pageEmployees.Dock = DockStyle.Fill;
                tabHR.SelectedPage = tabPageEmployees;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageHRLanding::toolBtnEmployees_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void tabHR_CloseAction(object sender, CloseActionEventArgs e)
        {
            try
            {
                if (e.Action == CloseButtonAction.RemovePageAndDispose)
                {
                    DB_FORM_IDs formID = (DB_FORM_IDs)((KryptonPage)e.Item).Tag;
                    switch (formID)
                    {
                        case DB_FORM_IDs.SALARY_HEADS: tabPageSalaryHead.Controls.Clear(); tabPageSalaryHead = null; break;
                        case DB_FORM_IDs.EMPLOYEE: tabPageEmployees.Controls.Clear(); tabPageEmployees = null; break;
                        case DB_FORM_IDs.CTC_CONFIGURATION: tabPageConfigureCTC.Controls.Clear(); tabPageConfigureCTC = null; break;
                        case DB_FORM_IDs.HR_LEAVE_CONFIGURATION: tabPageManageLeave.Controls.Clear(); tabPageManageLeave = null; break;
                        case DB_FORM_IDs.LEAVE_APPLICATIONS: tabPageLeavesRegister.Controls.Clear(); tabPageLeavesRegister = null; break;
                        case DB_FORM_IDs.ATTENDANCE_ENTRY_MANUAL: tabPageManualAtendanceEntry.Controls.Clear(); tabPageManualAtendanceEntry = null; break;
                        case DB_FORM_IDs.ATTENDANCE_IMPORT: tabPageImportAttendance.Controls.Clear(); tabPageImportAttendance = null; break;
                        case DB_FORM_IDs.ADVANCE_REQUEST: tabPageAdvanceRegister.Controls.Clear(); tabPageAdvanceRegister = null; break;
                        case DB_FORM_IDs.LOAN_REQUEST: tabPageLoanRequestRegister.Controls.Clear(); tabPageLoanRequestRegister = null; break;
                        case DB_FORM_IDs.LOAN_DISBURSEMENT: tabPageLoanDisbursementRegister.Controls.Clear(); tabPageLoanDisbursementRegister = null; break;
                        case DB_FORM_IDs.ORGANIZATION_CHART: tabPageOrganizationChart.Controls.Clear(); tabPageOrganizationChart = null; break;
                        case DB_FORM_IDs.HOLIDAYS_AND_WEEKOFFS: tabPageHolidaysAndWeekOffs.Controls.Clear(); tabPageHolidaysAndWeekOffs = null; break;
                        case DB_FORM_IDs.ATTENDANCE_CHART_VIEW: tabPageAttendanceChartView.Controls.Clear(); tabPageAttendanceChartView = null; break;
                        case DB_FORM_IDs.ATTENDANCE_GRID_VIEW: tabPageAttendanceGridView.Controls.Clear(); tabPageAttendanceGridView = null; break;
                        case DB_FORM_IDs.PAYROLL: tabPageGeneratePayslips.Controls.Clear(); tabPageGeneratePayslips = null; break;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageHRLanding::tabHR_CloseAction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuAttendanceEntry_Click(object sender, EventArgs e)
        {
            
        }
    }
}
