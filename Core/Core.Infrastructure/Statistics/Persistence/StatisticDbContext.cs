namespace Core.Infrastructure.Statistics.Persistence
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class StatisticDbContext : DbContext,
        IStatisticDbContext
    {
        public StatisticDbContext(DbContextOptions<StatisticDbContext> options)
            : base(options)
        {
        }

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<PlaceView> PlaceViews { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
