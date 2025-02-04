namespace Makc2024.Dummy.Reader.Infrastructure.App.Config.Options;

/// <summary>
/// Секция аутентификации в параметрах конфигурации приложения.
/// </summary>
/// <param name="Issuer">Издатель.</param>
/// <param name="Audience">Аудитория.</param>
/// <param name="Key">Ключ.</param>
public record AppConfigOptionsAuthentication(
  string Issuer,
  string Audience,
  string Key)
{
  /// <summary>
  /// Получить симметричный ключ безопасности.
  /// </summary>
  /// <returns>Симметричный ключ безопасности.</returns>
  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    var keyBytes = Encoding.UTF8.GetBytes(Key);

    return new SymmetricSecurityKey(keyBytes);
  }
}
