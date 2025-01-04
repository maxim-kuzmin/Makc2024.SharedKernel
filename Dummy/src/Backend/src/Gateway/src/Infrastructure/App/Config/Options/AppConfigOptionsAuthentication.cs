namespace Makc2024.Dummy.Gateway.Infrastructure.App.Config.Options;

/// <summary>
/// Аутентификация в параметрах конфигурации приложения.
/// </summary>
/// <param name="Issuer">Издатель.</param>
/// <param name="Audience">Аудитория.</param>
/// <param name="Key">Ключ.</param>
public record AppConfigOptionsAuthentication(
  string Issuer,
  string Audience,
  string Key);
