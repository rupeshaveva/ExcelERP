using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    public partial class frmAddEditBoqItem : KryptonForm
    {
        public int INDEX_ID { get; set; }
        public int UOM_ID { get; set; }
        public string UOM_NAME { get; set; }
        public decimal SERIAL_NO_SYS { get; set; }
        public string SERIAL_NO_BOQ { get; set; }
        public string SERIAL_NO_CLIENT { get; set; }
        public string ITEM_DESCRIPTION
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        public frmAddEditBoqItem()
        {
            InitializeComponent();

        }
        private void frmAddEditBoqItem_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateUOMDropdown();
                ScatterData();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBoqItem::frmAddEditBoqParentItem_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ScatterData()
        {
            try
            {
                txtSRNO_SYS.Text = SERIAL_NO_SYS.ToString();
                txtSRNO_BOQ.Text = this.SERIAL_NO_BOQ;
                txtDescription.Text = ITEM_DESCRIPTION;
                if (UOM_ID != 0)
                {
                    SelectListItem item = ((List<SelectListItem>)cboUOM.DataSource).Where(x => x.ID == UOM_ID).FirstOrDefault();
                    if (item != null)
                    {
                        cboUOM.SelectedItem = item;
                        cboUOM.SelectedValue = item.ID;
                    }


                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBoqItem::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void PopulateUOMDropdown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceMASTERS()).GetAllUOMs());
                cboUOM.DataSource = lstUOMs;
                cboUOM.DisplayMember = "Description";
                cboUOM.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBoqItem::PopulateUOMDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    this.SERIAL_NO_SYS = decimal.Parse(txtSRNO_SYS.Text.Trim());
                    this.SERIAL_NO_BOQ = txtSRNO_BOQ.Text.Trim();
                    SERIAL_NO_CLIENT = txtClientSerialNo.Text.Trim();
                    if (cboUOM.SelectedItem != null)
                    {
                        SelectListItem selItem = (SelectListItem)cboUOM.SelectedItem;
                        this.UOM_ID = selItem.ID;
                        this.UOM_NAME = selItem.Description;
                    }



                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBoqItem::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboUOM_SelectedValueChanged(object sender, EventArgs e)
        {
            //SelectListItem selUOM = (SelectListItem)cboUOM.SelectedItem;
            //this.UOM_ID = selUOM.ID;
            //this.UOM_NAME = selUOM.Description;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
        #region VALIDATIONS
        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDescription.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtDescription, "Required");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBoqItem::txtDescription_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboUOM_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboUOM.SelectedItem == null)
                {
                    errorProvider1.SetError(cboUOM, "Required");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBoqItem::cboUOM_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

      
    }

}
