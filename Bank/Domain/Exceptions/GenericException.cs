using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException() : base()
        {
        }

        public GenericException(string? message) : base(message)
        {
        }

        public GenericException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}