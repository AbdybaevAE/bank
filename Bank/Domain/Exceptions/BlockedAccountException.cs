namespace Bank.Domain.Exceptions
{
    public class BlockedAccountException : GenericException
    {
        public BlockedAccountException()
        {
        }

        public BlockedAccountException(string? message) : base(message)
        {
        }

        public BlockedAccountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}