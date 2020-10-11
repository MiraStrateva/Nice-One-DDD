namespace NiceOne.Domain.PlaceInfo.Repositories
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.PlaceInfo.Models.Locations;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICountryDomainRepository : IDomainRepository<Country>
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<City>> GetCities(int countryId);
        Task<City> GetCity(int id);
    }
}
