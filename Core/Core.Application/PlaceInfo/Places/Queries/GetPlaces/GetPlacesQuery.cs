namespace Core.Application.PlaceInfo.Places.Queries.GetPlaces
{
    using Core.Application.PlaceInfo.Places.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPlacesQuery : IRequest<IEnumerable<PlaceOutputModel>>
    {
        public class GetPlacesQueryHandler : IRequestHandler<GetPlacesQuery, IEnumerable<PlaceOutputModel>>
        {
            private readonly IPlaceQueryRepository placeQueryRepository;

            public GetPlacesQueryHandler(IPlaceQueryRepository placeQueryRepository)
            {
                this.placeQueryRepository = placeQueryRepository;
            }

            public async Task<IEnumerable<PlaceOutputModel>> Handle(
                GetPlacesQuery request,
                CancellationToken cancellationToken)
                => await placeQueryRepository.Get();
        }
    }
}
