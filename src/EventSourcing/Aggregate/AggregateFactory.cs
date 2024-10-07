namespace EventSourcing.Aggregate;

public static class AggregateFactory<TAggregateRoot>
    where TAggregateRoot : AggregateRoot, new()
{
    public static TAggregateRoot Create(AggregateId id)
    {
        TAggregateRoot aggregate = new()
        {
            Id = id
        };
        return aggregate;
    }
}