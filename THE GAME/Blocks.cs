using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace SchoolTycoon
{
    public partial class MainWindow
    {
        public static Bitmap tileSet = new Bitmap("graphics\\tileset.png");
        BlockType[][] BlockTypes = new BlockType[][] {
            new BlockType[] { Block("Empty", 2, 1, true, true, false) },            // 0
            new BlockType[] { Block("Grass", 0, 0, false, true, false) },           // 1
            new BlockType[] { Block("Dirt", 1, 0, false, true, false) },            // 2
            new BlockType[] { Block("Stone path", 2, 0, true, true, false) },       // 3
            #region new BlockType[] { Block("Floor path", 3, 0, true, false, true) },       // 4
            new BlockType[] { Block("Floor path", 3, 0, true, false, true), 
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
                              Block("Floor path", 3, 46, true, false, true),
            },
#endregion
            #region new BlockType[] { Block("Classroom", 0, 4, false, false, false) },      // 5
            new BlockType[] { Block("Classroom (Small)", 0, 4, false, false, false),    // 0
                              Block("Classroom (Small)", 0, 5, false, false, false),    // 1
                              Block("Classroom (Small)", 0, 6, false, false, false),    // 2
                              Block("Classroom (Small)", 0, 7, false, false, false),    // 3
                              Block("Classroom (Medium)", 1, 4, false, false, false),   // 4
                              Block("Classroom (Medium)", 1, 5, false, false, false),   // 5
                              Block("Classroom (Medium)", 1, 6, false, false, false),   // 6
                              Block("Classroom (Medium)", 1, 7, false, false, false),   // 7
                              Block("Classroom (Medium)", 0, 8, false, false, false),   // 8
                              Block("Classroom (Medium)", 0, 9, false, false, false),   // 9
                              Block("Classroom (Medium)", 0, 10, false, false, false),  // 10
                              Block("Classroom (Medium)", 0, 11, false, false, false),  // 11
                              Block("Classroom (Large)", 2, 4, false, false, false),    // 12
                              Block("Classroom (Large)", 2, 5, false, false, false),    // 13
                              Block("Classroom (Large)", 2, 6, false, false, false),    // 14
                              Block("Classroom (Large)", 2, 7, false, false, false),    // 15
                              Block("Classroom (Large)", 1, 8, false, false, false),    // 16
                              Block("Classroom (Large)", 1, 9, false, false, false),    // 17
                              Block("Classroom (Large)", 1, 10, false, false, false),   // 18
                              Block("Classroom (Large)", 1, 11, false, false, false),   // 19 
            },
            #endregion  
            #region new BlockType[] { Block("Blueprint", 2, 2, false, true, false) },       // 6
            new BlockType[] { Block("Blueprint (Outside)", 2, 2, false, true, false),   // 0
                              Block("Blueprint (Inside)", 2, 2, false, false, false),   // 1
            },
            #endregion

        };
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
        public static BlockType Block(string Name, int TileLocationY, int TileLocationX, bool Buildable, bool Outside, bool Walled)
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



        int SelectedBlueprint = 0;
        int Rotation = 0;
        Point[] BuilderRelPoints;
        public Blueprint[,] Blueprints = new Blueprint[,]
        {
            #region Classroom (Small)
            {
                new Blueprint("ClassroomSmallName",
                              "ClassroomSmallDescription",
                              1000,
                              30,
                              new Point[] { new Point(0, 0) },
                              new short[][] { new short[] { 5, 0 } }),
                new Blueprint("ClassroomSmallName",
                              "ClassroomSmallDescription",
                              1000,
                              30,
                              new Point[] { new Point(0, 0) },
                              new short[][] { new short[] { 5, 1 } }),
                new Blueprint("ClassroomSmallName",
                              "ClassroomSmallDescription",
                              1000,
                              30,
                              new Point[] { new Point(0, 0) },
                              new short[][] { new short[] { 5, 2 } }),
                new Blueprint("ClassroomSmallName",
                              "ClassroomSmallDescription",
                              1000,
                              30,
                              new Point[] { new Point(0, 0) },
                              new short[][] { new short[] { 5, 3 } }),
            },
            #endregion

            #region Classroom (Medium)
            {
                new Blueprint("ClassroomMediumName",
                              "ClassroomMediumDescription",
                              1500,
                              60,
                              new Point[] { new Point(0, 0), new Point(0, 1) },
                              new short[][] { new short[] { 5, 4 }, new short[] { 5, 8 } }),
                new Blueprint("ClassroomMediumName",
                              "ClassroomMediumDescription",
                              1500,
                              60,
                              new Point[] { new Point(0, 0), new Point(-1, 0) },
                              new short[][] { new short[] { 5, 5 }, new short[] { 5, 9 } }),
                new Blueprint("ClassroomMediumName",
                              "ClassroomMediumDescription",
                              1500,
                              60,
                              new Point[] { new Point(0, 0), new Point(0, -1) },
                              new short[][] { new short[] { 5, 6 }, new short[] { 5, 10 } }),
                new Blueprint("ClassroomMediumName",
                              "ClassroomMediumDescription",
                              1500,
                              60,
                              new Point[] { new Point(0, 0), new Point(1, 0) },
                              new short[][] { new short[] { 5, 7 }, new short[] { 5, 11 } }),
            },
            #endregion

            #region Classroom (Large)
            {
                new Blueprint("ClassroomLargeName",
                              "ClassroomLargeDescription",
                              2000,
                              90,
                              new Point[] { new Point(0, 0), new Point(1, 0), new Point(0, 1) },
                              new short[][] { new short[] { 5, 12 }, new short[] { 5, 16 }, new short[] { 5, 8 } }),
                new Blueprint("ClassroomLargeName",
                              "ClassroomLargeDescription",
                              2000,
                              90,
                              new Point[] { new Point(0, 0), new Point(0, 1), new Point(-1,0) },
                              new short[][] { new short[] { 5, 13 }, new short[] { 5, 17 }, new short[] { 5, 9 } }),
                new Blueprint("ClassroomLargeName",
                              "ClassroomLargeDescription",
                              2000,
                              90,
                              new Point[] { new Point(0, 0), new Point(-1, 0), new Point(0, -1) },
                              new short[][] { new short[] { 5, 14 }, new short[] { 5, 18 }, new short[] { 5, 10 } }),
                new Blueprint("ClassroomLargeName",
                              "ClassroomLargeDescription",
                              2000,
                              90,
                              new Point[] { new Point(0, 0), new Point(0, -1), new Point(1, 0) },
                              new short[][] { new short[] { 5, 15 }, new short[] { 5, 19 }, new short[] { 5, 11 } }),



        },
                              

           
    
                                

            #endregion
        };
        public struct Blueprint
        {
            public string NameResource;
            public string DescriptionResource;
            public int Price;
            public int DaysToBuild;
            public Point[] RelPoints;
            public short[][] TileData;

            public Blueprint(string NameResource, string DescriptionResource, int Price, int DaysToBuild, Point[] RelPoints, short[][] TileData )
            {
                this.NameResource = NameResource;
                this.DescriptionResource = DescriptionResource;
                this.Price = Price;
                this.DaysToBuild = DaysToBuild;
                this.RelPoints = RelPoints;
                this.TileData = TileData;
            }
        }
        public void PrepareBlueprint()
        {
            for (int x = 0; x < 25; x++)
            {
                PictureBox box = new PictureBox();
                box.Margin = new Padding(0);
                box.BackgroundImage = BlockTypes[0][0].Tile.GetThumbnailImage(32, 32, null, IntPtr.Zero);
                BuilderBlueprint.Controls.Add(box);
            }

            BuilderBlueprint.Left = (classroomBuilderTab.Width - BuilderBlueprint.Width) / 2;
        }
        public void MakeBlueprint(int BlueprintNumber, int Rotation)
        {
            Blueprint Plan = Blueprints[BlueprintNumber, Rotation];

            Point RelPoint;
            int BlockCount;
            short[] TileData = { 0, 0 };

            if (BuilderRelPoints != null)
            {
                BlockCount = BuilderRelPoints.Count();
                for (int BlockNumber = 0; BlockNumber < BlockCount; BlockNumber++)
                {
                    RelPoint = BuilderRelPoints[BlockNumber];
                    PictureBox Tile = (PictureBox)BuilderBlueprint.GetControlFromPosition(2 + RelPoint.X, 2 + RelPoint.Y);
                    Tile.Tag = new short[] { TileData[0], TileData[1] };
                    Tile.BackgroundImage = BlockTypes[TileData[0]][TileData[1]].Tile.GetThumbnailImage(32, 32, null, IntPtr.Zero);
                }
            }

            BuilderRelPoints = Plan.RelPoints;

            BlockCount = Plan.RelPoints.Count();
            for (int BlockNumber = 0; BlockNumber < BlockCount; BlockNumber++)
            {
                RelPoint = Plan.RelPoints[BlockNumber];
                TileData = Plan.TileData[BlockNumber];
                PictureBox Tile = (PictureBox)BuilderBlueprint.GetControlFromPosition(2 + RelPoint.X, 2 + RelPoint.Y);
                Tile.Tag = new short[] { TileData[0], TileData[1] };
                Tile.BackgroundImage = BlockTypes[TileData[0]][TileData[1]].Tile.GetThumbnailImage(32, 32, null, IntPtr.Zero);
            }

            BlueprintName.Text = "< " + Language.GetString(Plan.NameResource) + " >";
            BlueprintDescription.Text = Language.GetString(Plan.DescriptionResource);
            
            BlueprintPrice.Text = String.Format(Language.GetString("ClassroomBuilderCosts"), Plan.Price.ToString("N0", Culture.NumberFormat));
            if (Money >= Plan.Price)
            {
                BlueprintPrice.ForeColor = Color.Black;
                //CBbuildButton.Enabled = true;
            }
            else
            {
                BlueprintPrice.ForeColor = Color.Red;
                //CBbuildButton.Enabled = false;
            }

            BlueprintBuildTime.Text = String.Format(Language.GetString("ClassroomBuilderTime"), Plan.DaysToBuild);
        }
        private void CBbuildButton_Click(object sender, EventArgs e)
        {
            Blueprint Plan = Blueprints[SelectedBlueprint, Rotation];

            Point RelPoint;
            int BlockCount = Plan.RelPoints.Count();
            short[] TileData = { 0, 0 };

            Money -= Plan.Price;
            UpdateStatusWindow();

            for (int BlockNumber = 0; BlockNumber < BlockCount; BlockNumber++)
            {
                RelPoint = Plan.RelPoints[BlockNumber];
                TileData = Plan.TileData[BlockNumber];
                PictureBox Tile = (PictureBox)theGrid.GetControlFromPosition(BuildLocation.X + RelPoint.X, BuildLocation.Y + RelPoint.Y);
                Tile.Tag = new short[] { TileData[0], TileData[1] };

                // Place blueprint:
                if (BlockTypes[TileData[0]][TileData[1]].Outside)
                    Tile.BackgroundImage = BlockTypes[6][0].Tile;
                else
                    Tile.BackgroundImage = BlockTypes[6][1].Tile;
            }
            TimeLine.Add(new Event(Date.AddDays(Plan.DaysToBuild), EventType.Build, new int[] { SelectedBlueprint, Rotation }, BuildLocation, "Construction of \"" + Language.GetString(Plan.NameResource) + "\" finishes.", "Construction of \"" + Language.GetString(Plan.NameResource) + "\" has finished."));

            ExitClassroomBuilder(null, null);
        }
        private void BuildClassroom(int[] Data, Point Location)
        {
            Blueprint Plan = Blueprints[Data[0], Data[1]];

            Point RelPoint;
            int BlockCount = Plan.RelPoints.Count();
            short[] TileData = { 0, 0 };

            for (int BlockNumber = 0; BlockNumber < BlockCount; BlockNumber++)
            {
                RelPoint = Plan.RelPoints[BlockNumber];
                TileData = Plan.TileData[BlockNumber];
                PictureBox Tile = (PictureBox)theGrid.GetControlFromPosition(Location.X + RelPoint.X, Location.Y + RelPoint.Y);
                Tile.Tag = new short[] { TileData[0], TileData[1] };

                Tile.BackgroundImage = BlockTypes[TileData[0]][TileData[1]].Tile;
            }
        }
        private void ExitClassroomBuilder(object sender, EventArgs e)
        {
            clearSprites();
            CBbuildButton.Enabled = false;
            tabControl1.SelectedTab = standardTab;
        }



        public enum RoomType
        {
            ClassroomSmall,
            ClassroomMedium,
            ClassroomLarge,
        }
        public struct Blackboard
        {
            public string NameResource;
            public string DescriptionResource;
            public int Price;
            public int Quality;
            public int WritingRoom;

            public Blackboard(string NameResource, string DescriptionResource, int Price, int WritingRoom)
            {
                this.NameResource = NameResource;
                this.DescriptionResource = DescriptionResource;
                this.Price = Price;
                this.Quality = 100;
                this.WritingRoom = WritingRoom;
            }
        }
        #region Blackboard[] Blackboards = new Blackboard[] {
        Blackboard[] Blackboards = new Blackboard[] {
            new Blackboard("NoBlackboardName", "NoBlackboardDescription", 0, 0),
            new Blackboard("RockSlateName", "RockSlateDescription", 50, 10), 
            new Blackboard("ChalkboardName", "ChalkboardDescription", 150, 40),
            new Blackboard("WhiteboardName", "WhiteboardDescription", 200, 40),
            new Blackboard("DoubleChalkboardName", "DoubleChalkboardDescription", 300, 80),
            new Blackboard("DoubleWhiteboardName", "DoubleWhiteboardDescription", 400, 80),
            new Blackboard("InteractiveWhiteboardName", "InteractiveWhiteboardDescription", 1000, 100),
        };
        #endregion
        public struct Classroom
        {
            public RoomType RoomType;
            public Blackboard Blackboard;
            public short ChairsMax;
            public short Chairs;
            public short DesksMax;
            public short Desks;
            public short ComputersMax;
            public short Computers;
            public short IslandSize;
            public bool IslandsPossible;
            public Point[] Locations;

            public Classroom(RoomType RoomType, short ChairsMax, short DesksMax, short ComputersMax, bool IslandsPossible, Point[] Locations)
            {
                this.RoomType = RoomType;
                this.Blackboard = new Blackboard("NoBlackboardName", "NoBlackboardDescription", 0, 0);
                this.ChairsMax = ChairsMax;
                this.Chairs = 0;
                this.DesksMax = DesksMax;
                this.Desks = 0;
                this.ComputersMax = ComputersMax;
                this.Computers = 0;
                this.IslandSize = 4;
                this.IslandsPossible = IslandsPossible;
                this.Locations = Locations;
            }
        }


        public enum EventType
        {
            Build,
        }
        /*
         * Build:
         * [0] = Selected Blueprint
         * [1] = Rotation
        */
        public struct Event
        {
            public DateTime DateTime;
            public EventType EventType;
            public int[] Data;
            public Point Location;
            public string BeforeText;
            public string AfterText;

            public Event(DateTime DateTime, EventType EventType, int[] Data, Point Location, string BeforeText, string AfterText)
            {
                this.DateTime = DateTime;
                this.EventType = EventType;
                this.Data = Data;
                this.Location = Location;
                this.BeforeText = BeforeText;
                this.AfterText = AfterText;
            }
        }
        List<Event> TimeLine = new List<Event>();



        public Bitmap spriteSet = new Bitmap("graphics\\sprites.png");
        List<Image> Sprites = new List<Image>();

        public enum Sprite
        {
            BlueprintBlue,
            BlueprintRed,
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
