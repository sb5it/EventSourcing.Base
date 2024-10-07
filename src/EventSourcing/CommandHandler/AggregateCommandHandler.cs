using EventSourcing.Aggregate;
using EventSourcing.Command;
using EventSourcing.Repository;

namespace EventSourcing.CommandHandler;

public abstract class AggregateCommandHandler<T, TAggregateRoot>(IAggregateRootRepository<TAggregateRoot> aggregateRootRepository)
    : ICommandHandler<T>
    where T : ICommand
    where TAggregateRoot : IAggregateRoot
{
    // ReSharper disable once NotAccessedField.Global
    protected TAggregateRoot? AggregateRoot;
    
    public async Task HandleAsync(T command)
    {
        await DehydrateAsync(command);
        await ProcessAsync(command);
        await SaveAsync();
    }
    
    protected virtual async Task DehydrateAsync(T command)
    {
        var aggregate = await aggregateRootRepository.FindByIdAsync(command.Id);
        if (aggregate != null)
        {
            AggregateRoot = aggregate;
        }
    }

    protected abstract Task ProcessAsync(T command);

    private async Task SaveAsync()
    {
        await aggregateRootRepository.SaveAsync(AggregateRoot);
    }
}