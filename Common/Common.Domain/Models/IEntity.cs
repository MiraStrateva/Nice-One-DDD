namespace Common.Domain.Models
{
    using Common.Domain;
    using System.Collections.Generic;

    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
