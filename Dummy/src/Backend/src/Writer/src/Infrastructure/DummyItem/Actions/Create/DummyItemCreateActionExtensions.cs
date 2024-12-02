namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Create;

public static class DummyItemCreateActionExtensions
{
  public static DummyItemCreateActionCommand ToDummyItemCreateActionCommand(this DummyItemCreateActionRequest request)
  {
    return new(request.Name);
  }
}
