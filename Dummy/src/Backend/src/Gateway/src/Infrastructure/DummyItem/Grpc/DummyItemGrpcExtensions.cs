namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Grpc;

public static class DummyItemGrpcExtensions
{
  public static DummyItemCreateActionGrpcRequest ToDummyItemCreateActionGrpcRequest(
    this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionGrpcRequest
    {
      Name = command.Name,
    };
  }

  public static DummyItemDeleteActionGrpcRequest ToDummyItemDeleteActionGrpcRequest(
    this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionGrpcRequest
    {
      Id = command.Id,
    };
  }

  public static DummyItemGetActionGrpcRequest ToDummyItemGetActionGrpcRequest(this DummyItemGetActionQuery query)
  {
    return new DummyItemGetActionGrpcRequest
    {
      Id = query.Id,
    };
  }

  public static DummyItemGetActionDTO ToDummyItemGetActionDTO(this DummyItemGetActionGrpcReply reply)
  {
    return new(reply.Id, reply.Name);
  }

  public static DummyItemGetListActionGrpcRequest ToDummyItemGetListActionGrpcRequest(
    this DummyItemGetListActionQuery query)
  {
    return new()
    {
      Page = new ActionGrpcRequestPage()
      {
        Number = query.Page.Number,
        Size = query.Page.Size,
      },
      Filter = new DummyItemGetListActionGrpcRequestFilter()
      {
        FullTextSearchQuery = query.Filter.FullTextSearchQuery
      }
    };
  }

  public static DummyItemGetListActionDTO ToDummyItemGetListActionDTO(this DummyItemGetListActionGrpcReply reply)
  {
    var items = new List<DummyItemGetListActionDTOItem>(reply.Items.Count);

    foreach (var itemReply in reply.Items)
    {
      DummyItemGetListActionDTOItem item = new(itemReply.Id, itemReply.Name);

      items.Add(item);
    }

    return new(items, reply.TotalCount);
  }

  public static DummyItemUpdateActionGrpcRequest ToDummyItemUpdateActionGrpcRequest(
    this DummyItemUpdateActionCommand command)
  {
    return new DummyItemUpdateActionGrpcRequest
    {
      Id = command.Id,
      Name = command.Name,
    };
  }
}
