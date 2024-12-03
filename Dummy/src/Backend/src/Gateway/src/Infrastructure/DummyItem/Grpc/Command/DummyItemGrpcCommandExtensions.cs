namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Grpc.Command;

public static class DummyItemGrpcCommandExtensions
{
  public static DummyItemCreateActionGrpcRequest ToDummyItemCreateActionGrpcRequest(
    this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionGrpcRequest
    {
      Name = command.Name,
    };
  }

  public static DummyItemDeleteActionGrpcRequest ToDummyItemDeleteActionGrpcRequest(
    this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionGrpcRequest
    {
      Id = command.Id,
    };
  }

  public static DummyItemUpdateActionGrpcRequest ToDummyItemUpdateActionGrpcRequest(
    this DummyItemUpdateActionCommand command)
  {
    return new DummyItemUpdateActionGrpcRequest
    {
      Id = command.Id,
      Name = command.Name,
    };
  }
}
