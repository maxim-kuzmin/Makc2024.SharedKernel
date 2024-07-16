namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

public class DummyItemEntity : EntityBaseWithId<long>, IAggregateRoot
{
  public string Name { get; set; } = null!;

  public sealed override object DeepCopy()
  {
    return base.DeepCopy();
  }
}
