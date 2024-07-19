namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemDeleteActionHandler
{
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    string uri = DummyItemDeleteActionSettings.CreateUri(request);

    using var httpResponse = await httpClient.DeleteAsync(uri, cancellationToken);

    return httpResponse.ToResult();
  }
}
