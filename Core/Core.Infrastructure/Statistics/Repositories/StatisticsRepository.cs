namespace Core.Infrastructure.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Statistics;
    using Application.Statistics.Queries.Current;
    using AutoMapper;
    using Common.Infrastructure.Persistence;
    using Domain.Statistics.Models;
    using Domain.Statistics.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class StatisticsRepository : DataRepository<IStatisticDbContext, Statistics>,
        IStatisticDomainRepository,
        IStatisticQueryRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(IStatisticDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<GetLatestStatisticOutputModel> GetCurrent(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetLatestStatisticOutputModel>(this.All())
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<int> GetPlaceViews(int placeId, CancellationToken cancellationToken = default)
            => await this.Data
                .PlaceViews
                .CountAsync(pv => pv.PlaceId == placeId, cancellationToken);

        public async Task IncrementPlaces(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddPlace();

            await this.Save(statistics, cancellationToken);
        }

        public async Task IncrementFeedbacks(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddFeedback();

            await this.Save(statistics, cancellationToken);
        }
    }
}
