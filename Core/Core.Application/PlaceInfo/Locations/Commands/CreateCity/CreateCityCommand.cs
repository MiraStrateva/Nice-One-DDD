namespace Core.Application.PlaceInfo.Locations.Commands.CreateCity
{
    using Core.Domain.PlaceInfo.Repositories;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCityCommand : IRequest<CreateCityOutputModel>
    {
        public string Name { get; set; } = default!;
        public int CountryId { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityOutputModel>
        {
            private readonly ICountryDomainRepository countryDomainRepository;

            public CreateCityCommandHandler(ICountryDomainRepository countryDomainRepository)
            {
                this.countryDomainRepository = countryDomainRepository;
            }

            public async Task<CreateCityOutputModel> Handle(
                CreateCityCommand request,
                CancellationToken cancellationToken)
            {
                var country = await countryDomainRepository.Find(request.CountryId);
                country.AddCity(request.Name);

                await this.countryDomainRepository.Save(country, cancellationToken);
                var city = country.Cities.Single(city => city.Name == request.Name);

                return new CreateCityOutputModel(city.Id);
            }
        }
    }
}
