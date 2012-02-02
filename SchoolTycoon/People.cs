﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SchoolTycoon
{
    public partial class MainWindow
    {
        public Bitmap[][] PeopleGFX = new Bitmap[][] {
            new Bitmap[2],      // Pupil
            new Bitmap[2],      // Teacher
        };
        public Bitmap peopleSet = new Bitmap("graphics\\people.png");

        public enum Gender : byte { Male, Female };
        public enum Type : byte { Pupil, Teacher };
        public enum Subject : byte { English, Maths, Physics, Chemistry, History, Biology, Economics, ForeignLanguages, Geography };

        public int AmountOfClasses;
        public struct Person
        {
            public Gender Gender;
            public Type Type;
            public int Happiness;
            public int Class;

            public Person(Gender Gender, Type Type, int Class)
            {
                this.Gender = Gender;
                this.Type = Type;
                this.Happiness = Random.Next(1000);
                this.Class = Class;
            }
        }

        public void loadPeopleGraphics()
        {
            peopleSet.MakeTransparent(Color.Fuchsia);

            int personTypeCount = PeopleGFX.Count();
            int personSubTypeCount;
            short personType;
            short personSubType;

            for (personType = 0; personType < personTypeCount; personType++)
            {
                personSubTypeCount = PeopleGFX[personType].Count();
                for (personSubType = 0; personSubType < personSubTypeCount; personSubType++)
                    PeopleGFX[personType][personSubType] = peopleSet.Clone(new Rectangle(personSubType * 16, personType * 16, 16, 16), System.Drawing.Imaging.PixelFormat.Undefined);
            }
        }
    }
}
