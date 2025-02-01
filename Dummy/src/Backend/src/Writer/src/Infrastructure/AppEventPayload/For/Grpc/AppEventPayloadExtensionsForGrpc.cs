using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;

namespace Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.For.Grpc;

/// <summary>
/// Расширения полезной нагрузки события приложения для gRPC.
/// </summary>
public static class AppEventPayloadExtensionsForGrpc
{
  public static AppEventPayloadCreateActionCommand ToAppEventPayloadCreateActionCommand(
    this AppEventPayloadCreateActionRequestForGrpc request)
  {
    return new(request.AppEventId, request.Data);
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

  public static AppEventPayloadGetActionReplyForGrpc ToAppEventPayloadGetActionReplyForGrpc(this AppEventPayloadSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      AppEventId = dto.AppEventId,
      Data = dto.Data,
    };
  }

  public static AppEventPayloadGetListActionQuery ToAppEventPayloadGetListActionQuery(
    this AppEventPayloadGetListActionRequestForGrpc request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static AppEventPayloadGetListActionReplyForGrpc ToAppEventPayloadGetListActionGrpcReply(this AppEventPayloadListDTO dto)
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
    return new(request.Id, request.AppEventId, request.Data);
  }
}
