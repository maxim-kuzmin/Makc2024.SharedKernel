namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public class DummyItemGetActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemGetActionHandler
{
  public async Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterClientName);

    var httpResponseTask = httpClient.GetAsync(request.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
