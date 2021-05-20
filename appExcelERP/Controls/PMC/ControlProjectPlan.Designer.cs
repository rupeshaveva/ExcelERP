namespace appExcelERP.Controls.PMC
{
    partial class ControlProjectPlan
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
            this.tabProjectPlan = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageProjectPlan = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageProjectExecution = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabProjectPlan)).BeginInit();
            this.tabProjectPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectExecution)).BeginInit();
            this.SuspendLayout();
            // 
            // tabProjectPlan
            // 
            this.tabProjectPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProjectPlan.Location = new System.Drawing.Point(3, 3);
            this.tabProjectPlan.Name = "tabProjectPlan";
            this.tabProjectPlan.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageProjectPlan,
            this.tabPageProjectExecution});
            this.tabProjectPlan.SelectedIndex = 1;
            this.tabProjectPlan.Size = new System.Drawing.Size(741, 423);
            this.tabProjectPlan.TabIndex = 0;
            this.tabProjectPlan.Text = "kryptonNavigator1";
            // 
            // tabPageProjectPlan
            // 
            this.tabPageProjectPlan.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProjectPlan.Flags = 65534;
            this.tabPageProjectPlan.LastVisibleSet = true;
            this.tabPageProjectPlan.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageProjectPlan.Name = "tabPageProjectPlan";
            this.tabPageProjectPlan.Size = new System.Drawing.Size(739, 396);
            this.tabPageProjectPlan.Text = "Planning";
            this.tabPageProjectPlan.ToolTipTitle = "Page ToolTip";
            this.tabPageProjectPlan.UniqueName = "58748D0001994131F19CF0283843387F";
            // 
            // tabPageProjectExecution
            // 
            this.tabPageProjectExecution.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProjectExecution.Flags = 65534;
            this.tabPageProjectExecution.LastVisibleSet = true;
            this.tabPageProjectExecution.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageProjectExecution.Name = "tabPageProjectExecution";
            this.tabPageProjectExecution.Size = new System.Drawing.Size(739, 396);
            this.tabPageProjectExecution.Text = "Execution";
            this.tabPageProjectExecution.ToolTipTitle = "Page ToolTip";
            this.tabPageProjectExecution.UniqueName = "5FED8CA00C5744A5C2BA0C72A1F89A08";
            // 
            // ControlProjectPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabProjectPlan);
            this.Name = "ControlProjectPlan";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(747, 429);
            this.Load += new System.EventHandler(this.ControlProjectPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabProjectPlan)).EndInit();
            this.tabProjectPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectExecution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabProjectPlan;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProjectPlan;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProjectExecution;
    }
}
