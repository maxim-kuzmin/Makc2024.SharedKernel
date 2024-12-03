namespace Makc2024.Dummy.Writer.Infrastructure.App.Grpc;

public class AppGrpcService(IMediator _mediator) : AppGrpcServiceBase
{
  public override async Task<AppLoginActionGrpcReply> Login(
    AppLoginActionGrpcRequest request,
    ServerCallContext context)
  {
    AppLoginActionCommand command = request.ToAppLoginActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    Result<AppLoginActionDTO> result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppLoginActionGrpcReply();
  }
}
