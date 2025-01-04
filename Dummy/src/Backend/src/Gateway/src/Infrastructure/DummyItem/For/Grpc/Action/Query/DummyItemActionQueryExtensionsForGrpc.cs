namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.For.Grpc.Action.Query;

/// <summary>
/// Расширения запросов действия над фиктивным предметом для gRPC.
/// </summary>
public static class DummyItemActionQueryExtensionsForGrpc
{
  /// <summary>
  /// Преобразовать к запросу действия на получение фиктивного предмета для gRPC.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос действия на получение фиктивного предмета для gRPC.</returns>
  public static DummyItemGetActionRequestForGrpc ToDummyItemGetActionGrpcRequest(this DummyItemGetActionQuery query)
  {
    return new DummyItemGetActionRequestForGrpc
    {
      Id = query.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия на получение списка фиктивных предметов для gRPC.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос действия на получение списка фиктивных предметов для gRPC.</returns>
  public static DummyItemGetListActionRequestForGrpc ToDummyItemGetListActionGrpcRequest(
    this DummyItemGetListActionQuery query)
  {
    return new()
    {
      Page = new ActionRequestPageForGrpc()
      {
        Number = query.Page.Number,
        Size = query.Page.Size,
      },
      Filter = new DummyItemGetListActionRequestFilterForGrpc()
      {
        FullTextSearchQuery = query.Filter.FullTextSearchQuery
      }
    };
  }
}
