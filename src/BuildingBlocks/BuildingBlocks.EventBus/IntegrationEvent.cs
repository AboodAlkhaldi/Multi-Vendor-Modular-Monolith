namespace BuildingBlocks.EventBus;

public abstract record IntegrationEvent : IIntegrationEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime OccurrenceAt { get; init; } = DateTime.UtcNow;
}
