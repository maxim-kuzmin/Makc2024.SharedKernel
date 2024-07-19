namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemCreateActionHandler
{
  public async Task<Result<long>> Handle(DummyItemCreateActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var content = DummyItemCreateActionSettings.CreateContent(request);

    string uri = DummyItemCreateActionSettings.CreateUri();

    using var httpResponse = await httpClient.PostAsync(uri, content, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<long>(cancellationToken);

    return result;
  }
}
