namespace Makc2024.Dummy.Gateway.Infrastructure.App.Actions.Login;

public class AppLoginActionHandler(
  IHttpClientFactory _httpClientFactory) : IAppLoginActionHandler
{
  public async Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    using var requestContent = CreateRequestContent(request);

    string requestUri = CreateRequestUri();

    using var httpResponse = await httpClient.PostAsync(requestUri, requestContent, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<AppLoginActionDTO>(cancellationToken);

    return result;
  }

  public static JsonContent CreateRequestContent(AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string CreateRequestUri()
  {
    return $"{AppActionsSettings.Root}/login";
  }
}
