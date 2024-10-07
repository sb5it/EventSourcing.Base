using System.Reflection;

namespace EventSourcing.Aggregate;

public interface IAggregateRoot
{
    void LoadFromHistory(IEnumerable<IEvent> events);
    IEnumerable<IEvent> GetUncommittedEvents();
    void ClearUncommittedEvents();
    AggregateId Id { get; }
}

public abstract class AggregateRoot : IAggregateRoot
{
    public AggregateId Id { get; internal init;  } = null!;

    private readonly List<IEvent> _uncommittedEvents = new();

    //For better performance this can be overridden in the derived class
    public virtual void LoadFromHistory(IEnumerable<IEvent> events)
    {
        var myClassType = GetType();
        foreach (var @event in events)
        {
            MethodInfo? method = myClassType.GetMethod(
                "When",
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { @event.GetType() },
                null
            );
            
            if (method != null)
            {
                method.Invoke(this, new object[] { @event });
            }
        }
    }

    public IEnumerable<IEvent> GetUncommittedEvents()
    {
        return _uncommittedEvents.AsReadOnly();
    }

    public void ClearUncommittedEvents()
    {
        _uncommittedEvents.Clear();
    }
    
    protected void RaiseDomainEvent(IEvent domainEvent)
    {
#if DEBUG
        Console.WriteLine($"RaiseDomainEvent: {domainEvent.GetType().Name}");
#endif
        _uncommittedEvents.Add(domainEvent);
    }
}