namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.For.Grpc;

/// <summary>
/// Сервис события приложения для gRPC.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppEventServiceForGrpc(IMediator _mediator) : AppEventServiceBaseForGrpc
{
  public override async Task<AppEventGetActionReplyForGrpc> Create(
    AppEventCreateActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToAppEventCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetActionReplyForGrpc();
  }

  public override async Task<Empty> Delete(AppEventDeleteActionRequestForGrpc request, ServerCallContext context)
  {
    var command = request.ToAppEventDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<AppEventGetActionReplyForGrpc> Get(
    AppEventGetActionRequestForGrpc request,
    ServerCallContext context)
  {
    var query = request.ToAppEventGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetActionReplyForGrpc();
  }

  public override async Task<AppEventGetListActionReplyForGrpc> GetList(
    AppEventGetListActionRequestForGrpc request,
    ServerCallContext context)
  {
    var query = request.ToAppEventGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetListActionGrpcReply();
  }

  public override async Task<AppEventGetActionReplyForGrpc> Update(
    AppEventUpdateActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToAppEventUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetActionReplyForGrpc();
  }
}
