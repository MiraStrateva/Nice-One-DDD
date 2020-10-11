namespace NiceOne.Domain.PlaceInfo.Models.Locations
{
    using NiceOne.Domain.Common.Models;
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using static NiceOne.Domain.Common.Models.ModelConstants.Common;

    public class City : Entity<int>
    {
        internal City(string name)
        {
            this.Validate(name);

            this.Name = name;
        }
        public string Name { get; private set; }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidLocationException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }
    }
}
