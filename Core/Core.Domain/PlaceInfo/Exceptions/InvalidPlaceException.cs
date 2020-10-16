namespace Core.Domain.PlaceInfo.Exceptions
{
    using Common.Domain;

    public class InvalidPlaceException : BaseDomainException
    {
        public InvalidPlaceException()
        {
        }

        public InvalidPlaceException(string error) => this.Error = error;
    }
}
