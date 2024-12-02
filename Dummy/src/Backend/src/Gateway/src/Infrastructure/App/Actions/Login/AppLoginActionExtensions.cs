namespace Makc2024.Dummy.Gateway.Infrastructure.App.Actions.Login;

public static class AppLoginActionExtensions
{
  public static JsonContent ToHttpRequestContent(this AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }
}
