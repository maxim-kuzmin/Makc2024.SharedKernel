namespace Makc2024.Dummy.Gateway.Infrastructure.App.Actions.Login;

public class AppLoginActionHandler(
  IHttpClientFactory _httpClientFactory) : IAppLoginActionHandler
{
  public async Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    using var httpResponse = await httpClient.PostAsync(
      AppActionsSettings.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<AppLoginActionDTO>(cancellationToken);

    return result;
  }
}
