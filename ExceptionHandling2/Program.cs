using System;


namespace ExceptionHandling2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your birthdate (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthdate))
            {
                // Calculate age
                int age = CalculateAge(birthdate);
                Console.WriteLine($"Your age is {age} years.");
                try
                {
                    canVote(age);
                }
                catch (UnderageVoterException ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }

           
        }

        static int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }

        static void canVote(int age)
        {
            if (age < 18)
                throw new UnderageVoterException("You cannot vote. Please come after " + (18 - age) + " years");
            else Console.WriteLine("Welcome, you can Vote!"); 
        }
    }

    class UnderageVoterException : Exception
    {
        public UnderageVoterException() : base("This is a custom UnderageVoterException") { }
        public UnderageVoterException(string msg) : base(msg) { }

    }


}
