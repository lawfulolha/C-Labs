using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(new Person("Volodymyr", "Schevchenko", new DateTime(1999, 2, 25)), Education.Bachelor, 312);
            student.Exams.Add(new Exam("JavaScript", 77, new DateTime(2020, 1, 31)));


            Student studentCopy = student.DeepCopy();

            Console.WriteLine(student.ToString());
            Console.WriteLine(studentCopy.ToString());

            Student student1 = new Student(new Person("Iryna", "Sokil", new DateTime(1999, 10, 2)), Education.Bachelor, 322);
            student1.Exams.Add(new Exam("Calculus", 90, new DateTime(2020, 1, 28)));

            Console.Write("Input file name: ");
            string filename = Console.ReadLine();
            student1.Save(filename);

            Student studentLoad = new Student();
            studentLoad.Load(filename);

            Console.WriteLine(studentLoad.ToString());

            studentLoad.AddFromConsole();
            studentLoad.Save(filename);

            Console.WriteLine(studentLoad.ToString());
        }
    }
}