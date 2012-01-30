namespace SchoolTycoon
{
    partial class MainWindow
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classroomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nederlandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.theGrid = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.standardTab = new System.Windows.Forms.TabPage();
            this.OpenCBbutton = new System.Windows.Forms.Button();
            this.advanceDayButton = new System.Windows.Forms.Button();
            this.classroomBuilderTab = new System.Windows.Forms.TabPage();
            this.BlueprintBuildTime = new System.Windows.Forms.Label();
            this.BlueprintPrice = new System.Windows.Forms.Label();
            this.CBbuildButton = new System.Windows.Forms.Button();
            this.BlueprintDescription = new System.Windows.Forms.Label();
            this.BlueprintName = new System.Windows.Forms.Label();
            this.NextBlueprint = new System.Windows.Forms.Button();
            this.PreviousBlueprint = new System.Windows.Forms.Button();
            this.RotateBlueprintRight = new System.Windows.Forms.Button();
            this.RotateBlueprintLeft = new System.Windows.Forms.Button();
            this.BuilderBlueprint = new System.Windows.Forms.TableLayoutPanel();
            this.CBcancelButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.TeacherCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PupilCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentDate = new System.Windows.Forms.Label();
            this.MoneyCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.standardTab.SuspendLayout();
            this.classroomBuilderTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.buildToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classroomToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // classroomToolStripMenuItem
            // 
            this.classroomToolStripMenuItem.Name = "classroomToolStripMenuItem";
            this.classroomToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.classroomToolStripMenuItem.Text = "Classroom";
            this.classroomToolStripMenuItem.Click += new System.EventHandler(this.OpenClassroomBuilder);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.nederlandsToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.englishToolStripMenuItem.Tag = "en";
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage);
            // 
            // nederlandsToolStripMenuItem
            // 
            this.nederlandsToolStripMenuItem.Name = "nederlandsToolStripMenuItem";
            this.nederlandsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.nederlandsToolStripMenuItem.Tag = "nl";
            this.nederlandsToolStripMenuItem.Text = "Nederlands";
            this.nederlandsToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeTile
            // 
            this.changeTile.Name = "contextMenuStrip1";
            this.changeTile.Size = new System.Drawing.Size(61, 4);
            this.changeTile.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DebugTileChange);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.theGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 250;
            this.splitContainer1.Size = new System.Drawing.Size(788, 368);
            this.splitContainer1.SplitterDistance = 534;
            this.splitContainer1.TabIndex = 1;
            // 
            // theGrid
            // 
            this.theGrid.AutoScroll = true;
            this.theGrid.AutoSize = true;
            this.theGrid.ColumnCount = 1;
            this.theGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.theGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theGrid.Location = new System.Drawing.Point(0, 0);
            this.theGrid.Margin = new System.Windows.Forms.Padding(0);
            this.theGrid.Name = "theGrid";
            this.theGrid.RowCount = 1;
            this.theGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.theGrid.Size = new System.Drawing.Size(534, 368);
            this.theGrid.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.standardTab);
            this.tabControl1.Controls.Add(this.classroomBuilderTab);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(250, 368);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // standardTab
            // 
            this.standardTab.BackColor = System.Drawing.Color.White;
            this.standardTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.standardTab.Controls.Add(this.OpenCBbutton);
            this.standardTab.Controls.Add(this.advanceDayButton);
            this.standardTab.Location = new System.Drawing.Point(4, 22);
            this.standardTab.Name = "standardTab";
            this.standardTab.Padding = new System.Windows.Forms.Padding(3);
            this.standardTab.Size = new System.Drawing.Size(242, 342);
            this.standardTab.TabIndex = 0;
            this.standardTab.Text = "Standard";
            // 
            // OpenCBbutton
            // 
            this.OpenCBbutton.AutoSize = true;
            this.OpenCBbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenCBbutton.Location = new System.Drawing.Point(3, 2);
            this.OpenCBbutton.Name = "OpenCBbutton";
            this.OpenCBbutton.Size = new System.Drawing.Size(65, 36);
            this.OpenCBbutton.TabIndex = 1;
            this.OpenCBbutton.Text = "Classroom\r\nBuilder";
            this.OpenCBbutton.UseVisualStyleBackColor = true;
            this.OpenCBbutton.Click += new System.EventHandler(this.OpenClassroomBuilder);
            // 
            // advanceDayButton
            // 
            this.advanceDayButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.advanceDayButton.Location = new System.Drawing.Point(3, 292);
            this.advanceDayButton.Name = "advanceDayButton";
            this.advanceDayButton.Size = new System.Drawing.Size(234, 45);
            this.advanceDayButton.TabIndex = 0;
            this.advanceDayButton.Text = "Advance Day";
            this.advanceDayButton.UseVisualStyleBackColor = true;
            this.advanceDayButton.Click += new System.EventHandler(this.advanceDayButton_Click);
            // 
            // classroomBuilderTab
            // 
            this.classroomBuilderTab.BackColor = System.Drawing.Color.White;
            this.classroomBuilderTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classroomBuilderTab.Controls.Add(this.BlueprintBuildTime);
            this.classroomBuilderTab.Controls.Add(this.BlueprintPrice);
            this.classroomBuilderTab.Controls.Add(this.CBbuildButton);
            this.classroomBuilderTab.Controls.Add(this.BlueprintDescription);
            this.classroomBuilderTab.Controls.Add(this.BlueprintName);
            this.classroomBuilderTab.Controls.Add(this.NextBlueprint);
            this.classroomBuilderTab.Controls.Add(this.PreviousBlueprint);
            this.classroomBuilderTab.Controls.Add(this.RotateBlueprintRight);
            this.classroomBuilderTab.Controls.Add(this.RotateBlueprintLeft);
            this.classroomBuilderTab.Controls.Add(this.BuilderBlueprint);
            this.classroomBuilderTab.Controls.Add(this.CBcancelButton);
            this.classroomBuilderTab.Location = new System.Drawing.Point(4, 22);
            this.classroomBuilderTab.Name = "classroomBuilderTab";
            this.classroomBuilderTab.Padding = new System.Windows.Forms.Padding(3);
            this.classroomBuilderTab.Size = new System.Drawing.Size(242, 342);
            this.classroomBuilderTab.TabIndex = 1;
            this.classroomBuilderTab.Text = "ClassroomBuilder";
            // 
            // BlueprintBuildTime
            // 
            this.BlueprintBuildTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueprintBuildTime.Location = new System.Drawing.Point(3, 288);
            this.BlueprintBuildTime.Name = "BlueprintBuildTime";
            this.BlueprintBuildTime.Size = new System.Drawing.Size(236, 13);
            this.BlueprintBuildTime.TabIndex = 11;
            this.BlueprintBuildTime.Text = "Building time: 0 days";
            this.BlueprintBuildTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BlueprintPrice
            // 
            this.BlueprintPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueprintPrice.Location = new System.Drawing.Point(3, 275);
            this.BlueprintPrice.Name = "BlueprintPrice";
            this.BlueprintPrice.Size = new System.Drawing.Size(236, 13);
            this.BlueprintPrice.TabIndex = 10;
            this.BlueprintPrice.Text = "Costs: €0";
            this.BlueprintPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CBbuildButton
            // 
            this.CBbuildButton.Enabled = false;
            this.CBbuildButton.Location = new System.Drawing.Point(1, 304);
            this.CBbuildButton.Name = "CBbuildButton";
            this.CBbuildButton.Size = new System.Drawing.Size(119, 35);
            this.CBbuildButton.TabIndex = 4;
            this.CBbuildButton.Text = "Build";
            this.CBbuildButton.UseVisualStyleBackColor = true;
            this.CBbuildButton.Click += new System.EventHandler(this.CBbuildButton_Click);
            // 
            // BlueprintDescription
            // 
            this.BlueprintDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.BlueprintDescription.Location = new System.Drawing.Point(6, 184);
            this.BlueprintDescription.Name = "BlueprintDescription";
            this.BlueprintDescription.Size = new System.Drawing.Size(233, 91);
            this.BlueprintDescription.TabIndex = 8;
            this.BlueprintDescription.Text = "Blueprint Description";
            // 
            // BlueprintName
            // 
            this.BlueprintName.AutoSize = true;
            this.BlueprintName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.BlueprintName.Location = new System.Drawing.Point(6, 166);
            this.BlueprintName.Name = "BlueprintName";
            this.BlueprintName.Size = new System.Drawing.Size(153, 18);
            this.BlueprintName.TabIndex = 7;
            this.BlueprintName.Text = "< Blueprint Name >";
            // 
            // NextBlueprint
            // 
            this.NextBlueprint.AutoSize = true;
            this.NextBlueprint.Image = global::SchoolTycoon.Properties.Resources.next;
            this.NextBlueprint.Location = new System.Drawing.Point(203, 39);
            this.NextBlueprint.Name = "NextBlueprint";
            this.NextBlueprint.Size = new System.Drawing.Size(31, 124);
            this.NextBlueprint.TabIndex = 3;
            this.NextBlueprint.Tag = new sbyte[] {
        ((sbyte)(1)),
        ((sbyte)(1))};
            this.NextBlueprint.UseVisualStyleBackColor = true;
            this.NextBlueprint.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // PreviousBlueprint
            // 
            this.PreviousBlueprint.AutoSize = true;
            this.PreviousBlueprint.Image = global::SchoolTycoon.Properties.Resources.previous;
            this.PreviousBlueprint.Location = new System.Drawing.Point(6, 39);
            this.PreviousBlueprint.Name = "PreviousBlueprint";
            this.PreviousBlueprint.Size = new System.Drawing.Size(31, 124);
            this.PreviousBlueprint.TabIndex = 2;
            this.PreviousBlueprint.Tag = new sbyte[] {
        ((sbyte)(1)),
        ((sbyte)(-1))};
            this.PreviousBlueprint.UseVisualStyleBackColor = true;
            this.PreviousBlueprint.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // RotateBlueprintRight
            // 
            this.RotateBlueprintRight.AutoSize = true;
            this.RotateBlueprintRight.Image = global::SchoolTycoon.Properties.Resources.rotateright;
            this.RotateBlueprintRight.Location = new System.Drawing.Point(203, 3);
            this.RotateBlueprintRight.Name = "RotateBlueprintRight";
            this.RotateBlueprintRight.Size = new System.Drawing.Size(31, 30);
            this.RotateBlueprintRight.TabIndex = 1;
            this.RotateBlueprintRight.Tag = new sbyte[] {
        ((sbyte)(0)),
        ((sbyte)(1))};
            this.RotateBlueprintRight.UseVisualStyleBackColor = true;
            this.RotateBlueprintRight.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // RotateBlueprintLeft
            // 
            this.RotateBlueprintLeft.AutoSize = true;
            this.RotateBlueprintLeft.Image = global::SchoolTycoon.Properties.Resources.rotateleft;
            this.RotateBlueprintLeft.Location = new System.Drawing.Point(6, 3);
            this.RotateBlueprintLeft.Name = "RotateBlueprintLeft";
            this.RotateBlueprintLeft.Size = new System.Drawing.Size(31, 30);
            this.RotateBlueprintLeft.TabIndex = 0;
            this.RotateBlueprintLeft.Tag = new sbyte[] {
        ((sbyte)(0)),
        ((sbyte)(-1))};
            this.RotateBlueprintLeft.UseVisualStyleBackColor = true;
            this.RotateBlueprintLeft.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // BuilderBlueprint
            // 
            this.BuilderBlueprint.ColumnCount = 5;
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.Location = new System.Drawing.Point(40, 3);
            this.BuilderBlueprint.Margin = new System.Windows.Forms.Padding(0);
            this.BuilderBlueprint.Name = "BuilderBlueprint";
            this.BuilderBlueprint.RowCount = 5;
            this.BuilderBlueprint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.Size = new System.Drawing.Size(160, 160);
            this.BuilderBlueprint.TabIndex = 1;
            // 
            // CBcancelButton
            // 
            this.CBcancelButton.Location = new System.Drawing.Point(120, 304);
            this.CBcancelButton.Name = "CBcancelButton";
            this.CBcancelButton.Size = new System.Drawing.Size(119, 35);
            this.CBcancelButton.TabIndex = 5;
            this.CBcancelButton.Text = "Cancel";
            this.CBcancelButton.UseVisualStyleBackColor = true;
            this.CBcancelButton.Click += new System.EventHandler(this.ExitClassroomBuilder);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(242, 342);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Inventory";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 130);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(242, 212);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 118);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(788, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "School Tycoon save files|*.sts";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "School Tycoon save files|*.sts";
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.White;
            this.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusPanel.Controls.Add(this.TeacherCount);
            this.StatusPanel.Controls.Add(this.label5);
            this.StatusPanel.Controls.Add(this.PupilCount);
            this.StatusPanel.Controls.Add(this.label3);
            this.StatusPanel.Controls.Add(this.CurrentDate);
            this.StatusPanel.Controls.Add(this.MoneyCount);
            this.StatusPanel.Controls.Add(this.label1);
            this.StatusPanel.Location = new System.Drawing.Point(0, 322);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(200, 70);
            this.StatusPanel.TabIndex = 3;
            // 
            // TeacherCount
            // 
            this.TeacherCount.AutoSize = true;
            this.TeacherCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.TeacherCount.ForeColor = System.Drawing.Color.Black;
            this.TeacherCount.Location = new System.Drawing.Point(84, 49);
            this.TeacherCount.Name = "TeacherCount";
            this.TeacherCount.Size = new System.Drawing.Size(15, 16);
            this.TeacherCount.TabIndex = 6;
            this.TeacherCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Teachers:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // PupilCount
            // 
            this.PupilCount.AutoSize = true;
            this.PupilCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.PupilCount.ForeColor = System.Drawing.Color.Black;
            this.PupilCount.Location = new System.Drawing.Point(84, 34);
            this.PupilCount.Name = "PupilCount";
            this.PupilCount.Size = new System.Drawing.Size(15, 16);
            this.PupilCount.TabIndex = 4;
            this.PupilCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pupils:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CurrentDate
            // 
            this.CurrentDate.AutoSize = true;
            this.CurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.CurrentDate.ForeColor = System.Drawing.Color.Black;
            this.CurrentDate.Location = new System.Drawing.Point(2, 2);
            this.CurrentDate.Name = "CurrentDate";
            this.CurrentDate.Size = new System.Drawing.Size(119, 16);
            this.CurrentDate.TabIndex = 2;
            this.CurrentDate.Text = "January 1st, year 1";
            this.CurrentDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MoneyCount
            // 
            this.MoneyCount.AutoSize = true;
            this.MoneyCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.MoneyCount.ForeColor = System.Drawing.Color.Black;
            this.MoneyCount.Location = new System.Drawing.Point(84, 18);
            this.MoneyCount.Name = "MoneyCount";
            this.MoneyCount.Size = new System.Drawing.Size(22, 16);
            this.MoneyCount.TabIndex = 1;
            this.MoneyCount.Text = "€0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Money:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 414);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "School Tycoon";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.standardTab.ResumeLayout(false);
            this.standardTab.PerformLayout();
            this.classroomBuilderTab.ResumeLayout(false);
            this.classroomBuilderTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip changeTile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classroomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nederlandsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage standardTab;
        private System.Windows.Forms.Button advanceDayButton;
        private System.Windows.Forms.TabPage classroomBuilderTab;
        private System.Windows.Forms.Label BlueprintBuildTime;
        private System.Windows.Forms.Label BlueprintPrice;
        private System.Windows.Forms.Button CBbuildButton;
        private System.Windows.Forms.Label BlueprintDescription;
        private System.Windows.Forms.Label BlueprintName;
        private System.Windows.Forms.Button NextBlueprint;
        private System.Windows.Forms.Button PreviousBlueprint;
        private System.Windows.Forms.Button RotateBlueprintRight;
        private System.Windows.Forms.Button RotateBlueprintLeft;
        private System.Windows.Forms.TableLayoutPanel BuilderBlueprint;
        private System.Windows.Forms.Button CBcancelButton;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label MoneyCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PupilCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CurrentDate;
        private System.Windows.Forms.Label TeacherCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OpenCBbutton;
        public System.Windows.Forms.TableLayoutPanel theGrid;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;


    }
}

