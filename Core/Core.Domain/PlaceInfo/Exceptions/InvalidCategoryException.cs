namespace Core.Domain.PlaceInfo.Exceptions
{
    using Common.Domain;

    public class InvalidCategoryException : BaseDomainException
    {
        public InvalidCategoryException()
        {
        }

        public InvalidCategoryException(string error) => this.Error = error;
    }
}
