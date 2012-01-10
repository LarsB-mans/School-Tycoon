using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SchoolTycoon
{
    public partial class MainWindow
    {
        public Bitmap tileSet = new Bitmap("graphics\\tileset.png");
        BlockType[][] BlockTypes;

        public struct BlockType
        {
            public Image Tile;
            public string Name;
            public bool Buildable;
            public bool Outside;
            public bool Walled;

            public BlockType(Image tile, string name, bool buildable, bool outside, bool walled)
            {
                Tile = tile;
                Name = name;
                Buildable = buildable;
                Outside = outside;
                Walled = walled;
            }
        }

        public void MakeBlockTypes()
        {
            BlockTypes = new BlockType[4][];
            BlockTypes[0] = new BlockType[] { Block("Grass", 0, 0, false, true, false) };
            BlockTypes[1] = new BlockType[] { Block("Dirt", 1, 0, false, true, false) };
            BlockTypes[2] = new BlockType[] { Block("Stone path", 2, 0, true, true, false) };
            BlockTypes[3] = new BlockType[] { Block("Floor path", 3, 0, true, false, true), 
                                              Block("Floor path", 3, 1, true, false, true), 
                                              Block("Floor path", 3, 2, true, false, true), 
                                              Block("Floor path", 3, 3, true, false, true), 
                                              Block("Floor path", 3, 4, true, false, true), 
                                              Block("Floor path", 3, 5, true, false, true), 
                                              Block("Floor path", 3, 6, true, false, true), 
                                              Block("Floor path", 3, 7, true, false, true), 
                                              Block("Floor path", 3, 8, true, false, true), 
                                              Block("Floor path", 3, 9, true, false, true), 
                                              Block("Floor path", 3, 10, true, false, true), 
                                              Block("Floor path", 3, 11, true, false, true), 
                                              Block("Floor path", 3, 12, true, false, true), 
                                              Block("Floor path", 3, 13, true, false, true), 
                                              Block("Floor path", 3, 14, true, false, true), 
                                              Block("Floor path", 3, 15, true, false, true), 
                                              Block("Floor path", 3, 16, true, false, true), 
                                              Block("Floor path", 3, 17, true, false, true), 
                                              Block("Floor path", 3, 18, true, false, true), 
                                              Block("Floor path", 3, 19, true, false, true), 
                                              Block("Floor path", 3, 20, true, false, true), 
                                              Block("Floor path", 3, 21, true, false, true), 
                                              Block("Floor path", 3, 22, true, false, true), 
                                              Block("Floor path", 3, 23, true, false, true), 
                                              Block("Floor path", 3, 24, true, false, true), 
                                              Block("Floor path", 3, 25, true, false, true), 
                                              Block("Floor path", 3, 26, true, false, true), 
                                              Block("Floor path", 3, 27, true, false, true), 
                                              Block("Floor path", 3, 28, true, false, true), 
                                              Block("Floor path", 3, 29, true, false, true), 
                                              Block("Floor path", 3, 30, true, false, true), 
                                              Block("Floor path", 3, 31, true, false, true), 
                                              Block("Floor path", 3, 32, true, false, true), 
                                              Block("Floor path", 3, 33, true, false, true), 
                                              Block("Floor path", 3, 34, true, false, true), 
                                              Block("Floor path", 3, 35, true, false, true), 
                                              Block("Floor path", 3, 36, true, false, true), 
                                              Block("Floor path", 3, 37, true, false, true), 
                                              Block("Floor path", 3, 38, true, false, true), 
                                              Block("Floor path", 3, 39, true, false, true), 
                                              Block("Floor path", 3, 40, true, false, true), 
                                              Block("Floor path", 3, 41, true, false, true), 
                                              Block("Floor path", 3, 42, true, false, true), 
                                              Block("Floor path", 3, 43, true, false, true), 
                                              Block("Floor path", 3, 44, true, false, true), 
                                              Block("Floor path", 3, 45, true, false, true), 
                                              Block("Floor path", 3, 46, true, false, true) };
        }
        public BlockType Block(string Name, int TileLocationY, int TileLocationX, bool Buildable, bool Outside, bool Walled)
        {
            return new BlockType(tileSet.Clone(new Rectangle(TileLocationX * 16, TileLocationY * 16, 16, 16), System.Drawing.Imaging.PixelFormat.Undefined), Name, Buildable, Outside, Walled);
        }
        public short GetEnclosureValue(Point BlockLocation)
        {
            Point[] RelativePointTable = new Point[] { new Point(-1, -1),
                                                       new Point(0, -1),
                                                       new Point(1, -1),
                                                       new Point(-1, 0),
                                                       new Point(1, 0),
                                                       new Point(-1, 1),
                                                       new Point(0, 1),
                                                       new Point(1, 1) };

            int LocationX, LocationY;
            int Value = 0;
            short[] TileData;
            for (int i = 0; i < 8; i++)
            {
                LocationX = BlockLocation.X + RelativePointTable[i].X;
                LocationY = BlockLocation.Y + RelativePointTable[i].Y;

                if (LocationX >= columncount || LocationX < 0 || LocationY >= rowcount || LocationY < 0)
                {
                    Value += 1 << i;
                    continue;
                }

                TileData = getTileData(LocationX, LocationY);

                if (BlockTypes[TileData[0]][TileData[1]].Outside == true)
                    Value += 1 << i;
            }

            byte[] Possibilities = new byte[] { 0, 15, 2, 2, 14, 16, 2, 2, 3, 3, 8, 8, 28, 28, 8, 8, 5, 30, 9, 9, 5, 30, 9, 9, 13, 13, 43, 43, 13, 13, 43, 43, 7, 18, 27, 27, 20, 22, 27, 27, 3, 3, 8, 8, 28, 28, 8, 8, 34, 38, 40, 40, 34, 38, 40, 40, 13, 13, 43, 43, 13, 13, 43, 43, 4, 29, 12, 12, 33, 37, 12, 12, 10, 10, 45, 45, 41, 41, 45, 45, 11, 42, 44, 44, 11, 42, 44, 44, 46, 46, 1, 1, 46, 46, 1, 1, 4, 29, 12, 12, 33, 37, 12, 12, 10, 10, 45, 45, 41, 41, 45, 45, 11, 42, 44, 44, 11, 42, 44, 44, 46, 46, 1, 1, 46, 46, 1, 1, 6, 17, 31, 31, 19, 23, 31, 31, 32, 32, 39, 39, 36, 36, 39, 39, 5, 30, 9, 9, 5, 30, 9, 9, 13, 13, 43, 43, 13, 13, 43, 43, 21, 25, 35, 35, 24, 26, 35, 35, 32, 32, 39, 39, 36, 36, 39, 39, 34, 38, 40, 40, 34, 38, 40, 40, 13, 13, 43, 43, 13, 13, 43, 43, 4, 29, 12, 12, 33, 37, 12, 12, 10, 10, 45, 45, 41, 41, 45, 45, 11, 42, 44, 44, 11, 42, 44, 44, 46, 46, 1, 1, 46, 46, 1, 1, 4, 29, 12, 12, 33, 37, 12, 12, 10, 10, 45, 45, 41, 41, 45, 45, 11, 42, 44, 44, 11, 42, 44, 44, 46, 46, 1, 1, 46, 46, 1, 1 };

            return Possibilities[Value];
        }



        public Bitmap spriteSet = new Bitmap("graphics\\sprites.png");
        List<Image> Sprites = new List<Image>();

        public enum Sprite
        {
            BlueprintBlue,
            BlueprintRed
        }

        public void LoadSprites()
        {
            int spriteCount = spriteSet.Width / 16;

            spriteSet.MakeTransparent(Color.Fuchsia);

            for (int x = 0; x < spriteCount; x++)
                Sprites.Add(spriteSet.Clone(new Rectangle(x * 16, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Undefined));
        }
    }
}
