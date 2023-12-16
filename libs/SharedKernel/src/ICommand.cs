namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс команды. Источник: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
public interface ICommand<out TResponse> : ArdalisSharedKernel.ICommand<TResponse>
{
}
