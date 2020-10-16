namespace Core.Application.PlaceInfo.Locations.Queries.GetCountryCities
{
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCountryCitiesQuery : IRequest<IEnumerable<CityOutputModel>>
    {
        public int CountryId { get; private set; }

        public class GetCountryCitiesRequestHandler : IRequestHandler<GetCountryCitiesQuery, IEnumerable<CityOutputModel>>
        {
            private readonly ICountryQueryRepository countryQueryRepository;

            public GetCountryCitiesRequestHandler(ICountryQueryRepository countryQueryRepository)
            {
                this.countryQueryRepository = countryQueryRepository;
            }

            public async Task<IEnumerable<CityOutputModel>> Handle(
                GetCountryCitiesQuery request,
                CancellationToken cancellationToken)
                => await countryQueryRepository.GetCities(request.CountryId);
        }
    }
}
