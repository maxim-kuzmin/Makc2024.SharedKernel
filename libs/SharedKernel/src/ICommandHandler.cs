namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс обработчика команды. Источник: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TCommand">Тип команды.</typeparam>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : ArdalisSharedKernel.ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
{
}
