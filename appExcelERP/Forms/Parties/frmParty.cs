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

using System.ComponentModel.DataAnnotations;
using libERP.SERVICES;
using libERP.MODELS;
using libERP;

namespace appExcelERP.Forms
{
    public partial class frmParty : KryptonForm
    {
        private ServiceUOW _UOM = null;

        public int SelectedID { get; set; }
        public string SelectedPartyType { get; set; }
                
        public frmParty(string partyType)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.SelectedID = 0;
            this.SelectedPartyType = partyType;
        }
        public frmParty(int partyID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.SelectedID = partyID;
        }

        private void frmParty_Load(object sender, EventArgs e)
        {
            try
            {
                switch (this.SelectedPartyType)
                {
                    case "A": this.Text = "Add/EDIT AGENT INFO."; break;
                    case "C": this.Text = "Add/EDIT CUSTOMER INFO."; break;
                    case "S": this.Text = "Add/EDIT SUPPLIER INFO."; break;
                }
                PopulateIndytryTypeDropDown();
                if (this.SelectedID == 0)
                {
                    DoBlanks();
                    txtPartyCode.Text = _UOM.PartiesService.GenerateNewPartyCode(this.SelectedPartyType);
                    cboIndustryType.Focus();
                }
                else
                    ScatterData();
                
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::frmParty_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void PopulateIndytryTypeDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UOM.MasterService.GetAllIndustryTypes());
                cboIndustryType.DataSource = LST;
                cboIndustryType.ValueMember = "ID";
                cboIndustryType.DisplayMember = "Description";
            }
            catch (Exception  ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::PopulateIndytryTypeDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     }
        private void DoBlanks()
        {
            try
            {
                txtPartyCode.Text = txtPartyName.Text = txtWebSite.Text = txtEmail.Text = string.Empty;
                txtGSTNo.Text = txtPANNumber.Text = string.Empty;
                cboIndustryType.SelectedItem = null;
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::DoBlanks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public void ScatterData()
        {
            try
            {
                Tbl_MP_Master_Party model = _UOM.PartiesService.GetPartyByPartyID(this.SelectedID);
                if (model != null)
                {
                    txtPartyCode.Text = model.PartyCode;
                    txtPartyName.Text = model.PartyName;
                    this.SelectedPartyType = model.PartyType;
                    if (model.FK_IndustryType > 0)
                        cboIndustryType.SelectedItem = ((List<SelectListItem>)cboIndustryType.DataSource).Where(x => x.ID == model.FK_IndustryType).FirstOrDefault();

                    txtEmail.Text = model.EmailID;
                    txtWebSite.Text = model.Website;

                    txtPANNumber.Text = model.PANNo;
                    txtGSTNo.Text = model.GSTNO;
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPartyName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtPartyName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtPartyName, "Party Name Can't be left Blnak");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::txtPartyName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    Tbl_MP_Master_Party model = null;
                    if (this.SelectedID == 0)
                    {
                        model = new Tbl_MP_Master_Party();
                        model.PartyCode = txtPartyCode.Text;
                        model.PartyName = txtPartyName.Text;
                        model.PartyType = this.SelectedPartyType;
                        model.FK_IndustryType = ((SelectListItem)cboIndustryType.SelectedItem).ID;

                        model.EmailID = txtEmail.Text;
                        model.Website = txtWebSite.Text;

                        model.GSTNO = txtGSTNo.Text;
                        model.PANNo = txtPANNumber.Text;
                        model.IsActive = true;
                        this.SelectedID = _UOM.PartiesService.AddNewParty(model);

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        model = _UOM.PartiesService.GetPartyByPartyID(this.SelectedID);
                        if (model != null)
                        {
                            model.PartyCode = txtPartyCode.Text;
                            model.PartyName = txtPartyName.Text;
                            model.PartyType = this.SelectedPartyType;
                            model.FK_IndustryType = ((SelectListItem)cboIndustryType.SelectedItem).ID;

                            model.EmailID = txtEmail.Text;
                            model.Website = txtWebSite.Text;

                            model.GSTNO = txtGSTNo.Text;
                            model.PANNo = txtPANNumber.Text;

                            _UOM.PartiesService.UpdateParty(model);

                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmParty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: this.DialogResult = DialogResult.Cancel; break;
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "frmParty::frmParty_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboIndustryType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboIndustryType.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboIndustryType, " Industry type is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmParty::cboIndustryType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() != string.Empty)
                {
                    if (!new EmailAddressAttribute().IsValid(txtEmail.Text.Trim()))
                    {
                        errorProvider1.SetError(txtEmail, "Invalid Email Address entered.");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmParty::txtEmail_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtWebSite_Validating(object sender, CancelEventArgs e)
        {
            //if(txtWebSite.Text.Trim()!=string.Empty)
            //{ 
            //    if (!new UrlAttribute().IsValid(txtWebSite.Text))
            //    {
            //        errorProvider1.SetError(txtWebSite, "Invalid URL entered.");
            //        e.Cancel = true;
            //    }
            //}
        }
    }
}
