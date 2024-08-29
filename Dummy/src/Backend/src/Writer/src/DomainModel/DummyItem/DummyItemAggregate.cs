namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

public class DummyItemAggregate(long dummyItemEntityId = default) : AggregateBase
{  
  private readonly DummyItemEntity _dummyItemEntity = new() { Id = dummyItemEntityId };

  public long Id => _dummyItemEntity.Id;
  public string Name => _dummyItemEntity.Name;

  public DummyItemEntity? GetDummyItemEntityToCreate()
  {
    return (DummyItemEntity)_dummyItemEntity.DeepCopy();
  }

  public DummyItemEntity? GetDummyItemEntityToDelete(DummyItemEntity dummyItemEntity)
  {
    if (Id == default || dummyItemEntity.Id != Id)
    {
      return null;
    }

    return dummyItemEntity;
  }

  public DummyItemEntity? GetDummyItemEntityToUpdate(DummyItemEntity dummyItemEntity)
  {
    if (Id == default || dummyItemEntity.Id != Id)
    {
      return null;
    }

    bool isOk = false;

    if (HasChangedProperty(nameof(Name)) && dummyItemEntity.Name != Name)
    {
      dummyItemEntity.Name = Name;

      isOk = true;
    }

    return isOk ? dummyItemEntity : null;
  }

  public void UpdateName(string name)
  {
    _dummyItemEntity.Name = Guard.Against.NullOrEmpty(name, nameof(name));

    SetChangedProperty(nameof(Name));
  }
}
