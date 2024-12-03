namespace Makc2024.Dummy.Writer.Infrastructure.App.Grpc;

public static class AppGrpcExtensions
{
  public static AppLoginActionCommand ToAppLoginActionCommand(this AppLoginActionGrpcRequest request)
  {
    return new(request.UserName, request.Password); 
  }

  public static AppLoginActionGrpcReply ToAppLoginActionGrpcReply(this AppLoginActionDTO dto)
  {
    return new()
    {
      UserName = dto.UserName,
      AccessToken = dto.AccessToken,
    };
  }
}
