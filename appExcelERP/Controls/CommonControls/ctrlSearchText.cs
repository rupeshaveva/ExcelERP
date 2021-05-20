using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlSearchText : UserControl
    {

        public bool ShowPopup { get; set; }
        public int PopupHeight { get; set; }
        BindingList<SelectListItem> _SourceList = null;

        public SelectListItem SelectedItem { get; set; }
        public BindingList<SelectListItem> DataSource { get { return _SourceList; } set { _SourceList = value; gridData.DataSource = _SourceList; SetGridColumns(); } }


        public ctrlSearchText()
        {
            InitializeComponent();
            this.ShowPopup = true;
            gridData.Visible = false;
            this.Height = TextSearch.Height;
            this.PopupHeight = 100;
        }
        private void SetGridColumns()
        {
            if (gridData.DataSource != null)
                gridData.Columns["ID"].Visible = gridData.Columns["Code"].Visible = gridData.Columns["DescriptionToUpper"].Visible = false;
        }
        private void TextSearch_Enter(object sender, EventArgs e)
        {
            if(this.ShowPopup)
            {
                this.Height = TextSearch.Height + PopupHeight;
                gridData.Visible = true;
            }
                
        }
        private void TextSearch_Leave(object sender, EventArgs e)
        {
            //this.Height = TextSearch.Height;
            //gridData.Visible = false;
            //if (this.SelectedItem != null)
            //    TextSearch.Text = this.SelectedItem.Description;
        }
        private void Search_TextChanged(object sender, EventArgs e)
        {
            if (_SourceList == null) return;
            BindingList<SelectListItem> filtered = new BindingList<SelectListItem>(_SourceList.Where(
                     p => p.DescriptionToUpper.Contains(this.TextSearch.Text.ToUpper())).ToList());
            gridData.DataSource = filtered;

        }
        private void gridData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.SelectedItem = _SourceList.Where(x => x.ID == (int)gridData.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void TextSearch_KeyUp(object sender, KeyEventArgs e)
        {
            int selIndex = 0;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    selIndex = gridData.SelectedRows[0].Index;
                    if(selIndex < gridData.Rows.Count)
                    {
                        selIndex++;
                        gridData.FirstDisplayedScrollingRowIndex = selIndex;
                        gridData.Rows[selIndex].Selected = true;
                    }
                    break;
                case Keys.Up:
                    selIndex = gridData.SelectedRows[0].Index;
                    if (selIndex < gridData.Rows.Count)
                    {
                        selIndex++;
                        gridData.FirstDisplayedScrollingRowIndex = selIndex;
                        gridData.Rows[selIndex].Selected = true;
                    }
                    break;
                case Keys.Enter:
                    break;
            }
            //gridData.MultiSelect = false;
            //gridData.ClearSelection();
            //gridData.FocusedRowHandle = rowId;
            //gridData.MultiSelect = true;
            //gridData.SelectedRows(rowId);
        }
    }
}
