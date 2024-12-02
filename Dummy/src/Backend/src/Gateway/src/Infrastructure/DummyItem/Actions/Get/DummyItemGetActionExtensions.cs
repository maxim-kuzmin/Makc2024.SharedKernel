namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public static class DummyItemGetActionExtensions
{
  public static string ToHttpRequestUrl(this DummyItemGetActionQuery query)
  {
    return $"{DummyItemActionsSettings.Root}/{query.Id}";
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
}
