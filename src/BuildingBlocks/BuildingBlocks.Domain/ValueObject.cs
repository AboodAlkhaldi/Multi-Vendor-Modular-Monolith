namespace BuildingBlocks.Domain
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode() // to generate a hash code based on the components of the value object
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });

            // Alternative implementation:  (mush easer ) (the job of the .Aggregate )
            //
            // int hash =1;
            // foreach (var obj in GetEqualityComponents())
            // {
            //         hash = hash * 23 + (obj?.GetHashCode() ?? 0);   
            // }
            // return hash;
        }
    }
}