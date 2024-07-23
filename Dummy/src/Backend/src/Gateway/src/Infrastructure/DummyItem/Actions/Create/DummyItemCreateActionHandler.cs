namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionHandler(
  IHttpClientFactory _httpClientFactory) : IDummyItemCreateActionHandler
{
  public async Task<Result<long>> Handle(DummyItemCreateActionCommand request, CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(nameof(AppConfigOptionsWriter));

    using var requestContent = CreateRequestContent(request);

    string requestUri = CreateRequestUri();

    using var httpResponse = await httpClient.PostAsync(requestUri, requestContent, cancellationToken);

    var result = await httpResponse.ToResultFromJsonAsync<long>(cancellationToken);

    return result;
  }

  public static JsonContent CreateRequestContent(DummyItemCreateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string CreateRequestUri()
  {
    return DummyItemActionsSettings.Root;
  }
}
