using System.Collections.ObjectModel;
using EventSourcing.Aggregate;

namespace EventSourcing.Repository;

public interface IAggregateRootRepository<TAggregate> 
    where TAggregate : IAggregateRoot
{
    public ReadOnlyCollection<IEvent> Events { get; }
    Task<TAggregate?> FindByIdAsync(Guid workerId);
    Task SaveAsync(TAggregate? aggregate);
}