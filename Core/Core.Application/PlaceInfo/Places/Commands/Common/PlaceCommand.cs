namespace Core.Application.PlaceInfo.Places.Commands.Common
{
    using Core.Domain.PlaceInfo.Models.Places;
    using global::Common.Application;

    public abstract class PlaceCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; }

        public string Description { get; set; } = default!;

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int CategoryId { get; set; }

        public PlaceType Type { get; set; } = default!;

        public string UserId { get; set; }
    }
}
