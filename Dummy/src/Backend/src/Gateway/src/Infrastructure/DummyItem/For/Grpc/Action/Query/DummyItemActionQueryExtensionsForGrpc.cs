namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Action.Query;

public static class DummyItemActionQueryExtensionsForGrpc
{
  public static DummyItemGetActionRequestForGrpc ToDummyItemGetActionGrpcRequest(this DummyItemGetActionQuery query)
  {
    return new DummyItemGetActionRequestForGrpc
    {
      Id = query.Id,
    };
  }

  public static DummyItemGetListActionRequestForGrpc ToDummyItemGetListActionGrpcRequest(
    this DummyItemGetListActionQuery query)
  {
    return new()
    {
      Page = new ActionRequestPageForGrpc()
      {
        Number = query.Page.Number,
        Size = query.Page.Size,
      },
      Filter = new DummyItemGetListActionRequestFilterForGrpc()
      {
        FullTextSearchQuery = query.Filter.FullTextSearchQuery
      }
    };
  }
}
