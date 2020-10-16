namespace Core.Application.Statistics.Handlers
{
    using Common.Application;
    using Core.Domain.PlaceInfo.Events.Places;
    using Core.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class PlaceAddedDomainEventHandler : IEventHandler<PlaceAddedDomainEvent>
    {
        private readonly IStatisticDomainRepository statistics;

        public PlaceAddedDomainEventHandler(IStatisticDomainRepository statistics)
            => this.statistics = statistics;
        public Task Handle(PlaceAddedDomainEvent domainEvent)
           => this.statistics.IncrementPlaces();

    }
}
