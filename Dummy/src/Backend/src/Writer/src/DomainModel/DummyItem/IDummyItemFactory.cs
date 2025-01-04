namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Интерфейс фабрики фиктивного предмета.
/// </summary>
public interface IDummyItemFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityId">Идентификатор сущности.</param>
  /// <returns>Агрегат.</returns>
  DummyItemAggregate CreateAggregate(long entityId = default);
}
