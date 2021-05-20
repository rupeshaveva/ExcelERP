using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.PMC;
using libERP.MODELS;
using libERP;
using libERP.MODELS.PROJECTS;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.PMC
{
    public partial class ControlProjectGeneralInfo : UserControl
    {
        public ControlProjectGeneralInfo()
        {
            InitializeComponent();
        }
        public ProjectGeneralInfo Project_generalInfo = null;

        public int SelectedProjectID { get; set; }
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;

            }
        }
        public void PopulateProjectGeneralInfo()
        {

            this.Cursor = Cursors.WaitCursor;
            Application.UseWaitCursor = true;
            ServiceProject _service = new ServiceProject();
            try
            {
                SelectListItem selItem = null;
                List<SelectListItem> lst = _service.GetAllProjectStatuses();
                TBL_MP_PMC_ProjectMaster model = (new ServiceProject()).GetProjectDBInfoByID(this.SelectedProjectID);

               if (model != null)
                {
                    headerGroupMain.ValuesPrimary.Heading = model.ProjectNumber;
                    selItem = lst.Where(x => x.ID == model.FK_ProjectStatusID).FirstOrDefault();
                    txtStatus.Text = selItem.Description;

                    txtProjectNo.Text = model.ProjectNumber;
                    txtProjectName.Text = model.ProjectName;
                    dtProjectDate.Value = (DateTime)model.ProjectDate;
                    dtProjectStartDate.Value = (DateTime)model.StartDate;
                    dtProjectEndDate.Value = (DateTime)model.EndDate;

                    // txtBillingAddress.Text = Project_generalInfo.BillingClientAddressID.ToString();
                    // txtClientAddress.Text = Project_generalInfo.SiteClientAddressID.ToString();
                    ServiceProject serviceProject = new ServiceProject();
                    txtBillingAddress.Text = serviceProject.GetProjectBillingAddress((int)model.PK_ProjectID);
                    txtClientAddress.Text = serviceProject.GetProjectSiteAddress((int)model.PK_ProjectID);
                    lblCreatedDateTime.Text =model.CreatedDatetime.ToString();
                    lblModifiedDateTime.Text = model.ModifiedDatetime.ToString();
                    ServiceEmployee emp = new ServiceEmployee();
                    List<SelectListItem> lst1 = emp.GetAllEmployees();
                    selItem = lst1.Where(x => x.ID == model.CreatedBy).FirstOrDefault();
                    lblCreatedBy.Text = selItem.Description;
                    List<SelectListItem> lst2 = emp.GetAllEmployees();
                    selItem = lst2.Where(x => x.ID == model.ModifiedBy).FirstOrDefault();
                    lblModifiedBy.Text = selItem.Description;

                    TBL_MP_Admin_Company_Master myComp = (new ServiceMASTERS()).MyCompanyInfo();
                    if (myComp != null)
                    {
                        txtCompanyAddress.Text = myComp.Address;
                    }
               }
                else
                {
                    txtProjectNo.Text = txtProjectName.Text = txtStatus.Text =
                        txtBillingAddress.Text = txtClientAddress.Text =txtCompanyAddress.Text= string.Empty;
                    dtProjectDate.Checked = dtProjectStartDate.Checked = dtProjectEndDate.Checked = false;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlProjectGeneralInfo::PopulateProjectGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            Application.UseWaitCursor = false;

        }

        private void ControlSalesOrderGeneralInfo_Load(object sender, EventArgs e)
        {

        }

      
       
    }
}
