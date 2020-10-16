namespace Core.Domain.PlaceInfo.Models.Locations
{
    using Common.Domain.Models;
    using Core.Domain.PlaceInfo.Exceptions;
    using static Common.Domain.Models.ModelConstants.Common;

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
