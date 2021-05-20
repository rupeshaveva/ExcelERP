namespace appExcelERP.Controls.ADMIN
{
    partial class ctrlAddEditAccessRights
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
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCanUndeleteRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanDeleteRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanModifyRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanAddNewRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanApproveRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanPrintRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanViewRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanSearchRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonRichTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.headerTitle = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(5, 5);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.headerTitle);
            this.kryptonHeaderGroup1.Panel.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(12);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(368, 559);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Add/Edit Access Rights";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSave.Text = "&Save";
            this.btnSave.UniqueName = "86785CFB65764D55E3AC82030BEBBF60";
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "49E07B95638C440874BA501A8C4AAAA2";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCanUndeleteRecord, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCanDeleteRecord, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCanModifyRecord, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCanAddNewRecord, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCanApproveRecord, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnCanPrintRecord, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCanViewRecord, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnCanSearchRecord, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 332);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnCanUndeleteRecord
            // 
            this.btnCanUndeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanUndeleteRecord.Location = new System.Drawing.Point(8, 104);
            this.btnCanUndeleteRecord.Name = "btnCanUndeleteRecord";
            this.btnCanUndeleteRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanUndeleteRecord.TabIndex = 3;
            this.btnCanUndeleteRecord.Values.Text = "Can &Undelete Record";
            this.btnCanUndeleteRecord.CheckedChanged += new System.EventHandler(this.btnCanUndeleteRecord_CheckedChanged);
            // 
            // btnCanDeleteRecord
            // 
            this.btnCanDeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanDeleteRecord.Location = new System.Drawing.Point(8, 72);
            this.btnCanDeleteRecord.Name = "btnCanDeleteRecord";
            this.btnCanDeleteRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanDeleteRecord.TabIndex = 2;
            this.btnCanDeleteRecord.Values.Text = "Can &Delete Record";
            this.btnCanDeleteRecord.CheckedChanged += new System.EventHandler(this.btnCanDeleteRecord_CheckedChanged);
            // 
            // btnCanModifyRecord
            // 
            this.btnCanModifyRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanModifyRecord.Location = new System.Drawing.Point(8, 40);
            this.btnCanModifyRecord.Name = "btnCanModifyRecord";
            this.btnCanModifyRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanModifyRecord.TabIndex = 1;
            this.btnCanModifyRecord.Values.Text = "Can &Modify Record";
            this.btnCanModifyRecord.CheckedChanged += new System.EventHandler(this.btnCanModifyRecord_CheckedChanged);
            // 
            // btnCanAddNewRecord
            // 
            this.btnCanAddNewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanAddNewRecord.Location = new System.Drawing.Point(8, 8);
            this.btnCanAddNewRecord.Name = "btnCanAddNewRecord";
            this.btnCanAddNewRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanAddNewRecord.TabIndex = 0;
            this.btnCanAddNewRecord.Values.Text = "Can &Add a new Record";
            this.btnCanAddNewRecord.CheckedChanged += new System.EventHandler(this.kryptonCheckButton1_CheckedChanged);
            // 
            // btnCanApproveRecord
            // 
            this.btnCanApproveRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanApproveRecord.Location = new System.Drawing.Point(8, 296);
            this.btnCanApproveRecord.Name = "btnCanApproveRecord";
            this.btnCanApproveRecord.Size = new System.Drawing.Size(326, 28);
            this.btnCanApproveRecord.TabIndex = 7;
            this.btnCanApproveRecord.Values.Text = "Can &Approve Records";
            this.btnCanApproveRecord.CheckedChanged += new System.EventHandler(this.btnCanApproveRecord_CheckedChanged);
            // 
            // btnCanPrintRecord
            // 
            this.btnCanPrintRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanPrintRecord.Location = new System.Drawing.Point(8, 232);
            this.btnCanPrintRecord.Name = "btnCanPrintRecord";
            this.btnCanPrintRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanPrintRecord.TabIndex = 6;
            this.btnCanPrintRecord.Values.Text = "Can &Print Record";
            this.btnCanPrintRecord.CheckedChanged += new System.EventHandler(this.btnCanPrintRecord_CheckedChanged);
            // 
            // btnCanViewRecord
            // 
            this.btnCanViewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanViewRecord.Location = new System.Drawing.Point(8, 200);
            this.btnCanViewRecord.Name = "btnCanViewRecord";
            this.btnCanViewRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanViewRecord.TabIndex = 5;
            this.btnCanViewRecord.Values.Text = "Can &View Records";
            this.btnCanViewRecord.CheckedChanged += new System.EventHandler(this.btnCanViewRecord_CheckedChanged);
            // 
            // btnCanSearchRecord
            // 
            this.btnCanSearchRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanSearchRecord.Location = new System.Drawing.Point(8, 168);
            this.btnCanSearchRecord.Name = "btnCanSearchRecord";
            this.btnCanSearchRecord.Size = new System.Drawing.Size(326, 26);
            this.btnCanSearchRecord.TabIndex = 4;
            this.btnCanSearchRecord.Values.Text = "Can &Search Records";
            this.btnCanSearchRecord.CheckedChanged += new System.EventHandler(this.btnCanSearchRecord_CheckedChanged);
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(12, 370);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.ReadOnly = true;
            this.kryptonRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(342, 124);
            this.kryptonRichTextBox1.TabIndex = 6;
            this.kryptonRichTextBox1.TabStop = false;
            this.kryptonRichTextBox1.Text = "";
            // 
            // headerTitle
            // 
            this.headerTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTitle.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerTitle.Location = new System.Drawing.Point(12, 12);
            this.headerTitle.Name = "headerTitle";
            this.headerTitle.Size = new System.Drawing.Size(342, 26);
            this.headerTitle.TabIndex = 3;
            this.headerTitle.Values.Heading = "kryptonHeader1";
            this.headerTitle.Values.Image = null;
            // 
            // ctrlAddEditAccessRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "ctrlAddEditAccessRights";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(378, 569);
            this.Load += new System.EventHandler(this.ctrlAddEditAccessRights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader headerTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanUndeleteRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanDeleteRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanModifyRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanAddNewRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanApproveRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanPrintRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanViewRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanSearchRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
    }
}
