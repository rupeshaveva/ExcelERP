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
using libERP;
using libERP.SERVICES;
using libERP.SERVICES.MASTER;
using libERP.MODELS;

namespace appExcelERP.Forms
{
    public partial class frmContact : KryptonForm
    {
        private ServiceUOW _UOM = null;
        public int PartyID { get; set; }
        public int ContactID { get; set; }
        Tbl_MP_Master_PartyContact_Detail model = null;
        

        private ServiceContacts _contactService = null;

        public string PartyName {
            get
            {
                return (new ServiceParties()).GetPartyNameByPartyID(this.PartyID);
            }
        }
        public frmContact()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
        }

        public frmContact(int contactID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.ContactID = contactID;
        }

        private void frmContact_Load(object sender, EventArgs e)
        {
            _contactService = _UOM.ContactService;
            headerGroupContactInfo.ValuesPrimary.Heading = this.PartyName;
            PopulateDepartmentDropdown();
            PopulateDesignationDropdown();
            DoBlanks();
            
            if (this.ContactID > 0)
            {
                ScatterData();
            }

        }

        private void PopulateDepartmentDropdown()
        {

            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UOM.MasterService.GetAllDepartments());
                cboDepartments.DataSource = LST;
                cboDepartments.ValueMember = "ID";
                cboDepartments.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmContact::PopulateDepartmentDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PopulateDesignationDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UOM.MasterService.GetAllDesignation());
                cboDesignations.DataSource = LST;
                cboDesignations.ValueMember = "ID";
                cboDesignations.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmContact::PopulateDesignationDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void DoBlanks()
        {
            txtContactName.Text = txtAddress.Text = txtEmail.Text = txtPhoneNo.Text = txtPhoneNoAlternate.Text = txtMobileNo.Text = txtMobileNoAlternate.Text = txtFAXNo.Text = string.Empty;
            cboDepartments.SelectedIndex = cboDesignations.SelectedIndex = 0;
        }

        public void ScatterData()
        {
            model = _contactService.GetContactByContactID(this.ContactID);
            if(model!=null)
            {
                txtContactName.Text= model.ContactPersoneName;
                txtAddress.Text = model.Address;
                txtPhoneNo.Text = model.TelephoneNo;
                txtPhoneNoAlternate.Text = model.AltTelephoneNo;
                txtMobileNo.Text = model.MobileNo;
                txtMobileNoAlternate.Text = model.AltMobileNo;
                txtFAXNo.Text= model.FaxNo;
                txtEmail.Text = model.EmailID;

                if(model.FK_Department!=null)
                {
                    SelectListItem item= ((List<SelectListItem>)cboDepartments.DataSource).Where(x => x.ID == model.FK_Department).FirstOrDefault();
                    if (item != null)
                    {
                        cboDepartments.SelectedItem = item;
                    }
                }
                if (model.FK_Designation != null)
                {
                    SelectListItem item = ((List<SelectListItem>)cboDesignations.DataSource).Where(x => x.ID == model.FK_Designation).FirstOrDefault();
                    if (item != null)
                    {
                        cboDesignations.SelectedItem = item;
                    }
                }
            }
            
        }

        public void GatherData()
        {
            model = new Tbl_MP_Master_PartyContact_Detail();
            if (this.ContactID > 0)
                model = _contactService.GetContactByContactID(this.ContactID);

            model.ContactPersoneName = txtContactName.Text.Trim();
            model.Address = txtAddress.Text;
            model.TelephoneNo = txtPhoneNo.Text;
            model.AltTelephoneNo = txtPhoneNoAlternate.Text;
            model.MobileNo = txtMobileNo.Text;
            model.AltMobileNo = txtMobileNoAlternate.Text;
            model.FaxNo = txtFAXNo.Text;

            model.EmailID = txtEmail.Text;
            if (cboDepartments.SelectedItem != null)
            {
                model.FK_Department = ((SelectListItem)cboDepartments.SelectedItem).ID;
                model.FK_Department_Text = ((SelectListItem)cboDepartments.SelectedItem).Description;
            }
            if (cboDesignations.SelectedItem != null)
            {
                model.FK_Designation = ((SelectListItem)cboDesignations.SelectedItem).ID;
                model.FK_Designation_Text = ((SelectListItem)cboDesignations.SelectedItem).Description;
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor; 
            try
            {
                if (this.ValidateChildren())
                {

                    GatherData();
                    model.FK_PartyID = this.PartyID;
                    if (this.ContactID == 0)
                    {
                        model.IsActive = true;
                        this.ContactID = _contactService.AddNewContact(model);
                    }
                    else
                        _contactService.UpdateContact(model);

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmContact::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtContactName_Validating(object sender, CancelEventArgs e)
        {
            if (txtContactName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtContactName, "Name can't be left blank.");
                e.Cancel = true;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() != string.Empty)
            {
                if (!new EmailAddressAttribute().IsValid(txtEmail.Text))
                {
                    errorProvider1.SetError(txtEmail, "Invalid Email Address entered.");
                    e.Cancel = true;
                }
            }

            
        }

        private void txtMobileNo_Validating(object sender, CancelEventArgs e)
        {
            if (!txtMobileNo.Text.All(Char.IsDigit))
            {
                errorProvider1.SetError(txtMobileNo, "Enter Digits only [0-9]");
                e.Cancel = true;
                return;
            }
            //if (txtMobileNo.Text.Trim().Length != 10)
            //{
            //    errorProvider1.SetError(txtMobileNo, "Enter Valid 10 Digit Mobile number ex. 9039030409");
            //    e.Cancel = true;
            //    return;
            //}
            
        }

        private void txtMobileNoAlternate_Validating(object sender, CancelEventArgs e)
        {
            if(txtMobileNoAlternate.Text.Trim()!=string.Empty)
            { 
                if (!txtMobileNoAlternate.Text.All(Char.IsDigit))
                {
                    errorProvider1.SetError(txtMobileNoAlternate, "Enter Digits only [0-9]");
                    e.Cancel = true;
                    return;
                }
                if (txtMobileNoAlternate.Text.Trim().Length != 10)
                {
                    errorProvider1.SetError(txtMobileNoAlternate, "Enter Valid 10 Digit Mobile number");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void cboDesignations_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboDesignations.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboDesignations, "Company Name is Mandatory");
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmContact::cboDesignations_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cboDepartments_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboDepartments.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboDepartments, "Company Name is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmContact::cboDesignations_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
