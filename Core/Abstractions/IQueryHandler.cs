using CSharpFunctionalExtensions;
using Shared.Result;

namespace Core.Abstractions;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse?> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}

public interface IQueryHandlerNonGeneric<in TQuery, TResponse>
    where TQuery : IQuery
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}

public interface IQueryHandlerWithResult<in TQuery, TResponse>
    where TQuery : IQuery
{
    Task<Result<TResponse, Error>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}