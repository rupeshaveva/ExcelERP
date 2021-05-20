using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.HR
{
    public partial class frmAddEditHolidayAndWeekOff : Form
    {
        public int SelectedYearID { get; set; }
        public int HolidayID { get; set; }
        public DateTime HolidayDate { get; set; }


        public frmAddEditHolidayAndWeekOff()
        {
            InitializeComponent();
        }
       public frmAddEditHolidayAndWeekOff(int ID)
        {
            InitializeComponent();
            this.HolidayID = ID;
        }

        private void frmAddEditHolidayAndWeekOff_Load(object sender, EventArgs e)
        {
            try
            {
                radioBtnHoliday.Tag = ATTENDANCE_TYPE.HOLIDAY;
                radioBtnWeekOff.Tag = ATTENDANCE_TYPE.WEEK_OFF;

                PopulateFinancialYearDropdown();
                if (HolidayID == 0)
                {
                    if (this.SelectedYearID != 0)
                        cboFinancialYear.SelectedItem = ((List<SelectListItem>)cboFinancialYear.DataSource).Where(x => x.ID == this.SelectedYearID).FirstOrDefault();
                    dtDate.Value = this.HolidayDate;
                    radioBtnHoliday.Checked = true;
                    txtRemark.Text = string.Empty;
                }
                else
                {
                    ScatterData();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::frmAddEditEmployeeRelation_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void ScatterData()
        {
            try
            {
                TBL_MP_HR_HolidaysAndWeekOff model = (new ServiceHolidayAndWeekOffs()).GetHolidayDbRecordByHolidayID(this.HolidayID);
                if (model != null)
                {
                    cboFinancialYear.SelectedItem = ((List<SelectListItem>)cboFinancialYear.DataSource).Where(x => x.ID == model.FK_YearID).FirstOrDefault();
                    dtDate.Value = (DateTime)model.HolidayDate;
                    if ((ATTENDANCE_TYPE)model.HolidayType == ATTENDANCE_TYPE.HOLIDAY) radioBtnHoliday.Checked = true;
                    if ((ATTENDANCE_TYPE)model.HolidayType == ATTENDANCE_TYPE.WEEK_OFF) radioBtnWeekOff.Checked = true;
                    txtRemark.Text = model.Remarks;
                }
               
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void PopulateFinancialYearDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllFinancialYears());
                cboFinancialYear.DataSource = lst;
                cboFinancialYear.DisplayMember = "Description";
                cboFinancialYear.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::PopulateFinancialYearDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_HR_HolidaysAndWeekOff model = null;
            ServiceHolidayAndWeekOffs _service = new ServiceHolidayAndWeekOffs();
            try
            {
                if (!this.ValidateChildren()) return;

                if (this.HolidayID == 0)
                    model = new TBL_MP_HR_HolidaysAndWeekOff();
                else
                    model = _service.GetHolidayDbRecordByHolidayID(this.HolidayID);

                model.FK_YearID= ((SelectListItem)cboFinancialYear.SelectedItem).ID;
                if (radioBtnHoliday.Checked) model.HolidayType = (int)ATTENDANCE_TYPE.HOLIDAY;
                if (radioBtnWeekOff.Checked) model.HolidayType = (int)ATTENDANCE_TYPE.WEEK_OFF;
                model.HolidayDate = dtDate .Value;
                model.Remarks = txtRemark.Text.Trim();
               
                if (this.HolidayID == 0)
                    this.HolidayID = _service.AddNewHolidayAndWeekOffs(model);
                else
                    _service.UpdateHolidayAndWeekOffsInfo(model);


                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditHolidayAndWeekOff::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
    }
}
