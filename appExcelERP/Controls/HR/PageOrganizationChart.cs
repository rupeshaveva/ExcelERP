using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Controls.HR
{
    public partial class PageOrganizationChart : UserControl
    {
        private OrgChartGenerator.OrgChart myOrgChart;

        public PageOrganizationChart()
        {
            InitializeComponent();
        }

        public void GenerateOrganizationChart()
        {
            try
            {
                OrgChartGenerator.OrgData.OrgDetailsDataTable myOrgData = new OrgChartGenerator.OrgData.OrgDetailsDataTable();
                myOrgData.AddOrgDetailsRow("1001", "Alon", "", "Manager");
                myOrgData.AddOrgDetailsRow("2001", "Yoram", "1001", "Team Leader");
                myOrgData.AddOrgDetailsRow("2002", "Dana", "1001", "Team Leader");
                myOrgData.AddOrgDetailsRow("3001", "Moshe", "2003", "SW Engineer");
                myOrgData.AddOrgDetailsRow("3002", "Oren", "2003", "SW Engineer");
                myOrgData.AddOrgDetailsRow("3003", "Noa", "2003", "SW Engineer");
                myOrgData.AddOrgDetailsRow("3004", "Mor", "2002", "Consultant");
                myOrgData.AddOrgDetailsRow("3005", "Omer", "2002", "Consultant");
                myOrgData.AddOrgDetailsRow("2003", "Avi", "1001", "Team Leader");
                myOrgData.AddOrgDetailsRow("2004", "Esty", "1001", "Team Leader");
                myOrgData.AddOrgDetailsRow("2005", "Danny", "1001", "Team Leader");
                myOrgData.AddOrgDetailsRow("2006", "Shlomo", "1001", "Team Leader");

                myOrgChart = new OrgChartGenerator.OrgChart(myOrgData);
                picOrgChart.Image = Image.FromStream(myOrgChart.GenerateOrgChart(picOrgChart.Width, picOrgChart.Height, "1001", System.Drawing.Imaging.ImageFormat.Bmp));



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageOrganizationChart::GenerateOrganizationChart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
