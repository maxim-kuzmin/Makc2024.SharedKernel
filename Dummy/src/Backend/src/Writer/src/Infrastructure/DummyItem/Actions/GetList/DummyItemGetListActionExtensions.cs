namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetList;

public static class DummyItemGetListActionExtensions
{
  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(this DummyItemGetListActionRequest request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static DummyItemGetListActionReply ToDummyItemGetListActionReply(this DummyItemGetListActionDTO dto)
  {
    DummyItemGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }
}
