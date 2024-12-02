namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Grpc;

public class DummyItemGrpcService(IMediator _mediator) : DummyItemGrpcServiceBase
{
  public override async Task<DummyItemGetActionGrpcReply> Create(
    DummyItemCreateActionGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemCreateActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken).ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionGrpcReply();
  }

  public override async Task<Empty> Delete(DummyItemDeleteActionGrpcRequest request, ServerCallContext context)
  {
    var command = request.ToDummyItemDeleteActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken).ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<DummyItemGetActionGrpcReply> Get(
    DummyItemGetActionGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemGetActionQuery();

    var result = await _mediator.Send(command, context.CancellationToken).ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionGrpcReply();
  }

  public override async Task<DummyItemGetListActionGrpcReply> GetList(
    DummyItemGetListActionGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemGetListActionQuery();

    var result = await _mediator.Send(command, context.CancellationToken).ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetListActionGrpcReply();
  }

  public override async Task<DummyItemGetActionGrpcReply> Update(
    DummyItemUpdateActionGrpcRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemUpdateActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken).ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionGrpcReply();
  }
}
