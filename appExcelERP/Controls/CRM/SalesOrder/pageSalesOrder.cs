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
using appExcelERP.Forms;
using libERP.SERVICES.CRM;
using appExcelERP.Forms.CRM.SalesOrder;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Controls.CommonControls;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.CRM.SalesOrder
{
    public partial class pageSalesOrder : UserControl
    {

        public ServiceSalesOrder _service = null;
        public DB_FORM_IDs SelectedTAB { get; set; }
        public KryptonPage ParentTABControl { get; set; }

        public string SelectedOrderNumber { get; set; }
        public int SelectedOrderID { get; set; }
        public int SelectedOrderStatusID { get; set; }
        public int SelectedOrderTypeID { get; set; }

        BindingList<SelectListItem> _OrdersList = null;
        BindingList<SelectListItem> _filteredOrdersList = null;

        #region CUSTOM CONTROLS FOR EACH TAB

        ControlSalesOrderGeneralInfo _ctrlGeneralDetails = null;
        private void InitializeSalesOrderGeneralInfoControl()
        {
            try
            {
                _ctrlGeneralDetails = new ControlSalesOrderGeneralInfo();
                tabPageGeneralInfo.Controls.Add(_ctrlGeneralDetails);
                _ctrlGeneralDetails.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::InitializeSalesOrderGeneralInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        ControlSalesOrderContacts _ctrlContactDetails = null;
        private void InitializeSalesOrderContactInfoControl()
        {
            try
            {
                _ctrlContactDetails = new ControlSalesOrderContacts();
                tabPageClientContact.Controls.Add(_ctrlContactDetails);
                _ctrlContactDetails.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::InitializeSalesOrderContactInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        ctrlAttachments _ctrlAttachment = null;
        private void InitializeAttachmentInfoControl()
        {
            _ctrlAttachment = new ctrlAttachments(APP_ENTITIES.SALES_ORDER);
            _ctrlAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
            tabPageAttachment.Controls.Add(_ctrlAttachment);
            _ctrlAttachment.Dock = DockStyle.Fill;
        }

        ctrlAssociates _ctrlAssociates = null;
        private void InitializeAssociatesInfoControl()
        {
            tabPageAssociates.Controls.Clear();
            _ctrlAssociates = new ctrlAssociates(APP_ENTITIES.SALES_ORDER);
            tabPageAssociates.Controls.Add(_ctrlAssociates);
            _ctrlAssociates.Dock = DockStyle.Fill;
        }

        ctrlScheduleCallLog _ctrlScheduler = null;
        private void InitializeSchedulerInfoControl()
        {
            tabPageScheduleCalls.Controls.Clear();
            _ctrlScheduler = new ctrlScheduleCallLog(APP_ENTITIES.SALES_ORDER);

            tabPageScheduleCalls.Controls.Add(_ctrlScheduler);
            _ctrlScheduler.Dock = DockStyle.Fill;
        }

        ControlSalesOrderTermsAndCondition _ctrlTermsAndCondition = null;
        private void InitializeTermsAndConditionControl()
        {
            tabPageTNC.Controls.Clear();
            _ctrlTermsAndCondition = new ControlSalesOrderTermsAndCondition();
            tabPageTNC.Controls.Add(_ctrlTermsAndCondition);
            _ctrlTermsAndCondition.Dock = DockStyle.Fill;
        }
        #endregion

        public pageSalesOrder()
        {
            InitializeComponent();
            _service = new ServiceSalesOrder();
        }

        private void pageSalesOrder_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SetSalesOrderTabTags();
                PopulateSalesOrderStatusDropdown();
                SetSalesOrderTabAsPerPermission();
                this.SelectedOrderID = 0;
                tabSalesOrder.Visible = false;
                if (_ctrlGeneralDetails != null) this.SelectedTAB = (DB_FORM_IDs)tabPageGeneralInfo.Tag;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::pageSalesOrder_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #region ACCESS RIGHT MANAGEMENT CODE
        private void SetSalesOrderTabTags()
        {
            try
            {
                tabPageGeneralInfo.Tag = DB_FORM_IDs.SALES_ORDER_GENERAL_INFO;
                
                tabPageAttachment.Tag = DB_FORM_IDs.SALES_ORDER_ATTACHMENTS;
                tabPageAssociates.Tag = DB_FORM_IDs.SALES_ORDER_ASSOCIATES;
                tabPageScheduleCalls.Tag = DB_FORM_IDs.SALES_ORDER_SCHEDULE_CALL;
                
                tabPageTNC.Tag= DB_FORM_IDs.SALES_ORDER_TNC;
                tabPageClientContact.Tag = DB_FORM_IDs.SALES_ORDER_CLIENT_CONTACT;
                tabPageGeneralInfo.Visible  =  tabPageAttachment.Visible = tabPageAssociates.Visible = tabPageScheduleCalls.Visible = false;
                 tabPageTNC.Visible = tabPageClientContact.Visible = false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::SetSalesOrderTabTags", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSalesOrderTabAsPerPermission()
        {
            try
            {
                foreach (KryptonPage tabSelected in tabSalesOrder.Pages)
                {
                    if (tabSelected.Tag != null)
                    {
                        WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == (DB_FORM_IDs)tabSelected.Tag).FirstOrDefault();
                        if (model != null)
                        {
                            tabSelected.Visible = model.CanView;
                            if (tabSelected.Visible)
                            {
                                switch ((DB_FORM_IDs)model.FormID)
                                {
                                    case DB_FORM_IDs.SALES_ORDER_GENERAL_INFO: InitializeSalesOrderGeneralInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ORDER_CLIENT_CONTACT: InitializeSalesOrderContactInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ORDER_BOQ:  break;
                                    case DB_FORM_IDs.SALES_ORDER_ATTACHMENTS: InitializeAttachmentInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ORDER_ASSOCIATES: InitializeAssociatesInfoControl();  break;
                                    case DB_FORM_IDs.SALES_ORDER_SCHEDULE_CALL: InitializeSchedulerInfoControl(); break;
                                    case DB_FORM_IDs.SALES_ORDER_SALES_NOTE:  break;
                                    case DB_FORM_IDs.SALES_ORDER_TNC: InitializeTermsAndConditionControl(); break;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::SetSalesOrderTabAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
            bool readOnly = _service.IsSalesOrderReadOnly(this.SelectedOrderID);
            if (readOnly)
                btnAddPrimarySO.Enabled = btnAddWithoutOrderSO.Enabled = btnEditOrder.Enabled =btnDeleteOrder.Enabled= ButtonEnabled.False;
            else
                btnAddPrimarySO.Enabled = btnAddWithoutOrderSO.Enabled = btnEditOrder.Enabled = btnDeleteOrder.Enabled = ButtonEnabled.True;

            switch (this.SelectedTAB)
            {
                case DB_FORM_IDs.SALES_ORDER_GENERAL_INFO:
                    if (_ctrlGeneralDetails == null) return;
                    _ctrlGeneralDetails.SelectedSalesOrderID = this.SelectedOrderID;
                    _ctrlGeneralDetails.ReadOnly = readOnly;
                    _ctrlGeneralDetails.PopulateSalesOrderGeneralInfo();
                    break;
                case DB_FORM_IDs.SALES_ORDER_CLIENT_CONTACT:
                    if (_ctrlContactDetails == null) return;
                    _ctrlContactDetails.SelectedSalesOrderID = this.SelectedOrderID;
                    _ctrlContactDetails.ReadOnly = readOnly;
                    _ctrlContactDetails.PopulateClientInfo();
                    break;
                case DB_FORM_IDs.SALES_ORDER_ATTACHMENTS:
                    if (_ctrlAttachment == null) return;
                    _ctrlAttachment.SelectedEntityID = this.SelectedOrderID;
                    _ctrlAttachment.PopulateDocuments();
                    break;
                case DB_FORM_IDs.SALES_ORDER_ASSOCIATES:
                    if (_ctrlAssociates == null) return;
                    _ctrlAssociates.SelectedID = this.SelectedOrderID;
                    _ctrlAssociates.ReadOnly = readOnly;
                    _ctrlAssociates.PopulateAssociatedEmployees();
                    break;
                case DB_FORM_IDs.SALES_ORDER_SCHEDULE_CALL:
                    if (_ctrlScheduler == null) return;
                    _ctrlScheduler.SOURCE_ENTITY_ID = this.SelectedOrderID;
                    _ctrlScheduler.ReadOnly = readOnly;
                    _ctrlScheduler.PopulateAllSchedules();
                    break;
                case DB_FORM_IDs.SALES_ORDER_TNC:
                    if (_ctrlTermsAndCondition == null) return;
                    _ctrlTermsAndCondition.SelectedOrderID = this.SelectedOrderID;
                    _ctrlTermsAndCondition.ReadOnly = readOnly;
                    _ctrlTermsAndCondition.PopulateTermsAndConditions();
                    break;
            }

        }
        #endregion  

        private void PopulateSalesOrderStatusDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceSalesOrder()).GetAllSalesOrderStatuses());
                cboSalesOrderStatuses.DataSource = LST;
                cboSalesOrderStatuses.DisplayMember = "Description";
                cboSalesOrderStatuses.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::PopulateSalesOrderStatusDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateSalesOrdersGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedOrderID = 0;
                tabSalesOrder.Visible = false;
                _OrdersList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceSalesOrder()).GetAllSOWithStatusForGridDisplay(SelectedOrderStatusID));
                gridSalesOrders.DataSource = _OrdersList;
                gridSalesOrders.Columns["ID"].Visible =
                gridSalesOrders.Columns["DescriptionToUpper"].Visible =
                gridSalesOrders.Columns["Code"].Visible =
                gridSalesOrders.Columns["IsActive"].Visible = false;

                headerGroupOrderList.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridSalesOrders.Rows.Count);

                if (gridSalesOrders.Rows.Count > 0) tabSalesOrder.Visible = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::PopulateSalesOrdersGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchSalesOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredOrdersList = new BindingList<SelectListItem>(_OrdersList.Where(p => p.DescriptionToUpper.Contains(txtSearchSalesOrder.Text.ToUpper())).ToList());
                gridSalesOrders.DataSource = _filteredOrdersList;
                headerGroupOrderList.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridSalesOrders.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::txtSearchSalesOrder_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridSalesOrders_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedOrderID= int.Parse(gridSalesOrders.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                this.SelectedOrderNumber = gridSalesOrders.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                this.SelectedOrderTypeID = (new ServiceSalesOrder()).GetSalesOrderType(this.SelectedOrderID);
                RefreshTabPage();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::gridSalesOrders_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabSales_TabClicked(object sender, KryptonPageEventArgs e)
        {
            this.SelectedTAB = (DB_FORM_IDs)((KryptonNavigator)sender).Pages[e.Index].Tag;
            this.RefreshTabPage();
        }
        private void btnToggleGrid_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel1Collapsed = !splitContainerMain.Panel1Collapsed;
        }
        private void btnAddPrimarySO_Click(object sender, EventArgs e)
        {
            try
            {
                frmSO_Primary frm = new frmSO_Primary();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalesOrdersGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::btnAddPrimarySO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAddWithoutOrderSO_Click(object sender, EventArgs e)
        {
            try
            {
                frmSO_WithoutOrder frm = new frmSO_WithoutOrder();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalesOrdersGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::btnAddWithoutOrderSO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceSalesOrder service = new ServiceSalesOrder();
                if (SelectedOrderTypeID == service.SO_TYPE_WITHOUT_ORDER_ID)
                {
                    frmSO_WithoutOrder frm = new frmSO_WithoutOrder(this.SelectedOrderID);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        PopulateSalesOrdersGrid();
                    }
                }
                if (SelectedOrderTypeID == service.SO_TYPE_PRIMARY_ID)
                {
                    frmSO_Primary frm = new frmSO_Primary(this.SelectedOrderID);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        PopulateSalesOrdersGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::btnEditOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Sales Order {0}", this.SelectedOrderID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalesOrder()).DeleteSalesOrder(this.SelectedOrderID, Program.CURR_USER.EmployeeID))
                        //  if ((new ServiceSalesOrder()).DeleteSalesOrder(this.SelectedOrderID))
                        PopulateSalesOrdersGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::btnDeleteLead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateSalesOrdersGrid();
        }
         private void cboSalesOrderStatuses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                SelectedOrderStatusID = ((SelectListItem)cboSalesOrderStatuses.SelectedItem).ID;
                PopulateSalesOrdersGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::cboSalesOrderStatuses_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region GENERATE REVISION FOR SALES ORDER
        private void btnGenerateRevision_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                new ServiceSalesOrder().GenerateRevision(this.SelectedOrderID, Program.CURR_USER);
                PopulateSalesOrdersGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageSalesOrder::btnGenerateRevision_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        #endregion
    }
}
