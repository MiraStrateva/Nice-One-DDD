namespace Core.Application.PlaceInfo.Locations.Commands.DeleteCountry
{
    using Common.Application;
    using Core.Domain.PlaceInfo.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCountryCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Result>
        {
            private readonly ICountryDomainRepository countryRepository;

            public DeleteCountryCommandHandler(ICountryDomainRepository countryRepository)
            {
                this.countryRepository = countryRepository;
            }

            public async Task<Result> Handle(
                DeleteCountryCommand request,
                CancellationToken cancellationToken)
                => await this.countryRepository.Delete(request.Id);
        }
    }
}
