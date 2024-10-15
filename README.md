# EventSourcing.Base

`EventSourcing` is a base library for implementing an event sourcing system in .NET. It provides foundational classes and interfaces to support the creation of aggregates, commands, value objects, event handling, and command processing.

## Project Overview

The library is organized into several key components:

### Aggregate

- **Aggregate.cs**: Defines the base class for aggregates, which are entities that encapsulate state changes through events.
- **AggregateFactory.cs**: A factory class responsible for creating instances of aggregates.
- **AggregateId.cs**: Represents the unique identifier for aggregates.
- **Event.cs**: Defines a base class for events that represent changes in the state of an aggregate.
- **IEvent.cs**: Interface for events, ensuring that all events implement required properties and methods.

### Command

- **ICommand.cs**: Interface for commands, which are actions that change the state of aggregates.

### CommandHandler

- **AggregateCommandHandler.cs**: Base class for handling commands that target specific aggregates.
- **ICommandHandler.cs**: Interface for command handlers, which process commands and produce events.

### Repository

- **IAggregateRootRepository.cs**: Interface for repositories that handle the persistence and retrieval of aggregate roots.

### ValueObject

- **IValueObject.cs**: Interface for value objects, which are immutable objects that represent a concept by their attributes rather than their identity.

## Getting Started

To use this library in your .NET project, add the NuGet package:

```bash
dotnet add package Sb5It.EventSourcing
```
Alternatively, you can find the package on GitHub Packages and include it in your `nuget.config` file:

```xml
<configuration>
  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/<your-github-username>/index.json" />
  </packageSources>
</configuration>
```
## Usage

1. **Create an Aggregate**:  
   Define a class that inherits from `Aggregate` and implement the necessary state-changing logic.

2. **Define Events**:  
   Create events by extending `Event` or implementing `IEvent` to represent changes in the aggregate's state.

3. **Implement Commands**:  
   Define commands that implement `ICommand` to represent actions that change the aggregate's state.

4. **Handle Commands**:  
   Use `AggregateCommandHandler` to process commands and produce events.

5. **Manage Persistence**:  
   Implement `IAggregateRootRepository` to handle saving and retrieving aggregates.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request with your improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
