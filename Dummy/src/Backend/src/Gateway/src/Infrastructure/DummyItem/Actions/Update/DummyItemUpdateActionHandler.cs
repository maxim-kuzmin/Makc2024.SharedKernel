namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemUpdateActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    using var httpResponse = await httpClient.PutAsync(
      request.ToHttpRequestUrl(),
      httpRequestContent,
      cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    return result;
  }
}
