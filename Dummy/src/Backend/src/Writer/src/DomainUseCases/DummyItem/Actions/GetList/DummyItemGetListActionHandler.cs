namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemActionQueryService _service) :
  IQueryHandler<DummyItemGetListActionQuery, Result<DummyItemListDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemListDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
