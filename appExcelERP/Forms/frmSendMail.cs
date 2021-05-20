using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES;
using libERP;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.IO;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.CRM;
using libERP.MODELS.CRM;
using System.Configuration;

namespace appExcelERP.Forms
{
    public partial class frmSendMail : Form
    {
        private ServiceUOW _UNIT;
        public APP_ENTITIES SOURCE_ENTITY { get; set; }
        public int SOURCE_ENTITY_ID { get; set; }

        public APP_ENTITIES SELECTED_ENTITY { get; set; }

        public Dictionary<string,string> AttachedFiles { get; set; }

        public frmSendMail()
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            lblParties.Tag = APP_ENTITIES.PARTIES;
            lblEmployees.Tag= APP_ENTITIES.EMPLOYEES;
            lblContacts.Tag = APP_ENTITIES.CONTACTS;
            lblAssociates.Tag = APP_ENTITIES.ASSOCIATES_AND_CONTACTS;

            this.AttachedFiles = new Dictionary<string, string>();
        }
              
        private void ReceipentSelectionLink_Clicked(object sender, EventArgs e)
        {
            try
            {
                SELECTED_ENTITY = (APP_ENTITIES)((KryptonLinkLabel)sender).Tag;
                frmGridMultiSelect frm = new frmGridMultiSelect(SELECTED_ENTITY, SOURCE_ENTITY,SOURCE_ENTITY_ID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindingList<MultiSelectListItem> selectedIDs = frm.SelectedItems;

                    if (selectedIDs != null)
                    {
                        string strAddresses = string.Empty;
                        if (txtMailTo.Text.Trim() != string.Empty)
                        {
                            if (!txtMailTo.Text.Trim().EndsWith(";"))
                            {
                                txtMailTo.Text += ";";
                            }
                        }
                        switch (SELECTED_ENTITY)
                        {
                            case APP_ENTITIES.EMPLOYEES:
                                foreach (MultiSelectListItem item in selectedIDs)
                                {
                                    
                                    TBL_MP_Master_Employee emp = _UNIT.AppDBContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == item.ID).FirstOrDefault();
                                    if (emp != null)
                                    {
                                        if (emp.EmailAddress.Trim() != string.Empty)
                                        {
                                            if(!txtMailTo.Text.Contains(emp.EmailAddress))
                                                txtMailTo.Text += emp.EmailAddress + ";";
                                        }
                                    }
                                }
                                break;
                            case APP_ENTITIES.CONTACTS:
                                foreach (MultiSelectListItem item in selectedIDs)
                                {
                                    Tbl_MP_Master_PartyContact_Detail contact = _UNIT.AppDBContext.Tbl_MP_Master_PartyContact_Detail.Where(x => x.PK_PartyContactDetails == item.ID).FirstOrDefault();
                                    if (contact != null)
                                    {
                                        if (contact.EmailID.Trim() != string.Empty)
                                        {
                                            if (!txtMailTo.Text.Contains(contact.EmailID))
                                                txtMailTo.Text += contact.EmailID + ";";
                                        }
                                    }
                                }
                                break;
                            case APP_ENTITIES.PARTIES:
                                foreach (MultiSelectListItem item in selectedIDs)
                                {
                                    Tbl_MP_Master_Party party = _UNIT.AppDBContext.Tbl_MP_Master_Party.Where(x => x.PK_PartyId == item.ID).FirstOrDefault();
                                    if (party != null)
                                    {
                                        if (party.EmailID.Trim() != string.Empty)
                                        {
                                            if (!txtMailTo.Text.Contains(party.EmailID))
                                                txtMailTo.Text += party.EmailID + ";";
                                        }
                                    }
                                }
                                break;
                            case APP_ENTITIES.ASSOCIATES_AND_CONTACTS:
                                foreach (MultiSelectListItem item in selectedIDs)
                                {
                                    switch (item.EntityType)
                                    {
                                        case APP_ENTITIES.EMPLOYEES:
                                            TBL_MP_Master_Employee emp = _UNIT.AppDBContext.TBL_MP_Master_Employee.Where(x => x.PK_EmployeeId == item.ID).FirstOrDefault();
                                            if (emp != null)
                                            {
                                                if (emp.EmailAddress.Trim() != string.Empty)
                                                {
                                                    if (!txtMailTo.Text.Contains(emp.EmailAddress))
                                                        txtMailTo.Text += emp.EmailAddress + ";";
                                                }
                                            }
                                            break;
                                        case APP_ENTITIES.PARTIES:
                                            Tbl_MP_Master_Party party = _UNIT.AppDBContext.Tbl_MP_Master_Party.Where(x => x.PK_PartyId == item.ID).FirstOrDefault();
                                            if (party != null)
                                            {
                                                if (party.EmailID.Trim() != string.Empty)
                                                {
                                                    if (!txtMailTo.Text.Contains(party.EmailID))
                                                        txtMailTo.Text += party.EmailID + ";";
                                                }
                                            }
                                            break;
                                        case APP_ENTITIES.CONTACTS:
                                            Tbl_MP_Master_PartyContact_Detail contact = _UNIT.AppDBContext.Tbl_MP_Master_PartyContact_Detail.Where(x => x.PK_PartyContactDetails == item.ID).FirstOrDefault();
                                            if (contact != null)
                                            {
                                                if (contact.EmailID.Trim() != string.Empty)
                                                {
                                                    if (!txtMailTo.Text.Contains(contact.EmailID))
                                                        txtMailTo.Text += contact.EmailID + ";";
                                                }
                                            }
                                            break;

                                    }
                                }
                                break;
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSendMail::ReceipentSelectionLink_Clicked");
            }
            

        }

        private void frmSendMail_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtMailTo_Validating(object sender, CancelEventArgs e)
        {
            if (txtMailTo.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtMailTo, "Not a vali emal Address");
                e.Cancel = true;
            }
        }

        private void txtSubject_Validating(object sender, CancelEventArgs e)
        {
            if (txtSubject.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtSubject, "Subject can't be left blank.");
                e.Cancel = true;
            }
        }

