namespace Makc2024.Dummy.Writer.Infrastructure.App.For.Grpc;

/// <summary>
/// Расширения приложения для gRPC.
/// </summary>
public static class AppExtensionsForGrpc
{
  /// <summary>
  /// Преобразовать к команде действия по входу в приложение.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда действия по входу в приложение.</returns>
  public static AppLoginActionCommand ToAppLoginActionCommand(this AppLoginActionRequestForGrpc request)
  {
    return new(request.UserName, request.Password);
  }

  /// <summary>
  /// Преобразовать к ответу действия по входу в приложение для gRPC.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <returns>Ответ действия по входу в приложение для gRPC.</returns>
  public static AppLoginActionReplyForGrpc ToAppLoginActionReplyForGrpc(this AppLoginActionDTO dto)
  {
    return new()
    {
      UserName = dto.UserName,
      AccessToken = dto.AccessToken,
    };
  }
}
