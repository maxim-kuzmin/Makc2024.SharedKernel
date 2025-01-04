namespace Makc2024.Dummy.Writer.Infrastructure.App.For.Grpc;

/// <summary>
/// Сервис приложения для gRPC.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppServiceForGrpc(IMediator _mediator) : AppServiceBaseForGrpc
{
  /// <summary>
  /// Войти.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <param name="context">Контекст.</param>
  /// <returns>Ответ.</returns>
  public override async Task<AppLoginActionReplyForGrpc> Login(
    AppLoginActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToAppLoginActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppLoginActionReplyForGrpc();
  }
}
