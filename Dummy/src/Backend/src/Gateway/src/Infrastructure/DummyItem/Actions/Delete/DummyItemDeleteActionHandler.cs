namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemDeleteActionHandler
{
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    using var httpResponse = await httpClient.DeleteAsync(request.ToHttpRequestUrl(), cancellationToken);

    return httpResponse.ToResult();
  }
}
