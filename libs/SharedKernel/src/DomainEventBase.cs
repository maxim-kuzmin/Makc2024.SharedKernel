namespace Makc2024.SharedKernel;

/// <summary>
/// Базовый тип для доменных событий. Зависит от MediatR INotification.
/// Включает свойство DateOccurred (дата появления), которое инициализируется при создании экземпляра класса.
/// </summary>
public abstract class DomainEventBase : ArdalisSharedKernel.DomainEventBase
{
}

