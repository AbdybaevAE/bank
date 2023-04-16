using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class Transaction
    {
        public Guid Id;
        public TransactionType Type;
        public decimal Amount;
        public Account account;
    }
}