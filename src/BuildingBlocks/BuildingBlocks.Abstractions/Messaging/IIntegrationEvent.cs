namespace BuildingBlocks.Abstractions.Messaging
{   
    public interface IIntegrationEvent
    {
       Guid EventId { get; }
        DateTime OccurrenceAt { get; }
    }
}
