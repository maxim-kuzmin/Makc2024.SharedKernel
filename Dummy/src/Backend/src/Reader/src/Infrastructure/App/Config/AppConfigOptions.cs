namespace Makc2024.Dummy.Reader.Infrastructure.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public class AppConfigOptions
{
  /// <summary>
  /// Ключ раздела конфигурации.
  /// </summary>
  public const string SectionKey = "App";

  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsAuthentication? Authentication { get; set; }

  /// <summary>
  /// Повтор включён оркестратором.
  /// </summary>
  public bool IsRetryEnabledByOrchestrator { get; set; }

  /// <summary>
  /// Язык.
  /// </summary>
  public string Language { get; set; } = "ru";

  /// <summary>
  /// База данных PostgreSQL.
  /// </summary>
  public AppConfigOptionsPostgreSQL? PostgreSQL { get; set; }

  /// <summary>
  /// Брокер сообщений RabbitMQ.
  /// </summary>
  public AppConfigOptionsRabbitMQ? RabbitMQ { get; set; }
}
