namespace Core.Infrastructure.Statistics
{
    using Common.Infrastructure.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    internal interface IStatisticDbContext : IDbContext
    {
        DbSet<Statistics> Statistics { get; }

        DbSet<PlaceView> PlaceViews { get; }
    }
}
