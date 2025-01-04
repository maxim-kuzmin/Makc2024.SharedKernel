namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemUpdateActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemGetActionDTO>>
{
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Update(request, cancellationToken);
  }
}
