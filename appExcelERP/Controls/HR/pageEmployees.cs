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
using libERP.SERVICES;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;
using libERP.MODELS.COMMON;
using appExcelERP.Controls.CommonControls;
using ComponentFactory.Krypton.Navigator;

namespace appExcelERP.Controls.HR
{
    public partial class pageEmployees : UserControl
    {
        public int FormOperationID { get; set; }
        public DB_FORM_IDs SelectedTAB { get; set; }
      


        public int SelectedEmployeeID { get; set; }
        public bool SelectedEmployeeActive { get; set; }
        public bool SelectedEmployeeDeleted { get; set; }


        private BindingList<SelectListItem> _ActiveEmployeeList = null;
        private BindingList<SelectListItem> _filteredActiveEmployeeList = null;

        private BindingList<SelectListItem> _InactiveEmployeeList = null;
        private BindingList<SelectListItem> _filteredInactiveEmployeeList = null;

        private ControlEmployeeGeneralInfo  _EmployeeGeneralInfoControl = null;
        private void InitializeEmployeeGeneralInfoControl()
        {
            try
            {
                _EmployeeGeneralInfoControl = new ControlEmployeeGeneralInfo();
                tabpageGeneralInfo.Controls.Clear();
                tabpageGeneralInfo.Controls.Add(_EmployeeGeneralInfoControl);
                _EmployeeGeneralInfoControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeGeneralInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private ControlEmployeePersonalInfo _EmployeePersonalInfoControl = null;
        private void InitializeEmployeePersonalInfoControl()
        {
            try
            {
                _EmployeePersonalInfoControl = new ControlEmployeePersonalInfo();
                tabPagePersonalInfo.Controls.Clear();
                tabPagePersonalInfo.Controls.Add(_EmployeePersonalInfoControl);
                _EmployeePersonalInfoControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeePersonalInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private ControlEmployeeBankInfo _EmployeeBankInfoControl = null;
        private void InitializeEmployeeBankInfoControl()
        {
            try
            {
                _EmployeeBankInfoControl = new ControlEmployeeBankInfo();
                tabPageBankDetails.Controls.Clear();
                tabPageBankDetails.Controls.Add(_EmployeeBankInfoControl);
                _EmployeeBankInfoControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeBankInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        ctrlAttachments _ctrlAttachment = null;
        private void InitializeAttachmentInfoControl()
        {
            _ctrlAttachment = new ctrlAttachments(APP_ENTITIES.EMPLOYEES);
            _ctrlAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
            tabPageAttachment.Controls.Add(_ctrlAttachment);
            _ctrlAttachment.Dock = DockStyle.Fill;
        }

        private ControlEmployeeOtherInfo _EmployeeOtherInfoControl = null;
        private void InitializeEmployeeOtherInfoControl()
        {
            try
            {
                _EmployeeOtherInfoControl = new ControlEmployeeOtherInfo();
                tabPageOtherDetails.Controls.Clear();
                tabPageOtherDetails.Controls.Add(_EmployeeOtherInfoControl);
                _EmployeeOtherInfoControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeOtherInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private ControlEmployeeAdditionalInfo _EmployeeAdditionalDetailControl = null;
        private void InitializeEmployeeAdditionalInfoControl()
        {
            try
            {
                _EmployeeAdditionalDetailControl = new ControlEmployeeAdditionalInfo();
                tabPageAdditionalDetails.Controls.Clear();
                tabPageAdditionalDetails.Controls.Add(_EmployeeAdditionalDetailControl);
                _EmployeeAdditionalDetailControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeAdditionalInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private ControlEmployeeLeaveConfig _EmployeeLeaveConfigControl = null;
        private void InitializeEmployeeLeaveConfigControl()
        {
            try
            {
                _EmployeeLeaveConfigControl = new ControlEmployeeLeaveConfig();
                tabPageLeaveConfiguration.Controls.Clear();
                tabPageLeaveConfiguration.Controls.Add(_EmployeeLeaveConfigControl);
                _EmployeeLeaveConfigControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeLeaveConfigControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private ControlEmployeeCTC _EmployeeCTCControl = null;
        private void InitializeEmployeeCTCControl()
        {
            try
            {
                _EmployeeCTCControl = new ControlEmployeeCTC();
                tabPageCTCInfo.Controls.Clear();
                tabPageCTCInfo.Controls.Add(_EmployeeCTCControl);
                _EmployeeCTCControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeCTCControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private ControlEmployeeAuthorities _EmployeeAuthoritiesControl = null;
        private void InitializeEmployeeAuthoritiesControl()
        {
            try
            {
                _EmployeeAuthoritiesControl = new ControlEmployeeAuthorities();
                tabPageEmployeeAuthorities.Controls.Clear();
                tabPageEmployeeAuthorities.Controls.Add(_EmployeeAuthoritiesControl);
                _EmployeeAuthoritiesControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::InitializeEmployeeAuthoritiesControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public pageEmployees()
        {
            InitializeComponent();
            InitializeEmployeeGeneralInfoControl();
        }
        private void pageEmployees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SetEmployeeInfoTabTags();
                PopulateInactiveEmployeesGrid();
                PopulateActiveEmployeesGrid();
                SplitContainerMain.SplitterDistance=(int)(this.Width*.20);
                SetEmployeeInfoTabAsPerPermission();
                if (_EmployeeGeneralInfoControl != null) this.SelectedTAB = (DB_FORM_IDs)tabpageGeneralInfo.Tag;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::pageEmployees_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #region ACCESS RIGHT MANAGEMENT CODE
        private void SetEmployeeInfoTabTags()
        {
            try
            {
                tabpageGeneralInfo.Tag = DB_FORM_IDs.EMPLOYEE_GENERAL_INFO;
                tabPagePersonalInfo.Tag = DB_FORM_IDs.EMPLOYEE_PERSONAL_DETAILS;
                tabPageBankDetails.Tag = DB_FORM_IDs.EMPLOYEE_BANK_DETAILS;
                tabPageAttachment.Tag = DB_FORM_IDs.EMPLOYEE_ATTACHMENT;
                tabPageOtherDetails.Tag = DB_FORM_IDs.EMPLOYEE_OTHER_DETAIL;
                tabPageAdditionalDetails.Tag = DB_FORM_IDs.EMPLOYEE_ADDITIONAL_DETAILS;
                tabPageLeaveConfiguration.Tag = DB_FORM_IDs.EMPLOYEE_LEAVE_CONFIGURATION;
                tabPageCTCInfo.Tag = DB_FORM_IDs.EMPLOYEE_CTC_INFO;
                tabPageEmployeeAuthorities.Tag = DB_FORM_IDs.EMPLOYEE_AUTHORITIES;

                tabpageGeneralInfo.Visible = 
                tabPagePersonalInfo.Visible = 
                tabPageBankDetails.Visible = 
                tabPageAttachment.Visible = 
                tabPageOtherDetails.Visible =
                tabPageLeaveConfiguration.Visible =
                tabPageAdditionalDetails.Visible = 
                tabPageCTCInfo.Visible= 
                tabPageEmployeeAuthorities.Visible=false;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::SetEmployeeInfoTabTags", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetEmployeeInfoTabAsPerPermission()
        {
            try
            {
                foreach (KryptonPage tabSelected in tabEmployees.Pages)
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
                                    case DB_FORM_IDs.EMPLOYEE_GENERAL_INFO: InitializeEmployeeGeneralInfoControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_PERSONAL_DETAILS: InitializeEmployeePersonalInfoControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_BANK_DETAILS: InitializeEmployeeBankInfoControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_ATTACHMENT: InitializeAttachmentInfoControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_OTHER_DETAIL: InitializeEmployeeOtherInfoControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_ADDITIONAL_DETAILS: InitializeEmployeeAdditionalInfoControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_LEAVE_CONFIGURATION: InitializeEmployeeLeaveConfigControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_CTC_INFO: InitializeEmployeeCTCControl(); break;
                                    case DB_FORM_IDs.EMPLOYEE_AUTHORITIES: InitializeEmployeeAuthoritiesControl(); break;
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
                MessageBox.Show(errMessage, "pageEmployees::SetEmployeeInfoTabAsPerPermission", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshTabPage()
        {
         switch (this.SelectedTAB)
            {
                case DB_FORM_IDs.EMPLOYEE_GENERAL_INFO:
                    if (_EmployeeGeneralInfoControl == null) return;
                    _EmployeeGeneralInfoControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeeGeneralInfoControl.PopulateEmployeeGeneralAndResignationInfo();
                    break;

                case DB_FORM_IDs.EMPLOYEE_PERSONAL_DETAILS:
                    if (_EmployeePersonalInfoControl == null) return;
                    _EmployeePersonalInfoControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeePersonalInfoControl.PopulateEmployeePersonalAndFamilyInfo();
                    break;

                case DB_FORM_IDs.EMPLOYEE_BANK_DETAILS:
                    if (_EmployeeBankInfoControl == null) return;
                    _EmployeeBankInfoControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeeBankInfoControl.PopulateEmployeeBankInfo();
                    break;

                case DB_FORM_IDs.EMPLOYEE_ATTACHMENT:
                    if (_ctrlAttachment == null) return;
                    _ctrlAttachment.SelectedEntityID = this.SelectedEmployeeID;
                    _ctrlAttachment.PopulateDocuments();
                    break;

                case DB_FORM_IDs.EMPLOYEE_OTHER_DETAIL:
                    if (_EmployeeOtherInfoControl == null) return;
                    _EmployeeOtherInfoControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeeOtherInfoControl.PopulateEmployeeQualificationAndLastEmployerInfo();
                    break;
                case DB_FORM_IDs.EMPLOYEE_ADDITIONAL_DETAILS:
                    if (_EmployeeAdditionalDetailControl == null) return;
                    _EmployeeAdditionalDetailControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeeAdditionalDetailControl.PopulateAdditonalInfo();
                    break;
                case DB_FORM_IDs.EMPLOYEE_LEAVE_CONFIGURATION:
                    if (_EmployeeLeaveConfigControl == null) return;
                    _EmployeeLeaveConfigControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeeLeaveConfigControl.PopulateEmployeeLeaveConfigurations();
                    break;
                case DB_FORM_IDs.EMPLOYEE_CTC_INFO:
                    if (_EmployeeCTCControl == null) return;
                    _EmployeeCTCControl.SelectedEmployeeID = this.SelectedEmployeeID;
                    _EmployeeCTCControl.PopulateAllouncesAndDeductionCTCGrid();
                    break;
                case DB_FORM_IDs.EMPLOYEE_AUTHORITIES:
                    if (_EmployeeAuthoritiesControl == null) return;
                    _EmployeeAuthoritiesControl.EmployeeID = this.SelectedEmployeeID;
                    _EmployeeAuthoritiesControl.PopulateAuthoritiesForEmployee();
                    break;

            }

        }
        #endregion

        private void tabEmployees_TabClicked(object sender, ComponentFactory.Krypton.Navigator.KryptonPageEventArgs e)
        {
            this.SelectedTAB = (DB_FORM_IDs)((KryptonNavigator)sender).Pages[e.Index].Tag;
            this.RefreshTabPage();
        }

        #region ACTIVE EMPLOYEES
        private void PopulateActiveEmployeesGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _ActiveEmployeeList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceEmployee()).GetAllActiveEmployees());
                gridActiveEmployees.DataSource = _ActiveEmployeeList;
                headerGroupActiveEmployees.ValuesSecondary.Heading = string.Format("{0} records found.", gridActiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::PopulateActiveEmployeesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridActiveEmployees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridActiveEmployees.Columns["ID"].Visible = gridActiveEmployees.Columns["Code"].Visible = gridActiveEmployees.Columns["IsActive"].Visible = gridActiveEmployees.Columns["DescriptionToUpper"].Visible = false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::gridActiveEmployees_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
   
        private void gridActiveEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedEmployeeID = (int)gridActiveEmployees.Rows[e.RowIndex].Cells["ID"].Value;


                this.SelectedEmployeeActive = true;
                this.SelectedEmployeeDeleted = ServiceEmployee.IsDeletedEmployee(this.SelectedEmployeeID);
                btnDeleteItem.Text = (this.SelectedEmployeeDeleted) ? "Undelete" : "Delete";
                btnActivate.Text = (this.SelectedEmployeeActive) ? "Deactivate" : "Activate";
                string strDescription= gridActiveEmployees.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", "  ");


                headerGroupMain.ValuesPrimary.Heading = strDescription.ToUpper();
                headerGroupActiveEmployees.ValuesSecondary.Heading = this.SelectedEmployeeID.ToString();
                RefreshTabPage();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::gridActiveEmployees_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefreshActiveEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateActiveEmployeesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnRefreshActiveEmployees_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSearchActiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredActiveEmployeeList = new BindingList<SelectListItem>(_ActiveEmployeeList.Where(p => p.DescriptionToUpper.Contains(txtSearchActiveEmployees.Text.ToUpper())).ToList());
                gridActiveEmployees.DataSource = _filteredActiveEmployeeList;
                headerGroupActiveEmployees.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridActiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::txtSearchActiveEmployees_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region INACTIVE EMPLOYEES
        private void PopulateInactiveEmployeesGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _InactiveEmployeeList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceEmployee()).GetAllInactiveEmployees());
                gridInactiveEmployees.DataSource = _InactiveEmployeeList;
                headerGroupInactiveEmployees.ValuesSecondary.Heading = string.Format("{0} records found.", gridInactiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::PopulateInactiveEmployeesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridInactiveEmployees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridInactiveEmployees.Columns["ID"].Visible = gridInactiveEmployees.Columns["Code"].Visible = gridInactiveEmployees.Columns["IsActive"].Visible = gridInactiveEmployees.Columns["DescriptionToUpper"].Visible = false;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::gridInactiveEmployees_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
         private void gridInactiveEmployees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedEmployeeID = (int)gridInactiveEmployees.Rows[e.RowIndex].Cells["ID"].Value;
                string strDescription = gridInactiveEmployees.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", "  ");
                headerGroupMain.ValuesPrimary.Heading = strDescription.ToUpper();

                this.SelectedEmployeeActive = false;
                this.SelectedEmployeeDeleted = ServiceEmployee.IsDeletedEmployee(this.SelectedEmployeeID);
                btnDeleteItem.Text = (this.SelectedEmployeeDeleted) ? "Undelete" : "Delete";
                btnActivate.Text = (this.SelectedEmployeeActive) ? "Deactivate" : "Activate";

                RefreshTabPage();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::gridInactiveEmployees_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefreshInactiveEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateInactiveEmployeesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnRefreshInactiveEmployees_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSearchInactiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredInactiveEmployeeList = new BindingList<SelectListItem>(_InactiveEmployeeList.Where(p => p.DescriptionToUpper.Contains(txtSearchInactiveEmployees.Text.ToUpper())).ToList());
                gridInactiveEmployees.DataSource = _filteredInactiveEmployeeList;
                headerGroupInactiveEmployees.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridInactiveEmployees.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::txtSearchInactiveEmployees_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditEmployee frm = new frmAddEditEmployee();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateActiveEmployeesGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnAddNewEmployee_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditEmployee frm = new frmAddEditEmployee(this.SelectedEmployeeID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateActiveEmployeesGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnEditEmployee_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateActiveEmployeesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you Sure to {0}\n{1}",
                    ((this.SelectedEmployeeDeleted)?"Undelete":"Delete"),headerGroupMain.ValuesPrimary.Heading);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    (new ServiceEmployee()).DeleteEmployee(this.SelectedEmployeeID, !this.SelectedEmployeeDeleted);
                    PopulateActiveEmployeesGrid();
                    PopulateInactiveEmployeesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnDeleteItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you Sure to {0}\n{1}",
                    ((this.SelectedEmployeeActive) ? "Deactivate" : "Activate"), headerGroupMain.ValuesPrimary.Heading);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    (new ServiceEmployee()).DeactivateEmployee(this.SelectedEmployeeID, !this.SelectedEmployeeActive);
                    PopulateActiveEmployeesGrid();
                    PopulateInactiveEmployeesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageEmployees::btnActivate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }

       

       
    }
}
