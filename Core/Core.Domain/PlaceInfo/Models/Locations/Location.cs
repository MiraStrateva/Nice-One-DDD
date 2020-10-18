namespace Core.Domain.PlaceInfo.Models.Locations
{
    using Common.Domain.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [NotMapped]
    public class Location : ValueObject
    {
        internal Location(Country country, City city)
        {
            Validate(country, city);
            Country = country;
            City = city;
        }

        public Country Country { get; }

        public City City { get; }

        private void Validate(Country country, City city)
        {
            if (country.Cities.Contains(city))
            {
                return;
            }

            throw new Exception("");
        }
    }
}
