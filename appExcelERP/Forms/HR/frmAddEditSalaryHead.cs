using appExcelERP.Forms.UserList;
using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.HR
{
    public partial class frmAddEditSalaryHead : Form
    {
        public int SelectedPK_ID { get; set; }
        public int SelectSalaryHeadID { get; set; }

        public frmAddEditSalaryHead()
        {
            InitializeComponent();
        }
        public frmAddEditSalaryHead(int id)
        {
            InitializeComponent();
            this.SelectedPK_ID = id;
        }

        private void frmAddEditSalaryHead_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateSalaryHeadTypeDropDown();
                PopulateSalaryHeadNatureDropDown();
                txtSalaryHead.ReadOnly = true;
                if (this.SelectedPK_ID == 0)
                {
                    txtSalaryHead.Text=
                    txtSequence.Text= String.Empty;
                    cboSalaryHeadType.SelectedIndex = 0;
                    cboSalaryHeadNature.SelectedIndex = 0;
                    chkIsActive.Checked = true;
                }
                else
                {
                    TBl_MP_HR_SalaryHead model = (new ServiceSalaryHead()).GetSalaryHeadDbRecord(this.SelectedPK_ID);
                    if (model != null)
                    {
                        this.SelectSalaryHeadID=model.fK_Usrlst_SH_ID;
                        txtSalaryHead.Text = GetSalaryHeadTypeName(model.fK_Usrlst_SH_ID);
                        txtSequence.Text = model.Sequence.ToString();
                        cboSalaryHeadType.SelectedItem =((List<SelectListItem>)cboSalaryHeadType.DataSource).Where(x=>x.ID== model.fk_Usrlst_HdrType_ID).FirstOrDefault();
                        cboSalaryHeadNature.SelectedItem = ((List<SelectListItem>)cboSalaryHeadNature.DataSource).Where(x => x.ID == model.fk_Usrlst_HdNature_ID).FirstOrDefault();
                        chkIsActive.Checked = model.IsActive;
                        btnAddNewSalaryHead.Visible = false;
                        
                    }
                }


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::frmAddEditSalaryHead_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TBl_MP_HR_SalaryHead model = null;
            ServiceSalaryHead _service = new ServiceSalaryHead();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.SelectedPK_ID == 0)
                {
                    model = new TBl_MP_HR_SalaryHead();
                }
                else
                    model = _service.GetSalaryHeadDbRecord(this.SelectedPK_ID);

                model.fK_Usrlst_SH_ID = SelectSalaryHeadID; 
                model.fk_Usrlst_HdrType_ID = ((SelectListItem)cboSalaryHeadType.SelectedItem).ID;
                model.fk_Usrlst_HdNature_ID = ((SelectListItem)cboSalaryHeadNature.SelectedItem).ID;
                model.Sequence = int.Parse(txtSequence.Text.Trim());
                model.IsActive = chkIsActive.Checked;


                if (this.SelectedPK_ID == 0)
                    this.SelectSalaryHeadID = _service.AddNewSalaryHead(model);
                else
                    _service.UpdatesalaryHead(model);

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region POPULATE DROPDOWNS
        private string GetSalaryHeadTypeName( int headID)
        {
            string strName = string.Empty;
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllSalaryHeads());
                strName = LST.Where(x => x.ID == headID).FirstOrDefault().Description;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::GetSalaryHeadTypeName", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strName;
        }
        private void PopulateSalaryHeadTypeDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllSalaryHeadsType());
                cboSalaryHeadType.DataSource = LST;
                cboSalaryHeadType.DisplayMember = "Description";
                cboSalaryHeadType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::PopulateSalaryHeadTypeDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateSalaryHeadNatureDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllSalaryHeadsNature());
                cboSalaryHeadNature.DataSource = LST;
                cboSalaryHeadNature.DisplayMember = "Description";
                cboSalaryHeadNature.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::PopulateSalaryHeadNatureDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VALIDATIONS
        private void txtSalaryHead_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSalaryHead.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSalaryHead, "Salary Head is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::txtSalaryHead_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboSalaryHeadType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboSalaryHeadType.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboSalaryHeadType, "Select Salary Head Type");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::cboSalaryHeadType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboSalaryHeadNature_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboSalaryHeadNature.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboSalaryHeadNature, "Select salary Head Nature");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::cboSalaryHeadNature_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion
        
        private void btnAddNewSalaryHead_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmADMINUserList frm = new frmADMINUserList();
                frm.Text = "Add new Salary Head";
                frm.ADMINCategoryID = Program.LIST_DEFAULTS.Where(x=>x.ID==(int)APP_DEFAULT_VALUES.SalaryHeadAdminCategoryID).FirstOrDefault().DEFAULT_VALUE;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.SelectSalaryHeadID = frm.UserListID;
                    txtSalaryHead.Text = frm.txtCategoryName.Text;
                   
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditSalaryHead::btnAddNewSalaryHead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
    }
}
