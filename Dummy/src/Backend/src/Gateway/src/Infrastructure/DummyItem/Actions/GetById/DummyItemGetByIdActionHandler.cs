namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetByIdActionHandler
{
  public async Task<Result<DummyItemGetByIdActionDTO>> Handle(
    DummyItemGetByIdActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    string uri = DummyItemGetByIdActionSettings.CreateUri(request);

    using var httpResponse = await httpClient.GetAsync(uri, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetByIdActionDTO>(cancellationToken);

    return result;
  }
}
