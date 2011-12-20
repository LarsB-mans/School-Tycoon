using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainWindow : Form
    {
        public static TableLayoutPanelCellPosition selectedTile;
        public static int rowcount;
        public static int columncount;
        public static int tileSetNumber = 0;
        Blocks Blocks = new Blocks();
        People People = new People();

        int[][] personData = new int[0][];

        public MainWindow()
        {
            Blocks.loadGraphics();
            People.loadGraphics();
            InitializeComponent();

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
                    changeTileImage(j, i, 0, 0);
            #endregion

            InitializePeople();
            lockGame(false);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
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

            savefile.Close();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
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
            lockGame(false);
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
            personData = new int[4][];  // create 1 person
            personData[0] = new int[4]; // generate data for person 1
            personData[1] = new int[4]; // generate data for person 2
            personData[2] = new int[4];
            personData[3] = new int[4];

            personData[0][0] = 0;       // person 1 = student
            personData[0][1] = 0;       // person 1 = male
            personData[0][2] = 0;
            personData[0][3] = 0;

            personData[1][0] = 0;       // person 2 = student
            personData[1][1] = 1;       // person 2 = male
            personData[1][2] = 1;
            personData[1][3] = 0;

            personData[2][0] = 1;       // person 1 = teacher
            personData[2][1] = 0;       // person 1 = male
            personData[2][2] = 0;
            personData[2][3] = 1;

            personData[3][0] = 1;       // person 1 = teacher
            personData[3][1] = 1;       // person 1 = female
            personData[3][2] = 1;
            personData[3][3] = 1;

            foreach (int[] data in personData)
            {
                PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(data[2], data[3]);
                tile.Image = People.GFX[data[0]][data[1]];
            }
        }

        private void lockGame(bool lockstatus)
        {
            lockstatus = !lockstatus;
            saveToolStripMenuItem.Enabled = lockstatus;
            splitContainer1.Enabled = lockstatus;
        }
        private void fillDebugMenu()
        {
            int blockCount = Blocks.GFX.Count();
            for (int i = 0; i < Blocks.GFX.Count(); i++)
            {
                changeTile.Items.Add(i.ToString());
                changeTile.Items[changeTile.Items.Count - 1].Tag = i;
            }
        }
        private void box_Click(object sender, EventArgs e)
        {
            selectedTile = theGrid.GetPositionFromControl(((Control)sender));
            changeTile.Show(Cursor.Position);
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
                    changeTileImage(column, row, tiletype, tilevalue);
                    break;
            }
        }
        private void changeTileImage(int column, int row, short tiletype, short tilevalue)
        {
            PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(column, row);
            tile.Tag = new short[] { tiletype, tilevalue };
            tile.BackgroundImage = Blocks.GFX[tiletype][tilevalue];
        }
        private short[] getTileData(int column, int row)
        {
            PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(column, row);
            return (short[])tile.Tag;
        }
    }
}
