namespace Core.Infrastructure.PlaceInfo.Repositories
{
    using AutoMapper;
    using Common.Infrastructure.Persistence;
    using Core.Application.PlaceInfo.Locations;
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using Core.Domain.PlaceInfo.Models.Locations;
    using Core.Domain.PlaceInfo.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CountryRepository : DataRepository<IPlaceInfoDbContext, Country>,
        ICountryDomainRepository,
        ICountryQueryRepository
    {
        private readonly IMapper mapper;

        public CountryRepository(IPlaceInfoDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var country = await Find(id);
            Data.Set<Country>().Remove(country);

            await Data.SaveChangesAsync();
        }

        public async Task<Country> Find(int id, CancellationToken cancellationToken = default)
            => await this.Data.Countries.FindAsync(id);

        public async Task<City> Find(int id, int cityId, CancellationToken cancellationToken = default)
            => await this.Data.Cities.FindAsync(cityId);

        public async Task<IEnumerable<CountryOutputModel>> Get(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<CountryOutputModel>(this.Data.Countries)
                .ToListAsync();

        public async Task<CountryOutputModel> Get(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<CountryOutputModel>(this.Data.Countries)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<CityOutputModel>> GetCities(int countryId)
            => await this.mapper
                .ProjectTo<CityOutputModel>(this.Data.Cities)
                .Where(c => c.CountryId == countryId)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<CityOutputModel> GetCity(int countryId, int cityId)
            => await this.mapper
                .ProjectTo<CityOutputModel>(this.Data.Cities)
                .FirstOrDefaultAsync(c => c.Id == cityId);
    }
}
