namespace Core.Domain.PlaceInfo.Events.Places
{
    using Common.Domain;
    using System;

    public class FeedbackAddedDomainEvent : IDomainEvent
    {
        public DateTime OccurredOn => DateTime.Now;
    }
}
