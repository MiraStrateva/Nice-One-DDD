namespace Core.Application.PlaceInfo.Locations.Commands.UpdateCountry
{
    using Common.Application;
    using Core.Domain.PlaceInfo.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateCountryCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Result>
        {
            private readonly ICountryDomainRepository countryRepository;

            public UpdateCountryCommandHandler(
                ICountryDomainRepository countryRepository)
            {
                this.countryRepository = countryRepository;
            }

            public async Task<Result> Handle(
                UpdateCountryCommand request,
                CancellationToken cancellationToken)
            {
                var country = await this.countryRepository.Find(
                    request.Id,
                    cancellationToken);

                country
                    .UpdateName(request.Name);

                await this.countryRepository.Save(country, cancellationToken);

                return Result.Success;
            }
        }
    }
}
