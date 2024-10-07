using System.Threading.Tasks;
using EventSourcing.Command;

namespace EventSourcing.CommandHandler;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}