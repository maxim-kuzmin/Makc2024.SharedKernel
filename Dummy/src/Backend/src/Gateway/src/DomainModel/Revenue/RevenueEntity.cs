namespace Makc2024.Dummy.Gateway.DomainModel.Revenue;

public class RevenueEntity : EntityBaseWithoutId<NonNullableStringType>, IAggregateRoot
{
  public string Month { get; set; } = null!;
  public int Value { get; set; }

  public sealed override object DeepCopy()
  {
    return base.DeepCopy();
  }

  public sealed override NonNullableStringType GetId()
  {
    return Month;
  }

  public sealed override void SetId(NonNullableStringType id)
  {
    Month = id;
  }
}
