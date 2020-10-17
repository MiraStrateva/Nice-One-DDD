namespace Core.Infrastructure.Statistics.Persistence
{
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class StatisticsDbContext : DbContext,
        IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
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
