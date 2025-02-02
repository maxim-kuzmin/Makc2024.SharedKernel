namespace Makc2024.Dummy.Shared.DomainModel.Entity;

/// <summary>
/// Основа сущности со свойством идентификатора.
/// </summary>
/// <typeparam name="TId">Тип идентификатора.</typeparam>
public abstract class EntityBaseWithIdProperty<TId> : EntityBase<TId>
  where TId : struct, IEquatable<TId>
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public TId Id { get; set; }

  /// <inheritdoc/>
  public sealed override TId GetId()
  {
    return Id;
  }

  /// <inheritdoc/>
  public sealed override void SetId(TId id)
  {
    Id = id;
  }
}
