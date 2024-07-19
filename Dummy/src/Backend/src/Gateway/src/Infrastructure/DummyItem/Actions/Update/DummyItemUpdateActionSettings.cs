namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Update;

public class DummyItemUpdateActionSettings
{
  public static JsonContent CreateContent(DummyItemUpdateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static string CreateUri()
  {
    return DummyItemActionSettings.Root;
  }
}
