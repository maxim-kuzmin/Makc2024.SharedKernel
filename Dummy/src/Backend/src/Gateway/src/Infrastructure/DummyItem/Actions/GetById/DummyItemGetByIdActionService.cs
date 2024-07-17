namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionService(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetByIdActionService
{
  public async Task<Result<DummyItemGetByIdActionDTO>> GetByIdAsync(
    DummyItemGetByIdActionQuery query,
    CancellationToken cancellationToken = default)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var httpResponse = await httpClient.GetAsync($"dummy-items/{query.Id}", cancellationToken);

    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
    {
      return Result.Unauthorized();
    }

    httpResponse.EnsureSuccessStatusCode();

    var response = await httpResponse.Content.ReadFromJsonAsync<DummyItemGetByIdActionDTO?>(cancellationToken);

    if (response == null)
    {
      return Result.Error();
    }

    return Result.Success(response);
  }
}
