namespace Core.Application.PlaceInfo.Places.Queries.GetPlacesByCategory
{
    using Core.Application.PlaceInfo.Places.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPlacesByCategoryQuery : IRequest<IEnumerable<PlaceOutputModel>>
    {
        public int CategoryId { get; set; }

        public class GetPlacesByCategoryQueryHandler : IRequestHandler<
            GetPlacesByCategoryQuery,
            IEnumerable<PlaceOutputModel>>
        {
            private readonly IPlaceQueryRepository placeRepository;

            public GetPlacesByCategoryQueryHandler(IPlaceQueryRepository placeRepository)
                => this.placeRepository = placeRepository;

            public async Task<IEnumerable<PlaceOutputModel>> Handle(
                GetPlacesByCategoryQuery request,
                CancellationToken cancellationToken)
                => await this.placeRepository.GetByCategory(request.CategoryId, cancellationToken);
        }
    }
}
