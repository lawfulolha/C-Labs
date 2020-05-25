using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Person
    {

        private string firstName;
        private string surname;
        private DateTime dateOfBirth;

        public Person(string n, string sn, DateTime dateofbirth)
        {
            firstName = n;
            surname = sn;
            dateOfBirth = dateofbirth;
        }

        public Person()
        {
            firstName = "John";
            surname = "Doe";
            dateOfBirth = new DateTime(1999, 1, 1);
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
            get
            {
                return this.surname;
            }
            set
            {
                this.surname = value;
            }
        }

        public DateTime DateOfBirth
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
        public void SetIntDateOfBirth(int day, int month, int year)
        {
            this.dateOfBirth = new DateTime(year, month, day);
        }

        public int GetDayOfBirth()
        {
            return dateOfBirth.Day;
        }

        public int GetMonthOfBirth()
        {
            return dateOfBirth.Month;
        }

        public int GetYearOfBirth()
        {
            return dateOfBirth.Year;
        }

        public override string ToString()
        {
            return this.firstName + " " + this.surname + " " + this.dateOfBirth.ToString();
        }

        public virtual string ToShortString()
        {
            return this.firstName + " " + this.surname;
        }
    }
}
