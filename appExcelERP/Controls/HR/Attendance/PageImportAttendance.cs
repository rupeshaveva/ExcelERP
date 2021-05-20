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

namespace appExcelERP.Controls.HR.Attendance
{
    public partial class PageImportAttendance : UserControl
    {
        private ServiceAttendance _serviceAttendance = null;
        public BindingList<OfficeAttendanceModel> listATTENDANCE { get; set; }
        private BindingList<OfficeAttendanceModel> _filteredListATTENDANCE = null;

        public PageImportAttendance()
        {
            InitializeComponent();
        }
        private void PageImportAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                _serviceAttendance = new ServiceAttendance();
                _serviceAttendance.OnImportRecordProcessStart += _serviceAttendance_OnImportRecordProcessStart1;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageImportAttendance::PageImportAttendance_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #region OFFICE ATTENDANCE
        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                listATTENDANCE = (new ServiceAttendance()).GetAllAttendanceFromSmartOfficeInDateRange(dtStartDate.Value, dtEndDate.Value);
                gridAttendance.DataSource = listATTENDANCE;
                gridAttendance.Columns["EmployeeIDSmartOffice"].Visible =
                gridAttendance.Columns["EmployeeIDExcelERP"].Visible = false;
                gridAttendance.Columns["Duration"].DefaultCellStyle.Format = "0.00";
                headerGroupProcess.ValuesSecondary.Heading = string.Format("{0} Records found.", listATTENDANCE.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageImportAttendance::btnProcess_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnPostAttendanceToExcelERP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int result = _serviceAttendance.PostOfficeAttendanceRecordsToExcelERP(listATTENDANCE, Program.CURR_USER.EmployeeID);
                headerGroupProcess.ValuesSecondary.Heading = string.Format("Successfully Imported {0} Records", result);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageImportAttendance::btnPostAttendanceToExcelERP_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSearchEmployeeName_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchEmployeeName.Text.Trim() == string.Empty)
                    gridAttendance.DataSource = listATTENDANCE;
                else
                {
                    _filteredListATTENDANCE = new BindingList<OfficeAttendanceModel>(listATTENDANCE.Where(p => p.EmployeeName.Contains(txtSearchEmployeeName.Text.ToUpper())).ToList());
                    gridAttendance.DataSource = _filteredListATTENDANCE;
                }
                headerGroupProcess.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridAttendance.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageImportAttendance::btnSearchEmployeeName_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _serviceAttendance_OnImportRecordProcessStart1(object sender, libERP.MODELS.COMMON.EventArguementModel e)
        {
            try
            {
                headerGroupProcess.ValuesSecondary.Heading = e.Message;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageImportAttendance::_serviceAttendance_OnImportRecordProcessStart1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

       
    }
}
