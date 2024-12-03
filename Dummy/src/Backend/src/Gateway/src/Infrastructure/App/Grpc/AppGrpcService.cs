namespace Makc2024.Dummy.Gateway.Infrastructure.App.Grpc;

public class AppGrpcService(WriterAppGrpcClient _grpcClient) : IAppService
{
  public async Task<Result<AppLoginActionDTO>> Login(
    AppLoginActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.LoginAsync(
        command.ToAppLoginActionGrpcRequest(),
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
