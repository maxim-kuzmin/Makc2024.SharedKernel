namespace Gateway.DomainModel.Revenue;

public class RevenueAggregate(string revenueEntityMonth = "") : AggregateBase
{
  private readonly RevenueEntity _revenueEntity = new() { Month = revenueEntityMonth };

  public string Month => _revenueEntity.Month;
  public int Value => _revenueEntity.Value;

  public RevenueEntity? GetRevenueEntityToCreate()
  {
    return (RevenueEntity)_revenueEntity.DeepCopy();
  }

  public RevenueEntity? GetRevenueEntityToDelete(RevenueEntity revenueEntity)
  {
    if (Month == "" || revenueEntity.Month != Month)
    {
      return null;
    }

    return revenueEntity;
  }

  public RevenueEntity? GetRevenueEntityToUpdate(RevenueEntity revenueEntity)
  {
    if (Month == "" || revenueEntity.Month != Month)
    {
      return null;
    }

    bool isOk = false;

    if (HasChangedProperty(nameof(Value)) && revenueEntity.Value != Value)
    {
      revenueEntity.Value = Value;

      isOk = true;
    }

    return isOk ? revenueEntity : null;
  }

  public void UpdateValue(int newValue)
  {
    _revenueEntity.Value = newValue;

    SetChangedProperty(nameof(Value));
  }
}
