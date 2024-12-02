namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionHandler(
  IOptionsSnapshot<AppConfigOptions> _appConfigOptions,
  IHttpClientFactory _httpClientFactory,
  DummyItemGrpc.DummyItemGrpcClient _grpcClient) : IDummyItemUpdateActionHandler
{
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
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
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.UpdateAsync(
        request.ToDummyItemUpdateActionRequest(),
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
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PutAsync(
      request.ToHttpRequestUrl(),
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
