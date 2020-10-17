namespace Core.Infrastructure.Statistics
{
    using Microsoft.Extensions.DependencyInjection;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddStatisticsInfrastructure(this IServiceCollection services)
            => services
                .AddScoped<IStatisticsDbContext>(provider => provider.GetService<StatisticsDbContext>());
    }
}
