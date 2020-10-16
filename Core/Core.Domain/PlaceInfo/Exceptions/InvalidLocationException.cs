namespace Core.Domain.PlaceInfo.Exceptions
{
    using Common.Domain;

    public class InvalidLocationException : BaseDomainException
    {
        public InvalidLocationException()
        {
        }

        public InvalidLocationException(string error) => this.Error = error;
    }
}