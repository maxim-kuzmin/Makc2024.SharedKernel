namespace Makc2024.Dummy.Gateway.Infrastructure.App.For.Grpc;

public static class AppExtensionsForGrpc
{
  public static AppLoginActionRequestForGrpc ToAppLoginActionGrpcRequest(this AppLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  public static AppLoginActionDTO ToAppLoginActionDTO(this AppLoginActionReplyForGrpc reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}
