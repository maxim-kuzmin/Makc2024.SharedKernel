namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Create;

public static class DummyItemCreateActionExtensions
{
  public static JsonContent ToHttpRequestContent(this DummyItemCreateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static DummyItemCreateActionRequest ToDummyItemCreateActionRequest(this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionRequest
    {
      Name = command.Name,
    };
  }
}
