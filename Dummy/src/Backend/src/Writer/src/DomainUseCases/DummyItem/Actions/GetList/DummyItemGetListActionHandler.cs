namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetListActionHandler(IDummyItemQueryService _service) :
  IQueryHandler<DummyItemGetListActionQuery, Result<DummyItemGetListActionDTO>>
{
  public Task<Result<DummyItemGetListActionDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request, cancellationToken);
  }
}
