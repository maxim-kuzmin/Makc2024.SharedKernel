namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Grpc;

public class DummyItemGrpcService(IMediator _mediator) : DummyItemGrpc.DummyItemGrpcBase
{
  public override async Task<DummyItemGetActionReply> Create(
    DummyItemCreateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemCreateActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReply();
  }

  public override async Task<Empty> Delete(DummyItemDeleteActionRequest request, ServerCallContext context)
  {
    var command = request.ToDummyItemDeleteActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<DummyItemGetActionReply> Get(DummyItemGetActionRequest request, ServerCallContext context)
  {
    var command = request.ToDummyItemGetActionQuery();

    var result = await _mediator.Send(command, context.CancellationToken);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReply();
  }

  public override async Task<DummyItemGetListActionReply> GetList(
    DummyItemGetListActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToDummyItemGetListActionQuery();

    var result = await _mediator.Send(command, context.CancellationToken);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetListActionReply();
  }

  public override async Task<DummyItemGetActionReply> Update(DummyItemUpdateActionRequest request, ServerCallContext context)
  {
    var command = request.ToDummyItemUpdateActionCommand();

    var result = await _mediator.Send(command, context.CancellationToken);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionReply();
  }
}
