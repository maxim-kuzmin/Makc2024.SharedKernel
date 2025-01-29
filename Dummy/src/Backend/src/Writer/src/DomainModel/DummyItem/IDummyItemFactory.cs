namespace Makc2024.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Интерфейс фабрики фиктивного предмета.
/// </summary>
public interface IDummyItemFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Агрегат.</returns>
  DummyItemAggregate CreateAggregate(DummyItemEntity? entityFromDb = null);
}
