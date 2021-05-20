using libERP;
using libERP.SERVICES;
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
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms
{
    public partial class frmGenerateParties : KryptonForm
    {
        public frmGenerateParties()
        {
            InitializeComponent();
        }

        private void frmGenerateParties_Load(object sender, EventArgs e)
        {

        }

        private void frmGenerateParties_Activated(object sender, EventArgs e)
        {
            
        }
        private void GeneratePartiesForSalesLead()
        {
            ServiceSalesLead _leadService = new ServiceSalesLead();
            ServiceParties _partyService = new ServiceParties();
            ServiceContacts _contactService = new ServiceContacts();

            List<TBL_MP_CRM_SM_SalesLead> dbLeads = _leadService.GetAllSalesLeadDBItems();
            if (dbLeads == null) return;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0; progressBar1.Maximum = dbLeads.Count;

            int progressVAl = 0;
            
            foreach (TBL_MP_CRM_SM_SalesLead lead in dbLeads)
            {
                lblTitle.Text = string.Format("{0} of {1}\n\n{2} {3}\n{4}",progressVAl+1, progressBar1.Maximum,  lead.LeadNo, lead.LeadDate.ToString("dd MMM yyyy"), lead.LeadName);

                Tbl_MP_Master_Party party = _partyService.GetPartyByPartyName(lead.LeadName);
                if (party != null)
                {
                    lead.FK_PartyID = party.PK_PartyId;
                    _leadService.UpdateSalesLeadMasterInfo(lead);
                    lblTitle.Text += string.Format("\nExisting Party found. Customer update in SalesLead PartyID:{0}",lead.FK_PartyID);
                }
                else
                {
                    party = new Tbl_MP_Master_Party()
                    {
                        PartyType = "C",
                        FK_PartyType = 2,
                        PartyName = lead.LeadName,
                        FK_IndustryType = 8003,
                        EmailID = lead.LeadEmailID,
                        Website = lead.LeadWebsite,
                        IsActive=true
                    };

                    int partyID = _partyService.AddNewParty(party);
                    Tbl_MP_Master_PartyContact_Detail contact = new Tbl_MP_Master_PartyContact_Detail()
                    {
                        
                        FK_PartyID=partyID,
                        ContactPersoneName = lead.ContactPersone,
                        Address= lead.LeadAddress,
                        EmailID= lead.LeadEmailID,
                        TelephoneNo= lead.LeadPhoneNo,
                        MobileNo= lead.LeadMobileNo,
                        FaxNo= lead.LeadFAXNo,
                        IsActive=true,
                    };
                    _contactService.AddNewContact(contact);
                    lblTitle.Text += "\n\nNew Party & Contact created.";
                }
                progressVAl++;
                progressBar1.Value = progressVAl;
                Application.DoEvents();
            }
            

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GeneratePartiesForSalesLead();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGenerateParties_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: this.Close();break;
            }
        }
    }
}
