namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionService(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetListActionService
{
  public async Task<Result<IEnumerable<DummyItemGetListActionDTO>>> GetListAsync(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken = default)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    var request = new DummyItemGetListActionRequest(
      query.Page.Number,
      query.Page.Count,
      query.Filter.FullTextSearchQuery);

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new(nameof(request.CurrentPage), request.CurrentPage.ToString()),
      new(nameof(request.ItemsPerPage), request.ItemsPerPage.ToString()),
      new(nameof(request.Query), request.Query)
    ];

    var queryString = QueryString.Create(parameters);

    string url = $"dummy-items{queryString}";

    using var httpResponse = await httpClient.GetAsync(url, cancellationToken);

    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
    {
      return Result.Unauthorized();
    }

    httpResponse.EnsureSuccessStatusCode();

    var response = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<DummyItemGetListActionDTO>>(cancellationToken);

    if (response == null)
    {
      return Result.Error();
    }

    return Result.Success(response);
  }
}
