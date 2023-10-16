using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling5
{
    public class Person
    {
        public string Name { get; set; }
        private int Age;

        public int getAge()
        {
            return this.Age;
        }

        public void setAge(DateTime dateTime)
        {
            this.Age = CalculateAge(dateTime);
        }

        public DateTime Birthdate { get; set; }

        public void canVote(int age)
        {
            if (age < 18)
                throw new UnderageVoterException("\nYou cannot vote. Your age is: " + this.Age + "\nPlease come after " + (18 - age) + " years " + this.Name + "\n");
            else Console.WriteLine("\nWelcome, you can Vote! " + this.Name + "\n");
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}