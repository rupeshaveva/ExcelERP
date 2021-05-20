using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.UserList;
using libERP.MODELS.COMMON;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.CRM
{
    public partial class pageProjectChecklist : UserControl
    {
        public int SelectedProjectCheckPointID { get; set; }
        private string SelectedCheckListItem = string.Empty;
        private int SelectedCheckListItemID = 0;

        BindingList<SelectListItem> _ProjectCheckList = null;
        BindingList<SelectListItem> _filteredProjectCheckList = null;


        public pageProjectChecklist()
        {
            InitializeComponent();
        }
        private void pageProjectChecklist_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateCheckPointsGrid();
             }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::pageProjectChecklist_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #region CHECKPOINT
        private void PopulateCheckPointsGrid()
        {
             this.Cursor = Cursors.WaitCursor;
                try
                {
                    _ProjectCheckList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllProjectCheckPoints());
                    gridCheckPoints.DataSource = _ProjectCheckList;
                    gridCheckPoints.Columns["ID"].Visible =
                    gridCheckPoints.Columns["DescriptionToUpper"].Visible =
                    gridCheckPoints.Columns["Code"].Visible =
                    gridCheckPoints.Columns["IsActive"].Visible = false;

                    headerGroupProjectyCheckPoint.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCheckPoints.Rows.Count);
                }
            
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::PopulateCheckPointsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            this.Cursor = Cursors.Default;
        }
        private void btnAddNewCheckPoint_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.MASTERCategoryID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.ProjectChecklistPointCategory).FirstOrDefault().DEFAULT_VALUE;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCheckPointsGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::btnAddNewCheckPoint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnEditCheckPoint_Click(object sender, EventArgs e)
        {
            try
            {

                frmMasterUserList frm = new frmMasterUserList(this.SelectedProjectCheckPointID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCheckPointsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::btnEditCheckPoint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridCheckPoints_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedProjectCheckPointID = int.Parse(gridCheckPoints.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                PopulateCheckListGrid();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::gridCheckPoints_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       #endregion

        #region CHECKLIST
        private void PopulateCheckListGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _ProjectCheckList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceCheckListMaster()).GetAllCheckListItemsForCheckPoint(SelectedProjectCheckPointID));
                gridCheckList.DataSource = _ProjectCheckList;
                gridCheckList.Columns["ID"].Visible =
                gridCheckList.Columns["DescriptionToUpper"].Visible =
                gridCheckList.Columns["Code"].Visible =
                gridCheckList.Columns["IsActive"].Visible = false;

                headerGroupProjectyCheckPoint.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCheckPoints.Rows.Count);
            }

            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::PopulateCheckListGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            this.Cursor = Cursors.Default;
        }
        private void btnAddNewCheckList_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCheckList frm = new frmAddEditCheckList();
                frm.CategoryID = this.SelectedProjectCheckPointID;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCheckListGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::btnAddNewCheckList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnEditCheckLIst_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCheckList frm = new frmAddEditCheckList(this.SelectedCheckListItemID);
                frm.CategoryID = this.SelectedProjectCheckPointID;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCheckListGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::btnEditCheckLIst_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnDeleteCheckList_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Format("Are you sure to delete CheckList Item\n{0}", SelectedCheckListItem);
                if (MessageBox.Show(str, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    (new ServiceCheckListMaster()).DeleteCheckListItem(this.SelectedCheckListItemID);
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::btnDeleteCheckList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridCheckList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedCheckListItemID = int.Parse(gridCheckList.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                this.SelectedCheckListItem = gridCheckList.Rows[e.RowIndex].Cells["Description"].Value.ToString();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageProjectChecklist::btnAddNewCheckList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion









    }
}
