namespace Makc2024.Dummy.Gateway.Infrastructure.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions
{
  /// <summary>
  /// Ключ раздела.
  /// </summary>
  public const string SectionKey = "App";

  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsAuthentication Authentication { get; set; } = null!;

  /// <summary>
  /// Писатель.
  /// </summary>
  public AppConfigOptionsWriter Writer { get; set; } = null!;
}
