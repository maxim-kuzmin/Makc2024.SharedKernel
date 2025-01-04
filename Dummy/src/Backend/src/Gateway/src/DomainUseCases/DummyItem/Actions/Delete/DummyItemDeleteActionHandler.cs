namespace Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(IDummyItemActionCommandService _service) :
  ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Delete(request, cancellationToken);
  }
}
