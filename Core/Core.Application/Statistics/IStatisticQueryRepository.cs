namespace Core.Application.Statistics
{
    using Common.Application.Contracts;
    using Domain.Statistics.Models;
    using Queries.Current;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticQueryRepository : IQueryRepository<Statistics>
    {
        Task<GetLatestStatisticOutputModel> GetCurrent(CancellationToken cancellationToken = default);

        Task<int> GetPlaceViews(int placeId, CancellationToken cancellationToken = default);
    }
}
