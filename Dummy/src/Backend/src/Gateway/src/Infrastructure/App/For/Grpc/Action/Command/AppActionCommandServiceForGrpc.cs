namespace Makc2024.Dummy.Gateway.Infrastructure.App.For.Grpc.Action.Command;

/// <summary>
/// Сервис команд действия с приложением для gRPC.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class AppActionCommandServiceForGrpc(WriterAppGrpcClient _grpcClient) : IAppActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppLoginActionDTO>> Login(
    AppLoginActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.LoginAsync(
        command.ToAppLoginActionRequestForGrpc(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToAppLoginActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}
