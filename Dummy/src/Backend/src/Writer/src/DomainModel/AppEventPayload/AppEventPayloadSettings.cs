namespace Makc2024.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
public abstract class AppEventPayloadSettings
{
  /// <summary>
  /// Максимальная длина для данных.
  /// </summary>
  public int MaxLengthForData { get; protected set; }
}
