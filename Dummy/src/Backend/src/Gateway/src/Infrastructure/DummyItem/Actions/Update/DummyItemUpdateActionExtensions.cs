namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Update;

public static class DummyItemUpdateActionExtensions
{
  public static JsonContent ToHttpRequestContent(this DummyItemUpdateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string ToHttpRequestUrl(this DummyItemUpdateActionCommand command)
  {
    return $"{DummyItemActionsSettings.Root}/{command.Id}";
  }

  public static DummyItemUpdateActionRequest ToDummyItemUpdateActionRequest(this DummyItemUpdateActionCommand command)
  {
    return new DummyItemUpdateActionRequest
    {
      Id = command.Id,
      Name = command.Name,
    };
  }
}
