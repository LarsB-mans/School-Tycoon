using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SchoolTycoon
{
    class People
    {
        public Bitmap[][] GFX = new Bitmap[][] {
            new Bitmap[2],      // Pupil
            new Bitmap[2],      // Teacher
        };
        public Bitmap sprites = new Bitmap("graphics\\sprites.png");

        public void loadGraphics()
        {
            sprites.MakeTransparent(Color.Fuchsia);

            int personTypeCount = GFX.Count();
            int personSubTypeCount;
            short personType;
            short personSubType;

            for (personType = 0; personType < personTypeCount; personType++)
            {
                personSubTypeCount = GFX[personType].Count();
                for (personSubType = 0; personSubType < personSubTypeCount; personSubType++)
                    GFX[personType][personSubType] = sprites.Clone(new Rectangle(personSubType * 16, personType * 16, 16, 16), System.Drawing.Imaging.PixelFormat.Undefined);
            }
        }
    }
}
