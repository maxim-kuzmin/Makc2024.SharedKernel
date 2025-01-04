namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Обработчик действия по получению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemGetActionHandler(IDummyItemActionQueryService _service) :
  IQueryHandler<DummyItemGetActionQuery, Result<DummyItemGetActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemGetActionQuery request,
    CancellationToken cancellationToken)
  {
    return _service.Get(request, cancellationToken);
  }
}
