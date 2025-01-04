using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Action.Command;

namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Http.Action.Command;

/// <summary>
/// Сервис команд действия над фиктивным предметом для HTTP.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class DummyItemActionCommandServiceForHttp(
  IHttpClientFactory _httpClientFactory) : IDummyItemActionCommandService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemGetActionDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = command.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      DummyItemSettingsForHttp.Root,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemGetActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  /// <inheritdoc/>
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
