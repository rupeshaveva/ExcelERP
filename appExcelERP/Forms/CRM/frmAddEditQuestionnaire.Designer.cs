namespace appExcelERP.Forms.CRM
{
    partial class frmAddEditQuestionnaire
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
            this.cboCategory = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboRelatedTo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtQuestionText = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtImplecationText = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSolutionText = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRelatedTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownWidth = 297;
            this.cboCategory.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(81, 13);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(217, 21);
            this.cboCategory.TabIndex = 22;
            this.cboCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cboCategory_Validating);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label16.Location = new System.Drawing.Point(13, 13);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 20);
            this.label16.TabIndex = 21;
            this.label16.Values.Text = "&Category";
            // 
            // cboRelatedTo
            // 
            this.cboRelatedTo.DropDownWidth = 297;
            this.cboRelatedTo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRelatedTo.FormattingEnabled = true;
            this.cboRelatedTo.Location = new System.Drawing.Point(388, 13);
            this.cboRelatedTo.Margin = new System.Windows.Forms.Padding(4);
            this.cboRelatedTo.Name = "cboRelatedTo";
            this.cboRelatedTo.Size = new System.Drawing.Size(217, 21);
            this.cboRelatedTo.TabIndex = 24;
            this.cboRelatedTo.Validating += new System.ComponentModel.CancelEventHandler(this.cboRelatedTo_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(317, 13);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 23;
            this.kryptonLabel1.Values.Text = "&Related To";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 46);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(92, 20);
            this.kryptonLabel2.TabIndex = 25;
            this.kryptonLabel2.Values.Text = "&Question Text";
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Location = new System.Drawing.Point(13, 68);
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtQuestionText.Size = new System.Drawing.Size(592, 77);
            this.txtQuestionText.TabIndex = 26;
            this.txtQuestionText.Text = "kryptonRichTextBox1";
            this.txtQuestionText.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuestionText_Validating);
            // 
            // txtImplecationText
            // 
            this.txtImplecationText.Location = new System.Drawing.Point(12, 177);
            this.txtImplecationText.Name = "txtImplecationText";
            this.txtImplecationText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtImplecationText.Size = new System.Drawing.Size(592, 77);
            this.txtImplecationText.TabIndex = 28;
            this.txtImplecationText.Text = "kryptonRichTextBox2";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 153);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel3.TabIndex = 27;
            this.kryptonLabel3.Values.Text = "&Implecation Text";
            // 
            // txtSolutionText
            // 
            this.txtSolutionText.Location = new System.Drawing.Point(12, 286);
            this.txtSolutionText.Name = "txtSolutionText";
            this.txtSolutionText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSolutionText.Size = new System.Drawing.Size(592, 200);
            this.txtSolutionText.TabIndex = 30;
            this.txtSolutionText.Text = "kryptonRichTextBox3";
            this.txtSolutionText.Validating += new System.ComponentModel.CancelEventHandler(this.txtSolutionText_Validating);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 262);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel4.TabIndex = 29;
            this.kryptonLabel4.Values.Text = "&Solution Text";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(505, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 28);
            this.btnClose.TabIndex = 32;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(399, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 31;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(620, 536);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSolutionText);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtImplecationText);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtQuestionText);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.cboRelatedTo);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditQuestionnaire";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Questionnaire";
            this.Load += new System.EventHandler(this.frmAddEditQuestionnaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRelatedTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboRelatedTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtQuestionText;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtImplecationText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtSolutionText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}