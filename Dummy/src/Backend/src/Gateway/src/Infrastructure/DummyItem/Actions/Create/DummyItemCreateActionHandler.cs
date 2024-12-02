namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemCreateActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      DummyItemActionsSettings.Root,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
