namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadSettings
{
  /// <summary>
  /// Максимальная длина для сущности.
  /// </summary>
  public const int MaxLengthForEntity = 255;

  /// <summary>
  /// Максимальная длина для идентификатора сущности.
  /// </summary>
  public const int MaxLengthForEntityId = 255;

  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public const int MaxLengthForName = 255;
}
