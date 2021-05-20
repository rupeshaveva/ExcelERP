using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.HR.Attendance
{
    public partial class PageAttendanceChartView : UserControl
    {
        public vAttendanceRegister SelectedAttendanceModel { get; set; }

        public int SelectedAttendanceID { get; set; }
        public BindingList<vAttendanceRegister> _AttendanceList { get; set; }
        public BindingList<vAttendanceRegister> _filterAttendanceList { get; set; }

        public int SelectedEmployeeID { get; set; }
        public BindingList<SelectListItem> _EmployeesList { get; set; }
        public BindingList<SelectListItem> _filteredEmployeesList { get; set; }

        private ControlEmployeeAttendanceViewer _EmployeeAttendaceViewer = null;

        public PageAttendanceChartView()
        {
            InitializeComponent();
        }
        #region ATTENDANCE CHART VIEW
        private void PageAttendanceChartView_Load(object sender, EventArgs e)
        {
            try
            {
               
                _EmployeeAttendaceViewer = new ControlEmployeeAttendanceViewer();
                SplitContainerChartView.Panel2.Controls.Clear();
                SplitContainerChartView.Panel2.Controls.Add(_EmployeeAttendaceViewer);
                _EmployeeAttendaceViewer.Dock = DockStyle.Fill;
                SplitContainerChartView.SplitterDistance = (int)(this.Width * .18);
                //_EmployeesList = new BindingList<SelectListItem>();
                //FormatEmployeeGrid();
                //_AttendanceList = new BindingList<vAttendanceRegister>();
                //FormatAttendanceGrid();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceChartView::PageMonthlyAttendanceManager_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnPrepareMonthlySheet_Click(object sender, EventArgs e)
        {
            try
            {
                //headerGridView.Values.Heading = string.Format("Fetching list of Distinct Employees for month ({0})", dtAttendanceMonth.Value.ToString("MMMM"));
                _EmployeesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceAttendance()).GetDistinctEmployeesListForMonthInAttendance(dtAttendanceMonth.Value));
                gridActiveEmployees.DataSource = _EmployeesList;
                FormatEmployeeGrid();
                Application.DoEvents();
                headerGroupActiveEmployees.ValuesSecondary.Heading = string.Format("{0} records found.", gridActiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceChartView::btnPrepareMonthlySheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridActiveEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (_EmployeeAttendaceViewer != null)
                {
                    _EmployeeAttendaceViewer.EmployeeID = (int)gridActiveEmployees.Rows[e.RowIndex].Cells["ID"].Value;
                    _EmployeeAttendaceViewer.dtAttendanceMonth.Value = _EmployeeAttendaceViewer.AttendanceMonth = dtAttendanceMonth.Value;
                    _EmployeeAttendaceViewer.headerGroupOptions.Visible = false;
                    _EmployeeAttendaceViewer.PopulateCalendarAndSummary();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceChartView::gridActiveEmployees_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }
        private void FormatEmployeeGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                gridActiveEmployees.Columns["ID"].Visible =
                gridActiveEmployees.Columns["Code"].Visible =
                gridActiveEmployees.Columns["DescriptionToUpper"].Visible =
                gridActiveEmployees.Columns["IsActive"].Visible = false;
               headerGroupActiveEmployees.ValuesPrimary.Heading = "Formatting Employee's Grid Completed";
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceChartView::FormatEmployeeGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchActiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredEmployeesList = new BindingList<SelectListItem>(_EmployeesList.Where(p => p.Description.Contains(txtSearchActiveEmployees.Text.ToUpper())).ToList());
                gridActiveEmployees.DataSource = _filteredEmployeesList;
                headerGroupActiveEmployees.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridActiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceChartView::btnSearchActiveUsers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        #endregion


    }
}

