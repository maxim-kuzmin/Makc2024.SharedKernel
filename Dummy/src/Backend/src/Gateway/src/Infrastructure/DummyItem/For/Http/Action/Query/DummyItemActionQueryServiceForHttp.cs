namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Http.Action.Query;

public class DummyItemActionQueryServiceForHttp(AppSession _appSession, IHttpClientFactory _httpClientFactory) :
  IDummyItemQueryService
{
  public async Task<Result<DummyItemGetActionDTO>> Get(
      DummyItemGetActionQuery query,
      CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    var httpResponseTask = httpClient.GetAsync(query.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  public async Task<Result<DummyItemGetListActionDTO>> GetList(
      DummyItemGetListActionQuery query,
      CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetListActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
