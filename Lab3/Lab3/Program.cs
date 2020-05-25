using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection collection = new StudentCollection();

            Person person1 = new Person("Ernar", "Kadyrbekov", new DateTime(1999, 1, 21));
            Person person2 = new Person("Roman", "Krit", new DateTime(1998, 11, 1 ));
            Person person3 = new Person("French", "Montana", new DateTime(1998, 2,  6));
            Person person4 = new Person("Fifty", "Cent", new DateTime(2000, 2, 13));

            Student student1 = new Student(person1, Education.Bachelor, 302);
            Student student2 = new Student(person2, Education.Bachelor, 302);
            Student student3 = new Student(person3, Education.Bachelor, 302);
            Student student4 = new Student(person4, Education.Bachelor, 302);

            student1.Tests = new System.Collections.Generic.List<Test>
            {
                new Test("Calculus", true),
                new Test("Algebra", true),
                new Test("Differential Equations", true)
            };

            student2.Tests = new System.Collections.Generic.List<Test>
            {
                   new Test("Calculus", true),
                new Test("Algebra", true),
                new Test("Differential Equations", true)
            };

            student3.Tests = new System.Collections.Generic.List<Test>
            {
                  new Test("Calculus", true),
                new Test("Algebra", true),
                new Test("Differential Equations", true)
            };

            student4.Tests = new System.Collections.Generic.List<Test>
            {
                  new Test("Calculus", true),
                new Test("Algebra", true),
                new Test("Differential Equations", true)
            };


            student1.Exams = new System.Collections.Generic.List<Exam>
            {
                new Exam("JavaScript", 77, new DateTime(2020, 1, 31)),
                new Exam("Web-Design", 95, new DateTime(2020, 1, 28)),
                new Exam("Economics", 81, new DateTime(2020, 1, 25))
            };

            student2.Exams = new System.Collections.Generic.List<Exam>
            {
                new Exam("JavaScript", 77, new DateTime(2020, 1, 31)),
                new Exam("Web-Design", 95, new DateTime(2020, 1, 28)),
                new Exam("Economics", 81, new DateTime(2020, 1, 25))
            };

            student3.Exams = new System.Collections.Generic.List<Exam>
            {
               new Exam("JavaScript", 77, new DateTime(2020, 1, 31)),
                new Exam("Web-Design", 95, new DateTime(2020, 1, 28)),
                new Exam("Economics", 81, new DateTime(2020, 1, 25))
            }; 

            student4.Exams = new System.Collections.Generic.List<Exam>
            {
                new Exam("JavaScript", 77, new DateTime(2020, 1, 31)),
                new Exam("Web-Design", 95, new DateTime(2020, 1, 28)),
                new Exam("Economics", 81, new DateTime(2020, 1, 25))
            };

            Student[] students = new Student[4];
            students[0] = student1;
            students[1] = student2;
            students[2] = student3;
            students[3] = student4;

            collection.AddStudents(students);

            Console.WriteLine(collection.ToString()+"\n");

            collection.SurnameSort();
            Console.WriteLine(collection.ToString() + "\n"); 

            collection.DateOfBirthSort();
            Console.WriteLine(collection.ToString() + "\n");

            collection.AverageMarkSort();
            Console.WriteLine(collection.ToString() + "\n");

            Console.WriteLine(collection.MaxAverageMark + "\n" );

            Console.WriteLine(collection.Master.Cast<object>().ToList().ToString() + "\n");

            Console.WriteLine(collection.AverageMarkGroup(80).ToString() + "\n");

            List<Person> people = new List<Person>() {
                person1,
                person2,
                person3,
                person4
            };

            List<string> vs = new List<string>()
            {
                "Ernar",
                "Roman",
                "French",
                "Fifty"
            };

            Dictionary<Person, Student> pairs = new Dictionary<Person, Student>();
            pairs.Add(person1, student1);
            pairs.Add(person2, student2);
            pairs.Add(person3, student3);
            pairs.Add(person4, student4);

            Dictionary<string, Student> pairs1 = new Dictionary<string, Student>();
            pairs1.Add("Ernar", student1);
            pairs1.Add("Roman", student2);
            pairs1.Add("French", student3);
            pairs1.Add("Fifty", student4);

            TestCollections test = new TestCollections(people, vs, pairs, pairs1);

            test.CheckTimePersonList(0); 
            test.CheckTimePersonList(2); 
            test.CheckTimePersonList(4); 
            test.CheckTimePersonList(7);

            Console.WriteLine();
            test.CheckTimeStringList(0); 
            test.CheckTimeStringList(2); 
            test.CheckTimeStringList(4); 
            test.CheckTimeStringList(7);

            Console.WriteLine();
            test.CheckTimeDictionaryPersonKey(person1); 
            test.CheckTimeDictionaryPersonKey(person3);
            test.CheckTimeDictionaryPersonValue(student1);
            test.CheckTimeDictionaryPersonValue(student3);
            Console.WriteLine();

            test.CheckTimeDictionaryStringKey("Ernar");
            
            test.CheckTimeDictionaryStringKey("French");
            test.CheckTimeDictionaryStringKey("Fifty");
            Console.WriteLine();

            test.CheckTimeDictionaryStringValue(student1);
            test.CheckTimeDictionaryStringValue(student3);
            Console.WriteLine();
        }
    }
}
