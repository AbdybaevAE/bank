namespace Bank.EventStore.Models.Event
{
    public enum EventType
    {
        AmountDebited,
        AmountCredited,
        AccountCreated,
        AccountUpdated,
        AccountDeleted,
        AccountBlocked
    }
}
