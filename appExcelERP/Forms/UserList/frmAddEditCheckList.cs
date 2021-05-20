using libERP;
using libERP.MODELS;
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
    public partial class frmAddEditCheckList : Form
    {
        public int ItemID { get; set; }
        public int CategoryID { get; set; }

         public frmAddEditCheckList()
        {
            InitializeComponent();
        }
        public frmAddEditCheckList(int ID)
        {
            InitializeComponent();
            ItemID = ID;
        }
        private void PopulateCheckPointsDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllActiveProjectCheckPoints());
                cboCheckPoints.DataSource = LST;
                cboCheckPoints.DisplayMember = "Description";
                cboCheckPoints.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCheckList::PopulateCheckPointsDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddEditCheckList_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateCheckPointsDropdown();
                if (this.ItemID == 0)
                {
                    if(this.CategoryID!=0)
                        cboCheckPoints.SelectedItem = ((List<SelectListItem>)cboCheckPoints.DataSource).Where(x => x.ID ==this.CategoryID).FirstOrDefault();
                }
                else
                    ScatterData();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCheckList::frmAddEditCheckList_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ScatterData()
        {
            try
            {
                CheckList_Master item = (new ServiceCheckListMaster()).GetCheckListItemDBInfo(this.ItemID);
                if(item!=null)
                {
                    cboCheckPoints.SelectedItem = ((List<SelectListItem>)cboCheckPoints.DataSource).Where(x => x.ID == item.FK_CheckPointID).FirstOrDefault();
                    txtDescription.Text = item.Description;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCheckList::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cboCheckPoints_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboCheckPoints.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboCheckPoints, "Check Point is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCheckList::cboCheckPoints_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDescription.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtDescription, "Check List is mandatory");
                    e.Cancel = true;
                    
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCheckList::cboCheckPoints_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckList_Master model = null;
            ServiceCheckListMaster service = new ServiceCheckListMaster();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.ItemID == 0)
                    model = new CheckList_Master();
                else
                    model = service.GetCheckListItemDBInfo(this.ItemID);

                #region GATHER DATA INTO MODEL FROM VIEW
                model.FK_CheckPointID = ((SelectListItem)cboCheckPoints.SelectedItem).ID;
                model.Description = txtDescription.Text.Trim();
                #endregion

                if (this.ItemID == 0)
                {
                    
                    this.ItemID = service.AddNewCheckListItem(model);
                }
                else
                {
                   
                    service.UpdateCheckListItem(model);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCheckList::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
