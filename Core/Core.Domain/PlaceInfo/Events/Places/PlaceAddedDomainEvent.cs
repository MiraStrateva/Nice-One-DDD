namespace Core.Domain.PlaceInfo.Events.Places
{
    using Common.Domain;
    using System;

    public class PlaceAddedDomainEvent : IDomainEvent
    {
        public DateTime OccurredOn => DateTime.Now;
    }
}
