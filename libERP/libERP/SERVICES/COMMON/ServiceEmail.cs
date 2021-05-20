
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.COMMON
{
    public class ServiceEmail
    {
        public event UpdateProgressEventHandler UpdateProgressed;

        protected virtual void OnUpdateProgressed(ProgressEventArguementModel e)
        {
            UpdateProgressed(this, e);
        }

        public bool MailSent { get; set; }
        public string EmailResultText { get; set; }

        public async Task<bool> SendScheduleCallCreatedEmailNotification(int fromEmpID,String msgFrom,string msgTo, string Subject, string msgBody)
        {
            MailMessage mailMessage = new MailMessage();
            string strPassword = ServiceEmployee.GetEmailPasswordForEmployee(fromEmpID);
            string strEmailAddress = ServiceEmployee.GetEmployeeEmailByID(fromEmpID);
            string strEmpName = ServiceEmployee.GetEmployeeNameByID(fromEmpID);
            if (strPassword == string.Empty)
            {
                MessageBox.Show("You cannot send Emails, unless you set your valid Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!new EmailAddressAttribute().IsValid(strEmailAddress))
            {
                MessageBox.Show("It appears that you have not set your Email Address in the Employee database or is Invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            mailMessage.From = new MailAddress(strEmailAddress, strEmpName);
            foreach (var address in msgTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (new EmailAddressAttribute().IsValid(address))
                    mailMessage.To.Add(address);
            }
            if (mailMessage.To.Count == 0)
            {
                MessageBox.Show("Invalid number of Recipients or Invalid Email Address", "Terminating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            mailMessage.Subject = Subject;
            mailMessage.Body = msgBody;
            mailMessage.IsBodyHtml = false;
            //if (this.AttachedFiles.Count > 0)
            //{
            //    foreach (KeyValuePair<string, string> pair in AttachedFiles)
            //    {
            //        Attachment attachment = new Attachment(pair.Value);
            //        if (attachment != null)
            //        {
            //            mailMessage.Attachments.Add(attachment);
            //        }
            //    }
            //}

            //SmtpClient smtp = new SmtpClient(Properties.Settings.Default.EMAIL_SERVER.ToString());
            //smtp.Port = int.Parse(Properties.Settings.Default.EMAIL_PORT.ToString());
            //smtp.Credentials = new NetworkCredential(strEmailAddress, strPassword);
            //smtp.EnableSsl = Properties.Settings.Default.EMAIL_ENABLE_SSL;

            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["EMAIL_SERVER"].ToString());
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["EMAIL_PORT"].ToString());
            smtp.Credentials = new NetworkCredential(strEmailAddress, strPassword);
            smtp.EnableSsl = (ConfigurationManager.AppSettings["EMAIL_ENABLE_SSL"].ToString()=="True")? true : false;

            await smtp.SendMailAsync(mailMessage);




            return true;

        }

        public async Task<bool> SendEmail(int fromEmpID, String msgFrom, string msgTo, string Subject, string msgBody)
        {
            MailMessage mailMessage = new MailMessage();
            string strPassword = ServiceEmployee.GetEmailPasswordForEmployee(fromEmpID);
            string strEmailAddress = ServiceEmployee.GetEmployeeEmailByID(fromEmpID);
            string strEmpName = ServiceEmployee.GetEmployeeNameByID(fromEmpID);
            if (strPassword == string.Empty)
            {
                MessageBox.Show("You cannot send Emails, unless you set your valid Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
           
            if (!new EmailAddressAttribute().IsValid(strEmailAddress))
            {
                MessageBox.Show("It appears that you have not set your Email Address in the Employee database or is Invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            mailMessage.From = new MailAddress(strEmailAddress, strEmpName);
            foreach (var address in msgTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (new EmailAddressAttribute().IsValid(address))
                    mailMessage.To.Add(address);
            }
            if (mailMessage.To.Count == 0)
            {
                MessageBox.Show("Invalid number of Recipients or Invalid Email Address", "Terminating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            mailMessage.Subject = Subject;
            mailMessage.Body = msgBody;
            mailMessage.IsBodyHtml = false;

            //SmtpClient smtp = new SmtpClient(Properties.Settings.Default.EMAIL_SERVER.ToString());
            //smtp.Port = int.Parse(Properties.Settings.Default.EMAIL_PORT.ToString());
            //smtp.Credentials = new NetworkCredential(strEmailAddress, strPassword);
            //smtp.EnableSsl = Properties.Settings.Default.EMAIL_ENABLE_SSL;
            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["EMAIL_SERVER"].ToString());
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["EMAIL_PORT"].ToString());
            smtp.Credentials = new NetworkCredential(strEmailAddress, strPassword);
            smtp.EnableSsl = (ConfigurationManager.AppSettings["EMAIL_ENABLE_SSL"].ToString() == "True") ? true : false;



            await smtp.SendMailAsync(mailMessage);
            return true;

        }

        void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.MailSent = false;
                this.EmailResultText = "Email sending cancelled ";
            }
            else if (e.Error != null)
            {
                this.MailSent = false;
                this.EmailResultText = e.Error.Message;
            }
            else
            {
                this.MailSent = true;
                this.EmailResultText = "Mail Sent Successfully";
            }

            ProgressEventArguementModel args = new ProgressEventArguementModel();
            args.Percentage = 100;
            args.Message = EmailResultText;
            args.ID = 0;
            args.HasError = !MailSent;
            OnUpdateProgressed(args);
        }

    }
}
