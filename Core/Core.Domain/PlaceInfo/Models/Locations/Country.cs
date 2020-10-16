namespace Core.Domain.PlaceInfo.Models.Locations
{
    using Common.Domain;
    using Common.Domain.Models;
    using Core.Domain.PlaceInfo.Exceptions;
    using System.Collections.Generic;
    using System.Linq;
    using static Common.Domain.Models.ModelConstants.Common;

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

        public void AddCity(string name)
        {
            this.cities.Add(new City(name));
        }

        public void RemoveCity(City city)
        {
            this.cities.Remove(city);
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidLocationException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
