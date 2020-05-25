using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Exam
    {
        public string title;
        public int mark;
        public DateTime date;

        public Exam(string name, int mark, DateTime date)
        {
            this.title = title;
            this.mark = mark;
            this.date = date;
        }

        public Exam()
        {
            this.title = "Exam";
            this.mark = -1;
            this.date = new DateTime(2010, 2, 3);
        }

        public override string ToString()
        {
            return this.title + ", " + this.mark.ToString() + ", " + this.date.ToString();
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
                this.date = value;
            }
        }
    }
}