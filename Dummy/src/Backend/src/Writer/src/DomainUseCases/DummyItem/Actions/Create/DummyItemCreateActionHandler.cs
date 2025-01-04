namespace Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;

/// <summary>
/// Обработчик действия по созданию фиктивного предмета.
/// </summary>
/// <param name="_service">Сервис.</param>
public class DummyItemCreateActionHandler(IDummyItemCommandService _service) :
  ICommandHandler<DummyItemCreateActionCommand, Result<DummyItemGetActionDTO>>
{
  /// <inheritdoc/>
  public Task<Result<DummyItemGetActionDTO>> Handle(
    DummyItemCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    return _service.Create(request, cancellationToken);
  }
}
