namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemUpdateActionHandler
{
  public async Task<Result<DummyItemUpdateActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var requestContent = CreateRequestContent(request);

    string requestUri = CreateRequestUri(request);

    using var httpResponse = await httpClient.PutAsync(requestUri, requestContent, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<DummyItemUpdateActionDTO>(cancellationToken);

    return result;
  }

  public static JsonContent CreateRequestContent(DummyItemUpdateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string CreateRequestUri(DummyItemUpdateActionCommand command)
  {
    return $"{DummyItemActionsSettings.Root}/{command.Id}";
  }
}
