namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetListActionHandler
{
  public async Task<Result<List<DummyItemGetListActionDTO>>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    string uri = DummyItemGetListActionSettings.CreateUri(request);

    using var httpResponse = await httpClient.GetAsync(uri, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<List<DummyItemGetListActionDTO>>(cancellationToken);

    return result;
  }
}
