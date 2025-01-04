namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Action.Command;

/// <summary>
/// Расширения команд действия над фиктивным предметом для gRPC.
/// </summary>
public static class DummyItemActionCommandExtensionsForGrpc
{
  /// <summary>
  /// Преобразовать к запросу действия по созданию фиктивного предмета для gRPC.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по созданию фиктивного предмета для gRPC.</returns>
  public static DummyItemCreateActionRequestForGrpc ToDummyItemCreateActionGrpcRequest(
    this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionRequestForGrpc
    {
      Name = command.Name,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по удалению фиктивного предмета для gRPC.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по удалению фиктивного предмета для gRPC.</returns>
  public static DummyItemDeleteActionRequestForGrpc ToDummyItemDeleteActionGrpcRequest(
    this DummyItemDeleteActionCommand command)
  {
    return new DummyItemDeleteActionRequestForGrpc
    {
      Id = command.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия по обновлению фиктивного предмета для gRPC.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по обновлению фиктивного предмета для gRPC.</returns>
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
