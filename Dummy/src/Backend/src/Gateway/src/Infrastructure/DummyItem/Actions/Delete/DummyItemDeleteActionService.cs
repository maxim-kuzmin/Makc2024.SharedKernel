namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionService(
  IHttpClientFactory _httpClientFactory) : IDummyItemDeleteActionService
{
  public async Task<Result<bool>> DeleteAsync(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken = default)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var httpResponse = await httpClient.DeleteAsync($"dummy-items/{command.Id}", cancellationToken);

    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
    {
      return Result.Unauthorized();
    }

    httpResponse.EnsureSuccessStatusCode();

    var response = await httpResponse.Content.ReadFromJsonAsync<bool>(cancellationToken);

    return Result.Success(response);
  }
}
