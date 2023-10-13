using System;
using System.IO;

namespace ExceptionHandling4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter your Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your birthdate (yyyy-mm-dd): ");
            int age = 0;
            try
            {
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                age = CalculateAge(date);
                Console.WriteLine($"Your age is {age} years.");
                canVote(age);
            }
            catch (UnderageVoterException ex)
            {
                string path = "C:\\Users\\ayush.soni\\source\\repos\\VoterCustomException\\ExceptionHandling4\\error-report\\" + DateTime.Now.ToString("dd MMM yyyy hh mm tt") + ".log";
                using (StreamWriter stm = new StreamWriter(path, true))
                {
                    stm.WriteLine("Name = " + name + ",\t\t" +
                                "Age = " + age + "\t\t" +
                                DateTime.Now + "\n" +
                                ex.Message + "\n" +
                                "------------------------------------------------------------------------------------");
                }
                Console.WriteLine(ex.Message);
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