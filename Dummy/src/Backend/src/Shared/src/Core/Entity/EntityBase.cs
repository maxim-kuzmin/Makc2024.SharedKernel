using Ardalis.SharedKernel;

namespace Makc2024.Dummy.Shared.Core.Entity;

/// <summary>
/// Основа сущности.
/// </summary>
/// <typeparam name="TId">Тип идентификатора.</typeparam>
public abstract class EntityBase<TId> : IEntityBase<TId>
  where TId : struct, IEquatable<TId>
{
  /// <inheritdoc/>
  public virtual object DeepCopy()
  {
    return MemberwiseClone();
  }

  /// <inheritdoc/>
  public abstract TId GetId();

  /// <inheritdoc/>
  public abstract void SetId(TId id);
}
