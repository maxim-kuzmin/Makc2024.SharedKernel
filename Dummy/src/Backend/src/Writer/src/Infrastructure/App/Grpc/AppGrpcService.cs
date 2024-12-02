namespace Makc2024.Dummy.Writer.Infrastructure.App.Grpc;

public class AppGrpcService(IMediator _mediator) : AppGrpcServiceBase
{
  public override async Task<AppLoginActionGrpcReply> Login(AppLoginActionGrpcRequest request, ServerCallContext context)
  {
    var command = request.ToAppLoginActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken).ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppLoginActionGrpcReply();
  }
}
