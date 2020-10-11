namespace NiceOne.Domain.Statistics.Models
{
    using NiceOne.Domain.Common.Models;

    public class PlaceView : Entity<int>
    {
        internal PlaceView(int placeId, string? userId)
        {
            this.PlaceId = placeId;
            this.UserId = userId;
        }

        public int PlaceId { get; }

        public string? UserId { get; }
    }
}
