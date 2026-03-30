namespace BuildingBlocks.Abstractions.Time
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        DateTime Now { get; } // why this , cuz in tests we can inject a fake date 
    }

}