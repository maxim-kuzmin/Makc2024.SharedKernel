namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Интерфейс фабрики события приложения.
/// </summary>
public interface IAppEventFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Агрегат.</returns>
  AppEventAggregate CreateAggregate(AppEventEntity? entityFromDb = null);
}
