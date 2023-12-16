namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс обработчика запроса. Источник: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TQuery">Тип запроса.</typeparam>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : ArdalisSharedKernel.IQueryHandler<TQuery, TResponse>
       where TQuery : IQuery<TResponse>
{
}
