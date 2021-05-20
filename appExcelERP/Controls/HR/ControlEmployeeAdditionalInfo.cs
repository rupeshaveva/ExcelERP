using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;
using libERP.MODELS;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeAdditionalInfo : UserControl
    {
        public int SelectedEmployeeID { get; set; }
        public int SelectedEmployeeMedicalID { get; set; }
        public EmployeeAdditionalInfoModel SelectedModel { get; set; }

        public ControlEmployeeAdditionalInfo()
        {
            InitializeComponent();
        }
        private void ControlEmployeeAdditionalInfo_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
              
                PopulateVisaType();
              
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::ControlEmployeeAdditionalInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void SetReadOnly()
        {
            try
            {
                btnAddNewMedicalInfo.Enabled = btnEditMedicalInfo.Enabled = btnUpdateInfo.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void PopulateAdditonalInfo()
        {
            try
            {
                DoBlank();
                gridMedicaInfo.DataSource = null;
                SelectedModel = (new ServiceEmployee()).GetEmployeeAdditonalAndMedicalInfo(this.SelectedEmployeeID);
                if (SelectedModel != null)
                {
                    txtNationality.Text = SelectedModel.Nationality;
                    txtUniqueIDNo.Text = SelectedModel.AADHAR_NO;
                    txtLicenceNo.Text = SelectedModel.LicenceNo;
                    txtPassportNo.Text = SelectedModel.PassportNo;
                    txtVisaNo.Text = SelectedModel.VisaNo;
                    txtWorkPermit.Text = SelectedModel.WorkPermitNo;
                    txtWorkPermitType.Text = SelectedModel.WorkPermitType;

                    //FOR LICENCE INFO
                    if (SelectedModel.LicenceIssueDate == null)
                        dtLicenceIssueDate.Checked = false;
                    else
                        dtLicenceIssueDate.Value = (DateTime)SelectedModel.LicenceIssueDate;

                    if (SelectedModel.LicenceExpiryDate == null)
                        dtLicenceExpiryDate.Checked = false;
                    else
                        dtLicenceExpiryDate.Value = (DateTime)SelectedModel.LicenceExpiryDate;

                    //FOR PASSPORT INFO
                    if (SelectedModel.PassportIssueDate == null)
                        dtPassportIssueDate.Checked = false;
                    else
                        dtPassportIssueDate.Value = (DateTime)SelectedModel.PassportIssueDate;

                    if (SelectedModel.PassportExpiryDate == null)
                        dtPassportExpiryDate.Checked = false;
                    else
                        dtPassportExpiryDate.Value = (DateTime)SelectedModel.PassportExpiryDate;

                    //FOR VISA INFO
                    if (SelectedModel.VisaIssueDate == null)
                        dtVisaIssueDate.Checked = false;
                    else
                        dtVisaIssueDate.Value = (DateTime)SelectedModel.VisaIssueDate;

                    if (SelectedModel.VisaExpiryDate == null)
                        dtVisaExpiryDate.Checked = false;
                    else
                        dtVisaExpiryDate.Value = (DateTime)SelectedModel.VisaExpiryDate;

                    //FOR WORK PERMIT INFO
                    if (SelectedModel.WorkPermitIssueDate == null)
                        dtWorkPermitIssueDate.Checked = false;
                    else
                        dtWorkPermitIssueDate.Value = (DateTime)SelectedModel.WorkPermitIssueDate;
                    if (SelectedModel.WorkPermitExpiryDate == null)
                        dtWorkPermitExpiryDate.Checked = false;
                    else
                        dtWorkPermitExpiryDate.Value = (DateTime)SelectedModel.WorkPermitExpiryDate;

                    PopulateMedicalInfoGrid();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::PopulateAdditonalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DoBlank()
        {
            try
            {
                txtNationality.Text = txtUniqueIDNo.Text = txtLicenceNo.Text =  txtPassportNo.Text = txtVisaNo.Text = txtWorkPermit.Text =  txtWorkPermitType.Text = string.Empty;
                dtLicenceIssueDate.Checked = dtLicenceExpiryDate.Checked = dtPassportIssueDate.Checked = dtPassportExpiryDate.Checked = 
                dtVisaIssueDate.Checked = dtVisaExpiryDate.Checked = dtWorkPermitIssueDate.Checked = dtWorkPermitExpiryDate.Checked = false;
            }
            catch (Exception ex) 
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::DoBlank", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PopulateVisaType()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllVisaType());
                cboVisaType.DataSource = LST;
                cboVisaType.DisplayMember = "Description";
                cboVisaType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::PopulateVisaType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewMedicalInfo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditMedicalInfo frm = new frmAddEditMedicalInfo();
                frm.EmployeeID = this.SelectedEmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SelectedModel.MedicalInfo = (new ServiceEmployee()).GetEmployeeMedicalInfoDbRecordsList(this.SelectedEmployeeMedicalID);
                    PopulateMedicalInfoGrid();
                }
            }
            catch (Exception ex)
            {
                
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::btnAddNewMedicalInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnEditMedicalInfo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditMedicalInfo frm = new frmAddEditMedicalInfo(this.SelectedEmployeeMedicalID);
                frm.EmployeeID = this.SelectedEmployeeID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SelectedModel.MedicalInfo = (new ServiceEmployee()).GetEmployeeMedicalInfoDbRecordsList(this.SelectedEmployeeMedicalID);
                    PopulateMedicalInfoGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::btnEditMedicalInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (!this.ValidateChildren()) return;
                
                    SelectedModel = (new ServiceEmployee()).GetEmployeeAdditonalAndMedicalInfo(this.SelectedEmployeeID);
                SelectedModel.Nationality = txtNationality.Text;
                SelectedModel.AADHAR_NO = txtUniqueIDNo.Text;
                SelectedModel.LicenceNo = txtLicenceNo.Text;

                if (dtLicenceIssueDate.Checked)
                    SelectedModel.LicenceIssueDate = dtLicenceIssueDate.Value;
                else
                    SelectedModel.LicenceIssueDate = null;

                if (dtLicenceExpiryDate.Checked)
                    SelectedModel.LicenceExpiryDate = dtLicenceExpiryDate.Value;
                else
                    SelectedModel.LicenceExpiryDate = null;

                if (dtPassportIssueDate.Checked)
                    SelectedModel.PassportIssueDate = dtPassportIssueDate.Value;
                else
                    SelectedModel.PassportIssueDate = null;


                SelectedModel.PassportNo = txtPassportNo.Text;

                if (dtPassportExpiryDate.Checked)
                    SelectedModel.PassportExpiryDate = dtPassportExpiryDate.Value;
                else
                    SelectedModel.PassportExpiryDate = null;

              
                SelectedModel.VisaTypeInfo = ((SelectListItem)cboVisaType.SelectedItem);
                SelectedModel.VisaNo = txtVisaNo.Text;

                if (dtVisaIssueDate.Checked)
                    SelectedModel.VisaIssueDate = dtVisaIssueDate.Value;
                else
                    SelectedModel.VisaIssueDate = null;

                if (dtVisaExpiryDate.Checked)
                    SelectedModel.VisaExpiryDate = dtVisaExpiryDate.Value;
                else
                    SelectedModel.VisaExpiryDate = null;
              
                SelectedModel.WorkPermitType = txtWorkPermitType.Text;
                SelectedModel.WorkPermitNo = txtWorkPermit.Text;

                if (dtWorkPermitIssueDate.Checked)
                    SelectedModel.WorkPermitIssueDate = dtWorkPermitIssueDate.Value;
                else
                    SelectedModel.WorkPermitIssueDate = null;

                if (dtWorkPermitExpiryDate.Checked)
                    SelectedModel.WorkPermitExpiryDate = dtWorkPermitExpiryDate.Value;
                else
                    SelectedModel.WorkPermitExpiryDate = null;
            

                //fill additional info properties with the vaue from UI controsl

                bool res = (new ServiceEmployee()).SetEmployeeAdditonalInfo(SelectedModel);
                if (res)
                {
                    string strMessage = string.Format("Additional Information of {0} Updated", SelectedModel.EmployeeFullName);
                    MessageBox.Show(strMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::btnUpdateInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PopulateMedicalInfoGrid()
        {
            try
            {
                gridMedicaInfo.DataSource = (new ServiceEmployee()).GetEmployeeMedicalInfoList(this.SelectedEmployeeID);
                gridMedicaInfo.Columns["ID"].Visible =
                gridMedicaInfo.Columns["DescriptionToUpper"].Visible =
                gridMedicaInfo.Columns["IsActive"].Visible = false;
                gridMedicaInfo.Columns["Code"].Width = (int)(gridMedicaInfo.Width * .3);
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::PopulateMedicalInfoGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridMedicaInfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                this.SelectedEmployeeMedicalID = (int)gridMedicaInfo.Rows[e.RowIndex].Cells["ID"].Value;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::gridMedicaInfo_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridMedicaInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in gridMedicaInfo.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridMedicaInfo.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridMedicaInfo.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::gridMedicaInfo_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region VALIDATION
        private void dtPassportIssueDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtPassportNo.Text.Trim() != string.Empty)
                {
                    if (!dtPassportIssueDate.Checked)
                    {
                        errorProvider1.SetError(lblPassportIssueDate, "Passport Issue Date is mandatory");
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtPassportIssueDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtLicenceIssueDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtLicenceNo.Text.Trim() != string.Empty)
                {
                    if (!dtLicenceIssueDate.Checked)
                    {
                        errorProvider1.SetError(lblLicenceIssueDate, "Licence Issue Date is mandatory");
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtLicenceIssueDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtLicenceExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtLicenceNo.Text.Trim() != string.Empty)
                {
                    if (!dtLicenceExpiryDate.Checked)
                    {
                        errorProvider1.SetError(lblLicenceExpiryDate, "Licence Expiry Date is Mandatory");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (dtLicenceIssueDate.Value >= dtLicenceExpiryDate.Value)
                        {
                            errorProvider1.SetError(lblLicenceExpiryDate, "Expiry date is never greater than Issueing Date");
                            e.Cancel = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtLicenceExpiryDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtPassportExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtPassportNo.Text.Trim() != string.Empty)
                {
                    if (!dtPassportExpiryDate.Checked)
                    {
                        errorProvider1.SetError(lblPassportExpiryDate, "Passport Expiry Date is Mandatory");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (dtPassportIssueDate.Value >= dtPassportExpiryDate.Value)
                        {
                            errorProvider1.SetError(lblPassportExpiryDate, "Expiry date is never greater than Issueing Date");
                            e.Cancel = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtPassportExpiryDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboVisaType_Validating(object sender, CancelEventArgs e)
        {
            if(txtVisaNo.Text.Trim()!= String.Empty)
            {
                try
                {
                    int selID = ((SelectListItem)cboVisaType.SelectedItem).ID;
                    if (selID == 0)
                    {
                        errorProvider1.SetError(lblVisaType, "Visa Type is Mandatory");
                        e.Cancel = true;
                    }
                }
                catch (Exception ex)
                {

                    string errMessage = ex.Message;
                    if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                    MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::cboVisaType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private void txtVisaNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboVisaType.SelectedIndex != 0)
                {
                    if (txtVisaNo.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(lblVisaNo, "Visa No i mandatory");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::txtVisaNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtVisaIssueDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtVisaNo.Text.Trim() != string.Empty)
                {
                    if (!dtVisaIssueDate.Checked)
                    {
                        errorProvider1.SetError(lblVisaIssueDate, "Visa Issue Date is mandatory");
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtVisaIssueDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtVisaExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtVisaNo.Text.Trim() != string.Empty)
                {
                    if (!dtVisaExpiryDate.Checked)
                    {
                        errorProvider1.SetError(lblVisaExpiryDate, "Visa Expiry Date is Mandatory");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (dtVisaIssueDate.Value >= dtVisaExpiryDate.Value)
                        {
                            errorProvider1.SetError(lblVisaExpiryDate, "Expiry date is never greater than Issueing Date");
                            e.Cancel = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtVisaExpiryDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtWorkPermit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtWorkPermitType.Text.Trim() != string.Empty)
                {
                    if (txtWorkPermit.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(lblWorkPermit, "Work permit is mandatory");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::txtWorkPermit_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtWorkPermitIssueDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtWorkPermitType.Text.Trim() != string.Empty)
                {
                    if (!dtWorkPermitIssueDate.Checked)
                    {
                        errorProvider1.SetError(lblWorkPermitIssueDate, "Work Permit Issue Date is mandatory");
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtWorkPermitIssueDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtWorkPermitExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtWorkPermitType.Text.Trim() != string.Empty)
                {
                    if (!dtWorkPermitExpiryDate.Checked)
                    {
                        errorProvider1.SetError(lblWorkPermitExpiryDate, "Work Permit Expiry Date is Mandatory");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (dtWorkPermitIssueDate.Value >= dtWorkPermitExpiryDate.Value)
                        {
                            errorProvider1.SetError(lblWorkPermitExpiryDate, "Expiry date is never greater than Issueing Date");
                            e.Cancel = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::dtWorkPermitExpiryDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtUniqueIDNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtUniqueIDNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblUniqueIDNo, "AADHAR NO iS mandatory");
                    e.Cancel = true;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::txtUniqueIDNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLicenceNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (dtLicenceIssueDate.Checked && dtLicenceExpiryDate.Checked)
                {
                    if (txtLicenceNo.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(lblLicenceNo, "Please enter the Licence No");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::txtLicenceNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPassportNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (dtPassportIssueDate.Checked && dtPassportExpiryDate.Checked)
                {
                    if (txtPassportNo.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(lblPassportNo, "Please enter the Passport No");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAdditionalInfo::txtPassportNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion

         }
}
