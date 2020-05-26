using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        private static void KeyListener()
        {
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q || key == ConsoleKey.F10)
                {
                    Environment.Exit(0);
                }
                if (key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {

            Human[] people_array = { new Botan("Bob"), new Student("Rick"),new Student("Joe"), new Girl("Pam"),
                new PrettyGirl("Jill"), new SmartGirl("Sandy")};
            for (int i = 0; i < 6; i++)
            {
                var first = people_array[UniqueRandom.Instance.Next(people_array.Length)];
                var second = people_array[UniqueRandom.Instance.Next(people_array.Length)];
                var couple = CoupleAttribute.Couple(first, second);
                Console.WriteLine($" {first.GetType().Name} {first.Name} + {second.GetType().Name} {second.Name} " + couple.GetType().Name);
                try
                {
                    Console.WriteLine(couple.Name + "   " + couple.GetType().Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Program.KeyListener();
            }
        }
    }
}