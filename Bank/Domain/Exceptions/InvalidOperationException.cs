using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Exceptions
{
    public class InvalidOperationException : GenericException
    {
        public InvalidOperationException()
        {
        }

        public InvalidOperationException(string? message) : base(message)
        {
        }

        public InvalidOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}