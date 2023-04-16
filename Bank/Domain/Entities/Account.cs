using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class Account
    {
        public Guid id;
        public string ExternalId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Transaction> transactions;
    }
}