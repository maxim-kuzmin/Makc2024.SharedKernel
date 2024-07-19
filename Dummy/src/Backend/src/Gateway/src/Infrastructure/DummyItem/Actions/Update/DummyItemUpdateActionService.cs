namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionService(
  IHttpClientFactory _httpClientFactory) : IDummyItemUpdateActionService
{
  public async Task<Result<DummyItemUpdateActionDTO>> UpdateAsync(
    DummyItemUpdateActionCommand command,
    CancellationToken cancellationToken = default)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var httpRequest = JsonContent.Create(command);

    using var httpResponse = await httpClient.PutAsync("dummy-items", httpRequest, cancellationToken);

    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
    {
      return Result.Unauthorized();
    }

    httpResponse.EnsureSuccessStatusCode();

    var response = await httpResponse.Content.ReadFromJsonAsync<DummyItemUpdateActionDTO?>(cancellationToken);

    if (response == null)
    {
      return Result.NotFound();
    }

    return Result.Success(response);
  }
}
