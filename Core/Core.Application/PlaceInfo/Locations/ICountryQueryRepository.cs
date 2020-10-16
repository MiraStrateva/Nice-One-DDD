namespace Core.Application.PlaceInfo.Locations
{
    using Common.Application.Contracts;
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using Core.Domain.PlaceInfo.Models.Locations;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICountryQueryRepository : IQueryRepository<Country>
    {
        Task<IEnumerable<CountryOutputModel>> Get(CancellationToken cancellationToken = default);
        Task<CountryOutputModel> Get(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CityOutputModel>> GetCities(int countryId);
        Task<CityOutputModel> GetCity(int countryId, int cityId);
    }
}
