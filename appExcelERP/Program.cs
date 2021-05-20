using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP.MODELS;
using libERP;
using ComponentFactory.Krypton.Toolkit;
using System.Drawing;
using System.ComponentModel;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.ADMIN;
using System.Net.Mail;
using System.Net;

namespace appExcelERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static USER_SESSION CURR_USER =new USER_SESSION();
        public static List<APP_DEFAULTS> LIST_DEFAULTS = null;
        public static ServiceWhoseWho CONTROL_ACCESS = null;
               
        public static char DefaultStringSeperator = '|';
        public static PaletteModeManager CURRENT_THEME = PaletteModeManager.Office2007Blue;
        public static Color ColorSelected =Color.Blue;


        public static bool AUTO_LOGIN = false;
        public static string TEST_USER_NAME = "";
        public static string TEST_USER_PASSWORD = "";
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (AUTO_LOGIN)
            {
                //TEST_USER_NAME = "";
                //TEST_USER_PASSWORD= "TEST_USER_PASSWORD"
                TEST_USER_NAME = "E00433";//SA
                TEST_USER_PASSWORD = "default";

                //TEST_USER_NAME = "E00368";//PRABHU
                //TEST_USER_PASSWORD = "prabhur@2018";

                //TEST_USER_NAME = "E00001";//LAXMI
                //TEST_USER_PASSWORD = "123";

              //  TEST_USER_NAME = "E00025";//AGM
               // TEST_USER_PASSWORD = "sunilw@2014";

                //TEST_USER_NAME = "E00008";//DESIGN MANAGER
                //TEST_USER_PASSWORD = "cad@2015";

                //TEST_USER_NAME = "E00390";//ABHJIEET
                //TEST_USER_PASSWORD = "abhijitg@2018$";
            }

           // string encPass = AppCommon.DecryptText("9T+g9HRwo8P3YSZXX1//Zw==");

            //DateTime leaveFrom = new DateTime(2019, 04, 15, 08, 45, 0);
            //DateTime leaveTo = new DateTime(2019, 04, 17, 13, 00, 0);
            //TimeDuration duration = AppCommon.GetTimeDuration(leaveFrom, leaveTo);
            //string strduration = duration.Text;
            SetApplicationDefaults();// get all application defaults into memory as list collection
            CONTROL_ACCESS = new ServiceWhoseWho();
            Application.Run(new frmMDI());

        }

        public static void SetApplicationDefaults()
        {
            try
            {
                LIST_DEFAULTS = new List<APP_DEFAULTS>();
                LIST_DEFAULTS.Add(new APP_DEFAULTS() { ID = 0, DEFAULT_VALUE = 0, DESCRIPTION = "faltu", FROM_TABLE = "" });
                LIST_DEFAULTS.AddRange((new ServiceAppDefaults()).GetAllApplicationDefaultSettings());

        
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "Main::SetApplicationDefaults", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SendTestMail()
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sachin.patwardhan@excelgas.com");
                mailMessage.To.Add("sachin.patwardhan@excelgas.com");
                mailMessage.Subject = "Test Subject";
                mailMessage.Body = "Checking auto Email feature";
                SmtpClient smtp = new SmtpClient("smtpout.secureserver.net");
                smtp.Port = 3535;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sachin.patwardhan@excelgas.com", "SachinP#2019");
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
                //smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
               
    }
}
