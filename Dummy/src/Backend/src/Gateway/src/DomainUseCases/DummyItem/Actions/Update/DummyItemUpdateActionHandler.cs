namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemUpdateActionHandler(IDummyItemActionCommandService _service) :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemGetActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Update(request, cancellationToken);
  }
}
