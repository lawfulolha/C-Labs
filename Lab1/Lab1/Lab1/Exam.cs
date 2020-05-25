using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Exam
    {
        public string title;
        public int mark;
        public DateTime exam_date;
        public Exam(string n, int m, DateTime d)
        {
            title = n;
            mark = m;
            exam_date = d;
        }

        public Exam()
        {
            title = "Exam";
            mark = 0;
            exam_date = new DateTime(2010, 1, 1);
        }

        public override string ToString()
        {
            return this.title + ", " + mark.ToString() + ", " + exam_date.ToString();
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
        public int Mark {
            get {
                return this.mark;
            }

            set
            {
                this.mark = value;
            }
        }

        public DateTime GetDate {
            get {
                    return exam_date;
                }

            set
            {
                exam_date = value;
            }
        }
    }
}
