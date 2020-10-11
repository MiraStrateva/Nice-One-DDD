namespace NiceOne.Domain.PlaceInfo.Factories.Places
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.PlaceInfo.Models.Locations;
    using NiceOne.Domain.PlaceInfo.Models.Places;

    public interface IPlaceFactory : IFactory<Place>
    {
        IPlaceFactory WithName(string name);

        IPlaceFactory WithDescription(string description);

        IPlaceFactory WithLocation(Location location);

        IPlaceFactory WithLocation(string country, string city);

        IPlaceFactory WithCategory(Category category);

        IPlaceFactory WithCategory(string name, string description, string imageUrl);

        IPlaceFactory WithPlaceType(PlaceType placeType);

        IPlaceFactory ByUser(string userId);
    }
}
