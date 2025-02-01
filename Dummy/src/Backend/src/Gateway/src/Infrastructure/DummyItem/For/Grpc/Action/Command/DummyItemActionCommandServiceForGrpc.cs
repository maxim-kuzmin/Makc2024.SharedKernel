namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Action.Command;

/// <summary>
/// Сервис команд действия с фиктивным предметом для gRPC.
/// </summary>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class DummyItemActionCommandServiceForGrpc(
  WriterDummyItemGrpcClient _grpcClient) : IDummyItemActionCommandService
{
  /// <inheritdoc/>
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

  /// <inheritdoc/>
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

  /// <inheritdoc/>
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
