namespace Bank.Controllers.DTO
{
    public class CreateAccountRequestBody
    {
        public string ExternalId { get; set; }
        public bool IsBlocked { get; set; }
    }
}