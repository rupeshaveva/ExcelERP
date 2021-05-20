namespace appExcelERP.Controls.CRM
{
    partial class PageSalesDashboard
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
            this.tabDashboard = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pageInvoicing = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.pageTotalRecovery = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.pageBalanceToRecover = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.pageEnquiriesMade = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.pageSalesOrders = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.ctrlDashboardInvoicing1 = new appExcelERP.Controls.CRM.ctrlDashboardInvoicing();
            ((System.ComponentModel.ISupportInitialize)(this.tabDashboard)).BeginInit();
            this.tabDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageInvoicing)).BeginInit();
            this.pageInvoicing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageTotalRecovery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageBalanceToRecover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageEnquiriesMade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageSalesOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDashboard
            // 
            this.tabDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDashboard.Location = new System.Drawing.Point(5, 5);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pageInvoicing,
            this.pageTotalRecovery,
            this.pageBalanceToRecover,
            this.pageEnquiriesMade,
            this.pageSalesOrders});
            this.tabDashboard.SelectedIndex = 0;
            this.tabDashboard.Size = new System.Drawing.Size(937, 532);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "kryptonNavigator1";
            // 
            // pageInvoicing
            // 
            this.pageInvoicing.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageInvoicing.Controls.Add(this.ctrlDashboardInvoicing1);
            this.pageInvoicing.Flags = 65534;
            this.pageInvoicing.LastVisibleSet = true;
            this.pageInvoicing.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageInvoicing.Name = "pageInvoicing";
            this.pageInvoicing.Size = new System.Drawing.Size(935, 505);
            this.pageInvoicing.Text = "Invoicing";
            this.pageInvoicing.ToolTipTitle = "Page ToolTip";
            this.pageInvoicing.UniqueName = "CA6599623EE0468F0292B584A0278875";
            // 
            // pageTotalRecovery
            // 
            this.pageTotalRecovery.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageTotalRecovery.Flags = 65534;
            this.pageTotalRecovery.LastVisibleSet = true;
            this.pageTotalRecovery.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageTotalRecovery.Name = "pageTotalRecovery";
            this.pageTotalRecovery.Size = new System.Drawing.Size(935, 505);
            this.pageTotalRecovery.Text = "Recovery";
            this.pageTotalRecovery.ToolTipTitle = "Page ToolTip";
            this.pageTotalRecovery.UniqueName = "58A48979707C40DD1FAA74D2A7719179";
            // 
            // pageBalanceToRecover
            // 
            this.pageBalanceToRecover.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageBalanceToRecover.Flags = 65534;
            this.pageBalanceToRecover.LastVisibleSet = true;
            this.pageBalanceToRecover.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageBalanceToRecover.Name = "pageBalanceToRecover";
            this.pageBalanceToRecover.Size = new System.Drawing.Size(935, 505);
            this.pageBalanceToRecover.Text = "Balance to Recover";
            this.pageBalanceToRecover.TextDescription = "";
            this.pageBalanceToRecover.TextTitle = "Balance to Recover";
            this.pageBalanceToRecover.ToolTipTitle = "Page ToolTip";
            this.pageBalanceToRecover.UniqueName = "F153F452F25E490882A9FCDC8148843D";
            // 
            // pageEnquiriesMade
            // 
            this.pageEnquiriesMade.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageEnquiriesMade.Flags = 65534;
            this.pageEnquiriesMade.LastVisibleSet = true;
            this.pageEnquiriesMade.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageEnquiriesMade.Name = "pageEnquiriesMade";
            this.pageEnquiriesMade.Size = new System.Drawing.Size(935, 505);
            this.pageEnquiriesMade.Text = "Enquiries generated.";
            this.pageEnquiriesMade.TextDescription = "Total Enquiry generated ";
            this.pageEnquiriesMade.ToolTipTitle = "Page ToolTip";
            this.pageEnquiriesMade.UniqueName = "2C4B4064ED1943E317B5697708D7529F";
            // 
            // pageSalesOrders
            // 
            this.pageSalesOrders.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageSalesOrders.Flags = 65534;
            this.pageSalesOrders.LastVisibleSet = true;
            this.pageSalesOrders.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageSalesOrders.Name = "pageSalesOrders";
            this.pageSalesOrders.Size = new System.Drawing.Size(935, 505);
            this.pageSalesOrders.Text = "Sales Order(s)";
            this.pageSalesOrders.ToolTipTitle = "Page ToolTip";
            this.pageSalesOrders.UniqueName = "7A86248A0E5141488B8834FC02121BDE";
            // 
            // ctrlDashboardInvoicing1
            // 
            this.ctrlDashboardInvoicing1.Location = new System.Drawing.Point(113, 65);
            this.ctrlDashboardInvoicing1.Name = "ctrlDashboardInvoicing1";
            this.ctrlDashboardInvoicing1.Padding = new System.Windows.Forms.Padding(5);
            this.ctrlDashboardInvoicing1.Size = new System.Drawing.Size(747, 276);
            this.ctrlDashboardInvoicing1.TabIndex = 0;
            // 
            // PageSalesDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDashboard);
            this.Name = "PageSalesDashboard";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(947, 542);
            ((System.ComponentModel.ISupportInitialize)(this.tabDashboard)).EndInit();
            this.tabDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageInvoicing)).EndInit();
            this.pageInvoicing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageTotalRecovery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageBalanceToRecover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageEnquiriesMade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageSalesOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabDashboard;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageInvoicing;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageTotalRecovery;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageBalanceToRecover;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageEnquiriesMade;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageSalesOrders;
        private ctrlDashboardInvoicing ctrlDashboardInvoicing1;
    }
}
