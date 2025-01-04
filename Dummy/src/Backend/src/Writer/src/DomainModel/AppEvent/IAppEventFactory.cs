namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Интерфейс фабрики события приложения.
/// </summary>
public interface IAppEventFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityId">Идентификатор сущности.</param>
  /// <returns>Агрегат.</returns>
  AppEventAggregate CreateAggregate(long entityId = default);
}
