namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
public abstract class AppEventPayloadSettings
{
  /// <summary>
  /// Максимальная длина для сущности.
  /// </summary>
  public int MaxLengthForEntity { get; protected set; }

  /// <summary>
  /// Максимальная длина для идентификатора сущности.
  /// </summary>
  public int MaxLengthForEntityId { get; protected set; }

  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
