using System;
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

        List<Pupil> Pupils;
        List<Teacher> Teachers;

        public enum Gender : byte { Male, Female };
        public enum Subject : byte { Biology, Chemistry, Economics, Geography, History, Language, Maths, Physics };
        
        public int AmountOfClasses;
        public struct Pupil
        {
            public string FirstName;
            public string LastName;
            public Gender Gender;
            public int Happiness;
            public int Class;

            public Pupil(Gender Gender, int Class)
            {
                this.FirstName = "Herp";
                this.LastName = "Derp";
                this.Gender = Gender;
                this.Happiness = Random.Next(1000);
                this.Class = Class;
            }
        }
        public struct Teacher
        {
            public string FirstName;
            public string LastName;
            public Gender Gender;
            public Subject[] Subjects;
            public int Salary;
            public int Happiness;

            public Teacher(Gender Gender, Subject[] Subjects, int Salary)
            {
                this.FirstName = "Herp";
                this.LastName = "Derp";
                this.Gender = Gender;
                this.Subjects = Subjects;
                this.Salary = Salary;
                this.Happiness = Random.Next(1000);
            }
        }

        public void InitializePeople()
        {
            AmountOfClasses = 6;

            Pupils = new List<Pupil>();
            for (int x = 0; x < AmountOfClasses; x++)
            {
                int ClassSize = Random.Next(20, 24);
                for (int y = 0; y < ClassSize; y++)
                    Pupils.Add(new Pupil((Gender)Random.Next(1), x));
            }
            for (int x = 0; x < 9; x++)
                Pupils.Add(new Pupil((Gender)Random.Next(1), x));

            Teachers = new List<Teacher>();
            for (int x = 0; x < 8; x++)
                Teachers.Add(new Teacher((Gender)Random.Next(1), new Subject[] { (Subject)x, }, 10));
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
