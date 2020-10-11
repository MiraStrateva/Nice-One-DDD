namespace NiceOne.Domain.PlaceInfo.Exceptions
{
    using NiceOne.Domain.Common;

    public class InvalidPlaceException : BaseDomainException
    {
        public InvalidPlaceException()
        {
        }

        public InvalidPlaceException(string error) => this.Error = error;
    }
}
