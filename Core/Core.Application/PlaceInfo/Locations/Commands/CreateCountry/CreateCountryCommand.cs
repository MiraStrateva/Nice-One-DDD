namespace Core.Application.PlaceInfo.Locations.Commands.CreateCountry
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Domain.PlaceInfo.Factories.Locations;
    using Core.Domain.PlaceInfo.Repositories;
    using MediatR;

    public class CreateCountryCommand : IRequest<CreateCountryOutputModel>
    {
        public string Name { get; set; } = default!;

        public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreateCountryOutputModel>
        {
            private readonly ICountryFactory countryFactory;
            private readonly ICountryDomainRepository countryRepository;

            public CreateCountryCommandHandler(
                ICountryFactory countryFactory,
                ICountryDomainRepository countryRepository)
            {
                this.countryFactory = countryFactory;
                this.countryRepository = countryRepository;
            }

            public async Task<CreateCountryOutputModel> Handle(
                CreateCountryCommand request,
                CancellationToken cancellationToken)
            {
                var country = this.countryFactory
                    .WithName(request.Name)
                    .Build();

                await this.countryRepository.Save(country, cancellationToken);

                return new CreateCountryOutputModel(country.Id);
            }
        }
    }
}
