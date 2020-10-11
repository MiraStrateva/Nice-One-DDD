namespace NiceOne.Domain.Statistics.Repositories
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticsDomainRepository : IDomainRepository<Statistics>
    {
        Task IncrementPlaces(CancellationToken cancellationToken = default);
        Task IncrementFeedbacks(CancellationToken cancellationToken = default);
    }
}
