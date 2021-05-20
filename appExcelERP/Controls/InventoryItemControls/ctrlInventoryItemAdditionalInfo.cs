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
using libERP;
using libERP.MODELS;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Diagnostics;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.InventoryItemControls
{
    public partial class ctrlInventoryItemAdditionalInfo : UserControl
    {
        public int SelectedItemID { get; set; }
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnUploadPicture.Enabled = ButtonEnabled.False;
                }
                else
                {
                    btnUploadPicture.Enabled = ButtonEnabled.True;
                }
            }
        }
        private void ctrlInventoryItemAdditionalInfo_Load(object sender, EventArgs e)
        {
            //splitContainerGeneralInfo.SplitterDistance = this.Height / 3;
        }

        public ctrlInventoryItemAdditionalInfo()
        {
            InitializeComponent();
        }
        public void PopulateAdditionalInfo()
        {
            pictureBoxItemImage.Image = null;
            btnUploadPicture.Enabled = ButtonEnabled.False;
            txtCreatedBy.Text = txtModifiedBy.Text = lblBaseUOM.Text= lblPurchaseUOM.Text= string.Empty;
            try
            {
                TBL_MP_Master_Item item = (new ServiceInventoryItems()).GetItemDBRecord(this.SelectedItemID);
                if (item != null)
                {

                    ServiceEmployee _serviceEmp = new ServiceEmployee();
                    if (item.CreatedBy != null)
                        txtCreatedBy.Text = string.Format("{0}\n{1}", ServiceEmployee.GetEmployeeNameByID((int)item.CreatedBy), item.CreatedDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                    if (item.LastModifiedBy != null)
                        txtModifiedBy.Text = string.Format("{0}\n{1}", ServiceEmployee.GetEmployeeNameByID((int)item.LastModifiedBy), item.LastModifiedDate.Value.ToString("dd MMM yy hh:mmtt"));

                    List<SelectListItem> lstUOMs = (new ServiceMASTERS()).GetAllUOMs();
                    if (item.Fk_UserList_BaseUOM_ID != null)
                        lblBaseUOM.Text = string.Format("Base UOM : {0}", lstUOMs.Where(x => x.ID == item.Fk_UserList_BaseUOM_ID).FirstOrDefault().Description);
                    if (item.Fk_UserList_PurchaseUOM_ID != null)
                        lblPurchaseUOM.Text = string.Format("Purchase UOM : {0}", lstUOMs.Where(x => x.ID == item.Fk_UserList_PurchaseUOM_ID).FirstOrDefault().Description);


                    if (item.ImageFileName != null)
                    {
                        string filePath = string.Format("{0}{1}", AppCommon.GetInventoryItemImagePath(), item.ImageFileName);
                        if (File.Exists(filePath))
                        {
                            byte[] array = File.ReadAllBytes(filePath);
                            Bitmap image;
                            using (MemoryStream stream = new MemoryStream(array))
                            {
                                image = new Bitmap(stream);
                            }
                            pictureBoxItemImage.Image = image;
                        }
                    }


                    txtDeleteInfo.Text = string.Empty;
                    bool isActive = (bool)item.IsActive;
                    if (!isActive)
                    {
                        String empName = string.Empty;
                        string delDate = string.Empty;
                        if (item.DeletedBy != null)
                            empName = ServiceEmployee.GetEmployeeNameByID((int)item.DeletedBy);
                        if (item.DeletedBy != null)
                            delDate = item.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt");
                        headerGroupDelete.ValuesPrimary.Heading= string.Format("DELETED : {0} DT. {1}", empName, delDate);
                        txtDeleteInfo.Text = string.Format("{0}", item.DeleteRemarks);
                        btnUploadPicture.Enabled = ButtonEnabled.False;
                    }
                    else
                    {
                        btnUploadPicture.Enabled = ButtonEnabled.True;
                        headerGroupDelete.ValuesPrimary.Heading = string.Format("ACTIVE ITEM");
                        txtDeleteInfo.Text = string.Format("{0}", item.DeleteRemarks);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlInventoryItemAdditionalInfo::PopulateAdditionalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    (new ServiceInventoryItems()).UpdateItemImageFileName(this.SelectedItemID, openFileDialog.FileName);
                    PopulateAdditionalInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageInventoryItems::btnUploadPicture_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void ctrlInventoryItemAdditionalInfo_Resize(object sender, EventArgs e)
        {
            splitContainerGeneralInfo.SplitterDistance = this.Height / 2;
        }
       }
}
