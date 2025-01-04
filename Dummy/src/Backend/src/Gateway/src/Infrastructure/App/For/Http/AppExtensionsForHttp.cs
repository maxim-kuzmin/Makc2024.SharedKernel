namespace Makc2024.Dummy.Gateway.Infrastructure.App.For.Http;

/// <summary>
/// Расширения приложения для HTTP.
/// </summary>
public static class AppExtensionsForHttp
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
