namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem;

/// <summary>
/// Фабрика фиктивного предмета.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class DummyItemFactory(IDummyItemResources _resources, DummyItemSettings _settings) : IDummyItemFactory
{
  /// <inheritdoc/>
  public DummyItemAggregate CreateAggregate(long entityId = 0)
  {
    return new(entityId, _resources, _settings);
  }
}
