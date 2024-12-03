namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Grpc.Query;

public static class DummyItemGrpcQueryExtensions
{
  public static DummyItemGetActionGrpcRequest ToDummyItemGetActionGrpcRequest(this DummyItemGetActionQuery query)
  {
    return new DummyItemGetActionGrpcRequest
    {
      Id = query.Id,
    };
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
}
