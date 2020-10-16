namespace Common.Infrastructure.Events
{
    using Common.Domain;
    using System.Threading.Tasks;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
