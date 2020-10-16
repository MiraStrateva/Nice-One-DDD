namespace Core.Application.PlaceInfo.Locations.Queries.GetCountry
{
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCountryQuery : IRequest<CountryOutputModel>
    {
        public int Id { get; private set; }

        public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryOutputModel>
        {
            private readonly ICountryQueryRepository countryQueryRepository;

            public GetCountryQueryHandler(ICountryQueryRepository countryQueryRepository)
            {
                this.countryQueryRepository = countryQueryRepository;
            }

            public async Task<CountryOutputModel> Handle(
                GetCountryQuery request,
                CancellationToken cancellationToken)
                => await countryQueryRepository.Get(request.Id, cancellationToken);
        }
    }
}
