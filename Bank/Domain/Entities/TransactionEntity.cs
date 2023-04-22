namespace Bank.Domain.Entities
{
    public class TransactionEntity
    {
        public Guid Id;
        public TransactionType Type;
        public decimal Amount;
        public AccountEntity account;
    }
}
