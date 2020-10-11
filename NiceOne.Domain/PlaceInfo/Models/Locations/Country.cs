namespace NiceOne.Domain.PlaceInfo.Models.Locations
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.Common.Models;
    using NiceOne.Domain.PlaceInfo.Events;
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using System.Collections.Generic;
    using System.Linq;
    using static NiceOne.Domain.Common.Models.ModelConstants.Common;

    public class Country : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<City> cities;

        internal Country(string name)
        {
            this.Validate(name);

            this.Name = name;

            this.cities = new HashSet<City>();
        }

        public string Name { get; private set; }

        public Country UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public IReadOnlyCollection<City> Cities => this.cities.ToList().AsReadOnly();

        public void AddCity(City city)
        {
            this.cities.Add(city);

            this.AddEvent(new CityAddedEvent());
        }

        public void RemoveCity(City city)
        {
            this.cities.Remove(city);

            this.AddEvent(new CityRemovedEvent());
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidLocationException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
