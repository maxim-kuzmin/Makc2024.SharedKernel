namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Http;

public class DummyItemHttpService(AppSession _appSession, IHttpClientFactory _httpClientFactory) : IDummyItemService
{
  public async Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = command.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      DummyItemHttpSettings.Root,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

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

  public async Task<Result<DummyItemGetActionDTO>> Update(
      DummyItemUpdateActionCommand command,
      CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = command.ToHttpRequestContent();

    var httpResponseTask = httpClient.PutAsync(
      command.ToHttpRequestUrl(),
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
