using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using libERP.MODELS;
using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

using System.Windows.Forms;
using libERP.MODELS.COMMON;
using libERP.SERVICES.MASTER;

namespace libERP.SERVICES.COMMON
{
    public static class AppUtility
    {
        public static IEnumerable<TControl> GetChildControls<TControl>(this Control control) where TControl : Control
        {
            var children = (control.Controls != null) ? control.Controls.OfType<TControl>() : Enumerable.Empty<TControl>();
            return children.SelectMany(c => GetChildControls<TControl>(c)).Concat(children);
        }
    }

    public class AppCommon : DefaultService
    {
        public static string EXCELColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }
        public string GetUniqueFileName(string fileName)
        {
            string newFileName = string.Empty;
            try
            {
                Guid g = Guid.NewGuid();
                newFileName = g.ToString() + Path.GetExtension(fileName);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "AppCommon::GetUniqueFileName");
            }
            return newFileName;
        }

        public static DateTime GetServerDateTime()
        {
            string sql = "select getdate() as currDate";
            var currDate = (new EXCEL_ERP_TESTEntities()).Database.SqlQuery<DateTime>(sql).FirstOrDefault();
            return currDate;
        }
        private static string Decrypt(string strText, string sDecrKey)
        {
            byte[] rgbKey = new byte[0];
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            byte[] buffer = new byte[strText.Length + 1];
            try
            {
                rgbKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                buffer = Convert.FromBase64String(strText);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public static string DecryptText(string strText)
        {
            return Decrypt(strText, "&%#@?,:*");
        }
        private static string Encrypt(string strText, string strEncrKey)
        {
            byte[] rgbKey = new byte[0];
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            try
            {
                rgbKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(strText);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public static string EncryptText(string strText)
        {
            return Encrypt(strText, "&%#@?,:*");
        }

        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
        public static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        public static string ConvertIntArrayToDelimiterSeperatedString(int[] intArr)
        {
            string strReturn = string.Empty;
            try
            {

                for (int i = 0; i <= intArr.GetUpperBound(0); i++)
                {
                    strReturn += intArr[i].ToString().Trim() + DefaultStringSeperator;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AppCommon::ConvertIntArrayToDelimiterSeperatedString", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strReturn;
        }
         //public BindingList<SelectListItem> ConvertToBindingList(List<SelectListItem> lst)
        //{
        //    BindingList<SelectListItem> newList = new BindingList<SelectListItem>();
        //    try
        //    {
        //        foreach (SelectListItem itm in lst)
        //        {
        //            newList.Add(itm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return newList;
        //}
         public static BindingList<T> ConvertToBindingList<T>(List<T> lst)
        {
            BindingList<T> newList = new BindingList<T>();
            try
            {
                foreach (var itm in lst)
                {
                    newList.Add(itm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newList;
        }
        public List<MultiSelectListItem> ConvertToMultiSelectListItem(List<SelectListItem> lst)
        {
            List<MultiSelectListItem> newList = new List<MultiSelectListItem>();
            try
            {
                foreach (var selItem in lst)
                {
                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        Description = selItem.Description,
                        Code = selItem.Code,
                        ID = selItem.ID
                    };
                    newList.Add(item);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "AppCommon::ConvertToMultiSelectListItem");
            }
            return newList;
        }

        public static List<SelectListItem> GetAllMonthNamesList()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {

                lst.Add(new SelectListItem() { ID = 1, Description = "JANUARY" });
                lst.Add(new SelectListItem() { ID = 2, Description = "FEBRUARY" });
                lst.Add(new SelectListItem() { ID = 3, Description = "MARCH" });
                lst.Add(new SelectListItem() { ID = 4, Description = "APRIL" });
                lst.Add(new SelectListItem() { ID = 5, Description = "MAY" });
                lst.Add(new SelectListItem() { ID = 6, Description = "JUNE" });
                lst.Add(new SelectListItem() { ID = 7, Description = "JULY" });
                lst.Add(new SelectListItem() { ID = 8, Description = "AUGUST" });
                lst.Add(new SelectListItem() { ID = 9, Description = "SEPTEMBER" });
                lst.Add(new SelectListItem() { ID = 10, Description = "OCTOBER" });
                lst.Add(new SelectListItem() { ID = 11, Description = "NOVEMBER" });
                lst.Add(new SelectListItem() { ID = 12, Description = "DECEMBER" });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AppCommon::GetAllMonthNamesList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetAllThemes()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                items.Add(new SelectListItem() { Code = "Office2007Black", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black });
                items.Add(new SelectListItem() { Code = "Office2007Blue", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Blue });
                items.Add(new SelectListItem() { Code = "Office2007Silver", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Silver });

                items.Add(new SelectListItem() { Code = "Office2010Black", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black });
                items.Add(new SelectListItem() { Code = "Office2010Blue", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Blue });
                items.Add(new SelectListItem() { Code = "Office2010Silver", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver });

                items.Add(new SelectListItem() { Code = "Office2013White", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2013White });


                items.Add(new SelectListItem() { Code = "SparkleBlue", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparkleBlue });
                items.Add(new SelectListItem() { Code = "SparkleOrange", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparkleOrange });
                items.Add(new SelectListItem() { Code = "SparklePurple", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparklePurple });


                items.Add(new SelectListItem() { Code = "ProfessionalOffice2003", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.ProfessionalOffice2003 });
                items.Add(new SelectListItem() { Code = "ProfessionalSystem", ID = (int)ComponentFactory.Krypton.Toolkit.PaletteModeManager.ProfessionalSystem });




            }
            catch (Exception ex)
            {
                throw ex;
            }
            return items;
        }

        public static string GetDefaultStorageFolderPath()
        {
            string strPath = string.Empty;
            try
            {
                strPath = ConfigurationManager.AppSettings["LOCAL_DATA_PATH"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }

        public static string GetDefaultStorageFolderPathForPayslip()
        {
            string strPath = string.Empty;
            try
            {
                strPath = ConfigurationManager.AppSettings["ERP_DOCUMENTS_Payslip_FOLDER"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }

        public static string GetEmployeeImagePath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"Employee_Images\");
                strPath = ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetEmployeeAttachmentsImagePath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"Employee_Attachment\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"Employee_Attachment\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetSalesLeadAttachmentPath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"SalesLead_Attachment\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"SalesLead_Attachment\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetSalesEnquiryAttachmentPath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"SalesEnquiry_Attachment\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"SalesEnquiry_Attachment\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetSalesQuotationAttachmentPath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"SalesQuotation_Attachment\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"SalesQuotation_Attachment\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetSalesOrderAttachmentPath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"SalesOrder_Attachment\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"SalesOrder_Attachment\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetInventoryItemImagePath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"Inventory_Item_Images\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"Inventory_Item_Images\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        public static string GetInventoryItemAttachmentsImagePath()
        {
            string strPath = string.Empty;
            try
            {
                //strPath = String.Format("{0}{1}", libERP.Properties.Settings.Default.ERP_DOCUMENTS_FOLDER, @"Inventory_Item_Attachment\");
                strPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["ERP_DOCUMENTS_FOLDER"], @"Inventory_Item_Attachment\");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPath;
        }
        
        public List<SelectListItem> GetAllADMINMasterCategories()
        {
            List<SelectListItem> masterCategories = new List<SelectListItem>();
            try
            {
                masterCategories.Add(new SelectListItem() { ID = (int)APP_ADMIN_CATEGORIES.SUSPECTING_INFO, Description = "Suspecting Information List" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return masterCategories;
        }
        
        #region DATETIME FUNCTIONS
        public static DateTime ConvertToDateTime(string date, string time)
        {
            DateTime dt = DateTime.Now;

            string[] arrDate = date.Split('-');
            string[] arrTime = time.Split(' ');
            string[] arrHHMM = arrTime[0].Split(':');

            arrHHMM[0] = (arrTime[1].ToUpper() == "PM") ? ((int.Parse(arrHHMM[0]) + 12) % 24).ToString() : arrHHMM[0];
            dt = new DateTime(int.Parse(arrDate[2]), int.Parse(arrDate[1]), int.Parse(arrDate[0]), int.Parse(arrHHMM[0]), int.Parse(arrHHMM[1]), 0);

            return dt;

        }
        public static DateTime GetDateTimeFromTime(string time)
        {
            DateTime dt = DateTime.Now;
            try
            {
                string[] arrTime = time.Split(' ');
                string[] arrHHMM = arrTime[0].Split(':');
                arrHHMM[0] = (arrTime[1].ToUpper() == "PM") ? ((int.Parse(arrHHMM[0]) + 12) % 24).ToString() : arrHHMM[0];
                dt = new DateTime(dt.Year, dt.Month, dt.Day, int.Parse(arrHHMM[0]), int.Parse(arrHHMM[1]), 0);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "AppCommon::GetDateTimeFromTime", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public static string GetDurationBetweenDates(DateTime startDateTime, DateTime endDatetime)
        {
            string strDuration = string.Empty;
            try
            {
                strDuration = ((TimeSpan)(startDateTime - endDatetime)).ToString();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "AppCommon::GetDurationBetweenDates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strDuration;
        }
        public static TimeDuration GetTimeDuration(DateTime startDatetime, DateTime endDatetime)
        {
            TimeDuration duration = new TimeDuration();
            DateTime dayStart = DateTime.Now;
            DateTime dayEnd = DateTime.Now;
            int mDays = 0;
            int mHours = 0;
            int mMins = 0;
            try
            {
                int hrs = 0;
                if (startDatetime.Date == endDatetime.Date)
                {
                    dayStart = new DateTime(startDatetime.Year, startDatetime.Month, startDatetime.Day);
                    dayEnd = new DateTime(startDatetime.Year, startDatetime.Month, startDatetime.Day);
                    SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                    mDays = 0;
                    string actualDuration = ((TimeSpan)(endDatetime - startDatetime)).ToString();
                    mHours = int.Parse(actualDuration.Split(':')[0]);
                    mMins = int.Parse(actualDuration.Split(':')[1]);
                    ////hrs = (int)Math.Abs((endDatetime - startDatetime).TotalHours);
                    //if (hrs >= 8)
                    //{
                    //    mDays = 1; mHours = 0; mMins = mns;
                    //}
                    //else
                    //{
                    //    mDays = 0; mHours = hrs;mMins = 0;
                    //}
                    

                }
                else
                {
                    dayStart = new DateTime(startDatetime.Year, startDatetime.Month, startDatetime.Day);
                    dayEnd = new DateTime(startDatetime.Year, startDatetime.Month, startDatetime.Day);
                    SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);

                    hrs = (int)Math.Abs((dayEnd - startDatetime).TotalHours);
                    if (hrs >= 8)
                    {
                        mDays = 1; mHours = 0; mMins = 0;
                    }
                    else
                    {
                        mDays = 0; mHours = hrs;
                    }
                    DateTime leaveDate = startDatetime.AddDays(1);
                    while (leaveDate.Date < endDatetime.Date)
                    {
                        mDays++;
                        leaveDate = leaveDate.AddDays(1);
                    }
                    dayStart = new DateTime(endDatetime.Year, endDatetime.Month, endDatetime.Day);
                    dayEnd = new DateTime(endDatetime.Year, endDatetime.Month, endDatetime.Day);
                    SetShiftStartFromAndToDatetime(ref dayStart, ref dayEnd);
                    hrs = (int)Math.Abs((endDatetime - dayStart).TotalHours);
                    mHours += hrs;
                    if (mHours >= 8)
                    {
                        mDays++; mHours = (mHours - 8);
                    }
                }

                duration = new TimeDuration(mDays, mHours, mMins);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "AppCommon::GetDurationBetweenDates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return duration;
        }
        public static void SetShiftStartFromAndToDatetime(ref DateTime start, ref DateTime end)
        {
            try
            {
                EXCEL_ERP_TESTEntities conn = new EXCEL_ERP_TESTEntities();
                TBL_MP_Admin_Company_Master dbModel = conn.TBL_MP_Admin_Company_Master.FirstOrDefault();
                if (dbModel != null)
                {
                    //format 05:15 PM
                    start = ConvertToDateTime(start.ToString("dd-MM-yyyy"), dbModel.ShiftTimeFrom);
                    end = ConvertToDateTime(end.ToString("dd-MM-yyyy"), dbModel.ShiftTimeTo);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "AppCommon::SetShiftStartFromAndToDatetime", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static List<SelectListItem> GEtAttendanceTypeSelectListItems()
        {
            List<SelectListItem> lstTypes = new List<SelectListItem>();
            try
            {
                lstTypes.Add(new SelectListItem() { ID = (int)ATTENDANCE_TYPE.NONE, Description = "(SELECT)" });
                lstTypes.Add(new SelectListItem() { ID = (int)ATTENDANCE_TYPE.PRESENT, Description = "PRESENT" });
                lstTypes.Add(new SelectListItem() { ID = (int)ATTENDANCE_TYPE.ABSENT, Description = "ABSENT" });
                lstTypes.Add(new SelectListItem() { ID = (int)ATTENDANCE_TYPE.LEAVE, Description = "LEAVE" });
                lstTypes.Add(new SelectListItem() { ID = (int)ATTENDANCE_TYPE.OUT_DOOR, Description = "OUTDOOR" });
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;

                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "AppCommon::GEtAttendanceTypeSelectListItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstTypes;
        }

        public static bool IsSunday(DateTime date)
        {
            bool result = false;
            try
            {
                if (date.ToString("ddd").ToUpper() == "SUN") result = true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public static bool IsSaturday(DateTime date)
        {
            bool result = false;
            try
            {
                if (date.ToString("ddd").ToUpper() == "SAT") result = true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public static bool isSecondSaturday(DateTime date)
        {
            var day = new DateTime(date.Year, date.Month, 1);
            day = FindNext(DayOfWeek.Saturday, day);
            day = FindNext(DayOfWeek.Saturday, day.AddDays(1));
            return day.Date==date.Date;
        }
        public static bool isFourthSaturday(DateTime date)
        {
            var day = new DateTime(date.Year, date.Month, 1);
            day = FindNext(DayOfWeek.Saturday, day);
            day = FindNext(DayOfWeek.Saturday, day.AddDays(1));
            day = FindNext(DayOfWeek.Saturday, day.AddDays(1));
            day = FindNext(DayOfWeek.Saturday, day.AddDays(1));
            return day.Date == date.Date;
        }
        private static DateTime FindNext(DayOfWeek dayOfWeek, DateTime after)
        {
            DateTime day = after;
            while (day.DayOfWeek != dayOfWeek) day = day.AddDays(1);
            return day;
        }
         #endregion
         public static void GeneratePasswordFile()
        {
            try
            {
                EXCEL_ERP_TESTEntities _conn = new EXCEL_ERP_TESTEntities();
                string strLine = string.Empty;
                List<TBL_User_Master> lst = _conn.TBL_User_Master.Where(x => x.IsActive == true).ToList();
                string[] lines = new string[lst.Count];
                int i = 0;
                foreach (TBL_User_Master item in lst)
                {
                    lines[i++] = string.Format("\n{0}\t{1}\t{2}",
                        item.TBL_MP_Master_Employee.EmployeeCode,
                        item.TBL_MP_Master_Employee.EmployeeName,
                        DecryptText(item.LoginPassword));

                }
                System.IO.File.WriteAllLines(@"C:\Users\sachin\Desktop\Passwords.txt", lines);


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "AppCommon::GeneratePasswordFile", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }

   


}
