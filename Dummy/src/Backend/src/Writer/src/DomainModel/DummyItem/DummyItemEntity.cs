namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Сущность фиктивного предмета.
/// </summary>
public class DummyItemEntity : EntityBaseWithIdProperty<long>, IAggregateRoot
{
  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = null!;
}
