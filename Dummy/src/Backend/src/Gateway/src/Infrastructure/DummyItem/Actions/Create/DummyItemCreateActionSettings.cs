namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Create;

public class DummyItemCreateActionSettings
{
  public static JsonContent CreateContent(DummyItemCreateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string CreateUri()
  {
    return DummyItemActionsSettings.Root;
  }
}
