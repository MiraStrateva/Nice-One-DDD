namespace Core.Infrastructure.Statistics
{
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddStatisticsInfrastructure(this IServiceCollection services)
            => services
                .AddScoped<IStatisticDbContext>(provider => provider.GetService<StatisticDbContext>());
    }
}
