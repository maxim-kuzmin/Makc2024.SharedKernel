namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Delete;

public static class DummyItemDeleteActionExtensions
{
  public static string ToHttpRequestUrl(this DummyItemDeleteActionCommand command)
  {
    return $"{DummyItemActionsSettings.Root}/{command.Id}";
  }

  public static DummyItemDeleteActionRequest ToDummyItemDeleteActionRequest(this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionRequest
    {
      Id = command.Id,
    };
  }
}
