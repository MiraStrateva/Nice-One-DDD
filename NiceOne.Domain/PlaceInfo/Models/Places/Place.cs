namespace NiceOne.Domain.PlaceInfo.Models.Places
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.Common.Models;
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using NiceOne.Domain.PlaceInfo.Models.Locations;
    using System.Collections.Generic;
    using System.Linq;
    using static NiceOne.Domain.Common.Models.ModelConstants.Common;

    public class Place : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Feedback> feedbacks;

        private static readonly IEnumerable<Category> AllowedCategories
           = new CategoryData().GetData().Cast<Category>();

        internal Place(string name, string description, string userId, Location location, Category category, PlaceType placeType = default!)
        {
            this.Validate(name, description);
            this.ValidateCategory(category);

            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Category = category;
            this.UserId = userId;

            this.feedbacks = new HashSet<Feedback>();
            this.PlaceType = placeType;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Location Location { get; private set; }

        public Category Category { get; private set; }

        public PlaceType PlaceType { get; private set; }

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

        public Place UpdateCategory(Category category)
        {
            this.ValidateCategory(category);
            this.Category = category;

            return this;
        }

        public Place UpdateLocation(
            Country country,
            City city)
        {
            this.Location = new Location(country, city);

            return this;
        }

        public Place UpdatePlaceType(PlaceType placeType)
        {
            this.PlaceType = placeType;

            return this;
        }

        public void AddFeedback(Feedback feedback)
        {
            this.feedbacks.Add(feedback);
        }

        private void Validate(string name, string description)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
        }

        private void ValidateCategory(Category category)
        {
            var categoryName = category?.Name;

            if (AllowedCategories.Any(c => c.Name == categoryName))
            {
                return;
            }

            var allowedCategoryNames = string.Join(", ", AllowedCategories.Select(c => $"'{c.Name}'"));

            throw new InvalidPlaceException($"'{categoryName}' is not a valid category. Allowed values are: {allowedCategoryNames}.");
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
