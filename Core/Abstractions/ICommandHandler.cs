using Shared.Result;
using CSharpFunctionalExtensions;

namespace Core.Abstractions;

public interface ICommandHandler<in TCommand, TResponse> 
    where TCommand : ICommand
{
    Task<Result<TResponse, Error>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand> 
    where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken);
}