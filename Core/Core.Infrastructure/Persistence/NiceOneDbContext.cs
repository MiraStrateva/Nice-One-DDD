namespace Core.Infrastructure.Persistence
{
    using Common.Domain.Models;
    using Common.Infrastructure.Events;
    using Core.Domain.PlaceInfo.Models.Categories;
    using Core.Domain.PlaceInfo.Models.Locations;
    using Core.Domain.PlaceInfo.Models.Places;
    using Core.Domain.Statistics.Models;
    using Core.Infrastructure.PlaceInfo;
    using Core.Infrastructure.Statistics;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NiceOneDbContext : IdentityDbContext<User>,
        IPlaceInfoDbContext,
        IStatisticDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;

        public NiceOneDbContext(
            DbContextOptions<NiceOneDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Country> Countries { get; set; } = default!;

        public DbSet<City> Cities { get; set; } = default!;

        public DbSet<Feedback> Feedbacks { get; set; } = default!;

        public DbSet<Place> Places { get; set; } = default!;

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<PlaceView> PlaceViews { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
