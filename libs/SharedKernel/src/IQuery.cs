namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс запроса. Источник: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
public interface IQuery<out TResponse> : ArdalisSharedKernel.IQuery<TResponse>
{
}
