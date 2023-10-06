using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age : ");
            int age =Convert.ToInt32(Console.ReadLine());
            try
            {
                canVote(age);
            }catch (UnderageVoterException ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }


        static void canVote(int age)
        {
            if (age < 18) {
                throw new UnderageVoterException("You cannot vote. Please come after "+ (18 - age) + " years");
            }
            else {
                Console.WriteLine("Welcome, you can Vote!");
            }
        }
    }

    class UnderageVoterException : Exception
    {
        public UnderageVoterException() : base("This is a custom UnderageVoterException") { }
        public UnderageVoterException(string msg) : base(msg) { }
       
    }


}
