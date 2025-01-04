namespace Makc2024.Dummy.Gateway.Infrastructure.App.For.Http.Action.Command;

/// <summary>
/// Сервис команд действия над приложением.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppActionCommandServiceForHttp(IHttpClientFactory _httpClientFactory) : IAppActionCommandService
{
  public async Task<Result<AppLoginActionDTO>> Login(
    AppLoginActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      AppSettingsForHttp.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppLoginActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
