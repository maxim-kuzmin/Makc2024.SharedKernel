namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(
  IOptionsSnapshot<AppConfigOptions> _appConfigOptions,
  AppSession _appSession,
  IHttpClientFactory _httpClientFactory,
  WriterDummyItemGrpcClient _grpcClient) : IDummyItemGetListActionHandler
{
  public Task<Result<DummyItemGetListActionDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _appConfigOptions.Value.Writer.Transport switch
    {
      AppTransport.Grpc => HandleViaGrpc(request, cancellationToken),
      AppTransport.Http => HandleViaHttp(request, cancellationToken),
      _ => throw new NotImplementedException()
    };
  }

  private async Task<Result<DummyItemGetListActionDTO>> HandleViaGrpc(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    try
    {
      string? accessToken = _appSession.AccessToken;

      Metadata headers = [];

      headers.AddAuthorizationHeader(_appSession);

      var replyTask = _grpcClient.GetListAsync(
        request.ToDummyItemGetListActionGrpcRequest(),
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

  private async Task<Result<DummyItemGetListActionDTO>> HandleViaHttp(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, request.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetListActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
