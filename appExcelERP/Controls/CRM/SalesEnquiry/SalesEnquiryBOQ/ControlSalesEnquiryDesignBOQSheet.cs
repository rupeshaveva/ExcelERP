using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using appExcelERP.Forms;
using libERP.MODELS;
using libERP.SERVICES;
using ComponentFactory.Krypton.Navigator;
using libERP;
using appExcelERP.Controls.CRM.SalesEnquiry.SalesEnquiryBOQ;
using libERP.MODELS.CRM;
using libERP.MODELS.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.CRM;

namespace appExcelERP.Controls.CRM
{
    public partial class ControlSalesEnquiryDesignBOQSheet : UserControl
    {
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if(_ReadOnly)
                    btnAddChildItems.Enabled = btnRemoveSelectedItem.Enabled = btnShowHideChildItems.Enabled = btnUpdateSheet.Enabled = btnViewItemInfo.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                else
                    btnAddChildItems.Enabled = btnRemoveSelectedItem.Enabled = btnShowHideChildItems.Enabled = btnUpdateSheet.Enabled = btnViewItemInfo.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                
            }
        }
        public int SelectedIndexID { get; set; }
        public int SelectedItemID { get; set; }
        public int SelectedParentItemID { get; set; }

        public bool SelectedItemIsAsseblyItem { get; set; }
        private bool ShowChildren = true;
        
        public KryptonPage ParentTabPage { get; set; }
        public SalesEnquiryDesignBOQSheet BOQSheet { get; set; }

        public ControlSalesEnquiryDesignBOQSheet()
        {
            InitializeComponent();
        }
        public ControlSalesEnquiryDesignBOQSheet(SalesEnquiryDesignBOQSheet Sheet)
        {
            InitializeComponent();
            this.BOQSheet = Sheet;
        }

        private void ControlSalesEnquiryDesignBOQSheet_Load(object sender, EventArgs e)
        {
            btnViewItemInfo.Visible = btnShowHideChildItems.Visible= false;
        }

        #region BOQ PARENT ITEMS
        public void PopulateBOQItemsGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                btnRemoveSelectedItem.Visible = false;
                btnAddChildItems.Visible = SelectedItemIsAsseblyItem;
                gridBOQItems.DataSource = null;
                if (BOQSheet.datatableBOQ.Rows.Count > 0)
                {
                    BOQSheet.datatableBOQ.DefaultView.Sort = string.Format("{0} ASC", (new ServiceSalesEnquiryBOQ()).COL_SERIAL_NO_SYS);
                    btnRemoveSelectedItem.Visible = true;
                }
                gridBOQItems.DataSource = BOQSheet.datatableBOQ;
                gridBOQItems.RowHeadersVisible = false;
                SetBOQItemsGridColumnSizes();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::PopulateBOQItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void SetBOQItemsGridColumnSizes()
        {
            try
            {
                ServiceSalesEnquiryBOQ boqService = new ServiceSalesEnquiryBOQ();
                if (gridBOQItems.Columns.Count == 0) return;
                gridBOQItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridBOQItems.Columns[boqService.COL_DEFAULT_QTY].Visible =
                gridBOQItems.Columns[boqService.COL_INDEX].Visible =
                gridBOQItems.Columns[boqService.COL_PARENT_ITEM_ID].Visible = 
                gridBOQItems.Columns[boqService.COL_HAS_SERVICES].Visible = 
                gridBOQItems.Columns[boqService.COL_IS_ASSEMBLY].Visible = 
                gridBOQItems.Columns[boqService.COL_ITEM_ID].Visible = 
                gridBOQItems.Columns[boqService.COL_UOM_ID].Visible = false;


                Font F = this.Font;
                //gridBOQItems.Columns["ItemDescription"].DefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Regular);
                gridBOQItems.Columns[boqService.COL_ITEM_DESCRIPTION].ReadOnly = gridBOQItems.Columns[boqService.COL_UOM_NAME].ReadOnly = true;

                
                
                

                //Application.DoEvents();
                //RIGHT ALIGN ALL SERVICES COLUMN
                foreach (DataGridViewColumn col in gridBOQItems.Columns)
                {
                    EnquiryBOQService selItem = BOQSheet.BOQ_SERVICES.Where(x => x.Description == col.HeaderText).FirstOrDefault();
                    if (selItem != null)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                //Application.DoEvents();
                foreach (DataGridViewRow row in gridBOQItems.Rows)
                {
                    
                }
                //gridBOQItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                int descriptionWidth = (int)(this.Width * .4);
                gridBOQItems.Columns[boqService.COL_SERIAL_NO_SYS].HeaderText = "#";
                gridBOQItems.Columns[boqService.COL_SERIAL_NO_SYS].Width = (int)(gridBOQItems.Width * .03);
                gridBOQItems.Columns[boqService.COL_SERIAL_NO_SYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                gridBOQItems.Columns[boqService.COL_ITEM_CODE].Width = (int)(gridBOQItems.Width * .1);
                gridBOQItems.Columns[boqService.COL_ITEM_CODE].ReadOnly = true;
                gridBOQItems.Columns[boqService.COL_ITEM_CODE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                gridBOQItems.Columns[boqService.COL_UOM_NAME].Width = (int)(gridBOQItems.Width * .05);
                gridBOQItems.Columns[boqService.COL_UOM_NAME].HeaderText = "UOM";
                gridBOQItems.Columns[boqService.COL_UOM_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;


                gridBOQItems.Columns[boqService.COL_TOTAL_QTY].Width = (int)(gridBOQItems.Width * .1);
                gridBOQItems.Columns[boqService.COL_TOTAL_QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridBOQItems.Columns[boqService.COL_TOTAL_QTY].DefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Bold);

                gridBOQItems.Columns[boqService.COL_ITEM_DESCRIPTION].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridBOQItems.Columns[boqService.COL_ITEM_DESCRIPTION].MinimumWidth = descriptionWidth;
                gridBOQItems.Columns[boqService.COL_ITEM_DESCRIPTION].Width = descriptionWidth;
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::SetBOQItemsGridColumnSizes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridBOQItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //this.gridBOQItems.Sort(this.gridBOQItems.Columns["Key"], ListSortDirection.Ascending);
                foreach (DataGridViewRow row in gridBOQItems.Rows)
                {
                    this.SelectedItemIsAsseblyItem = bool.Parse(row.Cells["IsAssembly"].Value.ToString());
                    if (SelectedItemIsAsseblyItem)
                    {
                        row.DefaultCellStyle.Font = new Font(gridBOQItems.Font, FontStyle.Bold);
                        row.DefaultCellStyle.BackColor = Program.ColorSelected;
                    }
                    int pID = int.Parse(row.Cells["ParentItemID"].Value.ToString());
                    if (pID != 0)
                    {
                        row.Cells["ItemDescription"].Style.Padding = new Padding(30, 0, 0, 0);
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::gridBOQItems_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void gridBOQItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                decimal totQty = 0;
                if (e.RowIndex >= 0)
                {
                    string strColName = gridBOQItems.Columns[e.ColumnIndex].Name;
                    EnquiryBOQService selService = BOQSheet.BOQ_SERVICES.Where(x => x.Description == strColName).FirstOrDefault();
                    if (selService != null)
                    {
                        //UPDATE TOTAL QTY FOR THE SELECTED ROW
                        totQty = 0;
                        foreach (EnquiryBOQService item in BOQSheet.BOQ_SERVICES)
                        {
                            totQty += decimal.Parse(gridBOQItems.Rows[e.RowIndex].Cells[item.Description].Value.ToString());
                        }
                        gridBOQItems.Rows[e.RowIndex].Cells["TotalQty"].Value = totQty;
                        if (totQty != 0)
                        {
                            gridBOQItems.Rows[e.RowIndex].Cells["HasServices"].Value = true;
                            gridBOQItems.Rows[e.RowIndex].Cells["TotalQty"].ReadOnly = true;
                        }
                        else
                        {
                            gridBOQItems.Rows[e.RowIndex].Cells["HasServices"].Value = false;
                            gridBOQItems.Rows[e.RowIndex].Cells["TotalQty"].ReadOnly = false;
                        }
                        SelectedItemIsAsseblyItem = bool.Parse(gridBOQItems.Rows[e.RowIndex].Cells["IsAssembly"].Value.ToString());
                        //gridBOQItems.EditMode = DataGridViewEditMode.EditProgrammatically;
                        //IF THE ROW IS AN ASSEMBLY ITEM UPDATE QUANTITIES OF ALL ITS CHILD ITEMS
                        if (SelectedItemIsAsseblyItem)
                        {
                            foreach (DataGridViewRow childRow in gridBOQItems.Rows)
                            {
                                int parentID = int.Parse(childRow.Cells["ParentItemID"].Value.ToString());
                                if (parentID == SelectedItemID)
                                {
                                    decimal defVal = decimal.Parse(childRow.Cells["DefaultQty"].Value.ToString());
                                    childRow.Cells["TotalQty"].Value = totQty * defVal;
                                }
                            }
                        }
                        //gridBOQItems.EditMode = DataGridViewEditMode.EditOnKeystroke;


                    }
                    else
                    {
                        if (strColName == "TotalQty")
                        {
                            SelectedItemIsAsseblyItem = bool.Parse(gridBOQItems.Rows[e.RowIndex].Cells["IsAssembly"].Value.ToString());
                            totQty = decimal.Parse(gridBOQItems.Rows[e.RowIndex].Cells["TotalQty"].Value.ToString());
                            //IF THE ROW IS AN ASSEMBLY ITEM UPDATE QUANTITIES OF ALL ITS CHILD ITEMS
                            if (SelectedItemIsAsseblyItem)
                            {
                                foreach (DataGridViewRow childRow in gridBOQItems.Rows)
                                {
                                    int parentID = int.Parse(childRow.Cells["ParentItemID"].Value.ToString());
                                    if (parentID == SelectedItemID)
                                    {
                                        decimal defVal = decimal.Parse(childRow.Cells["DefaultQty"].Value.ToString());
                                        childRow.Cells["TotalQty"].Value = totQty * defVal;
                                    }
                                }
                            }
                            //gridBOQItems.EditMode = DataGridViewEditMode.EditOnKeystroke;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::gridBOQItems_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridBOQItems_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::gridBOQItems_CellLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void gridBOQItems_Resize(object sender, EventArgs e)
        {
            SetBOQItemsGridColumnSizes();
        }
        private void gridBOQItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServiceSalesEnquiryBOQ serviceBOQ = new ServiceSalesEnquiryBOQ();
                btnViewItemInfo.Visible = true;
                SelectedIndexID = int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[serviceBOQ.COL_INDEX].Value.ToString());
                this.SelectedItemID =int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[serviceBOQ.COL_ITEM_ID].Value.ToString());
                SelectedParentItemID = int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[serviceBOQ.COL_PARENT_ITEM_ID].Value.ToString());
                SelectedItemIsAsseblyItem = (bool)gridBOQItems.Rows[e.RowIndex].Cells[serviceBOQ.COL_IS_ASSEMBLY].Value;
                btnAddChildItems.Visible = btnShowHideChildItems.Visible = SelectedItemIsAsseblyItem;
                //btnRemoveChildItems.Visible =(SelectedParentItemID != 0)?true:false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}",ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::gridBOQItems_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtSearchBOQItemsGrid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string strFiler = string.Format("ItemDescription LIKE '%{0}%'", txtSearchBOQItemsGrid.Text);
                (gridBOQItems.DataSource as DataTable).DefaultView.RowFilter = strFiler;
                gridBOQItems.Refresh();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::txtSearchBOQItemsGrid_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion
        
        #region BUTTON CLICKS
        private void btnUpdateSheet_Click(object sender, EventArgs e)
        {
            ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
            try
            {
                frmAddEditBOQDesign frm = new frmAddEditBOQDesign();
                frm.txtSheetName.Text = BOQSheet.SheetName;
                frm.BOQ_ITEMS = BOQSheet.BOQ_ITEMS;
                frm.BOQ_SERVICES = BOQSheet.BOQ_SERVICES;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (ParentTabPage != null) ParentTabPage.Text = frm.txtSheetName.Text.Trim();
                    BOQSheet.SheetName = frm.txtSheetName.Text.Trim();
                    BOQSheet.BOQ_SERVICES = frm.BOQ_SERVICES;
                    BOQSheet.BOQ_ITEMS = frm.BOQ_ITEMS;

                    if (BOQSheet.datatableBOQ.Rows.Count == 0)
                        BOQSheet.datatableBOQ = serviceDesignBOQ.GenerateBOQDataTableDefault();

                    BOQSheet.datatableBOQ = serviceDesignBOQ.GenerateDesignBOQDataTableWithServices(BOQSheet.datatableBOQ, BOQSheet.BOQ_SERVICES, BOQSheet.BOQ_ITEMS);
                    PopulateBOQItemsGrid();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnUpdateSheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddChildItems_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAssemblyChildItems frm = new frmAddEditAssemblyChildItems();
                frm.AssemblyParentItemID = this.SelectedItemID;
                frm.SelectedItems = new BindingList<MultiSelectListItem>();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AddAssemblyChildItems(frm.SelectedItems);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnAddChildItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            //frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.INVENTORY_ASSEMBLY_ITEMS, this.SelectedItemID);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    AddAssemblyChildItems(frm.SelectedItems);
            //}
        }
        private void btnRemoveSelectedItem_Click(object sender, EventArgs e)
        {
            string strFilter = string.Empty;
            ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
            string strMessage = string.Empty;
            try
            {
                if (this.SelectedItemIsAsseblyItem)
                {
                    strFilter = string.Format("[{0}]={1}", serviceDesignBOQ.COL_INDEX, this.SelectedIndexID);
                    DataRow parentRow = BOQSheet.datatableBOQ.Select(strFilter).FirstOrDefault();
                    if (parentRow != null)
                    {
                        strMessage = "This item is An Assebly Item. Deleting the item will remove all of its childrens\n\n";
                        strMessage += parentRow["ItemDescription"].ToString();
                        DialogResult result = MessageBox.Show(strMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            strFilter = string.Format("[{0}]={1}", serviceDesignBOQ.COL_PARENT_ITEM_ID, this.SelectedItemID);
                            DataRow[] childRows = BOQSheet.datatableBOQ.Select(strFilter);
                            foreach (DataRow child in childRows)
                            {
                                BOQSheet.datatableBOQ.Rows.Remove(child);
                                BOQSheet.datatableBOQ.AcceptChanges();
                            }

                            BOQSheet.datatableBOQ.Rows.Remove(parentRow);
                            BOQSheet.datatableBOQ.AcceptChanges();
                            // REMOVE ITEM FROM THE COLLECTION OF BOQ_ITEMS
                            EnquiryBOQItem ITEM = BOQSheet.BOQ_ITEMS.Where(X => X.ID == this.SelectedItemID).FirstOrDefault();
                            if (ITEM != null)
                                BOQSheet.BOQ_ITEMS.Remove(ITEM);
                        }
                    }
                }
                else
                {
                    strFilter = string.Format("[{0}]={1}", serviceDesignBOQ.COL_INDEX, this.SelectedIndexID);
                    DataRow delRow = BOQSheet.datatableBOQ.Select(strFilter).FirstOrDefault();
                    if (delRow != null)
                    {
                        DialogResult result = MessageBox.Show(delRow["ItemDescription"].ToString(), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            BOQSheet.datatableBOQ.Rows.Remove(delRow);
                            BOQSheet.datatableBOQ.AcceptChanges();
                            // REMOVE ITEM FROM THE COLLECTION OF BOQ_ITEMS
                            EnquiryBOQItem ITEM = BOQSheet.BOQ_ITEMS.Where(X => X.ID == this.SelectedItemID).FirstOrDefault();
                            if (ITEM != null)
                                BOQSheet.BOQ_ITEMS.Remove(ITEM);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnRemoveSelectedItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnShowHideChildItems_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ShowChildren = !ShowChildren;
                foreach (DataGridViewRow row in gridBOQItems.Rows)
                {
                    int parent = int.Parse(row.Cells["ParentItemID"].Value.ToString());
                    if (parent != 0) row.Visible = ShowChildren;
                }
                btnShowHideChildItems.Text = (ShowChildren == true) ? "Hide Children" : "Show Children";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::btnShowHideChildItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }
        private void btnViewItemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                frmEntityInfo frm = new frmEntityInfo(APP_ENTITIES.INVENTORY_ITEM, this.SelectedItemID);
                frm.Show();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::btnViewItemInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        #region HELPERS             
        private void PopulateBOQItemsSummaryGrid()
        {
            try
            {
                gridBOQSummary.DataSource = null;
                Application.DoEvents();
                gridBOQSummary.DataSource = (new ServiceSalesEnquiryBOQ()).GenrateDesignBOQDatatableSummary(BOQSheet.datatableBOQ);
                gridBOQSummary.RowHeadersVisible = false;
                gridBOQSummary.ColumnHeadersVisible = false;
                gridBOQSummary.Width = gridBOQItems.Width;

                gridBOQSummary.Columns["HasServices"].Visible = gridBOQSummary.Columns["ItemID"].Visible = gridBOQSummary.Columns["UOMID"].Visible = false;
                gridBOQSummary.Columns["ItemCode"].Width = gridBOQItems.Columns["ItemCode"].Width;
                gridBOQSummary.Columns["UOMName"].Width = gridBOQItems.Columns["UOMName"].Width;
                gridBOQSummary.Columns["TotalQty"].Width = gridBOQItems.Columns["TotalQty"].Width;
                gridBOQSummary.Columns["ItemDescription"].Width = gridBOQItems.Columns["ItemDescription"].Width;

                foreach (DataGridViewColumn col in gridBOQSummary.Columns)
                {
                    col.DefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size + 1, FontStyle.Bold);
                }

                gridBOQSummary.ReadOnly = true;
                gridBOQSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridBOQSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //RIGHT ALIGN ALL SERVICES COLUMN
                gridBOQSummary.Columns["TotalQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn col in gridBOQSummary.Columns)
                {
                    EnquiryBOQService selItem = BOQSheet.BOQ_SERVICES.Where(x => x.Description == col.HeaderText).FirstOrDefault();
                    if (selItem != null)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                if (gridBOQSummary.Rows.Count > 0)
                    gridBOQSummary.Height = gridBOQSummary.Rows[0].Height;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void AddAssemblyChildItems(BindingList<MultiSelectListItem> selItems)
        {
            try
            {
                if (selItems.Count > 0)
                {
                    ServiceSalesEnquiryBOQ _boqService = new ServiceSalesEnquiryBOQ();
                    foreach (MultiSelectListItem item in selItems)
                    {
                        string strSearch = string.Format("ItemID={0} AND ParentItemID={1}", item.ID, this.SelectedItemID);
                        DataRow[] dr = BOQSheet.datatableBOQ.Select(strSearch);
                        if (dr.Count() == 0)
                        {
                            TBL_MP_Master_Item dbItem = (new ServiceInventoryItems()).GetItemDBRecord(item.ID);
                            if (dbItem != null)
                            {
                                var newIndex = int.Parse(BOQSheet.datatableBOQ.AsEnumerable().Max(row => row[_boqService.COL_INDEX]).ToString());
                                newIndex++;
                                DataRow dtrow = BOQSheet.datatableBOQ.NewRow();
                                dtrow[_boqService.COL_INDEX] = newIndex;
                                dtrow[_boqService.COL_SERIAL_NO_SYS] = GetNewSerialNoForChildItem(this.SelectedIndexID);
                                dtrow[_boqService.COL_PARENT_ITEM_ID] = this.SelectedItemID;
                                dtrow[_boqService.COL_HAS_SERVICES] = false;
                                dtrow[_boqService.COL_ITEM_ID] = item.ID;
                                dtrow[_boqService.COL_ITEM_CODE] = item.Code;
                                dtrow[_boqService.COL_ITEM_DESCRIPTION] = item.Description;
                                dtrow[_boqService.COL_IS_ASSEMBLY] = dbItem.IsAssembly;
                                if (dbItem.Fk_UserList_BaseUOM_ID != null)
                                {
                                    List<SelectListItem> UOMs = (new ServiceMASTERS()).GetAllUOMs();
                                    SelectListItem selUOM = UOMs.Where(x => x.ID == dbItem.Fk_UserList_BaseUOM_ID).FirstOrDefault();
                                    if (selUOM != null)
                                    {
                                        dtrow[_boqService.COL_UOM_ID] = selUOM.ID;
                                        dtrow[_boqService.COL_UOM_NAME] = selUOM.Description;
                                    }
                                }
                                //GET DEFAULT QUANTITY FROM ASSEMBLY CHILD ITEM TABLE
                                dtrow[_boqService.COL_TOTAL_QTY] = (new ServiceInventoryItems()).GetDefaultQuantityofItemInAssembly(this.SelectedItemID, item.ID);
                                dtrow[_boqService.COL_DEFAULT_QTY] = dtrow[_boqService.COL_TOTAL_QTY];
                                //SET SERCVICS COLUMNS QTY VALUE TO 0
                                foreach (EnquiryBOQService selService in BOQSheet.BOQ_SERVICES)
                                {
                                    dtrow[selService.Description] = 0;
                                }
                                BOQSheet.datatableBOQ.Rows.Add(dtrow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::AddAssemblyChildItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public decimal GetNewSerialNoForChildItem(int INDEX_ID)
        {
            decimal parentSerial = 0;
            decimal newSerial = 0;

            try
            {
                ServiceSalesEnquiryBOQ _boqService = new ServiceSalesEnquiryBOQ();

                //SELECT PARENT ROW FROM DATABALE
                string strExpr = string.Format("[{0}]={1}", _boqService.COL_INDEX, INDEX_ID);

                DataRow[] rowParent = BOQSheet.datatableBOQ.Select(strExpr);
                if (rowParent.Count() > 0)
                {
                    parentSerial = decimal.Parse(rowParent[0][_boqService.COL_SERIAL_NO_SYS].ToString());
                    string strFilter = string.Format("[{0}]={1}", _boqService.COL_PARENT_ITEM_ID, this.SelectedItemID);
                    DataRow[] childRows = BOQSheet.datatableBOQ.Select(strFilter);
                    int numberOfRecords = childRows.Count() + 1;
                    newSerial = decimal.Parse(string.Format("{0}.{1}", rowParent[0][_boqService.COL_SERIAL_NO_SYS].ToString(), numberOfRecords.ToString().PadLeft(2, '0')));
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQSheet::GetNewSerialNoForChildItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newSerial;
        }
         #endregion

        private void ControlSalesEnquiryDesignBOQSheet_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        

       
    }
}
