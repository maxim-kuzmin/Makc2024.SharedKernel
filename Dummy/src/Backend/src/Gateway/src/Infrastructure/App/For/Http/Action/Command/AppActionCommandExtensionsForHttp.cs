namespace Makc2024.Dummy.Gateway.Infrastructure.App.For.Http.Action.Command;

/// <summary>
/// Расширения команд действия с приложением для HTTP.
/// </summary>
public static class AppActionCommandExtensionsForHttp
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }
}
