using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Person : IDateAndCopy, IComparable<Person>, IComparer<Person>
    {
        protected string firstName;
        protected string surname;
        protected DateTime dateOfBirth;

        public Person(string name, string surname, DateTime datebirth)
        {
            this.firstName = name;
            this.surname = surname;
            this.dateOfBirth = datebirth;
        }

        public Person()
        {
            firstName = "John";
            surname = "Doe";
            dateOfBirth = new DateTime(1999, 2, 12);
        }


        public string FirstName
        {

            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string Surname
        {
            set
            {
                this.surname = value;
            }

            get
            {
                return this.surname;
            }
        }

        public DateTime DateOfBirth
        {
            set
            {
                this.dateOfBirth = value;
            }

            get
            {
                return this.dateOfBirth;
            }
        }

        public void SetIntDateOfBirth(int day, int month, int year)
        {
            dateOfBirth = new DateTime(year, month, day);
        }

        public int GetDay()
        {
            return dateOfBirth.Day;
        }

        public int GetMonth()
        {
            return dateOfBirth.Month;
        }

        public int GetYear()
        {
            return dateOfBirth.Year;
        }

        public override string ToString()
        {
            return firstName + " " + surname + " " + dateOfBirth.ToString();
        }

        public virtual string ToShortString()
        {
            return firstName + " " + surname;
        }
        /*
        public override bool Equals(object obj)
        {
            Person person = (Person)obj;
            return (this.firstName == person.FirstName && this.surname == person.Surname && this.dateOfBirth == person.DateOfBirth);
        }*/

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

        public override int GetHashCode()
        {
            int hashcode = firstName.GetHashCode();
            hashcode = 31 * hashcode + surname.GetHashCode();
            hashcode = 31 * hashcode + dateOfBirth.GetHashCode();
            return hashcode;
        }

        public virtual object DeepCopy()
        {
            Person copy = new Person();
            copy.firstName = firstName;
            copy.surname = surname;
            copy.dateOfBirth = dateOfBirth;
            return (object)copy;
        }

        public virtual DateTime Date
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
            }
        }
       
        public int CompareTo(Person person)
        {
            if (person != null)
            {
                if (this.Surname.Length > person.Surname.Length)
                {
                    return 1;
                }
                else if (this.Surname.Length < person.Surname.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Objects are not comparable");
            }
        }

        public int Compare(Person person1, Person person2)
        {
            if (person1.DateOfBirth > person2.DateOfBirth)
            {
                return 1;
            }
            else if (person1.DateOfBirth < person2.DateOfBirth)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

}
