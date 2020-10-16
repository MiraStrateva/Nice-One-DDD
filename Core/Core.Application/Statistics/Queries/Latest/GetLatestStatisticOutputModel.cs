namespace Core.Application.Statistics.Queries.Current
{
    using AutoMapper;
    using Common.Application.Mapping;
    using Core.Domain.Statistics.Models;

    public class GetLatestStatisticOutputModel : IMapFrom<Statistics>
    {
        public int TotalPlaces { get; private set; }

        public int TotalFeedbacks { get; private set; }

        public int TotalPlaceViews { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Statistics, GetLatestStatisticOutputModel>()
                .ForMember(cs => cs.TotalPlaces, cfg => cfg
                    .MapFrom(s => s.PlaceViews.Count));
    }
}
