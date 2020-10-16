namespace Core.Application.PlaceInfo.Locations.Commands.DeleteCountry
{
    using Common.Application;
    using Core.Domain.PlaceInfo.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCountryCommand : EntityCommand<int>, IRequest<Unit>
    {
        public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Unit>
        {
            private readonly ICountryDomainRepository countryRepository;

            public DeleteCountryCommandHandler(ICountryDomainRepository countryRepository)
            {
                this.countryRepository = countryRepository;
            }

            public async Task<Unit> Handle(
                DeleteCountryCommand request,
                CancellationToken cancellationToken)
            {
                await this.countryRepository.Delete(request.Id);
                return Unit.Value;
            }
        }
    }
}
