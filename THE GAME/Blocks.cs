using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Blocks
    {
        public Bitmap[][] GFX = new Bitmap[][] {
            new Bitmap[4],      // Grass
            new Bitmap[4],      // Dirt
            new Bitmap[1]       // Stone path
        };
        public Bitmap tileset = new Bitmap("graphics\\tileset.png");

        public void loadGraphics()
        {
            int blockTypeCount = GFX.Count();
            int blockSubTypeCount;
            short blockType;
            short blockSubType;

            for (blockType = 0; blockType < blockTypeCount; blockType++)
            {
                blockSubTypeCount = GFX[blockType].Count();
                for (blockSubType = 0; blockSubType < blockSubTypeCount; blockSubType++)
                    GFX[blockType][blockSubType] = tileset.Clone(new Rectangle(blockSubType * 16, blockType * 16, 16, 16), System.Drawing.Imaging.PixelFormat.Undefined);
            }
        }
    }
}
