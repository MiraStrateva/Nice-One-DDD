using Common.Application.Mapping;
using Core.Domain.PlaceInfo.Models.Locations;

namespace Core.Application.PlaceInfo.Locations.Queries.Common
{
    public class CountryOutputModel : IMapFrom<Country>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
