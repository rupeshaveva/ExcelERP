namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeeAttendanceViewer
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
            this.headerGroupOptions = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnGenerateManualSheet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtAttendanceMonth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panelAttendanceSummary = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableMonthCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).BeginInit();
            this.headerGroupOptions.Panel.SuspendLayout();
            this.headerGroupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelAttendanceSummary)).BeginInit();
            this.tableMonthCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupOptions
            // 
            this.headerGroupOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupOptions.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupOptions.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupOptions.HeaderVisibleSecondary = false;
            this.headerGroupOptions.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOptions.Name = "headerGroupOptions";
            // 
            // headerGroupOptions.Panel
            // 
            this.headerGroupOptions.Panel.Controls.Add(this.btnGenerateManualSheet);
            this.headerGroupOptions.Panel.Controls.Add(this.dtAttendanceMonth);
            this.headerGroupOptions.Panel.Controls.Add(this.label17);
            this.headerGroupOptions.Size = new System.Drawing.Size(1215, 67);
            this.headerGroupOptions.TabIndex = 1;
            this.headerGroupOptions.ValuesPrimary.Heading = "Attendance Viewer";
            this.headerGroupOptions.ValuesPrimary.Image = null;
            this.headerGroupOptions.ValuesSecondary.Heading = " ";
            // 
            // btnGenerateManualSheet
            // 
            this.btnGenerateManualSheet.Location = new System.Drawing.Point(187, 11);
            this.btnGenerateManualSheet.Name = "btnGenerateManualSheet";
            this.btnGenerateManualSheet.Size = new System.Drawing.Size(100, 25);
            this.btnGenerateManualSheet.TabIndex = 129;
            this.btnGenerateManualSheet.Values.Text = "Perpare Sheet";
            this.btnGenerateManualSheet.Click += new System.EventHandler(this.btnGenerateManualSheet_Click);
            // 
            // dtAttendanceMonth
            // 
            this.dtAttendanceMonth.CustomFormat = "MMMM yyyy";
            this.dtAttendanceMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAttendanceMonth.Location = new System.Drawing.Point(86, 11);
            this.dtAttendanceMonth.Name = "dtAttendanceMonth";
            this.dtAttendanceMonth.Size = new System.Drawing.Size(95, 21);
            this.dtAttendanceMonth.TabIndex = 120;
            this.dtAttendanceMonth.ValueChanged += new System.EventHandler(this.dtAttendanceMonth_ValueChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(4, 11);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 20);
            this.label17.TabIndex = 119;
            this.label17.Values.Text = "&Select Month";
            // 
            // panelAttendanceSummary
            // 
            this.panelAttendanceSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAttendanceSummary.Location = new System.Drawing.Point(0, 467);
            this.panelAttendanceSummary.Name = "panelAttendanceSummary";
            this.panelAttendanceSummary.Size = new System.Drawing.Size(1215, 88);
            this.panelAttendanceSummary.TabIndex = 4;
            // 
            // tableMonthCalendar
            // 
            this.tableMonthCalendar.AutoScroll = true;
            this.tableMonthCalendar.ColumnCount = 7;
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableMonthCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableMonthCalendar.Controls.Add(this.kryptonHeaderGroup2, 0, 0);
            this.tableMonthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMonthCalendar.Location = new System.Drawing.Point(0, 67);
            this.tableMonthCalendar.Name = "tableMonthCalendar";
            this.tableMonthCalendar.RowCount = 5;
            this.tableMonthCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMonthCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMonthCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMonthCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMonthCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMonthCalendar.Size = new System.Drawing.Size(1215, 400);
            this.tableMonthCalendar.TabIndex = 5;
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(3, 3);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(167, 24);
            this.kryptonHeaderGroup2.TabIndex = 0;
            // 
            // ControlEmployeeAttendanceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableMonthCalendar);
            this.Controls.Add(this.panelAttendanceSummary);
            this.Controls.Add(this.headerGroupOptions);
            this.Name = "ControlEmployeeAttendanceViewer";
            this.Size = new System.Drawing.Size(1215, 555);
            this.Load += new System.EventHandler(this.ControlEmployeeAttendanceViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).EndInit();
            this.headerGroupOptions.Panel.ResumeLayout(false);
            this.headerGroupOptions.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).EndInit();
            this.headerGroupOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelAttendanceSummary)).EndInit();
            this.tableMonthCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGenerateManualSheet;
        public ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtAttendanceMonth;
        public ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOptions;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelAttendanceSummary;
        private System.Windows.Forms.TableLayoutPanel tableMonthCalendar;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
    }
}
