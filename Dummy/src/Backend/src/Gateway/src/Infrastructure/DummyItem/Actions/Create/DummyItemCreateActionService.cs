namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionService(
  IHttpClientFactory _httpClientFactory) : IDummyItemCreateActionService
{
  public async Task<Result<long>> CreateAsync(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken = default)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var httpRequest = JsonContent.Create(command);

    using var httpResponse = await httpClient.PostAsync("dummy-items", httpRequest, cancellationToken);

    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
    {
      return Result.Unauthorized();
    }

    httpResponse.EnsureSuccessStatusCode();

    var response = await httpResponse.Content.ReadFromJsonAsync<long?>(cancellationToken);

    if (!response.HasValue)
    {
      return Result.NotFound();
    }

    return Result.Success(response.Value);
  }
}
