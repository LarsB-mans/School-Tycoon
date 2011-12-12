using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainWindow : Form
    {
        public static TableLayoutPanelCellPosition selectedTile;
        public static int rowcount = 16;
        public static int columncount = 16;
        public static int tileSetNumber = 0;
        Blocks blocks = new Blocks();
        People people = new People();
        
        public Bitmap sprites = new Bitmap("graphics\\sprites.png");

        int[][] personData = new int[0][];

        public MainWindow()
        {
            blocks.loadGraphics();
            people.loadGraphics();
            InitializeComponent();

            fillDebugMenu();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGrid(columncount, rowcount);
            InitializePeople();
        }

        public void InitializeGrid(int columncount, int rowcount)
        {
            theGrid.Controls.Clear();
            theGrid.ColumnStyles.Clear();
            theGrid.ColumnCount = columncount + 1;
            for (int i = 0; i < columncount; i++)
                theGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));

            theGrid.RowStyles.Clear();
            theGrid.RowCount = rowcount + 1;
            for (int i = 0; i < rowcount; i++)
                theGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));

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
        }
        public void InitializePeople()
        {
            personData = new int[2][];  // create 1 person
            personData[0] = new int[4]; // generate data for person 1
            personData[1] = new int[4]; // generate data for person 2

            personData[0][0] = 0;       // person 1 = student
            personData[0][1] = 0;       // person 1 = male
            personData[0][2] = 0;
            personData[0][3] = 0;

            personData[1][0] = 0;       // person 2 = student
            personData[1][1] = 1;       // person 2 = male
            personData[1][2] = 4;
            personData[1][3] = 0;

            foreach (int[] data in personData)
            {
                PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(data[2], data[3]);
                tile.Image = people.GFX[data[0]][data[1]];
            }
        }

        private void fillDebugMenu()
        {
            int blockCount = blocks.GFX.Count();
            for (int i = 0; i < blocks.GFX.Count(); i++)
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
            tile.BackgroundImage = blocks.GFX[tiletype][tilevalue];
        }
        private short[] getTileData(int column, int row)
        {
            PictureBox tile = (PictureBox)theGrid.GetControlFromPosition(column, row);
            return (short[])tile.Tag;
        }

    }
}