        private void txtMessage_Validating(object sender, CancelEventArgs e)
        {
            if (txtMessage.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtMessage, "Message can't be left blank.");
                e.Cancel = true;
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.ValidateChildren())
                {
                    MailMessage mailMessage = new MailMessage();
                    string strPassword = ServiceEmployee.GetEmailPasswordForEmployee(Program.CURR_USER.EmployeeID);
                    if (strPassword == string.Empty)
                    {
                        frmSetPassword frm = new frmSetPassword(PASSWORD_TYPE.EMAIL_PASSWORD);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            strPassword = frm.txtPassword.Text.Trim();
                        }
                        else
                        {
                            MessageBox.Show("You cannot send Emails, unless you set your valid Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (!new EmailAddressAttribute().IsValid(Program.CURR_USER.EmailAddress))
                    {
                        MessageBox.Show("It appears that you have not set your Email Address in the Employee database or is Invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mailMessage.From = new MailAddress(Program.CURR_USER.EmailAddress);
                    foreach (var address in txtMailTo.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {

                        if (new EmailAddressAttribute().IsValid(address))
                            mailMessage.To.Add(address);
                    }
                    if (mailMessage.To.Count == 0)
                    {
                        MessageBox.Show("Invalid number of Recipients found. orInvalid Email Address","Terminating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    mailMessage.Subject = txtSubject.Text;
                    mailMessage.Body = txtMessage.Text;
                    mailMessage.IsBodyHtml = false;
                    if (this.AttachedFiles.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> pair in AttachedFiles)
                        {
                            Attachment attachment = new Attachment(pair.Value);
                            if (attachment != null)
                            {
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }

                    //SmtpClient smtp = new SmtpClient(Properties.Settings.Default.EMAIL_SERVER.ToString());
                    //smtp.Port =int.Parse(Properties.Settings.Default.EMAIL_PORT.ToString());
                    //smtp.Credentials = new NetworkCredential(Program.CURR_USER.EmailAddress, strPassword);
                    //smtp.EnableSsl = Properties.Settings.Default.EMAIL_ENABLE_SSL;

                    SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["EMAIL_SERVER"].ToString());
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["EMAIL_PORT"].ToString());
                    smtp.Credentials = new NetworkCredential(Program.CURR_USER.EmailAddress, strPassword);
                    smtp.EnableSsl = (ConfigurationManager.AppSettings["EMAIL_ENABLE_SSL"].ToString() == "True") ? true : false;


                    smtp.SendAsync(mailMessage, mailMessage.Subject);
                    smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmSendMail::btnSendMail_Click", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Email sending cancelled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Email sent sucessfully!");
                this.DialogResult = DialogResult.OK; 
            }
        }

        private void frmSendMail_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            PopulateAttachmentGrid();
            PopulateMessageBodyDefault();
        }
        private void PopulateMessageBodyDefault()
        {
            switch (this.SOURCE_ENTITY)
            {
                case APP_ENTITIES.SALES_LEAD:
                    LeadMasterInfoModel model = (new ServiceSalesLead()).GetLeadMasterInfo(this.SOURCE_ENTITY_ID);
                    if (model != null)
                    {
                        txtMessage.Text = string.Format("\n\nLead : {0} dt. {1}", model.LeadNo, model.LeadDate.Value.ToString("dd MMM yyyy"));
                        txtMessage.Text += string.Format("\nParty : {0} ", model.LeadName);
                        txtMessage.Text += string.Format("\nRequirement:\n{0} ", model.LeadRequirement);
                    }
                    break;
                case APP_ENTITIES.SALES_ENQUIRY:
                    TBL_MP_CRM_SalesEnquiry dbEnquiry = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(this.SOURCE_ENTITY_ID);
                    if (dbEnquiry != null)
                    {
                        txtMessage.Text = string.Format("\n\nEnquiry : {0} dt. {1}", dbEnquiry.SalesEnquiry_No, dbEnquiry.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                        txtMessage.Text += string.Format("\nParty : {0} ", dbEnquiry.Tbl_MP_Master_Party.PartyName);
                        txtMessage.Text += string.Format("\nRequirement:\n{0} ", dbEnquiry.General_Description);
                    }
                    break;
            }
        }
        private void PopulateAttachmentGrid()
        {
            gridAttachments.DataSource = this.AttachedFiles.ToList();
            gridAttachments.Columns["Value"].Visible = false;
        }

        private void btnAddNewAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                if (this.AttachedFiles == null) AttachedFiles = new Dictionary<string, string>();
                AttachedFiles.Add(Path.GetFileName(fileDialog.FileName), fileDialog.FileName);
                PopulateAttachmentGrid();
            }
        }

        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            if (gridAttachments.SelectedRows.Count > 0)
            {
                string strKey = gridAttachments.SelectedRows[0].Cells["Key"].Value.ToString();
                this.AttachedFiles.Remove(strKey);
                PopulateAttachmentGrid();
            }
        }
    }
}
