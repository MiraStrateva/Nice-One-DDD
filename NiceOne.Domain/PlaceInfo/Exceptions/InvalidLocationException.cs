namespace NiceOne.Domain.PlaceInfo.Exceptions
{
    using NiceOne.Domain.Common;

    public class InvalidLocationException : BaseDomainException
    {
        public InvalidLocationException()
        {
        }

        public InvalidLocationException(string error) => this.Error = error;
    }
}