namespace Core.Application.PlaceInfo.Locations.Queries.GetCountries
{
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCountriesQuery : IRequest<IEnumerable<CountryOutputModel>>
    {
        public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryOutputModel>>
        {
            private readonly ICountryQueryRepository countryQueryRepository;

            public GetCountriesQueryHandler(ICountryQueryRepository countryQueryRepository)
            {
                this.countryQueryRepository = countryQueryRepository;
            }

            public async Task<IEnumerable<CountryOutputModel>> Handle(
                GetCountriesQuery request, 
                CancellationToken cancellationToken)
                => await countryQueryRepository.Get(cancellationToken);
        }
    }
}
