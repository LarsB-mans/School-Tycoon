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
            this.advanceDayButton = new System.Windows.Forms.Button();
            this.classroomBuilderTab = new System.Windows.Forms.TabPage();
            this.BlueprintPrice = new System.Windows.Forms.Label();
            this.CBbuildButton = new System.Windows.Forms.Button();
            this.BlueprintDescription = new System.Windows.Forms.Label();
            this.BlueprintName = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BuilderBlueprint = new System.Windows.Forms.TableLayoutPanel();
            this.CBcancelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.standardTab.SuspendLayout();
            this.classroomBuilderTab.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // classroomToolStripMenuItem
            // 
            this.classroomToolStripMenuItem.Name = "classroomToolStripMenuItem";
            this.classroomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.classroomToolStripMenuItem.Text = "Classroom";
            this.classroomToolStripMenuItem.Click += new System.EventHandler(this.classroomToolStripMenuItem_Click);
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
            this.englishToolStripMenuItem.Tag = "EN";
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
            // 
            // nederlandsToolStripMenuItem
            // 
            this.nederlandsToolStripMenuItem.Name = "nederlandsToolStripMenuItem";
            this.nederlandsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.nederlandsToolStripMenuItem.Tag = "NL";
            this.nederlandsToolStripMenuItem.Text = "Nederlands";
            this.nederlandsToolStripMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
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
            this.changeTile.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.changeTile_ItemClicked);
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
            this.theGrid.ColumnCount = 1;
            this.theGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.theGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theGrid.Location = new System.Drawing.Point(0, 0);
            this.theGrid.Margin = new System.Windows.Forms.Padding(0);
            this.theGrid.Name = "theGrid";
            this.theGrid.RowCount = 1;
            this.theGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.theGrid.Size = new System.Drawing.Size(534, 368);
            this.theGrid.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.standardTab);
            this.tabControl1.Controls.Add(this.classroomBuilderTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(250, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // standardTab
            // 
            this.standardTab.Controls.Add(this.advanceDayButton);
            this.standardTab.Location = new System.Drawing.Point(4, 22);
            this.standardTab.Name = "standardTab";
            this.standardTab.Padding = new System.Windows.Forms.Padding(3);
            this.standardTab.Size = new System.Drawing.Size(242, 342);
            this.standardTab.TabIndex = 0;
            this.standardTab.Text = "Standard";
            // 
            // advanceDayButton
            // 
            this.advanceDayButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.advanceDayButton.Location = new System.Drawing.Point(3, 294);
            this.advanceDayButton.Name = "advanceDayButton";
            this.advanceDayButton.Size = new System.Drawing.Size(236, 45);
            this.advanceDayButton.TabIndex = 0;
            this.advanceDayButton.Text = "Advance Day";
            this.advanceDayButton.UseVisualStyleBackColor = true;
            // 
            // classroomBuilderTab
            // 
            this.classroomBuilderTab.BackColor = System.Drawing.Color.White;
            this.classroomBuilderTab.Controls.Add(this.BlueprintPrice);
            this.classroomBuilderTab.Controls.Add(this.CBbuildButton);
            this.classroomBuilderTab.Controls.Add(this.BlueprintDescription);
            this.classroomBuilderTab.Controls.Add(this.BlueprintName);
            this.classroomBuilderTab.Controls.Add(this.button5);
            this.classroomBuilderTab.Controls.Add(this.button4);
            this.classroomBuilderTab.Controls.Add(this.button3);
            this.classroomBuilderTab.Controls.Add(this.button2);
            this.classroomBuilderTab.Controls.Add(this.BuilderBlueprint);
            this.classroomBuilderTab.Controls.Add(this.CBcancelButton);
            this.classroomBuilderTab.Location = new System.Drawing.Point(4, 22);
            this.classroomBuilderTab.Name = "classroomBuilderTab";
            this.classroomBuilderTab.Padding = new System.Windows.Forms.Padding(3);
            this.classroomBuilderTab.Size = new System.Drawing.Size(242, 342);
            this.classroomBuilderTab.TabIndex = 1;
            this.classroomBuilderTab.Text = "ClassroomBuilder";
            // 
            // BlueprintPrice
            // 
            this.BlueprintPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueprintPrice.Location = new System.Drawing.Point(6, 276);
            this.BlueprintPrice.Name = "BlueprintPrice";
            this.BlueprintPrice.Size = new System.Drawing.Size(230, 25);
            this.BlueprintPrice.TabIndex = 10;
            this.BlueprintPrice.Text = "Costs: €0,-";
            this.BlueprintPrice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // CBbuildButton
            // 
            this.CBbuildButton.Enabled = false;
            this.CBbuildButton.Location = new System.Drawing.Point(3, 304);
            this.CBbuildButton.Name = "CBbuildButton";
            this.CBbuildButton.Size = new System.Drawing.Size(115, 35);
            this.CBbuildButton.TabIndex = 9;
            this.CBbuildButton.Text = "Build";
            this.CBbuildButton.UseVisualStyleBackColor = true;
            this.CBbuildButton.Click += new System.EventHandler(this.CBbuildButton_Click);
            // 
            // BlueprintDescription
            // 
            this.BlueprintDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.BlueprintDescription.Location = new System.Drawing.Point(6, 184);
            this.BlueprintDescription.Name = "BlueprintDescription";
            this.BlueprintDescription.Size = new System.Drawing.Size(233, 92);
            this.BlueprintDescription.TabIndex = 8;
            this.BlueprintDescription.Text = "Blueprint Description";
            // 
            // BlueprintName
            // 
            this.BlueprintName.AutoSize = true;
            this.BlueprintName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.BlueprintName.Location = new System.Drawing.Point(3, 166);
            this.BlueprintName.Name = "BlueprintName";
            this.BlueprintName.Size = new System.Drawing.Size(153, 18);
            this.BlueprintName.TabIndex = 7;
            this.BlueprintName.Text = "< Blueprint Name >";
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Image = global::SchoolTycoon.Properties.Resources.next;
            this.button5.Location = new System.Drawing.Point(208, 39);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 124);
            this.button5.TabIndex = 6;
            this.button5.Tag = new sbyte[] {
        ((sbyte)(1)),
        ((sbyte)(-1))};
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Image = global::SchoolTycoon.Properties.Resources.previous;
            this.button4.Location = new System.Drawing.Point(3, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 124);
            this.button4.TabIndex = 5;
            this.button4.Tag = new sbyte[] {
        ((sbyte)(1)),
        ((sbyte)(-1))};
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Image = global::SchoolTycoon.Properties.Resources.rotateright;
            this.button3.Location = new System.Drawing.Point(208, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 30);
            this.button3.TabIndex = 4;
            this.button3.Tag = new sbyte[] {
        ((sbyte)(0)),
        ((sbyte)(1))};
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Image = global::SchoolTycoon.Properties.Resources.rotateleft;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 30);
            this.button2.TabIndex = 3;
            this.button2.Tag = new sbyte[] {
        ((sbyte)(0)),
        ((sbyte)(-1))};
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BlueprintButtons_Click);
            // 
            // BuilderBlueprint
            // 
            this.BuilderBlueprint.ColumnCount = 5;
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.BuilderBlueprint.Location = new System.Drawing.Point(41, 3);
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
            this.CBcancelButton.Location = new System.Drawing.Point(124, 304);
            this.CBcancelButton.Name = "CBcancelButton";
            this.CBcancelButton.Size = new System.Drawing.Size(115, 35);
            this.CBcancelButton.TabIndex = 0;
            this.CBcancelButton.Text = "Cancel";
            this.CBcancelButton.UseVisualStyleBackColor = true;
            this.CBcancelButton.Click += new System.EventHandler(this.switchToStandardTab);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(788, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "School Tycoon save files|*.sts";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "School Tycoon save files|*.sts";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 414);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "School Tycoon";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.standardTab.ResumeLayout(false);
            this.classroomBuilderTab.ResumeLayout(false);
            this.classroomBuilderTab.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        public System.Windows.Forms.TableLayoutPanel theGrid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage standardTab;
        private System.Windows.Forms.TabPage classroomBuilderTab;
        private System.Windows.Forms.Button advanceDayButton;
        private System.Windows.Forms.Button CBcancelButton;
        private System.Windows.Forms.TableLayoutPanel BuilderBlueprint;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label BlueprintName;
        private System.Windows.Forms.Label BlueprintDescription;
        private System.Windows.Forms.Button CBbuildButton;
        private System.Windows.Forms.Label BlueprintPrice;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nederlandsToolStripMenuItem;


    }
}

