namespace Core.Application.Statistics.Handlers
{
    using Common.Application;
    using Core.Domain.PlaceInfo.Events.Places;
    using Core.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class FeedbackAddedDomainEventHandler : IEventHandler<FeedbackAddedDomainEvent>
    {
        private readonly IStatisticDomainRepository statistics;

        public FeedbackAddedDomainEventHandler(IStatisticDomainRepository statistics)
            => this.statistics = statistics;

        public Task Handle(FeedbackAddedDomainEvent domainEvent)
            => this.statistics.IncrementFeedbacks();
    }
}
