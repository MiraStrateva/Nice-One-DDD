namespace Core.Domain.PlaceInfo.Factories.Places
{
    using Common.Domain;
    using Core.Domain.PlaceInfo.Models.Locations;
    using Core.Domain.PlaceInfo.Models.Places;

    public interface IPlaceFactory : IFactory<Place>
    {
        IPlaceFactory WithName(string name);

        IPlaceFactory WithDescription(string description);

        IPlaceFactory WithLocation(Location location);

        IPlaceFactory WithLocation(string country, string city);

        IPlaceFactory WithCategory(int categoryId);

        IPlaceFactory WithPlaceType(PlaceType placeType);

        IPlaceFactory ByUser(string userId);
    }
}
