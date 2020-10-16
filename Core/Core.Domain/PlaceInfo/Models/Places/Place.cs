namespace Core.Domain.PlaceInfo.Models.Places
{
    using Common.Domain;
    using Common.Domain.Models;
    using Core.Domain.PlaceInfo.Events.Places;
    using Core.Domain.PlaceInfo.Exceptions;
    using Core.Domain.PlaceInfo.Models.Categories;
    using Core.Domain.PlaceInfo.Models.Locations;
    using System.Collections.Generic;
    using System.Linq;
    using static Common.Domain.Models.ModelConstants.Common;

    public class Place : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Feedback> feedbacks;

        private static readonly IEnumerable<Category> AllowedCategories
           = new CategoryData().GetData().Cast<Category>();

        internal Place(
            string name,
            string description,
            string userId,
            Location location,
            int categoryId,
            PlaceType placeType = default!)
        {
            this.Validate(name, description);
            this.ValidateCategory(categoryId);

            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.CategoryId = categoryId;
            this.UserId = userId;

            this.feedbacks = new HashSet<Feedback>();
            this.Type = placeType;

            this.AddEvent(new PlaceAddedDomainEvent());
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Location Location { get; private set; }

        public int CategoryId { get; private set; }

        public PlaceType Type { get; private set; }

        public string UserId { get; private set; }

        public double Rating { 
            get
                => this.Feedbacks.Select(f => f.Rating).Average();
        }

        public int FeedbackCount { 
            get 
                => this.Feedbacks.Count(); 
        }

        public IReadOnlyCollection<Feedback> Feedbacks => this.feedbacks.ToList().AsReadOnly();

        public Place UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }

        public Place UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        public Place UpdateLocation(
            Country country,
            City city)
        {
            this.Location = new Location(country, city);

            return this;
        }

        public Place UpdatePlaceType(PlaceType type)
        {
            this.Type = type;

            return this;
        }

        public void AddFeedback(string text, int rating, string userId)
        {
            this.feedbacks.Add(new Feedback(text, rating, userId));

            this.AddEvent(new FeedbackAddedDomainEvent());
        }

        private void Validate(string name, string description)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
        }

        private void ValidateCategory(int categoryId)
        {
            if (AllowedCategories.Any(c => c.Id == categoryId))
            {
                return;
            }

            var allowedCategoryIds = string.Join(", ", AllowedCategories.Select(c => $"'{c.Id}'"));

            throw new InvalidPlaceException($"'{categoryId}' is not a valid category Id. Allowed values are: {allowedCategoryIds}.");
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidPlaceException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidPlaceException>(
               description,
               MinDescriptionLength,
               MaxDescriptionLength,
               nameof(this.Description));
    }
}
