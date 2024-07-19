namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetList;

public class DummyItemGetListActionSettings
{
  public static string CreateUri(DummyItemGetListActionQuery request)
  {
    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("CurrentPage", request.Page.Number.ToString()),
      new("ItemsPerPage", request.Page.Count.ToString()),
      new("Query", request.Filter.FullTextSearchQuery)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemActionSettings.Root}{queryString}";
  }
}
