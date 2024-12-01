namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionHandler(
  AppSession _appSession,
  IHttpClientFactory _httpClientFactory) : IDummyItemGetListActionHandler
{
  public async Task<Result<DummyItemGetListActionDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    string requestUri = CreateRequestUri(request);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

    string? accessToken = _appSession.AccessToken;

    if (!string.IsNullOrEmpty(accessToken))
    {
      httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    using var httpResponse = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemGetListActionDTO>(cancellationToken);

    return result;
  }

  public static string CreateRequestUri(DummyItemGetListActionQuery request)
  {
    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("CurrentPage", request.Page.Number.ToString()),
      new("ItemsPerPage", request.Page.Size.ToString()),
      new("Query", request.Filter.FullTextSearchQuery)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemActionsSettings.Root}{queryString}";
  }
}
