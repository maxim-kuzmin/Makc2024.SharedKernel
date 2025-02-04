namespace Makc2024.Dummy.Reader.Infrastructure.App.Config.Options;

/// <summary>
/// Секция PostgreSQL в параметрах конфигурации приложения.
/// </summary>
/// <param name="ConnectionStringName">Имя строки подключения.</param>
/// <param name="Database">База данных.</param>
/// <param name="Password">Пароль.</param>
/// <param name="Port">Порт.</param>
/// <param name="Server">Сервер.</param>
/// <param name="UserId">Идентификатор пользователя.</param>
public record AppConfigOptionsPostgreSQL(
  string ConnectionStringName,
  string Database,
  string Password,
  int Port,
  string Server,
  string UserId)
{
  /// <summary>
  /// Преобразовать к строке подключения.
  /// </summary>
  /// <param name="template">Шаблон.</param>
  /// <returns>Строка полключения.</returns>
  public string ToConnectionString(string template)
  {
    return template
      .Replace("{Database}", Database)
      .Replace("{Password}", Password)
      .Replace("{Port}", Port.ToString())
      .Replace("{Server}", Server)
      .Replace("{UserId}", UserId);
  }
}
