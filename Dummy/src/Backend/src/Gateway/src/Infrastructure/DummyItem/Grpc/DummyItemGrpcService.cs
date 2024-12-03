namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Grpc;

public class DummyItemGrpcService(AppSession _appSession, WriterDummyItemGrpcClient _grpcClient) : IDummyItemService
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

  public async Task<Result<DummyItemGetActionDTO>> Get(
      DummyItemGetActionQuery query,
      CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.GetAsync(
        query.ToDummyItemGetActionGrpcRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemGetActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  public async Task<Result<DummyItemGetListActionDTO>> GetList(
      DummyItemGetListActionQuery query,
      CancellationToken cancellationToken)
  {
    try
    {
      string? accessToken = _appSession.AccessToken;
      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var replyTask = _grpcClient.GetListAsync(
        query.ToDummyItemGetListActionGrpcRequest(),
        headers,
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemGetListActionDTO());
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
