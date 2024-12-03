namespace Makc2024.Dummy.Gateway.Infrastructure.App.Http;

public class AppHttpService(IHttpClientFactory _httpClientFactory) : IAppService
{
  public async Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      AppHttpSettings.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppLoginActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
