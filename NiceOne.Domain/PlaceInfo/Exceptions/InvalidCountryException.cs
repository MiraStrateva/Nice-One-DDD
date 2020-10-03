namespace NiceOne.Domain.PlaceInfo.Exceptions
{
    using NiceOne.Domain.Common;

    public class InvalidCountryException : BaseDomainException
    {
        public InvalidCountryException()
        {
        }

        public InvalidCountryException(string error) => this.Error = error;
    }
}