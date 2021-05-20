using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.MASTER;
using libERP;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.MODELS;

namespace appExcelERP.Controls.HR
{
    public partial class PageHolidayAndWeekOffs : UserControl
    {
        public int SelectedFYID { get; set; }
        public DateTime SelectedDate { get; set; }
        private BindingList<SelectListItem> _HolidayAndWeekOffList = null;
        private BindingList<SelectListItem> _filteredHolidayAndWeekOffList = null;

        private BindingList<SelectListItem> _FinYearList = null;
        private BindingList<SelectListItem> _filteredFinYearList = null;


        KryptonMonthCalendar _Calender = null;
        public PageHolidayAndWeekOffs()
        {
            InitializeComponent();
        }
        private void PageHolidayAndWeekOffs_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateAllFinancialYearsInGrid();
                WhosWhoModel permission = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.HOLIDAYS_AND_WEEKOFFS).FirstOrDefault();
                if (permission.CanAddNew || permission.CanModify)
                    btnUpdateHoliday.Enabled = ButtonEnabled.True;
                else
                    btnUpdateHoliday.Enabled = ButtonEnabled.False;

                btnDeleteHoliday.Enabled = (permission.CanDelete) ? ButtonEnabled.True : ButtonEnabled.False;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::PageHolidayAndWeekOffs_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateAllFinancialYearsInGrid()
        {
            try
            {
                gridFY.DataSource = (new ServiceMASTERS()).GetAllFinancialYears();
                gridFY.Columns["ID"].Visible = gridFY.Columns["Code"].Visible = gridFY.Columns["IsActive"].Visible = gridFY.Columns["DescriptionToUpper"].Visible = false;
           }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::PopulateAllFinancialYearsInGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateHolidayAndWeekOffViews()
        {
            btnDeleteHoliday.Visible = true;
            ServiceHolidayAndWeekOffs _service = new ServiceHolidayAndWeekOffs();
            try
            {
                tbl_Acct_Financial_Year model = (new ServiceMASTERS()).GetFinancialYearDbRecordByID(this.SelectedFYID);
                if (model != null)
                {
                    this.SuspendLayout();
                    monthViewControl = new ComponentFactory.Krypton.Toolkit.KryptonMonthCalendar();
                    //monthViewControl.MaxDate = DateTime.Now;
                    //monthViewControl.MinDate = DateTime.Now;
                    monthViewControl.MinDate = (DateTime)model.FromDate;
                    monthViewControl.MaxDate = (DateTime)model.ToDate;
                    monthViewControl.DateChanged += _Calender_DateChanged;
                    //_Calender.DayStyle = ButtonStyle.Standalone;
                    //_Calender.OverrideBolded.Day.Back.Color1 = System.Drawing.Color.Red;
                    //_Calender.HeaderStyle = HeaderStyle.Primary;
                    monthViewControl.SelectionStart = (DateTime)model.FromDate;
                    monthViewControl.SelectionEnd = (DateTime)model.FromDate;
                    monthViewControl.MaxSelectionCount = 1;
                    monthViewControl.ShowToday = false;
                    monthViewControl.ShowTodayCircle = false;


                    List<TBL_MP_HR_HolidaysAndWeekOff> lstHolidays = _service.GetAllHolidaysForTheFinYear(this.SelectedFYID);
                    _HolidayAndWeekOffList = new BindingList<SelectListItem>();
                    foreach (TBL_MP_HR_HolidaysAndWeekOff item in lstHolidays)
                    {
                        monthViewControl.AddBoldedDate(item.HolidayDate);
                        _HolidayAndWeekOffList.Add(new SelectListItem() {  ID = item.PK_HolidayID, Code= item.HolidayDate.ToString("dd MMM yyyy"),  Description= item.Remarks });
                    }
                    gridHolidaysAndWeekOffs.DataSource = _HolidayAndWeekOffList;
                    //make these columns hidden PK_HolidayID, FK_YearID, HolidayType
                    gridHolidaysAndWeekOffs.Columns["ID"].Visible =
                     gridHolidaysAndWeekOffs.Columns["DescriptionToUpper"].Visible =
                     gridHolidaysAndWeekOffs.Columns["IsActive"].Visible = false;

                    this.monthViewControl.CalendarDimensions = new System.Drawing.Size(4, 3);
                    this.monthViewControl.DayOfWeekStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
                    this.monthViewControl.DayStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
                    this.monthViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.monthViewControl.Location = new System.Drawing.Point(0, 0);
                    this.monthViewControl.OverrideBolded.Day.Back.Color1 = System.Drawing.Color.Yellow;
                    this.monthViewControl.OverrideBolded.Day.Back.Color2 = System.Drawing.Color.Red;
                    this.monthViewControl.OverrideBolded.Day.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
                    //this._Calender.OverrideBolded.Day.Border.Color1 = System.Drawing.Color.Lime;
                    //this._Calender.OverrideBolded.Day.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
                    //this._Calender.OverrideBolded.Day.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                    //| ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                    //| ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                    //this._Calender.OverrideBolded.Day.Border.Width = 1;
                    this.monthViewControl.OverrideBolded.Day.Content.ShortText.Color1 = System.Drawing.Color.Red;
                    this.monthViewControl.OverrideBolded.Day.Content.LongText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                    this.monthViewControl.OverrideBolded.Day.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.monthViewControl.OverrideBolded.Day.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
                    this.monthViewControl.OverrideBolded.Day.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;

                    headerGroupCalendarView.Panel.Controls.Clear();
                    headerGroupCalendarView.Panel.Controls.Add(monthViewControl);
                    monthViewControl.Show();
                    this.ResumeLayout(false);
                    //monthViewControl.Dock = DockStyle.Fill;
                    headerGroupRight.ValuesPrimary.Heading = string.Format("FA: {0}  till  {1}", model.FromDate.ToString("dd MMMM yyyy"), model.ToDate.ToString("dd MMMM yyyy "));
                    headerGroupRight.ValuesPrimary.Description = string.Format("Holidays: {0} Week-offs: {1}", _service.GetHolidayCountForYear(this.SelectedFYID), _service.GetWeekOffCountForYear(this.SelectedFYID));
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::PopulateHolidayAndWeekOffViews", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Calender_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            throw new NotImplementedException();
        }
        private void _Calender_DateChanged(object sender, DateRangeEventArgs e)
        {
            btnDeleteHoliday.Visible = false;
            try
            {
                this.SelectedDate = e.Start;
                TBL_MP_HR_HolidaysAndWeekOff model = (new ServiceHolidayAndWeekOffs()).GetHolidayDbRecordByDate(this.SelectedDate);
                if (model != null)
                {
                    btnDeleteHoliday.Visible = true;
                    ATTENDANCE_TYPE type = (ATTENDANCE_TYPE)model.HolidayType;
                    headerGroupRight.ValuesSecondary.Heading =string.Format("{0} - {1} ({2})", SelectedDate.ToString("dd MMM yy"), model.Remarks, ((type== ATTENDANCE_TYPE.HOLIDAY)?"Holiday":"Week-Off"));

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::_Calender_DateChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PageHolidayAndWeekOffs_Resize(object sender, EventArgs e)
        {
            //kryptonMonthCalendar1.Height = kryptonSplitContainer1.Panel2.Height;
            //kryptonMonthCalendar1.Width = kryptonSplitContainer1.Panel2.Width;
            //kryptonMonthCalendar1.CalendarDimensions = new Size(5, 2);
            //Application.DoEvents();
        }
        private void gridFY_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedFYID = (int)gridFY.Rows[e.RowIndex].Cells["ID"].Value;
                PopulateHolidayAndWeekOffViews();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::gridFY_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdateHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditHolidayAndWeekOff frm = null;
                TBL_MP_HR_HolidaysAndWeekOff model = (new ServiceHolidayAndWeekOffs()).GetHolidayDbRecordByDate(this.SelectedDate);
                if (model != null)
                    frm = new frmAddEditHolidayAndWeekOff(model.PK_HolidayID);
                else
                {
                    frm = new frmAddEditHolidayAndWeekOff();
                    frm.SelectedYearID = this.SelectedFYID;
                    frm.HolidayDate = this.SelectedDate;
                }
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateHolidayAndWeekOffViews();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::btnUpdateHoliday_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void kryptonSplitContainer1_SizeChanged(object sender, EventArgs e)
        {
            if (this._Calender != null)
            {
                this._Calender.Size = new System.Drawing.Size(headerGroupRight.Panel.Width, headerGroupRight.Panel.Height);
                _Calender.Refresh();
            }
            
        }
        private void gridHolidaysAndWeekOffs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteHoliday.Visible = false;
            try
            {

                this.SelectedDate = DateTime.Parse(gridHolidaysAndWeekOffs.Rows[e.RowIndex].Cells["Code"].Value.ToString());
                TBL_MP_HR_HolidaysAndWeekOff model = (new ServiceHolidayAndWeekOffs()).GetHolidayDbRecordByDate(this.SelectedDate);
                if (model != null)
                {
                    btnDeleteHoliday.Visible = true;
                    ATTENDANCE_TYPE type = (ATTENDANCE_TYPE)model.HolidayType;
                    headerGroupRight.ValuesSecondary.Heading = string.Format("{0} - {1} ({2})", SelectedDate.ToString("dd MMM yy"), model.Remarks, ((type == ATTENDANCE_TYPE.HOLIDAY) ? "Holiday" : "Week-Off"));

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::gridHolidaysAndWeekOffs_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchGrid_Click(object sender, EventArgs e)
        {
            try
            {
                _filteredHolidayAndWeekOffList = new BindingList<SelectListItem>(_HolidayAndWeekOffList.Where(p => p.DescriptionToUpper.Contains(txtSearchGrid.Text.ToUpper())).ToList());
                gridHolidaysAndWeekOffs.DataSource = _filteredHolidayAndWeekOffList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::txtSearchGrid_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you Sure to Remove Holiday or Week-Off On {0}", this.SelectedDate.ToString("dd MMMM yyyy"));
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool res = (new ServiceHolidayAndWeekOffs()).RemoveHolidayAandWeekOffOnDate(this.SelectedDate);
                    if (res)
                        MessageBox.Show(string.Format("Removed Holiday or Week-Off on {0}", this.SelectedDate.ToString("dd MMMM yyyy")), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateHolidayAndWeekOffViews();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageHolidayAndWeekOffs::btnDeleteHoliday_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchFA_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredFinYearList = new BindingList<SelectListItem>(_FinYearList.Where(p => p.Description.Contains(txtSearchFA.Text.ToUpper())).ToList());
                gridFY.DataSource = _filteredFinYearList;
                headerGroupFY.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridFY.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PageHolidayAndWeekOffs::txtSearchFinYears_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }

       
    }
}
