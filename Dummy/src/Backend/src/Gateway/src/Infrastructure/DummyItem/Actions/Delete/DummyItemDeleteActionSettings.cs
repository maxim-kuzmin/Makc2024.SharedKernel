namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Delete;

public class DummyItemDeleteActionSettings
{
  public static string CreateUri(DummyItemDeleteActionCommand command)
  {
    return $"{DummyItemActionSettings.Root}/{command.Id}";
  }
}
