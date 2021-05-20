using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.HR.Attendance
{
    public partial class PageAttendanceSummaryView : UserControl
    {
        BindingList<MonthlyAttendanceSummaryModel> _SummaryList = null;
        BindingList<MonthlyAttendanceSummaryModel> _filteredSummaryList = null;
        #region ATTENDANCE SUMMARY VIEW
        public PageAttendanceSummaryView()
        {
            InitializeComponent();
        }
        private void btnPrepareMonthlySheet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _SummaryList =AppCommon.ConvertToBindingList<MonthlyAttendanceSummaryModel>((new ServiceAttendance()).GetMonthlyAttendanceSummaryForMonth(dtAttendanceMonth.Value));
                gridAttendanceSummary.DataSource = _SummaryList;
                FormatAttendanceGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceSummaryView::btnPrepareMonthlySheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void FormatAttendanceGrid()
        {
            try
            {
                
                gridAttendanceSummary.Columns["EmployeeID"].Visible = false;
                gridAttendanceSummary.Columns["EmployeeName"].Width= (int)(gridAttendanceSummary.Width*.25);
                gridAttendanceSummary.Columns["TotalDays"].HeaderText = string.Format("Days in\nMonth");
                gridAttendanceSummary.Columns["NonWorkingDays"].HeaderText = string.Format("Off\nDays");
                gridAttendanceSummary.Columns["PaidDays"].HeaderText = string.Format("Paid\nDays");
               gridAttendanceSummary.Columns["EmployeeDescription"].Visible = false;
                gridAttendanceSummary.Columns["SearchText"].Visible = false;
                //gridAttendanceSummary.Columns["EmployeeName"].HeaderText = string.Format("Name of\nEmployee");
                //gridAttendanceSummary.Columns["EmployeeName"].HeaderText = string.Format("Name of\nEmployee");
                gridAttendanceSummary.Columns["SandwichLeaves"].HeaderText = string.Format("Sandwich\nLeaves");
                gridAttendanceSummary.Columns["LateComings"].HeaderText = string.Format("Late\nComings");
                gridAttendanceSummary.Columns["EarlyGoings"].HeaderText = string.Format("Early\nGoings");



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceSummaryView::FormatAttendanceGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSearchAttendanceSummary_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                _filteredSummaryList = new BindingList<MonthlyAttendanceSummaryModel>(_SummaryList.Where(p => p.SearchText.Contains(txtSearchOnsiteEmployee.Text.ToUpper())).ToList());
                gridAttendanceSummary.DataSource = _filteredSummaryList;
                headerGroupOptions.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridAttendanceSummary.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceSummaryView::btnSearchAttendanceSummary_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string fileNameWithPath = string.Format("{0}Summary {1}.xls", AppCommon.GetDefaultStorageFolderPath(), dtAttendanceMonth.Value.ToString("MMM yyyy").ToUpper());
                (new ServiceExcelApp()).ExportAttendanceSummaryDataToExcel(_SummaryList, dtAttendanceMonth.Value, fileNameWithPath);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageAttendanceSummaryView::btnExportToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

      
    }
}
