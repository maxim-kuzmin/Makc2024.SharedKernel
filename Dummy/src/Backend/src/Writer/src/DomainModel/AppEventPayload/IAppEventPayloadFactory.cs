namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Интерфейс фабрики полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadFactory
{
  /// <summary>
  /// Создать агрегат.
  /// </summary>
  /// <param name="entityId">Идентификатор сущности.</param>
  /// <returns>Агрегат.</returns>
  AppEventPayloadAggregate CreateAggregate(long entityId = default);
}
