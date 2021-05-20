using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Braincase.GanttChart;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using libERP.SERVICES.PMC;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using appExcelERP.Forms;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.PMC
{

    public partial class ControlGanttChart : UserControl
    {
        public int SelectedProjectID { get; set; }
        public PROJECT_PLAN_TYPE SelectedPlanType { get; set; }
        public MyTask SelectedTask { get; set; }

        OverlayPainter _mOverlay = new OverlayPainter();
        ProjectManager _mManager = null;

        public ControlGanttChart()
        {
            InitializeComponent();
            _mManager = new ProjectManager();
        }
        public void PopulateGanttChart()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _mManager = (new ServiceProject()).GetProjectPlanForProjectID(this.SelectedProjectID, SelectedPlanType);
                if (_mManager == null)
                {
                    _mManager = new ProjectManager();
                    #region Create a Project and some Tasks

                    //var work = new MyTask(_mManager) { Name = "Prepare for Work" };
                    //var wake = new MyTask(_mManager) { Name = "Wake Up" };
                    //var teeth = new MyTask(_mManager) { Name = "Brush Teeth" };
                    //var shower = new MyTask(_mManager) { Name = "Shower" };
                    //var clothes = new MyTask(_mManager) { Name = "Change into New Clothes" };
                    //var hair = new MyTask(_mManager) { Name = "Blow My Hair" };
                    //var pack = new MyTask(_mManager) { Name = "Pack the Suitcase" };

                    //_mManager.Add(work);
                    //_mManager.Add(wake);
                    //_mManager.Add(teeth);
                    //_mManager.Add(shower);
                    //_mManager.Add(clothes);
                    //_mManager.Add(hair);
                    //_mManager.Add(pack);

                    //// Set task durations, e.g. using ProjectManager methods 
                    //_mManager.SetDuration(wake, TimeSpan.FromDays(3));
                    //_mManager.SetDuration(teeth, TimeSpan.FromDays(5));
                    //_mManager.SetDuration(shower, TimeSpan.FromDays(7));
                    //_mManager.SetDuration(clothes, TimeSpan.FromDays(4));
                    //_mManager.SetDuration(hair, TimeSpan.FromDays(3));
                    //_mManager.SetDuration(pack, TimeSpan.FromDays(5));

                    //// demostrate splitting a task
                    //_mManager.Split(pack, new MyTask(_mManager), new MyTask(_mManager), TimeSpan.FromDays(2));

                    //// Set task complete status, e.g. using newly created properties
                    //wake.Complete = 0.9f;
                    //teeth.Complete = 0.5f;
                    //shower.Complete = 0.4f;

                    //// Give the Tasks some organisation, setting group and precedents
                    //_mManager.Group(work, wake);
                    //_mManager.Group(work, teeth);
                    //_mManager.Group(work, shower);
                    //_mManager.Group(work, clothes);
                    //_mManager.Group(work, hair);
                    //_mManager.Group(work, pack);
                    //_mManager.Relate(wake, teeth);
                    //_mManager.Relate(wake, shower);
                    //_mManager.Relate(shower, clothes);
                    //_mManager.Relate(shower, hair);
                    //_mManager.Relate(hair, pack);
                    //_mManager.Relate(clothes, pack);

                    //// Create and assign Resources.
                    //// MyResource is just custom user class. The API can accept any object as resource.
                    //var jake = new MyResource() { Name = "Jake" };
                    //var peter = new MyResource() { Name = "Peter" };
                    //var john = new MyResource() { Name = "John" };
                    //var lucas = new MyResource() { Name = "Lucas" };
                    //var james = new MyResource() { Name = "James" };
                    //var mary = new MyResource() { Name = "Mary" };
                    ////// Add some resources
                    //_mManager.Assign(wake, jake);
                    //_mManager.Assign(wake, peter);
                    //_mManager.Assign(wake, john);
                    //_mManager.Assign(teeth, jake);
                    //_mManager.Assign(teeth, james);
                    //_mManager.Assign(pack, james);
                    //_mManager.Assign(pack, lucas);
                    //_mManager.Assign(shower, mary);
                    //_mManager.Assign(shower, lucas);
                    //_mManager.Assign(shower, john);

                    //_mManager.Unassign(wake, john);
                    //_mManager.Unassign(wake, peter);
                    #endregion
                }
                // Initialize the Chart with our ProjectManager and CreateTaskDelegate
                _mChart.Init(_mManager);
                _mChart.CreateTaskDelegate = delegate () { return new MyTask(_mManager); };
                _mChart.TaskMouseOver += new EventHandler<TaskMouseEventArgs>(_mChart_TaskMouseOver);
                _mChart.TaskMouseOut += new EventHandler<TaskMouseEventArgs>(_mChart_TaskMouseOut);
                _mChart.TaskSelected += new EventHandler<TaskMouseEventArgs>(_mChart_TaskSelected);
                _mChart.PaintOverlay += _mOverlay.ChartOverlayPainter;
                _mChart.AllowTaskDragDrop = true;
                //foreach (Braincase.GanttChart.Task t in _mManager.Tasks)
                //{
                //    _mChart.SetToolTip(t, string.Join(", ", _mManager.ResourcesOf(t).Select(x => (x as MyResource).Name)));
                //}
                // set some tooltips to show the resources in each task
                //_mChart.SetToolTip(wake, string.Join(", ", _mManager.ResourcesOf(wake).Select(x => (x as MyResource).Name)));
                //_mChart.SetToolTip(teeth, string.Join(", ", _mManager.ResourcesOf(teeth).Select(x => (x as MyResource).Name)));
                //_mChart.SetToolTip(pack, string.Join(", ", _mManager.ResourcesOf(pack).Select(x => (x as MyResource).Name)));
                //_mChart.SetToolTip(shower, string.Join(", ", _mManager.ResourcesOf(shower).Select(x => (x as MyResource).Name)));

                // Set Time information
                var span = DateTime.Today - _mManager.Start;
                _mManager.Now = span; // set the "Now" marker at the correct date
                _mChart.TimeResolution = TimeResolution.Day; // Set the chart to display in days in header

                
                _mOverlay.PrintMode = !((btnInformation.Checked == ButtonCheckState.Checked) ? true : false);
                gridAllTasks.DataSource = new BindingSource(_mManager.Tasks, null);
                gridResources.DataSource = new BindingSource(_mManager.GetAllResources(), null);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::PopulateGanttChart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void PopulateAllResourcesGrid()
        {
            try
            {
                var lst = _mManager.GetAllResources();
                gridResources.DataSource = new BindingSource(lst, null);
                gridResources.Columns["ID"].Visible = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::PopulateAllResourcesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateTaskNotes()
        {
            try
            {
                List<TaskNote> lstNotes = new List<TaskNote>();
                if (SelectedTask.TaskNotes.Count>0)
                   lstNotes= SelectedTask.TaskNotes.OrderByDescending(x => x.NoteDatetime).ToList();

                gridTaskNotes.DataSource = new BindingSource(lstNotes, null);
                foreach (DataGridViewColumn col in gridTaskNotes.Columns)
                {
                    col.Visible = false;
                }
                gridTaskNotes.Columns["SummaryText"].Visible = true;
                gridTaskNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridTaskNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                gridTaskNotes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::PopulateTaskNotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void _mChart_TaskSelected(object sender, TaskMouseEventArgs e)
        {
            SelectedTask = (MyTask)e.Task;
            txtTaskName.Text = SelectedTask.Name;
            #region set all resources for selected TASK
            List<SelectListItem> allResources = new List<SelectListItem>();
            foreach (MyResource myResource in _mManager.GetAllResources())
            {
                allResources.Add(new SelectListItem() { ID= myResource.ID, Description= myResource.Name});
            }
            
            List<ListViewItem> taskResources = _mManager.ResourcesOf(e.Task).Select(x => new ListViewItem(((MyResource)x).Name)).ToList();
            foreach (ListViewItem item in taskResources)
            {
                SelectListItem found = allResources.Where(x => x.Description == item.Text).FirstOrDefault();
                if (found!=null) found.IsActive = true;
            }
            gridTaskResources.DataSource = allResources;
            gridTaskResources.Columns["ID"].Visible =
            gridTaskResources.Columns["Code"].Visible =
            gridTaskResources.Columns["DescriptionToUpper"].Visible = false;
            gridTaskResources.Columns["IsActive"].Width = 40;
            gridTaskResources.Columns["Description"].ReadOnly = true;
            gridTaskResources.Columns["IsActive"].DisplayIndex = 0;
            gridTaskResources.Columns["Description"].DisplayIndex = 1;

            PopulateTaskNotes();
            #endregion  

        }
        void _mChart_TaskMouseOut(object sender, TaskMouseEventArgs e)
        {
            headerGroupGanttChart.ValuesSecondary.Description = "";
            _mChart.Invalidate();
        }
        void _mChart_TaskMouseOver(object sender, TaskMouseEventArgs e)
        {
            string strText = string.Format("{0:0.00}% {1}",e.Task.Complete*100, string.Join(", ", _mManager.ResourcesOf(e.Task).Select(x => (x as MyResource).Name)));
            headerGroupGanttChart.ValuesSecondary.Heading = strText;
            strText = string.Format("{0} - {1} [{2}]", _mManager.GetDateTime(e.Task.Start).ToString("dd MMM"), _mManager.GetDateTime(e.Task.End).ToString("dd MMM"), e.Task.End - e.Task.Start);
            headerGroupGanttChart.ValuesSecondary.Description = strText;
            _mChart.Invalidate();
        }

        #region Main Menu
        private void mnuViewDaysDayOfWeek_Click(object sender, EventArgs e)
        {
            _mChart.TimeResolution = TimeResolution.Week;
            _mChart.Invalidate();
        }
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            // start a new Project and init the chart with the project
            _mManager = new ProjectManager();
           
        }
        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please visit http://www.jakesee.com/net-c-winforms-gantt-chart-control/ for more help and details", "Braincase Solutions - Gantt Chart", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process.Start("http://www.jakesee.com/net-c-winforms-gantt-chart-control/");
            }
        }
        private void mnuViewRelationships_Click(object sender, EventArgs e)
        {
            //_mChart.ShowRelations = mnuViewRelationships.Checked = !mnuViewRelationships.Checked;
            //_mChart.Invalidate();
        }
        private void mnuViewSlack_Click(object sender, EventArgs e)
        {
            //_mChart.ShowSlack = mnuViewSlack.Checked = !mnuViewSlack.Checked;
            //_mChart.Invalidate();
        }
        private void mnuViewIntructions_Click(object sender, EventArgs e)
        {
            //_mOverlay.PrintMode = !(mnuViewIntructions.Checked = !mnuViewIntructions.Checked);
            //_mChart.Invalidate();
        }

        #region Timescale Views
        private void btnHours_Click(object sender, EventArgs e)
        {
            _mChart.TimeResolution = TimeResolution.Hour;
            _ClearTimeResolutionMenu();
            btnHours.Checked = ButtonCheckState.Checked;
            _mChart.Invalidate();
        }
        private void btnDays_Click(object sender, EventArgs e)
        {
            _mChart.TimeResolution = TimeResolution.Day;
            _ClearTimeResolutionMenu();
            btnDays.Checked = ButtonCheckState.Checked;
            _mChart.Invalidate();
        }
        private void btnWeeks_Click(object sender, EventArgs e)
        {
            _mChart.TimeResolution = TimeResolution.Week;
            _ClearTimeResolutionMenu();
            btnWeeks.Checked = ButtonCheckState.Checked;
            _mChart.Invalidate();
        }
        private void _ClearTimeResolutionMenu()
        {
            btnHours.Checked = btnWeeks.Checked = btnDays.Checked = ButtonCheckState.Unchecked;
        }
        #endregion Timescale Views

        #endregion Main Menu

        #region Sidebar
        private void _mDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _mManager.Start = _mStartDatePicker.Value;
            var span = DateTime.Today - _mManager.Start;
            _mManager.Now = span;

            _mChart.Invalidate();
        }
        private void _mPropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            _mChart.Invalidate();
        }
        private void _mNowDatePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan span = _mNowDatePicker.Value - _mStartDatePicker.Value;
            _mManager.Now = span.Add(new TimeSpan(1, 0, 0, 0));
            _mChart.Invalidate();
        }
        private void _mScrollDatePicker_ValueChanged(object sender, EventArgs e)
        {
            _mChart.ScrollTo(_mScrollDatePicker.Value);
            _mChart.Invalidate();
        }
        private void _mTaskGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (gridAllTasks.SelectedRows.Count > 0)
            {
                var task = gridAllTasks.SelectedRows[0].DataBoundItem as Braincase.GanttChart.Task;
                _mChart.ScrollTo(task);
            }
        }
        #endregion Sidebar

        #region Print
        private void _PrintDocument(float scale)
        {
            using (var dialog = new PrintDialog())
            {
                dialog.Document = new System.Drawing.Printing.PrintDocument();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // set the print mode for the custom overlay painter so that we skip printing instructions
                    dialog.Document.BeginPrint += (s, arg) => _mOverlay.PrintMode = true;
                    dialog.Document.EndPrint += (s, arg) => _mOverlay.PrintMode = false;

                    // tell chart to print to the document at the specified scale
                    _mChart.Print(dialog.Document, scale);
                }
            }
        }
        private void _PrintImage(float scale)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Bitmap (*.bmp) | *.bmp";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // set the print mode for the custom overlay painter so that we skip printing instructions
                    _mOverlay.PrintMode = true;
                    // tell chart to print to the document at the specified scale

                    var bitmap = _mChart.Print(scale);
                    _mOverlay.PrintMode = false; // restore printing overlays

                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }
        #endregion Print        

        #region BUTTON CLICK
        private void btnCollapseDetails_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }
        private void btnInformation_Click(object sender, EventArgs e)
        {
            try
            {
                _mOverlay.PrintMode = !((btnInformation.Checked == ButtonCheckState.Checked) ? true : false);
                _mChart.Invalidate();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnAddNewTask_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnSaveProjectPlanning_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if ((new ServiceProject()).UpdateProjectPlanning(this.SelectedProjectID, _mManager,this.SelectedPlanType))
                    MessageBox.Show("Project Planning Updated Successfully.");

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnSaveProjectPlanning_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            try
            {
                MyTask newTask = new MyTask(_mManager) { Name = "New Task" };
                newTask.TaskNotes = new List<TaskNote>();
                _mManager.Add(newTask);
                _mChart.Init(_mManager);
                _mChart.Invalidate();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnAddNewTask_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Bitmap (*.bmp) | *.bmp";
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // set the print mode for the custom overlay painter so that we skip printing instructions
                        _mOverlay.PrintMode = true;
                        // tell chart to print to the document at the specified scale

                        var bitmap = _mChart.Print();
                        _mOverlay.PrintMode = false; // restore printing overlays

                        bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SelectedTask.Name = txtTaskName.Text.Trim();
                _mManager.Unassign(_mChart.SelectedTask);
                foreach (DataGridViewRow row in gridTaskResources.Rows)
                {
                    if ((bool)row.Cells["IsActive"].Value)
                    {
                        foreach (MyResource myResource in _mManager.GetAllResources())
                        {
                            if (row.Cells["ID"].Value.ToString() == myResource.ID.ToString())
                            {
                                _mManager.Assign(_mChart.SelectedTask, myResource);
                                //continue;
                            }
                        }
                    }
                }
                _mChart.Invalidate();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnUpdateTask_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void ControlGanttChart_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Width * .65);
        }
        private void btnAddMoreResources_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.EMPLOYEES);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindingList<MultiSelectListItem> selectedIDs = frm.SelectedItems;
                    if (selectedIDs != null)
                    {
                        foreach (MultiSelectListItem item in selectedIDs)
                        {
                            string[] arr= item.Description.Split('\n');
                            _mManager.Add(new MyResource() { ID = item.ID, Name = arr[0]});
                        }
                        //gridResources.DataSource = new BindingSource(_mManager.GetAllResources(), null);
                        PopulateAllResourcesGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnAddMoreResources_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewNote_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditTaskNote frm = new frmAddEditTaskNote();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TaskNote tNote = new TaskNote();
                    tNote.NoteDatetime = AppCommon.GetServerDateTime();
                    tNote.ResourceID = Program.CURR_USER.EmployeeID;
                    tNote.ResourceName = Program.CURR_USER.UserFullName;
                    tNote.Remarks = frm.txtRemarks.Text.Trim();
                    tNote.Complete = float.Parse(frm.txtComplete.Text.Trim())/100;

                    this.SelectedTask.TaskNotes.Add(tNote);
                    this.SelectedTask.Complete = tNote.Complete;
                    _mChart.Invalidate();
                    PopulateTaskNotes();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnAddNewNote_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void ControlGanttChart_Load(object sender, EventArgs e)
        {
            switch (this.SelectedPlanType)
            {
                case PROJECT_PLAN_TYPE.PROJECT_PLANNING:
                    tabPageTaskNotes.Visible = false;
                    break;
            }
        }
        private void btnImportMasterPlan_Click(object sender, EventArgs e)
        {
            ServiceProject _service = new ServiceProject();
            try
            {
                switch (this.SelectedPlanType)
                {
                    case PROJECT_PLAN_TYPE.PROJECT_PLANNING:
                        tabPageTaskNotes.Visible = false;
                        frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.ALL_PROJECTS);
                        frm.SingleSelect = true;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            int prevProjectID = frm.SelectedItems[0].ID;
                            _mManager = (new ServiceProject()).GetProjectPlanForProjectID(prevProjectID, PROJECT_PLAN_TYPE.PROJECT_PLANNING);
                            _mChart.Init(_mManager);
                            _mChart.Invalidate();
                        }
                        break;
                    case PROJECT_PLAN_TYPE.PROJECT_EXECUTION:
                        string strMessage = "Are you sure to Generate Execution plan from MasterPlanning?";
                        if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _mManager = _service.GetProjectPlanForProjectID(this.SelectedProjectID, PROJECT_PLAN_TYPE.PROJECT_PLANNING);
                            _service.UpdateProjectPlanning(this.SelectedProjectID, _mManager, this.SelectedPlanType);
                            PopulateGanttChart();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlGanttChart::btnImportMasterPlan_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #region overlay painter
    /// <summary>
    /// An example of how to encapsulate a helper painter for painter additional features on Chart
    /// </summary>
    public class OverlayPainter
    {
        /// <summary>
        /// Hook such a method to the chart paint event listeners
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChartOverlayPainter(object sender, ChartPaintEventArgs e)
        {
            // Don't want to print instructions to file
            if (this.PrintMode) return;

            var g = e.Graphics;
            var chart = e.Chart;

            // Demo: Static billboards begin -----------------------------------
            // Demonstrate how to draw static billboards
            // "push matrix" -- save our transformation matrix
            e.Chart.BeginBillboardMode(e.Graphics);

            // draw mouse command instructions
            int margin = 300;
            int left = 20;
            var color = chart.HeaderFormat.Color;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("*******************************************************************************************************");
            builder.AppendLine("Left Click        - Select task and display properties in PropertyGrid");
            builder.AppendLine("Left Mouse Drag   - Change task starting point");
            builder.AppendLine("Right Mouse Drag  - Change task duration");
            builder.AppendLine("Middle Mouse Drag - Change task complete percentage");
            builder.AppendLine("Left Doubleclick  - Toggle collaspe on task group");
            builder.AppendLine("Right Doubleclick - Split task into task parts");
            builder.AppendLine("Left Mouse Dragdrop onto another task - Group drag task under drop task");
            builder.AppendLine("Right Mouse Dragdrop onto another task part - Join task parts");
            builder.AppendLine("SHIFT + Left Mouse Dragdrop onto another task - Make drop task precedent of drag task");
            builder.AppendLine("ALT + Left Dragdrop onto another task - Ungroup drag task from drop task / Remove drop task from drag task precedent list");
            builder.AppendLine("SHIFT + Left Mouse Dragdrop - Order tasks");
            builder.AppendLine("SHIFT + Middle Click - Create new task");
            builder.AppendLine("ALT + Middle Click - Delete task");
            builder.AppendLine("Left Doubleclick - Toggle collaspe on task group");
            var size = g.MeasureString(builder.ToString(), e.Chart.Font);
            var background = new Rectangle(left, chart.Height - margin, (int)size.Width, (int)size.Height);
            background.Inflate(10, 10);
            g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(background, Color.LightYellow, Color.Transparent, System.Drawing.Drawing2D.LinearGradientMode.Vertical), background);
            g.DrawRectangle(Pens.Brown, background);
            g.DrawString(builder.ToString(), chart.Font, color, new PointF(left, chart.Height - margin));


            // "pop matrix" -- restore the previous matrix
            e.Chart.EndBillboardMode(e.Graphics);
            // Demo: Static billboards end -----------------------------------
        }
        public bool PrintMode { get; set; }
    }
    #endregion overlay painter

    #region custom task and resource
    /// <summary>
    /// A custom resource of your own type (optional)
    /// </summary>
    [Serializable]
    public class MyResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public MyResource() { }

    }
    /// <summary>
    /// A custom task of your own type deriving from the Task interface (optional)
    /// </summary>
    [Serializable]
    public class MyTask : Braincase.GanttChart.Task
    {
        public MyTask(ProjectManager manager)
            : base()
        {

            Manager = manager;
        }
        private ProjectManager Manager { get; set; }
        public new TimeSpan Start { get { return base.Start; } set { Manager.SetStart(this, value); } }
        public new TimeSpan End { get { return base.End; } set { Manager.SetEnd(this, value); } }
        public new TimeSpan Duration { get { return base.Duration; } set { Manager.SetDuration(this, value); } }
        public new float Complete { get { return base.Complete; } set { Manager.SetComplete(this, value); } }
        public List<TaskNote> TaskNotes { get; set; }

    }

    [Serializable]
    public class TaskNote
    {
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public DateTime NoteDatetime { get; set; }
        public string Remarks { get; set; }
        public float Complete { get; set; }
        public TaskNote() { NoteDatetime = DateTime.Now; }
        public string SummaryText { get { return string.Format("{3} [{0} ({1:0.00}%)]\n\n{2}\n", this.NoteDatetime.ToString("dd-MM-yy hh:mmtt"), Complete*100, Remarks, ResourceName); } }

    }

    #endregion custom task and resource
}
