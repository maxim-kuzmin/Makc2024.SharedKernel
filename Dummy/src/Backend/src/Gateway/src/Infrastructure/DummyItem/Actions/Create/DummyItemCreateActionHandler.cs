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

    using var httpResponse = await httpClient.PostAsync(
      DummyItemActionsSettings.Root,
      httpRequestContent,
      cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    return result;
  }
}
