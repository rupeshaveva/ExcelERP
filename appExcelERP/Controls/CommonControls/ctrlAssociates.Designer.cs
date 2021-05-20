namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlAssociates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitAssociates = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupAssociates = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnDisassociate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAssociated = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchAssociates = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panelAssociates = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureAssociate = new System.Windows.Forms.PictureBox();
            this.headerGroupEmployees = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAssociate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridEmployees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchEmployee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panelEmployeeInfo = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureEmployee = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitAssociates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitAssociates.Panel1)).BeginInit();
            this.splitAssociates.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAssociates.Panel2)).BeginInit();
            this.splitAssociates.Panel2.SuspendLayout();
            this.splitAssociates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAssociates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAssociates.Panel)).BeginInit();
            this.headerGroupAssociates.Panel.SuspendLayout();
            this.headerGroupAssociates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAssociated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAssociates)).BeginInit();
            this.panelAssociates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAssociate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees.Panel)).BeginInit();
            this.headerGroupEmployees.Panel.SuspendLayout();
            this.headerGroupEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEmployeeInfo)).BeginInit();
            this.panelEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // splitAssociates
            // 
            this.splitAssociates.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitAssociates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitAssociates.Location = new System.Drawing.Point(5, 5);
            this.splitAssociates.Name = "splitAssociates";
            this.splitAssociates.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitAssociates.Panel1
            // 
            this.splitAssociates.Panel1.AutoScroll = true;
            this.splitAssociates.Panel1.Controls.Add(this.headerGroupAssociates);
            // 
            // splitAssociates.Panel2
            // 
            this.splitAssociates.Panel2.AutoScroll = true;
            this.splitAssociates.Panel2.Controls.Add(this.headerGroupEmployees);
            this.splitAssociates.Size = new System.Drawing.Size(842, 605);
            this.splitAssociates.SplitterDistance = 306;
            this.splitAssociates.TabIndex = 0;
            // 
            // headerGroupAssociates
            // 
            this.headerGroupAssociates.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnDisassociate});
            this.headerGroupAssociates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupAssociates.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupAssociates.Location = new System.Drawing.Point(0, 0);
            this.headerGroupAssociates.Name = "headerGroupAssociates";
            // 
            // headerGroupAssociates.Panel
            // 
            this.headerGroupAssociates.Panel.Controls.Add(this.gridAssociated);
            this.headerGroupAssociates.Panel.Controls.Add(this.txtSearchAssociates);
            this.headerGroupAssociates.Panel.Controls.Add(this.panelAssociates);
            this.headerGroupAssociates.Size = new System.Drawing.Size(842, 306);
            this.headerGroupAssociates.TabIndex = 1;
            this.headerGroupAssociates.ValuesPrimary.Heading = "Associated Employees";
            this.headerGroupAssociates.ValuesPrimary.Image = null;
            // 
            // btnDisassociate
            // 
            this.btnDisassociate.Text = "&Dis-Associate";
            this.btnDisassociate.UniqueName = "390A3F034B494CF2A6A2E5F6736AA7CC";
            this.btnDisassociate.Click += new System.EventHandler(this.btnDisassociate_Click);
            // 
            // gridAssociated
            // 
            this.gridAssociated.AllowUserToAddRows = false;
            this.gridAssociated.AllowUserToDeleteRows = false;
            this.gridAssociated.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAssociated.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAssociated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAssociated.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAssociated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAssociated.ColumnHeadersVisible = false;
            this.gridAssociated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAssociated.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAssociated.Location = new System.Drawing.Point(0, 20);
            this.gridAssociated.MultiSelect = false;
            this.gridAssociated.Name = "gridAssociated";
            this.gridAssociated.ReadOnly = true;
            this.gridAssociated.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAssociated.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAssociated.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAssociated.Size = new System.Drawing.Size(681, 236);
            this.gridAssociated.TabIndex = 24;
            this.gridAssociated.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAssociated_CellClick);
            this.gridAssociated.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAssociated_RowEnter);
            // 
            // txtSearchAssociates
            // 
            this.txtSearchAssociates.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchAssociates.Location = new System.Drawing.Point(0, 0);
            this.txtSearchAssociates.Name = "txtSearchAssociates";
            this.txtSearchAssociates.Size = new System.Drawing.Size(681, 20);
            this.txtSearchAssociates.TabIndex = 23;
            this.txtSearchAssociates.TextChanged += new System.EventHandler(this.txtSearchAssociates_TextChanged);
            // 
            // panelAssociates
            // 
            this.panelAssociates.Controls.Add(this.kryptonTextBox1);
            this.panelAssociates.Controls.Add(this.pictureAssociate);
            this.panelAssociates.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAssociates.Location = new System.Drawing.Point(681, 0);
            this.panelAssociates.Name = "panelAssociates";
            this.panelAssociates.Padding = new System.Windows.Forms.Padding(3);
            this.panelAssociates.Size = new System.Drawing.Size(159, 256);
            this.panelAssociates.TabIndex = 21;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTextBox1.Location = new System.Drawing.Point(3, 136);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(153, 117);
            this.kryptonTextBox1.TabIndex = 18;
            this.kryptonTextBox1.Text = "Here we can display the most significant info. that is must, whenever we see this" +
    " employee in assication of a lead";
            // 
            // pictureAssociate
            // 
            this.pictureAssociate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureAssociate.Image = global::appExcelERP.Properties.Resources._1383042568_administrator;
            this.pictureAssociate.Location = new System.Drawing.Point(3, 3);
            this.pictureAssociate.Name = "pictureAssociate";
            this.pictureAssociate.Size = new System.Drawing.Size(153, 133);
            this.pictureAssociate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAssociate.TabIndex = 17;
            this.pictureAssociate.TabStop = false;
            // 
            // headerGroupEmployees
            // 
            this.headerGroupEmployees.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAssociate});
            this.headerGroupEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupEmployees.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupEmployees.Location = new System.Drawing.Point(0, 0);
            this.headerGroupEmployees.Name = "headerGroupEmployees";
            // 
            // headerGroupEmployees.Panel
            // 
            this.headerGroupEmployees.Panel.Controls.Add(this.gridEmployees);
            this.headerGroupEmployees.Panel.Controls.Add(this.txtSearchEmployee);
            this.headerGroupEmployees.Panel.Controls.Add(this.panelEmployeeInfo);
            this.headerGroupEmployees.Size = new System.Drawing.Size(842, 294);
            this.headerGroupEmployees.TabIndex = 0;
            this.headerGroupEmployees.ValuesPrimary.Heading = "All Employees";
            this.headerGroupEmployees.ValuesPrimary.Image = null;
            this.headerGroupEmployees.ValuesSecondary.Heading = "email : sachin.a.patwardhan@gmail.com Conatct No : 8827023194";
            // 
            // btnAssociate
            // 
            this.btnAssociate.Text = "&Associate";
            this.btnAssociate.UniqueName = "B019F5BB88F8408C85BB8A603E0E4331";
            this.btnAssociate.Click += new System.EventHandler(this.btnAssociate_Click);
            // 
            // gridEmployees
            // 
            this.gridEmployees.AllowUserToAddRows = false;
            this.gridEmployees.AllowUserToDeleteRows = false;
            this.gridEmployees.AllowUserToResizeColumns = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployees.ColumnHeadersVisible = false;
            this.gridEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridEmployees.Location = new System.Drawing.Point(0, 20);
            this.gridEmployees.MultiSelect = false;
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEmployees.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmployees.Size = new System.Drawing.Size(681, 224);
            this.gridEmployees.TabIndex = 28;
            this.gridEmployees.CellBorderStyleChanged += new System.EventHandler(this.gridEmployees_CellBorderStyleChanged);
            this.gridEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmployees_CellClick);
            this.gridEmployees.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmployees_RowEnter);
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchEmployee.Location = new System.Drawing.Point(0, 0);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(681, 20);
            this.txtSearchEmployee.TabIndex = 27;
            this.txtSearchEmployee.TextChanged += new System.EventHandler(this.txtSearchEmployee_TextChanged);
            // 
            // panelEmployeeInfo
            // 
            this.panelEmployeeInfo.Controls.Add(this.kryptonTextBox2);
            this.panelEmployeeInfo.Controls.Add(this.pictureEmployee);
            this.panelEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEmployeeInfo.Location = new System.Drawing.Point(681, 0);
            this.panelEmployeeInfo.Name = "panelEmployeeInfo";
            this.panelEmployeeInfo.Padding = new System.Windows.Forms.Padding(3);
            this.panelEmployeeInfo.Size = new System.Drawing.Size(159, 244);
            this.panelEmployeeInfo.TabIndex = 25;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTextBox2.Location = new System.Drawing.Point(3, 127);
            this.kryptonTextBox2.Multiline = true;
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(153, 114);
            this.kryptonTextBox2.TabIndex = 18;
            this.kryptonTextBox2.Text = "Here we can display the most significant info. that is must, whenever we see this" +
    " employee in assication of a lead";
            // 
            // pictureEmployee
            // 
            this.pictureEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEmployee.Image = global::appExcelERP.Properties.Resources._1383042568_administrator;
            this.pictureEmployee.Location = new System.Drawing.Point(3, 3);
            this.pictureEmployee.Name = "pictureEmployee";
            this.pictureEmployee.Size = new System.Drawing.Size(153, 124);
            this.pictureEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEmployee.TabIndex = 17;
            this.pictureEmployee.TabStop = false;
            // 
            // ctrlAssociates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAssociates);
            this.Name = "ctrlAssociates";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(852, 615);
            this.Load += new System.EventHandler(this.ctrlAssociates_Load);
            this.Resize += new System.EventHandler(this.ctrlAssociates_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.splitAssociates.Panel1)).EndInit();
            this.splitAssociates.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAssociates.Panel2)).EndInit();
            this.splitAssociates.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAssociates)).EndInit();
            this.splitAssociates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAssociates.Panel)).EndInit();
            this.headerGroupAssociates.Panel.ResumeLayout(false);
            this.headerGroupAssociates.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAssociates)).EndInit();
            this.headerGroupAssociates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAssociated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAssociates)).EndInit();
            this.panelAssociates.ResumeLayout(false);
            this.panelAssociates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAssociate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees.Panel)).EndInit();
            this.headerGroupEmployees.Panel.ResumeLayout(false);
            this.headerGroupEmployees.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees)).EndInit();
            this.headerGroupEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEmployeeInfo)).EndInit();
            this.panelEmployeeInfo.ResumeLayout(false);
            this.panelEmployeeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitAssociates;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupAssociates;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDisassociate;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupEmployees;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAssociate;
        private System.Windows.Forms.PictureBox pictureAssociate;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelAssociates;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAssociated;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchAssociates;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchEmployee;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelEmployeeInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private System.Windows.Forms.PictureBox pictureEmployee;
    }
}
