namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Grpc;

public static class DummyItemGrpcExtensions
{
  public static DummyItemCreateActionCommand ToDummyItemCreateActionCommand(
    this DummyItemCreateActionGrpcRequest request)
  {
    return new(request.Name);
  }

  public static DummyItemDeleteActionCommand ToDummyItemDeleteActionCommand(
    this DummyItemDeleteActionGrpcRequest request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionGrpcRequest request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionGrpcReply ToDummyItemGetActionGrpcReply(this DummyItemGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }

  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(
    this DummyItemGetListActionGrpcRequest request)
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

  public static DummyItemUpdateActionCommand ToDummyItemUpdateActionCommand(
    this DummyItemUpdateActionGrpcRequest request)
  {
    return new(request.Id, request.Name);
  }
}
