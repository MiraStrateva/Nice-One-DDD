namespace NiceOne.Domain.PlaceInfo.Exceptions
{
    using NiceOne.Domain.Common;

    public class InvalidCityException : BaseDomainException
    {
        public InvalidCityException()
        {
        }

        public InvalidCityException(string error) => this.Error = error;
    }
}
