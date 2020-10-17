namespace Core.Application.PlaceInfo.Places.Queries.Common
{
    public class PlaceOutputModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CategoryName { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public double Rating { get; private set; }
        public int FeedbackCount { get; private set; }

        public int UserId { get; private set; }
    }
}
