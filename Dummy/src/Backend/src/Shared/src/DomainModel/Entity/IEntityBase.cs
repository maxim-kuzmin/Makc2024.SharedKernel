namespace Makc2024.Dummy.Shared.DomainModel.Entity;

/// <summary>
/// Интерфейс основы сущности.
/// </summary>
/// <typeparam name="TId">Тип идентификатора.</typeparam>
public interface IEntityBase<TId> : IDeepCopyable
  where TId : struct, IEquatable<TId>
{
  /// <summary>
  /// Получить идентификатор.
  /// </summary>
  /// <returns>Идентификатор.</returns>
  TId GetId();

  /// <summary>
  /// Установить идентификатор.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  void SetId(TId id);
}
