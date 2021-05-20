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
using appExcelERP.Forms;
using libERP.MODELS;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeAuthorities : UserControl
    {
        public int EmployeeID { get; set; }
        public int SelectedAuthorityID { get; set; }
        
         public ControlEmployeeAuthorities()
        {
            InitializeComponent();
        }
         public void PopulateAuthoritiesForEmployee()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string colToShow = "EmployeeName,EmploymentDesc,DepartmentName,CategoryDesc,DesignationDesc";
                gridAuthorities.DataSource = (new ServiceEmployee()).GetAllAuthoritiesOfEmployee(this.EmployeeID);
                gridAuthorities.ColumnHeadersHeight = 35;
                gridAuthorities.Columns["EmployeeName"].Visible = true;
                gridAuthorities.Columns["EmployeeName"].HeaderText = "Employee Name";
                gridAuthorities.Columns["EmployeeName"].Width = 250;
         
                gridAuthorities.Columns["EmploymentDesc"].Visible = true;
                gridAuthorities.Columns["EmploymentDesc"].HeaderText = "Employee Description.";
                gridAuthorities.Columns["EmploymentDesc"].Width = 200;

                gridAuthorities.Columns["DepartmentName"].Visible = true;
                gridAuthorities.Columns["DepartmentName"].HeaderText = "Department Name";
                gridAuthorities.Columns["DepartmentName"].Width = 150;

                gridAuthorities.Columns["CategoryDesc"].Visible = true;
                gridAuthorities.Columns["CategoryDesc"].HeaderText = "Category Description";
                gridAuthorities.Columns["CategoryDesc"].Width = 200;

                gridAuthorities.Columns["DesignationDesc"].Visible = true;
                gridAuthorities.Columns["DesignationDesc"].HeaderText = "Designation Description";
                gridAuthorities.Columns["DesignationDesc"].Width = 200;
                headerGroupMain.ValuesSecondary.Heading = string.Format("({0})Records Found", gridAuthorities.Rows.Count);


                foreach (DataGridViewColumn col in gridAuthorities.Columns)
                {
                    col.Visible = colToShow.Contains(col.Name)?true:false;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAuthorities::PopulateAuthoritiesForEmployee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
         private void btnAddMoreAuthorities_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedAuthorityIDs = string.Empty;
                frmGridMultiSelect frm = new frmGridMultiSelect(libERP.MODELS.COMMON.APP_ENTITIES.EMPLOYEES);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    foreach (MultiSelectListItem item in frm.SelectedItems)
                    {
                        selectedAuthorityIDs += item.ID.ToString() + ",";
                    }
                }
                if((new ServiceEmployee()).UpdateEmployeeAuthorities(this.EmployeeID, selectedAuthorityIDs))
                    PopulateAuthoritiesForEmployee();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAuthorities::btnAddMoreAuthorities_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private void gridAuthorities_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedAuthorityID = 0;
                if (gridAuthorities.Rows.Count>0)
                    this.SelectedAuthorityID= int.Parse(gridAuthorities.Rows[e.RowIndex].Cells["PK_EmployeeId"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAuthorities::gridAuthorities_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private void btnRemoveAthorities_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Are you sure to Delete selected Authority Permanently";
                DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    (new ServiceEmployee()).RemoveEmployeeAuthority(this.EmployeeID, this.SelectedAuthorityID);
                    PopulateAuthoritiesForEmployee();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAuthorities::btnRemoveAthorities_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
