namespace appExcelERP.Controls.CRM
{
    partial class pageQuestionnaire
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddRelatedTo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditRelatedTo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteRelatedTo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.listRelatedTo = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.headerGroupQuestionCategory = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.AddQuestionCategory = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditQuestionCategory = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.listCategories = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewQuestionnaire = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditQuestionnair = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteQuestionnaire = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridQuestionnaire = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchQuestion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuestionCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuestionCategory.Panel)).BeginInit();
            this.headerGroupQuestionCategory.Panel.SuspendLayout();
            this.headerGroupQuestionCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuestionnaire)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.kryptonHeaderGroup1);
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupQuestionCategory);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.kryptonHeaderGroup2);
            this.splitContainerMain.Size = new System.Drawing.Size(765, 525);
            this.splitContainerMain.SplitterDistance = 255;
            this.splitContainerMain.TabIndex = 0;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddRelatedTo,
            this.btnEditRelatedTo,
            this.btnDeleteRelatedTo});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 153);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.listRelatedTo);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(255, 372);
            this.kryptonHeaderGroup1.TabIndex = 1;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Related to";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnAddRelatedTo
            // 
            this.btnAddRelatedTo.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddRelatedTo.UniqueName = "FF80696E8CAD499D909A9020198534DE";
            this.btnAddRelatedTo.Click += new System.EventHandler(this.btnAddRelatedTo_Click);
            // 
            // btnEditRelatedTo
            // 
            this.btnEditRelatedTo.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditRelatedTo.UniqueName = "601FF8A079C14E863CB1069CCC0E032D";
            this.btnEditRelatedTo.Click += new System.EventHandler(this.btnEditRelatedTo_Click);
            // 
            // btnDeleteRelatedTo
            // 
            this.btnDeleteRelatedTo.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteRelatedTo.UniqueName = "0CA4C453407C4069DAA78AB4B3443BFD";
            this.btnDeleteRelatedTo.Click += new System.EventHandler(this.btnDeleteRelatedTo_Click);
            // 
            // listRelatedTo
            // 
            this.listRelatedTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRelatedTo.Location = new System.Drawing.Point(0, 0);
            this.listRelatedTo.Name = "listRelatedTo";
            this.listRelatedTo.Size = new System.Drawing.Size(253, 345);
            this.listRelatedTo.TabIndex = 1;
            this.listRelatedTo.SelectedValueChanged += new System.EventHandler(this.listRelatedTo_SelectedValueChanged);
            // 
            // headerGroupQuestionCategory
            // 
            this.headerGroupQuestionCategory.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.AddQuestionCategory,
            this.btnEditQuestionCategory});
            this.headerGroupQuestionCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupQuestionCategory.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupQuestionCategory.HeaderVisibleSecondary = false;
            this.headerGroupQuestionCategory.Location = new System.Drawing.Point(0, 0);
            this.headerGroupQuestionCategory.Name = "headerGroupQuestionCategory";
            // 
            // headerGroupQuestionCategory.Panel
            // 
            this.headerGroupQuestionCategory.Panel.Controls.Add(this.listCategories);
            this.headerGroupQuestionCategory.Size = new System.Drawing.Size(255, 153);
            this.headerGroupQuestionCategory.TabIndex = 0;
            this.headerGroupQuestionCategory.ValuesPrimary.Heading = "Category";
            this.headerGroupQuestionCategory.ValuesPrimary.Image = null;
            // 
            // AddQuestionCategory
            // 
            this.AddQuestionCategory.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.AddQuestionCategory.UniqueName = "FF80696E8CAD499D909A9020198534DE";
            this.AddQuestionCategory.Click += new System.EventHandler(this.AddQuestionCategory_Click);
            // 
            // btnEditQuestionCategory
            // 
            this.btnEditQuestionCategory.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditQuestionCategory.UniqueName = "601FF8A079C14E863CB1069CCC0E032D";
            this.btnEditQuestionCategory.Click += new System.EventHandler(this.btnEditQuestionCategory_Click);
            // 
            // listCategories
            // 
            this.listCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCategories.Location = new System.Drawing.Point(0, 0);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(253, 126);
            this.listCategories.TabIndex = 0;
            this.listCategories.SelectedValueChanged += new System.EventHandler(this.listCategories_SelectedValueChanged);
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewQuestionnaire,
            this.btnEditQuestionnair,
            this.btnDeleteQuestionnaire});
            this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.gridQuestionnaire);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.txtSearchQuestion);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(505, 525);
            this.kryptonHeaderGroup2.TabIndex = 2;
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Questionnaire";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
            // 
            // btnAddNewQuestionnaire
            // 
            this.btnAddNewQuestionnaire.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewQuestionnaire.UniqueName = "FF80696E8CAD499D909A9020198534DE";
            this.btnAddNewQuestionnaire.Click += new System.EventHandler(this.btnAddNewQuestionnaire_Click);
            // 
            // btnEditQuestionnair
            // 
            this.btnEditQuestionnair.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditQuestionnair.UniqueName = "601FF8A079C14E863CB1069CCC0E032D";
            this.btnEditQuestionnair.Click += new System.EventHandler(this.btnEditQuestionnair_Click);
            // 
            // btnDeleteQuestionnaire
            // 
            this.btnDeleteQuestionnaire.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteQuestionnaire.UniqueName = "0CA4C453407C4069DAA78AB4B3443BFD";
            this.btnDeleteQuestionnaire.Click += new System.EventHandler(this.btnDeleteQuestionnaire_Click);
            // 
            // gridQuestionnaire
            // 
            this.gridQuestionnaire.AllowUserToAddRows = false;
            this.gridQuestionnaire.AllowUserToDeleteRows = false;
            this.gridQuestionnaire.AllowUserToResizeColumns = false;
            this.gridQuestionnaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridQuestionnaire.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridQuestionnaire.ColumnHeadersVisible = false;
            this.gridQuestionnaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQuestionnaire.Location = new System.Drawing.Point(0, 20);
            this.gridQuestionnaire.Name = "gridQuestionnaire";
            this.gridQuestionnaire.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridQuestionnaire.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridQuestionnaire.Size = new System.Drawing.Size(503, 478);
            this.gridQuestionnaire.TabIndex = 1;
            this.gridQuestionnaire.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridQuestionnaire_RowEnter);
            // 
            // txtSearchQuestion
            // 
            this.txtSearchQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchQuestion.Location = new System.Drawing.Point(0, 0);
            this.txtSearchQuestion.Name = "txtSearchQuestion";
            this.txtSearchQuestion.Size = new System.Drawing.Size(503, 20);
            this.txtSearchQuestion.TabIndex = 0;
            this.txtSearchQuestion.TextChanged += new System.EventHandler(this.txtSearchQuestion_TextChanged);
            // 
            // pageQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "pageQuestionnaire";
            this.Size = new System.Drawing.Size(765, 525);
            this.Load += new System.EventHandler(this.pageQuestionnaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuestionCategory.Panel)).EndInit();
            this.headerGroupQuestionCategory.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuestionCategory)).EndInit();
            this.headerGroupQuestionCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQuestionnaire)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddRelatedTo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditRelatedTo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteRelatedTo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupQuestionCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup AddQuestionCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditQuestionCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewQuestionnaire;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditQuestionnair;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteQuestionnaire;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchQuestion;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listRelatedTo;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listCategories;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridQuestionnaire;
    }
}
