namespace BuildingBlocks.Abstractions;

public interface IIntegrationEvent
{

    Guid EventId { get; }
    DateTime OccurrenceAt { get; }
}
