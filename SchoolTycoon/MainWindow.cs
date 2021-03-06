﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SchoolTycoon
{
    public partial class MainWindow : Form
    {
        public uint DayNumber = 0;
        public byte[] MonthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        DateTime Date = new DateTime(1, 1, 1);
        public int Money = 0;

        public static TableLayoutPanelCellPosition selectedTile;
        public static int rowcount;
        public static int columncount;
        public static int tileSetNumber = 0;

        short[,] Schedule = new short[8,3];
        
        int SelectedClassroomValue = 0;

        static Random Random = new Random();
        List<Point> SpriteLocationData = new List<Point>();
        Point BuildLocation;

        List<short[]> Inventory = new List<short[]>();

        public static ResourceManager Language = new ResourceManager("SchoolTycoon.Languages.English", Assembly.GetExecutingAssembly());
        public CultureInfo Culture = CultureInfo.GetCultureInfo("en");

        public MainWindow()
        {
            LoadSprites();

            InitializeComponent();

            Image ItemIcons = Image.FromFile("Graphics\\items.png");
            ItemLargeIcons.Images.AddStrip(ItemIcons);
            ItemSmallIcons.Images.AddStrip(ItemIcons.GetThumbnailImage(ItemIcons.Width / 4, ItemIcons.Height / 4, null, IntPtr.Zero));
            for (int ItemNumber = 0; ItemNumber < ShopItems.Count(); ItemNumber++)
            {
                ShopItemList.Items.Add(Language.GetString(ShopItems[ItemNumber].NameResource), ItemNumber);
            }

            Image PeopleIcons = Image.FromFile("Graphics\\people.png");
            PeopleLargeIcons.Images.AddStrip(PeopleIcons);
            PeopleSmallIcons.Images.AddStrip(PeopleIcons.GetThumbnailImage(PeopleIcons.Width / 4, PeopleIcons.Height / 4, null, IntPtr.Zero));

            PrepareBlueprint();

            tabControl1.ItemSize = new Size(0, 0);  // hide tab selection from the sidebar
            tabControl1.Region = new Region(new Rectangle(StandardTab.Left, StandardTab.Top, StandardTab.Width, StandardTab.Height));

            LockGame(true);
            FillDebugMenu();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockGame(true);

            rowcount = 16;
            columncount = 16;
            InitializeGrid(columncount, rowcount);

            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 3; y++)
                    Schedule[x, y] = 0;

            Money = 1500;

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Maximum = rowcount * columncount;
            Refresh();
            for (int i = 0; i < rowcount; i++)
            {
                for (int j = 0; j < columncount; j++)
                {
                    PictureBox box = new PictureBox();
                    box.Margin = new Padding(0);
                    box.Click += new EventHandler(ClickTile);
                    box.Tag = new short[] { 0, 0 };
                    theGrid.Controls.Add(box);
                    toolStripProgressBar1.Value++;
                }
                theGrid.Controls.Add(new Control());        // add empty control so the tableLayoutPanel does not mess up
            }

            toolStripProgressBar1.Visible = false;
            toolStripProgressBar1.Value = 0;

            for (int i = 0; i < rowcount; i++)              // fill tilemap with grass
                for (int j = 0; j < columncount; j++)
                    changeTileImage(j, i, 1, 0);

            InitializePeople();

            int TotalSalary = 0;
            foreach (Teacher Teacher in Teachers)
                TotalSalary += Teacher.Salary;
            label14.Text = "Income: 500\n\rExpenses: " + TotalSalary;

            UpdateStatusWindow();
            LockGame(false);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return; // dummied out

            /*if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            FileStream savefile = new FileStream(saveFileDialog.FileName, FileMode.Create);

            BinaryWriter savewrite = new BinaryWriter(savefile);
            savewrite.Write(new char[] { 'S', 'T', 'S', 'F' });
            savewrite.Write((byte)rowcount);
            savewrite.Write((byte)columncount);

            #region save map data
            for (int i = 0; i < rowcount; i++)
                for (int j = 0; j < columncount; j++)
                {
                    short[] tileData = getTileData(j, i);
                    foreach (short s in tileData)
                        savewrite.Write(s);
                }
            #endregion

            #region save person data
            savewrite.Write(personData.Length);

            foreach (int[] person in personData)
            {
                foreach (int property in person)
                {
                    savewrite.Write(property);
                }
            }
            #endregion

            #region save checksum
            MD5 MD5 = new MD5CryptoServiceProvider();
            savefile.Position = 0;
            byte[] checksum = MD5.ComputeHash(savefile);
            savefile.Position = savefile.Length;
            savewrite.Write(checksum);
            #endregion

            savefile.Close();*/
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;

            /*if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            lockGame(true);
            
            byte[] buffer = File.ReadAllBytes(openFileDialog.FileName);
            
            FileStream savefile = new FileStream(openFileDialog.FileName, FileMode.Open);

            BinaryReader saveread = new BinaryReader(savefile);

            string identifier = new string(saveread.ReadChars(4));
            if (identifier != "STSF")
            {
                MessageBox.Show("File is not a valid School Tycoon save file.", "Save file loads of error!");
                savefile.Close();
                return;
            }

            #region checksum check
            MD5 MD5 = new MD5CryptoServiceProvider();
            if (!MD5.ComputeHash(buffer, 0, buffer.Length - 16).SequenceEqual(buffer.Skip(buffer.Length - 16).ToArray()))
            {
                MessageBox.Show("Save file is corrupted.", "Save file load error!");
                savefile.Close();
                return;
            }
            #endregion

            #region load map data
            rowcount = saveread.ReadByte();
            columncount = saveread.ReadByte();

            InitializeGrid(columncount, rowcount);

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = rowcount * columncount;
            Refresh();

            for (int i = 0; i < rowcount; i++)              // fill the grid with empty
            {
                for (int j = 0; j < columncount; j++)
                {
                    PictureBox box = new PictureBox();
                    box.Margin = new Padding(0);
                    box.Click += new EventHandler(box_Click);
                    theGrid.Controls.Add(box);
                    toolStripProgressBar1.Value++;
                }
                theGrid.Controls.Add(new Control());        // add empty control so the tableLayoutPanel does not mess up
            }

            for (int i = 0; i < rowcount; i++)              // load tile data
                for (int j = 0; j < columncount; j++)
                {
                    changeTileImage(j, i, saveread.ReadInt16(), saveread.ReadInt16());
                }
            #endregion

            #region load person data
            int personcount = saveread.ReadInt32();
            personData = new int[personcount][];
            for (int i = 0; i < personcount; i++)       // for each person
            {
                personData[i] = new int[4];             // generate person data
                for (int j = 0; j < 4; j++)
                    personData[i][j] = saveread.ReadInt32();
            }

            foreach (int[] data in personData)
            {
                PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(data[2], data[3]);
                tile.Image = People.GFX[data[0]][data[1]];
            }
            #endregion

            savefile.Close();
            lockGame(false);*/
        }

        private void advanceWeekButton_Click(object sender, EventArgs e)
        {
            if (Classrooms.Count == 0)
            {
                MessageBox.Show("You must create a schedule first!");
                return;
            }

            Date = Date.AddDays(7);
            DayNumber++;
            Money += 500;
            UpdateStatusWindow();

            CheckBuildClassrooms();

            List<Event> RemovedEvents = new List<Event>();
            foreach (Event Event in TimeLine)
            {
                if (Event.DateTime >= Date)
                {
                    switch (Event.EventType)
                    {
                        default:
                            break;
                    }
                    RemovedEvents.Add(Event);
                }
            }
            foreach (Event RemoveEvent in RemovedEvents)
                TimeLine.Remove(RemoveEvent);

            //
            int TotalScheduleHours = Schedule[0, 2] + Schedule[1, 2] + Schedule[2, 2] + Schedule[3, 2] + Schedule[4, 2] + Schedule[5, 2] + Schedule[6, 2] + Schedule[7, 2];

            for (int PersonNumber = 0; PersonNumber < Pupils.Count; PersonNumber++)
            {
                Pupil Person = Pupils[PersonNumber];

                if (TotalScheduleHours > 30)
                    Person.Happiness -= (TotalScheduleHours - 30) * 2;
                else
                    Person.Happiness += 5;

                for (int Subject = 0; Subject < 8; Subject++)
                {
                    Person.Happiness += Teachers[Schedule[Subject, 0]].FunFactor * Schedule[Subject, 2];
                    switch (Classrooms[Schedule[Subject, 1]].RoomType)
                    {
                        case RoomType.ClassroomSmall:
                            Person.Happiness += 0;
                            break;
                        case RoomType.ClassroomMedium:
                            Person.Happiness += 2;
                            break;
                        case RoomType.ClassroomLarge:
                            Person.Happiness += 5;
                            break;
                    }
                    Person.Happiness += Classrooms[Schedule[Subject, 1]].Blackboard.Data * Schedule[Subject, 2];
                }

                Person.Happiness += Person.Intelligence + Person.Motivation * 9 / 10;

                if (Person.Happiness > 1000)
                    Person.Happiness = 1000;
                if (Person.Happiness < 0)
                    Person.Happiness = 0;

                Pupils[PersonNumber] = Person;
            }
            //

            foreach (Teacher Teacher in Teachers)
                Money -= Teacher.Salary;

            int AverageHappiness = 0;
            foreach (Pupil Person in Pupils)
                AverageHappiness += Person.Happiness;
            AverageHappiness /= Pupils.Count;
            progressBar1.Value = AverageHappiness > progressBar1.Maximum ? progressBar1.Maximum : AverageHappiness;
            label10.Text = "Average Happiness: " + progressBar1.Value * 100 / progressBar1.Maximum + "%";

        }
        private void CheckBuildClassrooms()
        {
            Classroom Classroom;
            for (int ClassroomNumber = 0; ClassroomNumber < Classrooms.Count; ClassroomNumber++)
            {
                Classroom = Classrooms[ClassroomNumber];

                Classroom.DaysToBuild -= 7;
                if (Classroom.DaysToBuild <= 0)
                    for (int LocationNumber = 0; LocationNumber < Classroom.Locations.Count(); LocationNumber++)
                        changeTileImage(Classroom.Locations[LocationNumber].X, Classroom.Locations[LocationNumber].Y, Classroom.TileData[LocationNumber][0], Classroom.TileData[LocationNumber][1]);

                Classrooms[ClassroomNumber] = Classroom;
            }
        }

        public void InitializeGrid(int columncount, int rowcount)
        {
            theGrid.Controls.Clear();
            theGrid.RowStyles.Clear();
            theGrid.RowCount = rowcount + 1;
            for (int i = 0; i < rowcount; i++)
                theGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 16));
            theGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            theGrid.ColumnStyles.Clear();
            theGrid.ColumnCount = columncount + 1;
            for (int i = 0; i < columncount; i++)
                theGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16));
            theGrid.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            if (theGrid.HorizontalScroll.Visible)
                StatusPanel.Top = 322 - 17;
            else
                StatusPanel.Top = 322;
        }

        private void LockGame(bool lockstatus)
        {
            lockstatus = !lockstatus;
            saveToolStripMenuItem.Enabled = lockstatus;
            splitContainer1.Enabled = lockstatus;
        }
        private void FillDebugMenu()
        {
            changeTile.Items.Add(BlockTypes[0][0].Name, BlockTypes[0][0].Tile);

            int blockCount = BlockTypes.Count();
            for (int i = 0; i < BlockTypes.Count(); i++)
            {
                changeTile.Items.Add(BlockTypes[i][0].Name, BlockTypes[i][0].Tile);
                changeTile.Items[changeTile.Items.Count - 1].Tag = i;
            }
        }
        private void ClickTile(object sender, EventArgs e)
        {
            selectedTile = theGrid.GetPositionFromControl(((Control)sender));
            Point TileLocation = new Point(selectedTile.Column, selectedTile.Row);
            short[] TileData = getTileData(selectedTile.Column, selectedTile.Row);
            switch (tabControl1.SelectedTab.Name)
            {
                case "StandardTab":
                case "ClassroomViewer":
                    if (TileData[0] != 5)   // not a classroom
                        break;

                    SelectedClassroomValue = -1;

                    for (int ClassroomNumber = 0; ClassroomNumber < Classrooms.Count; ClassroomNumber++)
                        foreach (Point Location in Classrooms[ClassroomNumber].Locations)
                            if (Location == TileLocation)
                                SelectedClassroomValue = ClassroomNumber;

                    if (SelectedClassroomValue == -1)
                        MessageBox.Show("Selected classroom has no data!");
                    else
                        OpenClassroom(SelectedClassroomValue);

                    break;
                case "DebugMenu":
                    changeTile.Show(Cursor.Position);
                    break;
                case "BuilderTab":
                    #region
                    if (BuilderRelPoints == null)
                        break;
                    //if (Blueprints[SelectedBlueprint, Rotation].Price > Money)
                    //    break;

                    clearSprites();
                    bool CanBuild = true;

                    foreach (Point RelPoint in BuilderRelPoints)
                    {
                        if (selectedTile.Column + RelPoint.X >= columncount || selectedTile.Column + RelPoint.X < 0 || selectedTile.Row + RelPoint.Y >= rowcount || selectedTile.Row + RelPoint.Y < 0)
                        {
                            CanBuild = false;
                            continue;
                        }
                        TileData = getTileData(selectedTile.Column + RelPoint.X, selectedTile.Row + RelPoint.Y);
                        if (!BlockTypes[TileData[0]][TileData[1]].Buildable)
                            CanBuild = false;
                    }
                    Sprite sprite = CanBuild ? Sprite.BlueprintGreen : Sprite.BlueprintRed;
                    foreach (Point RelPoint in BuilderRelPoints)
                    {
                        if (selectedTile.Column + RelPoint.X >= columncount || selectedTile.Column + RelPoint.X < 0 || selectedTile.Row + RelPoint.Y >= rowcount || selectedTile.Row + RelPoint.Y < 0)
                            continue;

                        setSprite(selectedTile.Column + RelPoint.X, selectedTile.Row + RelPoint.Y, sprite);
                    }
                    BuildLocation = new Point(selectedTile.Column, selectedTile.Row);
                    CBbuildButton.Enabled = CanBuild;
                    break;
                    #endregion
                case "InventoryTab":
                    SelectedClassroomValue = -1;

                    clearSprites();
                    if (TileData[0] != 5)   // not a classroom
                    {
                        button6.Enabled = false;
                        setSprite(selectedTile.Column, selectedTile.Row, Sprite.BlueprintRed);
                        break;
                    }

                    button6.Enabled = InventoryViewer.SelectedItems.Count != 0;

                    for (int ClassroomNumber = 0; ClassroomNumber < Classrooms.Count; ClassroomNumber++)
                        foreach (Point Location in Classrooms[ClassroomNumber].Locations)
                            if (Location == TileLocation)
                                SelectedClassroomValue = ClassroomNumber;

                    if (SelectedClassroomValue == -1)
                    {
                        button6.Enabled = false;
                        setSprite(selectedTile.Column, selectedTile.Row, Sprite.BlueprintRed);
                        MessageBox.Show("Selected classroom has no data!");
                    }
                    else
                    {
                        button6.Enabled = InventoryViewer.SelectedItems.Count != 0;
                        setSprite(selectedTile.Column, selectedTile.Row, Sprite.BlueprintGreen);
                    }

                    break;
                default:
                    break;
            }
        }
        private void BlueprintButtons_Click(object sender, EventArgs e)
        {
            sbyte[] ButtonData = (sbyte[])((Button)sender).Tag;
            switch (ButtonData[0])
            {
                case 0:
                    Rotation += ButtonData[1];
                    if (Rotation == -1)
                        Rotation = 3;
                    if (Rotation == 4)
                        Rotation = 0;
                    break;
                case 1:
                    int BlueprintCount = Blueprints.GetLength(0);
                    SelectedBlueprint += ButtonData[1];
                    if (SelectedBlueprint == -1)
                        SelectedBlueprint = BlueprintCount - 1;
                    if (SelectedBlueprint == BlueprintCount)
                        SelectedBlueprint = 0;
                    break;
            }
            clearSprites();
            MakeBlueprint(SelectedBlueprint, Rotation);
        }

        private void DebugTileChange(object sender, ToolStripItemClickedEventArgs e)
        {
            int column = selectedTile.Column;
            int row = selectedTile.Row;
            short tiletype = Convert.ToInt16(e.ClickedItem.Tag);
            short tilevalue = 0;
            switch (tiletype)
            {
                default:
                    if (BlockTypes[tiletype][tilevalue].Walled == true)
                        tilevalue = GetEnclosureValue(new Point(column, row));
                    changeTileImage(column, row, tiletype, tilevalue);
                    FixWalls(column, row);
                    break;
            }

            changeTile.Items[0].Text = BlockTypes[tiletype][0].Name;
            changeTile.Items[0].Image = BlockTypes[tiletype][0].Tile;
            changeTile.Items[0].Tag = tiletype;
        }
        private void FixWalls(int column, int row)
        {
            short[] tiledata;
            short tilevalue;

            if (column > 0 && row > 0)
            {
                tiledata = getTileData(column - 1, row - 1);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column - 1, row - 1));
                    changeTileImage(column - 1, row - 1, tiledata[0], tilevalue);
                }
            }

            if (row > 0)
            {
                tiledata = getTileData(column, row - 1);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column, row - 1));
                    changeTileImage(column, row - 1, tiledata[0], tilevalue);
                }
            }

            if (column < columncount - 1 && row > 0)
            {
                tiledata = getTileData(column + 1, row - 1);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column + 1, row - 1));
                    changeTileImage(column + 1, row - 1, tiledata[0], tilevalue);
                }
            }

            if (column > 0)
            {
                tiledata = getTileData(column - 1, row);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column - 1, row));
                    changeTileImage(column - 1, row, tiledata[0], tilevalue);
                }
            }

            if (column < columncount - 1)
            {
                tiledata = getTileData(column + 1, row);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column + 1, row));
                    changeTileImage(column + 1, row, tiledata[0], tilevalue);
                }
            }

            if (column > 0 && row < rowcount - 1)
            {
                tiledata = getTileData(column - 1, row + 1);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column - 1, row + 1));
                    changeTileImage(column - 1, row + 1, tiledata[0], tilevalue);
                }
            }

            if (row < rowcount - 1)
            {
                tiledata = getTileData(column, row + 1);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column, row + 1));
                    changeTileImage(column, row + 1, tiledata[0], tilevalue);
                }
            }

            if (column < columncount - 1 && row < rowcount - 1)
            {
                tiledata = getTileData(column + 1, row + 1);
                if (BlockTypes[tiledata[0]][tiledata[1]].Walled)
                {
                    tilevalue = GetEnclosureValue(new Point(column + 1, row + 1));
                    changeTileImage(column + 1, row + 1, tiledata[0], tilevalue);
                }
            }
        }
        private void changeTileImage(int column, int row, short tiletype, short tilevalue)
        {
            PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(column, row);
            tile.Tag = new short[] { tiletype, tilevalue };
            tile.BackgroundImage = BlockTypes[tiletype][tilevalue].Tile;
        }
        private void clearSprites()
        {
            PictureBox tile;
            foreach (Point point in SpriteLocationData)
            {
                tile = (PictureBox)theGrid.GetControlFromPosition(point.X, point.Y);
                tile.Image = null;
            }
        }
        private void setSprite(int column, int row, Sprite sprite)
        {
            PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(column, row);
            tile.Image = Sprites[(int)sprite];
            SpriteLocationData.Add(new Point(column, row));
        }
        private short[] getTileData(int column, int row)
        {
            PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(column, row);
            return (short[])tile.Tag;
        }

        private void OpenClassroomBuilder(object sender, EventArgs e)
        {
            MakeBlueprint(SelectedBlueprint, Rotation);
            numericUpDown10.Value = 0;
            tabControl1.SelectedTab = BuilderTab;
        }
        private void OpenInventory(object sender, EventArgs e)
        {
            clearSprites();
            button6.Enabled = false;
            SelectedClassroomValue = -1;

            InventoryViewer.Items.Clear();
            for (int ItemNumber = 0; ItemNumber < Inventory.Count; ItemNumber++)
                InventoryViewer.Items.Add(Inventory[ItemNumber][1] + "x " + Language.GetString(ShopItems[Inventory[ItemNumber][0]].NameResource), Inventory[ItemNumber][0]);

            pictureBox1.Visible = false;
            label16.Visible = false;
            label15.Visible = false;
            label12.Visible = false;
            label11.Visible = false;

            tabControl1.SelectedTab = InventoryTab;
        }
        private void OpenShop(object sender, EventArgs e)
        {
            ShopItemList.Items[0].Selected = true;
            tabControl1.SelectedTab = tabPage2;
        }
        private void OpenSchedule(object sender, EventArgs e)
        {
            if (Classrooms.Count == 0)
            {
                MessageBox.Show("You have no classrooms!");
                return;
            }

            for (int ClassNumber = 0; ClassNumber < AmountOfClasses; ClassNumber++)
                ClassList.Items.Add("Class " + ClassNumber);
            ClassList.SelectedIndex = 0;

            #region Fill Teacher comboboxes
            comboBox9.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Biology))
                    comboBox9.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox9.SelectedIndex = Schedule[0, 0];

            comboBox1.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Chemistry))
                    comboBox1.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox1.SelectedIndex = Schedule[1, 0];

            comboBox3.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Economics))
                    comboBox3.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox3.SelectedIndex = Schedule[2, 0];

            comboBox4.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Geography))
                    comboBox4.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox4.SelectedIndex = Schedule[3, 0];

            comboBox5.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.History))
                    comboBox5.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox5.SelectedIndex = Schedule[4, 0];

            comboBox6.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Language))
                    comboBox6.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox6.SelectedIndex = Schedule[5, 0];

            comboBox7.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Maths))
                    comboBox7.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox7.SelectedIndex = Schedule[6, 0];

            comboBox8.Items.Clear();
            foreach (Teacher Teacher in Teachers)
                if (Teacher.Subjects.Contains(Subject.Physics))
                    comboBox8.Items.Add(Teacher.FirstName[0] + ". " + Teacher.LastName);
            comboBox8.SelectedIndex = Schedule[7, 0];
            #endregion

            #region Fill Classroom comboboxes
            comboBox10.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox10.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox10.SelectedIndex = Schedule[0, 1];

            comboBox2.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox2.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox2.SelectedIndex = Schedule[1, 1];

            comboBox11.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox11.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox11.SelectedIndex = Schedule[2, 1];

            comboBox12.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox12.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox12.SelectedIndex = Schedule[3, 1];

            comboBox13.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox13.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox13.SelectedIndex = Schedule[4, 1];

            comboBox14.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox14.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox14.SelectedIndex = Schedule[5, 1];
            
            comboBox15.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox15.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox15.SelectedIndex = Schedule[6, 1];

            comboBox16.Items.Clear();
            foreach (Classroom Classroom in Classrooms)
                comboBox16.Items.Add(Classroom.Number.ToString().PadLeft(3, '0'));
            comboBox16.SelectedIndex = Schedule[7, 1];
            #endregion

            numericUpDown2.Value = Schedule[0, 2];
            numericUpDown3.Value = Schedule[0, 2];
            numericUpDown4.Value = Schedule[0, 2];
            numericUpDown5.Value = Schedule[0, 2];
            numericUpDown6.Value = Schedule[0, 2];
            numericUpDown7.Value = Schedule[0, 2];
            numericUpDown8.Value = Schedule[0, 2];
            numericUpDown9.Value = Schedule[0, 2];

            tabControl1.SelectedTab = tabPage3;
        }
        private void OpenPupils(object sender, EventArgs e)
        {
            TreeNode[] PupilList = new TreeNode[AmountOfClasses];
            for (int ClassNumber = 0; ClassNumber < AmountOfClasses; ClassNumber++)
                PupilList[ClassNumber] = new TreeNode("Class " + (ClassNumber + 1));

            int PupilID = 0;
            foreach (Pupil Pupil in Pupils)
            {
                TreeNode PupilNode = new TreeNode(Pupil.FirstName + " " + Pupil.LastName, (int)Pupil.Gender + 1, (int)Pupil.Gender + 1);
                PupilNode.Tag = PupilID++;
                PupilList[Pupil.Class].Nodes.Add(PupilNode);
            }

            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(PupilList);

            tabControl1.SelectedTab = tabPage4;
        }
        private void OpenDebugMenu(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = DebugMenu;
        }
        private void OpenClassroom(int ClassroomValue)
        {
            SelectedClassroomValue = ClassroomValue;
            Classroom Classroom = Classrooms[ClassroomValue];

            Point Location = Classroom.Locations[0];

            for (int y = 0; y < 5; y++)
                for (int x = 0; x < 5; x++)
                {
                    PictureBox PreviewTile = (PictureBox)tableLayoutPanel1.GetControlFromPosition(x, y);

                    if (Location.X + x - 2 < 0 || Location.Y + y - 2 < 0)
                        PreviewTile.Image = BlockTypes[0][0].Tile;
                    else
                        PreviewTile.Image = ((PictureBox)theGrid.GetControlFromPosition(Location.X + x - 2, Location.Y + y - 2)).BackgroundImage;
                }

            label34.Text = "Classroom " + Classroom.Number.ToString("D3");
            numericUpDown11.Value = Classroom.Number;

            if (Classroom.Blackboard.ItemID != -1)
            {
                pictureBox29.Image = ItemLargeIcons.Images[Classroom.Blackboard.ItemID];
                button15.Enabled = true;
            }
            else
            {
                pictureBox29.Image = new Bitmap(64, 64);
                button15.Enabled = false;
            }

            label42.Text = Language.GetString(Classroom.Blackboard.NameResource);
            label41.Text = Language.GetString(Classroom.Blackboard.DescriptionResource);

            tabControl1.SelectedTab = ClassroomViewer;
        }
        private void ExitToMainScreen(object sender, EventArgs e)
        {
            clearSprites();
            CBbuildButton.Enabled = false;
            tabControl1.SelectedTab = StandardTab;
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = false;
            nederlandsToolStripMenuItem.Checked = false;

            switch ((string)((ToolStripMenuItem)sender).Tag)
            {
                default:
                case "en":
                    englishToolStripMenuItem.Checked = true;
                    Language = new ResourceManager("SchoolTycoon.Languages.English", Assembly.GetExecutingAssembly());
                    break;
                case "nl":
                    nederlandsToolStripMenuItem.Checked = true;
                    Language = new ResourceManager("SchoolTycoon.Languages.Nederlands", Assembly.GetExecutingAssembly());
                    break;
            }

            Culture = CultureInfo.GetCultureInfo((string)((ToolStripMenuItem)sender).Tag);

            MakeBlueprint(SelectedBlueprint, Rotation);
            UpdateStatusWindow();
        }
        private string NumberSuffix(int Number, bool SuffixOnly)
        {
            string ReturnString;

            switch (Number % 100)
            {
                case 11:
                case 12:
                case 13:
                    ReturnString = "th";
                    break;
                default:
                    switch (Number % 10)
                    {
                        case 1:
                            ReturnString = "st";
                            break;
                        case 2:
                            ReturnString = "nd";
                            break;
                        case 3:
                            ReturnString = "rd";
                            break;
                        default:
                            ReturnString = "th";
                            break;
                    }
                    break;
            }

            if (!SuffixOnly)
                ReturnString = Number + ReturnString;
            return ReturnString;
        }

        private void UpdateStatusWindow()
        {
            MoneyCount.Text = "€" + Math.Abs(Money).ToString("N0", Culture.NumberFormat);
            if (Money >= 0)
            {
                MoneyCount.Font = new Font(MoneyCount.Font, FontStyle.Regular);
                MoneyCount.ForeColor = Color.Black;
            }
            else
            {
                MoneyCount.Font = new Font(MoneyCount.Font, FontStyle.Bold);
                MoneyCount.ForeColor = Color.Red;
                MoneyCount.Text = "−" + MoneyCount.Text;
            }

            PupilCount.Text = 0.ToString("N0", Culture.NumberFormat);
            TeacherCount.Text = 0.ToString("N0", Culture.NumberFormat);

            CurrentDate.Text = String.Format(Language.GetString("DateFormat"), Culture.DateTimeFormat.GetMonthName(Date.Month), Date.Day, NumberSuffix(Date.Day, true), Date.Year);
        }

        private void ShopItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShopItemList.SelectedItems.Count == 0)
                return;

            label2.Text = Language.GetString(ShopItems[ShopItemList.SelectedIndices[0]].NameResource);
            label4.Text = Language.GetString(ShopItems[ShopItemList.SelectedIndices[0]].DescriptionResource);
            label7.Text = "€" + ShopItems[ShopItemList.SelectedIndices[0]].Price;

            ItemToFind = (short)ShopItemList.SelectedIndices[0];
            int InventoryIndex = Inventory.FindIndex(FindItem);

            if (InventoryIndex == -1)
                label9.Text = "0";
            else
                label9.Text = Inventory[InventoryIndex][1].ToString();

            if (Money >= ShopItems[ShopItemList.SelectedIndices[0]].Price)
            {
                label7.ForeColor = Color.Black;
            }
            else
            {
                label7.ForeColor = Color.Red;
            }
            if (ShopItems[ShopItemList.SelectedIndices[0]].ItemID != -1)
                pictureBox2.Image = ItemLargeIcons.Images[ShopItems[ShopItemList.SelectedIndices[0]].ItemID].GetThumbnailImage(64, 64, null, IntPtr.Zero);
            else
                pictureBox2.Image = new Bitmap(64, 64);

            numericUpDown1.Value = 1;
            ShopItemCountChanged(null, null);
        }
        private void BuyItem(object sender, EventArgs e)
        {
            if (ShopItemList.SelectedItems.Count == 0)
                return;

            Money -= ShopItems[ShopItemList.SelectedIndices[0]].Price * (int)numericUpDown1.Value;

            AddItem((short)ShopItemList.SelectedIndices[0], (short)numericUpDown1.Value);

            ShopItemList_SelectedIndexChanged(null, null);
            UpdateStatusWindow();
        }

        private void AddItem(short ItemValue, short AddAmount)
        {
            ItemToFind = ItemValue;
            int InventoryIndex = Inventory.FindIndex(FindItem);

            if (InventoryIndex == -1)
                Inventory.Add(new short[] { (short)ItemToFind, (short)numericUpDown1.Value });
            else
                Inventory[InventoryIndex][1] += (short)numericUpDown1.Value;
        }
        private bool RemoveItem(short ItemValue, short RemoveAmount)
        {
            ItemToFind = ItemValue;
            int InventoryIndex = Inventory.FindIndex(FindItem);

            if (Inventory[InventoryIndex][1] == 1)
            {
                Inventory.RemoveAt(InventoryIndex);
                return true;
            }
            else
            {
                Inventory[InventoryIndex][1]--;
                return false;
            }
        }
        short ItemToFind = 0;
        private bool FindItem(short[] Item)
        {
            return Item[0] == ItemToFind;
        }
        private void InventoryViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InventoryViewer.SelectedItems.Count == 0)
            {
                button6.Enabled = false;
                return;
            }

            button6.Enabled = SelectedClassroomValue != -1;

            label16.Text = Language.GetString(ShopItems[Inventory[InventoryViewer.SelectedIndices[0]][0]].NameResource);
            label15.Text = Language.GetString(ShopItems[Inventory[InventoryViewer.SelectedIndices[0]][0]].DescriptionResource);
            label11.Text = Inventory[InventoryViewer.SelectedIndices[0]][1].ToString();
            pictureBox1.Image = ItemLargeIcons.Images[InventoryViewer.SelectedItems[0].ImageIndex].GetThumbnailImage(64, 64, null, IntPtr.Zero);

            pictureBox1.Visible = true;
            label16.Visible = true;
            label15.Visible = true;
            label12.Visible = true;
            label11.Visible = true;
        }
        private void ShopItemCountChanged(object sender, EventArgs e)
        {
            int Price = ShopItems[ShopItemList.SelectedIndices[0]].Price * (int)numericUpDown1.Value;
            label13.Text = "€" + Price;
            if (Money >= Price)
                label13.ForeColor = Color.Black;
            else
                label13.ForeColor = Color.Red;
        }

        private void ChangeHours(object sender, EventArgs e)
        {
            label25.Text = "Total hours: " + (numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value + numericUpDown5.Value + numericUpDown6.Value + numericUpDown7.Value + numericUpDown8.Value + numericUpDown9.Value);
        }
        private void ChangeClassroomNumber(object sender, EventArgs e)
        {
            label34.Text = "Classroom " + numericUpDown11.Value.ToString().PadLeft(3, '0');

            Classroom Classroom = Classrooms[SelectedClassroomValue];
            Classroom.Number = (short)numericUpDown11.Value;
            Classrooms[SelectedClassroomValue] = Classroom;
        }
        private void TakeBlackboard(object sender, EventArgs e)
        {
            Classroom Classroom = Classrooms[SelectedClassroomValue];

            AddItem(Classroom.Blackboard.ItemID, 1);
            Classroom.Blackboard = new ShopItem("NoBlackboardName", "NoBlackboardDescription", -1, 0, -10);

            Classrooms[SelectedClassroomValue] = Classroom;
            OpenClassroom(SelectedClassroomValue);
        }
        private void UseItem(object sender, EventArgs e)
        {
            Classroom Classroom = Classrooms[SelectedClassroomValue];

            if (Classroom.Blackboard.ItemID != -1)
            {
                MessageBox.Show("This classroom already has a blackboard. Remove it before adding a new one.");
                return;
            }

            Classroom.Blackboard = ShopItems[Inventory[InventoryViewer.SelectedIndices[0]][0]];
            Classrooms[SelectedClassroomValue] = Classroom;

            RemoveItem(Inventory[InventoryViewer.SelectedIndices[0]][0], 1);

            OpenInventory(null, null);
        }

        private void CreateSchedule(object sender, EventArgs e)
        {
            Schedule[0, 0] = (short)comboBox9.SelectedIndex;
            Schedule[1, 0] = (short)comboBox1.SelectedIndex;
            Schedule[2, 0] = (short)comboBox3.SelectedIndex;
            Schedule[3, 0] = (short)comboBox4.SelectedIndex;
            Schedule[4, 0] = (short)comboBox5.SelectedIndex;
            Schedule[5, 0] = (short)comboBox6.SelectedIndex;
            Schedule[6, 0] = (short)comboBox7.SelectedIndex;
            Schedule[7, 0] = (short)comboBox8.SelectedIndex;

            Schedule[0, 1] = (short)comboBox10.SelectedIndex;
            Schedule[1, 1] = (short)comboBox2.SelectedIndex;
            Schedule[2, 1] = (short)comboBox11.SelectedIndex;
            Schedule[3, 1] = (short)comboBox12.SelectedIndex;
            Schedule[4, 1] = (short)comboBox13.SelectedIndex;
            Schedule[5, 1] = (short)comboBox14.SelectedIndex;
            Schedule[6, 1] = (short)comboBox15.SelectedIndex;
            Schedule[7, 1] = (short)comboBox16.SelectedIndex;

            Schedule[0, 2] = (short)numericUpDown2.Value;
            Schedule[1, 2] = (short)numericUpDown3.Value;
            Schedule[2, 2] = (short)numericUpDown4.Value;
            Schedule[3, 2] = (short)numericUpDown5.Value;
            Schedule[4, 2] = (short)numericUpDown6.Value;
            Schedule[5, 2] = (short)numericUpDown7.Value;
            Schedule[6, 2] = (short)numericUpDown8.Value;
            Schedule[7, 2] = (short)numericUpDown9.Value;

            ExitToMainScreen(null, null);
        }
    }
}