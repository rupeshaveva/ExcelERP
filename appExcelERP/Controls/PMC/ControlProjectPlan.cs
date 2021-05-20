using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Controls.PMC
{
    public partial class ControlProjectPlan : UserControl
    {
        public int SelectedProjectID { get; set; }
        public ControlGanttChart _controlPLANNING { get; set; }
        public ControlGanttChart _controlEXECUTION { get; set; }

        public ControlProjectPlan()
        {
            InitializeComponent();
        }
        private void ControlProjectPlan_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrders::PopulateSalesOrderTypeVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulatePalnAndExecutionGanttCharts()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                tabPageProjectPlan.Controls.Clear();
                _controlPLANNING = new ControlGanttChart();
                _controlPLANNING.SelectedPlanType = libERP.MODELS.COMMON.PROJECT_PLAN_TYPE.PROJECT_PLANNING;
                tabPageProjectPlan.Controls.Add(_controlPLANNING);
                _controlPLANNING.Dock = DockStyle.Fill;
                _controlPLANNING.SelectedProjectID = this.SelectedProjectID;
                _controlPLANNING.PopulateGanttChart();

                tabPageProjectExecution.Controls.Clear();
                _controlEXECUTION = new ControlGanttChart();
                _controlEXECUTION.SelectedPlanType = libERP.MODELS.COMMON.PROJECT_PLAN_TYPE.PROJECT_EXECUTION;
                tabPageProjectExecution.Controls.Add(_controlEXECUTION);
                _controlEXECUTION.Dock = DockStyle.Fill;
                _controlEXECUTION.SelectedProjectID = this.SelectedProjectID;
                _controlEXECUTION.PopulateGanttChart();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectPlan::PopulatePalnAndExecutionGanttCharts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
