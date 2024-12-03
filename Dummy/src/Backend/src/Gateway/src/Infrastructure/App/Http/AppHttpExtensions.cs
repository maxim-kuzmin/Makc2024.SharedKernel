namespace Makc2024.Dummy.Gateway.Infrastructure.App.Http;

public static class AppHttpExtensions
{
  public static JsonContent ToHttpRequestContent(this AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }
}
