namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Command;

public class DummyItemGrpcCommandService(WriterDummyItemGrpcClient _grpcClient) :
  IDummyItemCommandService
{
  public async Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.CreateAsync(
        command.ToDummyItemCreateActionGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemGetActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.DeleteAsync(
        command.ToDummyItemDeleteActionGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<DummyItemGetActionDTO>> Update(
      DummyItemUpdateActionCommand command,
      CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.UpdateAsync(
        command.ToDummyItemUpdateActionGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemGetActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }
}
