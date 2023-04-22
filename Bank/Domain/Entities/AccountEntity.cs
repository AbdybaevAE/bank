namespace Bank.Domain.Entities
{
    public class AccountEntity
    {
        public Guid Id;
        public string ExternalId { get; set; }
        // public List<Transaction> transactions;
    }
}
