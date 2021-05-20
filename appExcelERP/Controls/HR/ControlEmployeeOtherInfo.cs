using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeOtherInfo : UserControl
    {
        public int SelectedEmployeeID { get; set; }
        public int SelectedID { get; set; }
        public int SelectedLastEmployeerID { get; set; }
        public int SelectedEmployeeQualificationID { get; set; }

        BindingList<EmployeeQualificationInfoModel> _EmployeeQualificationList = null;
        BindingList<EmployeeQualificationInfoModel> _filteredEmployeeQualificationList = null;

        BindingList<LastEmployerInfoModel> _LastEmployerInfoList = null;
        BindingList<LastEmployerInfoModel> _filteredLastEmployerInfoList = null;

        public ControlEmployeeOtherInfo()
        {
            InitializeComponent();
        }
        private void ControlEmployeeOtherInfo_Load(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
              //  PopulateEmployeeQualificationAndLastEmployerInfo();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::ControlEmployeeOtherInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void SetReadOnly()
        {
            try
            {
                btnAddNewLastEmployerInfo.Enabled = btnAddNewQualificationInfo.Enabled = btnEditLastEmployerInfo.Enabled  =btnEditQualificationInfo.Enabled =ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ControlEmployeeOtherInfo_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Height * .5);
        }
        
         public void PopulateEmployeeQualificationAndLastEmployerInfo()
         {
             try
             {
                 PopulateEmployeeQualificationGrid();
                  PopulateLastEmployerInfoGrid();
             }
             catch (Exception ex)
             {
                 string errMessage = ex.Message;
                 if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                 MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::PopulateEmployeeGeneralAndResignationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
         }
        
         #region Qualification Info
          private void PopulateEmployeeQualificationGrid()
          {
              try
              {
                _EmployeeQualificationList = AppCommon.ConvertToBindingList<EmployeeQualificationInfoModel>((new ServiceEmployee()).GetAllQualificationOfEmployee(this.SelectedEmployeeID));
                gridQualificationInfo.DataSource = _EmployeeQualificationList;
                foreach (DataGridViewColumn col in gridQualificationInfo.Columns)
                {
                    col.Visible = false;
                }
                    
                gridQualificationInfo.Columns["QualificationName"].Visible =
                gridQualificationInfo.Columns["NameOfInstitute"].Visible =
                gridQualificationInfo.Columns["Grade"].Visible = true;
                headerGroupQualificationInfo.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridQualificationInfo.Rows.Count);
            }
              catch (Exception ex)
              {
                     string errMessage = ex.Message;
                     if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                     MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::PopulateEmployeeQualificationGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
          }
          private void btnAddNewQualificationInfo_Click(object sender, EventArgs e)
          {
              try
              {
                     frmAddEditEmployeeQualification FRM = new frmAddEditEmployeeQualification();
                     FRM.SelectedEmployeeID = this.SelectedEmployeeID;
                     if (FRM.ShowDialog() == DialogResult.OK)
                     {
                         PopulateEmployeeQualificationGrid();
                     }
              }
              catch (Exception ex)
              {
                     string errMessage = ex.Message;
                     if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                     MessageBox.Show(errMessage, "ServiceEmployee::btnAddNewFamilyMember_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }

          }
          private void btnEditQualificationInfo_Click(object sender, EventArgs e)
        {
            try
            {

                frmAddEditEmployeeQualification FRM = new frmAddEditEmployeeQualification(this.SelectedEmployeeQualificationID);
                FRM.EmployeeQualificationID = this.SelectedEmployeeQualificationID;
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    PopulateEmployeeQualificationGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::btnEditQualificationInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
          private void gridQualificationInfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedEmployeeQualificationID = (int)gridQualificationInfo.Rows[e.RowIndex].Cells["EmployeeQualificationID"].Value;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::gridQualificationInfo_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
          private void btnSearchQualification_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredEmployeeQualificationList = new BindingList<EmployeeQualificationInfoModel>(_EmployeeQualificationList.Where(p => p.SearchText.ToUpper().Contains(txtSearchQualification.Text.ToUpper())).ToList());
                gridQualificationInfo.DataSource = _filteredEmployeeQualificationList;
                headerGroupQualificationInfo.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridQualificationInfo.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::btnSearchQualification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
         private void gridQualificationInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {

                foreach (DataGridViewRow row in gridQualificationInfo.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridQualificationInfo.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridQualificationInfo.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::gridQualificationInfo_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          #endregion

         #region Last Employer Info
        private void PopulateLastEmployerInfoGrid()
        {
            try
            {
                _LastEmployerInfoList = AppCommon.ConvertToBindingList<LastEmployerInfoModel>((new ServiceEmployee()).GetAllLastEmployerInfo(this.SelectedEmployeeID));
                gridLastEmployerInfo.DataSource = _LastEmployerInfoList;
               // gridLastEmployerInfo.DataSource = (new ServiceEmployee()).GetAllLastEmployerInfo(this.SelectedEmployeeID);
                foreach (DataGridViewColumn col in gridLastEmployerInfo.Columns)
                {
                    col.Visible = false;
                }
                gridLastEmployerInfo.Columns["LastEmployerName"].Visible =
                gridLastEmployerInfo.Columns["LastEmployerAddress"].Visible =
                gridLastEmployerInfo.Columns["ContactNo"].Visible = true;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::PopulateLastEmployerInfoGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewLastEmployerInfo_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    frmAddEditLastEmployerInfo FRM = new frmAddEditLastEmployerInfo();
                    FRM.SelectedEmployeeID = this.SelectedEmployeeID;
                    if (FRM.ShowDialog() == DialogResult.OK)
                    {
                        PopulateLastEmployerInfoGrid();
                    }
                }
                catch (Exception ex)
                {
                    string errMessage = ex.Message;
                    if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                    MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::btnAddNewLastEmployerInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void btnEditLastEmployerInfo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditLastEmployerInfo FRM = new frmAddEditLastEmployerInfo(this.SelectedLastEmployeerID);
                FRM.SelectedEmployeeID = this.SelectedEmployeeID;
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    PopulateLastEmployerInfoGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::btnEditLastEmployerInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridLastEmployerInfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedLastEmployeerID = (int)gridLastEmployerInfo.Rows[e.RowIndex].Cells["LastEmployerID"].Value;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::gridLastEmployerInfo_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchLastEmployer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredLastEmployerInfoList = new BindingList<LastEmployerInfoModel>(_LastEmployerInfoList.Where(p => p.SearchText.ToUpper().Contains(txtLastEmployerSearch.Text.ToUpper())).ToList());
                gridLastEmployerInfo.DataSource = _filteredLastEmployerInfoList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::btnSearchLastEmployer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridLastEmployerInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in gridLastEmployerInfo.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridLastEmployerInfo.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridLastEmployerInfo.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeOtherInfo::gridLastEmployerInfo_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

      

      
    }
}

