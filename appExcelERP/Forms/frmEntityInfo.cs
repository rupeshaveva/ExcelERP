using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Controls.InventoryItemControls;
using libERP.SERVICES;
using ComponentFactory.Krypton.Navigator;
using libERP.MODELS.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmEntityInfo : Form
    {
        public APP_ENTITIES ENTITY { get; set; }
        public int ENTITY_ID { get; set; }
        
        public frmEntityInfo(APP_ENTITIES enumEntity, int entityID)
        {
            ENTITY = enumEntity;
            this.ENTITY_ID = entityID;
            InitializeComponent();

            this.Cursor = Cursors.WaitCursor;
            switch (ENTITY)
            {
                case APP_ENTITIES.INVENTORY_ITEM:
                    PopulateInventoryItemInfo();
                    break;
            }
            this.Cursor = Cursors.Default;

        }

        public void PopulateInventoryItemInfo()
        {
            this.Text = "INVENTORY ITEM INFO";
            tabINFO.Pages.Clear();
            //ADD INVENTORY ITEM GENERAl INFO TAB
            ctrlInventoryItemAdditionalInfo ItemAdditionalInfoControl = null;
            ItemAdditionalInfoControl = new ctrlInventoryItemAdditionalInfo();
            KryptonPage pageGeneralInfo = new KryptonPage() { Text="General Info",Name="tabPageGeneralItemInfo" };
            tabINFO.Pages.Add(pageGeneralInfo);
            pageGeneralInfo.Controls.Add(ItemAdditionalInfoControl);
            ItemAdditionalInfoControl.Dock = DockStyle.Fill;
            ItemAdditionalInfoControl.SelectedItemID = this.ENTITY_ID;
            ItemAdditionalInfoControl.PopulateAdditionalInfo();
            ItemAdditionalInfoControl.ReadOnly = true;

            KryptonPage pagePurchaseInfo = new KryptonPage() { Text = "Purchase History", Name = "tabPagePurchaseHistoryInfo" };
            tabINFO.Pages.Add(pagePurchaseInfo);
            KryptonPage pageSalesInfo = new KryptonPage() { Text = "Sales History", Name = "tabPageSalesHistoryInfo" };
            tabINFO.Pages.Add(pageSalesInfo);

            pageGeneralInfo.Select();




        }

        private void frmEntityInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
