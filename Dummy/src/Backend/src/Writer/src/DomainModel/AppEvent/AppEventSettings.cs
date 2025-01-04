namespace Makc2024.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Настройки события приложения.
/// </summary>
public abstract class AppEventSettings
{
  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
