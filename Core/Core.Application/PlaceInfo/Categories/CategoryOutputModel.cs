namespace Core.Application.PlaceInfo.Places.Queries.Common
{
    public class CategoryOutputModel
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public int PlacesCount { get; private set; }
    }
} 
