using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP.MODELS;
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Forms;
using appExcelERP.Forms.UserList;
using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using libERP.SERVICES.CRM;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlSuspectInfo : UserControl
    {
        public int SelectedID { get; set; }
        public APP_ENTITIES ENTITY { get; set; }
        public List<SuspectingInfoModel> SuspectItems { get; set; }

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnAddSuspectCategory.Enabled = btnUpdate.Enabled = btnCancel.Enabled= ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                {
                    btnAddSuspectCategory.Enabled = btnUpdate.Enabled = btnCancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
            }
        }

        public ctrlSuspectInfo()
        {
            InitializeComponent();
        }
        public ctrlSuspectInfo(APP_ENTITIES currEntity)
        {
            InitializeComponent();
            this.ENTITY = currEntity;
        }

        public void PopulateSuspectInfoControls()
        {
            try
            {
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        this.SuspectItems= (new ServiceSalesLead()).GetSuspectingInfoForSalesLead(this.SelectedID);
                        headerGroupSuspectInfo.Panel.Controls.Clear();
                        int i = SuspectItems.Count;
                        foreach (SuspectingInfoModel model in SuspectItems)
                        {
                            
                            KryptonHeaderGroup grp = new KryptonHeaderGroup() { Name=string.Format("dyna-{0}", model.CategoryID)};
                            grp.Height = 100;
                            grp.HeaderStylePrimary = HeaderStyle.DockActive;
                            grp.ValuesPrimary.Heading = model.CategoryName;
                            grp.HeaderVisibleSecondary = false;
                            KryptonTextBox txtCategoryDescription = new KryptonTextBox();
                            txtCategoryDescription.Name = string.Format("txt_{0}",model.CategoryID);
                            txtCategoryDescription.Text = model.CategoryDiscription;
                            txtCategoryDescription.Multiline = true;
                            txtCategoryDescription.ReadOnly = ReadOnly;
                            grp.Tag = model.CategoryID;
                            grp.Panel.Controls.Add(txtCategoryDescription);
                            txtCategoryDescription.Dock = DockStyle.Fill;
                            grp.Dock = DockStyle.Top;
                            grp.TabIndex = i--;
                            headerGroupSuspectInfo.Panel.Controls.Add(grp);
                           
                        }

                        //gridData.DataSource = (new ServiceSalesLead()).GetSuspectingInfoForSalesLead(this.SelectedID);
                        //gridData.Columns["Entity"].Visible = gridData.Columns["PKId"].Visible = gridData.Columns["CategoryID"].Visible = false;
                        //gridData.Columns["CategoryName"].ReadOnly = true;
                        //gridData.Columns["CategoryName"].Width = (int)(gridData.Width*.3);
                        //gridData.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        //int headerHeight = this.gridData.ColumnHeadersHeight;
                        //int height = this.gridData.Size.Height - headerHeight;
                        //int rowHeight = height / this.gridData.RowCount; // -1;
                        //this.gridData.RowTemplate.Height = rowHeight;

                        //gridData.DataSource = (new ServiceSalesLead()).GetSuspectingInfoForSalesLead(this.SelectedID);
                        //gridData.Columns["CategoryDiscription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        //for(int i=0;i<gridData.Rows.Count;i++)
                        //{ 
                        //    DataGridViewCellStyle style = new DataGridViewCellStyle();
                        //    style.WrapMode = DataGridViewTriState.True;
                        //    ((DataGridViewTextBoxCell)gridData.Rows[i].Cells["CategoryDiscription"]).Style = style;
                            
                        //}
                        break;

                }
                
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlSuspectInfo::PopulateSuspectInfoControls", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SuspectingInfoModel model in this.SuspectItems)
                {
                    KryptonHeaderGroup grp = this.Controls.Find("dyna-" + model.CategoryID.ToString(), true).FirstOrDefault() as KryptonHeaderGroup;
                    if (grp != null)
                    {
                        KryptonTextBox textboxDescription = this.Controls.Find("txt_" + model.CategoryID.ToString(), true).FirstOrDefault() as KryptonTextBox;
                        if (textboxDescription != null)
                        {
                            model.CategoryDiscription = textboxDescription.Text.Trim();
                        }
                    }
                }
            (new ServiceSalesLead()).UpdateSuspectingInfoForSalesLead(this.SuspectItems, this.SelectedID);
                PopulateSuspectInfoControls();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlSuspectInfo::btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void btnAddSuspectCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.Text = "Add/Edit Suspect Info. Category";
                frm.kryptonHeaderGroup1.ValuesPrimary.Heading = "Suspect Category Name";
                frm.MASTERCategoryID = (int)APP_ADMIN_CATEGORIES.SUSPECTING_INFO;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSuspectInfoControls();
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlSuspectInfo::btnAddSuspectCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;

        }
    }
}
