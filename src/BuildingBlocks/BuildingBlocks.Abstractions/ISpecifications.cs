namespace BuildingBlocks.Abstractions
{
    public interface ISpecifications
    {
        IQueryable<T> Apply<T>(IQueryable<T> query);
    }
}

// this interface is used in the Reused queries to specify and minimize the query that goes to the Db
// for example, if we have a query that returns a list of products, we can use the specifications to specify that we only want to return the products that are in stock, or the products that are in a specific category, etc. 
// think of it like Where clause in SQL, but in a more reusable and composable way.