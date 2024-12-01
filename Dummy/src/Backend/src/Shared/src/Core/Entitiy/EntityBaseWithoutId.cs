namespace Makc2024.Dummy.Shared.Core.Entity;

public abstract class EntityBaseWithoutId<TId> : IDeepCopyable
  where TId : struct, IEquatable<TId>
{
  public virtual object DeepCopy()
  {
    return MemberwiseClone();
  }

  public abstract TId GetId();
  public abstract void SetId(TId id);
}
