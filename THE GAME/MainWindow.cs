using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public static TableLayoutPanelCellPosition selectedTile;
        public static int rowcount;
        public static int columncount;
        public static int tileSetNumber = 0;

        List<Person> Persons;
        List<Point> SpriteLocationData = new List<Point>();
        Point BuildLocation;

        public enum Sidebars { Main, ClassroomBuilder };

        public MainWindow()
        {
            loadPeopleGraphics();
            LoadSprites();

            InitializeComponent();

            PrepareBlueprint();

            tabControl1.ItemSize = new Size(0, 0);  // hide tab selection from the sidebar
            tabControl1.Region = new Region(new Rectangle(standardTab.Left, standardTab.Top, standardTab.Width, standardTab.Height));

            lockGame(true);
            fillDebugMenu();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockGame(true);

            rowcount = 16;
            columncount = 16;
            InitializeGrid(columncount, rowcount);

            #region generate an empty grid
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = rowcount * columncount;
            Refresh();
            for (int i = 0; i < rowcount; i++)
            {
                for (int j = 0; j < columncount; j++)
                {
                    PictureBox box = new PictureBox();
                    box.Margin = new Padding(0);
                    box.Click += new EventHandler(box_Click);
                    box.Tag = new short[] { 0, 0 };
                    theGrid.Controls.Add(box);
                    toolStripProgressBar1.Value++;
                }
                theGrid.Controls.Add(new Control());        // add empty control so the tableLayoutPanel does not mess up
            }

            for (int i = 0; i < rowcount; i++)              // fill tilemap with grass
                for (int j = 0; j < columncount; j++)
                    changeTileImage(j, i, 1, 0);
            #endregion

            InitializePeople();
            lockGame(false);
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

        public void InitializeGrid(int columncount, int rowcount)
        {
            theGrid.Controls.Clear();
            theGrid.RowStyles.Clear();
            theGrid.RowCount = rowcount + 1;
            for (int i = 0; i < rowcount; i++)
                theGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));

            theGrid.ColumnStyles.Clear();
            theGrid.ColumnCount = columncount + 1;
            for (int i = 0; i < columncount; i++)
                theGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
        }
        public void InitializePeople()
        {
            Persons = new List<Person>();
            Persons.Add(new Person(Gender.Male, Type.Pupil, 100));
        }

        private void lockGame(bool lockstatus)
        {
            lockstatus = !lockstatus;
            saveToolStripMenuItem.Enabled = lockstatus;
            splitContainer1.Enabled = lockstatus;
        }
        private void fillDebugMenu()
        {
            int blockCount = BlockTypes.Count();
            for (int i = 0; i < BlockTypes.Count(); i++)
            {
                changeTile.Items.Add(i.ToString());
                changeTile.Items[changeTile.Items.Count - 1].Tag = i;
            }
        }
        private void box_Click(object sender, EventArgs e)
        {
            selectedTile = theGrid.GetPositionFromControl(((Control)sender));
            short[] TileData = getTileData(selectedTile.Column, selectedTile.Row);
            switch ((Sidebars)tabControl1.SelectedIndex)
            {
                case Sidebars.Main:
                    changeTile.Show(Cursor.Position);
                    break;
                case Sidebars.ClassroomBuilder:
                    if (BuilderRelPoints == null)
                        break;

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
                    Sprite sprite = CanBuild ? Sprite.BlueprintBlue : Sprite.BlueprintRed;
                    foreach (Point RelPoint in BuilderRelPoints)
                    {
                        if (selectedTile.Column + RelPoint.X >= columncount || selectedTile.Column + RelPoint.X < 0 || selectedTile.Row + RelPoint.Y >= rowcount || selectedTile.Row + RelPoint.Y < 0)
                            continue;

                        setSprite(selectedTile.Column + RelPoint.X, selectedTile.Row + RelPoint.Y, sprite);
                    }
                    BuildLocation = new Point(selectedTile.Column, selectedTile.Row);
                    CBbuildButton.Enabled = CanBuild;
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

        private void changeTile_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filename = e.ClickedItem.Text;
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

        private void switchToStandardTab(object sender, EventArgs e)
        {
            clearSprites();
            CBbuildButton.Enabled = false;
            tabControl1.SelectedTab = standardTab;
        }
        private void classroomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = classroomBuilderTab;
            MakeBlueprint(SelectedBlueprint, Rotation);
        }
        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = false;
            nederlandsToolStripMenuItem.Checked = false;

            switch ((string)((ToolStripMenuItem)sender).Tag)
            {
                case "EN":
                    englishToolStripMenuItem.Checked = true;
                    Language = new ResourceManager("SchoolTycoon.Languages.English", Assembly.GetExecutingAssembly());
                    break;
                case "NL":
                    nederlandsToolStripMenuItem.Checked = true;
                    Language = new ResourceManager("SchoolTycoon.Languages.Nederlands", Assembly.GetExecutingAssembly());
                    break;
            }

            MakeBlueprint(SelectedBlueprint, Rotation);
        }

        private void CBbuildButton_Click(object sender, EventArgs e)
        {
            Blueprint Plan = Blueprints[SelectedBlueprint, Rotation];

            Point RelPoint;
            int BlockCount = Plan.RelPoints.Count();
            short[] TileData = { 0, 0 };

            for (int BlockNumber = 0; BlockNumber < BlockCount; BlockNumber++)
            {
                RelPoint = Plan.RelPoints[BlockNumber];
                TileData = Plan.TileData[BlockNumber];
                PictureBox Tile = (PictureBox)theGrid.GetControlFromPosition(BuildLocation.X + RelPoint.X, BuildLocation.Y + RelPoint.Y);
                Tile.Tag = new short[] { TileData[0], TileData[1] };
                Tile.BackgroundImage = BlockTypes[TileData[0]][TileData[1]].Tile;
            }

            switchToStandardTab(null, null);
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}