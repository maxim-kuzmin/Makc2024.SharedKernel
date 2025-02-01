namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Action.Query;

/// <summary>
/// Сервис запросов действия с фиктивным предметом для gRPC.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_grpcClient">Клиент gRPC.</param>
public class DummyItemActionQueryServiceForGrpc(
  AppSession _appSession,
  WriterDummyItemGrpcClient _grpcClient) : IDummyItemActionQueryService
{
  /// <inheritdoc/>
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

  /// <inheritdoc/>
  public async Task<Result<DummyItemGetListActionDTO>> GetList(
      DummyItemGetListActionQuery query,
      CancellationToken cancellationToken)
  {
    try
    {
      var accessToken = _appSession.AccessToken;
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
}
