namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс для отправки доменных событий.
/// В реализации может использоваться MediatR или любая другая библиотека.
/// </summary>
public interface IDomainEventDispatcher : ArdalisSharedKernel.IDomainEventDispatcher
{
}
