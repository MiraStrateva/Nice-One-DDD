namespace Core.Application.PlaceInfo.Locations.Commands.CreateCountry
{
    public class CreateCountryOutputModel
    {
        public CreateCountryOutputModel(int countryId)
            => this.CountryId = countryId;

        public int CountryId { get; }
    }
}
