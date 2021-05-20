using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.HR
{
    public partial class PageCTCConfiguration : UserControl
    {
        public int SelectedDesignationID { get; set; }

        private ControlCTCConfiguration _ControlPermanentCTC = null;
        private ControlCTCConfiguration _ControlProbationCTC = null;

        BindingList<SelectListItem> _DesignationList = null;
        BindingList<SelectListItem> _filteredDesignationList = null;


        public PageCTCConfiguration()
        {
            InitializeComponent();
        }
        private void PageCTCConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                // INSTANCIATE CONTROSL FOR PERMANET & PROBATION SALARY CONFIGURATION
                _ControlPermanentCTC = new ControlCTCConfiguration(libERP.MODELS.COMMON.EMPLOYMENT_TYPE.PERMAMENT);
                tabPagePermanentEmployee.Controls.Add(_ControlPermanentCTC);
                _ControlPermanentCTC.Dock = DockStyle.Fill;

                _ControlProbationCTC = new ControlCTCConfiguration(libERP.MODELS.COMMON.EMPLOYMENT_TYPE.PROBATION);
                tabPageProbationEmployee.Controls.Add(_ControlProbationCTC);
                _ControlProbationCTC.Dock = DockStyle.Fill; 

                PopulateDesignationGrid();

                

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCTCConfiguration::PageCTCConfiguration_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void PopulateDesignationGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _DesignationList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllDesignation());
                gridDesignations.DataSource = _DesignationList;
                gridDesignations.Columns["ID"].Visible =
                gridDesignations.Columns["DescriptionToUpper"].Visible =
                gridDesignations.Columns["Code"].Visible =
                gridDesignations.Columns["IsActive"].Visible = false;

                headerGroupDesignations.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridDesignations.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCTCConfiguration::PopulateDesignationGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnsearchDesignation_Click(object sender, EventArgs e)
        {
            try
            {
                _filteredDesignationList = new BindingList<SelectListItem>(_DesignationList.Where(p => p.DescriptionToUpper.Contains(txtSearchDesignation.Text.ToUpper())).ToList());
                gridDesignations.DataSource = _filteredDesignationList;
                headerGroupDesignations.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridDesignations.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCTCConfiguration::btnsearchDesignation_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridDesignations_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedDesignationID= int.Parse(gridDesignations.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                _ControlPermanentCTC.DesignationID = _ControlProbationCTC.DesignationID = this.SelectedDesignationID;
                _ControlPermanentCTC.PopulateAlluncesAndDeductionsSlaryHeadsGrid();
                _ControlProbationCTC.PopulateAlluncesAndDeductionsSlaryHeadsGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCTCConfiguration::gridDesignations_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       




    }
}
