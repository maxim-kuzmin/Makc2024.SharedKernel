namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemActionQueryService _service) :
  IQueryHandler<DummyItemGetListActionQuery, Result<DummyItemGetListActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemGetListActionDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
