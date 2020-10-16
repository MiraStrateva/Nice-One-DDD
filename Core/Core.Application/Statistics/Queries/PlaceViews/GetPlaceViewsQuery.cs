namespace Core.Application.Statistics.Queries.PlaceViews
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPlaceViewsQuery : IRequest<int>
    {
        public int PlaceId { get; set; }

        public class GetPlaceViewsQueryHandler : IRequestHandler<GetPlaceViewsQuery, int>
        {
            private readonly IStatisticQueryRepository statistics;

            public GetPlaceViewsQueryHandler(IStatisticQueryRepository statistics)
                => this.statistics = statistics;

            public Task<int> Handle(
                GetPlaceViewsQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetPlaceViews(request.PlaceId, cancellationToken);
        }
    }
}
