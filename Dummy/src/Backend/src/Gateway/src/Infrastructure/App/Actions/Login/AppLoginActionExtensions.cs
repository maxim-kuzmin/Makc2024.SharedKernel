﻿namespace Makc2024.Dummy.Gateway.Infrastructure.App.Actions.Login;

public static class AppLoginActionExtensions
{
  public static JsonContent ToHttpRequestContent(this AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static AppLoginActionRequest ToAppLoginActionRequest(this AppLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  public static AppLoginActionDTO ToAppLoginActionDTO(this AppLoginActionReply reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}
