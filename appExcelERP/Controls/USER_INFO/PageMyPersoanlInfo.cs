using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Controls.HR;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using appExcelERP.Controls.CommonControls;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.USER_INFO
{
    public partial class PageMyPersoanlInfo : UserControl
    {
        public DB_FORM_IDs SelectedTAB { get; set; }

        public ControlEmployeeGeneralInfo _controlGeneralInfo { get; set; }
        private ControlEmployeePersonalInfo _controlPersonalInfo { get; set; }
        private ControlEmployeeBankInfo _controlBankInfo { get; set; }
        private ctrlAttachments _ctrlAttachment { get; set; }
        private ControlEmployeeOtherInfo _controlOtherInfo { get; set; }
        private ControlEmployeeAdditionalInfo _controlAdditionalInfo { get; set; }
        private ControlEmployeeLeaveConfig _ControlLeaveInfo { get; set; }
        private ControlEmployeeCTC _ControlCTCInfo { get; set; }

        public PageMyPersoanlInfo()
        {
            InitializeComponent();
        }

        private void PageMyPersoanlInfo_Load(object sender, EventArgs e)
        {
            try
            {
                // GENERAL INFO CONTROL 
                _controlGeneralInfo = new ControlEmployeeGeneralInfo();
                _controlGeneralInfo.SelectedEmployeeID = Program.CURR_USER.EmployeeID;
                tabPageGeneralInfo.Controls.Add(_controlGeneralInfo);
                _controlGeneralInfo.Dock = DockStyle.Fill;
                _controlGeneralInfo.PopulateEmployeeGeneralAndResignationInfo();
                _controlGeneralInfo.SetReadOnly();
              
                // PERSONAL INFO CONTROL 
                _controlPersonalInfo = new ControlEmployeePersonalInfo();
                _controlPersonalInfo.SelectedEmployeeID = Program.CURR_USER.EmployeeID;
                tabPagePersonalInfo.Controls.Add(_controlPersonalInfo);
                _controlPersonalInfo.Dock = DockStyle.Fill;
                _controlPersonalInfo.PopulateEmployeePersonalAndFamilyInfo();
                _controlPersonalInfo.SetReadOnly();

                // BANK INFO
                _controlBankInfo = new ControlEmployeeBankInfo();
                _controlBankInfo.SelectedEmployeeID = Program.CURR_USER.EmployeeID;
                tabPageBankInfo.Controls.Add(_controlBankInfo);
                _controlBankInfo.Dock = DockStyle.Fill;
                _controlBankInfo.PopulateEmployeeBankInfo();
                 _controlBankInfo.SetReadOnly();

                // ATTACHMENT INFO.
                _ctrlAttachment = new ctrlAttachments(APP_ENTITIES.EMPLOYEES);
                _ctrlAttachment.CONTROL_ORIENTATION = Orientation.Vertical;
                tabPageAttachmentInfo.Controls.Add(_ctrlAttachment);
                _ctrlAttachment.Dock = DockStyle.Fill;
                _ctrlAttachment.SelectedEntityID = Program.CURR_USER.EmployeeID;
                _ctrlAttachment.PopulateDocuments();
                _ctrlAttachment.SetReadOnly();

                // OTHER INFO - ATION AND WORK EXPERIENCE
                _controlOtherInfo = new ControlEmployeeOtherInfo();
                tabPageOtherInfo.Controls.Clear();
                tabPageOtherInfo.Controls.Add(_controlOtherInfo);
                _controlOtherInfo.Dock = DockStyle.Fill;
                _controlOtherInfo.PopulateEmployeeQualificationAndLastEmployerInfo();
                 _controlOtherInfo.SetReadOnly();

                // ADDITIONAL INFO
                _controlAdditionalInfo = new ControlEmployeeAdditionalInfo();
                tabPageAdditionalInfo.Controls.Clear();
                tabPageAdditionalInfo.Controls.Add(_controlAdditionalInfo);
                _controlAdditionalInfo.Dock = DockStyle.Fill;
                _controlAdditionalInfo.SelectedEmployeeID = Program.CURR_USER.EmployeeID;
                _controlAdditionalInfo.PopulateAdditonalInfo();
                _controlAdditionalInfo.SetReadOnly();

                // LEAVE INFO
                _ControlLeaveInfo = new ControlEmployeeLeaveConfig();
                tabPageLeaveInfo.Controls.Clear();
                tabPageLeaveInfo.Controls.Add(_ControlLeaveInfo);
                _ControlLeaveInfo.Dock = DockStyle.Fill;
                _ControlLeaveInfo.SelectedEmployeeID = Program.CURR_USER.EmployeeID;
                _ControlLeaveInfo.PopulateEmployeeLeaveConfigurations();
                _ControlLeaveInfo.SetReadOnly();

                //CTC INFO
                _ControlCTCInfo = new ControlEmployeeCTC();
                tabPageCtcInfo.Controls.Clear();
                tabPageCtcInfo.Controls.Add(_ControlCTCInfo);
                _ControlCTCInfo.Dock = DockStyle.Fill;
                _ControlCTCInfo.SelectedEmployeeID = Program.CURR_USER.EmployeeID;
                _ControlCTCInfo.PopulateAllouncesAndDeductionCTCGrid();
                _ControlCTCInfo.SetReadOnly();                                       

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeAuthorities::PageMyPersoanlInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
