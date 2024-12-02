namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetList;

public static class DummyItemGetListActionExtensions
{
  public static string ToHttpRequestUrl(this DummyItemGetListActionQuery request)
  {
    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("CurrentPage", request.Page.Number.ToString()),
      new("ItemsPerPage", request.Page.Size.ToString()),
      new("Query", request.Filter.FullTextSearchQuery)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemActionsSettings.Root}{queryString}";
  }
}
