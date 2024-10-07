using System;

namespace EventSourcing.Command;

public interface ICommand
{
    public Guid Id { get; set; }
}