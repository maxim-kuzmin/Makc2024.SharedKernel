namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.For.Grpc;

/// <summary>
/// Сервис фиктивного предмета для gRPC.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class DummyItemServiceForGrpc(IMediator _mediator) : DummyItemServiceBaseForGrpc
{
  public override async Task<DummyItemGetActionReplyForGrpc> Create(
    DummyItemCreateActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReplyForGrpc();
  }

  public override async Task<Empty> Delete(DummyItemDeleteActionRequestForGrpc request, ServerCallContext context)
  {
    var command = request.ToDummyItemDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<DummyItemGetActionReplyForGrpc> Get(
    DummyItemGetActionRequestForGrpc request,
    ServerCallContext context)
  {
    var query = request.ToDummyItemGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReplyForGrpc();
  }

  public override async Task<DummyItemGetListActionReplyForGrpc> GetList(
    DummyItemGetListActionRequestForGrpc request,
    ServerCallContext context)
  {
    var query = request.ToDummyItemGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetListActionGrpcReply();
  }

  public override async Task<DummyItemGetActionReplyForGrpc> Update(
    DummyItemUpdateActionRequestForGrpc request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReplyForGrpc();
  }
}
