namespace Makc2024.Dummy.Gateway.Infrastructure.App.For.Grpc;

/// <summary>
/// Расширения приложения для gRPC.
/// </summary>
public static class AppExtensionsForGrpc
{
  /// <summary>
  /// Преобразовать к запросу действия по входу в приложение для gRPC.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по входу в приложение для gRPC.</returns>
  public static AppLoginActionRequestForGrpc ToAppLoginActionRequestForGrpc(this AppLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных действия по входу в приложение.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по входу в приложение.</returns>
  public static AppLoginActionDTO ToAppLoginActionDTO(this AppLoginActionReplyForGrpc reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}
