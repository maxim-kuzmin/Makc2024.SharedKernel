namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetByIdActionHandler
{
  public async Task<Result<DummyItemGetByIdActionDTO>> Handle(
    DummyItemGetByIdActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    string requestUri = CreateRequestUri(request);

    using var httpResponse = await httpClient.GetAsync(requestUri, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetByIdActionDTO>(cancellationToken);

    return result;
  }

  public static string CreateRequestUri(DummyItemGetByIdActionQuery query)
  {
    return $"{DummyItemActionsSettings.Root}/{query.Id}";
  }
}
