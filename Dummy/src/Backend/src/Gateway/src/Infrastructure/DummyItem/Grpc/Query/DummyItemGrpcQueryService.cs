namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Grpc.Query;

public class DummyItemGrpcQueryService(AppSession _appSession, WriterDummyItemGrpcClient _grpcClient) :
  IDummyItemQueryService
{
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
