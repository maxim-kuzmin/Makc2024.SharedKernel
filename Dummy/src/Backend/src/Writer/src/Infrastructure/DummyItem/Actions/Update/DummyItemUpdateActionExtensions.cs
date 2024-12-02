namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Update;

public static class DummyItemUpdateActionExtensions
{
  public static DummyItemUpdateActionCommand ToDummyItemUpdateActionCommand(this DummyItemUpdateActionRequest request)
  {
    return new(request.Id, request.Name);
  }
}
