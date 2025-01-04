namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc;

/// <summary>
/// Расширения фиктивного предмета для gRPC.
/// </summary>
public static class DummyItemExtensionsForGrpc
{
  /// <summary>
  /// Преобразовать к объекту передачи данных действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по получению фиктивного предмета.</returns>
  public static DummyItemGetActionDTO ToDummyItemGetActionDTO(this DummyItemGetActionReplyForGrpc reply)
  {
    return new(reply.Id, reply.Name);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по получению списка фиктивных предметов.</returns>
  public static DummyItemGetListActionDTO ToDummyItemGetListActionDTO(this DummyItemGetListActionReplyForGrpc reply)
  {
    var items = new List<DummyItemGetListActionDTOItem>(reply.Items.Count);

    foreach (var itemReply in reply.Items)
    {
      DummyItemGetListActionDTOItem item = new(itemReply.Id, itemReply.Name);

      items.Add(item);
    }

    return new(items, reply.TotalCount);
  }
}
