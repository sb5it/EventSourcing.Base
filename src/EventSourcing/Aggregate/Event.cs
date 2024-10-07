using System;

namespace EventSourcing.Aggregate;

public class Event : IEvent
{
    protected Event(Guid aggregateId, Guid id)
    {
        AggregateId = aggregateId;
        Id = id;
    }
    
    public Guid Id { get; private set; }

    public Guid AggregateId { get; }
}