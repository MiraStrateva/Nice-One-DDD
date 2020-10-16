namespace Core.Domain.PlaceInfo.Factories.Locations
{
    using Common.Domain;
    using Core.Domain.PlaceInfo.Models.Locations;

    public interface ICountryFactory : IFactory<Country>
    {
        ICountryFactory WithName(string name);
    }
}
