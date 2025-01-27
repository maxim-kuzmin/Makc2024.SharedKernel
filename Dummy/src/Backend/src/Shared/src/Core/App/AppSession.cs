namespace Makc2024.Dummy.Shared.Core.App;

/// <summary>
/// Сессия приложения.
/// </summary>
public class AppSession
{
  /// <summary>
  /// Токен доступа.
  /// </summary>
  public string? AccessToken { get; set; }

  /// <summary>
  /// Пользователь.
  /// </summary>
  public ClaimsPrincipal User { get; set; } = null!;
}
