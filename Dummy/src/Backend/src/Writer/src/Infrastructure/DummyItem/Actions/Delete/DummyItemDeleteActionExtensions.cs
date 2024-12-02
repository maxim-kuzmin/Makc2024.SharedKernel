namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Delete;

public static class DummyItemDeleteActionExtensions
{
  public static DummyItemDeleteActionCommand ToDummyItemDeleteActionCommand(this DummyItemDeleteActionGrpcRequest request)
  {
    return new(request.Id);
  }
}
