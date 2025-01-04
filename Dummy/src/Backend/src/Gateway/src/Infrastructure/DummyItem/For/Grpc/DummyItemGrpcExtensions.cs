namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc;

public static class DummyItemGrpcExtensions
{
  public static DummyItemGetActionDTO ToDummyItemGetActionDTO(this DummyItemGetActionReplyForGrpc reply)
  {
    return new(reply.Id, reply.Name);
  }

  public static DummyItemGetListActionDTO ToDummyItemGetListActionDTO(this DummyItemGetListActionReplyForGrpc reply)
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
