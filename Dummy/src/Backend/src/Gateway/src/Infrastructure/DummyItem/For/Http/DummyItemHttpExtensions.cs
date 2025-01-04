namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Http;

public static class DummyItemHttpExtensions
{
  public static JsonContent ToHttpRequestContent(this DummyItemCreateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string ToHttpRequestUrl(this DummyItemDeleteActionCommand command)
  {
    return $"{DummyItemHttpSettings.Root}/{command.Id}";
  }

  public static string ToHttpRequestUrl(this DummyItemGetActionQuery query)
  {
    return $"{DummyItemHttpSettings.Root}/{query.Id}";
  }

  public static string ToHttpRequestUrl(this DummyItemGetListActionQuery request)
  {
    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("CurrentPage", request.Page.Number.ToString()),
      new("ItemsPerPage", request.Page.Size.ToString()),
      new("Query", request.Filter.FullTextSearchQuery)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemHttpSettings.Root}{queryString}";
  }

  public static JsonContent ToHttpRequestContent(this DummyItemUpdateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string ToHttpRequestUrl(this DummyItemUpdateActionCommand command)
  {
    return $"{DummyItemHttpSettings.Root}/{command.Id}";
  }
}
