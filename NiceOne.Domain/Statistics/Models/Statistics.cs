namespace NiceOne.Domain.Statistics.Models
{
    using NiceOne.Domain.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<PlaceView> placeViews;

        internal Statistics()
        {
            this.TotalPlaces = 0;

            this.placeViews = new HashSet<PlaceView>();
        }

        public int TotalPlaces { get; private set; }

        public int TotalFeedbacks { get; private set; }

        public IReadOnlyCollection<PlaceView> PlaceViews
            => this.placeViews.ToList().AsReadOnly();

        public void AddPlace()
            => this.TotalPlaces++;

        public void AddFeedback()
            => this.TotalFeedbacks++;

        public void AddPlaceView(int placeId, string? userId)
            => this.placeViews.Add(new PlaceView(placeId, userId));
    }
}
