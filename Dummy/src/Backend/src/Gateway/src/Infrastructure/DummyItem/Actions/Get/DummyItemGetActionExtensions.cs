namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public static class DummyItemGetActionExtensions
{
  public static string ToHttpRequestUrl(this DummyItemGetActionQuery query)
  {
    return $"{DummyItemActionsSettings.Root}/{query.Id}";
  }

  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(this DummyItemGetActionQuery query)
  {
    return new DummyItemGetActionRequest
    {
      Id = query.Id,
    };
  }

  public static DummyItemGetActionDTO ToDummyItemGetActionDTO(this DummyItemGetActionReply reply)
  {
    return new(reply.Id, reply.Name);
  }
}
