using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{
   public class ServiceHolidayAndWeekOffs : DefaultService
    {
        public ServiceHolidayAndWeekOffs(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceHolidayAndWeekOffs()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public int AddNewHolidayAndWeekOffs(TBL_MP_HR_HolidaysAndWeekOff model)
        {
            int newID = 0;
            try
            {

                _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_HolidayID;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::AddNewHolidayAndWeekOffs", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateHolidayAndWeekOffsInfo(TBL_MP_HR_HolidaysAndWeekOff model)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_HolidaysAndWeekOff dbModel = _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.PK_HolidayID == model.PK_HolidayID).FirstOrDefault();
                dbModel.FK_YearID = model.FK_YearID;
                dbModel.HolidayDate = model.HolidayDate;
                dbModel.HolidayType = model.HolidayType;
                dbModel.Remarks = model.Remarks;
                 _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::UpdateHolidayAndWeekOffsInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public bool RemoveHolidayAandWeekOffOnDate(DateTime dtDate)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_HolidaysAndWeekOff model = _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.HolidayDate == dtDate).FirstOrDefault();
                if (model != null)
                {
                    _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Remove(model);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::RemoveHolidayAandWeekOffOnDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_HR_HolidaysAndWeekOff GetHolidayDbRecordByDate(DateTime dtDate)
        {
            TBL_MP_HR_HolidaysAndWeekOff model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.HolidayDate == dtDate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::GetHolidayDbRecordByDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public TBL_MP_HR_HolidaysAndWeekOff GetHolidayDbRecordByHolidayID(int id)
        {
            TBL_MP_HR_HolidaysAndWeekOff model = null;
            try
            {
                model = _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.PK_HolidayID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::GetHolidayDbRecordByDate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public List<TBL_MP_HR_HolidaysAndWeekOff> GetAllHolidaysForTheFinYear(int FinYearID)
        {
            try
            {
                return _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.FK_YearID == FinYearID).OrderBy(x=>x.HolidayDate).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::GetAllHolidaysForTheFinancialYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public int GetHolidayCountForYear(int FinYearID)
        {
            int cnt = 0;
            try
            {
                cnt= _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.FK_YearID == FinYearID).Where(x => x.HolidayType == (int)ATTENDANCE_TYPE.HOLIDAY).Count();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::GetHolidayCountForYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cnt;
        }
        public int GetWeekOffCountForYear(int FinYearID)
        {
            int cnt = 0;
            try
            {
                cnt = _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.FK_YearID == FinYearID).Where(x => x.HolidayType == (int)ATTENDANCE_TYPE.WEEK_OFF).Count();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::GetWeekOffCountForYear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cnt;
        }
        public int GetOffDaysBetweenDates(DateTime dtFromDate,DateTime dtToDate)
        {
            int daysCount = 0;
            try
            {
                daysCount = (from xx in _dbContext.TBL_MP_HR_HolidaysAndWeekOff where xx.HolidayDate >= dtFromDate && xx.HolidayDate <= dtToDate select xx).Count();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::GetOffDaysBetweenDates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return daysCount;
        }
        public bool IsHolidayOrWeekOff(DateTime currDate)
        {
            bool result = false;
            try
            {
                TBL_MP_HR_HolidaysAndWeekOff dbOff = _dbContext.TBL_MP_HR_HolidaysAndWeekOff.Where(x => x.HolidayDate == currDate).FirstOrDefault();
                if (dbOff != null) result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceHolidayAndWeekOffs::IsHolidayOrWeekOff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
