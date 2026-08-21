namespace Core.Abstractions;

/// <summary>
/// Провайдер текущего времени.
/// </summary>
public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}