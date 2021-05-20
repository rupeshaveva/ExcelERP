namespace appExcelERP.Controls.USER_INFO
{
    partial class PageUserInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageUserInfo));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolBtnPersonalInfo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnLeaveApplications = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAdvanceRequests = new System.Windows.Forms.ToolStripButton();
            this.toolBtnLoanApplications = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAttendanceViewer = new System.Windows.Forms.ToolStripButton();
            this.toolBtnPayslipViewer = new System.Windows.Forms.ToolStripButton();
            this.tabMY_INFO = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMY_INFO)).BeginInit();
            this.tabMY_INFO.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnPersonalInfo,
            this.toolBtnLeaveApplications,
            this.toolBtnAdvanceRequests,
            this.toolBtnLoanApplications,
            this.toolBtnAttendanceViewer,
            this.toolBtnPayslipViewer});
            this.toolStripMain.Location = new System.Drawing.Point(2, 2);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(778, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolBtnPersonalInfo
            // 
            this.toolBtnPersonalInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnPersonalInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnPersonalInfo.Image")));
            this.toolBtnPersonalInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnPersonalInfo.Name = "toolBtnPersonalInfo";
            this.toolBtnPersonalInfo.Size = new System.Drawing.Size(80, 22);
            this.toolBtnPersonalInfo.Text = "&Personal Info";
            this.toolBtnPersonalInfo.Click += new System.EventHandler(this.HRMenuItem_Click);
            // 
            // toolBtnLeaveApplications
            // 
            this.toolBtnLeaveApplications.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnLeaveApplications.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnLeaveApplications.Image")));
            this.toolBtnLeaveApplications.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnLeaveApplications.Name = "toolBtnLeaveApplications";
            this.toolBtnLeaveApplications.Size = new System.Drawing.Size(110, 22);
            this.toolBtnLeaveApplications.Text = "&Leave Applications";
            this.toolBtnLeaveApplications.Click += new System.EventHandler(this.HRMenuItem_Click);
            // 
            // toolBtnAdvanceRequests
            // 
            this.toolBtnAdvanceRequests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnAdvanceRequests.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnAdvanceRequests.Image")));
            this.toolBtnAdvanceRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAdvanceRequests.Name = "toolBtnAdvanceRequests";
            this.toolBtnAdvanceRequests.Size = new System.Drawing.Size(107, 22);
            this.toolBtnAdvanceRequests.Text = "&Advance Requests";
            this.toolBtnAdvanceRequests.Click += new System.EventHandler(this.HRMenuItem_Click);
            // 
            // toolBtnLoanApplications
            // 
            this.toolBtnLoanApplications.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnLoanApplications.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnLoanApplications.Image")));
            this.toolBtnLoanApplications.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnLoanApplications.Name = "toolBtnLoanApplications";
            this.toolBtnLoanApplications.Size = new System.Drawing.Size(106, 22);
            this.toolBtnLoanApplications.Text = "&Loan Applications";
            this.toolBtnLoanApplications.Click += new System.EventHandler(this.HRMenuItem_Click);
            // 
            // toolBtnAttendanceViewer
            // 
            this.toolBtnAttendanceViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnAttendanceViewer.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnAttendanceViewer.Image")));
            this.toolBtnAttendanceViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAttendanceViewer.Name = "toolBtnAttendanceViewer";
            this.toolBtnAttendanceViewer.Size = new System.Drawing.Size(110, 22);
            this.toolBtnAttendanceViewer.Text = "&Attendance Viewer";
            this.toolBtnAttendanceViewer.Click += new System.EventHandler(this.HRMenuItem_Click);
            // 
            // toolBtnPayslipViewer
            // 
            this.toolBtnPayslipViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnPayslipViewer.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnPayslipViewer.Image")));
            this.toolBtnPayslipViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnPayslipViewer.Name = "toolBtnPayslipViewer";
            this.toolBtnPayslipViewer.Size = new System.Drawing.Size(86, 22);
            this.toolBtnPayslipViewer.Text = "&Payslip Viewer";
            this.toolBtnPayslipViewer.Click += new System.EventHandler(this.HRMenuItem_Click);
            // 
            // tabMY_INFO
            // 
            this.tabMY_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMY_INFO.Location = new System.Drawing.Point(2, 27);
            this.tabMY_INFO.Name = "tabMY_INFO";
            this.tabMY_INFO.Size = new System.Drawing.Size(778, 517);
            this.tabMY_INFO.TabIndex = 2;
            this.tabMY_INFO.Text = "kryptonNavigator1";
            this.tabMY_INFO.SelectedPageChanged += new System.EventHandler(this.tabMY_INFO_SelectedPageChanged);
            this.tabMY_INFO.CloseAction += new System.EventHandler<ComponentFactory.Krypton.Navigator.CloseActionEventArgs>(this.tabMY_INFO_CloseAction);
            // 
            // PageUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMY_INFO);
            this.Controls.Add(this.toolStripMain);
            this.Name = "PageUserInfo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(782, 546);
            this.Load += new System.EventHandler(this.PageUserInfo_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMY_INFO)).EndInit();
            this.tabMY_INFO.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolBtnPersonalInfo;
        private System.Windows.Forms.ToolStripButton toolBtnLeaveApplications;
        private System.Windows.Forms.ToolStripButton toolBtnAttendanceViewer;
        private System.Windows.Forms.ToolStripButton toolBtnAdvanceRequests;
        private System.Windows.Forms.ToolStripButton toolBtnLoanApplications;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabMY_INFO;
        private System.Windows.Forms.ToolStripButton toolBtnPayslipViewer;
    }
}
