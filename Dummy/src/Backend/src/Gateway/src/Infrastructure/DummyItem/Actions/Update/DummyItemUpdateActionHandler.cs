namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemUpdateActionHandler
{
  public async Task<Result<DummyItemUpdateActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var content = DummyItemUpdateActionSettings.CreateContent(request);

    string uri = DummyItemUpdateActionSettings.CreateUri();

    using var httpResponse = await httpClient.PutAsync(uri, content, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemUpdateActionDTO>(cancellationToken);

    return result;
  }
}
