namespace NiceOne.Domain.PlaceInfo.Factories.Places
{
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using NiceOne.Domain.PlaceInfo.Models.Locations;
    using NiceOne.Domain.PlaceInfo.Models.Places;

    internal class PlaceFactory : IPlaceFactory
    {
        private string name = default!;
        private string description = default!;
        private Location location = default!;
        private Category category = default!;
        private PlaceType placeType = default!;
        private string userId = default!;

        private bool categorySet = false;
        private bool locationSet = false;

        public IPlaceFactory ByUser(string userId)
        {
            this.userId = userId;
            return this;
        }

        public IPlaceFactory WithCategory(Category category)
        {
            this.category = category;
            this.categorySet = true;
            return this;
        }

        public IPlaceFactory WithCategory(string name, string description, string imageUrl)
            => this.WithCategory(new Category(name, description, imageUrl));

        public IPlaceFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IPlaceFactory WithLocation(Location location)
        {
            this.location = location;
            this.locationSet = true;
            return this;
        }

        public IPlaceFactory WithLocation(Country country, City city)
            => this.WithLocation(new Location(country, city));

        public IPlaceFactory WithLocation(string countryName, string cityName)
            => this.WithLocation(new Location(new Country(countryName), new City(cityName)));

        public IPlaceFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IPlaceFactory WithPlaceType(PlaceType placeType)
        {
            this.placeType = placeType;
            return this;
        }

        public Place Build()
        {
            if (!this.categorySet || !this.locationSet)
            {
                throw new InvalidPlaceException("Category and location must have a value.");
            }

            return new Place(
                this.name,
                this.description,
                this.userId,
                this.location,
                this.category,
                this.placeType);
        }
    }
}
