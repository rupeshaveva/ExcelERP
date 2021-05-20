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


using libERP.MODELS;
using libERP.SERVICES.CRM;
using libERP;

namespace appExcelERP.Forms.Masters
{
    public partial class frmAddEditTermsAndCondition : KryptonForm
    {
        public int TermID { get; set; }
        public int CategoryID { get; set; }

        public frmAddEditTermsAndCondition()
        {
            InitializeComponent();
        }
        public frmAddEditTermsAndCondition(int termID)
        {
            InitializeComponent();
            this.TermID = termID;
        }

        private void frmAddEditTermsAndCondition_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescription.Text =  string.Empty;
                chkIsActive.Checked = true;
                PopulateTnCCategoriesDropdown();
                PopulateTnCTitlesDropdown();
                if (this.CategoryID != 0)
                    cboCategories.SelectedItem = ((List<SelectListItem>)cboCategories.DataSource).Where(X => X.ID == this.CategoryID).FirstOrDefault();

                
                this.Text = "TERM & CONDITION - [ADD NEW]";

                if (this.TermID != 0)
                {
                    TBL_MP_Master_TnC objTerm = (new ServiceTermsAndConditions()).GetTermConditionItemDBRecordByID(this.TermID);
                    if (objTerm != null)
                    {
                        txtDescription.Text = objTerm.Term_Description;
                        cboCategories.SelectedItem = ((List<SelectListItem>)cboCategories.DataSource).Where(x => x.ID == objTerm.Term_CategoryID).FirstOrDefault();
                        cboTitles.SelectedItem = ((List<SelectListItem>)cboTitles.DataSource).Where(x => x.ID == objTerm.Term_TitleID).FirstOrDefault();
                        chkIsActive.Checked = objTerm.IsActive;
                    }
                    this.Text = "TERM & CONDITION - [EDIT]";
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::frmAddEditTermsAndCondition_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopulateTnCCategoriesDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceTermsAndConditions()).GetAllActiveTermAndConditionCategories());
                cboCategories.DataSource = LST;
                cboCategories.DisplayMember = "Description";
                cboCategories.ValueMember = "ID";
               

            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::PopulateTnCCategoriesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateTnCTitlesDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceTermsAndConditions()).GetAllActiveTermAndConditionTitles());
                cboTitles.DataSource = LST;
                cboTitles.DisplayMember = "Description";
                cboTitles.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::PopulateTnCTitlesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TBL_MP_Master_TnC dbModel = null;
            try
            {
                errorProvider1.Clear();

                if (this.ValidateChildren())
                {
                    if (this.TermID == 0)
                    {
                        dbModel = new TBL_MP_Master_TnC()
                        {
                            Term_Description = txtDescription.Text.Trim(),
                            Term_TitleID = ((SelectListItem)(cboTitles.SelectedItem)).ID,
                            Term_CategoryID = ((SelectListItem)(cboCategories.SelectedItem)).ID,
                            IsActive = chkIsActive.Checked
                        };
                        this.TermID = (new ServiceTermsAndConditions()).AddNewTermAndCondition(dbModel);
                        if (this.TermID != 0) this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        dbModel = (new ServiceTermsAndConditions()).GetTermConditionItemDBRecordByID(this.TermID);
                        if (dbModel != null)
                        {
                            dbModel.Term_Description = txtDescription.Text.Trim();
                            dbModel.Term_TitleID = ((SelectListItem)(cboTitles.SelectedItem)).ID;
                            dbModel.Term_CategoryID = ((SelectListItem)(cboCategories.SelectedItem)).ID;
                            dbModel.IsActive = chkIsActive.Checked;
                            bool res = (new ServiceTermsAndConditions()).UpdateTermAndCondition(dbModel);
                            if (res) this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDescription.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtDescription, "Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::txtDescription_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCategories_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboCategories.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboCategories, "Category is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::cboCategories_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTitles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboTitles.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboTitles, "titles is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTermsAndCondition::cboTitles_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
    
}
