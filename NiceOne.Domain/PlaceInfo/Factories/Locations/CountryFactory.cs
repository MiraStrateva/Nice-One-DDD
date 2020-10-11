namespace NiceOne.Domain.PlaceInfo.Factories.Locations
{
    using NiceOne.Domain.PlaceInfo.Models.Locations;

    internal class CountryFactory : ICountryFactory
    {
        private string countryName = default!;

        public ICountryFactory WithName(string name)
        {
            this.countryName = name;
            return this;
        }

        public Country Build() => new Country(this.countryName);
    }
}
