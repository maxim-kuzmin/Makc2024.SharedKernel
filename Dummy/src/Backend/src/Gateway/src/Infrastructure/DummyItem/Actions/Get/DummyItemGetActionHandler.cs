namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    string requestUri = CreateRequestUri(request);

    using var httpResponse = await httpClient.GetAsync(requestUri, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    return result;
  }

  public static string CreateRequestUri(DummyItemGetActionQuery query)
  {
    return $"{DummyItemActionsSettings.Root}/{query.Id}";
  }
}
