using libERP.SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libERP;
 
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.MODELS.COMMON;
using libERP.SERVICES.ADMIN;

namespace appExcelERP
{
    public partial class frmLogin : KryptonForm
    {
        private ServiceUOW _UNIT = null;

        frmSplash _splashForm = null;

        public KryptonManager MANAGER { get; set; }
        public bool LoginSuccess { get; set; }
        public frmLogin()
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            this.LoginSuccess = false;
            InitializeBackgroundWorker();


        }

        #region BACKGROUNDWORKER
        BackgroundWorker bw = null;
        private void InitializeBackgroundWorker()
        {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BackgroundWorker worker = sender as BackgroundWorker;
            ServiceMASTERS _service = _UNIT.MasterService;

            _service.GetAllBraches();
            worker.ReportProgress(10, new eventArgThreadProgressModel()
            {
                Text = "Connecting database.....",
                Key = "CONNECTING",
            });

            worker.ReportProgress(30, new eventArgThreadProgressModel()
            {
                Text = "Fetching FA Years compaleted.",
                Key = "FIN_YEARS",
                List = _service.GetAllFinancialYears()
            });
            worker.ReportProgress(60, new eventArgThreadProgressModel()
            {
                ID = 30,
                Text = "Fetching List Companies completed...",
                Key = "COMPANIES",
                List = _service.GetAllCompanies()
            });
            worker.ReportProgress(100, new eventArgThreadProgressModel()
            {
                ID = 30,
                Text = "Fetching Branches completed...",
                Key = "BRANCHES",
                List = _service.GetAllBraches()
            });

        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            eventArgThreadProgressModel model = (eventArgThreadProgressModel)e.UserState;

            if (e.ProgressPercentage ==10)
            {
               
                _splashForm.Hide();
                _splashForm.Dispose();
                
            }


            lblProgress.Text = model.Text;
            switch (model.Key)
            {
                case "FIN_YEARS":
                    cboFinYear.DataSource = model.List;
                    cboFinYear.DisplayMember = "Description";
                    cboFinYear.ValueMember = "ID";
                    break;
                case "COMPANIES":
                    cboCompany.DataSource = model.List;
                    cboCompany.DisplayMember = "Description";
                    cboCompany.ValueMember = "ID";
                    break;
                case "BRANCHES":
                    cboBranch.DataSource = model.List;
                    cboBranch.DisplayMember = "Description";
                    cboBranch.ValueMember = "ID";
                    break;
                





            }
                      


        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.lblProgress.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.lblProgress.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.lblProgress.Text = "";
            }
        }
        #endregion
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if(this.ValidateChildren()==true)
                {
                    this.LoginSuccess = (new ServiceUsers()).IsVaidUser(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    if (LoginSuccess)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        #region POPULATE USER SPECIFIC INFORMATION
                        Program.CURR_USER = new USER_SESSION();
                        Program.CURR_USER.UserName = txtUserName.Text;
                        Program.CURR_USER.Password = txtPassword.Text;
                        Program.CURR_USER.FinanicalYearText = cboFinYear.Text;
                        Program.CURR_USER.FinYearID = int.Parse(cboFinYear.SelectedValue.ToString());
                        Program.CURR_USER.CompanyID = int.Parse(cboCompany.SelectedValue.ToString());
                        Program.CURR_USER.BranchID = int.Parse(cboBranch.SelectedValue.ToString());

                        TBL_MP_Master_Employee emp = (new ServiceUsers()).GetEmployeeDBModelByUserName(txtUserName.Text);
                        if (emp == null)
                        {
                            MessageBox.Show("Unable to locate Employee Info. for the user", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Program.CURR_USER.UserFullName = emp.EmployeeName;
                        Program.CURR_USER.EmployeeID = emp.PK_EmployeeId;
                        Program.CURR_USER.EmailAddress = emp.EmailAddress;
                        if (emp.FK_DepartmentId != null)
                        {
                            Program.CURR_USER.DepartmentID = (int)emp.FK_DepartmentId;
                            List<SelectListItem> lstDept = (new ServiceMASTERS()).GetAllDepartments();
                            if (lstDept != null)
                            {
                                Program.CURR_USER.DepartmentName = lstDept.Where(x => x.ID == (int)Program.CURR_USER.DepartmentID).FirstOrDefault().Description;
                            }
                        }


                        TBL_User_Master dbUser = (new ServiceUsers()).GetUserDBModelByUserName(txtUserName.Text);
                        if (dbUser != null)
                        {
                            Program.CURR_USER.UserID = dbUser.PK_UserID;
                            if (dbUser.FK_RoleId != null)
                            {
                                Program.CURR_USER.RoleID = (int)dbUser.FK_RoleId;
                                ServiceRoles roleService = new ServiceRoles();
                                TBL_MP_Master_Role dbRole = roleService.GetRoleDBRecordByID(Program.CURR_USER.RoleID);
                                if (dbRole != null)
                                    Program.CURR_USER.RoleName = dbRole.RoleName.ToUpper();
                                Program.CONTROL_ACCESS.UpdateControlAccessListForRole(Program.CURR_USER.RoleID,Program.CURR_USER.EmployeeID);
                            }
                            if (dbUser.Theme != null)
                            {
                                Program.CURRENT_THEME = MANAGER.GlobalPaletteMode = (PaletteModeManager)dbUser.Theme;
                                Program.ColorSelected = MANAGER.GlobalPalette.ColorTable.ButtonSelectedHighlight;
                            }
                        }
                        

                        #endregion
                        this.Cursor = Cursors.Default;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Invalid User Name or Password!!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmLogin::btnLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            Cursor.Current = Cursors.Default;
        
            if (bw.IsBusy != true)
            {
                    bw.RunWorkerAsync();
                    _splashForm = new frmSplash();
                    _splashForm.ShowDialog();
            }


            //AUTOASIGN USER NAME AND PASSWORD
            if(Program.AUTO_LOGIN)
            {
                txtUserName.Text = Program.TEST_USER_NAME;
                txtPassword.Text = Program.TEST_USER_PASSWORD;
            }
            

        }


        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "User Name cannot be left blank.");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be left blank.");
            }
        }

        private void frmLogin_ResizeEnd(object sender, EventArgs e)
        {
           
        }

        private void lblProgress_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
