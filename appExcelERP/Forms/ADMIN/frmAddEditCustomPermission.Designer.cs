namespace appExcelERP.Forms.ADMIN
{
    partial class frmAddEditCustomPermission
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
            this.components = new System.ComponentModel.Container();
            this.cboModules = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboForms = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnCanAuthorizeRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanApproveRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanCheckRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanPrintRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanViewRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanDeleteRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanModifyRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnCanAddNewRecord = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboModules
            // 
            this.cboModules.DropDownWidth = 297;
            this.cboModules.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModules.FormattingEnabled = true;
            this.cboModules.Location = new System.Drawing.Point(22, 33);
            this.cboModules.Margin = new System.Windows.Forms.Padding(4);
            this.cboModules.Name = "cboModules";
            this.cboModules.Size = new System.Drawing.Size(172, 21);
            this.cboModules.TabIndex = 1;
            this.cboModules.SelectedValueChanged += new System.EventHandler(this.cboModules_SelectedValueChanged);
            this.cboModules.Validating += new System.ComponentModel.CancelEventHandler(this.cboModules_Validating);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(24, 10);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(154, 20);
            this.label16.TabIndex = 0;
            this.label16.Values.Text = "Select Application Module";
            // 
            // cboForms
            // 
            this.cboForms.DropDownWidth = 297;
            this.cboForms.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboForms.FormattingEnabled = true;
            this.cboForms.Location = new System.Drawing.Point(204, 33);
            this.cboForms.Margin = new System.Windows.Forms.Padding(4);
            this.cboForms.Name = "cboForms";
            this.cboForms.Size = new System.Drawing.Size(354, 21);
            this.cboForms.TabIndex = 3;
            this.cboForms.SelectedValueChanged += new System.EventHandler(this.cboForms_SelectedValueChanged);
            this.cboForms.Validating += new System.ComponentModel.CancelEventHandler(this.cboForms_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(204, 9);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(101, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Select Operation ";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(13, 61);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanAuthorizeRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanApproveRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanCheckRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanPrintRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanViewRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanDeleteRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanModifyRecord);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnCanAddNewRecord);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(556, 135);
            this.kryptonHeaderGroup1.TabIndex = 4;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Set Permissions";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnCanAuthorizeRecord
            // 
            this.btnCanAuthorizeRecord.Location = new System.Drawing.Point(372, 72);
            this.btnCanAuthorizeRecord.Name = "btnCanAuthorizeRecord";
            this.btnCanAuthorizeRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanAuthorizeRecord.TabIndex = 7;
            this.btnCanAuthorizeRecord.Values.Text = "Can Authorize a Record";
            this.btnCanAuthorizeRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanApproveRecord
            // 
            this.btnCanApproveRecord.Location = new System.Drawing.Point(372, 40);
            this.btnCanApproveRecord.Name = "btnCanApproveRecord";
            this.btnCanApproveRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanApproveRecord.TabIndex = 6;
            this.btnCanApproveRecord.Values.Text = "Can Approve a Record";
            this.btnCanApproveRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanCheckRecord
            // 
            this.btnCanCheckRecord.Location = new System.Drawing.Point(372, 8);
            this.btnCanCheckRecord.Name = "btnCanCheckRecord";
            this.btnCanCheckRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanCheckRecord.TabIndex = 5;
            this.btnCanCheckRecord.Values.Text = "Can Check Record";
            this.btnCanCheckRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanPrintRecord
            // 
            this.btnCanPrintRecord.Location = new System.Drawing.Point(190, 59);
            this.btnCanPrintRecord.Name = "btnCanPrintRecord";
            this.btnCanPrintRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanPrintRecord.TabIndex = 4;
            this.btnCanPrintRecord.Values.Text = "Can Print Record";
            this.btnCanPrintRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanViewRecord
            // 
            this.btnCanViewRecord.Location = new System.Drawing.Point(190, 27);
            this.btnCanViewRecord.Name = "btnCanViewRecord";
            this.btnCanViewRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanViewRecord.TabIndex = 3;
            this.btnCanViewRecord.Values.Text = "Can View Record";
            this.btnCanViewRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanDeleteRecord
            // 
            this.btnCanDeleteRecord.Location = new System.Drawing.Point(8, 72);
            this.btnCanDeleteRecord.Name = "btnCanDeleteRecord";
            this.btnCanDeleteRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanDeleteRecord.TabIndex = 2;
            this.btnCanDeleteRecord.Values.Text = "Can Delete Record";
            this.btnCanDeleteRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanModifyRecord
            // 
            this.btnCanModifyRecord.Location = new System.Drawing.Point(8, 40);
            this.btnCanModifyRecord.Name = "btnCanModifyRecord";
            this.btnCanModifyRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanModifyRecord.TabIndex = 1;
            this.btnCanModifyRecord.Values.Text = "Can Modify Record";
            this.btnCanModifyRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnCanAddNewRecord
            // 
            this.btnCanAddNewRecord.Location = new System.Drawing.Point(8, 8);
            this.btnCanAddNewRecord.Name = "btnCanAddNewRecord";
            this.btnCanAddNewRecord.Size = new System.Drawing.Size(172, 26);
            this.btnCanAddNewRecord.TabIndex = 0;
            this.btnCanAddNewRecord.Values.Text = "Can Add a new Record";
            this.btnCanAddNewRecord.Click += new System.EventHandler(this.PermissionsButton_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(386, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(474, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditCustomPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 244);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.cboForms);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.cboModules);
            this.Controls.Add(this.label16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditCustomPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Permission [ADD/EDIT]";
            this.Load += new System.EventHandler(this.frmAddEditCustomPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboModules;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboForms;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanAuthorizeRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanApproveRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanCheckRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanPrintRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanViewRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanDeleteRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanModifyRecord;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton btnCanAddNewRecord;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}