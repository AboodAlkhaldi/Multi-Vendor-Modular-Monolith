namespace BuildingBlocks.Abstractions.Messaging
{
    public interface IEventBus
    {
        Task PublishAsync<TIntegrationEvent>(TIntegrationEvent @event , CancellationToken cancellationToken = default) 
            where TIntegrationEvent : IIntegrationEvent;

        void Subscribe<TIntegrationEvent, TIntegrationEventHandler>()
            where TIntegrationEvent : IIntegrationEvent
            where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;
    }
}