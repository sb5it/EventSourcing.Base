using System;

namespace EventSourcing.Aggregate;

public interface IEvent
{
    Guid Id { get; }
    Guid AggregateId { get; }
}