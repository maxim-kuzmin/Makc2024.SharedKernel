namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс репозитория с операциями только для чтения.
/// Используется главным образом для получения отслеживаемых доменных сущностей, а не для произвольных запросов.
/// </summary>
/// <typeparam name="T">Тип корня агрегата.</typeparam>
public interface IReadRepository<T> : ArdalisSharedKernel.IReadRepository<T>
  where T : class, IAggregateRoot
{
}
