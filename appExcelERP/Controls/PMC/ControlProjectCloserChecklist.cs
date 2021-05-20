using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.PROJECTS;
using libERP.SERVICES.PMC;

namespace appExcelERP.Controls.PMC
{
    public partial class ControlProjectCloserChecklist : UserControl
    {
        public int SelectedProjectID { get; set; }
        public ProjectCheckListModel PROJECT_CHECKLIST = null;
        public ControlProjectCloserChecklist()
        {
            InitializeComponent();
        }

        public void PopulateProjectCheckList()
        {
            try
            {
                PROJECT_CHECKLIST = (new ServiceProjectCheckList()).GetProjectCheckListForProjectID(this.SelectedProjectID);
                gridProjectCheckList.DataSource = PROJECT_CHECKLIST.LIST_ITEMS;

            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectCloserChecklist::PopulateProjectCheckList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridProjectCheckList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridProjectCheckList.Columns["SerialNo"].Width = 50;
                gridProjectCheckList.Columns["SerialNo"].HeaderText = "Sr. No.";
                gridProjectCheckList.Columns["YES"].Width = 35;
                gridProjectCheckList.Columns["NO"].Width = 35;
                gridProjectCheckList.Columns["NA"].Width = 35;
                gridProjectCheckList.Columns["IsChecklistItem"].Visible = false;
                gridProjectCheckList.Columns["Description"].ReadOnly = true;

                foreach (DataGridViewRow row in gridProjectCheckList.Rows)
                {
                    if ((bool)row.Cells["IsChecklistItem"].Value == false)
                    {
                        Font font = new Font( this.Font.FontFamily,10,FontStyle.Bold);
                        row.DefaultCellStyle.Font = font;
                        row.ReadOnly = true;
                        
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectCloserChecklist::gridProjectCheckList_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridProjectCheckList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if ((bool)gridProjectCheckList.Rows[e.RowIndex].Cells["IsChecklistItem"].Value == false)
                    {
                        if (gridProjectCheckList.Columns[e.ColumnIndex].Name == "YES" ||
                            gridProjectCheckList.Columns[e.ColumnIndex].Name == "NO" ||
                            gridProjectCheckList.Columns[e.ColumnIndex].Name == "NA"
                            )
                        {
                            e.PaintBackground(e.ClipBounds, true);
                            e.Handled = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectCloserChecklist::gridProjectCheckList_CellPainting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnUpdateCheckList_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = (new ServiceProjectCheckList()).UpdateProjectCheckListForProjectID(this.SelectedProjectID, this.PROJECT_CHECKLIST);
                if (result)
                {
                    MessageBox.Show("Successfully Updated Project Check List into the database", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectCloserChecklist::btnUpdateCheckList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridProjectCheckList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((bool)gridProjectCheckList.Rows[e.RowIndex].Cells["IsChecklistItem"].Value == true)
                {
                    if (gridProjectCheckList.Columns[e.ColumnIndex].Name == "YES")
                    {
                        if ((bool)gridProjectCheckList.Rows[e.RowIndex].Cells["YES"].Value == true)
                        {
                            gridProjectCheckList.Rows[e.RowIndex].Cells["NO"].Value = false;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["NA"].Value = false;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["Remark"].ReadOnly = false;
                        }
                    }
                    if (gridProjectCheckList.Columns[e.ColumnIndex].Name == "NO")
                    {
                        if ((bool)gridProjectCheckList.Rows[e.RowIndex].Cells["NO"].Value == true)
                        {
                            gridProjectCheckList.Rows[e.RowIndex].Cells["YES"].Value = false;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["NA"].Value = false;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["Remark"].Value = string.Empty;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["Remark"].ReadOnly = true;
                        }
                    }
                    if (gridProjectCheckList.Columns[e.ColumnIndex].Name == "NA")
                    {
                        if ((bool)gridProjectCheckList.Rows[e.RowIndex].Cells["NA"].Value == true)
                        {
                            gridProjectCheckList.Rows[e.RowIndex].Cells["YES"].Value = false;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["NO"].Value = false;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["Remark"].Value = string.Empty;
                            gridProjectCheckList.Rows[e.RowIndex].Cells["Remark"].ReadOnly = true;
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectCloserChecklist::gridProjectCheckList_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
