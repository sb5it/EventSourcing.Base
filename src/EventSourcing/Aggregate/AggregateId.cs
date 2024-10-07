using System;
using EventSourcing.ValueObject;

namespace EventSourcing.Aggregate;

public class AggregateId : IValueObject
{
    public AggregateId(Guid id)
    {
        if(id == default)
            throw new ArgumentException($"{nameof(AggregateId)} cannot be empty {id}");
        Id = id;
    }
    
    public Guid Id { get; private set; }
}