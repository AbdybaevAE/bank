namespace Bank.Services
{
    public record CreateAccountIn(string ExternalId);
    public record CreateAccountOut(string ExternalId);

    public interface IAccountService
    {
        Task<CreateAccountOut> CreateAccount(CreateAccountIn args);
    }
}