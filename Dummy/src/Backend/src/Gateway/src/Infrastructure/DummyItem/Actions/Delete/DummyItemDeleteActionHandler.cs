namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(
  IOptionsSnapshot<AppConfigOptions> _appConfigOptions,
  IHttpClientFactory _httpClientFactory,
  DummyItemGrpc.DummyItemGrpcClient _grpcClient) : IDummyItemDeleteActionHandler
{
  public Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    return _appConfigOptions.Value.Writer.Transport switch
    {
      AppTransport.Grpc => HandleViaGrpc(request, cancellationToken),
      AppTransport.Http => HandleViaHttp(request, cancellationToken),
      _ => throw new NotImplementedException()
    };
  }

  private async Task<Result> HandleViaGrpc(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.DeleteAsync(
        request.ToDummyItemDeleteActionRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success();
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  private async Task<Result> HandleViaHttp(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    var httpResponseTask = httpClient.DeleteAsync(request.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }
}
