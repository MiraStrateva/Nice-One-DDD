namespace Core.Domain.PlaceInfo.Models.Places
{
    using Common.Domain.Models;

    public class PlaceType : Enumeration
    {
        public static readonly PlaceType Tourist = new PlaceType(1, nameof(Tourist));
        public static readonly PlaceType Historical = new PlaceType(2, nameof(Historical));
        public static readonly PlaceType Urban = new PlaceType(3, nameof(Urban));

        private PlaceType(int value)
            : this(value, FromValue<PlaceType>(value).Name)
        {
        }

        private PlaceType(int value, string name)
            : base(value, name)
        {
        }
    }
}
