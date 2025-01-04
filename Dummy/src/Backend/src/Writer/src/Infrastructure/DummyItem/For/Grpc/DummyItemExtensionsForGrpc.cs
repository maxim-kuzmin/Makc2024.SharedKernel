namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.For.Grpc;

/// <summary>
/// Расширения фиктивного предмета для gRPC.
/// </summary>
public static class DummyItemExtensionsForGrpc
{
  public static DummyItemCreateActionCommand ToDummyItemCreateActionCommand(
    this DummyItemCreateActionRequestForGrpc request)
  {
    return new(request.Name);
  }

  public static DummyItemDeleteActionCommand ToDummyItemDeleteActionCommand(
    this DummyItemDeleteActionRequestForGrpc request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionRequestForGrpc request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionReplyForGrpc ToDummyItemGetActionReplyForGrpc(this DummyItemGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }

  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(
    this DummyItemGetListActionRequestForGrpc request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static DummyItemGetListActionReplyForGrpc ToDummyItemGetListActionGrpcReply(this DummyItemGetListActionDTO dto)
  {
    DummyItemGetListActionReplyForGrpc result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListActionReplyItemForGrpc item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static DummyItemUpdateActionCommand ToDummyItemUpdateActionCommand(
    this DummyItemUpdateActionRequestForGrpc request)
  {
    return new(request.Id, request.Name);
  }
}
