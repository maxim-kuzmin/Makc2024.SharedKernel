namespace Shared.Entity;

public abstract class EntityBaseWithId<TId> : EntityBaseWithoutId<TId>
  where TId : struct, IEquatable<TId>
{
  public TId Id { get; set; }

  public sealed override TId GetId()
  {
    return Id;
  }

  public sealed override void SetId(TId id)
  {
    Id = id;
  }
}
