namespace Core.Application.PlaceInfo.Locations.Commands.CreateCity
{
    public class CreateCityOutputModel
    {
        public CreateCityOutputModel(int cityId)
            => this.CityId = cityId;

        public int CityId { get; }
    }
}
