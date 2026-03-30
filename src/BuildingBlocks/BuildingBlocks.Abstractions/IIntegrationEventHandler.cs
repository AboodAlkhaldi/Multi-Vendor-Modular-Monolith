using BuildingBlocks.Abstractions;

namespace BuildingBlocks.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> where TIntegrationEvent : IIntegrationEvent
    {
        Task HandleAsync(TIntegrationEvent @event, CancellationToken cancellationToken = default);
    }
}