namespace NiceOne.Domain.PlaceInfo.Models.Locations
{
    using NiceOne.Domain.Common.Models;
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using static NiceOne.Domain.Common.Models.ModelConstants.Common;

    public class City
    {
        internal City(string name)
        {
            this.Validate(name);

            this.Name = name;
        }
        public string Name { get; }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidCityException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }
    }
}
