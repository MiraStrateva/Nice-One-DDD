namespace NiceOne.Domain.PlaceInfo.Factories.Locations
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.PlaceInfo.Models.Locations;

    public interface ICountryFactory : IFactory<Country>
    {
        ICountryFactory WithName(string name);
    }
}
