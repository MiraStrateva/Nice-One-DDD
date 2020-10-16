namespace Core.Domain.Statistics.Repositories
{
    using Common.Domain;
    using Core.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticDomainRepository : IDomainRepository<Statistics>
    {
        Task IncrementPlaces(CancellationToken cancellationToken = default);
        Task IncrementFeedbacks(CancellationToken cancellationToken = default);
    }
}
