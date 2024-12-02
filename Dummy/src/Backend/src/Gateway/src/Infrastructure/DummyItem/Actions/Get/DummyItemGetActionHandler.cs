namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(
  IOptionsSnapshot<AppConfigOptions> _appConfigOptions,
  IHttpClientFactory _httpClientFactory,
  DummyItemGrpc.DummyItemGrpcClient _grpcClient) : IDummyItemGetActionHandler
{
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    return _appConfigOptions.Value.Writer.Transport switch
    {
      AppTransport.Grpc => HandleViaGrpc(request, cancellationToken),
      AppTransport.Http => HandleViaHttp(request, cancellationToken),
      _ => throw new NotImplementedException()
    };
  }

  private async Task<Result<DummyItemGetActionDTO>> HandleViaGrpc(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.GetAsync(
        request.ToDummyItemGetActionRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToDummyItemGetActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  private async Task<Result<DummyItemGetActionDTO>> HandleViaHttp(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    var httpResponseTask = httpClient.GetAsync(request.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
