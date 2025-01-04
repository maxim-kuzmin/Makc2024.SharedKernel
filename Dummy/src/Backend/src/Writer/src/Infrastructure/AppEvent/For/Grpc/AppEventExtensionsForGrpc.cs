namespace Makc2024.Dummy.Writer.Infrastructure.AppEvent.For.Grpc;

/// <summary>
/// Расширения события приложения для gRPC.
/// </summary>
public static class AppEventExtensionsForGrpc
{
  public static AppEventCreateActionCommand ToAppEventCreateActionCommand(
    this AppEventCreateActionRequestForGrpc request)
  {
    return new(request.Name);
  }

  public static AppEventDeleteActionCommand ToAppEventDeleteActionCommand(
    this AppEventDeleteActionRequestForGrpc request)
  {
    return new(request.Id);
  }

  public static AppEventGetActionQuery ToAppEventGetActionQuery(this AppEventGetActionRequestForGrpc request)
  {
    return new(request.Id);
  }

  public static AppEventGetActionReplyForGrpc ToAppEventGetActionReplyForGrpc(this AppEventGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }

  public static AppEventGetListActionQuery ToAppEventGetListActionQuery(
    this AppEventGetListActionRequestForGrpc request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static AppEventGetListActionReplyForGrpc ToAppEventGetListActionGrpcReply(this AppEventGetListActionDTO dto)
  {
    AppEventGetListActionReplyForGrpc result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppEventGetListActionReplyItemForGrpc item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppEventUpdateActionCommand ToAppEventUpdateActionCommand(
    this AppEventUpdateActionRequestForGrpc request)
  {
    return new(request.Id, request.Name);
  }
}
