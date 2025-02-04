namespace Makc2024.Dummy.Writer.Infrastructure.App.Config.Options;

/// <summary>
/// Секция RabbitMQ в параметрах конфигурации приложения.
/// </summary>
/// <param name="HostName">Имя хоста.</param>
/// <param name="Password">Пароль.</param>
/// <param name="Port">Порт.</param>
/// <param name="UserName">Имя пользователя.</param>
public record AppConfigOptionsRabbitMQ(
  string HostName,
  string Password,
  int Port,
  string UserName);
