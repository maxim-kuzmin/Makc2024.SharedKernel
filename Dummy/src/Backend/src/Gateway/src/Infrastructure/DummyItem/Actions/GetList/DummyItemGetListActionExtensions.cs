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

  public static DummyItemGetListActionRequest ToDummyItemGetListActionRequest(this DummyItemGetListActionQuery query)
  {
    return new()
    {
      Page = new ActionRequestPage()
      {
        Number = query.Page.Number,
        Size = query.Page.Size,
      },
      Filter = new DummyItemGetListActionRequestFilter()
      {
        FullTextSearchQuery = query.Filter.FullTextSearchQuery
      }
    };
  }

  public static DummyItemGetListActionDTO ToDummyItemGetListActionDTO(this DummyItemGetListActionReply reply)
  {
    var items = new List<DummyItemGetListActionDTOItem>(reply.Items.Count);

    foreach (var itemReply in reply.Items)
    {
      DummyItemGetListActionDTOItem item = new(itemReply.Id, itemReply.Name);

      items.Add(item);
    }

    return new(items, reply.TotalCount);
  }
}
