using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Exceptions
{
    public class AccountNotFoundException : GenericException
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(string? message) : base(message)
        {
        }

        public AccountNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}