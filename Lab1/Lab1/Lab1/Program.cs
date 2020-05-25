using System;

namespace Lab1
{

    class Program
    {

        public static void TimeCheck()
        {
            var StartTime = System.Diagnostics.Stopwatch.StartNew();
            Exam[] exams = new Exam[1000000];
            for (int i = 0; i < exams.Length; i++)
            {
                exams[i] = new Exam();
            }
            StartTime.Stop();
            var ResultTime = StartTime.ElapsedMilliseconds;
            Console.WriteLine("Classic Format: " + ResultTime);
            var StartTime1 = System.Diagnostics.Stopwatch.StartNew();
            Exam[,] exams1 = new Exam[1000,1000];
            for (int i = 0; i < 100; i++)
            {
                for(int j = 0; j< 100; j++)
                {
                    exams1[i, j] = new Exam();
                }
            }
            StartTime1.Stop();
            var ResultTime1 = StartTime1.ElapsedMilliseconds;
            Console.WriteLine("Matrix: " + ResultTime1);
            var StartTime2 = System.Diagnostics.Stopwatch.StartNew();
            Exam[][] exams2 = new Exam[2][];
            exams2[0] = new Exam[499999];
            for(int i = 0; i < exams2[0].Length; i++)
            {
                exams2[0][i] = new Exam();
            }
            exams2[1] = new Exam[500001];
            for(int i = 0; i < exams2[1].Length; i++)
            {
                exams2[1][i] = new Exam();
            }
            StartTime2.Stop();
            var ResultTime2 = StartTime2.ElapsedMilliseconds;
            Console.WriteLine("Stairs: " + ResultTime2);
        }
        static void Main(string[] args)
        {
            Student student = new Student(new Person("Ivan", "Ivanov", new DateTime(2001, 2, 1)), Education.Bachelor, 302, 13);
            Console.WriteLine(student.ToShortString());
            Console.WriteLine(student[Education.Bachelor]);
            Console.WriteLine(student[Education.Master]);
            Console.WriteLine(student[Education.SecondEducation]);
            Exam[] exams = new Exam[2];
            exams[0] = new Exam("Calculus", 122, new DateTime(2018, 12, 23));
            exams[1] = new Exam("Functional Analisys", 114, new DateTime(2018, 12, 19));
            student.Exams = exams;
            Console.WriteLine(student.ToString());
            Exam[] exams1 = new Exam[2];
            exams1[0] = new Exam("Fractal Geometry", 188, new DateTime(2018, 12, 20));
            exams1[1] = new Exam("Differential Equations", 111, new DateTime(2019, 1, 4));
            student.AddExams(exams1);
            Console.WriteLine(student.ToString());
            TimeCheck();
        }
    }
}
