using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{

    [Serializable]
    class Exam
    {
        public string title;
        public int mark;
        public DateTime date;

        public Exam(string name, int mark, DateTime date)
        {
            this.title = name;
            this.mark = mark;
            this.date = date;
        }

        public Exam()
        {
            this.title = "Exam";
            this.mark = -1;
            this.date = new DateTime(2010, 1, 1);
        }

        public override string ToString()
        {
            return this.title + ";" + this.mark.ToString() + ";" + this.date.ToString() + "|";
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }
        public int Mark
        {
            get
            {
                return this.mark;
            }

            set
            {
                this.mark = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = date;
            }
        }
    }
}