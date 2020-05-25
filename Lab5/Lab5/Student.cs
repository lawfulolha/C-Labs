using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab5
{

    enum Education
    {
        Master,
        Bachelor,
        SecondEducation
    }

    [Serializable]
    class Student : Person
    {
        private Education degree;
        private int groupNumber;
        private List<Test> tests;
        private List<Exam> exams;

        public Student(Person info, Education degree, int groupnumber)
        {
            this.firstName = info.FirstName;
            this.surname = info.Surname;
            this.dateOfBirth = info.DateOfBirth;
            this.degree = degree;
            this.groupNumber = groupnumber;
            this.tests = new List<Test>();
            this.exams = new List<Exam>();
        }

        public Student()
        {
            this.firstName = "John";
            this.Surname = "Doe";
            this.dateOfBirth = new DateTime(1998, 1, 1);
            this.degree = Education.Bachelor;
            this.groupNumber = -1;
            this.tests = new List<Test>();
            this.exams = new List<Exam>();
        }

        public Person Info
        {
            get
            {
                Person person = new Person(this.firstName, this.Surname, this.dateOfBirth);
                return person;
            }
            set
            {
                this.firstName = value.FirstName;
                this.surname = value.Surname;
                this.dateOfBirth = value.DateOfBirth;
            }
        }

        public double AverageMark
        {
            get
            {
                double result = 0;
                Exam[] exams = (Exam[])this.exams.ToArray();
                for (int i = 0; i < this.exams.Count; i++)
                {
                    result += exams[i].Mark;
                }
                return result / exams.Length;
            }
        }

        public List<Exam> Exams
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

        public List<Test> Tests
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
                Exams.Add(exams[i]);
            }
        }

        public override string ToString()
        {
            string result = firstName + ";" + Surname + ";" + dateOfBirth.ToString() + ";" + degree.ToString() + ";" + groupNumber + ";";
            for (int i = 0; i < Tests.Count; i++)
            {
                result += Tests[i].ToString();
            }
            for (int i = 0; i < Exams.Count; i++)
            {
                result += Exams[i].ToString();
            }
            result += "|";
            return result;
        }

        public override string ToShortString()
        {
            return firstName + " " + Surname + " " + dateOfBirth.ToString() + " " + degree.ToString() + " " + groupNumber + " " + AverageMark + " ";
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
        public bool this[Education index]
        {
            get
            {
                return index == degree;
            }
        }

        public Student DeepCopy()
        {
            if (!typeof(Student).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            if (Object.ReferenceEquals(this, null))
            {
                return default(Student);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Student)formatter.Deserialize(stream);
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
                    throw new Exception("Group number must be in (100;699]");
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
            for (int i = 0; i < Tests.Count; i++)
            {
                union.Add(Tests[i]);
            }
            for (int i = 0; i < Exams.Count; i++)
            {
                union.Add(Exams[i]);
            }
            for (int i = 0; i < union.Count; i++)
            {
                yield return union[i];
            }
        }

        public System.Collections.IEnumerable GetEnumeratorMoreThan(double mark)
        {
            for (int i = 0; i < Exams.Count; i++)
            {
                Exam exam = (Exam)Exams[i];
                if (exam.Mark > mark)
                {
                    yield return exam;
                }
            }
        }

        public bool Save(string filename)
        {
            if (!(File.Exists(filename)))
            {
                Console.WriteLine("File does not exist");
                Console.WriteLine("File was created");
            }

            if (!typeof(Student).IsSerializable)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(stream, this);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public bool Load(string filename)
        {
            if (!(File.Exists(filename)))
            {
                Console.WriteLine("File does not exist");
                Console.WriteLine("File was created");
            }

            if (!typeof(Student).IsSerializable)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    Student student = (Student)formatter.Deserialize(stream);
                    firstName = student.firstName;
                    Surname = student.Surname;
                    dateOfBirth = student.dateOfBirth;
                    degree = student.Degree;
                    groupNumber = student.GroupNumber;
                    Tests = student.Tests;
                    Exams = student.Exams;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public bool AddFromConsole()
        {
            Console.Write("Input Exam info (Format: Math;95;27.03.2000): ");
            string info = Console.ReadLine();

            try
            {
                string[] vs = info.Split(new char[] { ';' });

                Exam exam = new Exam();
                exam.Title = vs[0];
                exam.Mark = Convert.ToInt32(vs[1]);

                string[] vs1 = vs[2].Split(new char[] { '.' });
                exam.Date = new DateTime(Convert.ToInt32(vs1[2]), Convert.ToInt32(vs1[1]), Convert.ToInt32(vs1[0]));

                Exams.Add(exam);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}