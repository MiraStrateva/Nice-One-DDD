namespace Core.Application.Statistics.Queries.Current
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetLatestStatisticQuery : IRequest<GetLatestStatisticOutputModel>
    {
        public class GetLatestStatisticQueryHandler : IRequestHandler<GetLatestStatisticQuery, GetLatestStatisticOutputModel>
        {
            private readonly IStatisticQueryRepository statistics;

            public GetLatestStatisticQueryHandler(IStatisticQueryRepository statistics)
                => this.statistics = statistics;

            public Task<GetLatestStatisticOutputModel> Handle(
                GetLatestStatisticQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetCurrent(cancellationToken);
        }
    }
}
