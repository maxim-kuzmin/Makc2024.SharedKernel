namespace Makc2024.SharedKernel;

/// <summary>
/// Интерфейс репозитория.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> : ArdalisSharedKernel.IRepository<T>
  where T : class, IAggregateRoot
{
}
