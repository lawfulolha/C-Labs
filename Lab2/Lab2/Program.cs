using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Les", "Podervlansky", new DateTime(1998, 1, 2));
            Person person2 = new Person("Les", "Podervlansky", new DateTime(1998, 1, 2));
            if (person1.Equals(person2))
            {
                Console.WriteLine("Are equal.");
            }
            else
            {
                Console.WriteLine("Are not equal.");
            }
            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person2.GetHashCode());


            Student student = new Student(person1, Education.Bachelor, 302);
            System.Collections.ArrayList tests = new System.Collections.ArrayList();
            tests.Add(new Test("Calculus", true));
            tests.Add(new Test("Differential Equations", true));
            tests.Add(new Test("Algebra", true));
            student.Testss = tests;
            System.Collections.ArrayList exams = new System.Collections.ArrayList();
            exams.Add(new Exam("JavaScript", 77, new DateTime(2020, 1, 31)));
            exams.Add(new Exam("Web-Design", 95, new DateTime(2020, 1, 28)));
            exams.Add(new Exam("Economics", 81, new DateTime(2020, 1, 25)));
            student.Examss = exams;
            Console.WriteLine(student.ToString());


            Console.WriteLine(student.Info.FirstName );
            Console.WriteLine(student.Info.Surname);
            Console.WriteLine(student.Info.DateOfBirth.ToString());

            Student studentCopy = (Student)student.DeepCopy();
            student.FirstName = "Les";
            student.Surname = "Claypool";
            student.DateOfBirth = new DateTime(1996, 1, 2);
            if (student == studentCopy)
            {
                Console.WriteLine("Error occured");
            }
            else
            {
                Console.WriteLine("Are not equal.");
            }


            try
            {
                student.GroupNumber  = 30;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            foreach (Exam exam in student.GetEnumeratorMoreThan(80))
            {
                Console.WriteLine(exam.Mark);
            }
        }
    }
}