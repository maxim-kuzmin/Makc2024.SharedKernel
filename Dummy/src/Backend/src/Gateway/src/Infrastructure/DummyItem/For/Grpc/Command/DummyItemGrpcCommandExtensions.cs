namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Command;

public static class DummyItemGrpcCommandExtensions
{
  public static DummyItemCreateActionRequestForGrpc ToDummyItemCreateActionGrpcRequest(
    this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionRequestForGrpc
    {
      Name = command.Name,
    };
  }

  public static DummyItemDeleteActionRequestForGrpc ToDummyItemDeleteActionGrpcRequest(
    this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionRequestForGrpc
    {
      Id = command.Id,
    };
  }

  public static DummyItemUpdateActionRequestForGrpc ToDummyItemUpdateActionGrpcRequest(
    this DummyItemUpdateActionCommand command)
  {
    return new DummyItemUpdateActionRequestForGrpc
    {
      Id = command.Id,
      Name = command.Name,
    };
  }
}
