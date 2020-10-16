namespace Common.Domain
{
    using System;

    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
