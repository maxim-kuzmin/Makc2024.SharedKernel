namespace Makc2024.Dummy.Writer.Apps.WebApp.DummyItem.Grpc;

public static class DummyItemGrpcExtensions
{
  public static DummyItemCreateActionCommand ToDummyItemCreateActionCommand(this DummyItemCreateActionRequest request)
  {
    return new(request.Name);
  }

  public static DummyItemDeleteActionCommand ToDummyItemDeleteActionCommand(this DummyItemDeleteActionRequest request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionReply ToDummyItemGetActionReply(this DummyItemGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }

  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionRequest request)
  {
    return new(request.Id);
  }

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

  public static DummyItemUpdateActionCommand ToDummyItemUpdateActionCommand(this DummyItemUpdateActionRequest request)
  {
    return new(request.Id, request.Name);
  }
}
