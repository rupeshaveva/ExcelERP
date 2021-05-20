namespace appExcelERP.Forms.ADMIN
{
    partial class frmAddEditFormPermission
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
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblModuleName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblFormName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCanDeleteRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanModifyRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanAddNewRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanViewRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanPrintRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanApproveRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanAuthorizeRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanCheckRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(18, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 18;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(114, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = false;
            this.lblModuleName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModuleName.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblModuleName.Location = new System.Drawing.Point(10, 10);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(378, 25);
            this.lblModuleName.TabIndex = 21;
            this.lblModuleName.Values.Text = "Module Name";
            // 
            // lblFormName
            // 
            this.lblFormName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFormName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.Location = new System.Drawing.Point(10, 35);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Padding = new System.Windows.Forms.Padding(5);
            this.lblFormName.Size = new System.Drawing.Size(378, 33);
            this.lblFormName.TabIndex = 22;
            this.lblFormName.Text = "Module Operation Name";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCanDeleteRecord, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCanModifyRecord, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCanAddNewRecord, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCanViewRecord, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCanPrintRecord, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCanApproveRecord, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnCanAuthorizeRecord, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnCanCheckRecord, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 68);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 332);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // btnCanDeleteRecord
            // 
            this.btnCanDeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanDeleteRecord.Location = new System.Drawing.Point(8, 72);
            this.btnCanDeleteRecord.Name = "btnCanDeleteRecord";
            this.btnCanDeleteRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanDeleteRecord.TabIndex = 2;
            this.btnCanDeleteRecord.Values.Text = "Can &Delete Record";
            this.btnCanDeleteRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanModifyRecord
            // 
            this.btnCanModifyRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanModifyRecord.Location = new System.Drawing.Point(8, 40);
            this.btnCanModifyRecord.Name = "btnCanModifyRecord";
            this.btnCanModifyRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanModifyRecord.TabIndex = 1;
            this.btnCanModifyRecord.Values.Text = "Can Modify Record";
            this.btnCanModifyRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanAddNewRecord
            // 
            this.btnCanAddNewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanAddNewRecord.Location = new System.Drawing.Point(8, 8);
            this.btnCanAddNewRecord.Name = "btnCanAddNewRecord";
            this.btnCanAddNewRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanAddNewRecord.TabIndex = 0;
            this.btnCanAddNewRecord.Values.Text = "Can Add a new Record";
            this.btnCanAddNewRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanViewRecord
            // 
            this.btnCanViewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanViewRecord.Location = new System.Drawing.Point(8, 136);
            this.btnCanViewRecord.Name = "btnCanViewRecord";
            this.btnCanViewRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanViewRecord.TabIndex = 5;
            this.btnCanViewRecord.Values.Text = "Can &View Records";
            this.btnCanViewRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanPrintRecord
            // 
            this.btnCanPrintRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanPrintRecord.Location = new System.Drawing.Point(8, 168);
            this.btnCanPrintRecord.Name = "btnCanPrintRecord";
            this.btnCanPrintRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanPrintRecord.TabIndex = 6;
            this.btnCanPrintRecord.Values.Text = "Can &Print Record";
            this.btnCanPrintRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanApproveRecord
            // 
            this.btnCanApproveRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanApproveRecord.Location = new System.Drawing.Point(8, 296);
            this.btnCanApproveRecord.Name = "btnCanApproveRecord";
            this.btnCanApproveRecord.Size = new System.Drawing.Size(362, 28);
            this.btnCanApproveRecord.TabIndex = 7;
            this.btnCanApproveRecord.Values.Text = "Can &Approve Records";
            this.btnCanApproveRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanAuthorizeRecord
            // 
            this.btnCanAuthorizeRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanAuthorizeRecord.Location = new System.Drawing.Point(8, 264);
            this.btnCanAuthorizeRecord.Name = "btnCanAuthorizeRecord";
            this.btnCanAuthorizeRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanAuthorizeRecord.TabIndex = 4;
            this.btnCanAuthorizeRecord.Values.Text = "Can A&uthorize Record";
            this.btnCanAuthorizeRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanCheckRecord
            // 
            this.btnCanCheckRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCanCheckRecord.Location = new System.Drawing.Point(8, 232);
            this.btnCanCheckRecord.Name = "btnCanCheckRecord";
            this.btnCanCheckRecord.Size = new System.Drawing.Size(362, 26);
            this.btnCanCheckRecord.TabIndex = 8;
            this.btnCanCheckRecord.Values.Text = "Can &Check Records";
            // 
            // frmAddEditFormPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 445);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.lblModuleName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditFormPermission";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCESS PERMISSIONS";
            this.Load += new System.EventHandler(this.frmAddEditFormPermission_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblModuleName;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanDeleteRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanModifyRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanAddNewRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanApproveRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanPrintRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanViewRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanAuthorizeRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanCheckRecord;
    }
}