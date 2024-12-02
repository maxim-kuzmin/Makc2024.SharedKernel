namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.GetList;

public static class DummyItemGetListActionExtensions
{
  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(this DummyItemGetListActionGrpcRequest request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static DummyItemGetListActionGrpcReply ToDummyItemGetListActionGrpcReply(this DummyItemGetListActionDTO dto)
  {
    DummyItemGetListActionGrpcReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListActionGrpcReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }
}
