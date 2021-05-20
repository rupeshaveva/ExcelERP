namespace appExcelERP.Forms
{
    partial class frmAlertsAndNotificatrionsView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearchNotification = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.gridNotifications = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchNotification
            // 
            this.txtSearchNotification.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchNotification.Location = new System.Drawing.Point(5, 5);
            this.txtSearchNotification.Name = "txtSearchNotification";
            this.txtSearchNotification.Size = new System.Drawing.Size(331, 20);
            this.txtSearchNotification.TabIndex = 0;
            this.txtSearchNotification.TextChanged += new System.EventHandler(this.txtSearchNotification_TextChanged);
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(5, 5);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 1;
            this.kryptonNavigator1.Size = new System.Drawing.Size(343, 461);
            this.kryptonNavigator1.TabIndex = 2;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.gridNotifications);
            this.kryptonPage1.Controls.Add(this.txtSearchNotification);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPage1.Size = new System.Drawing.Size(341, 434);
            this.kryptonPage1.Text = "Notifications";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "B026CEF5551A420165BCB5BEA0A7210E";
            // 
            // gridNotifications
            // 
            this.gridNotifications.AllowUserToAddRows = false;
            this.gridNotifications.AllowUserToDeleteRows = false;
            this.gridNotifications.AllowUserToOrderColumns = true;
            this.gridNotifications.AllowUserToResizeColumns = false;
            this.gridNotifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNotifications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridNotifications.ColumnHeadersVisible = false;
            this.gridNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNotifications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridNotifications.Location = new System.Drawing.Point(5, 25);
            this.gridNotifications.Name = "gridNotifications";
            this.gridNotifications.ReadOnly = true;
            this.gridNotifications.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridNotifications.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridNotifications.Size = new System.Drawing.Size(331, 404);
            this.gridNotifications.TabIndex = 2;
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(341, 434);
            this.kryptonPage2.Text = "Scheduled Alerts";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "B05F597C45284F63A692BEE699EA3E77";
            // 
            // frmAlertsAndNotificatrionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 471);
            this.Controls.Add(this.kryptonNavigator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlertsAndNotificatrionsView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alerts && Notifications";
            this.Load += new System.EventHandler(this.frmAlertsAndNotificatrionsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchNotification;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridNotifications;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
    }
}