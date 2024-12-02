namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemDeleteActionHandler
{
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    var httpResponseTask = httpClient.DeleteAsync(request.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }
}
