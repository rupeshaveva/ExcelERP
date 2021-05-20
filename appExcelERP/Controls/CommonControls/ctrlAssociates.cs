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
using System.IO;
using libERP.MODELS.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlAssociates : UserControl
    {

        private ServiceUOW _UOM = null;

        public int SelectedID { get; set; }
        public APP_ENTITIES ENTITY { get; set; }

        BindingList<AssociatedEmployeeModel> _EmployeesList = null;
        BindingList<AssociatedEmployeeModel> _AssociatesList = null;
        BindingList<AssociatedEmployeeModel> _filteredList = null;

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnAssociate.Enabled = btnDisassociate.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    gridEmployees.Enabled = txtSearchAssociates.Enabled = txtSearchEmployee.Enabled = false;
                }
                else
                {
                    btnAssociate.Enabled = btnDisassociate.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    gridAssociated.Enabled = gridEmployees.Enabled = txtSearchAssociates.Enabled = txtSearchEmployee.Enabled = true;
                }
            }
        }

        public ctrlAssociates()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
        }
        public ctrlAssociates(APP_ENTITIES EntityToAssociate)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.ENTITY = EntityToAssociate;
        }
        private void ctrlAssociates_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                splitAssociates.SplitterDistance = (int)(this.Height * 0.5);
                populateEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAssociates::ctrlAssociates_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }
        public void populateEmployees()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _EmployeesList = AppCommon.ConvertToBindingList<AssociatedEmployeeModel>(_UOM.MasterService.GetAllEmployeesForAssociation());
                gridEmployees.DataSource = _EmployeesList;
                gridEmployees.Columns["ID"].Visible = gridEmployees.Columns["ImagePath"].Visible = gridEmployees.Columns["StringExpression"].Visible = gridEmployees.Columns["ContactNumber"].Visible = gridEmployees.Columns["EmailAddress"].Visible = false;
                gridEmployees.ReadOnly = true;
                gridEmployees.Columns["Selected"].Width = (int)(gridEmployees.Width * .1);
                gridEmployees.Columns["Code"].Width = (int)(gridEmployees.Width * .1);
                gridEmployees.Columns["Name"].Width = (int)(gridEmployees.Width * .3);
                gridEmployees.Columns["Designation"].Width = (int)(gridEmployees.Width * .4);
                gridEmployees.Columns["Department"].Width = (int)(gridEmployees.Width * .1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAssociates::populateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void gridEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (gridEmployees.Rows[e.RowIndex].Cells["ImagePath"].Value == null)
                {
                    this.pictureEmployee.Image = global::appExcelERP.Properties.Resources._1383042568_administrator;
                    return;
                }
                string filePath = AppCommon.GetEmployeeImagePath() + gridEmployees.Rows[e.RowIndex].Cells["ImagePath"].Value.ToString();
                if (File.Exists(filePath))
                    pictureEmployee.Load(filePath);
                headerGroupEmployees.ValuesSecondary.Heading = string.Format("Contact Number(s): {1} Email: {0}", gridEmployees.Rows[e.RowIndex].Cells["EmailAddress"].Value.ToString(), gridEmployees.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAssociates::gridEmployees_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridEmployees.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridEmployees.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        public void PopulateAssociatedEmployees()
        {
            pictureAssociate.Image = null;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        _AssociatesList = AppCommon.ConvertToBindingList(_UOM.SalesLeadService.GetAssociatesForLeadID(this.SelectedID));
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        _AssociatesList = AppCommon.ConvertToBindingList((new ServiceSalesEnquiry()).GetAssociatesForEnquiryID(this.SelectedID));
                        break;
                    case APP_ENTITIES.SALES_QUOTATION:
                        _AssociatesList = AppCommon.ConvertToBindingList((new ServiceSalesQuotation()).GetAssociatesForQuotationID(this.SelectedID));
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        _AssociatesList = AppCommon.ConvertToBindingList((new ServiceSalesOrder()).GetAssociatesForSalesOrderID(this.SelectedID));
                        break;
                    
                }

                gridAssociated.DataSource = _AssociatesList;
                gridAssociated.Columns["ID"].Visible = gridAssociated.Columns["ImagePath"].Visible = gridAssociated.Columns["StringExpression"].Visible = gridAssociated.Columns["ContactNumber"].Visible = gridAssociated.Columns["EmailAddress"].Visible = false;
                gridAssociated.ReadOnly = true;
                gridAssociated.Columns["Selected"].Width = (int)(gridAssociated.Width * .1);
                gridAssociated.Columns["Code"].Width = (int)(gridAssociated.Width * .1);
                gridAssociated.Columns["Name"].Width = (int)(gridAssociated.Width * .3);
                gridAssociated.Columns["Designation"].Width = (int)(gridAssociated.Width * .4);
                gridAssociated.Columns["Department"].Width = (int)(gridAssociated.Width * .1);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAssociates::PopulateAssociatedEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredList = new BindingList<AssociatedEmployeeModel>(_EmployeesList.Where(
                 p => p.StringExpression.Contains(txtSearchEmployee.Text.ToUpper())).ToList());
                gridEmployees.DataSource = _filteredList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAssociates::txtSearchEmployee_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnAssociate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string IDs = string.Empty;
            try
            {
                foreach (DataGridViewRow row in gridEmployees.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value)
                    {
                        IDs +=string.Format("{0}{1}", row.Cells["ID"].Value.ToString() , Program.DefaultStringSeperator);
                    }
                }

                if (IDs.Length > 0)
                {
                    IDs = IDs.Substring(0, IDs.Length - 1);
                    switch (this.ENTITY)
                    {
                        case APP_ENTITIES.SALES_LEAD:
                            (new ServiceSalesLead()).AssociateEmployees(IDs, this.SelectedID);
                            break;
                        case APP_ENTITIES.SALES_ENQUIRY:
                            (new ServiceSalesEnquiry()).AssociateEmployees(IDs, this.SelectedID);
                            break;
                        case APP_ENTITIES.SALES_QUOTATION:
                            (new ServiceSalesQuotation()).AssociateEmployees(IDs, this.SelectedID);
                            break;
                        case APP_ENTITIES.SALES_ORDER:
                            (new ServiceSalesOrder()).AssociateEmployees(IDs, this.SelectedID);
                            break;
                    }
                    PopulateAssociatedEmployees();
                    populateEmployees();
                }
                else
                    MessageBox.Show("Select atelast one associate !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAssociates::btnAssociate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnDisassociate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string IDs = string.Empty;
            try
            {
                foreach (DataGridViewRow row in gridAssociated.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value)
                    {
                        IDs += string.Format("{0}{1}", row.Cells["ID"].Value.ToString(), Program.DefaultStringSeperator);
                    }
                }
                if (IDs.Length > 0)
                {
                    IDs = IDs.Trim().TrimEnd(Program.DefaultStringSeperator);
                    switch (this.ENTITY)
                    {
                        case APP_ENTITIES.SALES_LEAD: (new ServiceSalesLead()).DisassociateEmployees(IDs, this.SelectedID); break;
                        case APP_ENTITIES.SALES_ENQUIRY: (new ServiceSalesEnquiry()).DisassociateEmployees(IDs, this.SelectedID); break;
                        case APP_ENTITIES.SALES_QUOTATION: (new ServiceSalesQuotation()).DisassociateEmployees(IDs, this.SelectedID);
                            break;
                        case APP_ENTITIES.SALES_ORDER: (new ServiceSalesOrder()).DisassociateEmployees(IDs, this.SelectedID);
                            break;
                    }
                    populateEmployees();
                    PopulateAssociatedEmployees();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAssociates::btnDisassociate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridAssociated_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ReadOnly)
                gridAssociated.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridAssociated.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        private void gridAssociated_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (gridAssociated.Rows[e.RowIndex].Cells["ImagePath"].Value == null)
                {
                    this.pictureAssociate.Image = global::appExcelERP.Properties.Resources._1383042568_administrator;
                    return;
                }
                string filePath = AppCommon.GetEmployeeImagePath() + gridAssociated.Rows[e.RowIndex].Cells["ImagePath"].Value.ToString();
                if (File.Exists(filePath))
                    pictureAssociate.Load(filePath);
                headerGroupAssociates.ValuesSecondary.Heading = string.Format("Contact Number(s): {1} Email: {0}", gridAssociated.Rows[e.RowIndex].Cells["EmailAddress"].Value.ToString(), gridAssociated.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAssociates::gridAssociated_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void txtSearchAssociates_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredList = new BindingList<AssociatedEmployeeModel>(_AssociatesList.Where(
                                    p => p.StringExpression.Contains(txtSearchAssociates.Text.ToUpper())).ToList());
                gridAssociated.DataSource = _filteredList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAssociates::txtSearchAssociates_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void ctrlAssociates_Resize(object sender, EventArgs e)
        {
            splitAssociates.SplitterDistance = (int)(this.Height * .5);
        }
        private void gridEmployees_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }
    }
}
