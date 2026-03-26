using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.EntityFrameWorkCore;

namespace BuildingBlocks.Data
{
    public class AppDbContext(EventBus _eventBus) : DbContext
    {
        private readonly EventBus _eventBus;
        protected AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker
                .Entries<AggregateRoot>()
                .Select(e=>e.Entity)
                .Where(e=>e.DomainEvents.Any())
                .SelectMany(e=>e.DomainEvents)
                .ToList();

            var result = await base.SaveChangesAsync(cancellationToken);

            if(_eventBus != null)
            {
                foreach(var domainEvent in domainEvents)
                {
                    await _eventBus.Publish(domainEvent, cancellationToken);
                }
            }

            ChangeTracker
                .Entries<AggaregateRoot>()
                .Select(e=>e.Entity)
                .ToList()
                .ForEach(e=>e.ClearDomainEvents());

            return result;
        }


        // Common Modules Configurations 
        public void ConfigureBaseEntities(ModelBuilder modelBuilder)
        {
            // Soft Deletion 
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter,nameof(ISoftDelete.IsDeleted));
                    var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);
                    
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }


        }
    }
}