namespace Makc2024.Dummy.Gateway.Infrastructure.App.Actions.Login;

public class AppLoginActionHandler(
  IOptionsSnapshot<AppConfigOptions> _appConfigOptions,
  IHttpClientFactory _httpClientFactory,
  AppGrpc.AppGrpcClient _grpcClient) : IAppLoginActionHandler
{
  public Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    return _appConfigOptions.Value.Writer.Transport switch
    {
      AppTransport.Grpc => HandleViaGrpc(request, cancellationToken),
      AppTransport.Http => HandleViaHttp(request, cancellationToken),
      _ => throw new NotImplementedException()
    };
  }

  private async Task<Result<AppLoginActionDTO>> HandleViaGrpc(
    AppLoginActionCommand request,
    CancellationToken cancellationToken)
  {
    try
    {
      var replyTask = _grpcClient.LoginAsync(
        request.ToAppLoginActionRequest(),
        cancellationToken: cancellationToken);

      var reply = await replyTask.ConfigureAwait(false);

      return Result.Success(reply.ToAppLoginActionDTO());
    }
    catch (RpcException ex)
    {
      return ex.ToUnsuccessfulResult();
    }
  }

  private async Task<Result<AppLoginActionDTO>> HandleViaHttp(
    AppLoginActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      AppActionsSettings.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppLoginActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
