namespace Makc2024.Dummy.Gateway.Infrastructure.App.Grpc;

public static class AppGrpcExtensions
{
  public static AppLoginActionGrpcRequest ToAppLoginActionGrpcRequest(this AppLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  public static AppLoginActionDTO ToAppLoginActionDTO(this AppLoginActionGrpcReply reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}
