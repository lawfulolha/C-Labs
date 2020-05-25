using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{

    enum Education
    {
        Master,
        Bachelor,
        SecondEducation
    }

    class Student : Person
    {
        private Education degree;
        private int groupNumber;
        private System.Collections.ArrayList tests;
        private System.Collections.ArrayList exams;

        public Student(Person info, Education degree, int groupnumber)
        {
            this.firstName = info.FirstName;
            this.surname = info.Surname;
            this.dateOfBirth = info.DateOfBirth;
            this.degree = degree;
            this.GroupNumber = groupnumber;
            this.tests = new System.Collections.ArrayList();
            this.exams = new System.Collections.ArrayList();
        }

        public Student()
        {
            this.FirstName = "John";
            this.surname = "Doe";
            this.dateOfBirth = new DateTime(1998, 1, 1);
            this.degree = Education.Bachelor;
            this.GroupNumber = -1;
            this.tests = new System.Collections.ArrayList();
            this.exams = new System.Collections.ArrayList();
        }

        public Person Info
        {
            get
            {
                Person person = new Person(firstName, surname, dateOfBirth);
                return person;
            }
            set
            {
                firstName = value.FirstName;
                surname = value.Surname;
                dateOfBirth = value.DateOfBirth;
            }
        }

        public double AverageMark
        {
            get
            {
                double result = 0;
                Exam[] exams_avg = (Exam[]) this.exams.ToArray();
                for (int i = 0; i < this.exams.Count; i++)
                {
                    result += exams_avg[i].Mark;
                }
                return result;
            }
        }

        public System.Collections.ArrayList Examss
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

        public System.Collections.ArrayList Testss
        {
            get
            {
                return this.tests;
            }
            set
            {
                this.tests = value;
            }
        }

        public void AddExams(Exam[] exams)
        {
            for (int i = 0; i < exams.Length; i++)
            {
                this.exams.Add(exams[i]);
            }
        }

        public override string ToString()
        {
            string result = firstName + " " + surname + " " + dateOfBirth.ToString() + " " + degree.ToString() + " " + GroupNumber + " ";
            for (int i = 0; i < this.tests.Count; i++)
            {
                result += this.tests[i].ToString();
            }
            for (int i = 0; i < this.exams.Count; i++)
            {
                result += this.exams[i].ToString();
            }
            return result;
        }

        public override string ToShortString()
        {
            return firstName + " " + surname + " " + dateOfBirth.ToString() + " " + degree.ToString() + " " + GroupNumber + " " + AverageMark + " ";
        }

        public Education GetDegree()
        {
            return degree;
        }

        public void SetDegree(Education degree)
        {
            degree = degree;
        }

        public bool this[Education index]
        {
            get
            {
                return index == degree;
            }
        }

        public override object DeepCopy()
        {
            Student copy = new Student();
            copy.firstName = this.FirstName;
            copy.surname = this.surname;
            copy.dateOfBirth = this.dateOfBirth;
            copy.degree = this.degree;
            copy.GroupNumber = this.GroupNumber;
            copy.tests.AddRange(tests);
            copy.exams.AddRange(exams);
            return (object)copy;
        }

        public override DateTime Date
        {
            get
            {
                return this.Date;
            }
            set
            {
                this.Date = value;
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
                if (value <= 100 || value > 699)
                {
                    throw new Exception("Please enter number in range (100;699]");
                }
                else
                {
                    this.groupNumber = value;
                }
            }
        }

        public System.Collections.IEnumerable GetEnumeratorUnion()
        {
            System.Collections.ArrayList union = new System.Collections.ArrayList();
            for (int i = 0; i < tests.Count; i++)
            {
                union.Add(tests[i]);
            }
            for (int i = 0; i < this.exams.Count; i++)
            {
                union.Add(this.exams[i]);
            }
            for (int i = 0; i < union.Count; i++)
            {
                yield return union[i];
            }
        }

        public System.Collections.IEnumerable GetEnumeratorMoreThan(double mark)
        {
            for (int i = 0; i < exams.Count; i++)
            {
                Exam exam = (Exam)exams[i];
                if (exam.Mark > mark)
                {
                    yield return exam;
                }
            }
        }
    }
}