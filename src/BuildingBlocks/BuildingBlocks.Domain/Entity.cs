namespace BuildingBlocks.Domain
{
    public abstract class Entity<TId> where TId : notnull
    {
        public TId Id { get; protected set;}

        /// At the next method because we well use DDD we must compare the Ids by the value 
        // not by memory (if the tow Ids has the same Guid so they are the same 
        // regardless where did they came from {from DB or Api or etc..} )
        public override bool Equals(object? obj) 
        {
            if (obj is not Entity<TId> other)
               return false;

            if (ReferenceEquals(this, other))
                return true;

            if(Id.Equals(default!) || other.Id.Equals(default!))
                return false;
            
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}