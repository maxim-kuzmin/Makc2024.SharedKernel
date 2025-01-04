namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.For.Grpc;

/// <summary>
/// Расширения полезной нагрузки события приложения для gRPC.
/// </summary>
public static class AppEventPayloadExtensionsForGrpc
{
  public static AppEventPayloadCreateActionCommand ToAppEventPayloadCreateActionCommand(
    this AppEventPayloadCreateActionRequestForGrpc request)
  {
    return new(request.Name);
  }

  public static AppEventPayloadDeleteActionCommand ToAppEventPayloadDeleteActionCommand(
    this AppEventPayloadDeleteActionRequestForGrpc request)
  {
    return new(request.Id);
  }

  public static AppEventPayloadGetActionQuery ToAppEventPayloadGetActionQuery(this AppEventPayloadGetActionRequestForGrpc request)
  {
    return new(request.Id);
  }

  public static AppEventPayloadGetActionReplyForGrpc ToAppEventPayloadGetActionReplyForGrpc(this AppEventPayloadGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }

  public static AppEventPayloadGetListActionQuery ToAppEventPayloadGetListActionQuery(
    this AppEventPayloadGetListActionRequestForGrpc request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static AppEventPayloadGetListActionReplyForGrpc ToAppEventPayloadGetListActionGrpcReply(this AppEventPayloadGetListActionDTO dto)
  {
    AppEventPayloadGetListActionReplyForGrpc result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppEventPayloadGetListActionReplyItemForGrpc item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppEventPayloadUpdateActionCommand ToAppEventPayloadUpdateActionCommand(
    this AppEventPayloadUpdateActionRequestForGrpc request)
  {
    return new(request.Id, request.Name);
  }
}
