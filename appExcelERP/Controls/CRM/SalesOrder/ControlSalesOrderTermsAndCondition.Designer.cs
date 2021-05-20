namespace appExcelERP.Controls.CRM.SalesOrder
{
    partial class ControlSalesOrderTermsAndCondition
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerGroupTermsAndCondition = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddTerms = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveTerms = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridTermAndCondition = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchTermAndCondition = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition.Panel)).BeginInit();
            this.headerGroupTermsAndCondition.Panel.SuspendLayout();
            this.headerGroupTermsAndCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTermAndCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupTermsAndCondition
            // 
            this.headerGroupTermsAndCondition.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddTerms,
            this.btnRemoveTerms});
            this.headerGroupTermsAndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupTermsAndCondition.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupTermsAndCondition.Location = new System.Drawing.Point(0, 0);
            this.headerGroupTermsAndCondition.Name = "headerGroupTermsAndCondition";
            // 
            // headerGroupTermsAndCondition.Panel
            // 
            this.headerGroupTermsAndCondition.Panel.Controls.Add(this.gridTermAndCondition);
            this.headerGroupTermsAndCondition.Panel.Controls.Add(this.txtSearchTermAndCondition);
            this.headerGroupTermsAndCondition.Size = new System.Drawing.Size(577, 446);
            this.headerGroupTermsAndCondition.TabIndex = 0;
            this.headerGroupTermsAndCondition.ValuesPrimary.Heading = "TERMS & CONDITIONS ";
            this.headerGroupTermsAndCondition.ValuesPrimary.Image = null;
            // 
            // btnAddTerms
            // 
            this.btnAddTerms.Text = "&Add more T&&C";
            this.btnAddTerms.UniqueName = "1023D470F0F34A2CB7B791E87ACAC7FF";
            this.btnAddTerms.Click += new System.EventHandler(this.btnAddTerms_Click);
            // 
            // btnRemoveTerms
            // 
            this.btnRemoveTerms.Text = "&Remove T&&C";
            this.btnRemoveTerms.UniqueName = "67CE8190AA91440524BF34668C025E28";
            this.btnRemoveTerms.Click += new System.EventHandler(this.btnRemoveTerms_Click);
            // 
            // gridTermAndCondition
            // 
            this.gridTermAndCondition.AllowUserToAddRows = false;
            this.gridTermAndCondition.AllowUserToDeleteRows = false;
            this.gridTermAndCondition.AllowUserToResizeColumns = false;
            this.gridTermAndCondition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTermAndCondition.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridTermAndCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTermAndCondition.ColumnHeadersVisible = false;
            this.gridTermAndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTermAndCondition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridTermAndCondition.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridTermAndCondition.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.gridTermAndCondition.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridTermAndCondition.Location = new System.Drawing.Point(0, 20);
            this.gridTermAndCondition.MultiSelect = false;
            this.gridTermAndCondition.Name = "gridTermAndCondition";
            this.gridTermAndCondition.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTermAndCondition.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTermAndCondition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTermAndCondition.Size = new System.Drawing.Size(575, 376);
            this.gridTermAndCondition.TabIndex = 19;
            this.gridTermAndCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellClick);
            this.gridTermAndCondition.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellEnter);
            this.gridTermAndCondition.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellValueChanged);
            // 
            // txtSearchTermAndCondition
            // 
            this.txtSearchTermAndCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchTermAndCondition.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTermAndCondition.Location = new System.Drawing.Point(0, 0);
            this.txtSearchTermAndCondition.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchTermAndCondition.Name = "txtSearchTermAndCondition";
            this.txtSearchTermAndCondition.Size = new System.Drawing.Size(575, 20);
            this.txtSearchTermAndCondition.TabIndex = 18;
            this.txtSearchTermAndCondition.TextChanged += new System.EventHandler(this.txtSearchTermAndCondition_TextChanged);
            // 
            // ControlSalesOrderTermsAndCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupTermsAndCondition);
            this.Name = "ControlSalesOrderTermsAndCondition";
            this.Size = new System.Drawing.Size(577, 446);
            this.Load += new System.EventHandler(this.ControlSalesOrderTermsAndCondition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition.Panel)).EndInit();
            this.headerGroupTermsAndCondition.Panel.ResumeLayout(false);
            this.headerGroupTermsAndCondition.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition)).EndInit();
            this.headerGroupTermsAndCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTermAndCondition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupTermsAndCondition;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddTerms;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveTerms;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridTermAndCondition;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchTermAndCondition;
    }
}
