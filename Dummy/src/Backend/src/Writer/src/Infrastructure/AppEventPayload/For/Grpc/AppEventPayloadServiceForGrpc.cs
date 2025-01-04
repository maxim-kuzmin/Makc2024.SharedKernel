namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.For.Grpc;

/// <summary>
/// Сервис полезной нагрузки события приложения для gRPC.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppEventPayloadServiceForGrpc(IMediator _mediator) : AppEventPayloadServiceBaseForGrpc
{
  public override async Task<AppEventPayloadGetActionReplyForGrpc> Create(
    AppEventPayloadCreateActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToAppEventPayloadCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetActionReplyForGrpc();
  }

  public override async Task<Empty> Delete(AppEventPayloadDeleteActionRequestForGrpc request, ServerCallContext context)
  {
    var command = request.ToAppEventPayloadDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<AppEventPayloadGetActionReplyForGrpc> Get(
    AppEventPayloadGetActionRequestForGrpc request,
    ServerCallContext context)
  {
    var query = request.ToAppEventPayloadGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetActionReplyForGrpc();
  }

  public override async Task<AppEventPayloadGetListActionReplyForGrpc> GetList(
    AppEventPayloadGetListActionRequestForGrpc request,
    ServerCallContext context)
  {
    var query = request.ToAppEventPayloadGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetListActionGrpcReply();
  }

  public override async Task<AppEventPayloadGetActionReplyForGrpc> Update(
    AppEventPayloadUpdateActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToAppEventPayloadUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetActionReplyForGrpc();
  }
}
