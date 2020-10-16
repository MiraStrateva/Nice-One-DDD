namespace Core.Application.PlaceInfo.Locations.Queries.GetCountryCity
{
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCountryCityQuery : IRequest<CityOutputModel>
    {
        public int CountryId { get; private set; }
        public int CityId { get; private set; }

        public class GetCountryCityQueryHandler : IRequestHandler<GetCountryCityQuery, CityOutputModel>
        {
            private readonly ICountryQueryRepository countryQueryRepository;

            public GetCountryCityQueryHandler(ICountryQueryRepository countryQueryRepository)
            {
                this.countryQueryRepository = countryQueryRepository;
            }

            public async Task<CityOutputModel> Handle(
                GetCountryCityQuery request,
                CancellationToken cancellationToken)
                => await countryQueryRepository.GetCity(request.CountryId, request.CityId);
        }
    }
}
