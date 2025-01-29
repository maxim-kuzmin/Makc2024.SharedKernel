namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Интерфейс фабрики полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityFromDb">Сущность из базы данных.</param>
  /// <returns>Агрегат.</returns>
  AppEventPayloadAggregate CreateAggregate(AppEventPayloadEntity? entityFromDb = null);
}
