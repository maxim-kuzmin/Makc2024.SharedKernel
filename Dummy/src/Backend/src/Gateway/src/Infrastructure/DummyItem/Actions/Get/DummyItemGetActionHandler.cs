namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    using var httpResponse = await httpClient.GetAsync(request.ToHttpRequestUrl(), cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    return result;
  }
}
