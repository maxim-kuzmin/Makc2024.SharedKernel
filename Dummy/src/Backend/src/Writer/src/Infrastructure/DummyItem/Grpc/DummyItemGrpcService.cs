namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Grpc;

public class DummyItemGrpcService(IMediator _mediator) : DummyItemGrpcServiceBase
{
  public override async Task<DummyItemGetActionGrpcReply> Create(
    DummyItemCreateActionGrpcRequest request,
    ServerCallContext context)
  {
    DummyItemCreateActionCommand command = request.ToDummyItemCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    Result<DummyItemGetActionDTO> result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionGrpcReply();
  }

  public override async Task<Empty> Delete(DummyItemDeleteActionGrpcRequest request, ServerCallContext context)
  {
    var command = request.ToDummyItemDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    Result result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<DummyItemGetActionGrpcReply> Get(
    DummyItemGetActionGrpcRequest request,
    ServerCallContext context)
  {
    DummyItemGetActionQuery query = request.ToDummyItemGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    Result<DummyItemGetActionDTO> result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionGrpcReply();
  }

  public override async Task<DummyItemGetListActionGrpcReply> GetList(
    DummyItemGetListActionGrpcRequest request,
    ServerCallContext context)
  {
    DummyItemGetListActionQuery query = request.ToDummyItemGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    Result<DummyItemGetListActionDTO> result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetListActionGrpcReply();
  }

  public override async Task<DummyItemGetActionGrpcReply> Update(
    DummyItemUpdateActionGrpcRequest request,
    ServerCallContext context)
  {
    DummyItemUpdateActionCommand command = request.ToDummyItemUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    Result<DummyItemGetActionDTO> result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToDummyItemGetActionGrpcReply();
  }
}
