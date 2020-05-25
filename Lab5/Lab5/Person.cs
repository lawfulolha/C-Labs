using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{

    [Serializable]
    class Person
    {
        protected string firstName;
        protected string surname;
        protected DateTime dateOfBirth;

        public Person(string name, string surname, DateTime birthdate)
        {
            this.firstName = name;
            this.surname = surname;
            this.dateOfBirth = birthdate;
        }

        public Person()
        {
            firstName = "John";
            surname = "Doe";
            dateOfBirth = new DateTime(1999, 12, 12);
        }


        public string FirstName
        {
            get
            {
                return firstName;
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
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
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


        public override int GetHashCode()
        {
            int hashcode = this.firstName.GetHashCode();
            hashcode = 31 * hashcode + this.surname.GetHashCode();
            hashcode = 31 * hashcode + this.dateOfBirth.GetHashCode();
            return hashcode;
        }

        public virtual DateTime Date
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value;
            }
        }
    }
}