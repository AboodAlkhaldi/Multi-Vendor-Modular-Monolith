namespace BuildingBlocks.Domain
{
    public abstract class AggregateRoot : Entity
    {
        private List<IDomainEvent> _domainEvents = new List<iDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }


    }
}