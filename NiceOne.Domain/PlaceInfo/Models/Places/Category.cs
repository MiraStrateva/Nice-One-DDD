namespace NiceOne.Domain.PlaceInfo.Models.Places
{
    using NiceOne.Domain.Common.Models;
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using static NiceOne.Domain.Common.Models.ModelConstants.Common;

    public class Category : Entity<int>
    {
        internal Category(string name, string description, string imageUrl)
        {
            this.Validate(name, description, imageUrl);

            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }

        private void Validate(string name, string description, string imageUrl)
        {
            Guard.ForStringLength<InvalidPlaceException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidPlaceException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

            Guard.ForValidUrl<InvalidPlaceException>(
                imageUrl,
                nameof(this.ImageUrl));
        }
    }
}
