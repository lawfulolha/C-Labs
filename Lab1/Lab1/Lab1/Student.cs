using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{

    enum Education
    {
        Master,
        Bachelor,
        SecondEducation
    }
    class Student
    {

        private Person studentInfo;
        private Education degree;
        private int groupNumber;
        private Exam[] exams;

        public Student(Person info, Education degree, int groupnumber, int examsnumber)
        {
            this.studentInfo = info;
            this.degree = degree;
            this.groupNumber = groupnumber;
            this.exams = new Exam[examsnumber];
            for(int i = 0; i < exams.Length; i++)
            {
                exams[i] = new Exam();
            }
        }

        public Student()
        {
            groupNumber = -1;
            this.exams = new Exam[1];
            exams[0] = new Exam();
        }

        public Person StudentInfo
        {
            get
            {
                return this.studentInfo;
            }

            set
            {
                this.studentInfo = value;
            }
        }
        public Education Degree
        {
            get
            {
                return this.degree;
            }

            set
            {
                this.degree = value;
            }
        }
        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                this.groupNumber = value;
            }
        }
        public Exam[] Exams
        {
            get
            {
                return this.exams;
            }

            set
            {
                this.exams = value;
            }
        }

        public double AverageMark()
        {
            double res = 0;
            for(int i = 0; i < this.exams.Length; i++)
            {
                res += exams[i].Mark;
            }
            return res / exams.Length;
        }

        public bool this[Education index]
        {
            get
            {
                return index == this.degree;
            }
        }

        public void AddExams(Exam[] exams)
        {
            for(int i = 0; i < exams.Length; i++)
            {
                Array.Resize(ref exams, exams.Length + 1);
                exams[exams.Length - 1] = exams[i];
            }
        }

        public override string ToString()
        {
            string result = studentInfo.ToString() + ";" + degree.ToString() + ";" + groupNumber + ";";
            for(int i = 0; i < exams.Length; i++)
            {
                result += exams[i].ToString() + ";";
            }
            return result; 
        }

        public virtual string ToShortString()
        {
            return studentInfo.ToString() + ";" + degree.ToString() + ";" + groupNumber + ";" + AverageMark();
        }

    }
}
