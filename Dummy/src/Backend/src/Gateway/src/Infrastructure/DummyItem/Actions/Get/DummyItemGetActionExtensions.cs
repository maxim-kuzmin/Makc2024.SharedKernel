namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Get;

public static class DummyItemGetActionExtensions
{
  public static string ToHttpRequestUrl(this DummyItemGetActionQuery query)
  {
    return $"{DummyItemActionsSettings.Root}/{query.Id}";
  }
}
