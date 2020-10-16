namespace Core.Domain.PlaceInfo.Repositories
{
    using Common.Domain;
    using Core.Domain.PlaceInfo.Models.Locations;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICountryDomainRepository : IDomainRepository<Country>
    {
        Task<Country> Find(int id, CancellationToken cancellationToken = default);
        Task<City> Find(int id, int cityId, CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
    }
}
