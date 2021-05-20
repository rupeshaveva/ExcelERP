namespace appExcelERP.Controls.MASTERS
{
    partial class pageLocations
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
            this.headerGroupLocations = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.headerGroupCities = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewCity = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditCity = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCities = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchCities = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.headerGroupStates = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewState = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditState = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridStates = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchStates = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.headerGroupCountries = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewCountry = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditCountry = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCountries = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchCountry = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLocations.Panel)).BeginInit();
            this.headerGroupLocations.Panel.SuspendLayout();
            this.headerGroupLocations.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCities.Panel)).BeginInit();
            this.headerGroupCities.Panel.SuspendLayout();
            this.headerGroupCities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupStates.Panel)).BeginInit();
            this.headerGroupStates.Panel.SuspendLayout();
            this.headerGroupStates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCountries.Panel)).BeginInit();
            this.headerGroupCountries.Panel.SuspendLayout();
            this.headerGroupCountries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCountries)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupLocations
            // 
            this.headerGroupLocations.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRefresh});
            this.headerGroupLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupLocations.HeaderVisibleSecondary = false;
            this.headerGroupLocations.Location = new System.Drawing.Point(0, 0);
            this.headerGroupLocations.Name = "headerGroupLocations";
            // 
            // headerGroupLocations.Panel
            // 
            this.headerGroupLocations.Panel.Controls.Add(this.tableLayoutPanel1);
            this.headerGroupLocations.Size = new System.Drawing.Size(819, 401);
            this.headerGroupLocations.TabIndex = 0;
            this.headerGroupLocations.ValuesPrimary.Heading = "Locations";
            this.headerGroupLocations.ValuesPrimary.Image = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "66979F62F902448BE58A31FA79E95D93";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.headerGroupCities, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerGroupStates, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerGroupCountries, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 369);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // headerGroupCities
            // 
            this.headerGroupCities.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewCity,
            this.btnEditCity});
            this.headerGroupCities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupCities.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupCities.Location = new System.Drawing.Point(532, 8);
            this.headerGroupCities.Name = "headerGroupCities";
            // 
            // headerGroupCities.Panel
            // 
            this.headerGroupCities.Panel.Controls.Add(this.gridCities);
            this.headerGroupCities.Panel.Controls.Add(this.txtSearchCities);
            this.headerGroupCities.Size = new System.Drawing.Size(277, 353);
            this.headerGroupCities.TabIndex = 2;
            this.headerGroupCities.ValuesPrimary.Heading = "Cities";
            this.headerGroupCities.ValuesPrimary.Image = null;
            // 
            // btnAddNewCity
            // 
            this.btnAddNewCity.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewCity.Text = "&Add New";
            this.btnAddNewCity.UniqueName = "FCF0330DC6094087DA8878572C922894";
            this.btnAddNewCity.Click += new System.EventHandler(this.btnAddNewCity_Click);
            // 
            // btnEditCity
            // 
            this.btnEditCity.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditCity.Text = "&Edit";
            this.btnEditCity.UniqueName = "3FA1F66436294C5D6795CF2DC87EAE95";
            this.btnEditCity.Click += new System.EventHandler(this.btnEditCity_Click);
            // 
            // gridCities
            // 
            this.gridCities.AllowUserToAddRows = false;
            this.gridCities.AllowUserToDeleteRows = false;
            this.gridCities.AllowUserToOrderColumns = true;
            this.gridCities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCities.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCities.ColumnHeadersHeight = 28;
            this.gridCities.ColumnHeadersVisible = false;
            this.gridCities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCities.Location = new System.Drawing.Point(0, 26);
            this.gridCities.Name = "gridCities";
            this.gridCities.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCities.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCities.Size = new System.Drawing.Size(275, 277);
            this.gridCities.TabIndex = 9;
            this.gridCities.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCities_RowEnter);
            // 
            // txtSearchCities
            // 
            this.txtSearchCities.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.txtSearchCities.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchCities.Location = new System.Drawing.Point(0, 0);
            this.txtSearchCities.Name = "txtSearchCities";
            this.txtSearchCities.Size = new System.Drawing.Size(275, 26);
            this.txtSearchCities.TabIndex = 8;
            this.txtSearchCities.TextChanged += new System.EventHandler(this.txtSearchCities_TextChanged);
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Text = "&Search";
            this.buttonSpecAny2.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // headerGroupStates
            // 
            this.headerGroupStates.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewState,
            this.btnEditState});
            this.headerGroupStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupStates.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupStates.Location = new System.Drawing.Point(250, 8);
            this.headerGroupStates.Name = "headerGroupStates";
            // 
            // headerGroupStates.Panel
            // 
            this.headerGroupStates.Panel.Controls.Add(this.gridStates);
            this.headerGroupStates.Panel.Controls.Add(this.txtSearchStates);
            this.headerGroupStates.Size = new System.Drawing.Size(276, 353);
            this.headerGroupStates.TabIndex = 1;
            this.headerGroupStates.ValuesPrimary.Heading = "State/Provinces";
            this.headerGroupStates.ValuesPrimary.Image = null;
            // 
            // btnAddNewState
            // 
            this.btnAddNewState.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewState.Text = "&Add New";
            this.btnAddNewState.UniqueName = "88208F4AF49C45709F80AE571C9990E4";
            this.btnAddNewState.Click += new System.EventHandler(this.btnAddNewState_Click);
            // 
            // btnEditState
            // 
            this.btnEditState.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditState.Text = "&Edit";
            this.btnEditState.UniqueName = "3831F9CCD83E4418D095D3856B880258";
            this.btnEditState.Click += new System.EventHandler(this.btnEditState_Click);
            // 
            // gridStates
            // 
            this.gridStates.AllowUserToAddRows = false;
            this.gridStates.AllowUserToDeleteRows = false;
            this.gridStates.AllowUserToOrderColumns = true;
            this.gridStates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStates.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridStates.ColumnHeadersHeight = 28;
            this.gridStates.ColumnHeadersVisible = false;
            this.gridStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridStates.Location = new System.Drawing.Point(0, 26);
            this.gridStates.Name = "gridStates";
            this.gridStates.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStates.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridStates.Size = new System.Drawing.Size(274, 277);
            this.gridStates.TabIndex = 9;
            this.gridStates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStates_CellContentClick);
            this.gridStates.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStates_RowEnter);
            // 
            // txtSearchStates
            // 
            this.txtSearchStates.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.txtSearchStates.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchStates.Location = new System.Drawing.Point(0, 0);
            this.txtSearchStates.Name = "txtSearchStates";
            this.txtSearchStates.Size = new System.Drawing.Size(274, 26);
            this.txtSearchStates.TabIndex = 8;
            this.txtSearchStates.TextChanged += new System.EventHandler(this.txtSearchStates_TextChanged);
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Text = "&Search";
            this.buttonSpecAny1.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // headerGroupCountries
            // 
            this.headerGroupCountries.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewCountry,
            this.btnEditCountry});
            this.headerGroupCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupCountries.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupCountries.Location = new System.Drawing.Point(8, 8);
            this.headerGroupCountries.Name = "headerGroupCountries";
            // 
            // headerGroupCountries.Panel
            // 
            this.headerGroupCountries.Panel.Controls.Add(this.gridCountries);
            this.headerGroupCountries.Panel.Controls.Add(this.txtSearchCountry);
            this.headerGroupCountries.Size = new System.Drawing.Size(236, 353);
            this.headerGroupCountries.TabIndex = 0;
            this.headerGroupCountries.ValuesPrimary.Heading = "Countries";
            this.headerGroupCountries.ValuesPrimary.Image = null;
            // 
            // btnAddNewCountry
            // 
            this.btnAddNewCountry.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewCountry.Text = "&Add New";
            this.btnAddNewCountry.UniqueName = "4C07B53CC845421BAA8158F30E6E563D";
            this.btnAddNewCountry.Click += new System.EventHandler(this.btnAddNewCountry_Click);
            // 
            // btnEditCountry
            // 
            this.btnEditCountry.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditCountry.Text = "&Edit";
            this.btnEditCountry.UniqueName = "22B29AFA59B041B46DB3D1AD317BE927";
            this.btnEditCountry.Click += new System.EventHandler(this.btnEditCountry_Click);
            // 
            // gridCountries
            // 
            this.gridCountries.AllowUserToAddRows = false;
            this.gridCountries.AllowUserToDeleteRows = false;
            this.gridCountries.AllowUserToOrderColumns = true;
            this.gridCountries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCountries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCountries.ColumnHeadersHeight = 28;
            this.gridCountries.ColumnHeadersVisible = false;
            this.gridCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCountries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCountries.Location = new System.Drawing.Point(0, 26);
            this.gridCountries.Name = "gridCountries";
            this.gridCountries.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCountries.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridCountries.Size = new System.Drawing.Size(234, 277);
            this.gridCountries.TabIndex = 9;
            this.gridCountries.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCountries_RowEnter);
            // 
            // txtSearchCountry
            // 
            this.txtSearchCountry.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearch});
            this.txtSearchCountry.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchCountry.Location = new System.Drawing.Point(0, 0);
            this.txtSearchCountry.Name = "txtSearchCountry";
            this.txtSearchCountry.Size = new System.Drawing.Size(234, 26);
            this.txtSearchCountry.TabIndex = 8;
            this.txtSearchCountry.TextChanged += new System.EventHandler(this.txtSearchCountry_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Text = "&Search";
            this.btnSearch.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // pageLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupLocations);
            this.Name = "pageLocations";
            this.Size = new System.Drawing.Size(819, 401);
            this.Load += new System.EventHandler(this.pageLocations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLocations.Panel)).EndInit();
            this.headerGroupLocations.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLocations)).EndInit();
            this.headerGroupLocations.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCities.Panel)).EndInit();
            this.headerGroupCities.Panel.ResumeLayout(false);
            this.headerGroupCities.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCities)).EndInit();
            this.headerGroupCities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupStates.Panel)).EndInit();
            this.headerGroupStates.Panel.ResumeLayout(false);
            this.headerGroupStates.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupStates)).EndInit();
            this.headerGroupStates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCountries.Panel)).EndInit();
            this.headerGroupCountries.Panel.ResumeLayout(false);
            this.headerGroupCountries.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCountries)).EndInit();
            this.headerGroupCountries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCountries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupLocations;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupCities;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupStates;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupCountries;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCities;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchCities;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewState;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditState;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridStates;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchStates;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewCountry;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditCountry;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCountries;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchCountry;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewCity;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditCity;
    }
}
