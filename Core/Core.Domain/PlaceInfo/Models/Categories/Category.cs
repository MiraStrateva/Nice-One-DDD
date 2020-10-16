namespace Core.Domain.PlaceInfo.Models.Categories
{
    using Common.Domain;
    using Common.Domain.Models;
    using Core.Domain.PlaceInfo.Events.Places;
    using Core.Domain.PlaceInfo.Exceptions;
    using Core.Domain.PlaceInfo.Models.Places;
    using System.Collections.Generic;
    using System.Linq;
    using static Common.Domain.Models.ModelConstants.Common;

    public class Category : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Place> places;

        internal Category(string name, string description, string imageUrl)
        {
            this.Validate(name, description, imageUrl);

            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;

            this.places = new HashSet<Place>();
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }

        public IReadOnlyCollection<Place> Places => this.places.ToList().AsReadOnly();

        public Category UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        public Category UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public Category UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            return this;
        }

        public void AddPlace(Place place)
        {
            this.places.Add(place);

            this.AddEvent(new PlaceAddedDomainEvent());
        }

        private void Validate(string name, string description, string imageUrl)
        {
            ValidateName(name);
            ValidateDescription(description);
            ValidateImageUrl(imageUrl);
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidCategoryException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidCategoryException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidCategoryException>(
                imageUrl,
                nameof(this.ImageUrl));
    }
}