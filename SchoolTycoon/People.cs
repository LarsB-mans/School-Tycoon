using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SchoolTycoon
{
    public partial class MainWindow
    {
        List<Pupil> Pupils;
        List<Teacher> Teachers;

        public enum Gender : byte { Male, Female };
        public enum Subject : byte { Biology, Chemistry, Economics, Geography, History, Language, Maths, Physics };

        static string[] FirstNamesMale = new string[] { "Herp", "Herpo", "Herpley", "Herper", "Herpus", };
        static string[] FirstNamesFemale = new string[] { "Herp", "Herpa", "Herpina", "Herpette", "Hercy" };
        static string[] LastNames = new string[] { "Derp", "Derpus", "Derpsley", "Derpington", "Derpson", "Derper", "Derpelburg", "Dercy", };

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
                if (Gender == Gender.Male)
                    this.FirstName = FirstNamesMale[Random.Next(FirstNamesMale.Count())];
                else
                    this.FirstName = FirstNamesFemale[Random.Next(FirstNamesFemale.Count())];
                this.LastName = LastNames[Random.Next(LastNames.Count())];
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
                if (Gender == Gender.Male)
                    this.FirstName = FirstNamesMale[Random.Next(FirstNamesMale.Count())];
                else
                    this.FirstName = FirstNamesFemale[Random.Next(FirstNamesFemale.Count())];
                this.LastName = LastNames[Random.Next(LastNames.Count())];
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
                    Pupils.Add(new Pupil((Gender)Random.Next(2), x));
            }

            Teachers = new List<Teacher>();
            for (int x = 0; x < 8; x++)
                Teachers.Add(new Teacher((Gender)Random.Next(1), new Subject[] { (Subject)x, }, 10));
        }

        public void ShowPupilInfo(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            {
                HidePupilInfo();
                return;
            }

            Pupil Pupil = Pupils[(int)treeView1.SelectedNode.Tag];

            pictureBox3.Image = PeopleLargeIcons.Images[(int)Pupil.Gender + 1];
            label37.Text = Pupil.FirstName + " " + Pupil.LastName;

            pictureBox3.Visible = true;
            label37.Visible = true;
            label36.Visible = true;
        }
        public void HidePupilInfo()
        {
            pictureBox3.Visible = false;
            label37.Visible = false;
            label36.Visible = false;
        }
    }
}
