using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling5
{
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