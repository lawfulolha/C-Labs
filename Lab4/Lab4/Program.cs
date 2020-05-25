using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection1 = new StudentCollection();
            studentCollection1.CollectionName = "Students1";

            StudentCollection studentCollection2 = new StudentCollection();
            studentCollection2.CollectionName = "Students2";

            Student[] students1 = new Student[]
            {
                new Student(new Person("Alina", "Ivanchuk", new DateTime(2001, 2, 7)), Education.Bachelor, 302),
                new Student(new Person("Serhiy", "Melnyk", new DateTime(1999, 12, 1)), Education.Bachelor, 302),
                new Student(new Person("Andriy", "Andriev", new DateTime(1998, 1, 13)), Education.Bachelor, 322)
            };

            Student[] students2 = new Student[]
            {
                new Student(new Person("Vasyl", "Koval", new DateTime(1999, 2, 12)), Education.Bachelor, 302),
                new Student(new Person("Olha", "Kovinko", new DateTime(1999, 5, 20)), Education.Bachelor, 322),
                new Student(new Person("Petro", "Petrov", new DateTime(2001, 1, 3)), Education.Bachelor, 322)
            };

            studentCollection1.AddStudents(students1);
            studentCollection2.AddStudents(students2);

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            studentCollection1.StudentCountChange += journal1.ProcessStudentCountChange;
            studentCollection2.StudentReferenceChange += journal2.ProcessStudentReferenceChange;

            studentCollection2.StudentCountChange += journal2.ProcessStudentCountChange;
            studentCollection2.StudentReferenceChange += journal2.ProcessStudentReferenceChange;

            studentCollection1[1] = new Student(new Person("Volodymyr", "Schevchenko", new DateTime(1999, 2, 25)), Education.Bachelor, 312);
            studentCollection2[1] = new Student(new Person("Iryna", "Sokil", new DateTime(1999, 10, 2)), Education.Bachelor, 322);

            studentCollection1.AddStudents(new Student[] { new Student(new Person("Roman", "Karpiv", new DateTime(2000, 1, 16)), Education.Bachelor, 312) });
            studentCollection2.AddStudents(new Student[] { new Student(new Person("Kyrylo", "Kaplenko", new DateTime(2001, 12, 30)), Education.Bachelor, 312) });

            studentCollection1.Remove(0);
            studentCollection2.Remove(0);

            Console.WriteLine(journal1.ToString());
            Console.WriteLine();
            Console.WriteLine(journal2.ToString());
        }
    }
}
