using System;
using System.IO;

namespace ExceptionHandling3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter your birthdate (yyyy-mm-dd): ");
            try
            {
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                int age = CalculateAge(date);
                Console.WriteLine($"Your age is {age} years.");
                canVote(age);
            }
            catch (UnderageVoterException ex)
            {
                string path = "C:\\Users\\ayush.soni\\source\\repos\\VoterCustomException\\ExceptionalHandling3\\logs.txt";
                using (StreamWriter stm = new StreamWriter(path, true))
                {
                    stm.WriteLine(ex.Message + "\t" + DateTime.Now);
                }
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid date format.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private static int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private static void canVote(int age)
        {
            if (age < 18)
                throw new UnderageVoterException("You cannot vote. Please come after " + (18 - age) + " years");
            else Console.WriteLine("Welcome, you can Vote!");
        }
    }

    internal class UnderageVoterException : Exception
    {
        public UnderageVoterException() : base("This is a custom UnderageVoterException")
        {
        }

        public UnderageVoterException(string msg) : base(msg)
        {
        }
    }
}