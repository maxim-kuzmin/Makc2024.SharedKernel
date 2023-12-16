namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс корневого агрегата.
/// Применяестся, чтобы пометить корневые агрегаты в Вашей доменной модели.
/// Реализация репозитория может использовать ограничения, чтобы гарантировать его
/// работу только с корневыми агрегатами.
/// </summary>
public interface IAggregateRoot : ArdalisSharedKernel.IAggregateRoot
{
}
