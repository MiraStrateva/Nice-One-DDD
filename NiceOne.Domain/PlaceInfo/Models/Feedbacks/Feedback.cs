namespace NiceOne.Domain.PlaceInfo.Models.Places
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.Common.Models;
    using NiceOne.Domain.PlaceInfo.Exceptions;
    using System;
    using static NiceOne.Domain.Common.Models.ModelConstants.Feedback;

    public class Feedback : Entity<int>, IAggregateRoot
    {
        internal Feedback (string text, int rating, string IserId)
        {
            this.Validate(text, rating);

            this.Text = text;
            this.Rating = rating;
            this.Date = DateTime.Now;
            this.UserId = UserId;
        }

        public string Text { get; private set; }
        public int Rating { get; private set; }
        public DateTime Date { get; private set; }
        public string UserId { get; private set; }

        public Feedback UpdateText(string text)
        {
            this.ValidateText(text);
            this.Text = text;

            return this;
        }

        public Feedback UpdateRating(int rating)
        {
            this.ValidateRating(rating);
            this.Rating = rating;

            return this;
        }

        private void Validate(string text, int rating)
        {
            this.ValidateText(text);
            this.ValidateRating(rating);
        }

        private void ValidateText(string text)
            => Guard.ForStringLength<InvalidPlaceException>(
                    text,
                    MinTextLength,
                    MaxTextLength,
                    nameof(this.Text));

        private void ValidateRating(int rating)
            => Guard.AgainstOutOfRange<InvalidPlaceException>(
                rating,
                MinRatingValue,
                MaxRatingValue,
                nameof(this.Rating));
    }
}
