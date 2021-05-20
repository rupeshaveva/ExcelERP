using libERP;
using libERP.SERVICES;
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

namespace appExcelERP.Forms.UserList
{
    public partial class frmMasterCategory : Form
    {
        public int MASTERCategoryID { get; set; }
        public frmMasterCategory()
        {
            InitializeComponent();
            MASTERCategoryID = 0;
        }
        public frmMasterCategory(int categoryIDtoEDIT)
        {
            InitializeComponent();
            MASTERCategoryID = categoryIDtoEDIT;
        }

        private void frmMasterCategory_Load(object sender, EventArgs e)
        {
            try
            {
                if (MASTERCategoryID != 0)//case of editing master category
                {
                    TBL_MP_Master_Category dbModel = (new ServiceMASTERS()).GetMasterDBCategory(this.MASTERCategoryID);
                    txtCategoryName.Text = dbModel.CategoryDescription;
                }
                else
                {
                    txtCategoryName.Text = string.Empty;
                    chkIsActive.Checked = true;
                }
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCategoryName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCategoryName,"Cannot be left blank!!");
                e.Cancel = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Category dbModel = null;
            ServiceMASTERS _service = new ServiceMASTERS();
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren() == true)
                {

                    if (this.MASTERCategoryID == 0)
                        dbModel = new TBL_MP_Master_Category();
                    else
                        dbModel = _service.GetMasterDBCategory(this.MASTERCategoryID);

                    dbModel.CategoryDescription = txtCategoryName.Text.Trim();
                    dbModel.IsActive = chkIsActive.Checked;

                    if (this.MASTERCategoryID == 0)
                        _service.AddNewMasterCategory(dbModel);
                    else
                        _service.UpdateMasterCategory(dbModel);

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
